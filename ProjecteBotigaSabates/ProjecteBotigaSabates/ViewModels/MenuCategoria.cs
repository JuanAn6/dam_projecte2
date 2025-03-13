using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteBotigaSabates.ViewModels
{
    class MenuCategoria
    {
        public List<MenuCategoria> MenuCategories;
        public Categoria Cat;

        public MenuCategoria(Categoria cat)
        {
            MenuCategories = new List<MenuCategoria>();
            Cat = cat;
        }
    }
}
