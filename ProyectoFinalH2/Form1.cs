using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalH2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public string server = "DESKTOP-B9S4NRM";
        public string database = "RentalCars";
        string UsertTest = "tClientes";
        
        SqlComands conexionBa = new SqlComands();
        SqlComands sqlComands2 = new SqlComands();

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlComands2.funConexion(server,database);
            btnSingUp.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            btnSingUp.Visible = true;
        }

        private void btnSingUp_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" & txtPassw.Text != "") 
            {
                sqlComands2.funSingUp(server, database, UsertTest, txtName.Text, txtPassw.Text);
                txtName.Clear();
                txtPassw.Clear();
            }
            else { MessageBox.Show("Complete the fields", "Ups!."); }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int Bandera = sqlComands2.funLoginTest(server, database, UsertTest, txtName.Text, txtPassw.Text);
            if (Bandera == 1)
            {
                txtName.Clear();
                txtPassw.Clear();
                F2Usuer F2U = new F2Usuer();
                F2U.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Incorrect client or password, try again.", "Ups!");
            }
            
        }
    }
}
