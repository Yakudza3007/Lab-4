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
                Console.WriteLine("\n0 - Выход");
                Console.WriteLine("1 - Задание 6 (Time)");
                Console.WriteLine("2 - Задание 7 (Перегрузка)");
                Console.Write("Введите номер: ");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "0":
                        isRunning = false;
                        break;
                    case "1":
                        TestTask6(c);
                        break;
                    case "2":
                        TestTask7(c);
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта.");
                        break;
                }
            }
        }

        private static Time ReadTime(Checked c, string name)
        {
            byte hours = 0;
            byte minutes = 0;

            Console.WriteLine($"\nВвод времени {name}:");
            hours = (byte)c.ReadIntInRange("Часы: ", 0, 23);
            minutes = (byte)c.ReadIntInRange("Минуты: ", 0, 59);

            return new Time(hours, minutes);
        }

        private static void TestTask6(Checked c)
        {
            Time time1 = null;
            Time time2 = null;
            Time result = null;

            time1 = ReadTime(c, "1");
            time2 = ReadTime(c, "2");
            result = time1.Subtract(time2);

            Console.WriteLine($"\n{time1} - {time2} = {result}");
        }

        private static void TestTask7(Checked c)
        {
            Time time1 = null;
            Time time2 = null;
            Time result = null;
            byte hoursResult = 0;
            bool boolResult = false;
            uint addMinutes = 0;

            time1 = ReadTime(c, "1");
            time2 = ReadTime(c, "2");

            Console.WriteLine("\nУнарная операция --:");
            result = --time1;
            Console.WriteLine($"{result}");

            Console.WriteLine("\nЯвное приведение к byte:");
            hoursResult = (byte)time2;
            Console.WriteLine($"Часы: {hoursResult}");

            Console.WriteLine("\nНеявное приведение к bool:");
            boolResult = time2;
            Console.WriteLine($"Не ноль: {boolResult}");

            addMinutes = (uint)c.ReadIntInRange(
                "\nСколько минут добавить? ", 1, 1000);

            Console.WriteLine("\nTime + uint:");
            result = time1 + addMinutes;
            Console.WriteLine($"{time1} + " +
                              $"{addMinutes} = {result}");

            Console.WriteLine("\nuint + Time:");
            result = addMinutes + time2;
            Console.WriteLine($"{addMinutes} + " +
                              $"{time2} = {result}");

            Console.WriteLine("\nTime + Time:");
            result = time1 + time2;
            Console.WriteLine($"{time1} + " +
                              $"{time2} = {result}");
        }
    }
}
