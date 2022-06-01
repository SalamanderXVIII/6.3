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

namespace _6._3
{

    //Гребенюк А, 21-ИСП-2, 7-я лаборатоная, 2-й вариант, средний уровень.
    public partial class MainWindow : Window
    {
        public int linkedcount;
        public LinkedList<double> list;
        public string node;
        public MainWindow()
        {
            InitializeComponent();
            list = new LinkedList<double>();
            linkedcount = list.Count;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            list.Add(double.Parse(InputValue.Text));
            Result.Items.Add(InputValue.Text);
            InputValue.Clear();
            linkedcount++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            list.Remove(double.Parse(Result.SelectedItem.ToString()));
            Result.Items.Remove(Result.SelectedItem.ToString());
            linkedcount--;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < linkedcount; i++)
            {
                if (double.Parse(list.GetNodeString(list.GetNode(list, i))) < 0)
                {
                    list.Remove(Convert.ToDouble(list.GetNodeString(list.GetNode(list, i+1))));
                    linkedcount--;
                    Result.Items.Clear();
                    for (int c = 0; c < linkedcount; c++)
                    {
                        Result.Items.Add(list.GetNodeString(list.GetNode(list, c)));
                    }
                }
            }
        }
    }
}
