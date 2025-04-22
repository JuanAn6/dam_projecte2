using DBModel.Models;
using ProjecteBotigaSabates.StaticContent;
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

namespace ProjecteBotigaSabates.Views
{
    /// <summary>
    /// Lógica de interacción para StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private MainWindow mainWindow;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.tb_info.Text = "";
            mainWindow.tb_user_name.Text = ClientConnected.AuthClient.Nom + " " + ClientConnected.AuthClient.Cognom;

            BasketData basket = new BasketData();

            mainWindow.tb_number_lines.Text = ""+BasketData.CountLines();

        }

        private void Button_Products_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Navigate(new ProductsPage(null));
        }

        private void Button_Basket_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Navigate(new BasketPage());
            //Report.DownloadReport("F2025-000005");
        }
    }
}
