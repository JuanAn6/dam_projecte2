using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DBModel.Models
{
    public class VarietatProducte
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("producte_id")]
        public ObjectId ProducteId { get; set; }

        [BsonElement("img")]
        public string Img { get; set; }

        [BsonElement("color")]
        public string Color { get; set; }

        [BsonElement("preu")]
        public double Preu { get; set; }

        [BsonElement("descompte")]
        public double Descompte { get; set; }

        [BsonElement("talles")]
        public List<Talla> Talles { get; set; }

        

        public VarietatProducte(ObjectId id, ObjectId producteId, string img, string color, double preu, double descompte, List<Talla> talles)
        {
            Id = id;
            ProducteId = producteId;
            Img = img;
            Color = color;
            Preu = preu;
            Descompte = descompte;
            Talles = talles;
        }
    }
}
