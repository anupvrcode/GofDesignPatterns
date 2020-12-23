using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facade
{
    public class Program
    {
         /// <summary>

            /// Entry point into console application.

            /// </summary>

            static void Main()
            {

                // Facade
                Console.WriteLine("------------------------------------Composite Pattern----------------------------------------------------------------------");
                Console.WriteLine("Provide a unified interface to a set of interfaces in a subsystem. Façade defines a higher-level interface that makes the subsystem easier to use");
                Console.WriteLine("Participants");
                Console.WriteLine("Facade   (MortgageApplication)"); 
                Console.WriteLine("     knows which subsystem classes are responsible for a request. ");
                Console.WriteLine("     delegates client requests to appropriate subsystem objects. ");
                Console.WriteLine("Subsystem classes   (Bank, Credit, Loan)"); 
                Console.WriteLine("     implement subsystem functionality. ");
                Console.WriteLine("     handle work assigned by the Facade object. ");
                Console.WriteLine("     have no knowledge of the facade and keep no reference to it.");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Creating instance of Facade class Mortgage");
                Mortgage mortgage = new Mortgage();
                Console.WriteLine("\nCreated instance of Facade class Mortgage\n");
                // Evaluate mortgage eligibility for customer
                Customer customer = new Customer("Ann McKinsey");
                
                bool eligible = mortgage.IsEligible(customer, 125000);
                Console.WriteLine("\n" + customer.Name +" has been " + (eligible ? "Approved" : "Rejected"));
                // Wait for user
                Console.ReadKey();

            }

        }



        /// <summary>

        /// The 'Subsystem ClassA' class

        /// </summary>

        class Bank
        {

            public Bank() { Console.WriteLine("Creating instance of subsystemclass Bank"); }
            public bool HasSufficientSavings(Customer c, int amount)
            {

                Console.WriteLine("Check bank for " + c.Name);

                return true;

            }

        }



        /// <summary>

        /// The 'Subsystem ClassB' class

        /// </summary>

        class Credit
        {
            public Credit() { Console.WriteLine("Creating instance of subsystemclass Credit"); }
            public bool HasGoodCredit(Customer c)
            {

                Console.WriteLine("Check credit for " + c.Name);

                return true;

            }

        }



        /// <summary>

        /// The 'Subsystem ClassC' class

        /// </summary>

        class Loan
        {
            public Loan() { Console.WriteLine("Creating instance of subsystemclass Loan"); }
            public bool HasNoBadLoans(Customer c)
            {

                Console.WriteLine("Check loans for " + c.Name);

                return true;

            }

        }



        /// <summary>

        /// Customer class

        /// </summary>

        class Customer
        {

            private string _name;



            // Constructor

            public Customer(string name)
            {

                this._name = name;

            }



            // Gets the name

            public string Name
            {

                get { return _name; }

            }

        }



        /// <summary>

        /// The 'Facade' class

        /// </summary>

        class Mortgage
        {

            private Bank _bank = new Bank();

            private Loan _loan = new Loan();

            private Credit _credit = new Credit();

            public Mortgage()
            {
                
            }

            public bool IsEligible(Customer cust, int amount)
            {

                Console.WriteLine("{0} applies for {1:C} Mortgage\n",

                  cust.Name, amount);



                bool eligible = true;


                Console.WriteLine("Checking Eligibility from bank,credit and loan.This happens inside "+this.GetType().ToString());
                // Check creditworthyness of applicant

                if (!_bank.HasSufficientSavings(cust, amount))
                {

                    eligible = false;

                }

                else if (!_loan.HasNoBadLoans(cust))
                {

                    eligible = false;

                }

                else if (!_credit.HasGoodCredit(cust))
                {

                    eligible = false;

                }

                Console.WriteLine("Checked all Eligibility from bank,credit and loan.This happens inside " + this.GetType().ToString());

                return eligible;

            }

        }


    
}
