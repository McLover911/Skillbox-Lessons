using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows;

namespace TASK_1
{
    internal class AddClientLogic
    {
        public void checkAndSaveNewClient(string[] enteredData, Window w)
        {
            bool isWrongTypeOrEmpty = false;
            Manager manager = new Manager();

            foreach (string data in enteredData)
            {
                if (String.IsNullOrEmpty(data))
                {
                    MessageBox.Show("Все поля должны быть заполнены",
                                    "Ошибка",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                    isWrongTypeOrEmpty = true;
                    break;
                }
            }

            if (!isWrongTypeOrEmpty)
            {
                if (int.TryParse(enteredData[0], out int surname) ||
                    int.TryParse(enteredData[1], out int name) ||
                    int.TryParse(enteredData[2], out int patronimyc))
                {
                    MessageBox.Show("ФИО заполняется буквами",
                                    "Ошибка",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                    isWrongTypeOrEmpty = true;
                }
                else if (!int.TryParse(enteredData[3], out int phoneNumber) ||
                         !int.TryParse(enteredData[4], out int passportID))
                {
                    MessageBox.Show("Номера должны быть целыми числами",
                                    "Ошибка",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                    isWrongTypeOrEmpty = true;
                }
            }

            if (!isWrongTypeOrEmpty)
            {
                manager.AddClient(enteredData[0],
                                  enteredData[1],
                                  enteredData[2],
                                  enteredData[3],
                                  enteredData[4]);

                ManagerWindow managerWindow = new ManagerWindow();
                w.Close();
                managerWindow.Show();
            }
        }
    }
}
