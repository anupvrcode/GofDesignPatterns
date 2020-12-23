using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    public class Program
    {

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------Proxy Pattern----------------------------------------------------------------------");
            Console.WriteLine(" Provide a surrogate or placeholder for another object to control access to it.");
            Console.WriteLine("Participants");
            Console.WriteLine("Proxy   (MathProxy)");
            Console.WriteLine("     maintains a reference that lets the proxy access the real subject. Proxy may refer to a Subject if the RealSubject and Subject interfaces are the same. ");
            Console.WriteLine("     provides an interface identical to Subject's so that a proxy can be substituted for for the real subject. ");
            Console.WriteLine("     controls access to the real subject and may be responsible for creating and deleting it. ");
            Console.WriteLine("     other responsibilites depend on the kind of proxy: ");
            Console.WriteLine("         remote proxies are responsible for encoding a request and its arguments and for sending the encoded request to the real subject in a different address space. ");
            Console.WriteLine("         virtual proxies may cache additional information about the real subject so that they can postpone accessing it. For example, the ImageProxy from the Motivation caches the real images's extent. ");
            Console.WriteLine("         protection proxies check that the caller has the access permissions required to perform a request. ");
            Console.WriteLine("Subject   (IMath) ");
            Console.WriteLine("     defines the common interface for RealSubject and Proxy so that a Proxy can be used anywhere a RealSubject is expected. ");
            Console.WriteLine("RealSubject   (Math) ");
            Console.WriteLine("     defines the real object that the proxy represents.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            // Create math proxy

            Console.WriteLine("Creating instance of Proxy class MathProxy. MathProxy should implement/inherit Subject interface which is IMath here. Subject Interface is required to make sure the real subject and peoxy implements all the methods");
            MathProxy proxy = new MathProxy();



            // Do the math
            Console.WriteLine("Calling MathProxy.Add().");
            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("Calling MathProxy.Sub().");
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("Calling MathProxy.Mul().");
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("Calling MathProxy.Div().");
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));



            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'Subject interface

    /// </summary>

    public interface IMath
    {

        double Add(double x, double y);

        double Sub(double x, double y);

        double Mul(double x, double y);

        double Div(double x, double y);

    }



    /// <summary>

    /// The 'RealSubject' class

    /// </summary>

    class Math : IMath
    {
        public Math()
        {
            Console.WriteLine("Creating instance of Real Subject Math");
        }

        public double Add(double x, double y) { Console.WriteLine("Executing calling real Subject's Add method Math.Add()."); return x + y; }

        public double Sub(double x, double y) { Console.WriteLine("Executing calling real Subject's Sub method Math.Sub()."); return x - y; }

        public double Mul(double x, double y) { Console.WriteLine("Executing calling real Subject's Mul method Math.Mul()."); return x * y; }

        public double Div(double x, double y) { Console.WriteLine("Executing calling real Subject's Div method Math.Div()."); return x / y; }

    }



    /// <summary>

    /// The 'Proxy Object' class

    /// </summary>

    class MathProxy : IMath
    {

        private Math _math = new Math();



        public double Add(double x, double y)
        {
            Console.WriteLine("MathProxy calling real Subject's Add method Math.Add().");
            return _math.Add(x, y);

        }

        public double Sub(double x, double y)
        {
            Console.WriteLine("MathProxy calling real Subject's Sub method Math.Sub().");
            return _math.Sub(x, y);

        }

        public double Mul(double x, double y)
        {
            Console.WriteLine("MathProxy calling real Subject's Mul method Math.Mul().");
            return _math.Mul(x, y);

        }

        public double Div(double x, double y)
        {
            Console.WriteLine("MathProxy calling real Subject's Div method Math.Div().");
            return _math.Div(x, y);

        }

    }


}
