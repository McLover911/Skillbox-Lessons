using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TASK_1
{
    internal class Methods
    {
        private static string path = "Сотрудники.txt";
        private static int fileLength = File.ReadAllLines(path).Length;

        public static void AddData()
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                PersonalData pd = new PersonalData();

                Console.WriteLine("Введите ID:");
                pd.ID = Console.ReadLine();
                pd.DateTime = Convert.ToString(DateTime.Now);
                Console.WriteLine("Введите ФИО:");
                pd.FullName = Console.ReadLine();
                Console.WriteLine("Введите возраст:");
                pd.Age = Console.ReadLine();
                Console.WriteLine("Введите рост:");
                pd.Growth = Console.ReadLine();
                Console.WriteLine("Введите дату рождения:");
                pd.BirthDate = Console.ReadLine();
                Console.WriteLine("Введите место рождения:");
                pd.BirthPlace = Console.ReadLine();

                sw.WriteLine("\n{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                             pd.ID,
                             pd.DateTime,
                             pd.FullName,
                             pd.Age,
                             pd.Growth,
                             pd.BirthDate,
                             pd.BirthPlace);
            }

            Console.WriteLine("Данные добавлены");
        }

        public static void DisplayData(string id)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] substrings;

                while ((line = sr.ReadLine()) != null)
                {
                    substrings = line.Split('#');

                    if (substrings[0] == id)
                    {
                        Console.WriteLine(line.Replace('#', ' '));
                        break;
                    }
                }
            }
        }

        public static void DeleteData()
        {
            Console.WriteLine("Введите ID сотрудника:");
            string id = Console.ReadLine();

            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] substrings;

                while ((line = sr.ReadLine()) != null)
                {
                    substrings = line.Split('#');

                    if (substrings[0] != id)
                    {
                        list.Add(line);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(String.Join("\n", list));
            }

            Console.WriteLine("Данные удалены");
        }

        public static void EditData()
        {
            Console.WriteLine("Введите ID удаляемого сотрудника:");
            string id = Console.ReadLine();

            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] substrings;

                while ((line = sr.ReadLine()) != null)
                {
                    substrings = line.Split('#');

                    if (substrings[0] != id)
                    {
                        list.Add(line);
                    }
                    else
                    {
                        PersonalData pd = new PersonalData();

                        pd.ID = id;
                        pd.DateTime = Convert.ToString(DateTime.Now);
                        Console.WriteLine("Введите ФИО заменяемого сотрудника:");
                        pd.FullName = Console.ReadLine();
                        Console.WriteLine("Введите возраст:");
                        pd.Age = Console.ReadLine();
                        Console.WriteLine("Введите рост:");
                        pd.Growth = Console.ReadLine();
                        Console.WriteLine("Введите дату рождения:");
                        pd.BirthDate = Console.ReadLine();
                        Console.WriteLine("Введите место рождения:");
                        pd.BirthPlace = Console.ReadLine();

                        string newLine = $"{pd.ID}#{pd.DateTime}#{pd.FullName}#{pd.Age}#{pd.Growth}#{pd.BirthDate}#{pd.BirthPlace}";

                        list.Add(newLine);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(String.Join("\n", list));
            }

            Console.WriteLine("Данные заменены");
        }

        public static void LoadDateRange()
        {
            Console.WriteLine("Введите начальную дату в формате ДД.ММ.ГГГГ:");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите конечную дату в формате ДД.ММ.ГГГГ:");
            DateTime finishDate = DateTime.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] substrings;

                while ((line = sr.ReadLine()) != null)
                {
                    substrings = line.Split('#');

                    if (DateTime.Parse(substrings[1]) > startDate && DateTime.Parse(substrings[1]) < finishDate)
                    {
                        Console.WriteLine(line.Replace('#', ' '));
                    }
                }
            }
        }

        public static void AscendingSort()
        {
            PersonalData[] workerArray = new PersonalData[fileLength];

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] substrings;
                int k = 0;

                while ((line = sr.ReadLine()) != null)
                {

                    substrings = line.Split('#');

                    PersonalData pd = new PersonalData();

                    pd.ID = substrings[0];
                    pd.DateTime = substrings[1];
                    pd.FullName = substrings[2];
                    pd.Age = substrings[3];
                    pd.Growth = substrings[4];
                    pd.BirthDate = substrings[5];
                    pd.BirthPlace = substrings[6];

                    workerArray[k++] = pd;
                }

                PersonalData temp;

                for (int i = 0; i < workerArray.Length - 1; i++)
                {
                    for (int j = i + 1; j < workerArray.Length; j++)
                    {
                        if (DateTime.Parse(workerArray[i].DateTime) > DateTime.Parse(workerArray[j].DateTime))
                        {
                            temp = workerArray[i];
                            workerArray[i] = workerArray[j];
                            workerArray[j] = temp;
                        }
                    }
                }

                foreach (PersonalData pd in workerArray)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}",
                             pd.ID,
                             pd.DateTime,
                             pd.FullName,
                             pd.Age,
                             pd.Growth,
                             pd.BirthDate,
                             pd.BirthPlace);
                }
            }
        }

        public static void DescendingSort()
        {
            PersonalData[] workerArray = new PersonalData[fileLength];

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] substrings;
                int k = 0;

                while ((line = sr.ReadLine()) != null)
                {

                    substrings = line.Split('#');

                    PersonalData pd = new PersonalData();

                    pd.ID = substrings[0];
                    pd.DateTime = substrings[1];
                    pd.FullName = substrings[2];
                    pd.Age = substrings[3];
                    pd.Growth = substrings[4];
                    pd.BirthDate = substrings[5];
                    pd.BirthPlace = substrings[6];

                    workerArray[k++] = pd;
                }

                PersonalData temp;

                for (int i = 0; i < workerArray.Length - 1; i++)
                {
                    for (int j = i + 1; j < workerArray.Length; j++)
                    {
                        if (DateTime.Parse(workerArray[i].DateTime) < DateTime.Parse(workerArray[j].DateTime))
                        {
                            temp = workerArray[i];
                            workerArray[i] = workerArray[j];
                            workerArray[j] = temp;
                        }
                    }
                }

                foreach (PersonalData pd in workerArray)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}",
                             pd.ID,
                             pd.DateTime,
                             pd.FullName,
                             pd.Age,
                             pd.Growth,
                             pd.BirthDate,
                             pd.BirthPlace);
                }
            }

        }
    }
}
