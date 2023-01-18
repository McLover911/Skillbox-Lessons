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

            if (File.Exists(@"Tables\Logs.txt"))
            {
                listViewChanges.ItemsSource = manager.FillTheListOfChanges();
            }
        }

        private void buttonToChange_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex;
            object currentClient;
            
            if (listViewClients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Клиент не выбран",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
            else if (comboBoxSelectedItem.Text == "")
            {
                MessageBox.Show("Что изменить-то?",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
            else
            {
                selectedIndex = listViewClients.SelectedIndex;
                currentClient = listViewClients.SelectedItem;
                
                DataChangeWindow dataChangeWindow = new DataChangeWindow(selectedIndex, currentClient, comboBoxSelectedItem.Text);

                this.Close();
                dataChangeWindow.Show();
            }
        }

        private void Button_GoToEmployeeSelection(object sender, RoutedEventArgs e)
        {
            EmployeeSelection employeeSelection = new EmployeeSelection();
            this.Close();
            employeeSelection.Show();
        }

        private void buttonToAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            this.Close();
            addClientWindow.Show();
        }
    }
}
