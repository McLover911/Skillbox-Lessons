using System;

namespace TASK_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfCards;
            int score = 0;
            string cardType;

            Console.WriteLine("Введите количество карт на руках:");

            amountOfCards = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfCards; i++)
            {
                Console.WriteLine($"Введите номинал {i + 1}-й карты:");

                cardType = Console.ReadLine().ToUpper();

                switch (cardType)
                {
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        score += int.Parse(cardType);
                        break;
                    case "10":
                    case "J":
                    case "Q":
                    case "K":
                    case "T":
                        score += 10;
                        break;
                    default:
                        Console.WriteLine("Несуществующий номинал");
                        break;
                }

            }

            Console.WriteLine($"Сумма карт равна {score}");
        }
    }
}
