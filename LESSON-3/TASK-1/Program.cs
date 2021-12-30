using System;

namespace TASK_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;

            Console.WriteLine("Введите целое число:");

            num = int.Parse(Console.ReadLine());

            if (num % 2 == 0)
            {
                Console.WriteLine("Данное число чётное");
            }
            else
            {
                Console.WriteLine("Данное число нечётное");
            }
        }
    }
}
