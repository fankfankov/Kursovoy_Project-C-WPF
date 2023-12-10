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
using System.Windows.Navigation;
using CarShop228.AddEditDelPages;
using CarShop228.DataFullScreen;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;


namespace CarShop228
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            if (MainWindow.Globals.UserRoles == 1) //разгранечение ролей
            {
                Del_Btn.Visibility = Visibility.Visible;
                BackUP.Visibility = Visibility.Visible;
                TextBlock.Text = "ADMIN";

            }
            else
            {
                Del_Btn.Visibility = Visibility.Collapsed;
                BackUP.Visibility = Visibility.Collapsed;
                TextBlock.Text = "Manager";
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Btn_Rep_CL(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Sell_CL(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Katalog_CL(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();
            this.Close();
        }

        private void Btn_Settings_CL(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sells_DataGrid.ItemsSource = AppData.db.buying.ToList();
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

        private void Open_Full_Click(object sender, RoutedEventArgs e)
        {
            SellsFullPage sellsFullPage = new SellsFullPage();
            sellsFullPage.Show();
        }

        private void Refresh_Btn_Click(object sender, RoutedEventArgs e)
        {
            Sells_DataGrid.ItemsSource = AppData.db.buying.ToList();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                CarShopDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Sells_DataGrid.ItemsSource = CarShopDBEntities.GetContext().buying.ToList();
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

            var allRequest = CarShopDBEntities.GetContext().buying.ToList();
            var alcar = CarShopDBEntities.GetContext().car.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Отчёт о покупках";

            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allRequest.Count() + 1, 7);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "Номер по порядку";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Имя покупателя";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Фамилия покупателя";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Марка";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Модель";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Сумма покупки";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Дата покупки";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRequest.Count(); i++)
            {
                var currentCategory = allRequest[i];
                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = Convert.ToString(currentCategory.id);
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = Convert.ToString(currentCategory.customerFname);

                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = Convert.ToString(currentCategory.customerLname);

                    cellRange = paymentsTable.Cell(i + 2, 4).Range;
                    cellRange.Text = Convert.ToString(currentCategory.car.name);

                    cellRange = paymentsTable.Cell(i + 2, 5).Range;
                    cellRange.Text = Convert.ToString(currentCategory.car.model);

                    cellRange = paymentsTable.Cell(i + 2, 6).Range;
                    cellRange.Text = Convert.ToString(currentCategory.purchaseAmount);

                    cellRange = paymentsTable.Cell(i + 2, 7).Range;
                    cellRange.Text = currentCategory.purchaseDate.ToString("dd.MM.yyyy");
            }

            application.Visible = true;
        }

        private void BackUP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string serverName = "localhost\\SQLEXPRESS";
                string databaseName = "CarShopDB";
                string backupPath = @"F:\Kursovoy_Project-C-WPF-main\CarShopDB_BU.bak";

                ServerConnection serverConnection = new ServerConnection(serverName);
                Server server = new Server(serverConnection);
                Backup backup = new Backup
                {
                    Action = BackupActionType.Database,
                    Database = databaseName
                };

                backup.Devices.AddDevice(backupPath, DeviceType.File);

                backup.Initialize = true;
                backup.Checksum = true;
                backup.ContinueAfterError = true;

                backup.SqlBackup(server);

                MessageBox.Show("Бекап успешно произведён!", "Backup Status", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании бекапа: {ex.Message}", "Backup Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
