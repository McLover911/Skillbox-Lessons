using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_2
{
    internal class Methods
    {
        public static void AddNumber(Dictionary<string, string> phonebook)
        {
            string ownersName;
            string phoneNumber;
                                  
            while (true)
            {
                Console.WriteLine("Введите ФИО владельца номера телефона, чтобы добавить в справочник,\n" +
                                  "или пустую строку, чтобы вернуться к выбору операции:");
                ownersName = Console.ReadLine();

                if (ownersName != "")
                {
                    Console.WriteLine("Введите номер телефона:");
                    phoneNumber = Console.ReadLine();

                    phonebook.Add(phoneNumber, ownersName);
                    Console.WriteLine("Данные добавлены");
                    Console.WriteLine();
                }
                else
                {
                    break;
                }

            }
        }

        public static void FindNumber(Dictionary<string, string> phonebook)
        {
            string phoneNumber;
            string ownersName;

            Console.WriteLine("Введите номер владельца:");
            phoneNumber = Console.ReadLine();

            if (phonebook.TryGetValue(phoneNumber, out ownersName))
            {
                Console.WriteLine(ownersName);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Номер не найден");
                Console.WriteLine();
            }
        }
    }
}
