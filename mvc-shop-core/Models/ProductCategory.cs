using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_shop_core.Models
{
    public class ProductCategory : BaseEntity
    {
        //public string Id { get; set; }
        [StringLength(30)]
        [DisplayName("Category Name")]
        public string Category { get; set; }

        //no need because its comming form BaseEntity        
        //public ProductCategory()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
