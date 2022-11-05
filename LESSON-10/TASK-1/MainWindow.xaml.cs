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
        
        private void Click_Split_Button(object sender, RoutedEventArgs e)
        {
            string[] substrings = _strReverse.SplitText(textBoxToSeparate.Text);

            listBoxToSeparate.Items.Clear();

            foreach (string substring in substrings)
            {
                listBoxToSeparate.Items.Add(substring);
            }
        }

        private void Click_Reverse_Button(object sender, RoutedEventArgs e)
        {
            labelToReverse.Content = _strReverse.Reverse(textBoxToReverse.Text);
        }
    }
}
