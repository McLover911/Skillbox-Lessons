using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using TASK_1.Employees;

namespace TASK_1
{
    public class Client : IComparable<Client>
    {
        private protected string _surname;
        private protected string _name;
        private protected string _patronymic;
        private protected long _phoneNumber;
        private protected int _passportID;

        public string Surname { get { return _surname; } }
        public string Name { get { return _name; } }
        public string Patronymic { get { return _patronymic; } }
        public long PhoneNumber { get { return _phoneNumber; } }
        public int PassportID { get { return _passportID; } }

        public Client() { }
        private Client(string surname, string name, string patronymic, long phoneNumber, int passportID)
        {
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _passportID = passportID;
        }

        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        public virtual List<Client> ReturnListOfClients()
        {
            string[] clients = File.ReadAllLines(@"Tables\Clients.txt");
            string[] client;

            List<Client> listOfClients = new List<Client>();

            for (int i = 0; i < clients.Length; i++)
            {
                client = clients[i].Split('#');

                listOfClients.Add(new Client(client[0],
                                             client[1],
                                             client[2],
                                             long.Parse(client[3]),
                                             int.Parse(client[4])));
            }
            listOfClients.Sort();
            return listOfClients;
        }

        /// <summary>
        /// Конвертирует строку с данными клиента в объект Client
        /// </summary>
        /// <param name="clientInStringFormat"> Строка с данными клиента </param>
        /// <returns> Объект Client </returns>
        public Client ConvertStringToClient(string clientInStringFormat)
        {
            Client client;
            string[] splitedClient;

            splitedClient = clientInStringFormat.Split('#');
            client = new Client(splitedClient[0],
                                splitedClient[1],
                                splitedClient[2],
                                long.Parse(splitedClient[3]),
                                int.Parse(splitedClient[4]));
            return client;
        }

        /// <summary>
        /// Переписывает номер телефона в базе данных
        /// </summary>
        /// <param name="textBoxNewNumber"> Новый номер телефона, введённый в TextBox </param>
        /// <param name="selectedIndex"> Индекс выбранного клиента </param>
        /// <param name="currentPhoneNumber"> </param>
        public void ChangeThePhoneNumber(string textBoxNewNumber, int selectedIndex)
        {
            string updatedClient;
            string fullName;
            string changesDescribe;
            long formerPhoneNumber;
            string[] listOfClients = File.ReadAllLines(@"Tables\Clients.txt");

            Changes changes = new Changes();

            Client client = ConvertStringToClient(listOfClients[selectedIndex]);
            
            formerPhoneNumber = client.PhoneNumber;
            changesDescribe = formerPhoneNumber.ToString() + "->" + textBoxNewNumber;

            fullName = client.Surname + ' ' + client.Name + ' ' + client.Patronymic;
            client._phoneNumber = int.Parse(textBoxNewNumber);

            updatedClient = client.Surname + '#' +
                            client.Name + '#' +
                            client.Patronymic + '#' +
                            client.PhoneNumber + '#' +
                            client.PassportID;

            listOfClients[selectedIndex] = updatedClient;

            File.WriteAllLines(@"Tables\Clients.txt", listOfClients);

            changes.SaveChanges(fullName, "Телефон", changesDescribe, "Консультант");
        }

        /// <summary>
        /// Изменяет данные в базе и добавляет лог
        /// </summary>
        /// <param name="selectedIndex"> Индекс выбранного клиента </param>
        /// <param name="dataToReplace"> Какие данные изменяются </param>
        /// <param name="newData"> Новые данные </param>
        /// <param name="elementIndex"> Индекс данных в массиве </param>
        public void DataChange(int selectedIndex, string dataToReplace, string newData, int elementIndex)
        {
            Changes changes = new Changes();
            string[] listOfClients = File.ReadAllLines(@"Tables/Clients.txt");
            string[] client = new string[5];
            string clientsFullName;
            string updatedInfo = "";
            string typeOfChanges = "";

            client = listOfClients[selectedIndex].Split('#');
            clientsFullName = client[0] + ' ' + client[1] + ' ' + client[2];

            typeOfChanges = client[elementIndex] + "->" + newData;
            client[elementIndex] = newData;

            for (int i = 0; i < client.Length; i++)
            {
                updatedInfo += client[i] + '#';
            }

            updatedInfo.Remove(updatedInfo.Length - 1);

            listOfClients[selectedIndex] = updatedInfo;

            File.WriteAllLines(@"Tables/Clients.txt", listOfClients);

            changes.SaveChanges(clientsFullName, dataToReplace, typeOfChanges, "Менеджер");
        }
        
        /// <summary>
        /// Добавляет клиента в базу данных
        /// </summary>
        /// <param name="surname"> Фамилия </param>
        /// <param name="name"> Имя </param>
        /// <param name="patronimyc"> Отчество </param>
        /// <param name="phoneNumber"> Номер телефона </param>
        /// <param name="passportId"> Номер паспорта </param>
        public void AddClient(string surname, 
                              string name, 
                              string patronimyc, 
                              string phoneNumber, 
                              string passportId)
        {
            string fullInfo = surname + "#" +
                              name + "#" +
                              patronimyc + "#" +
                              phoneNumber + "#" +
                              passportId + "\n";

            File.AppendAllText(@"Tables/Clients.txt", fullInfo);
        }

        public int CompareTo(Client client)
        {
            if (client == null)
            {
                return 1;
            }

            int ret = String.Compare(this.Surname, client.Surname);
            return ret != 0 ? ret : this.Name.CompareTo(client.Name);
        }

    }
}
