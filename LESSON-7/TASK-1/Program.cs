using System;
using System.Collections.Generic;
using System.IO;

namespace TASK_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите идентификатор операции:\n" +
                              "1 - просмотр записи\n" +
                              "2 - создание записи\n" +
                              "3 - удаление записи\n" +
                              "4 - редактирование записи\n" +
                              "5 - загрузка записей временного диапазона\n" +
                              "6 - сортировка данных по возрастанию\n" +
                              "7 - сортировка данных по убыванию");
            string operationID = Console.ReadLine();

            switch (operationID)
            {
                case "1":
                    Console.WriteLine("Введите ID сотрудника:");
                    string employeeID = Console.ReadLine();
                    Methods.DisplayData(employeeID);
                    break;

                case "2":
                    Methods.AddData();
                    break;

                case "3":
                    Methods.DeleteData();
                    break;

                case "4":
                    Methods.EditData();
                    break;

                case "5":
                    Methods.LoadDateRange();
                    break;

                case "6":
                    Methods.AscendingSort();
                    break;

                case "7":
                    Methods.DescendingSort();
                    break;

                default:
                    Console.WriteLine("Идентификатор неверен");
                    break;
            }    
        }
    }
}