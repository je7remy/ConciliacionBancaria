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
using CapaNegocio;
using CapaDatos;



namespace ConciliacionBancaria
{
    public partial class FMCB : Form
    {
        // Variables globales
        public string mensaje = "";

        public FMCB()
        {
            InitializeComponent();
            

        }

      

        private void FMBancos_Load(object sender, EventArgs e)
        {
           
            

            

         
        }











        private void FMBancos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar la Conciliacion Bancaria?", "Cerrar Conciliacion Bancaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Bsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void Bguardar_Click(object sender, EventArgs e)
        {
           
        }


        private void Bcancelar_Click(object sender, EventArgs e)
        {
          
        }

      

      

       




      
    }
}
