using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class CollectionTasks
    {
        public static void Task1(Checked c)
        {
            List<int> numberList = new List<int>();
            List<int> uniqueList = new List<int>();
            HashSet<int> seenNumbers = new HashSet<int>();
            int elementsCount = 0;
            int index = 0;
            int currentNumber = 0;

            elementsCount = c.ReadIntInRange(
                "Введите количество элементов: ", 1, 100);

            for (index = 0; index < elementsCount; index++)
            {
                currentNumber = c.ReadInt(
                    $"Введите элемент {index + 1}: ");
                numberList.Add(currentNumber);
            }

            Console.WriteLine("Исходный список:");
            for (index = 0; index < numberList.Count; index++)
            {
                Console.Write(numberList[index] + " ");
            }
            Console.WriteLine();

            for (index = 0; index < numberList.Count; index++)
            {
                if (seenNumbers.Add(numberList[index]))
                {
                    uniqueList.Add(numberList[index]);
                }
            }

            Console.WriteLine("Список без повторений:");
            for (index = 0; index < uniqueList.Count; index++)
            {
                Console.Write(uniqueList[index] + " ");
            }
            Console.WriteLine();
        }
        
        public static void Task2(Checked c)
        {
            LinkedList<int> numbersList = new LinkedList<int>();
            LinkedListNode<int> currentNode = null;
            int elementsCount = 0;
            int index = 0;
            int currentNumber = 0;
            int targetElement = 0;
            int tempValue = 0;

            elementsCount = c.ReadIntInRange(
                "Введите количество элементов: ", 1, 100);

            for (index = 0; index < elementsCount; index++)
            {
                currentNumber = c.ReadInt(
                    $"Введите элемент {index + 1}: ");
                numbersList.AddLast(currentNumber);
            }

            targetElement = c.ReadInt("Введите элемент E: ");

            currentNode = numbersList.First;
            while (currentNode != null)
            {
                if (currentNode.Value == targetElement)
                {
                    if (currentNode.Previous != null && 
                        currentNode.Next != null)
                    {
                        if (currentNode.Previous.Value != 
                            currentNode.Next.Value)
                        {
                            tempValue = currentNode.Previous.Value;
                            currentNode.Previous.Value = 
                                currentNode.Next.Value;
                            currentNode.Next.Value = tempValue;
                        }
                    }
                }
                currentNode = currentNode.Next;
            }

            Console.WriteLine("Список после изменений:");
            currentNode = numbersList.First;
            while (currentNode != null)
            {
                Console.Write(currentNode.Value + " ");
                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }
        
                public static void Task3(Checked c)
        {
            HashSet<string> allLanguages = new HashSet<string>();
            HashSet<string> knownByEveryone = new HashSet<string>();
            HashSet<string> knownByAnyone = new HashSet<string>();
            HashSet<string> knownByNoOne = new HashSet<string>();
            List<HashSet<string>> employees = 
                new List<HashSet<string>>();
            HashSet<string> currentEmployeeLangs = 
                new HashSet<string>();
            int langCount = 0;
            int employeeCount = 0;
            int index = 0;
            int langIndex = 0;
            int empLangCount = 0;
            string currentLang = "";

            langCount = c.ReadIntInRange(
                "Введите количество языков: ", 1, 50);
            
            Console.WriteLine("Введите языки:");
            for (index = 0; index < langCount; index++)
            {
                currentLang = c.ReadString(
                    $"Язык {index + 1}: ").ToLower();
                allLanguages.Add(currentLang);
            }

            employeeCount = c.ReadIntInRange(
                "Введите количество сотрудников: ", 1, 20);

            for (index = 0; index < employeeCount; index++)
            {
                empLangCount = c.ReadIntInRange(
                    $"Сотрудник {index + 1}, сколько знает: ", 
                    0, langCount);
                
                currentEmployeeLangs = new HashSet<string>();
                for (langIndex = 0; langIndex < empLangCount; 
                     langIndex++)
                {
                    currentLang = c.ReadString(
                        $"  Язык {langIndex + 1}: ").ToLower();
                    currentEmployeeLangs.Add(currentLang);
                }
                employees.Add(currentEmployeeLangs);
            }

            knownByEveryone.UnionWith(employees[0]);
            knownByAnyone.UnionWith(employees[0]);
            
            for (index = 1; index < employeeCount; index++)
            {
                knownByEveryone.IntersectWith(employees[index]);
                knownByAnyone.UnionWith(employees[index]);
            }

            knownByNoOne.UnionWith(allLanguages);
            knownByNoOne.ExceptWith(knownByAnyone);

            Console.WriteLine("\nЗнают все сотрудники:");
            foreach (string lang in knownByEveryone)
            {
                Console.Write(lang + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Знает хотя бы один:");
            foreach (string lang in knownByAnyone)
            {
                Console.Write(lang + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Не знает никто:");
            foreach (string lang in knownByNoOne)
            {
                Console.Write(lang + " ");
            }
            Console.WriteLine();
        }
    }
}