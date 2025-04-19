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
        public ObjectId? Id { get; set; }

        private int qt;

        [BsonElement("quantitat")]
        public int Quantitat
        {
            get { return qt; }
            set {
                qt = value;
                Preu = Preu * qt;
            } 
        }

        [BsonElement("preu")]
        public double Preu { get; set; }

        [BsonElement("descompte")]
        public double Descompte { get; set; }

        [BsonElement("impost")]
        public Impost Impost { get; set; }

        [BsonElement("varietat_producte_id")]
        public VarietatProducte Vareitat { get; set; }

        [BsonElement("talla")]
        public Talla Talla { get; set; }

        public string ComandaId { get; set; }

        public LineaComanda(int quantitat, VarietatProducte vp, Talla talla)
        {
            Id = null;
            Descompte = 0;
            Preu = vp.Preu;
            Quantitat = quantitat;
            Impost = null;
            Vareitat = vp;
            Talla = talla;
            
        }


    }
}
