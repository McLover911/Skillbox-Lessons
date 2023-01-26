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
    /// Логика взаимодействия для ChangeAnyDataWindow.xaml
    /// </summary>
    public partial class ChangeAnyDataWindow : Window
    {
        private int _listViewSelectedIndex;
        private string _button;
        private Manager _manager;
        private int _elementIndex;

        public ChangeAnyDataWindow(int selectedIndex, string button)
        {
            InitializeComponent();

            _listViewSelectedIndex = selectedIndex;
            _button = button;
            _manager = new Manager();

            if (_button == "Фамилию") _button = "Фамилия";
            textBlockDataType.Text = _button;

            switch (_button)
            {
                case "Фамилия":
                    _elementIndex = 0;
                    break;
                case "Имя":
                    _elementIndex = 1;
                    break;
                case "Отчество":
                    _elementIndex = 2;
                    break;
                case "Номер телефона":
                    _elementIndex = 3;
                    break;
                case "Номер паспорта":
                    _elementIndex = 4;
                    break;
            }
        }

        private void buttonSaveData_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            string dataToReplace = _button;
            
            if (!String.IsNullOrEmpty(textBoxNewData.Text))
            {
                client.DataChange(_listViewSelectedIndex, dataToReplace, textBoxNewData.Text, _elementIndex);

                ManagerWindow managerWindow = new ManagerWindow();
                managerWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поле не может оставаться пустым",
                                "Неправильное значение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            this.Close();
        }
    }
}
