using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class Enviament
    {
        [BsonElement("enviament_id")]
        public ObjectId EnviamentId { get; set; }

        [BsonElement("descripcio")]
        public string Descripcio { get; set; }

        [BsonElement("preu")]
        public double Preu { get; set; }

        [BsonElement("preu_base")]
        public double PreuBase { get; set; }

        [BsonElement("impost")]
        public double Impost { get; set; }
    }
}
