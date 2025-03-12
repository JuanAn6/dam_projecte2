using DBModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ViewModel.Clases
{
    class Client
    {
        public Client()
        {
        }

        public Client(string id, string nif, string nom, string cognom, string email, Direccio direccio)
        {
            Id = id;
            Nif = nif;
            Nom = nom;
            Cognom = cognom;
            Email = email;
            Direccio = direccio;
        }

        public string Id { get; set; }
       
        public string Nif { get; set; }
        
        public string Nom { get; set; }
        
        public string Cognom { get; set; }
        
        public string Email { get; set; }

        public Direccio Direccio { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Client client &&
                   Id == client.Id &&
                   Nif == client.Nif;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nif, Nom, Cognom, Email, Direccio);
        }




        


    }
}
