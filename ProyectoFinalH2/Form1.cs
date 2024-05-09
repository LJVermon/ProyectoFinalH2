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
        string server = "B13-204-22892";
        string database = "RentalCars";
        string UsertTest = "testUser";
        
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
            
            MessageBox.Show($"new registered user, welcome to rental cars {txtName.Text} your ID is: {25642}.", "Hello!");
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            sqlComands2.funLoginTest(server, database, UsertTest, txtName.Text, txtPassw.Text);

            F2Usuer F2U = new F2Usuer();
            F2U.ShowDialog();
        }

        private void btnIstl_Click(object sender, EventArgs e)
        {
            
        }
    }
}
