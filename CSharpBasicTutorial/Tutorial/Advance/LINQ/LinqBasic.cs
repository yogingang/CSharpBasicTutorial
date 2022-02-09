using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;
public class LinqBasic
{

    public class Test : ITest
    {
        public void Run()
        {
            // The Three Parts of a LINQ Query:
            // 1. 데이터 소스 가져오기.
            int[] numbers = new int[7] { 3, 0, 4, 5, 1, 6, 2 };

            // 2. 쿼리 만들기.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // 3. 쿼리 실행.
            foreach (int num in numQuery)
            {
                Console.Write($"{num} ");
            }

            // 4. 즉시 실행
            var evenNumQuery = from num in numbers
                               where (num % 2) == 0
                               select num;

            // 집계함수 
            int evenNumCount = evenNumQuery.Count();
            Console.WriteLine("\n\n집계함수 Count()");
            Console.Write(evenNumCount);

            // 강제적용
            List<int> numQuery2 = (from num in numbers
                                   where (num % 2) == 0
                                   select num).ToList();

            Console.WriteLine("\n\n강제적용 ToList()");
            numQuery2.ForEach(n=>Console.Write($"{n} "));

            // or like this:
            // numQuery3 is still an int[]

            var numQuery3 = (from num in numbers
                             where (num % 2) == 0
                             select num).ToArray();

            Console.WriteLine("\n\n강제적용 ToArray()");
            foreach (var n in numQuery3) Console.Write($"{n} ");

            Console.WriteLine();

            //Query syntax:
            IEnumerable<int> querySyntax =
                from num in numbers
                where num % 2 == 0
                orderby num
                select num;

            //Method syntax:
            IEnumerable<int> methodSyntax = numbers.Where(num => num % 2 == 0).OrderBy(n => n);

            foreach (int i in querySyntax)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            foreach (int i in methodSyntax)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


        }
    }
}

