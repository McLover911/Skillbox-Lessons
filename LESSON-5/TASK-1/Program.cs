using System;

namespace TASK_1
{
    internal class Program
    {
        static string[] SeparateString(string str)
        {
            return str.Split(' ');
        }

        static void SubstringOutput(string[] subs)
        {
            foreach (var sub in subs)
            {
                Console.WriteLine($"{sub}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение:");
            string sentence = Console.ReadLine();
            SubstringOutput(SeparateString(sentence));
        }
    }
}
