using System;

namespace TASK_2
{
    internal class Program
    {
        static string[] SeparateString(string str)
        {
            return str.Split(' ');
        }

        static void ReverseWords(string inputPhrase)
        {
            string resultString = "";
            string[] separatedInput = SeparateString(inputPhrase);
            Array.Reverse(separatedInput);

            foreach (string word in separatedInput)
            {
                resultString += word + " ";
            }
            Console.WriteLine(resultString);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение:");
            string hey = Console.ReadLine();

            ReverseWords(hey);
        }
    }
}
