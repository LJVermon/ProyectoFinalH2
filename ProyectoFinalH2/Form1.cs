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
        public string server;
        public string basedata;
        private void Form1_Load(object sender, EventArgs e)
        {
            Instalacion F2Instal = new Instalacion();
            AddOwnedForm(F2Instal);
            F2Instal.ShowDialog();
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
            F2Usuer F2U = new F2Usuer();
            F2U.ShowDialog();
        }

        private void btnIstl_Click(object sender, EventArgs e)
        {
            
        }
    }
}
