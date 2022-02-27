using System;
using System.Collections.Generic;
using System.Collections;

namespace TASK_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integer = new List<int>();

            Methods.ListFilling(integer);

            Methods.DisplayList(integer);

            Methods.RemoveInRange(integer, 25, 50);

            Console.WriteLine();

            Methods.DisplayList(integer);
        }
    }
}
