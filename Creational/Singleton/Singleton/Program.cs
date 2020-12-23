using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    public class Program
    {
        

            /// <summary>

            /// Entry point into console application.

            /// </summary>

           /* static void Main()
            {
                Console.WriteLine("------------------------------------Singleton--------------------------------------------");
                Console.WriteLine("Ensure a class has only one instance and provide a global point of access to it");
                Console.WriteLine("Participants");
                Console.WriteLine("Singleton   (LoadBalancer) ");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Creating Instance of Loadbalancer1");
                LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
                Console.WriteLine("Creating Instance of Loadbalancer2");
                LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
                Console.WriteLine("Creating Instance of Loadbalancer3");
                LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
                Console.WriteLine("Creating Instance of Loadbalancer4");
                LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

                // Same instance?
                Console.WriteLine("If all 4 instances are same");
                if (b1 == b2 && b2 == b3 && b3 == b4)
                {
                    Console.WriteLine("Same instance\n");
                }
                else
                {
                    Console.WriteLine("Different instances got created");
                }


                // Load balance 15 server requests

                LoadBalancer balancer = LoadBalancer.GetLoadBalancer();

                for (int i = 0; i < balancer.Servers.Count; i++)
                {

                    //string server = balancer.Servers[i];

                    Console.WriteLine("Dispatch Request to: " + balancer.Servers[i]);

                }



                // Wait for user

                Console.ReadKey();

            }*/

        }



        /// <summary>

        /// The 'Singleton' class

        /// </summary>

        class LoadBalancer
        {

            private static LoadBalancer _instance;

            private List<string> _servers = new List<string>();

            private Random _random = new Random();

            public List<string> Servers { get { return _servers; } }

            // Lock synchronization object

            private static object syncLock = new object();



            // Constructor (protected)

            protected LoadBalancer()
            {

                // List of available servers
                Console.WriteLine("Loadbalancer getting created and adding servers to loadbalancer");
                _servers.Add("ServerI");

                _servers.Add("ServerII");

                _servers.Add("ServerIII");

                _servers.Add("ServerIV");

                _servers.Add("ServerV");

            }



            public static LoadBalancer GetLoadBalancer()
            {

                // Support multithreaded applications through

                // 'Double checked locking' pattern which (once

                // the instance exists) avoids locking each

                // time the method is invoked

                
                if (_instance == null)
                {

                    lock (syncLock)
                    {

                        if (_instance == null)
                        {
                            Console.WriteLine("Trying to create instance of Loadalancer");
                            Console.WriteLine("If static variable  is not created create new instance of LoadBalancer.Else return the already created instance");
                            _instance = new LoadBalancer();

                        }

                    }

                }



                return _instance;

            }



            // Simple, but effective random load balancer

            public string Server
            {

                get
                {

                    int r = _random.Next(_servers.Count);

                    return _servers[r].ToString();

                }

            }

        }

       
}
