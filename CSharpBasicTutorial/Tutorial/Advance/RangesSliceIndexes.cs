using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class RangesSliceIndexes
{
    public class Sample
    {
        private string[] _words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0

        public void Index()
        {
        
            Console.WriteLine($"The last word is {_words[^1]}");

            System.Index index = ^1;
            Console.WriteLine($"(with index variable) The last word is {_words[index]}");
        }

        public void RangeBasic()
        {
            string[] quickBrownFox = _words[1..4];
            foreach(var word in quickBrownFox)
                Console.WriteLine($"< {word} >");

        }

        public void RangeEtc()
        {
            string[] allWords = _words[..]; // contains "The" through "dog".
            string[] firstPhrase = _words[..4]; // contains "The" through "fox"
            string[] lastPhrase = _words[6..]; // contains "the, "lazy" and "dog"
            Console.WriteLine("_words[..]");
            foreach (var word in allWords)
                Console.Write($"< {word} >");
            Console.WriteLine();
            Console.WriteLine("_words[..4]");
            foreach (var word in firstPhrase)
                Console.Write($"< {word} >");
            Console.WriteLine();
            Console.WriteLine("_words[6..]");
            foreach (var word in lastPhrase)
                Console.Write($"< {word} >");
            Console.WriteLine();
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();
            //sample.Index();
            //sample.RangeBasic();
            sample.RangeEtc();
        }
        
    }
}
