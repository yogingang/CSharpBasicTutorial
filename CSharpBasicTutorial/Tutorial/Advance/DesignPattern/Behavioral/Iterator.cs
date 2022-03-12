using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Iterator
{

    public interface IWeeksIterator //Iterator interface
    {
        string Current { get; }

        bool MoveNext();
    }
    public class WeeksIterator : IWeeksIterator //Iterator object
    {
        private readonly string[] weeks;
        private int position;

        public WeeksIterator(string[] weeks)
        {
            this.weeks = weeks;
            this.position = -1;
        }

        public string Current => weeks[position];

        public bool MoveNext()
        {
            if (++position == weeks.Length) return false;
            return true;
        }
    }

    // 평일용 iterator
    public class WeekDaysIterator : IWeeksIterator
    {
        private readonly string[] weeks;
        private int position;

        public WeekDaysIterator(string[] weeks)
        {
            this.weeks = weeks;
            this.position = -1;
        }

        public string Current => weeks[position];

        public bool MoveNext()
        {
            if (++position == (weeks.Length - 2)) return false;
            return true;
        }
    }


    public class Weeks //Aggregate object
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

        public IWeeksIterator GetWeeksIterator()
        {
            //creates an Iterator object
            //return new WeeksIterator(weeks);
            return new WeekDaysIterator(weeks);
        }

        //이게 더 쉬워 보일 수 있다.
        public string[] Days => weeks;
    }

    public class Test : ITest
    {
        public void Run()
        {
            var weeks = new Weeks();
            var iterator = weeks.GetWeeksIterator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }

            Console.WriteLine();
            // 아래와 같이 하는게 더 편하다고 생각 할 수 있다.
            var days = new Weeks().Days;
            for (int i = 0; i < days.Length; i++)
            {
                Console.WriteLine(days[i]);
            }
        }
    }

  

}


