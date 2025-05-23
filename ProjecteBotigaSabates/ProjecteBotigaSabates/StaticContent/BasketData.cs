﻿using DBModel;
using DBModel.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjecteBotigaSabates.StaticContent
{
    public class BasketData
    {
        //Carregar la comanda que es fa servir com "carro" en el moment de fer el login!
        public static Comanda Comanda;
        public static List<LineaComanda> Products;

        public static TipusEnviament Enviament;

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


                Comanda = MongoDB.GetOpenOrder(ClientConnected.AuthClient.Id);
                
                //Crear la comanda si no existeix cap

                if (Comanda == null)
                {
                    Debug.WriteLine("No comanda en la base de dades!");
                    Comanda = new Comanda();
                    Comanda.ClientId = ClientConnected.AuthClient.Id;
                    Comanda.Data = DateTime.Now;
                    Comanda.Finalitzada = false;
                }
                else
                {
                    Debug.WriteLine("Comanda de la base de dades!"+Comanda.Id);
                    Products = MongoDB.GetLineasComanda(Comanda.Id);
                }

            }

        }

        public static List<LineaComanda> getLineasComanda()
        {
            return Products;
        }

        public static async void SaveBasketData()
        {
            Debug.WriteLine("Save Basket!");
            MongoDBConnection db = new MongoDBConnection();

            if (Comanda.Id.Equals(ObjectId.Empty))
            {
                Comanda.Data = DateTime.Now;
                ObjectId aux_id = await db.SaveActualBasket(Comanda);
                Debug.WriteLine("Insert: " + aux_id.ToString());
                Comanda.Id = aux_id;
            }
            else
            {
                await db.UpdateActualBasket(Comanda);
            }

            foreach (LineaComanda l in Products)
            {
                l.ComandaId = BasketData.Comanda.Id;
                Producte prod = db.GetProductById(l.Vareitat.ProducteId);
                l.Impost = prod.Impost;
                l.Descompte = l.Vareitat.Descompte;
                if(l.Id != ObjectId.Empty)
                {
                    l.Id = await db.UpdateActualBasketLine(l);
                    Debug.WriteLine("Update line: " + l.Id.ToString());
                }
                else
                {
                    l.Id = await db.SaveActualBasketLine(l);
                    Debug.WriteLine("Inseert line: " + l.Id.ToString());
                }


            }



        }

        public static int CountLines()
        {
            return Products.Count();
        }

        public static void Reset()
        {
            Comanda = null;
            Products.Clear();
            Enviament = null;

        }

        public static async void RemoveLine(LineaComanda l)
        {
            MongoDBConnection db = new MongoDBConnection();
            await db.DeleteLine(l.Id);
            Products.Remove(l);
            
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.tb_number_lines.Text = "" + BasketData.CountLines();


        }
    }
}
