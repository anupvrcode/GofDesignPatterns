using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitor
{
    public class Program
    {

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------Visitor Pattern----------------------------------------------------------------------");
            Console.WriteLine("Represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.");
            Console.WriteLine("Participants");
            Console.WriteLine("Visitor  (Visitor) ");
            Console.WriteLine("     declares a Visit operation for each class of ConcreteElement in the object structure. The operation's name and signature identifies the class that sends the Visit request to the visitor. That lets the visitor determine the concrete class of the element being visited. Then the visitor can access the elements directly through its particular interface ");
            Console.WriteLine("ConcreteVisitor  (IncomeVisitor, VacationVisitor) ");
            Console.WriteLine("     implements each operation declared by Visitor. Each operation implements a fragment of the algorithm defined for the corresponding class or object in the structure. ConcreteVisitor provides the context for the algorithm and stores its local state. This state often accumulates results during the traversal of the structure. ");
            Console.WriteLine("Element  (Element) ");
            Console.WriteLine("     defines an Accept operation that takes a visitor as an argument.");
            Console.WriteLine("ConcreteElement  (Employee) ");
            Console.WriteLine("     implements an Accept operation that takes a visitor as an argument");
            Console.WriteLine("ObjectStructure  (Employees) ");
            Console.WriteLine("     can enumerate its elements ");
            Console.WriteLine("     may provide a high-level interface to allow the visitor to visit its elements ");
            Console.WriteLine("     may either be a Composite (pattern) or a collection such as a list or a set ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            // Setup employee collection
            Console.WriteLine("Creating the ObjectStructure Employees");
            Employees e = new Employees();

            e.Attach(new Clerk());

            e.Attach(new Director());

            e.Attach(new President());



            // Employees are 'visited'

            e.Accept(new IncomeVisitor());

            e.Accept(new VacationVisitor());



            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'Visitor' interface

    /// </summary>

    interface IVisitor
    {

        void Visit(Element element);

    }



    /// <summary>

    /// A 'ConcreteVisitor' class

    /// </summary>

    class IncomeVisitor : IVisitor
    {

        public void Visit(Element element)
        {
            Console.WriteLine("IncomeVisitor visiting and impacting " + element.GetType().ToString() + " income");
            Employee employee = element as Employee;



            // Provide 10% pay raise

            employee.Income *= 1.10;

            Console.WriteLine("{0} {1}'s new income: {2:C}",

              employee.GetType().Name, employee.Name,

              employee.Income);

        }

    }



    /// <summary>

    /// A 'ConcreteVisitor' class

    /// </summary>

    class VacationVisitor : IVisitor
    {

        public void Visit(Element element)
        {
            Console.WriteLine("VacationVisitor visiting and impacting "+element.GetType().ToString()+" income");
            Employee employee = element as Employee;



            // Provide 3 extra vacation days

            Console.WriteLine("{0} {1}'s new vacation days: {2}",

              employee.GetType().Name, employee.Name,

              employee.VacationDays);

        }

    }



    /// <summary>

    /// The 'Element' abstract class

    /// </summary>

    abstract class Element
    {

        public abstract void Accept(IVisitor visitor);

    }



    /// <summary>

    /// The 'ConcreteElement' class

    /// </summary>

    class Employee : Element
    {

        private string _name;

        private double _income;

        private int _vacationDays;



        // Constructor

        public Employee(string name, double income,

          int vacationDays)
        {
            Console.WriteLine("Cretaing Instance of Concrete Element "+this.GetType().ToString()+". This will have an Accept operation which can accept a Visitor.");
            this._name = name;

            this._income = income;

            this._vacationDays = vacationDays;

        }



        // Gets or sets the name

        public string Name
        {

            get { return _name; }

            set { _name = value; }

        }



        // Gets or sets income

        public double Income
        {

            get { return _income; }

            set { _income = value; }

        }



        // Gets or sets number of vacation days

        public int VacationDays
        {

            get { return _vacationDays; }

            set { _vacationDays = value; }

        }



        public override void Accept(IVisitor visitor)
        {
            Console.Write(this.GetType().ToString() + " accepting visitor " + visitor.GetType().ToString());
            visitor.Visit(this);

        }

    }



    /// <summary>

    /// The 'ObjectStructure' class

    /// </summary>

    class Employees
    {

        private List<Employee> _employees = new List<Employee>();



        public void Attach(Employee employee)
        {

            _employees.Add(employee);

        }



        public void Detach(Employee employee)
        {

            _employees.Remove(employee);

        }



        public void Accept(IVisitor visitor)
        {
            Console.WriteLine("\nObjectStructure accepting Visitor " + visitor.GetType().ToString() + " which inturn loops through all the concrete elements in the structure");
            foreach (Employee e in _employees)
            {

                e.Accept(visitor);

            }
            Console.WriteLine(visitor.GetType().ToString()+" visited all the elements in the structure\n");
            Console.WriteLine();

        }

    }



    // Three employee types



    class Clerk : Employee
    {

        // Constructor

        public Clerk()

            : base("Hank", 25000.0, 14)
        {

        }

    }



    class Director : Employee
    {

        // Constructor

        public Director()

            : base("Elly", 35000.0, 16)
        {

        }

    }



    class President : Employee
    {

        // Constructor

        public President()

            : base("Dick", 45000.0, 21)
        {

        }

    }


}
