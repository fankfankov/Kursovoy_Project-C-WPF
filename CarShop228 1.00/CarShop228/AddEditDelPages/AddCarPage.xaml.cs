using CarShop228.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Interaction logic for AddCarPage.xaml
    /// </summary>
    public partial class AddCarPage : Window
    {
        private car _currentcar = new car();
        public AddCarPage(car selectedcar)
        {
            InitializeComponent();

            if (selectedcar != null)
            {
                _currentcar = selectedcar;
            }

            DataContext = _currentcar;
            CmbComp.ItemsSource = CarShopDBEntities.GetContext().complectation.ToList();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            var CurrentCar = CmbComp.SelectedItem as complectation;

            if (string.IsNullOrWhiteSpace(_currentcar.name))
                errors.AppendLine("Укажите название автомобиля");
            if (string.IsNullOrWhiteSpace(_currentcar.model))
                errors.AppendLine("Укажите модель автомобиля");
            if (string.IsNullOrWhiteSpace(_currentcar.color))
                errors.AppendLine("Укажите цвет");
            if (_currentcar.complectation == null)
                errors.AppendLine("Выберете комплектацию");
            if (_currentcar.price == null)
                errors.AppendLine("Введите стоимость машины");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentcar.id >= 0)
                CarShopDBEntities.GetContext().car.AddOrUpdate(_currentcar);

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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
        }
    }
}
