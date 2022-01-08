// See https://aka.ms/new-console-template for more information 
using CSharpBasicTutorial.Tutorial;

var shapes = new List<Abastract.AbstractShape>
{
    new Abastract.Rectangle(),
    new Abastract.Triangle(),
    new Abastract.Circle()
};

foreach (var shape in shapes)
{
    shape.Draw();
}

/* Output:
    Drawing a rectangle
    Performing base class drawing tasks
    Drawing a triangle
    Performing base class drawing tasks
    Drawing a circle
    Performing base class drawing tasks
*/