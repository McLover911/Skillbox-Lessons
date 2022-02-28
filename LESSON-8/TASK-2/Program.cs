using System;
using System.Collections.Generic;

namespace TASK_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operationID;

            ListService listService = new ListService();
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            while (true)
            {
                Console.WriteLine("Введите идентификатор операции:\n" +
                              "1 - добавить номер\n" +
                              "2 - найти владельца номера\n" +
                              "3 - прекратить работу со справочником");
                operationID = Console.ReadLine();

                Console.WriteLine();

                switch (operationID)
                {
                    case "1":
                        listService.AddNumber(phoneBook);
                        break;
                    case "2":
                        listService.FindNumber(phoneBook);
                        break;
                    case "3":
                        Console.WriteLine("Работа прекращена");
                        return;
                    default:
                        Console.WriteLine("Идентификатор неверен");
                        break;
                }
            }    
            

        }
    }
}
