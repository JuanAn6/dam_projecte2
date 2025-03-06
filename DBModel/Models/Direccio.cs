using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DBModel.Models
{
    public class Direccio
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Adreca")]
        public string Adreca { get; set; }

        [BsonElement("cp")]
        public int Cp{ get; set; }

        [BsonElement("Poblacio")]
        public string Poblacio { get; set; }

        [BsonElement("Pais")]
        public string Pais { get; set; }

    }
}