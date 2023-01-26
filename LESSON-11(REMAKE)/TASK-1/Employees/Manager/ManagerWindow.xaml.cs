using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
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

namespace TASK_1.Employees.Manager
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();

            Client client = new Client();
            Changes changes = new Changes();
            listViewClients.ItemsSource = client.ReturnListOfClients();
            listViewChanges.ItemsSource = changes.ReturnListOfChanges();
        }

        private void buttonToChange_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager();
            manager.DataProcessingAndTransmission(listViewClients, comboBoxSelectedItem, this);
        }

        private void buttonToAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            this.Close();
            addClientWindow.Show();
        }

        private void GoToEmployeeSelection_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSelectionWindow employeeSelection = new EmployeeSelectionWindow();
            this.Close();
            employeeSelection.Show();
        }
    }
}
