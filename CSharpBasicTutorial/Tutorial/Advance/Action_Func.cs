using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpTutorial.Tutorial.Advance.Delegates;

namespace CSharpTutorial.Tutorial.Advance
{
    public class Action_Func
    {
        // Delegate type 선언
        //public delegate Shape CreateShapeDelegate();
        //public delegate void AddCircleDelegate(Circle e);
        //public delegate void AddRectangleDelegate(Rectangle e);
        //public delegate void AddTriangleDelegate(Triangle e);

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
            //// call back 용
            //public AddCircleDelegate? AddCircleDelegateHandler;
            //public AddRectangleDelegate? AddRectangleDelegateHandler;
            //public AddTriangleDelegate? AddTriangleDelegateHandler;

            //// multi method call
            //public CreateShapeDelegate? MultiAction;

            //Func 와 Action 을 사용하여 수정
            public Func<Shape> MultiAction;
            public Action<Circle> AddCircleDelegateHandler;
            public Action<Rectangle> AddRectangleDelegateHandler;
            public Action<Triangle> AddTriangleDelegateHandler;

            public Shape MakeShape() => new Shape();
            public Circle MakeCircle() => new Circle();
            public Rectangle MakeRectangle() => new Rectangle();
            public Triangle MakeTriangle() => new Triangle();

            public void Test()
            {
                // 공변성 Test
                MultiAction = MakeShape;
                MultiAction += MakeCircle;
                MultiAction += MakeRectangle;
                MultiAction += MakeTriangle;
                MultiAction -= MakeCircle;

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
                //creator.AddCircleDelegateHandler += OnAddCircle;
                //creator.AddRectangleDelegateHandler += OnAddRectangle;
                //creator.AddTriangleDelegateHandler += OnAddTriangle;

                creator.Test();   

                // 반공변성 Test (모두 OnAddShape 에서 처리)
                creator.AddCircleDelegateHandler += OnAddMultiHandler;
                creator.AddRectangleDelegateHandler += OnAddMultiHandler;
                creator.AddTriangleDelegateHandler += OnAddMultiHandler;
            }
            public void OnAddCircle(Circle circle)
            {
                Console.WriteLine($"adding {circle.GetType().Name} in List<Shape>");
                _shapes.Add(circle);
                Console.WriteLine($"added {circle.GetType().Name} in List<Shape>");
            }
            public void OnAddRectangle(Rectangle rectangle)
            {
                Console.WriteLine($"adding {rectangle.GetType().Name} in List<Shape>");
                _shapes.Add(rectangle);
                Console.WriteLine($"added {rectangle.GetType().Name} in List<Shape>");
            }
            public void OnAddTriangle(Triangle triangle)
            {
                Console.WriteLine($"adding {triangle.GetType().Name} in List<Shape>");
                _shapes.Add(triangle);
                Console.WriteLine($"added {triangle.GetType().Name} in List<Shape>");
            }

            public void OnAddMultiHandler(Shape shape)
            {
                Console.WriteLine($"adding {shape.GetType().Name} in List<Shape>");
                _shapes.Add(shape);
                Console.WriteLine($"added {shape.GetType().Name} in List<Shape>");
            }

        }
    }
}
