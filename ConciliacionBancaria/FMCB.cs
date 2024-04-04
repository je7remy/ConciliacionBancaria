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
            CargarBancos();
            CargarCuentas();





        }


        private void CargarBancos()
        {
            try
            {
                string query = "ObtenerBancos";

                // Utiliza un bloque using para garantizar que la conexión se cierre correctamente
                SqlConnection sqlCon = CapaPresentacionConexion.ObtenerConexion();
                {
                    using (SqlCommand command = new SqlCommand(query, sqlCon))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        sqlCon.Open();
                        DataTable dt = new DataTable();

                        // Utiliza un SqlDataAdapter para llenar un DataTable con los resultados del procedimiento almacenado
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }

                        // Asigna el DataTable como origen de datos para el ComboBox
                        textBoxbancoid.DisplayMember = "Nombre";
                        textBoxbancoid.ValueMember = "BancoID";
                        textBoxbancoid.DataSource = dt;
                    }
                } // La conexión se cerrará automáticamente al salir del bloque using
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error al cargar bancos: " + ex.Message);
            }
        }



        private void CargarCuentas()
        {
            try
            {
                string query = "ObtenerCuentas";

                // Utiliza un bloque using para garantizar que la conexión se cierre correctamente
                SqlConnection sqlCon = CapaPresentacionConexion.ObtenerConexion();
                {
                    using (SqlCommand command = new SqlCommand(query, sqlCon))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        sqlCon.Open();
                        DataTable dt = new DataTable();

                        // Utiliza un SqlDataAdapter para llenar un DataTable con los resultados del procedimiento almacenado
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }

                        // Asigna el DataTable como origen de datos para el ComboBox
                        textBoxcuentaid.DisplayMember = "TipoCuenta";
                        textBoxcuentaid.ValueMember = "CuentaID";
                        textBoxcuentaid.DataSource = dt;
                    }
                } // La conexión se cerrará automáticamente al salir del bloque using
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error al cargar Cuentas: " + ex.Message);
            }
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
