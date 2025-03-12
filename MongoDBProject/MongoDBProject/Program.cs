// See https://aka.ms/new-console-template for more information
using MongoDB.Driver;

var mongodbUrl = "mongodb+srv://juan:juan1234@cluster0.oqsm0.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

var client = new MongoClient(mongodbUrl);

var dbList = client.ListDatabases().ToList();

Console.WriteLine("The list of databases on this server is: ");

foreach (var db in dbList)
{
    Console.WriteLine(db);
}
