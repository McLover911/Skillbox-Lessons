using System;
using System.Collections.Generic;
using System.Collections;

namespace TASK_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListService listService = new ListService();
            List<int> integer = new List<int>();

            listService.ListFilling(integer);

            listService.DisplayList(integer);

            listService.RemoveInRange(integer, 25, 50);

            Console.WriteLine();

            listService.DisplayList(integer);
        }
    }
}
