using CarShop228.DataFullScreen;
using CarShop228.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace CarShop228.AddEditDelPages
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Window
    {
        private buying _currentbuy = new buying();
        public AddPage(buying selectedbuying)
        {

            InitializeComponent();

            if(selectedbuying != null)
            { 
                _currentbuy = selectedbuying; 
            }

            DataContext = _currentbuy;
            CmbCar.ItemsSource = CarShopDBEntities.GetContext().car.ToList();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        public void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            var CurrentCar = CmbCar.SelectedItem as car;

            if (string.IsNullOrWhiteSpace(_currentbuy.customerFname))
                errors.AppendLine("Введите имя покупателя");
            if (string.IsNullOrWhiteSpace(_currentbuy.customerLname))
                errors.AppendLine("Введите фамилию покупателя");
            if (_currentbuy.car == null)
                errors.AppendLine("Выберете купленную машину");
            if (string.IsNullOrWhiteSpace(_currentbuy.purchaseAmount))
                errors.AppendLine("Введите стоимость покупки");
            if (_currentbuy.purchaseDate == null)
                errors.AppendLine("Выберите дату");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentbuy.id >= 0)
                CarShopDBEntities.GetContext().buying.AddOrUpdate(_currentbuy);

            try
            {
                CarShopDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
