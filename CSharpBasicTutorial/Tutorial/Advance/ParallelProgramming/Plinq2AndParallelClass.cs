using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Plinq2AndParallelClass
{
    public class Sample
    {
        
        public void Basic()
        {
            var numbers = Enumerable.Range(1, 10000000).ToArray();
            Stopwatch stopwatch = Stopwatch.StartNew();
            var parallelQuery = Partitioner.Create(numbers, true).AsParallel();
            var sum = parallelQuery.Sum(i => Math.Sqrt(i));
            stopwatch.Stop();
            Console.WriteLine("Chunk elapsed = " + stopwatch.Elapsed.Ticks);

            stopwatch.Restart();
            var sum2 = ParallelEnumerable.Range(1, 10000000).Sum(i => Math.Sqrt(i));
            stopwatch.Stop();
            Console.WriteLine("Range elapsed = " + stopwatch.Elapsed.Ticks);

            //output
            /*
             * Chunk elapsed = 1183971
             * Range elapsed = 270483
             */
        }

        public void ParallelInvoke()
        {
            Parallel.Invoke(
                 async () => {
                     var data = await new HttpClient().GetStringAsync("http://www.gutenberg.org/cache/epub/16452/pg16452.txt");
                     Console.WriteLine("Downloaded pg16452.txt");
                     },
                 async () =>
                 {
                     var data = await new HttpClient().GetStringAsync("http://www.gutenberg.org/files/54700/54700-0.txt");
                     Console.WriteLine("Downloaded 54700-0.txt");
                 }
                 );

            Console.ReadLine();

        }
        public void ParallelFor()
        {
            Parallel.For(0, 100, i => Console.Write($"{i} "));

        }
        public void ParallelForeach()
        {
            var numbers = Enumerable.Range(1, 100);
            Parallel.ForEach(numbers, i => Console.Write($"{i} "));

        }

    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();

            //sample.Basic();
            //sample.ParallelInvoke();
            //sample.ParallelFor();
            sample.ParallelForeach();


        }
    }
}
