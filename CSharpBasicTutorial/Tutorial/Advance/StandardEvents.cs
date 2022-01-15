using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class StandardEvents
    {
        public class CustomEventArgs : EventArgs
        {
            public CustomEventArgs(string message)
            {
                Message = message;
            }
            public string Message { get; set; }
        }

        // Class that publishes an event
        public class Publisher
        {
            // Declare the event using EventHandler<T>
            public event EventHandler<CustomEventArgs> RaiseStandardEvent;
            public void FiredStandardEvent()
            {
                // Write some code that does something useful here
                // then raise the event. You can also raise an event
                // before you execute a block of code.
                OnRaiseCustomEvent(new CustomEventArgs("표준 이벤트 발생"));
            }

            // Wrap event invocations inside a protected virtual method
            // to allow derived classes to override the event invocation behavior
            protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
            {
                // Make a temporary copy of the event to avoid possibility of
                // a race condition if the last subscriber unsubscribes
                // immediately after the null check and before the event is raised.
                EventHandler<CustomEventArgs> raiseEvent = RaiseStandardEvent;
                // Event will be null if there are no subscribers
                if (raiseEvent != null)
                {
                    // Format the string to send inside the CustomEventArgs parameter
                    e.Message += $" at {DateTime.Now}";
                    // Call to raise the event.
                    raiseEvent(this, e);
                }
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
                pub.RaiseStandardEvent += OnRaiseStandardEvent;
            }
            // Define what actions to take when the event is raised.
            private void OnRaiseStandardEvent(object sender, CustomEventArgs e)
            {
                Console.WriteLine($"{_id} received this message: {e.Message}");
            }
        }

        public class Test : ITest
        {
            public void Run()
            {
                var pub = new Publisher();
                var sub1 = new Subscriber("sub1", pub);
                //var sub2 = new Subscriber("sub2", pub);

                // Call the method that raises the event.
                pub.FiredStandardEvent();
            }
        }
    }
}
