using DBModel.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using Windows.Storage;

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

        public Categoria GetCategoriaById(Categoria category)
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            IMongoCollection<BsonDocument> categories_doc = mongoDB.GetCollection("categories");


            var filter = Builders<BsonDocument>.Filter.Eq("_id", category.ParentId);
            BsonDocument cat = categories_doc.Find(filter).First();

            if(cat != null) { 

                Categoria c = new Categoria(
                    cat.GetElement("_id").Value.AsObjectId,
                    cat.GetElement("nom").Value.AsString,
                    cat.GetElement("parent_id").Value is BsonNull ? null : cat.GetElement("parent_id").Value.AsObjectId
                );

                return c;
            }

            return null;

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

        public int GetCountProducts()
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            List<Producte> products = new List<Producte>();
            IMongoCollection<BsonDocument> products_doc = mongoDB.GetCollection("productes");
            long count = products_doc.CountDocuments(new BsonDocument());
            
            //Per el projecte tenim suficient amb un int
            return (int)count;
        }

        public Producte GetProductById(ObjectId prod_id)
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            
            IMongoCollection<BsonDocument> products_doc = mongoDB.GetCollection("productes");
            BsonDocument prod = products_doc.Find(Builders<BsonDocument>.Filter.Eq("_id", prod_id)).ToList().First();

            if (prod != null)
            {
                Producte p = new Producte(
                    prod.GetElement("_id").Value.AsObjectId,
                    prod.GetElement("codi").Value.AsString,
                    prod.GetElement("nom").Value.AsString,
                    prod.GetElement("descripcio").Value.AsString,
                    prod.GetElement("tipus_impost_id").Value.AsObjectId,
                    new List<CategoriaProducte>()
                );


                IMongoCollection<BsonDocument> impost_doc = mongoDB.GetCollection("tipus_impostos");
                BsonDocument impost = impost_doc.Find(Builders<BsonDocument>.Filter.Eq("_id", p.TipusImpostId)).ToList().First();

                if(impost != null)
                {
                    TipusImpost ti = new TipusImpost(
                        impost.GetElement("_id").Value.AsObjectId,
                        impost.GetElement("tipus").Value.AsString,
                        (impost.GetElement("percentatge").Value.IsInt32 ? impost.GetElement("percentatge").Value.AsInt32 : impost.GetElement("percentatge").Value.AsDouble)
                    );
                    p.Impost = ti;
                }

                return p;
            }
            else
            {
                return null;
            }

            
        }


        public List<Producte> GetPageProducts(int productsPerPage, int numPage)
        {
            return GetPageProductsWithFilters(productsPerPage, numPage, "", null, 0);
        }

        public List<Producte> GetPageProductsWithFilters(int productsPerPage, int numPage, string search, Categoria cat, int slideVal)
        {

            MongoDBConnection mongoDB = new MongoDBConnection();
            List<Producte> products = new List<Producte>();
            IMongoCollection<BsonDocument> products_doc = mongoDB.GetCollection("productes");
            int skipElements = numPage * productsPerPage;


            List<FilterDefinition<BsonDocument>> filters = new List<FilterDefinition<BsonDocument>>();

            //Filtre per busqueda

            if (!search.Equals(""))
            {
                filters.Add(Builders<BsonDocument>.Filter.Eq("nom", new BsonRegularExpression(search, "i")));
            }



            //Filtre per categoria
            if (cat != null)
            {
                Debug.WriteLine("RECURSIVA CATS: ");
                List<Categoria> categories = GetChildrenCategories(cat);
                foreach (Categoria aux in categories)
                {
                    Debug.WriteLine(aux);
                }
                if (categories.Count() > 0)
                {
                    IEnumerable<ObjectId> categoryId = categories.Select(c_aux => c_aux.Id);
                    filters.Add(Builders<BsonDocument>.Filter.In("categories.categoria_id", categoryId));
                }
            }

            //Filtre per preu

            if (slideVal != 0)
            {
                List<ObjectId> ids = new List<ObjectId>();
                IMongoCollection<BsonDocument> var_products_doc = mongoDB.GetCollection("varietat_producte");
                
                List<BsonDocument> vars = var_products_doc.Find(Builders<BsonDocument>.Filter.Gt("preu", (double)slideVal)).ToList();

                foreach (BsonDocument var_prod in vars)
                {
                    Debug.WriteLine("a:" + var_prod.GetElement("producte_id").Value.AsObjectId);
                    ids.Add(var_prod.GetElement("producte_id").Value.AsObjectId);
                }

                filters.Add(Builders<BsonDocument>.Filter.In("_id", ids));

            }

            FilterDefinition<BsonDocument> filter = FilterDefinition<BsonDocument>.Empty;
            if (filters.Count > 0)
            {
                filter = Builders<BsonDocument>.Filter.And(filters);
            }

            //COnsulta:
            List<BsonDocument> prods_filtred = products_doc.Find(filter).Skip(skipElements).Limit(productsPerPage).ToList();


            foreach (BsonDocument prod in prods_filtred)
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

        private List<Categoria> GetChildrenCategories(Categoria cat)
        {
            List<Categoria> cats = new List<Categoria>();
            cats.Add(cat);
            List<Categoria> cats_child = GetChildrenCategoriaByCategory(cat);

            foreach (Categoria aux in cats_child)
            {
                List<Categoria> cats_aux = GetChildrenCategories(aux);
                foreach (Categoria aux2 in cats_aux)
                {
                    cats.Add(aux2);
                }
            }

            return cats;
        }

        public List<Categoria> GetChildrenCategoriaByCategory(Categoria category)
        {


            MongoDBConnection mongoDB = new MongoDBConnection();
            List<Categoria> categoria = new List<Categoria>();
            IMongoCollection<BsonDocument> categories_doc = mongoDB.GetCollection("categories");
            var filter = Builders<BsonDocument>.Filter.Eq("parent_id", category.Id);
            foreach (BsonDocument cat in categories_doc.Find(filter).ToList())
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

        public List<VarietatProducte> GetAllVarietatsOfProducts(string prod)
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            var filter = Builders<BsonDocument>.Filter.Eq("producte_id",  new ObjectId(prod) );
            
            List<VarietatProducte> products = new List<VarietatProducte>();
            var collection = mongoDB.GetCollection("varietat_producte");
            List<BsonDocument> products_doc = collection.Find(filter).ToList();

            foreach (BsonDocument vp in products_doc)
            {

                List<Talla> talles = new List<Talla>();

                if (vp.Contains("talles"))
                {
                    foreach (var talla in vp.GetElement("talles").Value.AsBsonArray)
                    {
                        BsonDocument t = talla.AsBsonDocument;
                        int numTalla = t.GetElement("talla").Value.AsInt32;
                        int tallaStock= t.GetElement("stock").Value.AsInt32;
                        talles.Add(new Talla(numTalla, tallaStock));
                    }

                }


                VarietatProducte p = new VarietatProducte(
                    vp.GetElement("_id").Value.AsObjectId,
                    vp.GetElement("producte_id").Value.AsObjectId,
                    vp.GetElement("img").Value.AsString,
                    vp.GetElement("color").Value.AsString,
                    (vp.GetElement("preu").Value.IsInt32 ? vp.GetElement("preu").Value.AsInt32 : vp.GetElement("preu").Value.AsDouble),
                    (vp.GetElement("dto").Value.IsInt32 ? vp.GetElement("dto").Value.AsInt32 : vp.GetElement("dto").Value.AsDouble),
                    talles
                );

                products.Add(p);
            }


            return products;
        }

        public Comanda GetOpenOrder(ObjectId id)
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            
            List<FilterDefinition<BsonDocument>> filters = new List<FilterDefinition<BsonDocument>>();
            filters.Add(Builders<BsonDocument>.Filter.Eq("finalitzada", false));
            Debug.WriteLine("Client_id: " + id.ToString());
            filters.Add(Builders<BsonDocument>.Filter.Eq("client_id", id));

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.And(filters);

            var collection = mongoDB.GetCollection("comandes");

            List<BsonDocument> comandes_doc = collection.Find(filter).ToList();

            if(comandes_doc.Count() == 1)
            {
                BsonDocument cm = comandes_doc[0];
                Comanda comanda = new Comanda();
                comanda.Id = cm.GetElement("_id").Value.AsObjectId;
                comanda.ClientId = id;
                comanda.Data = ((DateTime) (cm.GetElement("data").Value.IsBsonNull? new DateTime() : cm.GetElement("data").Value ));
                comanda.Finalitzada = cm.GetElement("finalitzada").Value.AsBoolean;

                return comanda;
            }
            else
            {
                return null;
            }
            

        }

        public async Task<ObjectId> SaveActualBasket(Comanda c)
        {
            Debug.WriteLine("Comanda: "+c);
            await database.GetCollection<Comanda>("comandes").InsertOneAsync(c);
            return c.Id;
        }

        public async Task UpdateActualBasket(Comanda comanda)
        {
            var coleccion = database.GetCollection<Comanda>("comandes");

            var filter = Builders<Comanda>.Filter.Eq(c => c.Id, comanda.Id);
            var update = Builders<Comanda>.Update.Set(c => c.Data, DateTime.Now);

            await coleccion.UpdateOneAsync(filter, update);

        }


        public async Task<ObjectId> SaveActualBasketLine(LineaComanda l)
        {
            await database.GetCollection<LineaComanda>("lineas_comanda").InsertOneAsync(l);
            return l.Id;
        }

        public async Task<ObjectId> UpdateActualBasketLine(LineaComanda l)
        {
            var coleccion = database.GetCollection<LineaComanda>("lineas_comanda");
            var filter = Builders<LineaComanda>.Filter.Eq(line => line.Id, l.Id);
            await coleccion.ReplaceOneAsync(filter, l);
            return l.Id;
        }

        public List<LineaComanda> GetLineasComanda(ObjectId id)
        {
            MongoDBConnection mongoDB = new MongoDBConnection();
            List<LineaComanda> lineas = new List<LineaComanda>();
            var lineas_colection = database.GetCollection<LineaComanda>("lineas_comanda");
            var filter = Builders<LineaComanda>.Filter.Eq("comanda_id", id);
            foreach (LineaComanda l in lineas_colection.Find(filter).ToList())
            {
                Debug.WriteLine("LineaLoad: " + l.Id);
                lineas.Add(l);
            }

            return lineas;
        }

        public async Task DeleteLine(ObjectId id)
        {
            var colection = database.GetCollection<LineaComanda>("lineas_comanda");

            var filter = Builders<LineaComanda>.Filter.Eq(c => c.Id, id);
            DeleteResult result = await colection.DeleteOneAsync(filter);
            Debug.WriteLine("DeleteLine! "+result.DeletedCount);
        }


        public List<TipusEnviament> GetTipusEnviament()
        {
            return database.GetCollection<TipusEnviament>("tipus_enviament").Find(new BsonDocument()).ToList();
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
