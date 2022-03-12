using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Flyweight
{
    public class HeavyObject
    {
        private readonly string _name;
        private readonly int _age;

        public HeavyObject(string name, int age)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            _name = name;
            _age = age;
        }
        public void Execution()
        {
            Console.WriteLine($"Name : {_name} , Age : {_age}, !! Stay strong Ukraine! You will definitely win! !! Будь сильною Україно! Ви точно переможете! !!");
        }

    }

    public class HeavyObjectFactory
    {
        private Dictionary<string, HeavyObject> _pool = new Dictionary<string, HeavyObject>();
        public HeavyObject Get(string name, int age)
        {
            string key = $"{name}{age}";
            if (!_pool.ContainsKey(key))
            {
                var obj = new HeavyObject(name,age);
                _pool.Add(key, obj);
                return obj;
            }
            return _pool[key];
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var factory = new HeavyObjectFactory();

            var heavyObjects = new List<HeavyObject>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            heavyObjects.Add(factory.Get("Putin", 69));
            heavyObjects.Add(factory.Get("Biden", 79));
            heavyObjects.Add(factory.Get("Zelensky", 44));
            stopwatch.Stop();
            Console.WriteLine($"첫번째 초기화시 걸린 시간 {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            heavyObjects.Add(factory.Get("Biden", 79));
            heavyObjects.Add(factory.Get("Putin", 69));
            heavyObjects.Add(factory.Get("Zelensky", 44));
            stopwatch.Stop();
            Console.WriteLine($"두번째 초기화시 걸린 시간 {stopwatch.ElapsedMilliseconds}ms");

            foreach (var heavyObject in heavyObjects)
                heavyObject.Execution();

        }
    }
}


