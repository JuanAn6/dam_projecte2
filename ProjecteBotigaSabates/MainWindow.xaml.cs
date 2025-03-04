using DBModel;
using MongoDB.Bson;
using MongoDB.Driver;
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

namespace ProjecteBotigaSabates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        MongoDBConnection mongoDBConnection;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mongoDBConnection = new MongoDBConnection();

            IMongoCollection<BsonDocument> empresa = mongoDBConnection.GetCollection("dades_empresa");
            foreach(BsonDocument doc in empresa.Find(new BsonDocument()).ToList()) {
                Debug.WriteLine(doc.ToJson());
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            InsertData();
            
            tb_info.Text += "Data inserted!\n";

        }

        private void PrintInfoDocument(BsonDocument doc)
        {
            Debug.WriteLine("doc: "+doc.ToString());
            tb_info.Text += doc.ToString() + "\n";
        }
    }
}