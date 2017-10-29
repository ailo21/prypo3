using Microsoft.AspNet.Identity;
using prypo3.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace prypo3.Controllers
{
    public class FantController : Controller
    {
        // GET: Fant
        public ActionResult Index()
        {
            using (LibraryContext db = new LibraryContext())
            {
                //Fant item = new Fant();                
                //item.Title = "Title Fant";
                //item.Text = "Lorem ipsum...";
                //item.Price = 2500;
                //db.Fants.Add(item);
                //db.SaveChanges();

                return View(db.Fants.ToList());
            }
            
        }

        // GET: Fant/Details/5
        public ActionResult Details(int? id)
        {
            using (LibraryContext db = new LibraryContext())
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Fant data = db.Fants.Find(id);
                if (data == null)
                {
                    return HttpNotFound();
                }
                return View(data);
            }                
        }

        // GET: Fant/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fant/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Fant collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (LibraryContext db = new LibraryContext())
                    {
                        collection.Author = User.Identity.GetUserId();
                        db.Fants.Add(collection);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(collection);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Fant/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Fant/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fant/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fant/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
