using CarShop228.AddEditDelPages;
using CarShop228.DataFullScreen;
using CarShop228.Model;
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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            if (MainWindow.Globals.UserRoles == 1) //разгранечение ролей
            {
                Del_Btn.Visibility = Visibility.Visible;
                TextBlock.Text = "ADMIN";

            }
            else
            {
                Del_Btn.Visibility = Visibility.Collapsed;
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

        }
        private void Btn_Settings_CL(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Catalog_DataGrid.ItemsSource = AppData.db.car.ToList();
        }

        private void Add_Btn_CLick(object sender, RoutedEventArgs e)
        {
            AddCarPage addCarPage = new AddCarPage(null);
            addCarPage.Show();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddCarPage addPage = new AddCarPage((sender as Button).DataContext as car);
            addPage.Show();
        }

        private void Del_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentCar = Catalog_DataGrid.SelectedItem as car;
                AppData.db.car.Remove(CurrentCar);
                AppData.db.SaveChanges();
                MessageBox.Show("Вы успешно удалили звпись!");
                Catalog_DataGrid.ItemsSource = AppData.db.car.ToList();
            }
        }

        private void Open_Full_Click(object sender, RoutedEventArgs e)
        {
            CarsFullScreen carsFullScreen = new CarsFullScreen();
            carsFullScreen.Show();
        }

        private void Refresh_Btn_Click(object sender, RoutedEventArgs e)
        {
            Catalog_DataGrid.ItemsSource = AppData.db.car.ToList();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
