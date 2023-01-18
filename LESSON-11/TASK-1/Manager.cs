using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls.Primitives;

namespace TASK_1
{
    internal class Manager : Consultant, IManager
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
        public new string PassportID
        {
            get
            {
                if (_passportID.Length > 0
                      && int.TryParse(_passportID, out int passportIdInt)
                      && passportIdInt > 0) return _passportID;
                else return "Нет данных";
            }
            set { _passportID = value; }
        }

        public Manager() { }
        private Manager(string surname, string name, string patronymic, long phoneNumber, string passportID)
        {
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _passportID = passportID;
        }

        public new List<Manager> FillTheListOfClients()
        {
            string[] clients = File.ReadAllLines(@"Tables\Clients.txt");
            string[] client = new string[5];

            List<Manager> listOfClients = new List<Manager>();

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

        public new List<Changes> FillTheListOfChanges()
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
        public void AddClient(string surname, string name, string patronimyc, string phoneNumber, string passportId) 
        {
            string fullInfo = surname + "#" +
                              name + "#" +
                              patronimyc + "#" +
                              phoneNumber + "#" +
                              passportId + "\n";

            File.AppendAllText(@"Tables/Clients.txt", fullInfo);
        }

        public void DataChange(int selectedIndex, string dataToReplace, string newData)
        {
            string[] listOfClients = File.ReadAllLines(@"Tables/Clients.txt");
            string[] client = new string[5];
            string clientsFullName; 
            string updatedInfo = "";
            string typeOfChanges = "";

            client = listOfClients[selectedIndex].Split('#');
            clientsFullName = client[0] + ' ' + client[1] + ' ' + client[2];

            switch (dataToReplace)
            {
                case "Фамилию":
                    typeOfChanges = client[0] + "->" + newData;
                    client[0] = newData;
                    break;
                case "Имя":
                    typeOfChanges = client[1] + "->" + newData;
                    client[1] = newData;
                    break;
                case "Отчество":
                    typeOfChanges = client[2] + "->" + newData;
                    client[2] = newData;
                    break;
                case "Номер телефона":
                    typeOfChanges = client[3] + "->" + newData;
                    client[3] = newData;
                    break;
                case "Номер паспорта":
                    typeOfChanges = client[4] + "->" + newData;
                    client[4] = newData;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < client.Length; i++)
            {
                updatedInfo += client[i] + '#';
            }

            updatedInfo.Remove(updatedInfo.Length - 1);

            listOfClients[selectedIndex] = updatedInfo;

            File.WriteAllLines(@"Tables/Clients.txt", listOfClients);

            AddLogs(dataToReplace, clientsFullName, typeOfChanges, "Менеджер");
        }
    }
}
