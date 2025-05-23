﻿using MongoDB.Bson.Serialization.Attributes;
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
        public string Numero { get; set; }

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

        [BsonElement("tarjeta")]
        public Tarjeta Tarjeta { get; set; }

        [BsonElement("enviament")]
        public Enviament Enviament { get; set; }
        
        [BsonElement("lineas_factura")]
        public List<LineaFactura> LineasFactura{ get; set; }

    }
}
