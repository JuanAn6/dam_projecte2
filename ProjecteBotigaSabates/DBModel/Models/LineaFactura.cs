using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class LineaFactura
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("factura_id")]
        public ObjectId FacturaId { get; set; }

        [BsonElement("quantitat")]
        public int Quantitat { get; set; }

        [BsonElement("preu")]
        public double Preu { get; set; }

        [BsonElement("descompte")]
        public double Descompte { get; set; }

        [BsonElement("impost")]
        public Impost Impost { get; set; }

        [BsonElement("producte")]
        public ProducteDetallat Producte { get; set; }
    }
}
