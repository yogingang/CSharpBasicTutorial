using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Threads
{
    public class Sample
    {
        public void Basic()
        {
            Thread t = new Thread(Write);          
            t.Start();                              

            
            for (int i = 0; i < 1000; i++) Console.Write("1");
        }

        private void Write()
        {
            for (int i = 0; i < 1000; i++) Console.Write("2");
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();
            sample.Basic();
        }
    }
}
