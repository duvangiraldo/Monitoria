using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoMonitores.Models;

namespace ProyectoMonitores.Controllers
{
    public class AsesoriaController : Controller
    {
        public BaseMonitorEntities db = new BaseMonitorEntities();
        // GET: Asesoria
        public ActionResult Index()
        {
            return View(db.Asesoria.ToList());
        }

        public ActionResult CrearAsesoria(Asesoria asesoria)
        {

            db.Asesoria.Add(asesoria);
            db.SaveChanges();

            
            ViewBag.idCurso = new SelectList(db.Curso, "idCurso", "nombreCurso", asesoria.idCurso);
            ViewBag.idMonitor = new SelectList(db.Monitor, "idMonitor", "nombreMonitor", asesoria.idMonitor);


            return View();
        }

        public ActionResult EncontrarAsesoria(int id)
        {
            

            return View(db.Asesoria.Where(x => x.idMonitor == id).ToList());
        }

        public ActionResult EliminarAsesoria(int id)
        {
            try
            {
                Asesoria asesoria = db.Asesoria.Find(id);
                db.Asesoria.Remove(asesoria);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw (ex);
                return RedirectToAction("EliminarAsesoria");
            }
            return RedirectToAction("Index");
        }
    }

   
}