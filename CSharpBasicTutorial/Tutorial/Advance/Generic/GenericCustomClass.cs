using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class GenericCustomClass
    {
        class BaseNode { }
        class BaseNodeGeneric<T> { }

        // concrete type
        class NodeConcrete<T> : BaseNode { }

        // 폐쇄형 (Base 의 Generic type 에 형식을 지정해서 상속한다.)
        class NodeClosed<T> : BaseNodeGeneric<int> { }

        // 개방형 (Base 의 Generic type 에 형식을 지정하지 않고 상속한다.)
        class NodeOpen<T> : BaseNodeGeneric<T> { }


        public class Employee
        {
            public string Name { get; set; } = string.Empty;
            public int ID { get; set; }
        }

        public class GenericList<T> where T : Employee, new()
        {
            public T GetInstance()
            {
                // new 제약조건으로 인해 T class 의 instance 생성 가능
                T t = new(); 
                // Employee 제약조건으로 인해 Employee 의 Name 으로 접근 가능
                Console.WriteLine(t.Name);
                return t;
            }
        }

        public class Test : ITest
        {
            public void Run()
            {
                
            }

        }
    }
}
