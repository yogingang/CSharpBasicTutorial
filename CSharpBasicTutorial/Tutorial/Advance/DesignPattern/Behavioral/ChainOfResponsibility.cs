using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class ChainOfResponsibility
{
    public interface IHandler
    {
        void Next(IHandler handler);
        void Handle(int request);
    }

    public abstract class BaseHandler : IHandler
    {
        protected IHandler? _handler;
        public abstract void Handle(int request);
        public void Next(IHandler handler) => _handler = handler;
        protected void Print(int request) => Console.WriteLine($"{GetType().Name} handled request {request}");
    }

    public class MultipleOfThreeHandler : BaseHandler
    {
        public override void Handle(int request)
        {
            if (request % 3 == 0) Print(request);
            else _handler?.Handle(request);
        }
    }

    public class EvenHandler : BaseHandler
    {
        public override void Handle(int request)
        {
            if (request % 2 == 0) Print(request);
            else _handler?.Handle(request);
        }
    }

    public class OddHandler : BaseHandler
    {
        public override void Handle(int request)
        {
            if (request % 2 != 0) Print(request);
            else _handler?.Handle(request);
        }
    }


    public class Test : ITest
    {
        public void Run()
        {
            IHandler h1 = new MultipleOfThreeHandler();
            IHandler h2 = new EvenHandler();
            IHandler h3 = new OddHandler();

            h1.Next(h2);
            h2.Next(h3);

            var requests = Enumerable.Range(1,10) ;

            foreach(var request in requests) h1.Handle(request);
        }
    }

  

}


