using CarShop228.AddEditDelPages;
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

namespace CarShop228.DataFullScreen
{
    /// <summary>
    /// Interaction logic for SellsFullPage.xaml
    /// </summary>
    public partial class SellsFullPage : Window
    {
        public SellsFullPage()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Btn_CLick(object sender, RoutedEventArgs e)
        {
            AddPage addPage = new AddPage(null);
            addPage.Show();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddPage addPage = new AddPage((sender as Button).DataContext as buying);
            addPage.Show();
        }

        private void Del_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentCar = Sells_DataGrid.SelectedItem as buying;
                AppData.db.buying.Remove(CurrentCar);
                AppData.db.SaveChanges();
                MessageBox.Show("Вы успешно удалили звпись!");
                Sells_DataGrid.ItemsSource = AppData.db.buying.ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sells_DataGrid.ItemsSource = AppData.db.buying.ToList();
        }

        private void Refresh_Btn(object sender, RoutedEventArgs e)
        {
            Sells_DataGrid.ItemsSource = AppData.db.buying.ToList();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
