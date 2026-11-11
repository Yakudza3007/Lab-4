using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    internal class CollectionTasks
    {
        private struct Student
        {
            private string _surname;
            private string _name;
            private int _school;
            private int _score;

            public Student(string surname, string name, 
                int school, int score)
            {
                _surname = surname;
                _name = name;
                _school = school;
                _score = score;
            }

            public string Surname { get { return _surname; } }
            public string Name { get { return _name; } }
            public int School { get { return _school; } }
            public int Score { get { return _score; } }
        }

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
                            tempValue = 
                                currentNode.Previous.Value;
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
            HashSet<string> knownByEveryone = 
                new HashSet<string>();
            HashSet<string> knownByAnyone = 
                new HashSet<string>();
            HashSet<string> knownByNoOne = 
                new HashSet<string>();
            List<HashSet<string>> employees = 
                new List<HashSet<string>>();
            List<string> resultList = new List<string>();
            HashSet<string> currentLangs = 
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
                while (true)
                {
                    currentLang = c.ReadString(
                        $"Язык {index + 1}: ").ToLowerInvariant();

                    if (allLanguages.Add(currentLang))
                    {
                        break;
                    }
                    Console.WriteLine("Такой язык уже есть.");
                }
            }

            employeeCount = c.ReadIntInRange(
                "Введите количество сотрудников: ", 1, 20);

            for (index = 0; index < employeeCount; index++)
            {
                currentLangs = new HashSet<string>();
                Console.WriteLine($"\nСотрудник {index + 1}:");
                
                empLangCount = c.ReadIntInRange(
                    "Сколько языков знает? ", 0, 
                    allLanguages.Count);

                for (langIndex = 0; langIndex < empLangCount; 
                     langIndex++)
                {
                    while (true)
                    {
                        currentLang = c.ReadString(
                            $"Язык {langIndex + 1}: ")
                            .ToLowerInvariant();

                        if (!allLanguages.Contains(currentLang))
                        {
                            Console.WriteLine("Нет в списке.");
                            continue;
                        }

                        if (!currentLangs.Add(currentLang))
                        {
                            Console.WriteLine("Уже добавлен.");
                            continue;
                        }
                        break;
                    }
                }
                employees.Add(currentLangs);
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

            Console.WriteLine("\nЗнают все:");
            resultList.AddRange(knownByEveryone);
            for (index = 0; index < resultList.Count; index++)
            {
                Console.Write(resultList[index] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Знает хотя бы один:");
            resultList.Clear();
            resultList.AddRange(knownByAnyone);
            for (index = 0; index < resultList.Count; index++)
            {
                Console.Write(resultList[index] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Не знает никто:");
            resultList.Clear();
            resultList.AddRange(knownByNoOne);
            for (index = 0; index < resultList.Count; index++)
            {
                Console.Write(resultList[index] + " ");
            }
            Console.WriteLine();
        }
                
        private static void FillFileTask4(string fileName, 
            Checked c)
        {
            int lineCount = 0;
            int index = 0;
            string line = "";

            lineCount = c.ReadIntInRange(
                "Сколько строк текста ввести? ", 1, 10);
    
            using (StreamWriter writer = 
                new StreamWriter(fileName, false))
            {
                for (index = 0; index < lineCount; index++)
                {
                    line = c.ReadString(
                        $"Строка {index + 1}: ");
                    writer.WriteLine(line);
                }
            }
        }

        public static void Task4(Checked c)
        {
            string fileName = "task4_text.txt";
            HashSet<char> firstLetters = new HashSet<char>();
            List<char> sortedLetters = new List<char>();
            string line = "";
            int index = 0;
            int charIndex = 0;

            FillFileTask4(fileName, c);

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            using (StreamReader reader = 
                new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    for (charIndex = 0; 
                         charIndex < line.Length; 
                         charIndex++)
                    {
                        if (char.IsLetter(line[charIndex]))
                        {
                            if (charIndex == 0 || 
                                !char.IsLetter(line[charIndex - 1]))
                            {
                                firstLetters.Add(
                                    char.ToLowerInvariant(
                                        line[charIndex]));
                            }
                        }
                    }
                }
            }

            sortedLetters.AddRange(firstLetters);
            sortedLetters.Sort();

            Console.WriteLine("Буквы, с которых " +
                              "начинаются слова:");
                              
            for (index = 0; 
                 index < sortedLetters.Count; 
                 index++)
            {
                Console.Write(sortedLetters[index] + " ");
            }
            Console.WriteLine();
        }

        private static void FillFileTask5(string fileName, 
            Checked c)
        {
            int studentCount = 0;
            int index = 0;
            string line = "";
            string[] parts = new string[0];
            int school = 0;
            int score = 0;

            studentCount = c.ReadIntInRange(
                "Введите кол-во учеников: ", 5, 50);

            using (StreamWriter writer = 
                new StreamWriter(fileName, false))
            {
                for (index = 0; index < studentCount; index++)
                {
                    Console.WriteLine($"Ученик {index + 1} " +
                        "(введите: Фамилия Имя Школа Балл):");
                        
                    while (true)
                    {
                        line = c.ReadString(">> ");
                        parts = line.Split(
                            new char[] { ' ' }, 
                            StringSplitOptions
                                .RemoveEmptyEntries);

                        if (parts.Length == 4)
                        {
                            if (int.TryParse(parts[2], 
                                out school) && 
                                int.TryParse(parts[3], 
                                out score))
                            {
                                if (school >= 1 && 
                                    school <= 100 && 
                                    score >= 1 && 
                                    score <= 100)
                                {
                                    break;
                                }
                            }
                        }
                        Console.WriteLine(
                            "Ошибка! Введите 4 значения: " +
                            "Фамилия Имя Школа(1-100) Балл(1-100)");
                    }
                    
                    writer.WriteLine(line);
                }
            }
        }

        public static void Task5(Checked c)
        {
            string fileName = "task5_text.txt";
            List<Student> school50 = new List<Student>();
            string line = "";
            string[] parts = new string[0];
            int index = 0;
            int maxScore = -1;
            int maxScoreCount = 0;
            int secondMaxScore = -1;
            int secondMaxCount = 0;
            Student bestStudent = default(Student);
            Student secondStudent = default(Student);
            bool foundBest = false;
            bool foundSecond = false;

            FillFileTask5(fileName, c);

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            using (StreamReader reader = 
                new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(
                        new char[] { ' ' }, 
                        StringSplitOptions
                            .RemoveEmptyEntries);
                            
                    if (parts.Length == 4)
                    {
                        if (int.Parse(parts[2]) == 50)
                        {
                            school50.Add(new Student(
                                parts[0], parts[1], 50, 
                                int.Parse(parts[3])));
                        }
                    }
                }
            }

            if (school50.Count == 0)
            {
                Console.WriteLine("В школе 50 нет учеников.");
                return;
            }

            for (index = 0; index < school50.Count; index++)
            {
                if (school50[index].Score > maxScore)
                {
                    maxScore = school50[index].Score;
                }
            }

            for (index = 0; index < school50.Count; index++)
            {
                if (school50[index].Score == maxScore)
                {
                    maxScoreCount++;
                    if (!foundBest)
                    {
                        bestStudent = school50[index];
                        foundBest = true;
                    }
                }
            }

            if (maxScoreCount >= 3)
            {
                Console.WriteLine("Более двух учеников набрали " +
                                  "максимальный балл.");
                Console.WriteLine("Количество лучших учеников: " + 
                                  maxScoreCount);
            }
            else if (maxScoreCount == 2)
            {
                Console.WriteLine("Два ученика набрали " +
                                  "максимальный балл:");
                                  
                for (index = 0; 
                     index < school50.Count; 
                     index++)
                {
                    if (school50[index].Score == maxScore)
                    {
                        Console.WriteLine(
                            $"{school50[index].Surname} " +
                            $"{school50[index].Name}");
                    }
                }
            }
            else
            {
                for (index = 0; 
                     index < school50.Count; 
                     index++)
                {
                    if (school50[index].Score < maxScore 
                        && school50[index].Score > 
                        secondMaxScore)
                    {
                        secondMaxScore = 
                            school50[index].Score;
                    }
                }

                for (index = 0; 
                     index < school50.Count; 
                     index++)
                {
                    if (school50[index].Score == 
                        secondMaxScore)
                    {
                        secondMaxCount++;
                        if (!foundSecond)
                        {
                            secondStudent = 
                                school50[index];
                            foundSecond = true;
                        }
                    }
                }

                if (secondMaxCount == 1 && foundSecond)
                {
                    Console.WriteLine("Лучший ученик:");
                    Console.WriteLine(
                        $"{bestStudent.Surname} " +
                        $"{bestStudent.Name}");
                        
                    Console.WriteLine("Второй по успеваемости:");
                    Console.WriteLine(
                        $"{secondStudent.Surname} " +
                        $"{secondStudent.Name}");
                }
                else
                {
                    Console.WriteLine("Наибольший балл набрал " +
                                      "только один ученик, " +
                                      "а следующий балл набрали " +
                                      "несколько человек.");
                    Console.WriteLine("Лучший ученик:");
                    Console.WriteLine(
                        $"{bestStudent.Surname} " +
                        $"{bestStudent.Name}");
                }
            }
        }
    }
}