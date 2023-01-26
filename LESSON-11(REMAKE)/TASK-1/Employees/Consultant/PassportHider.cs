using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1.Employees.Consultant
{
    /// <summary>
    /// Прячет номер паспорта от консультанта
    /// </summary>
    internal class PassportHider : Client
    {
        public new string PassportID { get { return "Нет доступа"; } }
        
        public PassportHider() { }
        private PassportHider(string surname, string name, string patronymic, long phoneNumber, int passportID)
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
        public override List<Client> ReturnListOfClients()
        {
            string[] clients = File.ReadAllLines(@"Tables\Clients.txt");
            string[] client;

            List<Client> listOfClients = new List<Client>();

            for (int i = 0; i < clients.Length; i++)
            {
                client = clients[i].Split('#');

                listOfClients.Add(new PassportHider(client[0],
                                                    client[1],
                                                    client[2],
                                                    long.Parse(client[3]),
                                                    int.Parse(client[4])));
            }
            listOfClients.Sort();
            return listOfClients;
        }

        
    }
}
