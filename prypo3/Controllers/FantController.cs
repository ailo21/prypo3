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
                #region //new fant gener
                //Fant item = new Fant();
                //item.Title = "Title Fant";
                //item.Text = "Lorem ipsum...";
                //item.Author = User.Identity.GetUserId();
                //item.Price = 2500;
                //db.Fants.Add(item);
                //db.SaveChanges(); 
                #endregion
                if (User.IsInRole("admin"))
                {
                    return View(db.Fants.ToList());
                }
                else
                {
                    return View(db.Fants.Where(w=>w.Publish==true).ToList());
                }
                
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
                ViewBag.Edit = (data.Author == User.Identity.GetUserId() || User.IsInRole("admin")) ? true : false;
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
            using (LibraryContext db = new LibraryContext())
            {
                Fant data = db.Fants.Find(id);
                
                if (!(data != null || data.Author== User.Identity.GetUserId() || User.IsInRole("admin")))
                {
                    return HttpNotFound();
                }
                return View(data);
            }            
        }

        // POST: Fant/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Fant model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (LibraryContext db = new LibraryContext())
                    {
                        var user = db.Fants.Single(u => u.Id == id);
                        user.Title = model.Title;
                        user.Publish = model.Publish;
                        db.SaveChanges();
                    }
                }
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
