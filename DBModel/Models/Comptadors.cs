using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{


    public class Comptadors
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("comptador")]
        public int NumeroComptador { get; set; }

        [BsonElement("collection")]
        public string Collection { get; set; }
    }
}
