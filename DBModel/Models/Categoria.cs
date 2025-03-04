using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class Categoria
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nom")]
        public string Nom { get; set; }

        [BsonElement("parent_id")]
        public ObjectId? ParentId { get; set; }
    }
}
