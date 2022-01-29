using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class GenericDelegate2
    {
        public delegate void MyStackEventHandler<T, U>(T sender, U eventArgs);
        public class MyStack<T>
        {
            T[] items = { };
            int index;

            public class MyStackEventArgs : System.EventArgs
            {
                public T Item { get; init; }
            }
            public event MyStackEventHandler<MyStack<T>, MyStackEventArgs> mySatackEvent;
            protected virtual void OnStackChanged(MyStackEventArgs a)
            {
                mySatackEvent(this, a);
            }
            public virtual void Add(T item)
            {
                items.Append(item);
                OnStackChanged(new MyStackEventArgs() { Item=item});

            }

        }
        public class Test : ITest
        {
            
            public void Run()
            {
                MyStack<float> s = new MyStack<float>();
                s.mySatackEvent += S_mySatackEvent;
                s.Add(12.3f);
                s.Add(12.4f);
                s.Add(12.5f);
            }

            private void S_mySatackEvent(MyStack<float> sender, MyStack<float>.MyStackEventArgs eventArgs)
            {
                
                    Console.WriteLine(eventArgs.Item);
            }

        }
    }
}
