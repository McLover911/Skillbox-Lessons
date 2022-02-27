using System;
using System.Xml.Linq;

namespace TASK_4
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            string fullName;
            string streetName;
            int houseNumber;
            int flatNumber;
            int mobilePhone;
            int flatPhone;

            XElement person = new XElement("Person");
            XElement adress = new XElement("Adress");
            XElement phones = new XElement("Phones");

            person.Add(adress);
            person.Add(phones);

            Console.WriteLine("Введите ФИО контакта:");
            fullName = Console.ReadLine();
            person.SetAttributeValue("name", fullName);

            Console.WriteLine("Введите улицу:");
            streetName = Console.ReadLine();
            adress.Add(new XElement("Street", streetName));

            Console.WriteLine("Введите номер дома:");
            houseNumber = int.Parse(Console.ReadLine());
            adress.Add(new XElement("HouseNumber", houseNumber));

            Console.WriteLine("Введите номер квартиры:");
            flatNumber = int.Parse(Console.ReadLine());
            adress.Add(new XElement("FlatNumber", flatNumber));

            Console.WriteLine("Введите мобильный телефон:");
            mobilePhone = int.Parse(Console.ReadLine());
            phones.Add(new XElement("MobilePhone", mobilePhone));

            Console.WriteLine("Введите домашний телефон:");
            flatPhone = int.Parse(Console.ReadLine());
            phones.Add(new XElement("FlatPhone", flatPhone));

            Console.WriteLine();

            Console.WriteLine(person.ToString());
        }
    }
}
