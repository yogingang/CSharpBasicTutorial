using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class Records
    {
        // Record 선언 (간단한 방식)
        public record Person(string FirstName, string LastName);
        // Record 선언 다른 방식
        //public record Person
        //{
        //    public string FirstName { get; init; } = default!;
        //    public string LastName { get; init; } = default!;
        //};
        // 변경 가능 하게 선언
        //public record Person
        //{
        //    public string FirstName { get; set; } = default!;
        //    public string LastName { get; set; } = default!;
        //};

        // struct 도 record 로 만들 수 있다.
        // readonly 속성을 통해 변경 불가능 하다.
        //public readonly record struct Point(double X, double Y, double Z);
        // set 을 init 으로 선언하여 변경 불가능 하게 만들수도 있다.
        //public record struct Point
        //{
        //    public double X { get; init; }
        //    public double Y { get; init; }
        //    public double Z { get; init; }
        //}

        // 변경 가능한 record struct
        //public record struct Point(double X, double Y, double Z);
        //public record struct Point
        //{
        //    public double X { get; set; }
        //    public double Y { get; set; }
        //    public double Z { get; set; }
        //}

        // 변경 불가능 record class (readonly 가 없어도 기본적으로 불가능)
        //public record class Point(double X, double Y, double Z);

        // class 는 생략 가능
        //public record Point(double X, double Y, double Z);

        // 생성된 자동 구현 속성 정의가 원하는 내용이 아니면 동일한 이름의 속성을 직접 정의할 수 있다. 
        //public record Person(string FirstName, string LastName, string Id)
        //{
        //    internal string Id { get; init; } = Id;
        //}

        //public record class Address(string Street, string City);

        public record Person2(string FirstName, string LastName, string[] PhoneNumbers);
        //public record Person3(string FirstName, string LastName, 
        //                string[] PhoneNumbers, Address Address);
        public class Test : ITest
        {
            public void Run()
            {
                Person2 person = new("Nancy", "Davolio", new string[1] { "555-1234" });
                Console.WriteLine(person.PhoneNumbers[0]); // output: 555-1234

                //person.FirstName = "1234"; // 이것은 변경 불가 Compile error
                //person.LastName = "1234"; // 이것은 변경 불가 Compile error

                person.PhoneNumbers[0] = "555-6789"; // 이것은 변경 가능 (참조 형식 속성이 참조하는 데이터)
                Console.WriteLine(person.PhoneNumbers[0]); // output: 555-6789
               
            }

            public void Equal()
            {
                var phoneNumbers = new string[2];
                Person2 person1 = new("Nancy", "Davolio", phoneNumbers);
                Person2 person2 = new("Nancy", "Davolio", phoneNumbers);
                Console.WriteLine(person1 == person2); // output: True

                person1.PhoneNumbers[0] = "555-1234";
                Console.WriteLine(person1 == person2); // output: True

                Console.WriteLine(ReferenceEquals(person1, person2)); // output: False

            }

            public void NondestructiveWith()
            {
                Person2 person1 = new("Nancy", "Davolio", new string[1] );
                Console.WriteLine(person1);
                // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

                Person2 person2 = person1 with { FirstName = "John" };
                Console.WriteLine(person2);
                // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
                Console.WriteLine(person1 == person2); // output: False

                person2 = person1 with { PhoneNumbers = new string[1] };
                Console.WriteLine(person2);
                // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
                Console.WriteLine(person1 == person2); // output: False

                person2 = person1 with { };
                Console.WriteLine(person1 == person2); // output: True
            }

            public record Teacher(string FirstName, string LastName, int Grade)
            : Person(FirstName, LastName);
            public void Inheritance()
            {
                Person teacher = new Teacher("Nancy", "Davolio", 3);
                Console.WriteLine(teacher);
                // output: Teacher { FirstName = Nancy, LastName = Davolio, Grade = 3 }
            }

            public record Point(int X, int Y)
            {
                public int Zbase { get; set; }
            };
            public record NamedPoint(string Name, int X, int Y) : Point(X, Y)
            {
                public int Zderived { get; set; }
            };
            public void ChildRecordWith()
            {
                Point p1 = new NamedPoint("A", 1, 2) { Zbase = 3, Zderived = 4 };

                Point p2 = p1 with { X = 5, Y = 6, Zbase = 7 }; // Can't set Name or Zderived
                Console.WriteLine(p2 is NamedPoint);  // output: True
                Console.WriteLine(p2);
                // output: NamedPoint { X = 5, Y = 6, Zbase = 7, Name = A, Zderived = 4 }

                Point p3 = (NamedPoint)p1 with { Name = "B", X = 5, Y = 6, Zbase = 7, Zderived = 8 };
                Console.WriteLine(p3);
                // output: NamedPoint { X = 5, Y = 6, Zbase = 7, Name = B, Zderived = 8 }

            }

           
            public record Student(string FirstName, string LastName, int Grade)
                : Person(FirstName, LastName);
            public void ChildRecordDeconstruct()
            {
                Person teacher = new Teacher("Nancy", "Davolio", 3);
                var (firstName, lastName) = teacher; // Doesn't deconstruct Grade
                Console.WriteLine($"{firstName}, {lastName}");// output: Nancy, Davolio

                var (fName, lName, grade) = (Teacher)teacher;
                Console.WriteLine($"{fName}, {lName}, {grade}");// output: Nancy, Davolio, 3
            }
        }

    }
}
