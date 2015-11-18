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
    public class ParticipanteController : Controller
    {
        private EventosEntities db = new EventosEntities();

        //
        // GET: /Participante/

        public ViewResult Index()
        {
            var participantes = db.Participantes.Include(p => p.Evento).Include(p => p.GrauAcademico).Include(p => p.Sexo1).Include(p => p.TipoParticipante);
            return View(participantes.ToList());
        }

        //
        // GET: /Participante/Details/5

        public ViewResult Details(int id)
        {
            Participante participante = db.Participantes.Find(id);
            return View(participante);
        }

        //
        // GET: /Participante/Create

        public ActionResult Create()
        {
            ViewBag.idEvento = new SelectList(db.Eventoes, "id", "titulo");
            ViewBag.idGrau = new SelectList(db.GrauAcademicoes, "id", "descricao");
            ViewBag.sexo = new SelectList(db.Sexoes, "id", "descricao");
            ViewBag.idTipoParticipante = new SelectList(db.TipoParticipantes, "id", "descricao");
            return View();
        } 

        //
        // POST: /Participante/Create

        [HttpPost]
        public ActionResult Create(Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Participantes.Add(participante);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idEvento = new SelectList(db.Eventoes, "id", "titulo", participante.idEvento);
            ViewBag.idGrau = new SelectList(db.GrauAcademicoes, "id", "descricao", participante.idGrau);
            ViewBag.sexo = new SelectList(db.Sexoes, "id", "descricao", participante.sexo);
            ViewBag.idTipoParticipante = new SelectList(db.TipoParticipantes, "id", "descricao", participante.idTipoParticipante);
            return View(participante);
        }
        
        //
        // GET: /Participante/Edit/5
 
        public ActionResult Edit(int id)
        {
            Participante participante = db.Participantes.Find(id);
            ViewBag.idEvento = new SelectList(db.Eventoes, "id", "titulo", participante.idEvento);
            ViewBag.idGrau = new SelectList(db.GrauAcademicoes, "id", "descricao", participante.idGrau);
            ViewBag.sexo = new SelectList(db.Sexoes, "id", "descricao", participante.sexo);
            ViewBag.idTipoParticipante = new SelectList(db.TipoParticipantes, "id", "descricao", participante.idTipoParticipante);
            return View(participante);
        }

        //
        // POST: /Participante/Edit/5

        [HttpPost]
        public ActionResult Edit(Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEvento = new SelectList(db.Eventoes, "id", "titulo", participante.idEvento);
            ViewBag.idGrau = new SelectList(db.GrauAcademicoes, "id", "descricao", participante.idGrau);
            ViewBag.sexo = new SelectList(db.Sexoes, "id", "descricao", participante.sexo);
            ViewBag.idTipoParticipante = new SelectList(db.TipoParticipantes, "id", "descricao", participante.idTipoParticipante);
            return View(participante);
        }

        //
        // GET: /Participante/Delete/5
 
        public ActionResult Delete(int id)
        {
            Participante participante = db.Participantes.Find(id);
            return View(participante);
        }

        //
        // POST: /Participante/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Participante participante = db.Participantes.Find(id);
            db.Participantes.Remove(participante);
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