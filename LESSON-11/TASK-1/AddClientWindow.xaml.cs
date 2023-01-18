using System;
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
        Manager manager = new Manager();

        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void buttonToAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isWrongTypeOrEmpty = false;

            string[] enteredData =
            {
                textBoxSurname.Text,
                textBoxName.Text,
                textBoxPatronimyc.Text,
                textBoxPhoneNumber.Text,
                textBoxPassportID.Text
            };

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

            if(!isWrongTypeOrEmpty)
            {

                if (int.TryParse(textBoxSurname.Text, out int surname) ||
                    int.TryParse(textBoxName.Text, out int name) ||
                    int.TryParse(textBoxPatronimyc.Text, out int patronimyc))
                {
                    MessageBox.Show("ФИО заполняется буквами",
                                    "Ошибка",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                    isWrongTypeOrEmpty = true;
                }
                else if (!int.TryParse(textBoxPhoneNumber.Text, out int phoneNumber) ||
                         !int.TryParse(textBoxPassportID.Text, out int passportID))
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
                manager.AddClient(textBoxSurname.Text,
                                  textBoxName.Text,
                                  textBoxPatronimyc.Text,
                                  textBoxPhoneNumber.Text,
                                  textBoxPassportID.Text);

                ManagerWindow managerWindow = new ManagerWindow();
                this.Close();
                managerWindow.Show();
            }

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            this.Close();
            managerWindow.Show();
        }
    }
}
