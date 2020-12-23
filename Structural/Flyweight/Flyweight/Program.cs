using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyweight
{
    public class Program
    {

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------Flyweight Pattern----------------------------------------------------------------------");
            Console.WriteLine("Use sharing to support large numbers of fine-grained objects efficiently. ");
            Console.WriteLine("Participants");
            Console.WriteLine("Flyweight   (Character) .");
            Console.WriteLine("     declares an interface through which flyweights can receive and act on extrinsic state. ");
            Console.WriteLine("ConcreteFlyweight   (CharacterA, CharacterB, ..., CharacterZ) .");
            Console.WriteLine("     implements the Flyweight interface and adds storage for intrinsic state, if any. A ConcreteFlyweight object must be sharable. Any state it stores must be intrinsic, that is, it must be independent of the ConcreteFlyweight object's context. .");
            Console.WriteLine("     UnsharedConcreteFlyweight   ( not used ) .");
            Console.WriteLine("     not all Flyweight subclasses need to be shared. The Flyweight interface enables sharing, but it doesn't enforce it. It is common for UnsharedConcreteFlyweight objects to have ConcreteFlyweight objects as children at some level in the flyweight object structure (as the Row and Column classes have). .");
            Console.WriteLine("FlyweightFactory   (CharacterFactory) .");
            Console.WriteLine("     creates and manages flyweight objects .");
            Console.WriteLine("     ensures that flyweight are shared properly. When a client requests a flyweight, the FlyweightFactory objects assets an existing instance or creates one, if none exists. .");
            Console.WriteLine("Client   (FlyweightApp) .");
            Console.WriteLine("     maintains a reference to flyweight(s). .");
            Console.WriteLine("     computes or stores the extrinsic state of flyweight(s).");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            // Build a document with text

            string document = "AAZZBBZB";
            Console.WriteLine("Creating character array");
            char[] chars = document.ToCharArray();


            Console.WriteLine("Creating instance of flyweight factory.");
            CharacterFactory factory = new CharacterFactory();



            // extrinsic state

            int pointSize = 10;



            // For each character use a flyweight object
            Console.WriteLine("Starting for each loop");
            foreach (char c in chars)
            {

                pointSize++;
                Console.WriteLine("Creating Flyweight object for each character");
                Character character = factory.GetCharacter(c);
                Console.WriteLine("Controlling Flyweights extrinsic state which is pointsize  and displaying it");
                character.Display(pointSize);

            }



            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'FlyweightFactory' class

    /// </summary>

    class CharacterFactory
    {

        private Dictionary<char, Character> _characters =

          new Dictionary<char, Character>();



        public Character GetCharacter(char key)
        {

            // Uses "lazy initialization"

            Character character = null;

            if (_characters.ContainsKey(key))
            {

                character = _characters[key];

            }

            else
            {

                switch (key)
                {

                    case 'A': character = new CharacterA(); break;

                    case 'B': character = new CharacterB(); break;

                    //...

                    case 'Z': character = new CharacterZ(); break;

                }

                _characters.Add(key, character);

            }

            return character;

        }

    }



    /// <summary>

    /// The 'Flyweight' abstract class

    /// </summary>

    abstract class Character
    {

        protected char symbol;

        protected int width;

        protected int height;

        protected int ascent;

        protected int descent;

        protected int pointSize;



        public abstract void Display(int pointSize);

    }



    /// <summary>

    /// A 'ConcreteFlyweight' class

    /// </summary>

    class CharacterA : Character
    {

        // Constructor

        public CharacterA()
        {

            this.symbol = 'A';

            this.height = 100;

            this.width = 120;

            this.ascent = 70;

            this.descent = 0;

        }



        public override void Display(int pointSize)
        {

            this.pointSize = pointSize;

            Console.WriteLine(this.symbol +

              " (pointsize " + this.pointSize + ")");

        }

    }



    /// <summary>

    /// A 'ConcreteFlyweight' class

    /// </summary>

    class CharacterB : Character
    {

        // Constructor

        public CharacterB()
        {

            this.symbol = 'B';

            this.height = 100;

            this.width = 140;

            this.ascent = 72;

            this.descent = 0;

        }



        public override void Display(int pointSize)
        {

            this.pointSize = pointSize;

            Console.WriteLine(this.symbol +

              " (pointsize " + this.pointSize + ")");

        }



    }



    // ... C, D, E, etc.



    /// <summary>

    /// A 'ConcreteFlyweight' class

    /// </summary>

    class CharacterZ : Character
    {

        // Constructor

        public CharacterZ()
        {

            this.symbol = 'Z';

            this.height = 100;

            this.width = 100;

            this.ascent = 68;

            this.descent = 0;

        }



        public override void Display(int pointSize)
        {

            this.pointSize = pointSize;

            Console.WriteLine(this.symbol +

              " (pointsize " + this.pointSize + ")");

        }

    }


}
