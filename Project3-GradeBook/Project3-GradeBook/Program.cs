using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> gradeBook = new Dictionary<string, string>();
            bool done = false;
            string name = string.Empty;


            Console.WriteLine("Welcome to the GradeBook application.");
            Console.WriteLine("Here you'll enter the grades for your students.");

            // Loop
            while(!done)
            {
                string studentGrades = string.Empty;

                bool isDone = false;

                Console.WriteLine("\nPlease enter the first and last name of the student.\n");
                Console.Write("Or type Exit to quit: ");
                name = Console.ReadLine();

                if (name.ToUpper() != "EXIT")
                {
                    Console.WriteLine("\nPlease enter the grade for {0}", name);

                    while(!isDone)
                    {
                        string temp = string.Empty;
                        Console.Write("\nEnter Grade (or type Done if you're finished): ");
                        temp = Console.ReadLine();

                        if (temp.ToUpper() != "DONE")
                        {
                            studentGrades = studentGrades + temp + " ";
                        }
                        else
                        {
                            isDone = true;
                        }
                    }

                    if (studentGrades.Length > 0)
                    {
                        studentGrades = studentGrades.Trim();
                    }
                    else
                    {
                        Console.WriteLine("Do you want to quit?");
                        Console.Write("Yes or No:");
                        if (Console.ReadLine().ToUpper() == "YES")
                        {
                            done = true;
                            Console.WriteLine("Hit 'Enter' to quit...");
                            Console.ReadLine();
                            break;
                        }
                        else
                            break;
                    }

                    if (gradeBook.Count == 0)
                    {
                        gradeBook = EnterGrades(name, studentGrades);
                    }
                    else
                    {
                        gradeBook.Add(name, studentGrades);
                    }
                }
                else
                {
                    done = true;
                    PrintResults(gradeBook);
                    Console.WriteLine("Hit 'Enter' to quit...");
                    Console.ReadLine();
                    break;
                }

                string printGrades = string.Empty;
                Console.WriteLine("\n\n");


                studentGrades = string.Empty;
            }
        }

        static Dictionary<string, string> EnterGrades(string name, string grades)
        {
            Dictionary<string, string> student = new Dictionary<string, string>();

            student.Add(name, grades);

            return student;
        }

        static void PrintResults(Dictionary<string, string> gradeBooks)
        {
            foreach (var student in gradeBooks.Keys)
            {
                int lowestGrade = 100;
                int highestGrade = 0;
                double averageGrade = 0.0;

                int avgCount = 0;
                string[] separateGrades;
                separateGrades = gradeBooks[student].Split(' ');
                List<int> parsedGrades = new List<int>();

                for (int count = 0; count < separateGrades.Count(); count++)
                {
                    parsedGrades.Add(int.Parse(separateGrades[count]));
                }

                foreach (int lowGrade in parsedGrades)
                {
                    if (lowestGrade > lowGrade)
                        lowestGrade = lowGrade;
                }
                Console.WriteLine("{0}'s lowest grade is: {1}", student, lowestGrade);

                foreach (int highGrade in parsedGrades)
                {
                    if (highestGrade < highGrade)
                        highestGrade = highGrade;
                }
                Console.WriteLine("{0}'s highest grade is: {1}", student, highestGrade);

                foreach (int avgGrade in parsedGrades)
                {
                    averageGrade += avgGrade;
                    avgCount++;
                }
                Console.WriteLine("{0}'s average grade is: {1}", student, averageGrade/avgCount);

            }
        }
    }
}
