using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class ThreadForgroundBackGround
{
    public class Sample
    {
        public void Basic(bool isBackground = false)
        {
            Thread worker = new Thread(() => Console.ReadLine());
            worker.IsBackground = isBackground;
            worker.Start();
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            Sample sample = new Sample();
            sample.Basic();
        }
    }
}
