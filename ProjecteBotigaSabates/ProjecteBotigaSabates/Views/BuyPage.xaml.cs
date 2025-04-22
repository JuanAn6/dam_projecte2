using DBModel;
using DBModel.Models;
using ProjecteBotigaSabates.StaticContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para BuyPage.xaml
    /// </summary>
    public partial class BuyPage : Page
    {

        public double total_impost = 0;
        public double total_base = 0;
        public double base_enviament = 0;
        public double total_enviament = 0;


        public BuyPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTotal();
        }

        public void UpdateTotal()
        {
            total_impost = BasketData.Products.Sum(i => ((i.Quantitat * i.Vareitat.Preu) * (1 - (i.Vareitat.Descompte / 100))) * ((i.Impost.Percentatge / 100) + 1));
            total_base = BasketData.Products.Sum(i => (i.Quantitat * i.Vareitat.Preu) * (1 - (i.Vareitat.Descompte / 100)));

            if (BasketData.Enviament.PreuBase > total_base)
            {
                base_enviament = BasketData.Enviament.Preu;
                total_enviament = BasketData.Enviament.Preu * ((BasketData.Enviament.Impost.Percentatge / 100) + 1);
            }
            else
            {
                base_enviament = 0;
                total_enviament = 0;
            }

            tb_base_enviament.Text = "Shipping base: " + base_enviament + "€";
            tb_total_enviament.Text = "Shipping total: " + total_enviament + "€";

            tb_base_comanda.Text = "Base: " + total_base + "€";
            tb_total_comanda.Text = "Total: " + (total_impost + total_enviament) + "€";


        }

        private async void Button_Cancel_Order_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new BasketPage());
        }

        private async void Button_Finish_Order_Click(object sender, RoutedEventArgs e)
        {
            MongoDBConnection db = new MongoDBConnection();
            
            
            BasketData.SaveBasketData();
            
            //Afegir a la comanda la targeta i el enviament

            Tarjeta ta = new Tarjeta();
            tb_info.Text = "";

            int cvv = 0;
            if (tb_card_cvv.Text.Count() == 3 && Int32.TryParse(tb_card_cvv.Text, out cvv))
            {
                ta.CVV = cvv;
            }
            else
            {
                tb_info.Text = "Invalid cvv!";
                return;
            }

            if (tb_card_date.SelectedDate.HasValue)
            {
                ta.DataCaducitat = tb_card_date.SelectedDate.Value;
            }
            else
            {
                tb_info.Text = "Invalid date!";
                return;
            }

            if (tb_card_name.Text.Count() > 3)
            {
                ta.NomTarjeta = tb_card_name.Text;
            }
            else
            {
                tb_info.Text = "Invalid name!";
                return;
            }


            if (rb_master_card.IsChecked != null && rb_master_card.IsChecked == true)
            {
                var regex = new Regex(@"^([0-9]{4}\s){3}[0-9]{4}$");

                if (regex.IsMatch(tb_card_number.Text))
                {
                    ta.Numero = tb_card_number.Text;
                }
                else
                {
                    tb_info.Text = "Invalid number! format: xxxx xxxx xxxx xxxx";
                    return;
                }
            }
            else if (rb_visa.IsChecked != null && rb_visa.IsChecked == true)
            {

                var regex = new Regex(@"^[0-9]{16}$");

                if (regex.IsMatch(tb_card_number.Text))
                {
                    ta.Numero = tb_card_number.Text;
                }
                else
                {
                    tb_info.Text = "Invalid number! format: xxxxxxxxxxxx";
                    return;
                }
            }
            else
            {
                tb_info.Text = "Select card type!";
                return;
            }

            BasketData.Comanda.Tarjeta = ta;
            
            
            Enviament enviament = new Enviament();

            enviament.EnviamentId = BasketData.Enviament.Id;
            enviament.PreuBase = BasketData.Enviament.Preu;
            

            enviament.PreuEnviament = BasketData.Enviament.Preu * ((BasketData.Enviament.Impost.Percentatge/100)+1);
            enviament.Impost = BasketData.Enviament.Impost.Percentatge;


            BasketData.Comanda.Enviament = enviament;


            //Canviar la comanda com finalitzada, actualitzar la data
            BasketData.Comanda.Finalitzada = true;
            BasketData.Comanda.Data = DateTime.Now;

            await db.CloseOrder(BasketData.Comanda);

            //Actualitzar el stock dels productes

            foreach(LineaComanda l in BasketData.Products)
            {
                int stock = db.GetStockTallaVarietat(l.Vareitat.Id, l.Talla);
                int new_stock = stock - l.Quantitat;
                await db.SetStockVarietat(l.Vareitat.Id, l.Talla, new_stock);
            }

            //Generar la factura, recuperant el numero correlatiu
            
            Factura f = new Factura();

            string number = db.GetSerialNumber("factures");
            f.Numero = number;
            f.Tarjeta = ta;
            f.Enviament = enviament;
            f.DataFactura = DateTime.Now;
            f.ComandaId = BasketData.Comanda.Id;
            f.ClientId = ClientConnected.AuthClient.Id;
            f.BaseImposable = total_base;
            f.Total = total_impost + total_enviament;

            //Generar les lineas en la factura
            List<LineaFactura> list_linea_factura = new List<LineaFactura>();
            foreach(LineaComanda l in BasketData.Products)
            {
                LineaFactura lf = new LineaFactura();

                lf.Varietat = l.Vareitat;
                lf.Producte = db.GetProductById(l.Vareitat.ProducteId);
                lf.NumTalla = l.Talla.NumTalla;

                lf.Preu = l.Preu;
                lf.Descompte = l.Descompte;
                lf.Quantitat = l.Quantitat;
                lf.Base = (l.Preu * l.Quantitat) * (1-(l.Descompte / 100));
                lf.Impost = l.Impost.Percentatge;
                lf.ImportTotal = lf.Base * ((l.Impost.Percentatge / 100) + 1);

                list_linea_factura.Add(lf);

            }

            f.LineasFactura = list_linea_factura;

            //Enregistrar la factura

            await db.SaveFactura(f);

            //Enviar la factura per mail?




            //Netejar la comanda local de la app

            tb_card_cvv.IsEnabled = false;
            tb_card_name.IsEnabled = false;
            tb_card_date.IsEnabled = false;
            tb_card_number.IsEnabled = false;
            btn_cancel.IsEnabled = false;
            btn_save.IsEnabled = false;


            //Enviar el report(factura) per mail, també el guardare en filesystem

            Report.DownloadReport(f.Numero);



            //Reinicia la cistella per poder continuar
            BasketData.Reset();
            tb_info.Text = "Done!";

        }


    }
}
