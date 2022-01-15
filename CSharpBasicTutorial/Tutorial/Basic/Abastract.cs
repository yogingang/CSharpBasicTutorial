using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Basic;

public class Abastract
{
    public abstract class AbstractShape
    {
        abstract public void Draw();
        abstract protected void PrintDraw();
    }
    public class Shape: AbstractShape
    {
        public override void Draw()
        {
            PrintDraw();
            Console.WriteLine($"Performing base class drawing tasks, {GetClassName()}");
        }

        protected virtual string GetClassName()
        {
            return GetType().Name;
        }

        protected override void PrintDraw()
        {
            Console.WriteLine($"Drawing a {GetClassName()}");
        }
    }
    public class Circle : Shape{}
    public class Rectangle : Shape{}
    public class Triangle : Shape{}
}



