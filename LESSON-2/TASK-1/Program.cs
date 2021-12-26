using System;

namespace TASK_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Кузьменко Станислав Юрьевич";
            int age = 23;
            string email = "kust@gmail.com";
            float programmingScores = 73.5f;
            float mathScores = 85.2f;
            float physicsScores = 77.9f;

            string pattern = "ФИО: {0}" +
                             "\nВозраст: {1}" +
                             "\nEmail: {2}" +
                             "\nБаллы по программированию: {3}" +
                             "\nБаллы по математике: {4}" +
                             "\nБаллы по физике: {5}";

            Console.WriteLine(pattern,
                              fullName,
                              age,
                              email,
                              programmingScores,
                              mathScores,
                              physicsScores);
        }
    }
}
