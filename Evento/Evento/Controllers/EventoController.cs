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
    public class EventoController : Controller
    {
        private EventosEntities db = new EventosEntities();

        //
        // GET: /Evento/

        public ViewResult Index()
        {
            var eventoes = db.Eventoes.Include(e => e.Estado).Include(e => e.TipoEvento);
            return View(eventoes.ToList());
        }

        //
        // GET: /Evento/Details/5

        public ViewResult Details(int id)
        {
            Evento evento = db.Eventoes.Find(id);
            return View(evento);
        }

        //
        // GET: /Evento/Create

        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.Estadoes, "id", "descricao");
            ViewBag.idTipoEvento = new SelectList(db.TipoEventoes, "id", "descricao");
            return View();
        } 

        //
        // POST: /Evento/Create

        [HttpPost]
        public ActionResult Create(Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Eventoes.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idEstado = new SelectList(db.Estadoes, "id", "descricao", evento.idEstado);
            ViewBag.idTipoEvento = new SelectList(db.TipoEventoes, "id", "descricao", evento.idTipoEvento);
            return View(evento);
        }
        
        //
        // GET: /Evento/Edit/5
 
        public ActionResult Edit(int id)
        {
            Evento evento = db.Eventoes.Find(id);
            ViewBag.idEstado = new SelectList(db.Estadoes, "id", "descricao", evento.idEstado);
            ViewBag.idTipoEvento = new SelectList(db.TipoEventoes, "id", "descricao", evento.idTipoEvento);
            return View(evento);
        }

        //
        // POST: /Evento/Edit/5

        [HttpPost]
        public ActionResult Edit(Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.Estadoes, "id", "descricao", evento.idEstado);
            ViewBag.idTipoEvento = new SelectList(db.TipoEventoes, "id", "descricao", evento.idTipoEvento);
            return View(evento);
        }

        //
        // GET: /Evento/Delete/5
 
        public ActionResult Delete(int id)
        {
            Evento evento = db.Eventoes.Find(id);
            return View(evento);
        }

        //
        // POST: /Evento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Evento evento = db.Eventoes.Find(id);
            db.Eventoes.Remove(evento);
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