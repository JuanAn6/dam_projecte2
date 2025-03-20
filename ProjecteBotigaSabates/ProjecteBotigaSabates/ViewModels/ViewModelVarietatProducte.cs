using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjecteBotigaSabates.ViewModels
{
    class ViewModelVarietatProducte
    {
        public VarietatProducte prod;
        
        public ImageSource ImageUrl
        {
            get
            {
                return new BitmapImage(new Uri("https://drop-imgs.vercel.app/imgs/" + prod.Img));
            }
            set { }
        }

    }
}
