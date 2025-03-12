using DBModel.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.Text.Json;

namespace DBModel
{
    public class MongoDBConnection
    {
        private static IMongoDatabase database;
        private static MongoClient client = null;
        

        public MongoDBConnection()
        {
            
            string connectionString = "mongodb://localhost:27017";
            if(client == null)
            {
                client = new MongoClient(connectionString);
                database = client.GetDatabase("project");
                Debug.WriteLine("StartConnectionDatabase!!!");
                
            }

        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return database.GetCollection<BsonDocument>(collectionName);
        }

        public List<Client> GetClients()
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            List<Client> clients = new List<Client>();
            IMongoCollection<BsonDocument> clients_doc = mongoDB.GetCollection("clients");
            foreach (BsonDocument cli in clients_doc.Find(new BsonDocument()).ToList())
            {
                Client c = new Client(
                    cli.GetElement("_id").Value.AsObjectId,
                    cli.GetElement("nif").Value.AsString,
                    cli.GetElement("nom").Value.AsString,
                    cli.GetElement("cognom").Value.AsString,
                    cli.GetElement("email").Value.AsString,
                    new Direccio()
                );

                clients.Add(c);
            }


            return clients;
        }


        public Client GetClientByMail(string mail)
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            var filter = Builders<BsonDocument>.Filter.Eq("email", mail);
            var document = mongoDB.GetCollection("clients").Find(filter).FirstOrDefault();

            if (document == null) return null;
            
            Client c = new Client(
                document.GetElement("_id").Value.AsObjectId,
                document.GetElement("nif").Value.AsString,
                document.GetElement("nom").Value.AsString,
                document.GetElement("cognom").Value.AsString,
                document.GetElement("email").Value.AsString,
                new Direccio()
            );

            return c;
        }


        public List<Categoria> GetCategories()
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            List<Categoria> categoria = new List<Categoria>();
            IMongoCollection<BsonDocument> categories_doc = mongoDB.GetCollection("clients");
            foreach (BsonDocument cat in categories_doc.Find(new BsonDocument()).ToList())
            {
                var parent = cat.GetElement("parent_id");
                Categoria c = new Categoria(
                    cat.GetElement("_id").Value.AsObjectId,
                    cat.GetElement("nom").Value.AsString,
                    parent != null ? parent.Value.AsObjectId : null
                );

                categoria.Add(c);
            }

            return categoria;

        }

        public async Task InsertarDatosProductoAsync()
        {
            database.DropCollection("productes");
            database.DropCollection("varietats_productes");
            database.DropCollection("categories");
            var productesCollection = database.GetCollection<Producte>("productes");
            var varietatsCollection = database.GetCollection<VarietatProducte>("varietats_productes");
            var categoriesCollection = database.GetCollection<Categoria>("categories");

            Categoria categoria = new Categoria(
                ObjectId.GenerateNewId(),
                "Esport",
                null
            );

            await categoriesCollection.InsertOneAsync(categoria);

            Producte nouProducte = new Producte
            {
                Id = ObjectId.GenerateNewId(),
                Codi = "P001",
                Nom = "Sabates running x100",
                Descripcio = "<p>Sabates de running</p>",
                TipusImpostId = ObjectId.GenerateNewId(),
                Categories = new List<CategoriaProducte>
                {
                    new CategoriaProducte { CategoriaId = categoria.Id , Grau = 1 }
                }
            };

            await productesCollection.InsertOneAsync(nouProducte);

            VarietatProducte novaVarietat = new VarietatProducte
            {
                Id = ObjectId.GenerateNewId(),
                ProducteId = nouProducte.Id,
                Img = "sabates_running_blue.jpg",
                Color = "Blau",
                Preu = 19.99,
                Descompte = 0,
                Talles = new List<Talla>
                {
                    new Talla { NomTalla = "M", Stock = 10 },
                    new Talla { NomTalla = "L", Stock = 5 }
                }
            };

            await varietatsCollection.InsertOneAsync(novaVarietat);

            VarietatProducte novaVarietat2 = new VarietatProducte
            {
                Id = ObjectId.GenerateNewId(),
                ProducteId = nouProducte.Id,
                Img = "sabatas_running_red.jpg",
                Color = "Vermell",
                Preu = 21.99,
                Descompte = 0,
                Talles = new List<Talla>
                {
                    new Talla { NomTalla = "M", Stock = 8 },
                    new Talla { NomTalla = "L", Stock = 15 }
                }
            };

            await varietatsCollection.InsertOneAsync(novaVarietat2);
        }

        
    }
}
