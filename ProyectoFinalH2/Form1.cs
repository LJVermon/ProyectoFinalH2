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
        public string tableAdmin = "tAdmin";
        
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
            int Bandera2 = sqlComands2.funLoginTest(server, database, tableAdmin, txtName.Text, txtPassw.Text);
            F2Usuer F2 = new F2Usuer();
            F3Admin F3 = new F3Admin();
            AddOwnedForm(F2);
            F2.lblUserID.Text = $"{Convert.ToString(sqlComands2.funReturIDClient(server, database, UsertTest, txtName.Text, txtPassw.Text))}";
            if (Bandera == 1)
            {
                txtName.Clear();
                txtPassw.Clear();
                F2.Show();
            }
            else if (Bandera2 == 1)
            {
                txtName.Clear();
                txtPassw.Clear();
                F3.Show();
            }
            else
            {
                MessageBox.Show("Incorrect client or password, try again.", "Ups!");
            }
        }
    }
}
