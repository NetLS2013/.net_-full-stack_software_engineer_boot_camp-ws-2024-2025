using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTests
{
    public abstract class GenericTestClassBase<T>
    {
        public T? Params { get; set; }
        public abstract bool Equals(T param);
    }
    public class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public bool? IsMan { get; set; }

        public People(string name, int age, string email, bool? isMan)
        {
            Name = name;
            Age = age;
            Email = email;
            IsMan = isMan;
        }
    }
    public class PeopleTest : GenericTestClassBase<People>
    {
        public override bool Equals(People param)
        {
            if (Params == null || param == null)
                return false;
            if (Params.IsMan.HasValue && param.IsMan.HasValue)
            {
                if (Params.IsMan.Value != param.IsMan.Value)
                    return false;
            }

            return Params.Name == param.Name &&
                   Params.Age == param.Age &&
                   Params.Email == param.Email &&
                   Params.IsMan == param.IsMan;
        }
    }
}
