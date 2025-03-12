using DBModel;
using ViewModel.Clases;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBModel.Models;
using ProjecteBotigaSabates.StaticContent;

namespace ProjecteBotigaSabates.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SelectUserPage: Page
    {
        public SelectUserPage()
        {
            InitializeComponent();
        }
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        MongoDBConnection mongoDBConnection;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow.tb_info.Text = "";
            ClientConnected.AuthClient = null;
            mainWindow.tb_user_name.Text = "Sign in!";

            try
            {
                mongoDBConnection = new MongoDBConnection();

                IMongoCollection<BsonDocument> empresa = mongoDBConnection.GetCollection("dades_empresa");
                foreach (BsonDocument doc in empresa.Find(new BsonDocument()).ToList())
                {
                    Debug.WriteLine(doc.ToJson());
                }


                List<Client> clients = mongoDBConnection.GetClients();

                List<string> cb_values = clients.Select(item => item.Email).ToList();
                cb_values = cb_values.Prepend("Selecciona un client").ToList();
                cb_clients.ItemsSource = cb_values;
                cb_clients.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
               
                mainWindow.tb_info.Text = "Connection failed! \n Try to restart...";
            }

        }










        private async void InsertData()
        {
            await mongoDBConnection.InsertarDatosProductoAsync();
            Debug.WriteLine("Data inserted!");

            IMongoCollection<BsonDocument> categories = mongoDBConnection.GetCollection("categories");
            PrintInfoDocument(categories.Find(new BsonDocument()).FirstOrDefault());
            IMongoCollection<BsonDocument> productes = mongoDBConnection.GetCollection("productes");
            PrintInfoDocument(productes.Find(new BsonDocument()).FirstOrDefault());
            IMongoCollection<BsonDocument> varietats_productes = mongoDBConnection.GetCollection("varietats_productes");
            PrintInfoDocument(varietats_productes.Find(new BsonDocument()).FirstOrDefault());

        }

        private void Button_Click_Insert_Data(object sender, RoutedEventArgs e)
        {
            InsertData();
            mainWindow.tb_info.Text += "Data inserted!\n";
        }

        private void PrintInfoDocument(BsonDocument doc)
        {
            Debug.WriteLine("doc: " + doc.ToString());
            mainWindow.tb_info.Text += doc.ToString() + "\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cb_clients.SelectedItem != null)
            {
                string mail = (string)cb_clients.SelectedItem;

                Client c = mongoDBConnection.GetClientByMail(mail);
                if(c == null)
                {
                    mainWindow.tb_info.Text = "Selecciona un client valid!";
                }
                else
                {
                    ClientConnected.AuthClient = c;
                    Debug.WriteLine(ClientConnected.AuthClient.ToString());
                    mainWindow.grid_MainMenu.Opacity = 1;
                    NavigationService.Navigate(new StartPage());
                }
            }
        }
    }
}