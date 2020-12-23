﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Builder
{
   
public class Program
        {

            /// <summary>

            /// Entry point into console application.

            /// </summary>

            public static void Main()
            {
                Console.WriteLine("----------------------------------Builder Pattern------------------------------------------------------------------------");
                Console.WriteLine("Separate the construction of a complex object from its representation so that the same construction process can create different representations.");
                Console.WriteLine("Participants");
                Console.WriteLine("Builder  (VehicleBuilder) - specifies an abstract interface for creating parts of a Product object ");
                Console.WriteLine("ConcreteBuilder  (MotorCycleBuilder, CarBuilder, ScooterBuilder) - constructs and assembles parts of the product by implementing the Builder interface defines and keeps track of the representation it creates provides an interface for retrieving the product ");
                Console.WriteLine("Director  (Shop) - constructs an object using the Builder interface ");
                Console.WriteLine("Product  (Vehicle)- represents the complex object under construction. ConcreteBuilder builds the product's internal representation and defines the process by which it's assembled includes classes that define the constituent parts, including interfaces for assembling the parts into the final result ");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                // Create shop with vehicle builders
                Console.WriteLine("Creating instance of Shop which is Director");
                Shop shop = new Shop();

                Console.WriteLine("Declaring the builder VehicleBuilder");
                VehicleBuilder builder;
                // Construct and display vehicles

                Console.WriteLine("Instantiating a concrete builder ScooterBuilder which implements vehicleBuilder");
                builder = new ScooterBuilder();

                shop.Construct(builder);
                builder.Vehicle.Show();


                Console.WriteLine("Instantiating a concrete builder CarBuilder which implements vehicleBuilder");
                builder = new CarBuilder();

                shop.Construct(builder);
                builder.Vehicle.Show();


                Console.WriteLine("Instantiating a concrete builder MotorCycleBuilder which implements vehicleBuilder");
                builder = new MotorCycleBuilder();

                shop.Construct(builder);
                builder.Vehicle.Show();



                // Wait for user

                Console.ReadKey();

            }

        }



        /// <summary>

        /// The 'Director' class

        /// </summary>

        class Shop
        {

            // Builder uses a complex series of steps

            public void Construct(VehicleBuilder vehicleBuilder)
            {
                Console.WriteLine("Constructing the complex product using builder "+vehicleBuilder.GetType().ToString());
                vehicleBuilder.BuildFrame();
                vehicleBuilder.BuildEngine();
                vehicleBuilder.BuildWheels();
                vehicleBuilder.BuildDoors();
            }

        }



        /// <summary>

        /// The 'Builder' abstract class

        /// </summary>

        abstract class VehicleBuilder
        {

            protected Vehicle vehicle;



            // Gets vehicle instance

            public Vehicle Vehicle
            {

                get { return vehicle; }

            }



            // Abstract build methods

            public abstract void BuildFrame();

            public abstract void BuildEngine();

            public abstract void BuildWheels();

            public abstract void BuildDoors();

        }



        /// <summary>

        /// The 'ConcreteBuilder1' class

        /// </summary>

        class MotorCycleBuilder : VehicleBuilder
        {

            public MotorCycleBuilder()
            {

                vehicle = new Vehicle("MotorCycle");

            }



            public override void BuildFrame()
            {

                vehicle["frame"] = "MotorCycle Frame";

            }



            public override void BuildEngine()
            {

                vehicle["engine"] = "500 cc";

            }



            public override void BuildWheels()
            {

                vehicle["wheels"] = "2";

            }



            public override void BuildDoors()
            {

                vehicle["doors"] = "0";

            }

        }





        /// <summary>

        /// The 'ConcreteBuilder2' class

        /// </summary>

        class CarBuilder : VehicleBuilder
        {

            public CarBuilder()
            {

                vehicle = new Vehicle("Car");

            }



            public override void BuildFrame()
            {

                vehicle["frame"] = "Car Frame";

            }



            public override void BuildEngine()
            {

                vehicle["engine"] = "2500 cc";

            }



            public override void BuildWheels()
            {

                vehicle["wheels"] = "4";

            }



            public override void BuildDoors()
            {

                vehicle["doors"] = "4";

            }

        }



        /// <summary>

        /// The 'ConcreteBuilder3' class

        /// </summary>

        class ScooterBuilder : VehicleBuilder
        {

            public ScooterBuilder()
            {

                vehicle = new Vehicle("Scooter");

            }



            public override void BuildFrame()
            {

                vehicle["frame"] = "Scooter Frame";

            }



            public override void BuildEngine()
            {

                vehicle["engine"] = "50 cc";

            }



            public override void BuildWheels()
            {

                vehicle["wheels"] = "2";

            }



            public override void BuildDoors()
            {

                vehicle["doors"] = "0";

            }

        }



        /// <summary>

        /// The 'Product' class

        /// </summary>

        class Vehicle
        {

            private string _vehicleType;

            private Dictionary<string, string> _parts =

              new Dictionary<string, string>();



            // Constructor

            public Vehicle(string vehicleType)
            {

                this._vehicleType = vehicleType;

            }



            // Indexer

            public string this[string key]
            {

                get { return _parts[key]; }

                set { _parts[key] = value; }

            }



            public void Show()
            {

                Console.WriteLine("\n---------------------------");

                Console.WriteLine("Vehicle Type: {0}", _vehicleType);

                Console.WriteLine(" Frame : {0}", _parts["frame"]);

                Console.WriteLine(" Engine : {0}", _parts["engine"]);

                Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);

                Console.WriteLine(" #Doors : {0}", _parts["doors"]);

            }

        }


}
