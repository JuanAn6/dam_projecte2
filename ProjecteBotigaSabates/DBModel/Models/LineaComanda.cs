using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DBModel.Models
{
    public class LineaComanda : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("quantitat")]
        public int Quantitat { get; set; }
        
        [BsonElement("preu")]
        public double Preu { get; set; }

        [BsonElement("descompte")]
        public double Descompte { get; set; }

        [BsonElement("impost")]
        public TipusImpost Impost { get; set; }

        [BsonElement("varietat_producte_id")]
        public VarietatProducte Vareitat { get; set; }

        [BsonElement("talla")]
        public Talla Talla { get; set; }

        [BsonElement("comanda_id")]
        public ObjectId ComandaId { get; set; }

        public LineaComanda(int quantitat, VarietatProducte vp, Talla talla)
        {

            Descompte = 0;
            Preu = vp.Preu;
            Quantitat = quantitat;
            Impost = null;
            Vareitat = vp;
            Talla = talla;
            
        }


    }
}
