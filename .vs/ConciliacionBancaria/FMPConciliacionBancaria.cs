using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Agregamos lo siguiente para utilizar SQL
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CapaDatos;
using CapaNegocio;

namespace ConciliacionBancaria
{
    public partial class FMPConciliacionBancaria : Form
    {

        // Variables globales
        public string mensaje = "";


        public FMPConciliacionBancaria()
        {
            InitializeComponent();

        }

        private void Bsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FMPConciliacionBancaria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar la Conciliacion Bancaria?", "Cerrar Conciliacion Bancaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}