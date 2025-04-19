using DBModel;
using DBModel.Models;
using ProjecteBotigaSabates.StaticContent;
using ProjecteBotigaSabates.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
    /// Lógica de interacción para ViewProductPage.xaml
    /// </summary>
    public partial class ViewProductPage : Page
    {
        private Producte Prod;
        private List<Talla> Talles = new List<Talla>();
        private ViewModelVarietatProducte VarietatSelected; 
        public ViewProductPage(Producte prod)
        {
            Prod = prod;
            InitializeComponent();
        }

        ObservableCollection<ViewModelVarietatProducte> OCvareitats = new ObservableCollection<ViewModelVarietatProducte>();

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            tb_name.Text = Prod.Nom;
            ChangeDesc();

            MongoDBConnection mongoDB = new MongoDBConnection();
            List<VarietatProducte> varietats = mongoDB.GetAllVarietatsOfProducts(Prod.Id.ToString());

            foreach (VarietatProducte vp in varietats)
            {
                ViewModelVarietatProducte vmvp = new ViewModelVarietatProducte { prod = vp };
                OCvareitats.Add(vmvp);
            }

            lv_imgs.ItemsSource = OCvareitats;
            lv_imgs.SelectedIndex = 0;
        }

        private async void ChangeDesc()
        {
            await wb_desc.EnsureCoreWebView2Async();
            //wb_desc.NavigateToString(MyProd.Descripcio);
            string a = @"<html><body>" + Prod.Descripcio + "</body></html>";
            wb_desc.NavigateToString(a);
        }

        private void lv_imgs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Change varietat!");
            ViewModelVarietatProducte vmvp = (ViewModelVarietatProducte)lv_imgs.SelectedItem;

            if (vmvp != null)
            {
                VarietatSelected = vmvp;
                main_img.Source = vmvp.ImageUrl;
                tb_preu.Text = "Price: " + vmvp.prod.Preu + " €";
                tb_color.Text = "Color: " + vmvp.prod.Color;
                loadComboBoxTalla(vmvp);
            }
        }


        private void loadComboBoxTalla(ViewModelVarietatProducte vp)
        {
            Debug.WriteLine("TallaCount: " + vp.prod.Talles.Count());
            cb_talles.Items.Clear();
            Talles.Clear();
            foreach (Talla talla in vp.prod.Talles)
            {
                Debug.WriteLine("Talla: " + talla.NumTalla + " - stock: " + talla.Stock);
                cb_talles.Items.Add(""+talla.NumTalla);
                Talles.Add(talla);
            }
            if(vp.prod.Talles.Count() > 0)
            {
                cb_talles.SelectedIndex = 0;
            }
            else
            {
                tb_stock.Text = "Stock: 0";
            }

        }

        private void cb_talles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            
            if (index != -1)
            {
                tb_stock.Text = "Stock: " + Talles[index].Stock;
            }
            else
            {
                tb_stock.Text = "Stock: 0";
            }

        }

        private void Button_Click_Add_To_Basket(object sender, RoutedEventArgs e)
        {
            int index = cb_talles.SelectedIndex;
            int quantity = 0;
            
            tb_info_add.Text = "";
            
            if (index != -1 && Talles[index].Stock > 0 && Int32.TryParse(tb_qunatity.Text, out quantity) && quantity > 0 && Talles[index].Stock >= quantity)
            {
                int find_index = BasketData.Products.FindIndex(e => e.Talla.NumTalla == Talles[index].NumTalla && e.Vareitat.Equals(VarietatSelected.prod));
                Debug.WriteLine("LINEACOMANDA REPE?: " + find_index + " - "+ BasketData.Products.Count());
                if (find_index != -1)
                {
                    //Si en las lineas de la comanda ja existeix la varietat amb la talla a la cistella només s'afegeix la quantiatat al registre ja creat
                    if(quantity + BasketData.Products[find_index].Quantitat <= Talles[index].Stock)
                    {
                        BasketData.Products[find_index].Quantitat = BasketData.Products[find_index].Quantitat + quantity;
                        tb_info_add.Text = "Product added!";
                    }
                    else
                    {
                        tb_info_add.Text = "Stock Excedeed!";
                    }
                }
                else
                {
                    BasketData.Products.Add(new LineaComanda(quantity, VarietatSelected.prod, Talles[index]));
                    tb_info_add.Text = "Product added!";
                }

                
            }
            else
            {
                tb_info_add.Text = "There are some errors in the data, check them!";
            }

        }
    }
}
