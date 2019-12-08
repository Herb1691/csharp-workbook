using System;
using System.Collections.Generic;
using System.Text;


namespace Week7_BookInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            String finished = string.Empty;

            // instantiate an instance of the context
            BooksDBContext context = new BooksDBContext();

            // makes sure that the table exists, 
            //and creates it if it does not already exist
            context.Database.EnsureCreated();

            Console.WriteLine("Hello! This app is to inventory books you own or are interested in.");

            while (!done)
            {
                Console.WriteLine("What is the title of the book that you want to log?");
                Console.Write("Title: ");
                String titleInput = Console.ReadLine();
                Console.WriteLine("\nWho is the Author of {0}?", titleInput);
                Console.Write("Author: ");
                String authorInput = Console.ReadLine();

                BookLibrary newBook = new BookLibrary(titleInput, authorInput);

                context.books.Add(newBook);

                context.SaveChanges();

                bool validInput = false;

                while(!validInput)
                {
                    Console.WriteLine("\nContinue?");
                    Console.Write("Yes or No: ");

                    finished = Console.ReadLine();

                    switch (finished.ToUpper())
                    {
                        case "YES":
                            done = false;
                            validInput = true;
                            break;
                        case "NO":
                            done = true;
                            validInput = true;
                            break;
                        default:
                            Console.WriteLine("Please type either Yes or No.");
                            validInput = false;
                            break;
                    }
                }
            }

            context.PrintList();
            Console.ReadLine();
        }
    }
}
