﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TASK_1
{
    /// <summary>
    /// Логика взаимодействия для DataChangeWindow.xaml
    /// </summary>
    public partial class DataChangeWindow : Window
    {
        private int _listViewSelectedIndex;
        private string _button;
        private string[] _listOfClients;
        private Consultant _currentClient;
        private Manager _manager;



        public DataChangeWindow(int selectedIndex, object currentClient, string button)
        {
            InitializeComponent();

            _listViewSelectedIndex = selectedIndex;
            _currentClient = currentClient as Consultant;
            _button = button;
            _manager = new Manager();

            switch (_button)
            {
                case "surname":
                    textBlockDataType.Text = "Фамилия";
                    break;
                case "name":
                    textBlockDataType.Text = "Имя";
                    break;
                case "patronymic":
                    textBlockDataType.Text = "Отчество";
                    break;
                case "phoneNumber":
                    textBlockDataType.Text = "Номер телефона";
                    break;
                case "passportID":
                    textBlockDataType.Text = "Номер паспорта";
                    break;
            }
             
        }

        private void buttonSaveData_Click(object sender, RoutedEventArgs e)
        {
             
            string dataToReplace = "";

            switch (_button)
            {
                case "surname":
                    dataToReplace = _currentClient.Surname;
                    break;
                case "name":
                    dataToReplace = _currentClient.Name;
                    break;
                case "patronymic":
                    dataToReplace = _currentClient.Patronymic;
                    break;
                case "phoneNumber":
                    dataToReplace = _currentClient.PhoneNumber.ToString();
                    break;
                case "passportID":
                    dataToReplace = _currentClient.PassportID;
                    break;
            }

            

            if (!String.IsNullOrEmpty(textBoxNewData.Text))
            {
                _manager.DataChange(_listViewSelectedIndex, dataToReplace, textBoxNewData.Text);

                ManagerWindow managerWindow = new ManagerWindow();
                managerWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Поле не может оставаться пустым",
                                "Неправильное значение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            
        }
    }
}
