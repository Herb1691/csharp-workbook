using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> toDoList = new Dictionary<string, List<string>>();
            bool done = false;

            Console.WriteLine("To Do List:");

            while (!done)
            {
                bool toDo = false;
                List<string> tempList = new List<string>();
                string taskInput = string.Empty;
                string dateInput = string.Empty;
                string priorityInput = string.Empty;

                Console.WriteLine("\n\nPlease enter your task.");
                Console.Write("enter 'Q' to quit or 'P' to display your list: ");
                taskInput = Console.ReadLine();

                switch (taskInput.ToUpper())
                {
                    case "Q":
                        if (toDoList.Count > 0)
                            PrintToDo(toDoList);
                        else
                            Console.WriteLine("To Do List is still empty.");
                        toDo = true;
                        done = true;
                        break;
                    case "P":
                        if (toDoList.Count > 0)
                            PrintToDo(toDoList);
                        else
                            Console.WriteLine("To Do List is still empty.");
                        toDo = true;
                        break;
                }

                if (!toDo)
                {
                    Console.WriteLine("What date would you like to set for this task?");
                    Console.WriteLine("Please enter your date in the following format");
                    Console.Write("mm/dd/yyyy: ");
                    dateInput = Console.ReadLine();

                    Console.WriteLine("What priority is this task?");
                    Console.Write("Normal, High, or Low: ");
                    priorityInput = Console.ReadLine();

                    tempList.Add(dateInput);
                    tempList.Add(priorityInput);

                    toDoList.Add(taskInput, tempList);
                }
            }
        }

        static void PrintToDo(Dictionary<string, List<string>> toDo)
        {
            foreach (var key in toDo.Keys)
            {
                Console.Write("\n{0}  |  ", key);

                foreach (var item in toDo[key])
                {
                    Console.Write("{0}  |  ", item);
                }
            }
        }
    }
}
