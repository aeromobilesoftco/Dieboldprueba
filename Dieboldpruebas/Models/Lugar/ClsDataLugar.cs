using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dieboldpruebas.Models.Lugar
{
    public class ClsDataLugar
    {

        // base de datos
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["DemusUniver"].ToString();
            con = new SqlConnection(constr);
        }

        public int Guardar(ClsLugar alu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into lugar(nombrelugar) values (@nombrelugar)", con);
            comando.Parameters.Add("@nombrelugar", SqlDbType.VarChar);
            comando.Parameters["@nombrelugar"].Value = alu.nombrelugar;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }
    }
}