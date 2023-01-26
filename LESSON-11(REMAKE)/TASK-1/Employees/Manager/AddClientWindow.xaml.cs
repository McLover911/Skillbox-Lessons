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

namespace TASK_1.Employees.Manager
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
            AddClient addClient = new AddClient();

            string[] enteredData =
            {
                textBoxSurname.Text,
                textBoxName.Text,
                textBoxPatronimyc.Text,
                textBoxPhoneNumber.Text,
                textBoxPassportID.Text
            };

            addClient.ValidationAndSaving(enteredData, this);
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            this.Close();
            managerWindow.Show();
        }
    }
}
