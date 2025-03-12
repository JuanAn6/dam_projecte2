using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using mongodb_classes.Models;
using MongoDBProject;

BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));

DotNetEnv.Env.TraversePath().Load();
var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
var settings = MongoClientSettings.FromConnectionString(connectionString);
var client = new MongoClient(settings);
var database = client.GetDatabase("bank");
var accountsCollection = database.GetCollection<Account>("accounts");
var transfersCollection = database.GetCollection<Transfer>("transfers");

var sampleDocument = new Account
{
    AccountId = "MDB829001337",
    AccountHolder = "Linus Torvalds",
    AccountType = "checking",
    Balance = 50352434,
    LastUpdated = DateTimeOffset.UtcNow
};


// TODO: Create an expression which inserts a single document into the `accounts` collection below:
await accountsCollection.InsertOneAsync(sampleDocument);


Console.WriteLine("Successfully inserted a document into the `accounts` collection!");