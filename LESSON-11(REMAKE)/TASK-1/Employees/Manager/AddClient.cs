using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TASK_1.Employees.Manager
{
    internal class AddClient
    {
        //public void checkAndSaveNewClient(string[] enteredData, Window w)
        //{
        //    bool isWrongTypeOrEmpty = false;
        //    Client client = new Client();

        //    foreach (string data in enteredData)
        //    {
        //        if (String.IsNullOrEmpty(data))
        //        {
        //            MessageBox.Show("Все поля должны быть заполнены",
        //                            "Ошибка",
        //                            MessageBoxButton.OK,
        //                            MessageBoxImage.Error);
        //            isWrongTypeOrEmpty = true;
        //            break;
        //        }
        //    }

        //    if (!isWrongTypeOrEmpty)
        //    {
        //        if (int.TryParse(enteredData[0], out int surname) ||
        //            int.TryParse(enteredData[1], out int name) ||
        //            int.TryParse(enteredData[2], out int patronimyc))
        //        {
        //            MessageBox.Show("ФИО заполняется буквами",
        //                            "Ошибка",
        //                            MessageBoxButton.OK,
        //                            MessageBoxImage.Error);
        //            isWrongTypeOrEmpty = true;
        //        }
        //        else if (!int.TryParse(enteredData[3], out int phoneNumber) ||
        //                 !int.TryParse(enteredData[4], out int passportID))
        //        {
        //            MessageBox.Show("Номера должны быть целыми числами",
        //                            "Ошибка",
        //                            MessageBoxButton.OK,
        //                            MessageBoxImage.Error);
        //            isWrongTypeOrEmpty = true;
        //        }
        //    }

        //    if (!isWrongTypeOrEmpty)
        //    {
        //        client.AddClient(enteredData[0],
        //                          enteredData[1],
        //                          enteredData[2],
        //                          enteredData[3],
        //                          enteredData[4]);

        //        ManagerWindow managerWindow = new ManagerWindow();
        //        w.Close();
        //        managerWindow.Show();
        //    }
        //}

        public void ValidationAndSaving(string[] enteredData, Window thisWindow)
        {
            bool isWrong = InputValidation(enteredData);

            SaveClient(isWrong, enteredData, thisWindow);
        }

        /// <summary>
        /// Проверяет введённые данные на тип
        /// </summary>
        /// <param name="enteredData"> Массив введённых данных </param>
        /// <returns> Bool значение имеющихся ошибок </returns>
        private bool InputValidation(string[] enteredData)
        {
            bool isWrongTypeOrEmpty = false;

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
            return isWrongTypeOrEmpty;
        }

        /// <summary>
        /// Сохраняет клиента в базу данных и закрывает окно ввода данных
        /// </summary>
        /// <param name="isWrongTypeOrEmpty"> Bool-значение имеющихся в введённых данных ошибок </param>
        /// <param name="enteredData"> Массив введённых данных </param> 
        /// <param name="thisWindow"> Окно, которое нужно закрыть (this) </param>
        private void SaveClient(bool isWrongTypeOrEmpty, string[] enteredData, Window thisWindow)
        {
            Client client = new Client();

            if (!isWrongTypeOrEmpty)
            {
                client.AddClient(enteredData[0],
                                 enteredData[1],
                                 enteredData[2],
                                 enteredData[3],
                                 enteredData[4]);

                ManagerWindow managerWindow = new ManagerWindow();
                thisWindow.Close();
                managerWindow.Show();
            }
        }
    }
}
