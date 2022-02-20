using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class ThreadsLock
{
    public class Sample
    {
        #region basic lock
        private int i = 0;
        private static readonly object locker = new object();
        public void Basic()
        {
            Thread t = new Thread(Worker);          
            t.Start();
            Worker();
        }

        private void Worker()
        {
            lock (locker)
            {
                for (; i < 1000; i++) Console.Write($"{i} ");
            }
        }
        #endregion

        #region BackGroundForeGround
        public void BackGroundForeGround(bool isBackground = false)
        {
            Thread worker = new Thread(() => Console.ReadLine());
            worker.IsBackground = isBackground;
            worker.Start();
        }
        #endregion

        #region Barrier
        private Barrier _barrier = new Barrier(5, barrier => Console.WriteLine());
        public void Barrier()
        {
            for (int i = 0; i < 5; i++)
            {
                int j = i;
                new Thread(() => Count(j)).Start();
            }
        }
        /// <summary>
        /// barrier 은 생성된 모든 Thread 가 SignalAndWait() 한 부분까지 
        /// 처리 하기 전까지 다음 라인으로 진행되지 않는다.
        /// </summary>
        /// <param name="i"></param>
        private void Count(int i )
        {
            Console.WriteLine(i + ": get from Database ");
            _barrier.SignalAndWait();
            Console.WriteLine(i + ": send to WebServer ");
            _barrier.SignalAndWait();
            Console.WriteLine(i + ": delete from Database ");
            _barrier.SignalAndWait();   
        }
        #endregion

        #region SemaphoreSlim
        public void SemaphoreSlim()
        {
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(0, 3);

                for (int i = 0; i < 5; i++)
                {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        semaphoreSlim.Wait();
                        Thread.Sleep(100);
                        Console.WriteLine("{0} 실행 됨.", Thread.CurrentThread.Name);
                        semaphoreSlim.Release();
                    }));

                    thread.Name = String.Concat("Thread ", i + 1);
                    thread.Start();
                }

                Thread.Sleep(300);

                semaphoreSlim.Release(3);

                semaphoreSlim.AvailableWaitHandle.WaitOne();
                Console.WriteLine("ss.CurrentCount after ss.Wait() = {0}", semaphoreSlim.CurrentCount);

        }
    #endregion

}

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();
            //sample.Basic();
            //Console.WriteLine();
            //sample.BackGroundForeGround();
            //sample.Barrier();
            sample.SemaphoreSlim();
        }
    }

    //0 0 2 3 4 5 6 7 8 9 10 1
}
