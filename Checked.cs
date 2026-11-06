using System;

namespace ConsoleApp1
{
    internal class Checked
    {
        public int ReadInt(string prompt)
        {
            string userInput = "";
            int result = 0;

            while (true)
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                
                if (int.TryParse(userInput, out result))
                {
                    return result;
                }
                
                Console.WriteLine("Ошибка: введите число.");
            }
        }

        public int ReadIntInRange(string prompt, int minValue, 
            int maxValue)
        {
            int result = 0;

            while (true)
            {
                result = ReadInt(prompt); 
                
                if (result >= minValue && result <= maxValue)
                {
                    return result;
                }
                
                Console.WriteLine($"Ошибка: введите от " +
                                  $"{minValue} до {maxValue}.");
            }
        }

        public double ReadDouble(string prompt)
        {
            string userInput = "";
            double result = 0.0;

            while (true)
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                
                if (double.TryParse(userInput, out result))
                {
                    return result;
                }
                
                Console.WriteLine("Ошибка: введите число.");
            }
        }

        public string ReadString(string prompt)
        {
            string userInput = "";

            while (true)
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput;
                }
                
                Console.WriteLine("Ошибка: пустая строка.");
            }
        }
    }
}