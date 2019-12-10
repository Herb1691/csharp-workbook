using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint2_ToDoApp
{
    class App
    {
        ItemRepository repositoryItem = new ItemRepository();
        ConsoleUtils console = new ConsoleUtils();

        public void Start()
        {
            bool done = false;

            while (!done)
            {
                int menuSelection = 0;
                string desc = string.Empty;
                menuSelection = console.MainMenu();

                switch (menuSelection)
                {
                    case -1:
                        // Invalid Input
                        console.InvalidInput();
                        break;
                    case 1:
                        // 1. Add a ToDo Item
                        desc = console.AddItem();
                        repositoryItem.AddToDB(desc);
                        break;
                    case 2:
                        // 2. Display List of Items
                        List<ToDoItem> toDoList = repositoryItem.PrintList();
                        if (toDoList != null)
                        {
                            console.PrintItems(toDoList);
                        }
                        else
                        {
                            console.EmptyList();
                        }
                        break;
                    case 3:
                        // 3. Update an Item
                        ToDoItem itemToUpdate = repositoryItem.FindItem(console.ChooseItem());

                        if (itemToUpdate != null)
                        {
                            string info = console.UpdateItem(itemToUpdate);
                            bool isUpdated = false;

                            if (info != "-1")
                            {
                                isUpdated = repositoryItem.ItemUpdate(itemToUpdate, info);
                            }
                            else
                                console.InvalidInput();

                            if (isUpdated == false)
                            {
                                console.UpdateFailed();
                            }
                        }
                        else
                        {
                            console.SearchFailed();
                        }
                        break;
                    case 4:
                        // 4. Remove an Item
                        ToDoItem itemToRemove = repositoryItem.FindItem(console.ChooseItem());

                        if (itemToRemove != null)
                        {
                            repositoryItem.RemoveItem(itemToRemove);
                        }
                        else
                        {
                            console.SearchFailed();
                        }
                        break;
                    case 5:
                        // 5. Display Pending Items
                        List<ToDoItem> pendingItems = repositoryItem.PrintStatus(Flag.Pending);
                        if (pendingItems.Count != 0)
                        {
                            console.PrintItems(pendingItems);
                        }
                        else
                            console.SearchFailed();
                        break;
                    case 6:
                        // 6. Display Done Items
                        List<ToDoItem> doneItems = repositoryItem.PrintStatus(Flag.Done);
                        if (doneItems.Count != 0)
                        {
                            console.PrintItems(doneItems);
                        }
                        else
                            console.SearchFailed();
                        break;
                    case 7:
                        // 7. To Quit
                        done = true;
                        break;
                    default:
                        // Not sure how we got here
                        console.InvalidInput();
                        break;
                }        
            }
        }
    }
}
