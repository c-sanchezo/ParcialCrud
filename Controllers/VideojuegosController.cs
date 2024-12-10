using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParcialCelesteCrud.Models;

namespace ParcialCelesteCrud.Controllers
{
    public class VideojuegosController : Controller
    {
        private TiendaVideojuegosEntities db = new TiendaVideojuegosEntities();

        // GET: Videojuegos
        public ActionResult Index()
        {
            return View(db.Videojuegos.ToList());
        }

        // GET: Videojuegos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videojuegos videojuegos = db.Videojuegos.Find(id);
            if (videojuegos == null)
            {
                return HttpNotFound();
            }
            return View(videojuegos);
        }

        // GET: Videojuegos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videojuegos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideojuegoId,nombre,precio,stock,fecha_lanzamiento,CategoriaId")] Videojuegos videojuegos)
        {
            if (ModelState.IsValid)
            {
                db.Videojuegos.Add(videojuegos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videojuegos);
        }

        // GET: Videojuegos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videojuegos videojuegos = db.Videojuegos.Find(id);
            if (videojuegos == null)
            {
                return HttpNotFound();
            }
            return View(videojuegos);
        }

        // POST: Videojuegos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideojuegoId,nombre,precio,stock,fecha_lanzamiento,CategoriaId")] Videojuegos videojuegos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videojuegos).State = (System.Data.Entity.EntityState)System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videojuegos);
        }

        // GET: Videojuegos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videojuegos videojuegos = db.Videojuegos.Find(id);
            if (videojuegos == null)
            {
                return HttpNotFound();
            }
            return View(videojuegos);
        }

        // POST: Videojuegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Videojuegos videojuegos = db.Videojuegos.Find(id);
            db.Videojuegos.Remove(videojuegos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
