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
using System.Net.Mail;

namespace TASK_1
{
    /// <summary>
    /// Логика взаимодействия для ChangeThePhoneNumber.xaml
    /// </summary>
    public partial class ChangeThePhoneNumber : Window
    {
        private int _listViewSelectedIndex;
        private string _currentPhoneNumber;
        private string[] _listOfClients;

        public ChangeThePhoneNumber(int selectedIndex, string currentPhoneNumber)
        {
            InitializeComponent();

            _listViewSelectedIndex = selectedIndex;
            _currentPhoneNumber = currentPhoneNumber;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _listOfClients = File.ReadAllLines(@"Tables/Clients.txt");

            // обработка введённой информации
            if (!String.IsNullOrEmpty(textBoxNewNumber.Text) && int.TryParse(textBoxNewNumber.Text, out int newNumber))
            {
                // перезапись файла с новой информацией
                _listOfClients[_listViewSelectedIndex] = _listOfClients[_listViewSelectedIndex].Replace(_currentPhoneNumber, textBoxNewNumber.Text);
                File.WriteAllLines(@"Tables/Clients.txt", _listOfClients);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поле может содержать только цифры и не может оставаться пустым", 
                                "Неправильное значение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}
