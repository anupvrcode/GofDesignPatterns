using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    public class Program
    {
         /// <summary>

            /// Entry point into console application.

            /// </summary>

            static void Main()
            {
                Console.WriteLine("----------------------------------Adapter Pattern------------------------------------------------------------------------");
                Console.WriteLine("Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.");
                Console.WriteLine("Participants");
                Console.WriteLine("Target   - defines the domain-specific interface that Client uses. ");
                Console.WriteLine("Adapter   - adapts the interface Adaptee to the Target interface. ");
                Console.WriteLine("Adaptee   -defines an existing interface that needs adapting.");
                Console.WriteLine("Client   -collaborates with objects conforming to the Target interface.");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Creating Target Object using Adapter.");
                Target obj = new Adapter();
                obj.Request();


                // Wait for user

                Console.ReadKey();

            }

        }



    class Target
    {
        public virtual void Request() 
        {
            Console.WriteLine("Target.Request() is being called");
        }
    }

    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();
        public override void Request()
        {
            Console.WriteLine("Since Adapter inherits from Target the request method  in Adapter class gets called. This inturn call the SpecificRequest method in Adaptee and return the request.The client never know what happened.");
            _adaptee.SpecificRequest();
        }
    }

    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Adaptee.SpecificRequest() is being called");
        }
    }
}
