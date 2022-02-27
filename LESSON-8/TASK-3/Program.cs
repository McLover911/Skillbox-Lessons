using System;
using System.Collections.Generic;

namespace TASK_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;

            HashSet<int> collection = new HashSet<int>();

            while (true)
            {
                Console.WriteLine("Введите целое число:");
                num = int.Parse(Console.ReadLine());

                if (!collection.Contains(num))
                {
                    collection.Add(num);
                    Console.WriteLine("Число успешно сохранено");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Введённое число уже существует в коллекции");
                    Console.WriteLine();
                }
            }
        }
    }
}
