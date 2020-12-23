using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Template
{
    public class Program
    {

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------Template Pattern----------------------------------------------------------------------");
            Console.WriteLine("Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.");
            Console.WriteLine("Participants");
            Console.WriteLine("AbstractClass  (DataObject) ");
            Console.WriteLine("     defines abstract primitive operations that concrete subclasses define to implement steps of an algorithm ");
            Console.WriteLine("     implements a template method defining the skeleton of an algorithm. The template method calls primitive operations as well as operations defined in AbstractClass or those of other objects. ");
            Console.WriteLine("ConcreteClass  (CustomerDataObject) ");
            Console.WriteLine("     implements the primitive operations ot carry out subclass-specific steps of the algorithm.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Creating instance of ConcreteClass Categories");
            DataAccessObject daoCategories = new Categories();
            Console.WriteLine("Calling Categories.Run.");
            daoCategories.Run();


            Console.WriteLine("Creating instance of ConcreteClass Product");
            DataAccessObject daoProducts = new Products();
            Console.WriteLine("Calling Product.Run.");
            daoProducts.Run();



            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'AbstractClass' abstract class

    /// </summary>

    abstract class DataAccessObject
    {
        public DataAccessObject()
        {
            Console.WriteLine("AbstractClass DataAccessObject. Defines interface for Connect,Select,Process,Disconnect. Also has template method Run which defines the sequence in which the above methods should run. Run method cannot be overridden and sequence cannot be changed.");
        }
        protected string connectionString;

        protected DataSet dataSet;



        public virtual void Connect()
        {

            // Make sure mdb is available to app
            Console.WriteLine("Executing Connect");
            Console.WriteLine("Check the DB Connectivity");

        }



        public abstract void Select();

        public abstract void Process();



        public virtual void Disconnect()
        {
            Console.WriteLine("Executing Disconnect");
            Console.WriteLine("Make sure the connection to DB is closed");

        }



        // The 'Template Method' 

        public void Run()
        {
            Console.WriteLine("Executing Run!!!!!!!!!!!.");
            Connect();

            Select();

            Process();

            Disconnect();
            Console.WriteLine("Executed Run!!!!!!!!!!!!!!.");
        }

    }



    /// <summary>

    /// A 'ConcreteClass' class

    /// </summary>

    class Categories : DataAccessObject
    {
        public Categories():base()
        {
            Console.WriteLine("Overrides Select and Process methods specific to Categories.");
        }
        public override void Select()
        {
            Console.WriteLine("Executing Categories.Select");
            Console.WriteLine("Selecting Categories from Category table");

        }



        public override void Process()
        {
            Console.WriteLine("Executing Categories.Process");
            Console.WriteLine("Processing Categories selected from Category table");

        }

    }



    /// <summary>

    /// A 'ConcreteClass' class

    /// </summary>

    class Products : DataAccessObject
    {
        public Products():base()
        {
            Console.WriteLine("Overrides Select and Process methods specific to Products.");
        }
        public override void Select()
        {
            Console.WriteLine("Executing Products.Select");
            Console.WriteLine("Selecting Products from Product table");

        }



        public override void Process()
        {
            Console.WriteLine("Executing Products.Process");
            Console.WriteLine("Processing Products selected from Product table");

        }

    }


}
