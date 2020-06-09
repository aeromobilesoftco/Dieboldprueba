using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dieboldpruebas.Models.Lugar;

namespace Dieboldpruebas.Controllers.Lugar
{
    public class LugarController : Controller
    {
        // GET: Lugar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult lugar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(FormCollection luga)
        {
            ClsDataLugar clsneuluga = new ClsDataLugar();

            ClsLugar clsugare = new ClsLugar()
            {
                nombrelugar = luga["nombrelugar"]
            };

            clsneuluga.Guardar(clsugare);
            return RedirectToAction("Index");
        }
        }
}