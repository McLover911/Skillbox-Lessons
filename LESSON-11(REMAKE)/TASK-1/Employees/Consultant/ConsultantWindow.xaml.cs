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
    /// Логика взаимодействия для ConsultantWindow.xaml
    /// </summary>
    public partial class ConsultantWindow : Window
    {
        public ConsultantWindow()
        {
            InitializeComponent();

            PassportHider passportHider = new PassportHider();
            ChangesHider changesHider = new ChangesHider();
            
            listViewClients.ItemsSource = passportHider.ReturnListOfClients();
            listViewChanges.ItemsSource = changesHider.ReturnListOfChanges();
        }

        private void buttonChangeNumber_Click(object sender, RoutedEventArgs e)
        {
            Consultant consultant = new Consultant();
            consultant.TransferClientData(this, listViewClients);
            
        }

        private void buttonChangeUser_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSelectionWindow employeeSelection = new EmployeeSelectionWindow();
            this.Close();
            employeeSelection.Show();
        }
    }
}
