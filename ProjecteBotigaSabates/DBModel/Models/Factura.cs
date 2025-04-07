using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class Factura
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("num")]
        public int Numero { get; set; }

        [BsonElement("comanda_id")]
        public ObjectId ComandaId { get; set; }

        [BsonElement("client_id")]
        public ObjectId ClientId { get; set; }

        [BsonElement("base_imposable")]
        public double BaseImposable { get; set; }

        [BsonElement("total")]
        public double Total { get; set; }

        [BsonElement("data_factura")]
        public DateTime DataFactura { get; set; }

        [BsonElement("enviament")]
        public TipusEnviament Enviament { get; set; }

    }
}
