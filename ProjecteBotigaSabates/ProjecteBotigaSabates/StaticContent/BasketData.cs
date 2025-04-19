using DBModel;
using DBModel.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteBotigaSabates.StaticContent
{
    class BasketData
    {
        //Carregar la comanda que es fa servir com "carro" en el moment de fer el login!
        public static Comanda Comanda;
        public static List<LineaComanda> Products;

        private MongoDBConnection MongoDB;

        public BasketData()
        {
            MongoDB = new MongoDBConnection();
            if(Products == null)
            {
                Products = new List<LineaComanda>();
            }

            if(Comanda == null)
            {
                //Cargar la comanda si existeix una a mitjes


                Comanda = MongoDB.GetOpenOrder(ClientConnected.AuthClient);
                
                //Crear la comanda si no existeix cap

                if (Comanda == null)
                {
                    Debug.WriteLine("No comanda en la base de datos!");
                    Comanda comanda = new Comanda();
                    comanda.Id = "";
                    comanda.ClientId = ClientConnected.AuthClient.Id.ToString();
                    comanda.Data = new DateTime();
                    comanda.Finalitzada = false;
                }

            }

        }

        public static void AddLine(LineaComanda linea)
        {
            if (!Comanda.Id.Equals(""))
            {
                linea.ComandaId = Comanda.Id;
            }

            Products.Add(linea);

        }

        public static List<LineaComanda> getLineasComanda()
        {
            return Products;
        }
        
    }
}
