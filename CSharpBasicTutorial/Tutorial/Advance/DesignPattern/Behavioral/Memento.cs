using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Memento
{

    public interface ISalesOriginator
    {
        SalesMemento SaveMemento();
        void RestoreMemento(SalesMemento memento);

    }
    /// <summary>
    /// The 'Originator' class
    /// </summary>
    public class SalesOriginator: ISalesOriginator
    {
        private string _name;
        private string _phone;
        private double _budget;
        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Console.WriteLine("Name:   " + _name);
            }
        }
        // Gets or sets phone
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                Console.WriteLine("Phone:  " + _phone);
            }
        }
        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set
            {
                _budget = value;
                Console.WriteLine("Budget: " + _budget);
            }
        }
        // Stores memento
        public SalesMemento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new SalesMemento(_name, _phone, _budget);
        }
        // Restores memento
        public void RestoreMemento(SalesMemento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            (Name,Phone, Budget) = memento.GetRestore();
        }
    }

    public interface ISalesMemento
    {
        (string Name, string Phone, double Budget) GetRestore();
    }

    /// <summary>
    /// The 'Memento' class
    /// </summary>
    public class SalesMemento : ISalesMemento
    {
        private readonly string _name;
        private readonly string _phone;
        private readonly double _budget;
        // Constructor
        public SalesMemento(string name, string phone, double budget)
        {
            this._name = name;
            this._phone = phone;
            this._budget = budget;
        }
        public string Name => _name;
        public string Phone => _phone;
        public double Budget => _budget;

        public (string Name, string Phone, double Budget ) GetRestore()
        {
            return (this.Name, this.Phone, this.Budget);
        }
    }
    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    public class SalesCaretaker
    {
        public SalesMemento Memento { get; set; }   
    }

    public class Test : ITest
    {
       
        
        public void Run()
        {
            SalesOriginator s = new SalesOriginator();
            s.Name = "Noel van Halen";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;
            // Store internal state
            SalesCaretaker m = new SalesCaretaker();
            m.Memento = s.SaveMemento();
            // Continue changing originator
            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;
            // Restore saved state
            s.RestoreMemento(m.Memento);
        }
    }
}


