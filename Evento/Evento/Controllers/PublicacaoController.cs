using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evento;

namespace Evento.Controllers
{ 
    public class PublicacaoController : Controller
    {
        private EventosEntities db = new EventosEntities();

        //
        // GET: /Publicacao/

        public ViewResult Index()
        {
            var publicacaos = db.Publicacaos.Include(p => p.Evento);
            return View(publicacaos.ToList());
        }

        //
        // GET: /Publicacao/Details/5

        public ViewResult Details(int id)
        {
            Publicacao publicacao = db.Publicacaos.Find(id);
            return View(publicacao);
        }

        //
        // GET: /Publicacao/Create

        public ActionResult Create()
        {
            ViewBag.idEvento = new SelectList(db.Eventoes, "id", "titulo");
            return View();
        } 

        //
        // POST: /Publicacao/Create

        [HttpPost]
        public ActionResult Create(Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                db.Publicacaos.Add(publicacao);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idEvento = new SelectList(db.Eventoes, "id", "titulo", publicacao.idEvento);
            return View(publicacao);
        }
        
        //
        // GET: /Publicacao/Edit/5
 
        public ActionResult Edit(int id)
        {
            Publicacao publicacao = db.Publicacaos.Find(id);
            ViewBag.idEvento = new SelectList(db.Eventoes, "id", "titulo", publicacao.idEvento);
            return View(publicacao);
        }

        //
        // POST: /Publicacao/Edit/5

        [HttpPost]
        public ActionResult Edit(Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEvento = new SelectList(db.Eventoes, "id", "titulo", publicacao.idEvento);
            return View(publicacao);
        }

        //
        // GET: /Publicacao/Delete/5
 
        public ActionResult Delete(int id)
        {
            Publicacao publicacao = db.Publicacaos.Find(id);
            return View(publicacao);
        }

        //
        // POST: /Publicacao/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Publicacao publicacao = db.Publicacaos.Find(id);
            db.Publicacaos.Remove(publicacao);
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