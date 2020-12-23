using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    public class Program
    {

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------Strategy Pattern----------------------------------------------------------------------");
            Console.WriteLine("Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it");
            Console.WriteLine("Participants");
            Console.WriteLine("Strategy  (SortStrategy)"); 
            Console.WriteLine("     declares an interface common to all supported algorithms. Context uses this interface to call the algorithm defined by a ConcreteStrategy ");
            Console.WriteLine("ConcreteStrategy  (QuickSort, ShellSort, MergeSort) ");
            Console.WriteLine("     implements the algorithm using the Strategy interface ");
            Console.WriteLine("Context  (SortedList) ");
            Console.WriteLine("     is configured with a ConcreteStrategy object ");
            Console.WriteLine("     maintains a reference to a Strategy object ");
            Console.WriteLine("     may define an interface that lets Strategy access its data.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            // Two contexts following different strategies

            SortedList studentRecords = new SortedList();



            studentRecords.Add("Samual");

            studentRecords.Add("Jimmy");

            studentRecords.Add("Sandra");

            studentRecords.Add("Vivek");

            studentRecords.Add("Anna");



            studentRecords.SetSortStrategy(new QuickSort());

            studentRecords.Sort();



            studentRecords.SetSortStrategy(new ShellSort());

            studentRecords.Sort();



            studentRecords.SetSortStrategy(new MergeSort());

            studentRecords.Sort();



            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'Strategy' abstract class

    /// </summary>

    abstract class SortStrategy
    {

        public abstract void Sort(List<string> list);

    }



    /// <summary>

    /// A 'ConcreteStrategy' class

    /// </summary>

    class QuickSort : SortStrategy
    {

        public override void Sort(List<string> list)
        {

            list.Sort(); // Default is Quicksort

            Console.WriteLine("QuickSorted list ");

        }

    }



    /// <summary>

    /// A 'ConcreteStrategy' class

    /// </summary>

    class ShellSort : SortStrategy
    {

        public override void Sort(List<string> list)
        {

            //list.ShellSort(); not-implemented

            Console.WriteLine("ShellSorted list ");

        }

    }



    /// <summary>

    /// A 'ConcreteStrategy' class

    /// </summary>

    class MergeSort : SortStrategy
    {

        public override void Sort(List<string> list)
        {

            //list.MergeSort(); not-implemented

            Console.WriteLine("MergeSorted list ");

        }

    }



    /// <summary>

    /// The 'Context' class

    /// </summary>

    class SortedList
    {

        private List<string> _list = new List<string>();

        private SortStrategy _sortstrategy;

        public SortedList()
        {
            Console.WriteLine("Cretaing instance of Context SortedList. SortedList will have a SortStrategy Associated to which a ConcreteStrategy can be assigned");
        }

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            Console.WriteLine("Setting SortStrategy to SortedList. Right now associating "+sortstrategy.GetType().ToString());
            this._sortstrategy = sortstrategy;

        }



        public void Add(string name)
        {
            Console.WriteLine("Adding elements to the SortedList");
            _list.Add(name);

        }



        public void Sort()
        {
            Console.WriteLine("Calling SortedList.Sort");
            _sortstrategy.Sort(_list);



            // Iterate over list and display results

            foreach (string name in _list)
            {

                Console.WriteLine(" " + name);

            }

            Console.WriteLine();

        }

    }


}
