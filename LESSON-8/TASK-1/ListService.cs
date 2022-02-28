using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1
{
    internal class ListService
    {
        public void ListFilling(List<int> list)
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                list.Add(random.Next(100));
            }
        }

        public void DisplayList(List<int> list)
        {
            foreach (int num in list)
            {
                Console.WriteLine(num);
            }
        }

        public void RemoveInRange(List<int> list, int minValue, int maxValue)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int listElement = list[i];

                if (listElement > minValue && listElement < maxValue)
                {
                    list.Remove(listElement);
                }
            }
        }
    }
}
