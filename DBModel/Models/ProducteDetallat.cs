using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class ProducteDetallat
    {
        [BsonElement("varietat_producte_id")]
        public ObjectId VarietatProducteId { get; set; }

        [BsonElement("nom_producte")]
        public string NomProducte { get; set; }

        [BsonElement("color")]
        public string Color { get; set; }

        [BsonElement("talla")]
        public string Talla { get; set; }
    }
}
