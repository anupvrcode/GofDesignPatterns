using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory
{
    public class Program
    {
        /// <summary>

            /// Entry point into console application.

            /// </summary>

            public static void Main()
            {
                Console.WriteLine("------------------------------------AbstractFactoryPattern--------------------------------------------");
                Console.WriteLine("Provide an interface for creating families of related or dependent objects without specifying their concrete classes.");
                Console.WriteLine("Participants");
                Console.WriteLine("AbstractFactory  (ContinentFactory) - declares an interface for operations that create abstract products");
                Console.WriteLine("ConcreteFactory   (AfricaFactory, AmericaFactory) - implements the operations to create concrete product objects ");
                Console.WriteLine("AbstractProduct   (Herbivore, Carnivore) - declares an interface for a type of product object ");
                Console.WriteLine("Product  (Wildebeest, Lion, Bison, Wolf) -defines a product object to be created by the corresponding concrete factory,implements the AbstractProduct interface ");
                Console.WriteLine("Client  (AnimalWorld) -uses interfaces declared by AbstractFactory and AbstractProduct classes ");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("");
                // Create and run the African animal world

                Console.WriteLine("Creating the ConcreteFactory AfricaFactory using AbstractFactory ContinentFactory");
                ContinentFactory continent = new AfricaFactory();

                Console.WriteLine("Creating client AnimalWorld using the concretefactory.AnimalWorld doesnt know whether it is using Africa factory or AmericaFactory.");
                AnimalWorld world = new AnimalWorld(continent);
                Console.WriteLine("Executing Client's RunFoodChain method for current Factory " + continent.GetType().ToString());
                world.RunFoodChain();



                // Create and run the American animal world

                continent = new AmericaFactory();

                world = new AnimalWorld(continent);

                Console.WriteLine("Executing Client's RunFoodChain method for current Factory " + continent.GetType().ToString());
                world.RunFoodChain();



                // Wait for user input

                Console.ReadKey();

            }

    }





        /// <summary>

        /// The 'AbstractFactory' abstract class

        /// </summary>

        abstract class ContinentFactory
        {

            public abstract Herbivore CreateHerbivore();

            public abstract Carnivore CreateCarnivore();

        }



        /// <summary>

        /// The 'ConcreteFactory1' class

        /// </summary>

        class AfricaFactory : ContinentFactory
        {

            public override Herbivore CreateHerbivore()
            {

                return new Wildebeest();

            }

            public override Carnivore CreateCarnivore()
            {

                return new Lion();

            }

        }



        /// <summary>

        /// The 'ConcreteFactory2' class

        /// </summary>

        class AmericaFactory : ContinentFactory
        {

            public override Herbivore CreateHerbivore()
            {

                return new Bison();

            }

            public override Carnivore CreateCarnivore()
            {

                return new Wolf();

            }

        }



        /// <summary>

        /// The 'AbstractProductA' abstract class

        /// </summary>

        abstract class Herbivore
        {

        }



        /// <summary>

        /// The 'AbstractProductB' abstract class

        /// </summary>

        abstract class Carnivore
        {

            public abstract void Eat(Herbivore h);

        }



        /// <summary>

        /// The 'ProductA1' class

        /// </summary>

        class Wildebeest : Herbivore
        {

        }



        /// <summary>

        /// The 'ProductB1' class

        /// </summary>

        class Lion : Carnivore
        {

            public override void Eat(Herbivore h)
            {

                // Eat Wildebeest

                Console.WriteLine(this.GetType().Name +

                  " eats " + h.GetType().Name);

            }

        }



        /// <summary>

        /// The 'ProductA2' class

        /// </summary>

        class Bison : Herbivore
        {

        }



        /// <summary>

        /// The 'ProductB2' class

        /// </summary>

        class Wolf : Carnivore
        {

            public override void Eat(Herbivore h)
            {

                // Eat Bison

                Console.WriteLine(this.GetType().Name +

                  " eats " + h.GetType().Name);

            }

        }



        /// <summary>

        /// The 'Client' class 

        /// </summary>

        class AnimalWorld
        {

            private Herbivore _herbivore;

            private Carnivore _carnivore;



            // Constructor

            public AnimalWorld(ContinentFactory factory)
            {
                Console.WriteLine("ConcreteFactory creating a Concrete product which inherits from abstract product Carnivore. But again animal world doesnt really know what is getting created. Depends on the factory passed in.");
                Console.WriteLine("Here we are using " + factory.GetType().ToString());

                _carnivore = factory.CreateCarnivore();
                Console.WriteLine("Created carnivore" + _carnivore.GetType().ToString() + " since this is " + factory.GetType().ToString());
                Console.WriteLine("ConcreteFactory creating a Concrete product which inherits from abstract product Herbivore. But again animal world doesnt really know what is getting created. Depends on the factory passed in.");
                Console.WriteLine("Here we are using " + factory.GetType().ToString());
                _herbivore = factory.CreateHerbivore();
                Console.WriteLine("Created carnivore" + _herbivore.GetType().ToString() + " since this is " + factory.GetType().ToString());
            }



            public void RunFoodChain()
            {

                _carnivore.Eat(_herbivore);

            }

        }


    
}
