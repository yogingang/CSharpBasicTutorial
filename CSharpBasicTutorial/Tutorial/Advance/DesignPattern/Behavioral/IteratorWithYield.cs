using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class IteratorWithYield
{

    public class Weeks 
    {
        private string[] weeks = new string[]{
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
            };

        public IEnumerable GetWeeksIterator()
        {
            foreach (var item in weeks)
            {
                yield return item;
            }
        }

        public IEnumerable GetWeekDaysIterator()
        {
            for (int i = 0; i < (weeks.Length - 2); i++)
            {
                yield return weeks[i];
            }
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var weeks = new Weeks();
            foreach (var item in weeks.GetWeeksIterator())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (var item in weeks.GetWeekDaysIterator())
            {
                Console.WriteLine(item);
            }

        }
    }

  

}


