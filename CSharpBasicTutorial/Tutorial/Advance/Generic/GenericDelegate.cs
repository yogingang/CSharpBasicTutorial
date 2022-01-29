using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class GenericDelegate
    {
        public class MyStack<T>
        {
            T[] items;
            int index;

            public delegate void StackDelegate(T[] items);
        }
        public class Test : ITest
        {
            
            public void Run()
            {
                MyStack<float> s = new MyStack<float>();
                MyStack<float>.StackDelegate d = DoWork;

                d(new[]{12.3f, 12.4f,12.5f});
            }
            private void DoWork(float[] items)
            {
                foreach (var item in items)
                    Console.WriteLine(item);
            }
        }
    }
}
