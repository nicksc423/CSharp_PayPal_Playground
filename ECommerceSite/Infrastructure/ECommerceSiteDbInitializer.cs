using ECommerceSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerceSite.Infrastructure
{
    public class ECommerceSiteDbInitializer : DropCreateDatabaseAlways<ECommerceSiteDB>
    {
        protected override void Seed(ECommerceSiteDB context)
        {
            var testProduct = new Product() { Name = "testProduct", Price = 9.99M };
            var testCategorie = new Category() { Name = "testCategory" };
            testProduct.Catagorie = testCategorie;
            testCategorie.Products = new List<Product> { testProduct };

            context.Categories.Add(testCategorie);
            context.Products.Add(testProduct);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}