using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TASK_1
{
    internal class Manager : Consultant
    {
        public new string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public new string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public new string Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; }
        }
        public new long PhoneNumber
        {
            get { return _phoneNumber; }
            set { if (value.ToString().Length > 0 && value > 0) _phoneNumber = value; }
        }
        public new string PassportID
        {
            get { return _passportID; }
            set { _passportID = value; }
        }
        public Manager() { }
        private Manager(string surname, 
                        string name, 
                        string patronymic, 
                        long phoneNumber, 
                        string passportID)
        {
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _passportID = passportID;
        }

        // метод, возвращающий список клиентов
        public new List<Consultant> FillsTheListOfClients()
        {
            string[] clients = File.ReadAllLines(@"Tables\Clients.txt");
            string[] client = new string[5];

            List<Consultant> listOfClients = new List<Consultant>();

            for (int i = 0; i < clients.Length; i++)
            {
                client = clients[i].Split('#');

                listOfClients.Add(new Manager(client[0],
                                                 client[1],
                                                 client[2],
                                                 long.Parse(client[3]),
                                                 client[4]));
            }
            return listOfClients;
        }
    }
}
