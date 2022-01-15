using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class DelegatesVsEvents
    {
        // 비표준 형태의 event type 선언
        public delegate void NonStandardEventType(string message);
        // Class that publishes an event
        public class Publisher
        {
            // NonStandardEventType 의 event 수정자를 통해 delegate 변수 생성
            public event NonStandardEventType RaiseEvent;

            // NonStandardEventType 의 delegate 변수 생성
            public NonStandardEventType RaiseDelegate;
            public void FiredRaiseEvent()
            {
                RaiseEvent("이벤트 발생");
            }
            public void FiredRaiseDelegate()
            {
                RaiseEvent("delegate 발생");
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
                pub.RaiseEvent += OnRaiseEvent;
                // Subscribe to the delegate
                pub.RaiseDelegate += OnRaiseDelegate;

                // 기본적으로 위 두가지는 같다. 
                // 하지만

                //pub.RaiseEvent("내가 훔쳤다 ㅋㅋㅋㅋ"); // 컴파일 되지 않는다.
                pub.RaiseDelegate("내가 훔쳤다 ㅋㅋㅋㅋ"); // 가능하다. 
            }
            private void OnRaiseEvent(string message)
            {
                message += $" at {DateTime.Now}";
                Console.WriteLine($"OnRaiseEvent {_id} received this message: {message}");
            }

            private void OnRaiseDelegate(string message)
            {
                message += $" at {DateTime.Now}";
                Console.WriteLine($"OnRaiseDelegate {_id} received this message: {message}");
            }
        }

        public class Test : ITest
        {
            public void Run()
            {
                var pub = new Publisher();
                var sub1 = new Subscriber("sub1", pub);
                //var sub2 = new Subscriber("sub2", pub);


                // event 발생;
                pub.FiredRaiseEvent();
                // delegate 발생;
                pub.FiredRaiseEvent();
            }
        }
    }
}
