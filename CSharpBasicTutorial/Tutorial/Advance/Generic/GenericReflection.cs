using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class GenericReflection
    {
        public class MyStack<T>
        {
            T[] items = { };
            int index;

            public virtual U GenericMethod<U>(T item) where U:T
            {
                return (U)item;
            }
            public float Method(float item)
            {
                return item;
            }
            public T GetItem(int index) => items[index];
            public void AddItem(T item)=> items = items.Append(item).ToArray(); 
        }
        public class MyStack
        {
            object[] items;
            int index;
        }

        // 폐쇄형 class
        public class IntMyStack<T> : MyStack<int>
        {
            public override U GenericMethod<U>(int item)
            {
                return base.GenericMethod<U>(item);
            }
            public virtual T TParamterMethod(T item)
            {
                return item;
            }
        }

        public class Test : ITest
        {
            public void Run()
            {
                MyStack<float> genericStack = new MyStack<float>();
                MyStack stack = new MyStack();
                IntMyStack<float> intMyStack = new IntMyStack<float>();

                Console.WriteLine($"genericStack is generic type == {genericStack.GetType().IsGenericType}");
                Console.WriteLine($"stack is generic type == {stack.GetType().IsGenericType}");


                
                //foreach (var method in typeof(MyStack<>).GetMethods())
                foreach (var method in genericStack.GetType().GetMethods())
                {
                    var isOpenGeneric = method.IsGenericMethod == true ? method.ContainsGenericParameters : false;
                    Console.WriteLine($"{method.Name} is generic method == {method.IsGenericMethod}, is open generic method == {isOpenGeneric}");
                }

                Console.WriteLine($"typeof(IntMyStack<>) is opened generic type == {typeof(IntMyStack<>).ContainsGenericParameters}");
                Console.WriteLine($"intMyStack is opened generic type == {intMyStack.GetType().ContainsGenericParameters}");

                // 이것은 IntMyStack<> 이라는 type 에대한 비교 이므로 완전 폐쇄형이 아니다.
                // 그러므로 아래 intMyStack 이라는 instance 와 method 에 대한 ContainsGenericParameters 값이 다르다.
                //foreach (var method in typeof(IntMyStack<>).GetMethods())
                foreach (var method in intMyStack.GetType().GetMethods())
                    Console.WriteLine($"{method.Name} is opened generic method == {method.ContainsGenericParameters}");

                var myStackType = typeof(MyStack<>);
                var type_MyStack_Float = myStackType.MakeGenericType(typeof(float));
                var instance = Activator.CreateInstance(type_MyStack_Float);
                (instance as MyStack<float>).AddItem(12.3f);
                Console.WriteLine((instance as MyStack<float>).GetItem(0));
            }
        }
    }
}
