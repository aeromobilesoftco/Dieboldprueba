using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dieboldpruebas.Models.Usuario
{
    public class ClsDataUsuario
    {
        // base de datos
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["DemusUniver"].ToString();
            con = new SqlConnection(constr);
        }

        public int Guardar(ClsUsuario Clusua)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into usuario(Tipdoc,numdoc,nombre,direccion,telefono) values (@Tipdoc,@numdoc,@nombre,@direccion,@telefono)", con);
            comando.Parameters.Add("@Tipdoc", SqlDbType.VarChar);
            comando.Parameters.Add("@numdoc", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters["@Tipdoc"].Value = Clusua.TipDoc;
            comando.Parameters["@numdoc"].Value = Clusua.numdoc;
            comando.Parameters["@nombre"].Value = Clusua.nombre;
            comando.Parameters["@direccion"].Value = Clusua.direccion;
            comando.Parameters["@telefono"].Value = Clusua.telefono;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }
    }
}