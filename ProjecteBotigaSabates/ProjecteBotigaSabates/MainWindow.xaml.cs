using DBModel.Models;
using DBModel;
using MongoDB.Bson;

using System.Windows;
using System.Windows.Controls;
using ProjecteBotigaSabates.Views;
using ProjecteBotigaSabates.StaticContent;
using System.Diagnostics;
using System.Collections.Generic;
using ProjecteBotigaSabates.ViewModels;
using System.Windows.Input;

namespace ProjecteBotigaSabates
{
    /// <summary>
    /// Lógica de interacción para SelectUserPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new SelectUserPage());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            grid_MainMenu.Opacity = 0;

            LoadCategories();
        }


        private void LoadCategories()
        {
            MongoDBConnection mongoDB = new MongoDBConnection();

            List<Categoria> categories = mongoDB.GetCategories();

            Debug.WriteLine("CATEGORIES: " + categories);

            List<MenuCategoria> cats_menu = new List<MenuCategoria>();
            
            foreach (Categoria cat in categories)
            {
                if(cat.ParentId == null)
                {
                    cats_menu.Add(new MenuCategoria(cat));
                }
                else
                {
                    MenuCategoria mc = cats_menu.Find((ele) => { return ele.Cat.Id == cat.ParentId; });
                    if(mc != null)
                    {
                        mc.MenuCategories.Add(new MenuCategoria(cat));
                    }
                    else
                    {
                        searchAndAddMenuCategory(cats_menu, cat);
                    }
                }

                
            }

            AddMenuCategories(cats_menu,(MenuItem)menu_categories.Items[0]);

        }

        private void searchAndAddMenuCategory(List<MenuCategoria> cats_menu, Categoria cat)
        {
            foreach(MenuCategoria menu_cat_list in cats_menu)
            {
                MenuCategoria mc = menu_cat_list.MenuCategories.Find((ele) => { return ele.Cat.Id == cat.ParentId; });
                if (mc != null)
                {
                    mc.MenuCategories.Add(new MenuCategoria(cat));
                }
                else
                {
                    if(menu_cat_list.MenuCategories.Count > 0)
                    {
                        searchAndAddMenuCategory(menu_cat_list.MenuCategories, cat);
                    }
                }
            }
            
        }

        private void AddMenuCategories(List<MenuCategoria> cats_menu, MenuItem menu)
        {
            foreach (MenuCategoria cat in cats_menu)
            {

                

                MenuItem menuItem = new MenuItem { Header = cat.Cat.Nom };
                //menuItem.PreviewMouseLeftButtonDown += MenuItem_Click_Btn_MenuItem;
                menuItem.Tag = cat.Cat;
                
                Button btn = new Button { Content = "🔍" };
                btn.Click += MenuItem_Click_Btn;
                btn.Tag = cat.Cat;
                menuItem.Icon = btn;

           
                menu.Items.Add(menuItem);
                
                if(cat.MenuCategories.Count > 0)
                {
                    AddMenuCategories(cat.MenuCategories, menuItem);
                }
            }
        }
        /*
        private void MenuItem_Click_Btn_MenuItem(object sender, MouseButtonEventArgs e)
        {
            Categoria cat = (Categoria)((MenuItem)sender).Tag;
            Debug.WriteLine("CAT CLIK: " + cat);
            e.Handled = true;
        }
        */

        private void MenuItem_Click_Btn(object sender, RoutedEventArgs e)
        {

            Categoria cat = (Categoria)((Button)sender).Tag;
            Debug.WriteLine("CAT CLIK: " + cat);
            if (ClientConnected.AuthClient != null)
            {
                MainFrame.Navigate(new ProductsPage(cat));
                tb_info.Text = "";
            }
            else
            {
                tb_info.Text = "Select valid user!";
            }

        }


        private void Button_SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SelectUserPage());
            grid_MainMenu.Opacity = 0;
        }

        private void Button_Products_Click(object sender, RoutedEventArgs e)
        {
            if(ClientConnected.AuthClient != null)
            {
                MainFrame.Navigate(new ProductsPage(null));
                tb_info.Text = "";
            }
            else
            {
                tb_info.Text = "Select valid user!";
            }

        }

        private void Button_Basket_Click(object sender, MouseButtonEventArgs e)
        {
            if (ClientConnected.AuthClient != null)
            {
                MainFrame.Navigate(new BasketPage());
                tb_info.Text = "";
            }
            else
            {
                tb_info.Text = "Select valid user!";
            }
        }
    }
}
