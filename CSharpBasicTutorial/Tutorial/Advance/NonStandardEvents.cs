using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class NonStandardEvents
    {
        // 비표준 형태의 event type 선언
        public delegate void NonStandardEventType(string message);
        // Class that publishes an event
        public class Publisher
        {
            // NonStandardEventType 의 event 변수 생성
            public event NonStandardEventType RaiseNonStandardEvent;
            public void FiredNonStandardEvent()
            {
                RaiseNonStandardEvent("비표준 이벤트 발생");
            }
        }
        //Class that subscribes to an event
        public class Subscriber
        {
            private readonly string _id;
            public Subscriber(string id, Publisher pub)
            {
                _id = id;
                // Subscribe to the event
                pub.RaiseNonStandardEvent += OnRaiseNonStandardEvent;
            }
            private void OnRaiseNonStandardEvent(string message)
            {
                message += $" at {DateTime.Now}";
                Console.WriteLine($"{_id} received this message: {message}");
            }
        }

        public class Test : ITest
        {
            public void Run()
            {
                var pub = new Publisher();
                var sub1 = new Subscriber("sub1", pub);
                //var sub2 = new Subscriber("sub2", pub);

                // 비표준 event 실행;
                pub.FiredNonStandardEvent();
            }
        }
    }
}
