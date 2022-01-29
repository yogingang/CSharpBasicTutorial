using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class GenericMethod
    {
        public class MyClass
        {
            public void Swap<T>(ref T lhs, ref T rhs)
            {
                T temp;
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        }

        public class Test : ITest
        {

            public void Run()
            {
                MyClass @class = new MyClass();
                int a = 1;
                int b = 2;

                @class.Swap<int>(ref a, ref b);
                System.Console.WriteLine(a + " " + b);
            }

        }
    }
}
