using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBProject
{
    internal class Account
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("account_id")]
        public string AccountId { get; set; }

        [BsonElement("account_holder")]
        public string AccountHolder { get; set; }

        [BsonElement("account_type")]
        public string AccountType { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        [BsonElement("balance")]
        public decimal Balance { get; set; }

        [BsonElement("transfers_complete")]
        public string[] TransfersCompleted { get; set; }
    }
}
