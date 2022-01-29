using System;
using System.Threading;

namespace TASK_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            int hiddenNum;
            int enteredNum;
            string entered;

            Random random = new Random();

            Console.WriteLine("Введите максимальное целое число диапазона:");

            num = int.Parse(Console.ReadLine());
            hiddenNum = random.Next(num);

            Console.WriteLine($"Введите загаданное число от 0 до {num}:");

            while (true)
            {
                entered = Console.ReadLine();

                if (!string.IsNullOrEmpty(entered))
                {
                    enteredNum = int.Parse(entered);

                    if (enteredNum < hiddenNum)
                    {
                        Console.WriteLine("Введённое число меньше загаданного. Повторите попытку:");
                        continue;
                    }
                    else if (enteredNum > hiddenNum)
                    {
                        Console.WriteLine("Введённое число больше загаданного. Повторите попытку:");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Вы отгадали число!");
                        break;
                    }
                }    
                else
                {
                    Console.WriteLine($"Завершение программы. Загаданное число: {hiddenNum}");
                    break;
                }
                
            }
        }
    }
}
