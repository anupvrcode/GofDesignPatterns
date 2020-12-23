using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory
{
    class Program
    {
        //static void Main(string[] args)
        //{

        //    Console.WriteLine("Creating a dictionary for employees with type IEmployee");
        //    Dictionary<EmployeeFactory.EmployeeType, IEmployee> employees = new Dictionary<EmployeeFactory.EmployeeType, IEmployee>();
        //    Console.WriteLine("Creating a list for employees by passing the type by calling the factory");
        //    foreach (EmployeeFactory.EmployeeType e in Enum.GetValues(typeof(EmployeeFactory.EmployeeType)))
        //    {
        //        employees.Add(e, EmployeeFactory.GetEmployee(e));
        //    }
 
        //    foreach (EmployeeFactory.EmployeeType type in employees.Keys)
        //    Console.WriteLine(string.Format("{0}.My salary is {1:C}", employees[type].Type, employees[type].Salary));
    
        //    Console.ReadKey();
        //}
    }

    public interface IEmployee
    {
        string Type { get;}
        double Salary { get; }
    }
    public class Manager : IEmployee
    {
        public double Salary{get { return 75.5; }}
        public string Type { get { return "I am Manager"; } }
    }

    public class Programmer : IEmployee
    {
        public double Salary{get { return 70.5; }}
        public string Type { get { return "I am Programmer"; } }
    }

    public class DBA : IEmployee
    {
        public double Salary{get { return 69.5; }}
        public string Type { get { return "I am DBA"; } }
    }

    public class EmployeeFactory
    
    {
        public enum EmployeeType
        {            
            ManagerType,            
            ProgrammerType,            
            DBAType        
        }
        
        public static IEmployee GetEmployee(EmployeeType type)
        {
            Console.WriteLine("Creating a instance of Employee based on the type passed. This is happeninig in Factory class's factory method");
            IEmployee employee = null;            
            switch (type)
            {
            case EmployeeType.ManagerType:
            Console.WriteLine("Creating a Employee of type Manager");
            employee = new Manager();                    
            break;                
            case EmployeeType.ProgrammerType:
            Console.WriteLine("Creating a Employee of type Programmer");
            employee = new Programmer();
            break;            
            case EmployeeType.DBAType:
            Console.WriteLine("Creating a Employee of type DBA");
            employee = new DBA();                    
            break;                
            default:                    
            throw new ArgumentException(string.Format("An employee of type {0} cannot be found", Enum.GetName
            (typeof(EmployeeType), type)));
            }
            return employee;
        }
    }

}
