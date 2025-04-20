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

        [BsonElement("quantitat")]
        public int Quantitat { get; set; }

        [BsonElement("preu")]
        public double Preu { get; set; }

        [BsonElement("descompte")]
        public double Descompte { get; set; }

        [BsonElement("impost")]
        public double Impost { get; set; }

        [BsonElement("base")]
        public double Base { get; set; }

        [BsonElement("import_total")]
        public double ImportTotal { get; set; }

        [BsonElement("varitat")]
        public VarietatProducte Varietat { get; set; }
        
        [BsonElement("num_talla")]
        public int NumTalla { get; set; }

        [BsonElement("producte")]
        public Producte Producte { get; set; }

    }
}
