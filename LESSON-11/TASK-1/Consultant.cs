using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace TASK_1
{
    internal class Consultant : IConsultant
    {
        private protected string _surname;
        private protected string _name;
        private protected string _patronymic;
        private protected string _passportID;
        private protected long _phoneNumber;
        

        public string Surname
        {
            get { return _surname; }
        }
        public string Name
        {
            get { return _name; }
        }
        public string Patronymic
        {
            get { return _patronymic; }
        }
        public long PhoneNumber
        {
            get { return _phoneNumber; }
            set { if (value.ToString().Length > 0 && value > 0) _phoneNumber = value; }
        }
        public string PassportID
        {
            get { if (_passportID.Length > 0 
                      && int.TryParse(_passportID, out int passportIdInt) 
                      && passportIdInt > 0) return "**********";
                  else return "Нет данных"; }
        }
        
        public Consultant() { }

        // конструктор для использования внутри класса
        private Consultant(string surname, string name, string patronymic, long phoneNumber, string passportID)
        {
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _passportID = passportID;
        }

        // метод, возвращающий список клиентов
        public virtual List<Consultant> FillTheListOfClients()
        {
            string[] clients = File.ReadAllLines(@"Tables\Clients.txt");
            string[] client = new string[5];

            List<Consultant> listOfClients = new List<Consultant>();

            for (int i = 0; i < clients.Length; i++)
            {
                client = clients[i].Split('#');

                listOfClients.Add(new Consultant(client[0], 
                                                 client[1], 
                                                 client[2], 
                                                 long.Parse(client[3]), 
                                                 client[4]));
            }
            return listOfClients;
        }

        public void ChangeThePhoneNumber(string textBoxNewNumber, int selectedIndex, string currentPhoneNumber, string fullName)
        {
            string[] _listOfClients = File.ReadAllLines(@"Tables/Clients.txt");
            string changes = currentPhoneNumber + "->" + textBoxNewNumber;

            _listOfClients[selectedIndex] = _listOfClients[selectedIndex].Replace(currentPhoneNumber, textBoxNewNumber);
            File.WriteAllLines(@"Tables/Clients.txt", _listOfClients);

            AddLogs("Телефон", fullName, changes, "Консультант");
        }

        public void AddLogs(string typeOfChangedData, string nameOfPerson, string typeOfChanges, string whoChanged)
        {
            string Log = DateTime.Now.ToString() + '#' +
                         nameOfPerson + '#' +
                         typeOfChangedData + '#' +
                         typeOfChanges + '#' +
                         whoChanged + "\n";

            File.AppendAllText(@"Tables/Logs.txt", Log);
        }

        public List<Changes> FillTheListOfChanges()
        {
            
            string[] clients = File.ReadAllLines(@"Tables\Logs.txt");
            string[] client = new string[5];

            List<Changes> listOfClients = new List<Changes>();

            for (int i = 0; i < clients.Length; i++)
            {
                client = clients[i].Split('#');

                listOfClients.Add(new Changes(DateTime.Parse(client[0]),
                                             client[1],
                                             client[2],
                                             client[3],
                                             client[4]));
            }
            return listOfClients;
        }
    }
}
