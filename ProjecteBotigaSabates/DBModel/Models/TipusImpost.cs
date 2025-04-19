using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class TipusImpost
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("tipus")]
        public string Tipus { get; set; }

        [BsonElement("percentatge")]
        public double Percentatge { get; set; }

        public TipusImpost(ObjectId id, string tipus, double percentatge)
        {
            this.Id = id;
            this.Tipus = tipus;
            this.Percentatge = percentatge;
        }
    }
}
