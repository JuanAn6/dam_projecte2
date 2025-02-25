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
    }
}