using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class Talla
    {
        [BsonElement("talla")]
        public string NomTalla { get; set; }

        [BsonElement("stock")]
        public int Stock { get; set; }
    }
    
}
