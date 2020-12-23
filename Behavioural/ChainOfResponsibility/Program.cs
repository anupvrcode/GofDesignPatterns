using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsibility
{
    public class Program
    {

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------Chain of Responsibility Pattern----------------------------------------------------------------------");
            Console.WriteLine(" Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.");
            Console.WriteLine("Participants");
            Console.WriteLine("Handler   (Approver)."); 
            Console.WriteLine("     defines an interface for handling the requests."); 
            Console.WriteLine("     (optional) implements the successor link .");
            Console.WriteLine("ConcreteHandler   (Director, VicePresident, President) .");
            Console.WriteLine("     handles requests it is responsible for .");
            Console.WriteLine("     can access its successor .");
            Console.WriteLine("     if the ConcreteHandler can handle the request, it does so; otherwise it forwards the request to its successor .");
            Console.WriteLine("Client   (ChainApp) .");
            Console.WriteLine("     initiates the request to a ConcreteHandler object on the chain.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            // Setup Chain of Responsibility

            Console.WriteLine("Creating ConcreteHandler Director. Director will inherit from Handler Approver");
            Approver larry = new Director();
            Console.WriteLine("Creating ConcreteHandler VicePresident. VicePresident will inherit from Handler Approver");
            Approver sam = new VicePresident();
            Console.WriteLine("Creating ConcreteHandler President. President will inherit from Handler Approver");
            Approver tammy = new President();


            Console.WriteLine("Director setting VicePresident as his successor.");
            larry.SetSuccessor(sam);
            Console.WriteLine("VicePresident setting President as his successor.");
            sam.SetSuccessor(tammy);



            // Generate and process purchase requests

            Purchase p = new Purchase(2034, 350.00, "Assets");

            Console.WriteLine("Director Processing a request");
            larry.ProcessRequest(p);


            Console.WriteLine("Director Processing a request");
            p = new Purchase(2035, 32590.10, "Project X");

            larry.ProcessRequest(p);



            p = new Purchase(2036, 122100.00, "Project Y");
            Console.WriteLine("Director Processing a request");
            larry.ProcessRequest(p);



            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'Handler' abstract class

    /// </summary>

    abstract class Approver
    {

        protected Approver successor;



        public void SetSuccessor(Approver successor)
        {

            this.successor = successor;

        }



        public abstract void ProcessRequest(Purchase purchase);

    }



    /// <summary>

    /// The 'ConcreteHandler' class

    /// </summary>

    class Director : Approver
    {

        public override void ProcessRequest(Purchase purchase)
        {

            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("Director Can Approve a purchase <$10000.0");
                Console.WriteLine("{0} approved request# {1}",

                  this.GetType().Name, purchase.Number);

            }

            else if (successor != null)
            {
                Console.WriteLine("If above $10000.0 pass on to successor who is VicePresident");
                successor.ProcessRequest(purchase);

            }

        }

    }



    /// <summary>

    /// The 'ConcreteHandler' class

    /// </summary>

    class VicePresident : Approver
    {

        public override void ProcessRequest(Purchase purchase)
        {

            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("Director Can Approve a purchase <$25000.0");
                Console.WriteLine("{0} approved request# {1}",

                  this.GetType().Name, purchase.Number);

            }

            else if (successor != null)
            {
                Console.WriteLine("If above $25000.0 pass on to successor who is President");
                successor.ProcessRequest(purchase);

            }

        }

    }



    /// <summary>

    /// The 'ConcreteHandler' class

    /// </summary>

    class President : Approver
    {

        public override void ProcessRequest(Purchase purchase)
        {

            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("President Can Approve a purchase <$100000.0");
                Console.WriteLine("{0} approved request# {1}",

                  this.GetType().Name, purchase.Number);

            }

            else
            {
                Console.WriteLine("If above $25000.0 President cannot approve and also have no successor.");
                Console.WriteLine(

                  "Request# {0} requires an executive meeting!",

                  purchase.Number);

            }

        }

    }



    /// <summary>

    /// Class holding request details

    /// </summary>

    class Purchase
    {

        private int _number;

        private double _amount;

        private string _purpose;



        // Constructor

        public Purchase(int number, double amount, string purpose)
        {

            this._number = number;

            this._amount = amount;

            this._purpose = purpose;

        }



        // Gets or sets purchase number

        public int Number
        {

            get { return _number; }

            set { _number = value; }

        }



        // Gets or sets purchase amount

        public double Amount
        {

            get { return _amount; }

            set { _amount = value; }

        }



        // Gets or sets purchase purpose

        public string Purpose
        {

            get { return _purpose; }

            set { _purpose = value; }

        }

    }


}
