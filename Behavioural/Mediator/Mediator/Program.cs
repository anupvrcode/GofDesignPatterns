using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mediator
{
    public class Program
    {

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------Mediator Pattern----------------------------------------------------------------------");
            Console.WriteLine("Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.");
            Console.WriteLine("Participants");
            Console.WriteLine("Mediator  (IChatroom)");
            Console.WriteLine("     defines an interface for communicating with Colleague objects ");
            Console.WriteLine("ConcreteMediator  (Chatroom) ");
            Console.WriteLine("     implements cooperative behavior by coordinating Colleague objects ");
            Console.WriteLine("     knows and maintains its colleagues ");
            Console.WriteLine("Colleague classes  (Participant) ");
            Console.WriteLine("     each Colleague class knows its Mediator object ");
            Console.WriteLine("     each colleague communicates with its mediator whenever it would have otherwise communicated with another colleague ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            // Create chatroom

            Console.WriteLine("Creating instance of ConcreteMediator ChatRoom");
            Chatroom chatroom = new Chatroom();


            
            // Create participants and register them

            Console.WriteLine("Creating Participant George");
            Participant George = new Beatle("George");
            Console.WriteLine("Creating Participant Paul");
            Participant Paul = new Beatle("Paul");
            Console.WriteLine("Creating Participant Ringo");
            Participant Ringo = new Beatle("Ringo");
            Console.WriteLine("Creating Participant John");
            Participant John = new Beatle("John");
            Console.WriteLine("Creating Participant Yoko");
            Participant Yoko = new NonBeatle("Yoko");


            Console.WriteLine("Registering Participant Geroge to chatroom");
            chatroom.Register(George);
            Console.WriteLine("Registering Participant Paul to chatroom");
            chatroom.Register(Paul);
            Console.WriteLine("Registering Participant Ringo to chatroom");
            chatroom.Register(Ringo);
            Console.WriteLine("Registering Participant John to chatroom");
            chatroom.Register(John);
            Console.WriteLine("Registering Participant Yoko to chatroom");
            chatroom.Register(Yoko);



            // Chatting participants

            Yoko.Send("John", "Hi John!");

            Paul.Send("Ringo", "All you need is love");

            Ringo.Send("George", "My sweet Lord");

            Paul.Send("John", "Can't buy me love");

            John.Send("Yoko", "My sweet love");



            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'Mediator' abstract class

    /// </summary>

    abstract class AbstractChatroom
    {

        public abstract void Register(Participant participant);

        public abstract void Send(

          string from, string to, string message);

    }



    /// <summary>

    /// The 'ConcreteMediator' class

    /// </summary>

    class Chatroom : AbstractChatroom
    {
        public Chatroom()
        {
            Console.WriteLine("Inherits from Mediator AbstractChatRoom. Keeps a list of participants,Allows participants to register and also to send messages between participants");
        }

        private Dictionary<string, Participant> _participants =

          new Dictionary<string, Participant>();



        public override void Register(Participant participant)
        {
            Console.WriteLine("Adding " + participant.Name + "to chatroom's participant list.");
            if (!_participants.ContainsValue(participant))
            {

                _participants[participant.Name] = participant;

            }



            participant.Chatroom = this;

        }



        public override void Send(

          string from, string to, string message)
        {

            Console.WriteLine("ChatRoom sending the message to recipent");
            Participant participant = _participants[to];



            if (participant != null)
            {

                participant.Receive(from, message);

            }

        }

    }



    /// <summary>

    /// The 'AbstractColleague' class

    /// </summary>

    class Participant
    {

        private Chatroom _chatroom;

        private string _name;



        // Constructor

        public Participant(string name)
        {

            this._name = name;

        }



        // Gets participant name

        public string Name
        {

            get { return _name; }

        }



        // Gets chatroom

        public Chatroom Chatroom
        {

            set { _chatroom = value; }

            get { return _chatroom; }

        }



        // Sends message to given participant

        public void Send(string to, string message)
        {

            _chatroom.Send(_name, to, message);

        }



        // Receives message from given participant

        public virtual void Receive(

          string from, string message)
        {

            Console.WriteLine("{0} to {1}: '{2}'",

              from, Name, message);

        }

    }



    /// <summary>

    /// A 'ConcreteColleague' class

    /// </summary>

    class Beatle : Participant
    {

        // Constructor

        public Beatle(string name)

            : base(name)
        {

        }



        public override void Receive(string from, string message)
        {

            Console.Write("To a Beatle: ");

            base.Receive(from, message);

        }

    }



    /// <summary>

    /// A 'ConcreteColleague' class

    /// </summary>

    class NonBeatle : Participant
    {

        // Constructor

        public NonBeatle(string name)

            : base(name)
        {

        }



        public override void Receive(string from, string message)
        {

            Console.Write("To a non-Beatle: ");

            base.Receive(from, message);

        }

    }


}
