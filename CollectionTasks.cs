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
    }
}