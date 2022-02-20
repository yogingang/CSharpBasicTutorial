using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class TPL
{
    public class Sample
    {
        public void Basic()
        {
            Thread.CurrentThread.Name = "new Task";
            Task taskA = new Task(() => Console.WriteLine("Hello from taskA."));
            taskA.Start();
            Console.WriteLine("Hello from thread '{0}'.",Thread.CurrentThread.Name);
            taskA.Wait();
            // output
            // Hello from thread 'new Task'.
            // Hello from taskA
        }

        public void Run()
        {

            Thread.CurrentThread.Name = "Task.Run";
            Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA."));
            Console.WriteLine("Hello from thread '{0}'.",Thread.CurrentThread.Name);
            taskA.Wait();
            // output
            // Hello from thread 'Task.Run'.
            // Hello from taskA
        }

        public void StartNew()
        {
            Thread.CurrentThread.Name = "Task.Factory.StartNew";

            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("Hello from taskA."));
            Console.WriteLine("Hello from thread '{0}'.",Thread.CurrentThread.Name);
            taskA.Wait();
            // output
            // Hello from thread 'Task.Factory.StartNew'.
            // Hello from taskA.
        }

        public void TaskReturn()
        {
            Thread.CurrentThread.Name = "TaskReturn";
            var taskA = Task.Factory.StartNew(() => HelloWorld());
            Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.Name);
            Console.WriteLine(taskA.Result);
            // output
            // Hello from thread 'TaskReturn'.
            // Hello World!
        }
        private string HelloWorld() => "Hello World!";

        class CustomData
        {
            public long CreationTime;
            public int Name;
            public int ThreadNum;
        }

        public void TaskCaptureScopeMistake()
        {
            Thread.CurrentThread.Name = "TaskCaptureScopeMistake";
            Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.Name);
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                            {
                                Console.WriteLine($"i = [{i}]");
                            }));
            }
            Task.WaitAll(tasks.ToArray());
            // output
            /*
                Hello from thread 'TaskCaptureScopeMistake'.
                i = [3]
                i = [3]
                i = [5]
                i = [9]
                i = [9]
                i = [9]
                i = [9]
                i = [10]
                i = [10]
                i = [10]
             */
        }

        public void TaskCaptureScopeSolution()
        {
            Thread.CurrentThread.Name = "TaskCaptureScopeSolution";
            Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.Name);
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                int j = i;
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"i = [{j}]");
                }));
            }
            Task.WaitAll(tasks.ToArray());
            // output
            /*
                Hello from thread 'TaskCaptureScopeSolution'.
                i = [0]
                i = [2]
                i = [1]
                i = [6]
                i = [5]
                i = [4]
                i = [3]
                i = [7]
                i = [9]
                i = [8]
             */
        }

        public void TaskContinuation()
        {
            Task task1 = Task.Factory.StartNew(() => Console.Write("Hello.."));
            Task task2 = task1.ContinueWith(task => Console.Write("..world!"));

        }

        public void TaskException()
        {
            Task task1 = Task.Factory.StartNew(() => throw new Exception("error fired"));
            Task task2 = task1.ContinueWith(task => Console.Write("error capture" + task.Exception));

            task2.Wait();
        }

        public void TaskFaultProcess()
        {
            //Task t1 = Task.Factory.StartNew(()=>"hello");
            Task t1 = Task.Factory.StartNew(()=>throw new Exception("error fired"));

            Task fault = t1.ContinueWith(ant => Console.WriteLine("fault"),
                                          TaskContinuationOptions.OnlyOnFaulted);

            Task t3 = fault.ContinueWith(ant => Console.WriteLine("t3"));

            t3.Wait();
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();
            //sample.Basic();
            //sample.Run();
            //sample.StartNew();
            //sample.TaskReturn();
            //sample.TaskCaptureScopeMistake();
            //sample.TaskCaptureScopeSolution();
            //sample.TaskContinuation();
            //sample.TaskException();
            sample.TaskFaultProcess();


        }
    }
}
