using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpTutorial.Tutorial.Advance.Delegates;

namespace CSharpTutorial.Tutorial.Advance
{
    public class LambdaExpressions
    {
        
        public class Shape
        {
            public Shape()
            {
                PrintDraw();
            }
            protected virtual string GetClassName()
            {
                return GetType().Name;
            }

            protected virtual void PrintDraw()
            {
                Console.WriteLine($"Drawing a {GetClassName()}");
            }
        }
        public class Circle : Shape { }
        public class Rectangle : Shape { }
        public class Triangle : Shape { }

        public class Creator
        {
           
            //Func 와 Action 을 사용하여 수정
            public Func<Shape> MultiAction;
            public Action<Circle> AddCircleDelegateHandler;
            public Action<Rectangle> AddRectangleDelegateHandler;
            public Action<Triangle> AddTriangleDelegateHandler;

            public void Test()
            {
                // 공변성 Test
                // lambda 식을 이용하여 적용
                MultiAction = () => new Shape(); 
                MultiAction += () => new Circle();
                MultiAction += () => new Rectangle();
                MultiAction += () => new Triangle();
                MultiAction -= () => new Circle();
                // lambda 식을 사용할 경우 -= 를 통한 remove 동작은
                // 이전 lambda 식을 가르킬수 있는 방법이 없으므로 동작하지 않는다.
                // event 등록 및 삭제 시에 많이 하는 실수 이므로 주의하자
                // 이로인해 memory leak 이 발생하는 경우가 많다.

                Console.WriteLine("MultiAction test");
                MultiAction();

                Console.WriteLine();
                Console.WriteLine("Message fire test");
                AddCircleDelegateHandler?.Invoke(new Circle());
                AddRectangleDelegateHandler?.Invoke(new Rectangle());
                AddTriangleDelegateHandler?.Invoke(new Triangle());
            }

        }

        public class Test : ITest
        {
            List<Shape> _shapes = new List<Shape>();
            Creator creator = new Creator();

            public void Run()
            {

                // lambda 식으로 처리
                // 아래와 같은 경우는 lambda 식이 중복 되므로 
                // 다음과 같이 처리 하자
                Action<Shape> multiAction = shape =>
                {
                    Console.WriteLine($"adding {shape.GetType().Name} in List<Shape>");
                    _shapes.Add(shape);
                    Console.WriteLine($"added {shape.GetType().Name} in List<Shape>");
                };

                creator.AddCircleDelegateHandler += multiAction;
                creator.AddRectangleDelegateHandler += multiAction;
                creator.AddTriangleDelegateHandler += multiAction;
                creator.Test();
            }
        }
    }
}
