using System;

namespace TASK_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            int arrayLength;
            int min = int.MaxValue;

            Console.WriteLine("Ведите длину последовательности:");

            arrayLength = int.Parse(Console.ReadLine());

            array = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент:");

                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0;i < arrayLength; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            Console.WriteLine($"Наименьшее число последовательности: {min}");
        }
    }
}
