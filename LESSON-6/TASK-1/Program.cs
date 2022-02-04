using System;
using System.IO;
using System.Threading;

namespace TASK_1
{
    internal class Program
    {
        static private void DataWrite()
        {
            Console.WriteLine("Введите ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Введите ФИО:");
            string fullName = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            string age = Console.ReadLine();
            Console.WriteLine("Введите рост:");
            string growth = Console.ReadLine();
            Console.WriteLine("Введите дату рождения:");
            string birthDate = Console.ReadLine();
            Console.WriteLine("Введите место рождения:");
            string birthPlace = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter("Сотрудники.txt", true))
            {
                sw.WriteLine($"{id}#{DateTime.Now}#{fullName}#{age}#{growth}#{birthDate}#{birthPlace}");
            }
            Console.WriteLine("Данные добавлены");
        }

        static private void DisplayData()
        {
            using (StreamReader sr = new StreamReader("Сотрудники.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line.Replace('#', ' '));
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите идентификатор операции:" +
                              "\n1 - вывести данные на экран;" +
                              "\n2 — заполнить данные и добавить новую запись в конец файла.");
                string operationID = Console.ReadLine();

                if (operationID == "1" && File.Exists("Сотрудники.txt"))
                {
                    DisplayData();
                    break;
                }
                else if (operationID == "1" && !File.Exists("Сотрудники.txt"))
                {
                    Console.WriteLine("Файла не существует");
                    break;
                }
                else if (operationID == "2")
                {
                    DataWrite();
                    break;
                }
                else
                {
                    Console.WriteLine("Идентификатор неверен");
                    Thread.Sleep(1000);
                    Console.WriteLine();
                }
            }
            
        }
    }
}
