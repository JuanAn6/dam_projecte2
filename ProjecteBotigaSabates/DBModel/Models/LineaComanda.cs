using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class LineaComanda
    {
        [BsonId]
        public ObjectId? Id { get; set; }

        [BsonElement("quantitat")]
        public int Quantitat { get; set; }

        [BsonElement("preu")]
        public double Preu { get; set; }

        [BsonElement("descompte")]
        public double Descompte { get; set; }

        [BsonElement("impost")]
        public Impost Impost { get; set; }

        [BsonElement("varietat_producte_id")]
        public VarietatProducte Vareitat { get; set; }

        [BsonElement("talla")]
        public Talla talla { get; set; }

        public LineaComanda(int quantitat, VarietatProducte vp, Talla talla)
        {
            Id = null;
            Descompte = 0;
            Preu = vp.Preu * quantitat;
            Impost = null;!!

        }

    }
}
