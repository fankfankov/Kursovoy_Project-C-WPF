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
using CarShop228.AddEditDelPages;
using System.Data.Entity.Migrations;

namespace CarShop228.DataFullScreen
{
    /// <summary>
    /// Interaction logic for CarsFullScreen.xaml
    /// </summary>
    public partial class CarsFullScreen : Window
    {
        public CarsFullScreen()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void Add_Btn_CLick(object sender, RoutedEventArgs e)
        {
            AddCarPage addCarPage = new AddCarPage(null);
            addCarPage.Show();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

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

        private void Refresh_Btn(object sender, RoutedEventArgs e)
        {
            Catalog_DataGrid.ItemsSource = AppData.db.car.ToList();
        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Catalog_DataGrid.ItemsSource = AppData.db.car.ToList();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddCarPage addPage = new AddCarPage((sender as Button).DataContext as car);
            addPage.Show();
        }
    }
}
