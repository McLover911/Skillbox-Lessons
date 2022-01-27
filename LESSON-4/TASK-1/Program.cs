using System;

namespace TASK_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows;
            int columns;
            int[,] matrix;
            int sum = 0;

            Random random = new Random();
            
            Console.WriteLine("Введите количество строк:");
            rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов:");
            columns = int.Parse(Console.ReadLine());

            matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i,j] = random.Next(0, 9);
                    Console.Write($"{matrix[i, j]} ");
                    sum += matrix[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Сумма всех элементов матрицы: {sum}");
        }
    }
}
