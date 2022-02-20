using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class PLinq
{
    public class Sample
    {
        
        public void Basic()
        {
            var source = Enumerable.Range(1, 10000);
            // Opt in to PLINQ with AsParallel.
            var evenNums = from num in source.AsParallel()
                           where num % 2 == 0
                           select num;
            Console.WriteLine("{0} even numbers out of {1} total",
                              evenNums.Count(), source.Count());
            // The example displays the following output:
            //       5000 even numbers out of 10000 total

        }

        //public void WithDegreeOfParallelism()
        //{
        //    var query = from item in source.AsParallel().WithDegreeOfParallelism(2)
        //                where Compute(item) > 42
        //                select item;
        //}

        public void WithDegreeOfParallelism()
        {
            var query = from site in new[]
            {
              "www.albahari.com",
              "www.linqpad.net",
              "www.oreilly.com",
              "stackoverflow.com",
            }
            .AsParallel().WithDegreeOfParallelism(4)
            let p = new Ping().Send(site)
            select new
            {
                site,
                Result = p.Status,
                Time = p.RoundtripTime
            };

            foreach(var item in query) Console.WriteLine($"{item.site}\n{item.Result}\n{item.Time}");
        }

        public void WithDegreeOfParallelism2()
        {
            var data = "The Quick Brown Fox"
              .AsParallel().WithDegreeOfParallelism(2)
              .Where(c => !char.IsWhiteSpace(c))
              .AsParallel().WithDegreeOfParallelism(3)   // Forces Merge + Partition
              .Select(c => char.ToUpper(c));

            foreach(var item in data) Console.WriteLine(item);
        }

        public void AsOrderedTest()
        {
            var numbers = Enumerable.Range(1, 100);
            var evenNums =
                    from num in numbers.AsParallel()
                    where num % 2 == 0
                    select num;

            foreach (var num in evenNums) Console.Write($"{num} ");

            //var orderedEvenNums =
            //        from num in numbers.AsParallel().AsOrdered()
            //        where num % 2 == 0
            //        select num;

            //foreach (var num in orderedEvenNums) Console.Write($"{num}");

            Console.WriteLine("{0} even numbers out of {1} total",
                             evenNums.Count(), numbers.Count());
        }

        public void ForAllTest()
        {
           
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();
           
            //sample.Basic();
            //sample.AsOrderedTest();
            //sample.WithDegreeOfParallelism();
            sample.WithDegreeOfParallelism2();

        }
    }
}
