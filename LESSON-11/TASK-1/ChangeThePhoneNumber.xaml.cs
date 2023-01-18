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
    public partial class ChangeThePhoneNumberWindow : Window
    {
        private int _listViewSelectedIndex;
        private string _currentPhoneNumber;
        private string _fullName;

        Consultant consultant = new Consultant();

        public ChangeThePhoneNumberWindow(int selectedIndex, string currentPhoneNumber, string name)
        {
            InitializeComponent();

            _listViewSelectedIndex = selectedIndex;
            _currentPhoneNumber = currentPhoneNumber;
            _fullName = name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // обработка введённой информации
            if (!String.IsNullOrEmpty(textBoxNewNumber.Text) && int.TryParse(textBoxNewNumber.Text, out int newNumber))
            {
                // перезапись файла с новой информацией
                consultant.ChangeThePhoneNumber(textBoxNewNumber.Text, _listViewSelectedIndex, _currentPhoneNumber, _fullName);

                ConsultantWindow mainWindow = new ConsultantWindow();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ConsultantWindow mainWindow = new ConsultantWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
