using prypo3.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prypo3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (LibraryContext db = new LibraryContext())
            {
                Fant item = new Fant();
                item.Title = "Title Fant №2";
                item.Text = "Lorem ipsum...";
                item.Price = 2500;
                db.Fants.Add(item);
                db.SaveChanges();
            }
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}