using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    class fortutorial
    {
        static void Main()
        {
            Console.WriteLine("------------------------------------Singleton--------------------------------------------");
            Console.WriteLine("Ensure a class has only one instance and provide a global point of access to it");
            Console.WriteLine("Participants");
            Console.WriteLine("Singleton   (LoadBalancer) ");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Creating Instance of SingletonClass1");
            SingletonClass obj1 = SingletonClass.GetInstance(1);
            Console.WriteLine("Creating Instance of SingletonClass2");
            SingletonClass obj2 = SingletonClass.GetInstance(2);
            Console.WriteLine("Creating Instance of SingletonClass3");
            SingletonClass obj3 = SingletonClass.GetInstance(3);
            Console.WriteLine("Creating Instance of SingletonClass4");
            SingletonClass obj4 = SingletonClass.GetInstance(4);

            Console.WriteLine("If all 4 instances are same");
                if (obj1 == obj2 && obj2 == obj3 && obj3 == obj4)
                {
                    Console.WriteLine("Same instance\n");
                }
                else
                {
                    Console.WriteLine("Different instances got created");
                }

            Console.WriteLine("index for SingletonClass1-->"+obj1.Index);
            Console.WriteLine("index for SingletonClass2-->"+obj2.Index);
            Console.WriteLine("index for SingletonClass3-->"+obj3.Index);
            Console.WriteLine("index for SingletonClass4-->"+obj4.Index);
            Console.ReadLine();
        }

        class SingletonClass
        {
            private int _index;
            public int Index{get{return _index;}}
            private static SingletonClass singletonInstance;
            private static object lockObj = new object();

            public static SingletonClass GetInstance( int i)
            {
                if (singletonInstance == null)
                {
                    lock (lockObj)
                    {
                        singletonInstance = new SingletonClass();
                        singletonInstance._index = i;
                    }
                }

                return singletonInstance;
            }
        }
    }
}
