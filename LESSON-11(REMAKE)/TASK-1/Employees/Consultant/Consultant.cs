using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace TASK_1.Employees.Consultant
{
    internal class Consultant
    {
        public Consultant() { }

        /// <summary>
        /// Передаёт данные клиента в окно для смены номера
        /// </summary>
        /// <param name="thisWindow"> Окно для закрытия (this) </param>
        /// <param name="lv"> ListView со списком клиентов </param>
        public void TransferClientData(Window thisWindow, ListView lv)
        {
            int selectedIndex;
            string surname;
            string name;
            string patronymic;

            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show("Клиент не выбран",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
            else
            {
                selectedIndex = lv.SelectedIndex;

                surname = (lv.SelectedItem as Client).Surname;
                name = (lv.SelectedItem as Client).Name;
                patronymic = (lv.SelectedItem as Client).Patronymic;

                string fullName = surname + " " + name + " " + patronymic;

                ChangePhoneWindow changeNumberWindow = new ChangePhoneWindow(selectedIndex, fullName);
                thisWindow.Close();
                changeNumberWindow.Show();
            }
        }               
    }
}
