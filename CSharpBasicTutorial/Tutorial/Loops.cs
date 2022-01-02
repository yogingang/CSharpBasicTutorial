using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicTutorial.Tutorial
{
    public class LoopsTest : ITest
    {
        public void Run()
        {

            int i = 0;
            Console.WriteLine("#####while#####");
            while (i < 5)
            {
                Console.WriteLine(i);
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("#####do while#####");
            i = 0;
            do
            {
                Console.WriteLine(i);
                i++;
            }
            while (i < 5);

            Console.WriteLine();
            Console.WriteLine("#####for#####");
            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine(j);
            }

            Console.WriteLine();
            Console.WriteLine("#####foreach#####");
            int[] iList = { 0, 1, 2, 3, 4 };
            foreach (int item in iList)
            {
                Console.WriteLine(item);
            }


            int index = 0;
            while (index < 5)
            {
                Console.WriteLine(index);
                i++;
                if (i == 3)
                    break;
            }

            index = 0;
            while (index < 5)
            {
                if (i == 3)
                    continue;

                Console.WriteLine(index);
                i++;
            }


            for (int j = 0; j < 5; j++)
            {
                if (j == 3)
                    break;
                Console.WriteLine(j);
            }

            for (int j = 0; j < 5; j++)
            {
                if (j == 3)
                    continue;
                Console.WriteLine(j);
            }
        }
    }
}
