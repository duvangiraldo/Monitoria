using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoMonitores.Models;

namespace ProyectoMonitores.Controllers
{
    public class MonitorController : Controller
    {
        // GET: Monitor
        private BaseMonitorEntities db = new BaseMonitorEntities();
        public ActionResult Index()
        {
            return View(db.Monitor.ToList());
        }

        public ActionResult CrearMonitor(Monitor monitor)
        {

            db.Monitor.Add(monitor);
            db.SaveChanges();

            ViewBag.idCurso = new SelectList(db.Curso, "idCurso", "nombreCurso", monitor.idCurso);
            return View(monitor);
        }

       

       
    }
}