using DBModel;
using DBModel.Models;
using ProjecteBotigaSabates.StaticContent;
using ProjecteBotigaSabates.ViewModels;
using ProjecteBotigaSabates.Views;
using System;
using System.Collections.Generic;
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

namespace ProjecteBotigaSabates.Components
{
    /// <summary>
    /// Lógica de interacción para UCOrderLine.xaml
    /// </summary>
    public partial class UCOrderLine : UserControl
    {

        public LineaComanda OrderLine
        {
            get { return (LineaComanda)GetValue(OrderLineProperty); }
            set { SetValue(OrderLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderLineProperty =
            DependencyProperty.Register("OrderLine", typeof(LineaComanda), typeof(UCOrderLine), new PropertyMetadata(null));

        ViewModelVarietatProducte vmvp;
        Producte Prod;

        public UCOrderLine()
        {
            InitializeComponent();
        }

        private void uc_Loaded(object sender, RoutedEventArgs e)
        {
            vmvp = new ViewModelVarietatProducte() { prod = OrderLine.Vareitat };
            img_varietat.Source = vmvp.ImageUrl;

            LoadDataUC();

        }


        public void LoadDataUC()
        {
            MongoDBConnection db = new MongoDBConnection();
            Prod = db.GetProductById(OrderLine.Vareitat.ProducteId);

            //Nom del prod
            tb_name.Text = Prod.Nom + "";

            tb_color.Text = "Color: "+OrderLine.Vareitat.Color;
            tb_preu.Text = "Preu /u: " + OrderLine.Vareitat.Preu.ToString("F2");

            tb_dto.Text = "Descompte: " + OrderLine.Vareitat.Descompte.ToString("F2");
            tb_qunatitat.Text = OrderLine.Quantitat+"";

            tb_talla.Text = "Talla: "+OrderLine.Talla.NumTalla+"";

            double total = OrderLine.Quantitat * OrderLine.Vareitat.Preu;

            if(OrderLine.Vareitat.Descompte > 0)
            {
                total = total * (1 - (OrderLine.Vareitat.Descompte / 100));
            }

            //* Impost! calcular?
            
            if(Prod.Impost != null)
            {
                tb_impost.Text = "Impost: "+Prod.Impost.Percentatge.ToString("F2") + "%";
                tb_total.Text = (total * ((Prod.Impost.Percentatge / 100) + 1)).ToString("F2") + "€";
            }
            else
            {
                tb_total.Text = total.ToString("F2") + "€";
            }

            
            //impost show??
            
            

        }



        private void Button_Add_Prod_Click(object sender, RoutedEventArgs e)
        {
            int aux_qt = OrderLine.Quantitat;
            Talla aux_talla = OrderLine.Vareitat.Talles.Find(e => e.NumTalla == OrderLine.Talla.NumTalla);
            if (aux_talla != null && aux_talla.Stock >= aux_qt + 1)
            {
                OrderLine.Quantitat = aux_qt + 1;
                BasketData.Products[BasketData.Products.IndexOf(OrderLine)].Quantitat = OrderLine.Quantitat;
                LoadDataUC();
            }
            CheckEnableDisableButtons();
        }

        private void Button_Minus_Prod_Click(object sender, RoutedEventArgs e)
        {
            int aux_qt = OrderLine.Quantitat;
            Talla aux_talla = OrderLine.Vareitat.Talles.Find(e => e.NumTalla == OrderLine.Talla.NumTalla);
            if (aux_talla != null && aux_qt - 1 > 0)
            {
                OrderLine.Quantitat = aux_qt -1;
                BasketData.Products[BasketData.Products.IndexOf(OrderLine)].Quantitat = OrderLine.Quantitat;
                LoadDataUC();
            }
            CheckEnableDisableButtons();
        }

        private void CheckEnableDisableButtons()
        {
            Talla aux_talla = OrderLine.Vareitat.Talles.Find(e => e.NumTalla == OrderLine.Talla.NumTalla);
            
            if(aux_talla.Stock > OrderLine.Quantitat)
            {
                btn_add.IsEnabled = true;
            }
            else
            {
                btn_add.IsEnabled = false;
            }

            if (OrderLine.Quantitat <= 1)
            {
                btn_minus.IsEnabled = false;
            }
            else
            {
                btn_minus.IsEnabled = true;
            }

            //Update total de la cistella
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            BasketPage bp = (BasketPage)mainWindow.MainFrame.Content;
            bp.UpdateTotal();

        }

    }
}
