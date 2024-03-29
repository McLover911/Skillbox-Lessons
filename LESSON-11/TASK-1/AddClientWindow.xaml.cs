﻿using System;
using System.Collections.Generic;
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
using System.IO;
using System.Net.Http.Headers;

namespace TASK_1
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void buttonToAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClientLogic addClientLogic = new AddClientLogic();

            string[] enteredData =
            {
                textBoxSurname.Text,
                textBoxName.Text,
                textBoxPatronimyc.Text,
                textBoxPhoneNumber.Text,
                textBoxPassportID.Text
            };

            addClientLogic.checkAndSaveNewClient(enteredData, this);
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            this.Close();
            managerWindow.Show();
        }
    }
}
