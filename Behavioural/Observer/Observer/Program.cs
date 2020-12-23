using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    public class Program
    {

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------Observer Pattern----------------------------------------------------------------------");
            Console.WriteLine("Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.");
            Console.WriteLine("Participants");
            Console.WriteLine("Subject  (Stock) ");
            Console.WriteLine("     knows its observers. Any number of Observer objects may observe a subject .");
            Console.WriteLine("     provides an interface for attaching and detaching Observer objects. ");
            Console.WriteLine("ConcreteSubject  (IBM) ");
            Console.WriteLine("     stores state of interest to ConcreteObserver .");
            Console.WriteLine("     sends a notification to its observers when its state changes .");
            Console.WriteLine("Observer  (IInvestor)");
            Console.WriteLine("     defines an updating interface for objects that should be notified of changes in a subject.");
            Console.WriteLine("ConcreteObserver  (Investor)");
            Console.WriteLine("     maintains a reference to a ConcreteSubject object .");
            Console.WriteLine("     stores state that should stay consistent with the subject's .");
            Console.WriteLine("     implements the Observer updating interface to keep its state consistent with the subject's.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            // Create IBM stock and attach investors
            
            
            IBM ibm = new IBM("IBM", 120.00);

            Investor obj = new Investor("Sorros");
            ibm.Attach(obj);
            obj = new Investor("Berkshire");
            ibm.Attach(obj);



            // Fluctuating prices will notify investors

            ibm.Price = 120.10;

            ibm.Price = 121.00;

            ibm.Price = 120.50;

            ibm.Price = 120.75;

            ibm.Detach(obj);
            ibm.Price = 120.50;

            ibm.Price = 120.75;
            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'Subject' abstract class

    /// </summary>

    abstract class Stock
    {

        private string _symbol;

        private double _price;

        private List<IInvestor> _investors = new List<IInvestor>();



        // Constructor

        public Stock(string symbol, double price)
        {

            this._symbol = symbol;

            this._price = price;

        }



        public void Attach(IInvestor investor)
        {
            Console.WriteLine("Attaching the observer to the subject");
            _investors.Add(investor);

        }



        public void Detach(IInvestor investor)
        {
            Console.WriteLine("Detaching the observer to the subject");
            _investors.Remove(investor);

        }



        public void Notify()
        {
            Console.WriteLine("Notifying the observer to the subject");
            foreach (IInvestor investor in _investors)
            {

                investor.Update(this);

            }



            Console.WriteLine("");

        }



        // Gets or sets the price

        public double Price
        {

            get { return _price; }

            set
            {

                if (_price != value)
                {

                    _price = value;

                    Notify();

                }

            }

        }



        // Gets the symbol

        public string Symbol
        {

            get { return _symbol; }

        }

    }



    /// <summary>

    /// The 'ConcreteSubject' class

    /// </summary>

    class IBM : Stock
    {

        // Constructor

        public IBM(string symbol, double price)

            : base(symbol, price)
        {
            Console.WriteLine("Creating ConcreteSubject Stock");
        }

    }



    /// <summary>

    /// The 'Observer' interface

    /// </summary>

    interface IInvestor
    {

        void Update(Stock stock);

    }



    /// <summary>

    /// The 'ConcreteObserver' class

    /// </summary>

    class Investor : IInvestor
    {

        public string _name;

        private Stock _stock;



        // Constructor

        public Investor(string name)
        {

            this._name = name;

        }



        public void Update(Stock stock)
        {

            Console.WriteLine("Notified {0} of {1}'s " +

              "change to {2:C}", _name, stock.Symbol, stock.Price);

        }



        // Gets or sets the stock

        public Stock Stock
        {

            get { return _stock; }

            set { _stock = value; }

        }

    }


}
