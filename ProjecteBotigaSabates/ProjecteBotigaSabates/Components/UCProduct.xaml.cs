using DBModel;
using DBModel.Models;
using ProjecteBotigaSabates.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
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
using System.Xml.Linq;

namespace ProjecteBotigaSabates.Components
{
    /// <summary>
    /// Lógica de interacción para UCProduct.xaml
    /// </summary>
    public partial class UCProduct : UserControl
    {



        public Producte MyProd
        {
            get { return (Producte)GetValue(MyProdProperty); }
            set { SetValue(MyProdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyProdProperty =
            DependencyProperty.Register("MyProd", typeof(Producte), typeof(UCProduct), new PropertyMetadata(null));



        public UCProduct()
        {
            InitializeComponent();
        }

        ObservableCollection<ViewModelVarietatProducte> OCvareitats = new ObservableCollection<ViewModelVarietatProducte>();

        private async void uc_Loaded(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("MYPROD: " + MyProd.ToString());

            tb_name.Text = MyProd.Nom;

            ChangeDesc();
            

            MongoDBConnection mongoDB = new MongoDBConnection();
            List<VarietatProducte> varietats = mongoDB.GetAllVarietatsOfProducts(MyProd.Id.ToString());

            foreach(VarietatProducte vp in varietats)
            {
                ViewModelVarietatProducte vmvp = new ViewModelVarietatProducte{prod = vp};
                OCvareitats.Add(vmvp);
            }
            
            lv_imgs.ItemsSource = OCvareitats;
            lv_imgs.SelectedIndex = 0;
           
        }

        private async void ChangeDesc()
        {
            await wb_desc.EnsureCoreWebView2Async();
            //wb_desc.NavigateToString(MyProd.Descripcio);
            string a = @"<html><body style='background:#f7f7f7;'>" + MyProd.Descripcio+"</body></html>";
            wb_desc.NavigateToString(a);
        }

        private void lv_imgs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ViewModelVarietatProducte vmvp = (ViewModelVarietatProducte)lv_imgs.SelectedItem;

            if(vmvp != null)
            {
                main_img.Source = vmvp.ImageUrl;
                tb_preu.Text = "Price: " + vmvp.prod.Preu + " €";
                tb_dto.Text = "Discount: " + vmvp.prod.Descompte + "% "+(vmvp.prod.Preu - (vmvp.prod.Preu * (vmvp.prod.Descompte / 100))) + "€";
                tb_color.Text = "Color: " + vmvp.prod.Color;
            }

        }
    }
}
