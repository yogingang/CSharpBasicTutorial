using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Proxy
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
            Console.WriteLine($"Name : {_name} , Age : {_age}");
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

    public class HeavyObjectProxy
    {
        private readonly HeavyObject _heavyObject;
        public HeavyObjectProxy(HeavyObject heavyObject)
        {
            _heavyObject = heavyObject;
        }

        public void Execution()
        {
            Console.WriteLine("Russia is a loss!!");
            _heavyObject.Execution();
            Console.WriteLine("Росія - це втрата!!");
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var factory = new HeavyObjectFactory();

            var heavyObjectsProxy = new List<HeavyObjectProxy>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            heavyObjectsProxy.Add(new HeavyObjectProxy(factory.Get("Putin", 69)));
            heavyObjectsProxy.Add(new HeavyObjectProxy(factory.Get("Biden", 79)));
            heavyObjectsProxy.Add(new HeavyObjectProxy(factory.Get("Zelensky", 44)));
            stopwatch.Stop();
            Console.WriteLine($"첫번째 초기화시 걸린 시간 {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            heavyObjectsProxy.Add(new HeavyObjectProxy(factory.Get("Biden", 79)));
            heavyObjectsProxy.Add(new HeavyObjectProxy(factory.Get("Putin", 69)));
            heavyObjectsProxy.Add(new HeavyObjectProxy(factory.Get("Zelensky", 44)));
            stopwatch.Stop();
            Console.WriteLine($"두번째 초기화시 걸린 시간 {stopwatch.ElapsedMilliseconds}ms");

            foreach (var heavyObject in heavyObjectsProxy)
                heavyObject.Execution();

        }
    }
}


