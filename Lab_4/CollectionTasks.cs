using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    internal class CollectionTasks
    {
        private static T ReadValue<T>(Checked c, string prompt)
        {
            T result = default(T);
            string input = "";
            while (true)
            {
                input = c.ReadString(prompt);
                try
                {
                    result = (T)Convert.ChangeType(
                        input, typeof(T));
                    return result;
                }
                catch
                {
                    Console.WriteLine("Ошибка: неверный тип.");
                }
            }
        }

        private static List<T> ReadListTask1<T>(Checked c)
        {
            List<T> list = new List<T>();
            int count = 0;
            int index = 0;

            count = c.ReadIntInRange(
                "Введите количество элементов: ", 1, 100);

            for (index = 0; index < count; index++)
            {
                list.Add(ReadValue<T>(c, 
                    $"Элемент {index + 1}: "));
            }
            return list;
        }

        private static List<T> FilterUniqueTask1<T>(
            List<T> list)
        {
            List<T> result = new List<T>();
            HashSet<T> seen = new HashSet<T>();
            int index = 0;

            for (index = 0; index < list.Count; index++)
            {
                if (seen.Add(list[index]))
                {
                    result.Add(list[index]);
                }
            }
            return result;
        }

        public static void Task1<T>(Checked c)
        {
            List<T> original = new List<T>();
            List<T> unique = new List<T>();
            int index = 0;

            original = ReadListTask1<T>(c);

            Console.WriteLine("Исходный список:");
            for (index = 0; index < original.Count; index++)
            {
                Console.Write(original[index] + " ");
            }
            Console.WriteLine();

            unique = FilterUniqueTask1<T>(original);

            Console.WriteLine("Список без повторений:");
            for (index = 0; index < unique.Count; index++)
            {
                Console.Write(unique[index] + " ");
            }
            Console.WriteLine();
        }

        private static LinkedList<T> ReadLinkedListTask2<T>(
            Checked c)
        {
            LinkedList<T> list = new LinkedList<T>();
            int count = 0;
            int index = 0;

            count = c.ReadIntInRange(
                "Введите количество элементов: ", 1, 100);

            for (index = 0; index < count; index++)
            {
                list.AddLast(ReadValue<T>(c, 
                    $"Элемент {index + 1}: "));
            }
            return list;
        }

        private static void SwapNeighborsTask2<T>(
            LinkedList<T> list, T target)
        {
            LinkedListNode<T> current = null;
            T temp = default(T);

            current = list.First;
            while (current != null)
            {
                if (current.Value.Equals(target))
                {
                    if (current.Previous != null && 
                        current.Next != null)
                    {
                        if (!current.Previous.Value.Equals(
                            current.Next.Value))
                        {
                            temp = current.Previous.Value;
                            current.Previous.Value = 
                                current.Next.Value;
                            current.Next.Value = temp;
                        }
                    }
                }
                current = current.Next;
            }
        }

        public static void Task2<T>(Checked c)
        {
            LinkedList<T> list = new LinkedList<T>();
            LinkedListNode<T> current = null;
            T target = default(T);

            list = ReadLinkedListTask2<T>(c);
            target = ReadValue<T>(c, "Введите элемент E: ");

            SwapNeighborsTask2<T>(list, target);

            Console.WriteLine("Список после изменений:");
            current = list.First;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        private static void ReadLanguagesTask3(Checked c, 
            HashSet<string> all, List<HashSet<string>> emps)
        {
            int langCount = 0;
            int empCount = 0;
            int index = 0;
            int langIndex = 0;
            int empLangCount = 0;
            string lang = "";
            HashSet<string> current = null;

            langCount = c.ReadIntInRange(
                "Введите количество языков: ", 1, 50);
                
            Console.WriteLine("Введите языки:");
            for (index = 0; index < langCount; index++)
            {
                while (true)
                {
                    lang = c.ReadString(
                        $"Язык {index + 1}: ").ToLowerInvariant();
                    if (all.Add(lang)) break;
                    Console.WriteLine("Такой язык уже есть.");
                }
            }

            empCount = c.ReadIntInRange(
                "Введите количество сотрудников: ", 1, 20);

            for (index = 0; index < empCount; index++)
            {
                current = new HashSet<string>();
                Console.WriteLine($"\nСотрудник {index + 1}:");
                
                empLangCount = c.ReadIntInRange(
                    "Сколько языков знает? ", 0, all.Count);

                for (langIndex = 0; langIndex < empLangCount; 
                     langIndex++)
                {
                    while (true)
                    {
                        lang = c.ReadString(
                            $"Язык {langIndex + 1}: ")
                            .ToLowerInvariant();

                        if (!all.Contains(lang)) continue;
                        if (!current.Add(lang)) continue;
                        break;
                    }
                }
                emps.Add(current);
            }
        }

        private static void CalculateStatsTask3(
            List<HashSet<string>> emps, HashSet<string> all, 
            HashSet<string> everyone, HashSet<string> anyone, 
            HashSet<string> noOne)
        {
            int index = 0;

            everyone.UnionWith(emps[0]);
            anyone.UnionWith(emps[0]);

            for (index = 1; index < emps.Count; index++)
            {
                everyone.IntersectWith(emps[index]);
                anyone.UnionWith(emps[index]);
            }

            noOne.UnionWith(all);
            noOne.ExceptWith(anyone);
        }

        public static void Task3(Checked c)
        {
            HashSet<string> all = new HashSet<string>();
            List<HashSet<string>> emps = 
                new List<HashSet<string>>();
            HashSet<string> everyone = new HashSet<string>();
            HashSet<string> anyone = new HashSet<string>();
            HashSet<string> noOne = new HashSet<string>();
            List<string> result = new List<string>();
            int index = 0;

            ReadLanguagesTask3(c, all, emps);
            CalculateStatsTask3(emps, all, everyone, anyone, noOne);

            Console.WriteLine("\nЗнают все:");
            result.AddRange(everyone);
            for (index = 0; index < result.Count; index++)
            {
                Console.Write(result[index] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Знает хотя бы один:");
            result.Clear();
            result.AddRange(anyone);
            for (index = 0; index < result.Count; index++)
            {
                Console.Write(result[index] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Не знает никто:");
            result.Clear();
            result.AddRange(noOne);
            for (index = 0; index < result.Count; index++)
            {
                Console.Write(result[index] + " ");
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

        private static HashSet<char> GetFirstLettersTask4(
            string fileName)
        {
            HashSet<char> letters = new HashSet<char>();
            string line = "";
            int i = 0;

            using (StreamReader reader = 
                new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    for (i = 0; i < line.Length; i++)
                    {
                        if (char.IsLetter(line[i]))
                        {
                            if (i == 0 || 
                                !char.IsLetter(line[i - 1]))
                            {
                                letters.Add(
                                    char.ToLowerInvariant(line[i]));
                            }
                        }
                    }
                }
            }
            return letters;
        }

        public static void Task4(Checked c)
        {
            string fileName = "task4_text.txt";
            HashSet<char> firstLetters = new HashSet<char>();
            List<char> sorted = new List<char>();
            int index = 0;

            FillFileTask4(fileName, c);

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            firstLetters = GetFirstLettersTask4(fileName);
            sorted.AddRange(firstLetters);
            sorted.Sort();

            Console.WriteLine("Буквы, с которых " +
                              "начинаются слова:");
                              
            for (index = 0; index < sorted.Count; index++)
            {
                Console.Write(sorted[index] + " ");
            }
            Console.WriteLine();
        }

        private static void FillFileTask5(string fileName, 
            Checked c)
        {
            int count = 0;
            int index = 0;
            string line = "";
            string[] parts = new string[0];
            int school = 0;
            int score = 0;

            count = c.ReadIntInRange(
                "Введите кол-во учеников: ", 5, 50);

            using (StreamWriter writer = 
                new StreamWriter(fileName, false))
            {
                for (index = 0; index < count; index++)
                {
                    Console.WriteLine($"Ученик {index + 1} " +
                        "(Фамилия Имя Школа Балл):");
                        
                    while (true)
                    {
                        line = c.ReadString(">> ");
                        parts = line.Split(
                            new char[] { ' ' }, 
                            StringSplitOptions
                                .RemoveEmptyEntries);

                        if (parts.Length == 4)
                        {
                            if (int.TryParse(parts[2], out school)
                                && int.TryParse(parts[3], 
                                out score))
                            {
                                if (school >= 1 && 
                                    school <= 100 && 
                                    score >= 1 && 
                                    score <= 100) break;
                            }
                        }
                        Console.WriteLine("Ошибка! Введите: " +
                            "Фамилия Имя Школа(1-100) Балл(1-100)");
                    }
                    writer.WriteLine(line);
                }
            }
        }

        public static void Task5(Checked c)
        {
            string fileName = "task5_text.txt";
            int maxScore = -1;
            int maxCount = 0;
            string bestName1 = "";
            string bestName2 = "";

            int secondMaxScore = -1;
            int secondCount = 0;
            string secondName1 = "";

            string line = "";
            string[] parts = new string[0];
            int school = 0;
            int score = 0;
            string currentName = "";

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
                        school = int.Parse(parts[2]);
                        
                        if (school == 50)
                        {
                            score = int.Parse(parts[3]);
                            currentName = parts[0] + " " + 
                                          parts[1];

                            if (score > maxScore)
                            {
                                secondMaxScore = maxScore;
                                secondCount = maxCount;
                                secondName1 = bestName1;

                                maxScore = score;
                                maxCount = 1;
                                bestName1 = currentName;
                                bestName2 = "";
                            }
                            else if (score == maxScore)
                            {
                                maxCount++;
                                if (maxCount == 2)
                                {
                                    bestName2 = currentName;
                                }
                            }
                            else if (score > secondMaxScore)
                            {
                                secondMaxScore = score;
                                secondCount = 1;
                                secondName1 = currentName;
                            }
                            else if (score == secondMaxScore)
                            {
                                secondCount++;
                            }
                        }
                    }
                }
            }

            if (maxCount == 0)
            {
                Console.WriteLine("В школе 50 нет учеников.");
                return;
            }

            if (maxCount >= 3)
            {
                Console.WriteLine("Более двух учеников " +
                                  "набрали максимум.");
                Console.WriteLine("Количество лучших: " + 
                                  maxCount);
            }
            else if (maxCount == 2)
            {
                Console.WriteLine("Два ученика набрали " +
                                  "максимум:");
                Console.WriteLine(bestName1);
                Console.WriteLine(bestName2);
            }
            else
            {
                if (secondCount == 1)
                {
                    Console.WriteLine("Лучший:");
                    Console.WriteLine(bestName1);
                    Console.WriteLine("Второй:");
                    Console.WriteLine(secondName1);
                }
                else
                {
                    Console.WriteLine("Один лучший, " +
                                      "остальные равны.");
                    Console.WriteLine("Лучший:");
                    Console.WriteLine(bestName1);
                }
            }
        }
    }
}