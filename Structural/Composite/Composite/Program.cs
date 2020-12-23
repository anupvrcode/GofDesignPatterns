using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite
{
    public class Program
    {
         /// <summary>

            /// Entry point into console application.

            /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------Composite Pattern----------------------------------------------------------------------");
            Console.WriteLine("Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly. ");
            Console.WriteLine("Participants");
            Console.WriteLine(" Component   (DrawingElement) ");
            Console.WriteLine("     declares the interface for objects in the composition. ");
            Console.WriteLine("     implements default behavior for the interface common to all classes, as appropriate. ");
            Console.WriteLine("     declares an interface for accessing and managing its child components. ");
            Console.WriteLine("     (optional) defines an interface for accessing a component's parent in the recursive structure, and implements it if that's appropriate. ");
            Console.WriteLine("Leaf   (PrimitiveElement) ");
            Console.WriteLine("     represents leaf objects in the composition. A leaf has no children. ");
            Console.WriteLine("     defines behavior for primitive objects in the composition. ");
            Console.WriteLine("Composite   (CompositeElement) ");
            Console.WriteLine("     defines behavior for components having children. ");
            Console.WriteLine("     stores child components. ");
            Console.WriteLine("     implements child-related operations in the Component interface. ");
            Console.WriteLine("Client  (CompositeApp) ");
            Console.WriteLine("     manipulates objects in the composition through the Component interface.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            // Create a tree structure 

            
            CompositeElement root = new CompositeElement("Picture");
            Console.WriteLine("Adding a Primitive element to the composite element.");
            root.Add(new PrimitiveElement("Red Line"));
            Console.WriteLine("Adding a Primitive element to the composite element.");
            root.Add(new PrimitiveElement("Blue Circle"));
            Console.WriteLine("Adding a Primitive element to the composite element.");
            root.Add(new PrimitiveElement("Green Box"));



            // Create a branch

            CompositeElement comp = new CompositeElement("Two Circles");
            Console.WriteLine("Adding a Primitive element to the composite element.");
            comp.Add(new PrimitiveElement("Black Circle"));
            Console.WriteLine("Adding a Primitive element to the composite element.");
            comp.Add(new PrimitiveElement("White Circle"));
            Console.WriteLine("Adding a Primitive element to the root composite element.");
            root.Add(comp);



            // Add and remove a PrimitiveElement

            PrimitiveElement pe = new PrimitiveElement("Yellow Line");

            root.Add(pe);
            Console.WriteLine("Removing a Primitive element from the root composite element.");
            root.Remove(pe);



            // Recursively display nodes
            Console.WriteLine("Removing a Primitive element from the root composite element.");
            root.Display(1);



            // Wait for user

            Console.ReadKey();

        }

        }



        /// <summary>

        /// The 'Component' Treenode

        /// </summary>

        abstract class DrawingElement
        {

            protected string _name;



            // Constructor

            public DrawingElement(string name)
            {

                this._name = name;

            }



            public abstract void Add(DrawingElement d);

            public abstract void Remove(DrawingElement d);

            public abstract void Display(int indent);

        }



        /// <summary>

        /// The 'Leaf' class

        /// </summary>

        class PrimitiveElement : DrawingElement
        {

            // Constructor

            public PrimitiveElement(string name)

                : base(name)
            {
                Console.WriteLine("Creating primitive element.");
                Console.WriteLine("This will be a leaf node in the tree and cannot add or delete anything to and from this element.");
            }



            public override void Add(DrawingElement c)
            {

                Console.WriteLine(

                  "Cannot add to a PrimitiveElement");

            }



            public override void Remove(DrawingElement c)
            {

                Console.WriteLine(

                  "Cannot remove from a PrimitiveElement");

            }



            public override void Display(int indent)
            {

                Console.WriteLine(

                  new String('-', indent) + " " + _name);

            }

        }



        /// <summary>

        /// The 'Composite' class

        /// </summary>

        class CompositeElement : DrawingElement
        {

            private List<DrawingElement> elements =

              new List<DrawingElement>();



            // Constructor

            public CompositeElement(string name)

                : base(name)
            {
                Console.WriteLine("Creating CompositeElement. Implements abstract class DrawElement.");
                Console.WriteLine("This will have a tree structure and can add, remove,display elements to this.");
            }



            public override void Add(DrawingElement d)
            {

                elements.Add(d);

            }



            public override void Remove(DrawingElement d)
            {

                elements.Remove(d);

            }



            public override void Display(int indent)
            {

                Console.WriteLine(new String('-', indent) +

                  "+ " + _name);



                // Display each child element on this node

                foreach (DrawingElement d in elements)
                {

                    d.Display(indent + 2);

                }

            }

        }


    
}
