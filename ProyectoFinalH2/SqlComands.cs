using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Policy;

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

        public void funLoginTest(string server, string database, string tablatest, string entradaNombe, string entradaContra)
        {
            using (SqlConnection con = new SqlConnection($"server = {server}; database = {database}; integrated security = true;"))
            {
                con.Open();

                string Query2 = $"select * from {tablatest} where Nombre = {entradaNombe}";
                SqlCommand Coman2 = new SqlCommand(Query2, con);
                SqlDataReader RC2 = Coman2.ExecuteReader();
                if (RC2.Read())
                {
                    RC2.Close();
                    string Query3 = $"select * from {tablatest} where contra = { entradaContra}";
                    SqlCommand Coman3 = new SqlCommand(Query3, con);

                    SqlDataReader RC3 = Coman3.ExecuteReader();
                    if (RC3.Read())
                    {
                        RC3.Close();
                        MessageBox.Show("ok");
                    }
                    else { MessageBox.Show("Medico no encontrado", "Error."); RC3.Close(); }
                }
                else { MessageBox.Show("Cliente no encontrado", "Error."); RC2.Close(); }


                con.Close();
            }
        }

    }
}
