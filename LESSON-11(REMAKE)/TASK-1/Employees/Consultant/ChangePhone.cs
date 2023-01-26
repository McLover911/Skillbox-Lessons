using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace TASK_1.Employees.Consultant
{
    internal class ChangePhone
    {
        /// <summary>
        /// Переписывает номер телефона в базе данных
        /// </summary>
        /// <param name="textBoxNewNumber"> Новый номер телефона, введённый в TextBox </param>
        /// <param name="selectedIndex"> Индекс выбранного клиента </param>
        /// <param name="currentPhoneNumber"> </param>
        public void ChangeThePhoneNumber(string textBoxNewNumber, int selectedIndex) //, string fullName
        {
            string[] splitedClient;
            string[] listOfClients = File.ReadAllLines(@"Tables\Clients.txt");
            string updatedClient;


            splitedClient = listOfClients[selectedIndex].Split('#');
            splitedClient[3] = textBoxNewNumber;

            updatedClient = splitedClient[0] + '#' +
                            splitedClient[1] + '#' +
                            splitedClient[2] + '#' +
                            splitedClient[3] + '#' +
                            splitedClient[4];

            listOfClients[selectedIndex] = updatedClient;

            File.WriteAllLines(@"Tables\Clients.txt", listOfClients);

            //string changes = currentPhoneNumber + "->" + textBoxNewNumber;
            //AddLogs("Телефон", fullName, changes, "Консультант");
        }
    }
}
