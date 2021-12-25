using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_2
{
    class Program
    {
        static void Main(string[] args)
        {
            float programmingScores = 73.5f;
            float mathScores = 85.2f;
            float physicsScores = 77.9f;

            float scoreSum;
            float scoreMean;

            scoreSum = programmingScores + mathScores + physicsScores;
            scoreMean = scoreSum / 3;

            string scoreMeanFormated = scoreMean.ToString("#.##");

            Console.WriteLine($"Сумма баллов: {scoreSum} \nСреднее арифметическое баллов: {scoreMeanFormated}");

            Console.ReadKey();
        }
    }
}