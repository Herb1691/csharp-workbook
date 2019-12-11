using System;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CheckPoint2_ToDoApp
{
    class ItemContext : DbContext
    {
        // This property corresponds to the table in our database
        public DbSet<ToDoItem> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the directory the code is being executed from
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            // get the base directory for the project
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            // add 'students.db' to the project directory
            String DatabaseFile = Path.Combine(ProjectBase.FullName, "ToDoList.db");

            // to check what the path of the file is, uncomment the file below
            //Console.WriteLine("using database file :"+DatabaseFile);

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }

        public bool ItemUpdate(ToDoItem choice, string update)
        {
            bool success = false;
            String[] updating = update.Split();
            string desc = string.Empty;
            int id = 0;

            if (choice != null)
            {
                if (updating.Length == 1)
                {
                    bool isNumber = false;
                    isNumber = Int32.TryParse(updating[0], out id);

                    if (isNumber)
                    {
                        if (id == 2)
                        {
                            switch (choice.Status)
                            {
                                case "Pending":
                                    choice.Status = "Done";
                                    this.SaveChanges();
                                    success = true;
                                    break;
                                case "Done":
                                    choice.Status = "Pending";
                                    this.SaveChanges();
                                    success = true;
                                    break;
                            }
                        }
                        else
                        {
                            success = false;
                        }
                    }
                    else
                    {
                        choice.Description = updating[0];
                        this.SaveChanges();
                        success = true;
                    }
                }
                else if (updating.Length > 1)
                {
                    using (this)
                    {
                        var results = this.Items(item => item.Id == choice.Id);
                        if (results != null)
                        {
                            results.Description = update;
                            this.SaveChanges();
                        }
                    }
                    //choice.Description = update;
                    //listContext.SaveChanges();
                    //success = true;
                }
                else
                    success = false;
            }
            else
                success = false;

            return success;
        }
    }
}
