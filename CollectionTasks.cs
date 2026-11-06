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
    }
}