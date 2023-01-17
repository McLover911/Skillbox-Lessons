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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace TASK_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class ConsultantWindow : Window
    {
        public ConsultantWindow()
        {
            InitializeComponent();

            Consultant consultant = new Consultant();

            listViewClients.ItemsSource = consultant.FillTheListOfClients();

            if (File.Exists(@"Tables\Logs.txt"))
            {
                listViewChanges.ItemsSource = consultant.FillTheListOfChanges(); 
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex;
            string currentNumber;
            string surname;
            string name;
            string patronymic;

            if (listViewClients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Клиент не выбран", 
                                "Ошибка", 
                                MessageBoxButton.OK, 
                                MessageBoxImage.Warning);
            }
            else
            {
                selectedIndex = listViewClients.SelectedIndex;

                currentNumber = (listViewClients.SelectedItem as Consultant).PhoneNumber.ToString();
                surname = (listViewClients.SelectedItem as Consultant).Surname;
                name = (listViewClients.SelectedItem as Consultant).Name;
                patronymic = (listViewClients.SelectedItem as Consultant).Patronymic;

                string fullName = surname + " " + name + " " + patronymic;

                ChangeThePhoneNumber changeNumberWindow = new ChangeThePhoneNumber(selectedIndex, currentNumber, fullName);
                this.Close();
                changeNumberWindow.Show();
            }

        }

        private void buttonChangeThePerson_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSelection employeeSelection = new EmployeeSelection();
            this.Close();
            employeeSelection.Show();
        }
    }
}