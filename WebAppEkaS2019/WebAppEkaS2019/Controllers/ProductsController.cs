using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppEkaS2019.Models;
using System.Web.Mvc;

namespace WebAppEkaS2019.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            northwindEntities1 db = new northwindEntities1();
            List<Categories> tuoteRyhmat = db.Categories.ToList();
            ViewBag.tuoteryhmat = tuoteRyhmat;

            List<Products> tuotteet = db.Products.ToList();
            db.Dispose();
            return View(tuotteet);
        }

        public ActionResult ProdCards()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                northwindEntities1 db = new northwindEntities1();
                List<Products> model = db.Products.ToList();
                db.Dispose();
                return View(model);
            }
        }

    }
}