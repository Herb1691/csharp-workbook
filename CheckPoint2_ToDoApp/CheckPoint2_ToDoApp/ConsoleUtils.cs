using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint2_ToDoApp
{
    class ConsoleUtils
    {
        public ConsoleUtils()
        {
            Title();
        }
        private void Title()
        {
            Console.WriteLine("Hello!  Welcome to The ToDo App");
            Console.WriteLine("The app that lets you log and record");
            Console.WriteLine("all of your important tasks and set its' status!");
        }
        // Class To Add New Item - Returns a String
        public string AddItem()
        {
            Console.WriteLine("Please Enter the Description of the task");

            return Console.ReadLine();
        }

        // Class To Print ToDo Items - Receives a List from App Class
        public void PrintItems(List<ToDoItem> toDoItems)
        {
            Console.WriteLine("ID        Description        Status  ");
            Console.WriteLine("=====================================");

            foreach (ToDoItem item in toDoItems)
            {
                Console.WriteLine("{0}  {1}        {2}", item.Id, item.Description, item.Status);
            }
        }
        // Class To Allow a user to choose an item to update or remove by ID - Returns ID#
        public int ChooseItem()
        {
            bool validInput = false;
            int userInput = 0;

            Console.WriteLine("What is the ID of the item you are wanting to update or remove?");

            validInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (!validInput)
            {
                userInput = -1;
            }

            return userInput;
        }
        // Class Allows user to choose to update either the Description or the Status -
        // Receives the item being updated for displaying and returns a concatenated string
        // with 1 for desc or 2 for pending and if 1, concatenates the description input
        public string UpdateItem(ToDoItem toUpdate)
        {
            string updated = string.Empty;

            Console.WriteLine("ID        Description        Status  ");
            Console.WriteLine("=====================================");

            Console.WriteLine("{0}  {1}        {2}", toUpdate.Id, toUpdate.Description, toUpdate.Status);

            Console.WriteLine("Would you like to update the Description or the Status?");
            Console.WriteLine("1. Description");
            Console.WriteLine("2. Status");

            switch (Console.ReadLine())
            {
                case "1":
                    updated = AddItem();
                    break;
                case "2":
                    updated = "2";
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    updated = "-1";
                    break;
            }

            return updated;
        }
        // Menu will Display Starting Options for User - 1 for adding an item, 2 for printing the list of items,
        // 3 for Updating an item, 4 for removing an item, 5 for printing pending items,
        // 6 for printing done items - Returns an integer value
        public int MainMenu()
        {
            bool validInput = false;
            int userInput = 0;

            Console.WriteLine("Please choose from the following options: ");
            Console.WriteLine("1. Add a ToDo Item");
            Console.WriteLine("2. Display List of Items");
            Console.WriteLine("3. Update an Item");
            Console.WriteLine("4. Remove an Item");
            Console.WriteLine("5. Display Pending Items");
            Console.WriteLine("6. Display Done Items");
            Console.WriteLine("7. To Quit");

            validInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (!validInput)
            {
                userInput = -1;
            }

            return userInput;
        }

        // Empty List Method Warning - Prints warning message that list is empty
        public void EmptyList()
        {
            Console.WriteLine("The Database is currently empty.");
        }

        public void InvalidInput()
        {
            Console.WriteLine("Invalid Input!  Please Try again!");
        }

        public void SearchFailed()
        {
            Console.WriteLine("Search Failed!");
        }

        public void UpdateFailed()
        {
            Console.WriteLine("Unable To Update!");
        }
    }
}
