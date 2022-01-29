using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class GenericCustomClassExample
    {
        public class Shape
        {
            protected virtual string GetClassName() => GetType().Name;
            public virtual void PrintDraw() => Console.WriteLine($"Drawing a {GetClassName()}");
        }
        public class Circle : Shape { }
        public class Rectangle : Shape { }
        public class Triangle : Shape { }

        public class ShapeLoggingCreator<T> where T : Shape, new()
        {
            public ShapeLoggingCreator()
            {
                Console.WriteLine($"ShapeLoggingCreator create instance about {typeof(T).Name}");
                Insance = new T();
            }
            public T Insance { get; set; }

            public T GetInstance()
            {
                return Insance;
            }

        }

        public class Test : ITest
        {
            public void Run()
            {
                ShapeLoggingCreator<Circle> creator = new ShapeLoggingCreator<Circle>();
                creator.GetInstance().PrintDraw();

                //ShapeLoggingCreator<Rectangle> creator = new ShapeLoggingCreator<Rectangle>();
                //creator.GetInstance().PrintDraw();

                //ShapeLoggingCreator<Triangle> creator = new ShapeLoggingCreator<Triangle>();
                //creator.GetInstance().PrintDraw();
            }

            private void Print(List<Shape> list)
            {
                foreach (var item in list) item.PrintDraw();
            }
        }
    }
}
