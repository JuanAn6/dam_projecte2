using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Models
{
    public class Comanda
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("client_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClientId { get; set; }

        [BsonElement("data")]
        public DateTime Data { get; set; }

        [BsonElement("finalitzada")]
        public bool Finalitzada { get; set; }

        [BsonElement("tarjeta")]
        public Tarjeta Tarjeta { get; set; }

        [BsonElement("enviament")]
        public Enviament Enviament { get; set; }
    }

    public class Tarjeta
    {
        [BsonElement("cvv")]
        public string CVV { get; set; }

        [BsonElement("data_caducitat")]
        public string DataCaducitat { get; set; }

        [BsonElement("nom_tarjeta")]
        public string NomTarjeta { get; set; }
    }

    public class Enviament
    {
        [BsonElement("tipus_enviament_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EnviamentId { get; set; }

        [BsonElement("preu_enviament")]
        public decimal PreuEnviament { get; set; }
    }
}
