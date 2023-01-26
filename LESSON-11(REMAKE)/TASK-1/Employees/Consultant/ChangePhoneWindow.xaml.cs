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

namespace TASK_1.Employees.Consultant
{
    /// <summary>
    /// Логика взаимодействия для ChangePhoneWindow.xaml
    /// </summary>
    public partial class ChangePhoneWindow : Window
    {
        private int _listViewSelectedIndex;
        private string _fullName;

        /// <summary>
        /// Окно смены номера телефона
        /// </summary>
        /// <param name="selectedIndex"> Индекс выбранного в ListView клиента  </param>
        /// <param name="currentPhoneNumber"> Сохранённый номер телефона выбранного клиента </param>
        /// <param name="name"> Полное имя выбранного клиента </param>
        public ChangePhoneWindow(int selectedIndex, string name)
        {
            InitializeComponent();

            _listViewSelectedIndex = selectedIndex;
            _fullName = name;
        }

        private void buttonToConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxNewNumber.Text) && int.TryParse(textBoxNewNumber.Text, out int newNumber))
            {
                Client client = new Client();
                client.ChangeThePhoneNumber(textBoxNewNumber.Text, _listViewSelectedIndex);

                ConsultantWindow consultantWindow = new ConsultantWindow();
                consultantWindow.Show();
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

        private void buttonToCancel_Click(object sender, RoutedEventArgs e)
        {
            ConsultantWindow consultantWindow = new ConsultantWindow();
            consultantWindow.Show();
            this.Close();
        }
    }
}
