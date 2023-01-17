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
    /// Логика взаимодействия для EmployeeSelection.xaml
    /// </summary>
    public partial class EmployeeSelection : Window
    {
        public EmployeeSelection()
        {
            InitializeComponent();
        }

        private void buttonConsultant_Click(object sender, RoutedEventArgs e)
        {
            ConsultantWindow mainWindow = new ConsultantWindow();
            mainWindow.Show();
            this.Close();
        }

        private void buttonManager_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            this.Close();
        }
    }
}
