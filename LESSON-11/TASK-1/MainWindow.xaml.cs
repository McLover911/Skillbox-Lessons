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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Consultant consultant = new Consultant();

            listViewClients.ItemsSource = consultant.FillsTheListOfClients();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex;
            string currentNumber;

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

                ChangeThePhoneNumber changeNumberWindow = new ChangeThePhoneNumber(selectedIndex, currentNumber);
                this.Close();
                changeNumberWindow.Show();
            }

        }
    }
}