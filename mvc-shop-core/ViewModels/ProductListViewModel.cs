using mvc_shop_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_shop_core.ViewModels
{
   public class ProductListViewModel
    {
        //ProductManagerViewModel viewModel = new ProductManagerViewModel();

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }

    }
}
