using Dieboldpruebas.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dieboldpruebas.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult neusuar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(FormCollection usuare)
        {
            ClsDataUsuario clsneuluga = new ClsDataUsuario();

            ClsUsuario clsugare = new ClsUsuario()
            {
                TipDoc= usuare["TipDoc"],
                numdoc = usuare["numdoc"],
                nombre = usuare["nombre"],
                direccion = usuare["direccion"],
                telefono = usuare["telefono"]
            };

            clsneuluga.Guardar(clsugare);
            return RedirectToAction("Index");
        }

    }
}