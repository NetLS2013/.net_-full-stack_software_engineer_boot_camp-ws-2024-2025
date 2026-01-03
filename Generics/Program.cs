namespace Generics
{
    public abstract class GenericTestClassBase<T>
    {
        public T Params { get; set; }

        public abstract bool Equals(T param);
    }

    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public bool isWeath { get; set; }
        
    }

    public class PersonTest : GenericTestClassBase<Person>
    {   public override bool Equals(Person param)
        {
            return Params.name == param.name &&
               Params.age == param.age &&
               Params.isWeath == param.isWeath;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PersonTest personTest = new PersonTest();
            personTest.Params = new Person { name = "John", age = 30, isWeath = true };

            Person personToCompare = new Person { name = "John", age = 30, isWeath = true };
            bool areEqual = personTest.Equals(personToCompare);
            Console.WriteLine($"Are the two persons equal? {areEqual}");

            Person anotherPersonToCompare = new Person { name = "Jane", age = 25, isWeath = false };
            bool areAnotherEqual = personTest.Equals(anotherPersonToCompare);
            Console.WriteLine($"Are the two persons equal? {areAnotherEqual}");
        }
    }
}
