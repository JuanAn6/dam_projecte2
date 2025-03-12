using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class CategoriaProducte
    {
        [BsonElement("categoria_id")]
        public ObjectId CategoriaId { get; set; }

        [BsonElement("grau")]
        public int Grau { get; set; }
    }
}
