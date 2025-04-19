using DBModel;
using DBModel.Models;
using MongoDB.Bson;
using ProjecteBotigaSabates.StaticContent;
using ProjecteBotigaSabates.ViewModels;
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
    /// Lógica de interacción para BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public ObservableCollection<LineaComanda> LineasComanda { get; set; }

        public double Total { get; set; }

        public BasketPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LineasComanda = new ObservableCollection<LineaComanda>();

            foreach(LineaComanda lc in BasketData.Products)
            {
                LineasComanda.Add(lc);
                Debug.WriteLine("Linea add: " + lc.ToString());
            }

            this.DataContext = this;
            UpdateTotal();

        }

        private void Button_Del_Prod_Click(object sender, RoutedEventArgs e)
        {
            if(lv_lines.SelectedIndex != -1)
            {
                
                LineaComanda l = LineasComanda[lv_lines.SelectedIndex];
                BasketData.RemoveLine(l);
                LineasComanda.Remove(l);

            }
        }


        private void UpdateTotal()
        {
            Total = 0;
            Total = LineasComanda.Sum(i => i.Quantitat * i.Vareitat.Preu);

            foreach(LineaComanda l in LineasComanda)
            {
                Debug.WriteLine("LINEA preu: " + l);
            }

        }

        private void ClearPreview()
        {
            img_varietat.Source = null;
            tb_name.Text = "Name:";
            tb_color.Text = "Color:";
            tb_talla.Text = "Talla: ";
            tb_preu.Text = "Preu:";
            tb_qunatitat.Text = "Quantitat:";
            tb_dto.Text = "Descompte:";
            tb_impost.Text = "Impost:";
            tb_base_imposable.Text = "Total:";
            tb_total_impost.Text = "Total + impost:";
        }

        private void PreviewProd(int index)
        {
            LineaComanda OrderLine = LineasComanda[index];

            ViewModelVarietatProducte vmvp = new ViewModelVarietatProducte() { prod = OrderLine.Vareitat };
            img_varietat.Source = vmvp.ImageUrl;

            MongoDBConnection db = new MongoDBConnection();
            Producte prod = db.GetProductById(OrderLine.Vareitat.ProducteId);

            //Nom del prod
            tb_name.Text = prod.Nom + "";

            tb_color.Text = "Color: " + OrderLine.Vareitat.Color;
            tb_preu.Text = "Preu /u: " + OrderLine.Vareitat.Preu;

            tb_dto.Text = "Descompte: " + OrderLine.Vareitat.Descompte;
            tb_qunatitat.Text = OrderLine.Quantitat + "";

            tb_talla.Text = "Talla: " + OrderLine.Talla.NumTalla + "";

            double total = OrderLine.Quantitat * OrderLine.Vareitat.Preu;

            if (OrderLine.Vareitat.Descompte > 0)
            {
                total = total * (1 - (OrderLine.Vareitat.Descompte/100));
            }

            //* Impost! calcular?

            if (prod.Impost != null)
            {
                tb_impost.Text = "Impost: " + prod.Impost.Percentatge + "%";
                tb_total_impost.Text = "Total + impost: "+total * ((prod.Impost.Percentatge / 100) + 1) + "€";
            }

            tb_base_imposable.Text = "Total: "+total + "€";

            

        }

        private void lv_lines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int aux_index = lv_lines.SelectedIndex;
            if (aux_index != -1)
            {
                PreviewProd(aux_index);
            }
            else
            {
                ClearPreview();
            }
        }
        private void lv_lines_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int aux_index = lv_lines.SelectedIndex;
            if (aux_index != -1)
            {
                PreviewProd(aux_index);
            }
            else
            {
                ClearPreview();
            }
        }

        private void Button_Finish_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Show check and pay window!");
        }


        private async void Button_Save_Basket_Click(object sender, RoutedEventArgs e)
        {
            BasketData.SaveBasketData();

            //Mostrar mensaje de que se ha guardado correctamente?

        }



    }
}
