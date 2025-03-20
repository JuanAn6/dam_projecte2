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
            IMongoCollection<BsonDocument> categories_doc = mongoDB.GetCollection("categories");
            foreach (BsonDocument cat in categories_doc.Find(new BsonDocument()).ToList())
            {
                
                Categoria c = new Categoria(
                    cat.GetElement("_id").Value.AsObjectId,
                    cat.GetElement("nom").Value.AsString,
                    cat.GetElement("parent_id").Value is BsonNull ? null : cat.GetElement("parent_id").Value.AsObjectId
                );

                categoria.Add(c);
            }

            return categoria;

        }


        public List<Producte> GetAllProducts()
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            List<Producte> products = new List<Producte>();
            IMongoCollection<BsonDocument> products_doc = mongoDB.GetCollection("productes");
            foreach (BsonDocument prod in products_doc.Find(new BsonDocument()).ToList())
            {

                //prod.GetElement("categories").Value.ToList();

                Producte p = new Producte(
                    prod.GetElement("_id").Value.AsObjectId,
                    prod.GetElement("codi").Value.AsString,
                    prod.GetElement("nom").Value.AsString,
                    prod.GetElement("descripcio").Value.AsString,
                    prod.GetElement("tipus_impost_id").Value.AsObjectId,
                    new List<CategoriaProducte>()
                );

                products.Add(p);
            }


            return products;
        }


        public List<VarietatProducte> GetAllVarietatsOfProducts(string prod)
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            var filter = Builders<BsonDocument>.Filter.Eq("producte_id",  new ObjectId(prod) );
            
            List<VarietatProducte> products = new List<VarietatProducte>();
            var collection = mongoDB.GetCollection("varietat_producte");
            List<BsonDocument> products_doc = collection.Find(filter).ToList();

            foreach (BsonDocument vp in products_doc)
            {

                VarietatProducte p = new VarietatProducte(
                    vp.GetElement("_id").Value.AsObjectId,
                    vp.GetElement("producte_id").Value.AsObjectId,
                    vp.GetElement("img").Value.AsString,
                    vp.GetElement("color").Value.AsString,
                    vp.GetElement("preu").Value.AsInt32,
                    vp.GetElement("dto").Value.AsInt32,
                    new List<Talla>()
                );

                products.Add(p);
            }


            return products;
        }






        /*

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



        */




    }
}
