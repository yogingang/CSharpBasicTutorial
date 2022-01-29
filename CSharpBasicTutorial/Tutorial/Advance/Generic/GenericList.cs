using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    /// <summary>
    /// List<T>  형태에 대한 Test
    /// </summary>
    public class GenericList
    {
        public class Shape
        {
            protected virtual string GetClassName() => GetType().Name;
            public virtual void PrintDraw() =>Console.WriteLine($"Drawing a {GetClassName()}");           
        }
        public class Circle : Shape { }
        public class Rectangle : Shape { }
        public class Triangle : Shape { }
      
        public class Test : ITest
        {
            public void Run()
            {
                List<Shape> list = new List<Shape>();
                // List 에  하나씩 입력
                list.Add(new Shape());
                // 상속한 클래스도 입력 가능 
                list.Add(new Circle());

                // 초기화 선언
                List<Shape> subList = new List<Shape>()
                {
                    new Rectangle(),
                    new Triangle(),
                };

                // addRange
                list.AddRange(subList);

                // print
                Print(list);

                // 삭제
                list.Remove(list[0]);

                Console.WriteLine($"\nlist[0] 삭제뒤에 list 내용\n");
                // print
                Print(list);

                // 찾기
                Console.WriteLine("\ncircle 을 찾습니다.\n");
                var item = list.Find(shape => shape is Circle);
                if(item != null)
                    Console.WriteLine("circle 을 찾았습니다.");
                item?.PrintDraw();
            }

            private void Print(List<Shape> list)
            {
                foreach (var item in list) item.PrintDraw();
            }
        }
    }
}

//// select 를 통한 console.writeline
//_shapes.Select(s => 
//    {
//        Console.WriteLine(s);
//        return s;
//    }
//) ;

//private void Print<T>(IList<T> list) where T : Shape
//{
//    foreach(var item in list) item.PrintDraw();
//}