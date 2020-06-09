using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dieboldpruebas.Models.Equipo;

namespace Dieboldpruebas.Models.Asignacion
{

    public class ClsAsigSis
    {
        public string idequipo
        {
            get;
            set;
        }

        public string idusurio
        {
            get;
            set;
        }

        public string idestado
        {
            get;
            set;
        }

        public string idlugar
        {
            get;
            set;
        }

        public string evento { get; set; }
        public DateTime fecentrada { get; set; }
        public DateTime fecSalida { get; set; }
    }
}