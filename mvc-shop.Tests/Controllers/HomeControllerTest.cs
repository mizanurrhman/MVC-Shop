using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvc_shop;
using mvc_shop.Controllers;
using mvc_shop_core.Contracts;
using mvc_shop_core.Models;
using mvc_shop_core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace mvc_shop.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCategiryContext = new Mocks.MockContext<ProductCategory>();

            productContext.Insert(new Product());
            
            HomeController controller = new HomeController(productContext, productCategiryContext);

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel) result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());
            
        }


    }
}
