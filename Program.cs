using System;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Checked c = new Checked();
            bool isRunning = true;
            string userChoice = "";

            while (isRunning)
            {
                Console.WriteLine("\n0 - Выход из программы");
                Console.WriteLine("1 - List");
                Console.WriteLine("2 - LinkedList");
                Console.WriteLine("3 - HashSet");
                
                Console.Write("Введите номер задания: ");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "0":
                        isRunning = false;
                        break;
                    case "1":
                        CollectionTasks.Task1(c);
                        break;
                    case "2":
                        CollectionTasks.Task2(c);
                        break;
                    
                    case "3":
                        CollectionTasks.Task3(c);
                        break;
                    
                    default:
                        Console.WriteLine("Такого пункта нет.");
                        break;
                }
            }
        }
    }
}