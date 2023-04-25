using CarShop228.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace CarShop228
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TxbPass.IsEnabled = false;
        }
        public static class Globals //класс для разгранечения ролей
        {
            public static int UserRoles;
            public static user userinfo { get; set; }
        }
        private void Button_Click(object sender, RoutedEventArgs e)             //кнопка закрытия приложения
        {
            Application.Current.Shutdown();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)           //кнопка сворачивания приложения
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)    //передвижение окна
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        //авторизация
        private void Auth_Btn_Click(object sender, RoutedEventArgs e)  
        {
            var CurrentUser = AppData.db.user.FirstOrDefault(u => u.login == TxbLogin.Text); //проверка логина
            if (CurrentUser != null) //если правильный логин то открывается поле с паролем
            {
                TxbPass.IsEnabled = true;
                Auth_Btn.Visibility = Visibility.Hidden;
                Auth_Next_Btn.Visibility = Visibility.Visible;
                TxbPass.Focus();

            }
            else //если нет то ошибка
            {
                MessageBox.Show("Такого пользователя не существует!");
            }
        }
        private async void Auth_Btn_Click_2(object sender, RoutedEventArgs e)
        {
           var CurrentUser1 = AppData.db.user.FirstOrDefault(u => u.login == TxbLogin.Text && u.password == TxbPass.Text);     // проверка пароля
            if (CurrentUser1 != null) //если пароль правильный то открывается окно с кодом подтверждения и блокируются все кнопки
            {
                if (Auth_Win_1.Visibility == Visibility.Hidden)
                    Auth_Win_1.Visibility = Visibility.Visible;
                TxbLogin.IsEnabled = false;
                TxbPass.IsEnabled = false;
                Auth_Next_Btn.IsEnabled = false;
                TXB2.Focus();
                Globals.UserRoles = CurrentUser1.roleID;
                Globals.userinfo = CurrentUser1;
                while (true) //рандомизация кода и сброс кода каждые 10 секунд
                {
                    Random x = new Random();
                    int a = x.Next(1000, 9999);
                    TXB1.Text = a.ToString();
                    await Task.Delay(10000);
                }
            }
            else //если пароль не верный то ошибка
            {
                MessageBox.Show("Пароль не верен!");
                TxbPass.Clear();
                TxbPass.IsEnabled = false;
                TxbLogin.Clear();
                Auth_Next_Btn.Visibility = Visibility.Hidden;
                Auth_Btn.Visibility = Visibility.Visible;
            }
        }
        private async void Reboot_Btn_Click(object sender, RoutedEventArgs e) //перегенерация кнопки
        {
            while (true)
            {
                Random x = new Random();
                int a = x.Next(1000, 9999);
                TXB1.Text = a.ToString();
                await Task.Delay(10000);
            }
        }
        private void Next_Btn(object sender, RoutedEventArgs e) //проверка кода подтверждения
        {
            if (TXB2.Text == TXB1.Text) //если код верный то переход на другое окно
            {
                Window3 ebatb = new Window3();
                ebatb.Show();
                Close();
            }
            else //если код не верный то ошибка
            {
                MessageBox.Show("Код подтверждения не верный!");
                TXB2.Clear();
            }
        }

        private void TxbLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

