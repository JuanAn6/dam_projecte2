using DBModel;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Lógica de interacción para ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        MongoDBConnection mongoDB;
        public ObservableCollection<Producte> Products { get; set; }
        public ProductsPage()
        {
            InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            Products = new ObservableCollection<Producte>();
            mongoDB = new MongoDBConnection();
            List<Producte> prods = mongoDB.GetAllProducts();
            
            foreach(Producte p in prods)
            {
                Debug.WriteLine(p);
                Products.Add(p);
            }

            //lv_products.ItemsSource = Products;
            this.DataContext = this;

        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
           
        }

        
    }
}
