using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator
{
    public class Program
    {
        /// <summary>

            /// Entry point into console application.

            /// </summary>

            static void Main()
            {

                // Create book
                Console.WriteLine("------------------------------------Decorator Pattern----------------------------------------------------------------------");
                Console.WriteLine("Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.");
                Console.WriteLine("Participants");
                Console.WriteLine("Component   (LibraryItem) ");
                Console.WriteLine("     -defines the interface for objects that can have responsibilities added to them dynamically."); 
                Console.WriteLine("ConcreteComponent   (Book, Video) ");
                Console.WriteLine("     -defines an object to which additional responsibilities can be attached. ");
                Console.WriteLine("Decorator   (Decorator) ");
                Console.WriteLine("     -maintains a reference to a Component object and defines an interface that conforms to Component's interface.");
                Console.WriteLine("ConcreteDecorator   (Borrowable) ");
                Console.WriteLine("     -adds responsibilities to the component. ");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                // Create book
                Book book = new Book("Worley", "Inside ASP.NET", 10);
                book.Display();
                
                // Create video

                Video video = new Video("Spielberg", "Jaws", 23, 92);
                video.Display();



                // Make video borrowable, then borrow and display

                Console.WriteLine("Making video borrowable:");
                Borrowable borrowvideo = new Borrowable(video);

                borrowvideo.BorrowItem("Customer #1");

                borrowvideo.BorrowItem("Customer #2");


                Console.WriteLine("Display the borrowers");
                borrowvideo.Display();
                Console.WriteLine("Now LibraryItem video is borrowable, but LibraryItem Book is not boroowable");
                // Wait for user

                Console.ReadKey();

            }

        }



        /// <summary>

        /// The 'Component' abstract class

        /// </summary>

        abstract class LibraryItem
        {

            private int _numCopies;



            // Property

            public int NumCopies
            {

                get { return _numCopies; }

                set { _numCopies = value; }

            }



            public abstract void Display();

        }



        /// <summary>

        /// The 'ConcreteComponent' class

        /// </summary>

        class Book : LibraryItem
        {

            private string _author;

            private string _title;



            // Constructor

            public Book(string author, string title, int numCopies)
            {
                Console.WriteLine("Creating Concrete Component Book which inherits from Component LibraryItem");
                this._author = author;

                this._title = title;

                this.NumCopies = numCopies;

            }



            public override void Display()
            {

                Console.WriteLine("\nBook ------ ");

                Console.WriteLine(" Author: {0}", _author);

                Console.WriteLine(" Title: {0}", _title);

                Console.WriteLine(" # Copies: {0}", NumCopies);

            }

        }



        /// <summary>

        /// The 'ConcreteComponent' class

        /// </summary>

        class Video : LibraryItem
        {

            private string _director;

            private string _title;

            private int _playTime;



            // Constructor

            public Video(string director, string title,

              int numCopies, int playTime)
            {
                Console.WriteLine("Creating Concrete Component Video which inherits from Component LibraryItem");
                this._director = director;

                this._title = title;

                this.NumCopies = numCopies;

                this._playTime = playTime;

            }



            public override void Display()
            {

                Console.WriteLine("\nVideo ----- ");

                Console.WriteLine(" Director: {0}", _director);

                Console.WriteLine(" Title: {0}", _title);

                Console.WriteLine(" # Copies: {0}", NumCopies);

                Console.WriteLine(" Playtime: {0}\n", _playTime);

            }

        }



        /// <summary>

        /// The 'Decorator' abstract class

        /// </summary>

        abstract class Decorator : LibraryItem
        {

            protected LibraryItem libraryItem;



            // Constructor

            public Decorator(LibraryItem libraryItem)
            {

                this.libraryItem = libraryItem;

            }



            public override void Display()
            {

                libraryItem.Display();

            }

        }



        /// <summary>

        /// The 'ConcreteDecorator' class

        /// </summary>

        class Borrowable : Decorator
        {

            protected List<string> borrowers = new List<string>();



            // Constructor

            public Borrowable(LibraryItem libraryItem)

                : base(libraryItem)
            {
                Console.WriteLine("Creating instance of Concrete Decorator Borrowable.Input is Video which is a library item");
            }



            public void BorrowItem(string name)
            {
                Console.WriteLine("Implementing logic for Borrowing the Library Item "+libraryItem.GetType().ToString()+".This happens in "+this.GetType().ToString());
                borrowers.Add(name);

                libraryItem.NumCopies--;

            }



            public void ReturnItem(string name)
            {
                Console.WriteLine("Implementing logic for returning the Library Item " + libraryItem.GetType().ToString() + ".This happens in " + this.GetType().ToString());
                borrowers.Remove(name);

                libraryItem.NumCopies++;

            }



            public override void Display()
            {

                base.Display();



                foreach (string borrower in borrowers)
                {

                    Console.WriteLine(" borrower: " + borrower);

                }

            }

        }


    
}
