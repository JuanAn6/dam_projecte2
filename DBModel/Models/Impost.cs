using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class Impost
    {
        [BsonElement("impost_id")]
        public ObjectId ImpostId { get; set; }

        [BsonElement("impost_perentatge")]
        public double ImpostPercentatge { get; set; }
    }
}
