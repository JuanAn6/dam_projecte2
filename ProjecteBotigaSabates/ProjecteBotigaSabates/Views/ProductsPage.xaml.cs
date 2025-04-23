using DBModel;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjecteBotigaSabates.Views
{
    /// <summary>
    /// Lógica de interacción para ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        MongoDBConnection mongoDB;
        public ObservableCollection<Producte> Products { get; set; }

        private int numPage = 0;
        private int productsPerPage = 6;
        private int maxPage = 0;
        private int countProducts = 0;

        public string catFilter = "";
        public Categoria cat;

        private int slideValue = 0;

        private List<Categoria> catsBreadCrumbs = new List<Categoria>();

        public ProductsPage(Categoria cat)
        {
            InitializeComponent();
            this.cat = cat;
            if(cat != null)
            {
                catFilter = cat.Nom;
            }
            else
            {
                catFilter = "";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mongoDB = new MongoDBConnection();
            countProducts = mongoDB.GetCountProducts();
            
            productsPerPage = 6;
            maxPage = countProducts / productsPerPage;
            numPage = 0;

            Products = new ObservableCollection<Producte>();

            Debug.WriteLine("LOADPAGE CAT: " + cat);
            
            ChangePage();

            this.DataContext = this;

            
            LoadTreeViewCategories();

            //lv_products.ItemsSource = Products;

        }

        private void ChangePage()
        {
            ChangeBreadCrumbs();

            string search = tb_search.Text;
            List<Producte> prods = mongoDB.GetPageProductsWithFilters(productsPerPage, numPage, search, cat, slideValue);
            Debug.WriteLine("ChangePages!");
            Products.Clear();
            foreach (Producte p in prods)
            {
                Debug.WriteLine(p);
                Products.Add(p);
            }

            tb_max_page.Text = "" + (maxPage+1);
            tb_page.Text = "" + (numPage+1);

        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            ChangePage();
        }

        private void Button_Previous_Click(object sender, RoutedEventArgs e)
        {
            if(numPage - 1 >= 0)
            {
                numPage = numPage - 1;
                ChangePage();
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            if (numPage + 1 <= maxPage)
            {
                numPage = numPage + 1;
                ChangePage();
            }
        }


        private void ChangeBreadCrumbs()
        {
            catsBreadCrumbs.Clear();
            GetCategoriesParent(cat);

            if(catsBreadCrumbs.Count > 0)
            {
                catsBreadCrumbs.Reverse();
                string content = "Products";
                foreach(Categoria c in catsBreadCrumbs)
                {
                    content = content + " / " + c.Nom;
                }
                BreadCrumbs.Text = content;
            }
            else
            {
                BreadCrumbs.Text = "Products/";
            }
        }

        private void GetCategoriesParent(Categoria c)
        {
            if(c != null)
            {
                catsBreadCrumbs.Add(c);
                if (c.ParentId != null)
                {
                    Categoria c2 = mongoDB.GetCategoriaById(c);
                    GetCategoriesParent(c2);
                }

            }

        }

        private void sl_price_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double val = sl_price.Value;

            sl_price_val.Text = Math.Round(val)+"€";

            slideValue = (int)Math.Round(val);
        }


        private void LoadTreeViewCategories()
        {
            List<Categoria> categories = mongoDB.GetCategories();
            foreach(Categoria cat in categories)
            {
                if (cat.ParentId == null)
                {
                    AddCategoriaTreeView(null, cat, categories);
                }
            }
        }

        private void AddCategoriaTreeView(TreeViewItem item, Categoria parent, List<Categoria> categories)
        {

            TreeViewItem aux = new TreeViewItem();
            aux.Header = parent.Nom;
            aux.Tag = parent;
            aux.Selected += Aux_Selected_Category;
            if (item == null)
            {
                trv_categories.Items.Add(aux);
            }
            else
            {
                item.Items.Add(aux);
            }

            foreach (Categoria cat in categories.Where(c => c.ParentId == parent.Id).ToList())
            {
                AddCategoriaTreeView(aux, cat, categories);
            }

        }

        private void Aux_Selected_Category(object sender, RoutedEventArgs e)
        {
            TreeViewItem aux = (TreeViewItem)sender;
            Categoria cat_aux = (Categoria)aux.Tag;
            Debug.WriteLine("CATTREVIEW: " + cat_aux.Nom);
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new ProductsPage(cat_aux));

            e.Handled = true;
        }

        private void Button_Slide_Filter_Click(object sender, RoutedEventArgs e)
        {
            ChangePage();
        }

        private void lv_products_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            int index = ((ListView)sender).SelectedIndex;

            Debug.WriteLine("ShowPROD: " + index);
            if(index != -1)
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new ViewProductPage(Products.ElementAt(index)));
            }

        }


    }
}
