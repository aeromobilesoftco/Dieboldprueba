using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dieboldpruebas.Models.Equipo;

namespace Dieboldpruebas.Models.Equipo
{
    public class ClsDataEquipo
    {
        // base de datos
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["DemusUniver"].ToString();
            con = new SqlConnection(constr);
        }

        public int Guardar(ClsEquipo equi)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into equipo(serial, marca) values (@serial, @marca)", con);
            comando.Parameters.Add("@serial", SqlDbType.VarChar);
            comando.Parameters.Add("@marca", SqlDbType.VarChar);
            comando.Parameters["@serial"].Value = equi.serial;
            comando.Parameters["@marca"].Value = equi.marca;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }

        // Cargar lista de alumnos
        public List<ClsEquipo> verequi()
        {
            Conectar();

            List<ClsEquipo> alum = new List<ClsEquipo>();
            SqlCommand com = new SqlCommand("SELECT serial, marca FROM equipo", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {
                ClsEquipo clsalum = new ClsEquipo
                {
                    serial = registros["serial"].ToString(),
                    marca = registros["marca"].ToString()
                };
                alum.Add(clsalum);

            }

            con.Close();
            return alum;
        }
    }
}