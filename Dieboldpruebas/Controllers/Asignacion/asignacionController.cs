using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dieboldpruebas.Models.Asignacion;

namespace Dieboldpruebas.Controllers.Asignacion
{
    public class asignacionController : Controller
    {
        // GET: asignacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult newasigna()
        {
            string constr = ConfigurationManager.ConnectionStrings["DemusUniver"].ToString();
            SqlConnection _con = new SqlConnection(constr);

            // Cargo el equipo
            SqlDataAdapter _da = new SqlDataAdapter("SELECT idequipo,marca FROM Equipo", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            ViewBag.selequi = ToSelectList(_dt, "idequipo", "marca");

            // Cargo el usuario
            SqlDataAdapter _da1 = new SqlDataAdapter("SELECT idusuario,nombre FROM usuario", constr);
            DataTable _dt1 = new DataTable();
            _da1.Fill(_dt1);
            ViewBag.selusua = ToSelectList(_dt1, "idusuario", "nombre");

            SqlDataAdapter _da2 = new SqlDataAdapter("SELECT idlugar,nombrelugar FROM lugar", constr);
            DataTable _dt2 = new DataTable();
            _da2.Fill(_dt2);
            ViewBag.seluga = ToSelectList(_dt2, "idlugar", "nombrelugar");

            SqlDataAdapter _da3 = new SqlDataAdapter("SELECT idestado,estado FROM estado", constr);
            DataTable _dt3 = new DataTable();
            _da3.Fill(_dt3);
            ViewBag.seledo = ToSelectList(_dt3, "idestado", "estado");

            return View();
        }

        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        [HttpPost]
        public ActionResult Guardar(FormCollection asignaequi)
        {
            /*
            List<string> idequip = new List<string>();
            idequip.Add(asignaequi["idequipo"]);

            ViewBag.Domains = idequip;
            */
            ClsDataSis cdsis = new ClsDataSis();

            ClsAsigSis clequi = new ClsAsigSis()
            {
                idequipo = asignaequi["idequipo"],
                idusurio = asignaequi["idusurio"],
                idestado = asignaequi["idestado"],
                idlugar = asignaequi["idlugar"],
                evento = asignaequi["evento"],
                fecentrada= DateTime.Parse(asignaequi["fecentrada"]),
                fecSalida = DateTime.Parse(asignaequi["fecSalida"])
            };


            cdsis.Guardar(clequi);
            return RedirectToAction("Index");
        }

    }
}