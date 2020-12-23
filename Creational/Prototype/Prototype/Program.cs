using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype
{
    public class Program
    {
        /// <summary>

            /// Entry point into console application.

            /// </summary>

            static void Main()
            {
                Console.WriteLine("-------------------------------------Prototype Pattern-------------------------------------------");
                Console.WriteLine("A fully initialized instance to be copied or cloned");
                Console.WriteLine("Participants");
                Console.WriteLine("Prototype  (ColorPrototype)-declares an interface for cloning itself ");
                Console.WriteLine("ConcretePrototype  (Color)-implements an operation for cloning itself ");
                Console.WriteLine("Client  (ColorManager)-creates a new object by asking a prototype to clone itself ");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("");
                
                
                ColorManager colormanager = new ColorManager();



                // Initialize with standard colors
                Console.WriteLine("Creating new instance of color red 255,0,0 and adding to ColorManager.");
                colormanager["red"] = new Color(255, 0, 0);
                Console.WriteLine("Creating new instance of color green 0,255,0 and adding to ColorManager.");
                colormanager["green"] = new Color(0, 255, 0);
                Console.WriteLine("Creating new instance of color blue 0,0,255 and adding to ColorManager.");
                colormanager["blue"] = new Color(0, 0, 255);



                // User adds personalized colors
                Console.WriteLine("Creating new instance of color angry 255, 54, 0 and adding to ColorManager.");
                colormanager["angry"] = new Color(255, 54, 0);
                Console.WriteLine("Creating new instance of color peace 128, 211, 128 and adding to ColorManager.");
                colormanager["peace"] = new Color(128, 211, 128);
                Console.WriteLine("Creating new instance of color flame 211, 34, 20 and adding to ColorManager.");
                colormanager["flame"] = new Color(211, 34, 20);



                // User clones selected colors

                Console.WriteLine("Creating new instance of color by cloning previously created color red.");
                Color color1 = colormanager["red"].Clone() as Color;
                Console.WriteLine("Creating new instance of color by cloning previously created color peace.");
                Color color2 = colormanager["peace"].Clone() as Color;
                Console.WriteLine("Creating new instance of color by cloning previously created color flame.");
                Color color3 = colormanager["flame"].Clone() as Color;



                // Wait for user

                Console.ReadKey();

            }

        }



        /// <summary>

        /// The 'Prototype' abstract class

        /// </summary>

        interface ColorPrototype
        {

            ColorPrototype Clone();

        }



        /// <summary>

        /// The 'ConcretePrototype' class

        /// </summary>

        class Color : ColorPrototype
        {

            private int _red;

            private int _green;

            private int _blue;



            // Constructor

            public Color(int red, int green, int blue)
            {
                Console.WriteLine("Creating Instance of class Color. Color implements interface ColorPrototypeto  make sure it has a clone method and hence a clonable object .");
                this._red = red;

                this._green = green;

                this._blue = blue;

            }



            // Create a shallow copy

            public ColorPrototype Clone()
            {

                Console.WriteLine(

                  "Executing clone  method.Cloning color RGB: {0,3},{1,3},{2,3}",

                  _red, _green, _blue);



                return this.MemberwiseClone() as ColorPrototype;

            }

        }



        /// <summary>

        /// Prototype manager

        /// </summary>

        class ColorManager
        {

            private Dictionary<string, ColorPrototype> _colors;

            public ColorManager()
            {
                Console.WriteLine("Creating ColorManager. Not a required player. Contains a dictionary of clonable objects.");
                _colors = new Dictionary<string, ColorPrototype>();
            }

            // Indexer

            public ColorPrototype this[string key]
            {

                get { return _colors[key]; }

                set { _colors.Add(key, value); }

            }

        }


    
}
