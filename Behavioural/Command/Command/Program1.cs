using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command
{
    class Program1
    {
        static void Main()
        {
            Console.WriteLine("------------------------------------CommandPattern----------------------------------------------------------------------");
            Console.WriteLine("Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.");
            Console.WriteLine("Participants");
            Console.WriteLine("Command");
            Console.WriteLine("     declares an interface for executing an operation ");
            Console.WriteLine("ConcreteCommand");
            Console.WriteLine("     defines a binding between a Receiver object and an action ");
            Console.WriteLine("     implements Execute by invoking the corresponding operation(s) on Receiver ");
            Console.WriteLine("Client");
            Console.WriteLine("     creates a ConcreteCommand object and sets its receiver ");
            Console.WriteLine("Invoker");
            Console.WriteLine("     asks the command to carry out the request ");
            Console.WriteLine("Receiver");
            Console.WriteLine("     knows how to perform the operations associated with carrying out the request.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Creating instance of Reciever. He is the one who eventually perform the operation");
            Reciever reciever = new Reciever();
            Console.WriteLine("Creating instance of Invoker.Invoker should have a command to carry out the request");
            Invoker invoker = new Invoker();
            Console.WriteLine("Creating instance of ConcreteCommand which inherits from Command.He is the one who will invoke the reciever");
            Command command = new ConcreteCommand(reciever);
            
            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            Console.ReadLine();
        }

        abstract class Command
        {
            protected Reciever _reciever;
            public Command(Reciever reciever)
            {
                this._reciever = reciever;
            }

            public abstract void Execute();
        }

        class ConcreteCommand : Command
        {
            public ConcreteCommand(Reciever reciever):base(reciever)
            {
                Console.WriteLine("Associating Reciever to Command");
            }

            public override void Execute()
            {
                _reciever.Action();
            }
        }


        class Reciever
        {
            public void Action()
            {
                Console.WriteLine("Executing Reciever.Action()");
            }
        }

        class Invoker
        {
            private Command _command;
            
            public void SetCommand(Command command)
            {
                Console.WriteLine("Associating the command to Invoker");
                this._command = command;
            }

            public void ExecuteCommand()
            {
                Console.WriteLine("Executing the command from Invoker");
                _command.Execute();
            }
        }
    }
}
