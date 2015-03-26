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
            var testItem = new Item() { Name = "testItem", Price = 9.99M };
            var testCategorie = new Category() { Name = "testCategory" };
            testItem.Catagorie = testCategorie;
            testCategorie.Items = new List<Item> { testItem };

            context.Categories.Add(testCategorie);
            context.Items.Add(testItem);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}