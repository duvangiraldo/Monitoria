using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoMonitores.Models;

namespace ProyectoMonitores.Controllers
{
    public class CursoController : Controller
    {

        private BaseMonitorEntities db = new BaseMonitorEntities();
        // GET: Curso
        public ActionResult Index()
        {

            return View(db.Curso.ToList());
        }

        public ActionResult CrearCurso(Curso curso)
        {
            

           

                if (ModelState.IsValid)
                {
                    db.Curso.Add(curso);
                    db.SaveChanges();


                }

            
           

           

            return View(curso);
        }

        public ActionResult EncontrarCurso(int id)
        {

            Curso curso = db.Curso.Find(id);

            return View(curso);
        }

        public ActionResult EliminarCurso(int id)
        {

            try
            {
                Curso curso = db.Curso.Find(id);
                db.Curso.Remove(curso);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw (ex);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        
    }
}