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
    public partial class F3Admin : Form
    {
        public F3Admin()
        {
            InitializeComponent();
        }

        SqlComands SQLCmd = new SqlComands();
        Form1 F1 = new Form1();

        private void F3Admin_Load(object sender, EventArgs e)
        {
            SQLCmd.funTableCarsAll(F1.server, F1.database, dataGridCars);
            SQLCmd.funTableClientes(F1.server, F1.database, dataGridViewCliente);
            
        }

        private void txtPlacaCar_TextChanged(object sender, EventArgs e)
        {
            SQLCmd.funTableCarsHistory(F1.server, F1.database, txtPlacaCar.Text, dataGridViewArrReser);
        }

        private void dataGridCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPlacaCar.Text = dataGridCars.SelectedCells[0].Value.ToString();
            txtPlaca.Text = dataGridCars.SelectedCells[0].Value.ToString();
            txtModelo.Text = dataGridCars.SelectedCells[1].Value.ToString();
            txtTipo.Text = dataGridCars.SelectedCells[2].Value.ToString();
            txtDispo.Text = dataGridCars.SelectedCells[3].Value.ToString();
            txtColor.Text = dataGridCars.SelectedCells[4].Value.ToString();
            txtPuertas.Text = dataGridCars.SelectedCells[5].Value.ToString();
            txtAsiento.Text = dataGridCars.SelectedCells[6].Value.ToString();
            txtPrecio.Text = dataGridCars.SelectedCells[7].Value.ToString();
        }

        private void dataGridViewCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIDClient.Text = dataGridViewCliente.SelectedCells[0].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbPut.Checked)
            {
                SQLCmd.funEditPenality(F1.server, F1.database,1,Convert.ToInt32(lblIDClient.Text));
            }
            else if(rdbRemove.Checked)
            {
                SQLCmd.funEditPenality(F1.server, F1.database, 0, Convert.ToInt32(lblIDClient.Text));
            }
            SQLCmd.funTableClientes(F1.server, F1.database, dataGridViewCliente);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SQLCmd.funDeleteCar(F1.server, F1.database,txtPlaca.Text);
            MessageBox.Show("You deleted a vehicle from the database.", "Important.");
            SQLCmd.funTableCarsAll(F1.server, F1.database, dataGridCars);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != "" && txtModelo.Text != "" && txtTipo.Text != "" && txtDispo.Text != "" && txtColor.Text != "" && txtPuertas.Text != "" && txtAsiento.Text != "" && txtPrecio.Text != "")
            {
                int Dispo;
                if (txtDispo.Text == "True") { Dispo = 1; }
                else if (txtDispo.Text == "False") { Dispo = 0; }
                else { Dispo = 0; }
                int eje = SQLCmd.funAddCar(F1.server, F1.database, txtPlaca.Text, txtModelo.Text, txtTipo.Text, Dispo, txtColor.Text, Convert.ToInt32(txtPuertas.Text), Convert.ToInt32(txtAsiento.Text), Convert.ToInt32(txtPrecio.Text));
                if (eje > 0) { MessageBox.Show("New cart successfully added", "Ok."); }
                SQLCmd.funTableCarsAll(F1.server, F1.database, dataGridCars);
            }
            else { MessageBox.Show("All required fields","Ey!"); }


           

        }
    }
}
