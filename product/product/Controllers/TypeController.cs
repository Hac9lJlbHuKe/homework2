using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using product.Models;

namespace product.Controllers
{
    public class TypeController : Controller
    {

        private DatabaseContext db = new DatabaseContext();

        //
        // GET: /Type/

        public ActionResult Index()
        {
            return View(db.Type.ToList());
        }

        //
        // GET: /Type/Details/5

        public ActionResult Details(int id = 0)
        {
            Models.Type type = db.Type.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // GET: /Type/Create

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        //
        // POST: /Type/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Type.Add(type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", type.ProductId);
            return View(type);
        }

        //
        // GET: /Type/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Models.Type type = db.Type.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", type.ProductId);
            return View(type);
        }

        //
        // POST: /Type/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", type.ProductId);
            return View(type);
        }

        //
        // GET: /Type/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Models.Type type = db.Type.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // POST: /Types/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Type type = db.Type.Find(id);
            db.Type.Remove(type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}