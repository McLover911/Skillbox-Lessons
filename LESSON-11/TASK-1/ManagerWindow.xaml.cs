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

namespace TASK_1
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();

            Manager manager = new Manager();

            listViewClients.ItemsSource = manager.FillTheListOfClients();
        }

        private void buttonSurname_Click(object sender, RoutedEventArgs e)
        {
            DataChange("surname");
        }

        private void buttonName_Click(object sender, RoutedEventArgs e)
        {
            DataChange("name");
        }

        private void buttonPatronymic_Click(object sender, RoutedEventArgs e)
        {
            DataChange("patronymic");
        }

        private void buttonPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            DataChange("phoneNumber");
        }

        private void buttonPassportID_Click(object sender, RoutedEventArgs e)
        {
            DataChange("passportID");
        }
        private void DataChange(string buttonType)
        {
            int selectedIndex;
            object currentClient;
            string button;

            button = buttonType;
            
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
                currentClient = listViewClients.SelectedItem;

                DataChangeWindow dataChangeWindow = new DataChangeWindow(selectedIndex, currentClient, button);

                this.Close();
                dataChangeWindow.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSelection employeeSelection = new EmployeeSelection();
            this.Close();
            employeeSelection.Show();
        }
    }
}
