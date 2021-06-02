using mvc_shop_core.Contracts;
using mvc_shop_core.Models;
using mvc_shop_data_access_in_memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_shop.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        //ProductCategoryRepository context;
       // InMemoryRepository<ProductCategory> context;

        IRepository<ProductCategory> context;
        public ProductCategoryManagerController(IRepository<ProductCategory> context)
        {
            //context = new ProductCategoryRepository();
            //context = new InMemoryRepository<ProductCategory>();
            this.context=context;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            if (productCategories == null)
                return HttpNotFound();
            return View(productCategories);
        }


        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
                return View(productCategory);
            else
            {

                context.Insert(productCategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
                return HttpNotFound();
            else
                return View(productCategory);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);
            if (productCategoryToEdit == null)
                return HttpNotFound();
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }
                productCategoryToEdit.Category = productCategory.Category;


                context.Commit();
                return RedirectToAction("Index");
            }


        }
        public ActionResult Delete(string Id)
        {
            ProductCategory productToDelete = context.Find(Id);
            if (productToDelete == null)
                return HttpNotFound();
            else
                return View(productToDelete);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productToDelete = context.Find(Id);
            if (productToDelete == null)
                return HttpNotFound();
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}