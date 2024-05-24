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
        int sancion;
        private void F2Usuer_Load(object sender, EventArgs e)
        {
            comSQL.funTableCars(F1.server, F1.database, dataGridCars);
            sancion = comSQL.funSancion(F1.server, F1.database, Convert.ToInt32(lblUserID.Text));
            if (sancion == 1)
            {
                btnAcceptRent.Enabled = false;
                lblInformation.Text = "You cannot rent a new car, you have a penalty, pay the penalty first to rent a new car.";
                btnPayPenality.Enabled = true;
            }
            else 
            {
                btnAcceptRent.Enabled = true;
                lblInformation.Text = "All ok.";
                btnPayPenality.Enabled = false;
            }
            radiBtnRent.Checked = true;
            dataGridCars.Columns["Disponible"].Visible = false;
            dataGridCars.Columns["N_Puertas"].Visible = false;
            dataGridCars.Columns["Asientos"].Visible = false;
            dataGridCars.Columns["Precio_Dia"].Visible = false;
            dataGridCars.Columns["Imagen"].Visible = false;


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

        private void dataGridCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblNDoors.Text = dataGridCars.SelectedCells[5].Value.ToString();
            lblPlaces.Text = dataGridCars.SelectedCells[6].Value.ToString();
            lblPrice.Text = $"$ {dataGridCars.SelectedCells[7].Value.ToString()}";
        }

        private void btnAcceptRent_Click(object sender, EventArgs e)
        {
            if(dateTStar.Value > dateTEnd.Value)
            {
                dateTStar.Value = DateTime.Today;
                dateTEnd.Value = DateTime.Today;
                MessageBox.Show("You can't do that.", "Ups!.");
            }
            else
            {
                int IDC = Convert.ToInt32(lblUserID.Text);
                string Placa = dataGridCars.SelectedCells[0].Value.ToString();
                string Mode = "";
                int Value = 1;
                if (radiBtnRent.Checked) { Mode = "Rent"; Value = 0; } else if (radiBtnReserver.Checked) { Mode = "Reserve"; Value = 0; }
                DateTime fechaInicio = dateTStar.Value;
                DateTime fechaFin = dateTEnd.Value;
                comSQL.funTArriReser(F1.server, F1.database, IDC, Placa,Mode, fechaInicio, fechaFin);
                comSQL.funDispoCars(F1.server, F1.database,Value,Placa);
                MessageBox.Show($"Has {Mode} el vehiculo con placa {Placa} desde {fechaInicio} hasta el {fechaFin} por un valor de ${lblPrice.Text} por dia.","Felicidades") ;
                comSQL.funTableCars(F1.server, F1.database, dataGridCars);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have paid the penalty.", "Ok.");
            comSQL.funPaySancion(F1.server, F1.database, Convert.ToInt32(lblUserID.Text));
        }
    }
} 