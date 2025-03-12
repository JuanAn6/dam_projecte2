using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class Producte
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("codi")]
        public string Codi { get; set; }

        [BsonElement("nom")]
        public string Nom { get; set; }

        [BsonElement("descripcio")]
        public string Descripcio { get; set; }

        [BsonElement("tipus_impost_id")]
        public ObjectId TipusImpostId { get; set; }

        [BsonElement("categories")]
        public List<CategoriaProducte> Categories { get; set; }
    }
}
