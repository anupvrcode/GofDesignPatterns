using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    class Program1
    {

        static void Main()
        {
            Console.WriteLine("------------------------------------BridgePattern----------------------------------------------------------------------");
            Console.WriteLine(" Decouple an abstraction from its implementation so that the two can vary independently.");
            Console.WriteLine("Participants");
            Console.WriteLine("Abstraction   (BusinessObject) ");
            Console.WriteLine("       -defines the abstraction's interface. ");
            Console.WriteLine("       -maintains a reference to an object of type Implementor. ");
            Console.WriteLine("RefinedAbstraction   (CustomersBusinessObject) ");
            Console.WriteLine("       -extends the interface defined by Abstraction. ");
            Console.WriteLine("Implementor   (DataObject) ");
            Console.WriteLine("       -defines the interface for implementation classes. This interface doesn't have to correspond exactly to Abstraction's interface; in fact the two interfaces can be quite different. Typically the Implementation interface provides only primitive operations, and Abstraction defines higher-level operations based on these primitives. ");
            Console.WriteLine("ConcreteImplementor   (CustomersDataObject) ");
            Console.WriteLine("       -implements the Implementor interface and defines its concrete implementation.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Creating an object of RefinedAbstraction which inherit from Abstraction. Abstraction abstracts the class properties and have separate class to handle implementation.");
            Abstraction abstraction = new RefinedAbstraction();
            Console.WriteLine("Creating an object ConcreteImplementorA and assigning it as the Refined Abstraction's implementor.");
            abstraction.Implementor = new ConcreteImplementorA();

            Console.WriteLine("Calling Refined Abstractions operation. This will call Implementor A's method");
            abstraction.Operation();
            Console.WriteLine("Creating an object ConcreteImplementorA and assigning it as the Refined Abstraction's implementor.");
            abstraction.Implementor = new ConcreteImplementorB();
            Console.WriteLine("Calling Refined Abstractions operation. This will call Implementor B's method");
            abstraction.Operation();

            Console.ReadKey();
        
        }
        class Abstraction
        {
            protected Implementor implementor;
            public Implementor Implementor
            {
                set { implementor = value; }
            }
            public virtual void Operation()
            {
                implementor.Operation();
            }
        }

        class RefinedAbstraction:Abstraction
        {
            public override void Operation()
            {
                implementor.Operation();
            }
        }

        abstract class Implementor
        {
            public abstract void Operation();

        }

        class ConcreteImplementorA : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("Calling ConcreteImplementorA.Operation");
            }
        }
        class ConcreteImplementorB : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("Calling ConcreteImplementorB.Operation");
            }
        }

    }
}
