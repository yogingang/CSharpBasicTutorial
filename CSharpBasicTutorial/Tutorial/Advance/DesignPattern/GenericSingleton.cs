using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class GenericSingleton
{
    public class Singleton<T>
        where T : class, new()
    {
        private Singleton() { }
        private static readonly Lazy<T> _lazy = new Lazy<T>(() => new T());
        private static object _lock = new object();
        public static T Instance { get { lock (_lock) { return _lazy.Value; } } }
    }

    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; init; }
    }
    public class Test : ITest
    {
        public void Run()
        {

            var person1 = Singleton<Person>.Instance;
            var person2 = Singleton<Person>.Instance;

            person1.Id.ToString().Print();
            person2.Id.ToString().Print();


        }
    }
}
