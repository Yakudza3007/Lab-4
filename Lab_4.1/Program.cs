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
            byte hours1 = 0;
            byte minutes1 = 0;
            byte hours2 = 0;
            byte minutes2 = 0;
            Time time1 = null;
            Time time2 = null;
            Time result = null;
            byte hoursResult = 0;
            bool boolResult = false;
            uint addMinutes = 0;

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
                        hours1 = (byte)c.ReadIntInRange(
                            "Часы 1: ", 0, 23);
                        minutes1 = (byte)c.ReadIntInRange(
                            "Минуты 1: ", 0, 59);
                        hours2 = (byte)c.ReadIntInRange(
                            "Часы 2: ", 0, 23);
                        minutes2 = (byte)c.ReadIntInRange(
                            "Минуты 2: ", 0, 59);

                        time1 = new Time(hours1, minutes1);
                        time2 = new Time(hours2, minutes2);
                        result = time1 - time2;

                        Console.WriteLine($"{time1} - " +
                                          $"{time2} = " +
                                          $"{result}");
                        break;
                    case "2":
                        hours1 = (byte)c.ReadIntInRange(
                            "Часы 1: ", 0, 23);
                        minutes1 = (byte)c.ReadIntInRange(
                            "Минуты 1: ", 0, 59);
                        time1 = new Time(hours1, minutes1);

                        hours2 = (byte)c.ReadIntInRange(
                            "Часы 2: ", 0, 23);
                        minutes2 = (byte)c.ReadIntInRange(
                            "Минуты 2: ", 0, 59);
                        time2 = new Time(hours2, minutes2);

                        Console.WriteLine("\nОперация --:");
                        result = --time1;
                        Console.WriteLine($"{result}");

                        Console.WriteLine("\nК byte:");
                        hoursResult = (byte)time2;
                        Console.WriteLine(
                            $"Часы: {hoursResult}");

                        Console.WriteLine("\nК bool:");
                        boolResult = time2;
                        Console.WriteLine(
                            $"Не ноль: {boolResult}");

                        addMinutes = (uint)c.ReadIntInRange(
                            "Минут добавить: ", 1, 1000);

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
                        break;
                    default:
                        Console.WriteLine("Нет пункта.");
                        break;
                }
            }
        }
    }
}