namespace ValueAndReferenceTypes
{
    using System;
    using System.Reflection.Emit;

    public static class ReferenceHelpers
    {
        public static readonly Action<object, Action<IntPtr>> GetPinnedPtr;

        static ReferenceHelpers()
        {
            var dyn = new DynamicMethod(
                "GetPinnedPtr",
                typeof(void),
                new[] { typeof(object), typeof(Action<IntPtr>) },
                typeof(ReferenceHelpers).Module);

            var il = dyn.GetILGenerator();
            il.DeclareLocal(typeof(object), true);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Conv_I);
            il.Emit(OpCodes.Call, typeof(Action<IntPtr>).GetMethod("Invoke"));
            il.Emit(OpCodes.Ret);

            GetPinnedPtr = (Action<object, Action<IntPtr>>)dyn.CreateDelegate(typeof(Action<object, Action<IntPtr>>));
        }
    }

    class Car { public string Color; public Car(string c) { Color = c; } }
    struct MyStruct { public int X; public MyStruct(int x) { X = x; } }

    class Program
    {
        static void PrintAddr(object o, string name) =>
            ReferenceHelpers.GetPinnedPtr(o, ptr => Console.WriteLine($"{name}: 0x{ptr.ToString("X")}"));

        static void Main()
        {
            var a = new Car("blue");
            var b = a;
            var c = new Car("blue");

            Console.WriteLine("Reference type");
            PrintAddr(a, "a");
            PrintAddr(b, "b");
            PrintAddr(c, "c");

            Console.WriteLine("\nValue type");
            MyStruct s = new MyStruct(5);
            object box1 = s;
            object box2 = s;
            PrintAddr(box1, "box1");
            PrintAddr(box2, "box2");
        }
    }

}
