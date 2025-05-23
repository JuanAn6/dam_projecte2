﻿using MongoDB.Bson.Serialization.Attributes;
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
        public ObjectId Id { get; set; }

        [BsonElement("client_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ClientId { get; set; }

        [BsonElement("data")]
        public DateTime Data { get; set; }

        [BsonElement("finalitzada")]
        public bool Finalitzada { get; set; }

        [BsonElement("tarjeta")]
        public Tarjeta Tarjeta { get; set; }

        [BsonElement("enviament")]
        public Enviament Enviament { get; set; }


        public Comanda()
        {

        }

    }

    public class Tarjeta
    {
        [BsonElement("numero")]
        public string Numero { get; set; }
        
        [BsonElement("cvv")]
        public int CVV { get; set; }

        [BsonElement("data_caducitat")]
        public DateTime DataCaducitat { get; set; }

        [BsonElement("nom_tarjeta")]
        public string NomTarjeta { get; set; }
    }

    public class Enviament
    {
        [BsonElement("tipus_enviament_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId EnviamentId { get; set; }

        [BsonElement("preu_enviament")]
        public double PreuEnviament { get; set; }

        [BsonElement("preu_base")]
        public double PreuBase { get; set; }

        [BsonElement("impost")]
        public double Impost { get; set; }
    }
}
