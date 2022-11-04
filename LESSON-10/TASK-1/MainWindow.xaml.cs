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

namespace TASK_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StringReverse _strReverse = new StringReverse();

        public MainWindow()
        {
            InitializeComponent();
        }
         
        private void Left_Button_Click(object sender, RoutedEventArgs e)
        {
            string[] substrings = _strReverse.SplitText(firstTB.Text);

            listBox.Items.Clear();

            foreach (string substring in substrings)
            {
                listBox.Items.Add(substring);
            }
        }

        private void Right_Button_Click(object sender, RoutedEventArgs e)
        {
            label.Content = _strReverse.Reverse(secondTB.Text);
        }
    }
}
