using Overby.Extensions.Attachments; //Nuget Package: Overby.Extensions.Attachments
using System;

namespace Memory_address_of_an_object_in_Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Guid guid1 = AttachmentExtensions.GetReferenceId(new Car("blue")); //Using Nuget Package: Overby.Extensions.Attachments
            Console.WriteLine("Memory address of object: " + guid1.ToString());
        }
        public class Car
        {
            public string Color;
            public Car(string color)
            {
                Color = color;
            }
        }

    }
    
}
