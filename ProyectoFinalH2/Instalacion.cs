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
    public partial class Instalacion : Form
    {
        public Instalacion()
        {
            InitializeComponent();
        }

        private void Instalacion_Load(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Form1 F1 = Owner as Form1;
            //if (tbxBasedata.Text != "" & tbxServer.Text != "") 
            //{
            //    F1.server = tbxServer.Text;
            //    F1.database = tbxBasedata.Text;
            //    Close();
            //}
            //else { MessageBox.Show("Complet the camps", "Ups!"); F1.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
