using DBModel.Models;
using DBModel;
using MongoDB.Bson;

using System.Windows;
using System.Windows.Controls;
using ProjecteBotigaSabates.Views;
using ProjecteBotigaSabates.StaticContent;

namespace ProjecteBotigaSabates
{
    /// <summary>
    /// Lógica de interacción para SelectUserPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new SelectUserPage());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            grid_MainMenu.Opacity = 0;

            LoadCategories();
        }


        private void LoadCategories()
        {
            MongoDBConnection mongoDB = new MongoDBConnection();

            List<Categoria> categories = mongoDB.GetCategories();
        }


        private void Button_SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SelectUserPage());
            grid_MainMenu.Opacity = 0;
        }

        private void Button_Products_Click(object sender, RoutedEventArgs e)
        {
            if(ClientConnected.AuthClient != null)
            {
                MainFrame.Navigate(new ProductsPage());
                tb_info.Text = "";
            }
            else
            {
                tb_info.Text = "Select valid user!";
            }

        }




        
    }
}
