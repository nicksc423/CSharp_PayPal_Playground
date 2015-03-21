using ECommerceSite.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Controllers
{
    public class StoreController : Controller
    {
        ECommerceSiteDB dbContext = new ECommerceSiteDB();

        //
        // GET: /Store/
        public ActionResult Index()
        {
            var catagories = dbContext.Categories.ToList();
            return View(catagories);
        }

        //
        // GET: /Store/Browse?category=Disco
        public ActionResult Browse(string category)
        {
            // Retrieve Category and its Associated Items from database
            var categorieModel = dbContext.Categories.Include("Items")
                .Single(c => c.Name == category);

            return View(categorieModel);
        }

        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var item = dbContext.Items.Find(id);
            return View(item);
        }

        //
        // GET: /Store/CategoryMenu
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = dbContext.Categories.ToList();
            return PartialView(categories);
        }
    }
}