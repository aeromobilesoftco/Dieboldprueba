using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dieboldpruebas.Models.Equipo;

namespace Dieboldpruebas.Controllers.Equipo
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult neuequipo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(FormCollection luga)
        {
            ClsDataEquipo cde = new ClsDataEquipo();

            ClsEquipo clequi = new ClsEquipo()
            {
                serial= luga["serial"],
                marca = luga["marca"]
            };

            cde.Guardar(clequi);
            return RedirectToAction("Index");
        }

    }
}