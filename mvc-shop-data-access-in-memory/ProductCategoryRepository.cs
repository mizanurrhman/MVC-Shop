using mvc_shop_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace mvc_shop_data_access_in_memory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;// = new List<productCategories>()
        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {

                productCategories = new List<ProductCategory>();

                //productCategories = new List<ProductCategory>
                //{
                //new ProductCategory {  Id=Guid.NewGuid().ToString(), Category="Pen"}
                //new ProductCategory {  Id=Guid.NewGuid().ToString(), Category="Note Book"},
                //};
            }
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }
        public void Update(ProductCategory product)
        {
            ProductCategory productToUpdate = productCategories.Find(p => p.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("ProductCategory Not Found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory product = productCategories.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("ProductCategory Not Found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productToDelete = productCategories.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                productCategories.Remove(productToDelete);
            }
            else
            {
                throw new Exception("ProductCategory Not Found");
            }
        }
    }
}
