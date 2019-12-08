// add the following import to the top for your file
using System;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Week7_BookInventory
{
    class BooksDBContext : DbContext
    {
        // This property corresponds to the table in our database
        // This property corresponds to the table in our database
        public DbSet<BookLibrary> books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the directory the code is being executed from
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            // get the base directory for the project
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            // add 'students.db' to the project directory
            String DatabaseFile = Path.Combine(ProjectBase.FullName, "BooksInventory.db");

            // to check what the path of the file is, uncomment the file below
            //Console.WriteLine("using database file :"+DatabaseFile);

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }

        public void PrintList()
        {
            foreach (BookLibrary book in books)
            {
                Console.WriteLine("{0} {1} - {2}", book.Id, book.Title, book.Author);
            }
        }
    }
}
