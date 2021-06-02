using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_shop_core.Models
{
    public class Product : BaseEntity
    {

        // public string Id { get; set; } 
        // no need Id property here  beacuse it is come from BaseEntity

        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 1000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        //public Product()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
