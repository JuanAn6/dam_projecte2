using DBModel.Models;
using DBModel;
using MongoDB.Bson;

using System.Windows;
using System.Windows.Controls;
using ProjecteBotigaSabates.Views;


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
    }
}
