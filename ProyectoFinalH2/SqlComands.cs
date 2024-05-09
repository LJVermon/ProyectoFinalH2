using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFinalH2
{
    internal class SqlComands
    {
        public void funConexion(string server, string database)
        {
            using (SqlConnection con = new SqlConnection($"server = {server}; database = {database}; integrated security = true;"))
            {
                con.Open();
                con.Close();
            }
        }

        public void funData(string server, string database, DataGridView Tabla)
        {
            using (SqlConnection con = new SqlConnection($"server = {server}; database = {database}; integrated security = true;"))
            {
                con.Open();
                string Querry = "select * from testTab";
                SqlDataAdapter sqlCommand = new SqlDataAdapter(Querry, con);
                DataTable dt = new DataTable();
                sqlCommand.Fill(dt);
                Tabla.DataSource = dt;
                con.Close();
            }

        }

    }
}
