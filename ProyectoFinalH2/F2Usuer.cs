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
    public partial class F2Usuer : Form
    {
        public F2Usuer()
        {
            InitializeComponent();
        }
        SqlComands comSQL = new SqlComands();
        Form1 F1 = new Form1();
        private void F2Usuer_Load(object sender, EventArgs e)
        {
            comSQL.funTableCars(F1.server, F1.database, dataGridCars);
            radiBtnRent.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTStar_ValueChanged(object sender, EventArgs e)
        {
            if(dateTStar.Value < DateTime.Today) 
            {
                MessageBox.Show("Past dates cannot be selected", "Ey!"); 
                dateTStar.Value = DateTime.Today;
            }
        }

        private void dateTEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dateTEnd.Value < DateTime.Today)
            {
                MessageBox.Show("Past dates cannot be selected", "Ey!");
                dateTEnd.Value = DateTime.Today;
            }
        }

        private void btnCancelRent_Click(object sender, EventArgs e)
        {
            radiBtnRent.Checked = false;
            radiBtnReserver.Checked = false;
            dateTStar.Value = DateTime.Today;
            dateTEnd.Value = DateTime.Today;
        }
    }
}
