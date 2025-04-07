using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteBotigaSabates.StaticContent
{
    class BasketData
    {
        //Carregar la comanda que es fa servir com "carro" en el moment de fer el login!
        public static Comanda comanda;
        public static List<LineaComanda> Products;

        public BasketData()
        {
            if(Products == null)
            {
                Products = new List<LineaComanda>();
            }
        }
        
    }
}
