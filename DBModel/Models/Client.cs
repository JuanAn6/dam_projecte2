using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class Client
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nif")]
        public string Nif { get; set; }

        [BsonElement("nom")]
        public string Nom { get; set; }

        [BsonElement("cognom")]
        public string Cognom { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("direccio")]
        public Direccio Direccio { get; set; }

        public Client(ObjectId id, string nif, string nom, string cognom, string email, Direccio direccio)
        {
            Id = id;
            Nif = nif;
            Nom = nom;
            Cognom = cognom;
            Email = email;
            Direccio = direccio;
        }
    }
}
