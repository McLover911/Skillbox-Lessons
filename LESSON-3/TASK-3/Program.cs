using System;

namespace TASK_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            int counter = 1;

            Console.WriteLine("Введите целое число:");

            num = int.Parse(Console.ReadLine());

            while (counter != num)
            {
                if ((num % counter != 0) || (counter == 1))
                {
                    counter++;
                    continue;
                }
                else
                {
                    Console.WriteLine("Число не является простым");
                    return;
                }
            }

            Console.WriteLine("Число является простым");
        }
    }
}
