using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dieboldpruebas.Models.Asignacion
{
    public class ClsDataSis
    {
        // base de datos
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["DemusUniver"].ToString();
            con = new SqlConnection(constr);
        }

        public int Guardar(ClsAsigSis asigequi)
        {

            Conectar();
            SqlCommand comando = new SqlCommand("PA_INS_HISEQUI @idequipo,@idusuario,@idlugar,@idestado,@evento,@fecentrada,@fecsalida", con);
            comando.Parameters.Add("@idequipo", SqlDbType.VarChar);
            comando.Parameters.Add("@idusuario", SqlDbType.VarChar);
            comando.Parameters.Add("@idlugar", SqlDbType.VarChar);
            comando.Parameters.Add("@idestado", SqlDbType.VarChar);
            comando.Parameters.Add("@evento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecentrada", SqlDbType.DateTime);
            comando.Parameters.Add("@fecsalida", SqlDbType.DateTime);

            comando.Parameters["@idequipo"].Value = asigequi.idequipo;
            comando.Parameters["@idusuario"].Value = asigequi.idusurio;
            comando.Parameters["@idlugar"].Value = asigequi.idlugar;
            comando.Parameters["@idestado"].Value = asigequi.idestado;
            comando.Parameters["@evento"].Value = asigequi.evento; 
            comando.Parameters["@fecentrada"].Value =asigequi.fecentrada;
            comando.Parameters["@fecsalida"].Value = asigequi.fecSalida;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }


    }
}