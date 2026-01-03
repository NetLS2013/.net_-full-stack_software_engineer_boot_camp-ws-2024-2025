using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace ReferenceExperiments
{
    public class Car
    {
        public string Color;

        public Car(string color)
        {
            Color = color;
        }
    }

    public static class ReferenceHelpers
    {
        public static readonly Action<object, Action<IntPtr>> GetPinnedPtr;

        static ReferenceHelpers()
        {
            var dyn = new DynamicMethod(
                "GetPinnedPtr",
                typeof(void),
                new[] { typeof(object), typeof(Action<IntPtr>) },
                typeof(ReferenceHelpers).Module
            );

            var il = dyn.GetILGenerator();
            il.DeclareLocal(typeof(object), true);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Conv_I);
            il.Emit(OpCodes.Call, typeof(Action<IntPtr>).GetMethod("Invoke"));
            il.Emit(OpCodes.Ret);

            GetPinnedPtr =
                (Action<object, Action<IntPtr>>)dyn.CreateDelegate(
                    typeof(Action<object, Action<IntPtr>>));
        }
    }

    public static class ReferenceTypeExperiment
    {
        public static void Run()
        {
            Car car = new Car("blue");
            Console.WriteLine($"Car color: {car.Color}");

            ReferenceHelpers.GetPinnedPtr(car, ptr =>
            {
                Console.WriteLine($"Pinned address: 0x{ptr:X}");
                IntPtr typeHandle = Marshal.ReadIntPtr(ptr);
                Console.WriteLine(
                    $"TypeHandle match: {typeHandle == typeof(Car).TypeHandle.Value}"
                );
            });

            // --- Reference Types ---
            Console.WriteLine("\n=== REFERENCE TYPES CAR ===");
            Car car1 = new Car("Red");
            Car car2 = car1;

            Console.WriteLine($"Car color: {car1.Color}");
            ReferenceHelpers.GetPinnedPtr(car1,
                ptr => Console.WriteLine($"Address of car1: 0x{ptr:X}"));
            ReferenceHelpers.GetPinnedPtr(car2,
                ptr => Console.WriteLine($"Address of car2: 0x{ptr:X}"));

            // --- Value Types ---
            Console.WriteLine("\n=== VALUE TYPES INT ===");
            int val1 = 42;
            int val2 = val1;

            ReferenceHelpers.GetPinnedPtr(val1,
                ptr => Console.WriteLine($"Address of val1 (boxed): 0x{ptr:X}"));
            ReferenceHelpers.GetPinnedPtr(val2,
                ptr => Console.WriteLine($"Address of val2 (boxed): 0x{ptr:X}"));
        }
    }
}
