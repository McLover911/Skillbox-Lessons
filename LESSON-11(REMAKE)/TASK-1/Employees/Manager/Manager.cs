using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TASK_1.Employees.Manager
{
    internal class Manager
    {
        /// <summary>
        /// Обработка выбранных опций и передача данных в ChangeAnyData
        /// </summary>
        /// <param name="lvClients"> ListView с клиентами </param>
        /// <param name="cbSelectedItem"> Выбранная опция в ComboBox </param>
        /// <param name="thisWindow"> Окно, в котором используется метод (this) </param>
        public void DataProcessingAndTransmission(ListView lvClients, ComboBox cbSelectedItem, Window thisWindow)
        {
            int selectedIndex;
            Client currentClient;

            if (lvClients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Клиент не выбран",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
            else if (cbSelectedItem.Text == "")
            {
                MessageBox.Show("Что изменить-то?",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
            else
            {
                selectedIndex = lvClients.SelectedIndex;
                currentClient = lvClients.SelectedItem as Client;

                ChangeAnyDataWindow dataChangeWindow = new ChangeAnyDataWindow(selectedIndex, cbSelectedItem.Text);

                thisWindow.Close();
                dataChangeWindow.Show();
            }
        }


    }
}
