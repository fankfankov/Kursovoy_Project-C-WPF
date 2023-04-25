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

namespace CarShop228
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            if (MainWindow.Globals.UserRoles == 1) //разгранечение ролей
            {
                TextBlock.Text = "ADMIN";

            }
            else
            {
                TextBlock.Text = "User";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow ebatb3 = new MainWindow();
            ebatb3.Show();
            Close();
        }

        private void Btn_Rep_CL(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Sell_CL(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
            this.Close();
        }

        private void Btn_Katalog_CL(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();
            this.Close();
        }

        private void Btn_Settings_CL(object sender, RoutedEventArgs e)
        {

        }
    }
}
