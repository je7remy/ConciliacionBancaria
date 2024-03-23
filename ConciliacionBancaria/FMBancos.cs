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


namespace ConciliacionBancaria
{
    public partial class FMBancos : Form
    {
        // Variables globales
        public string mensaje = "";

        public FMBancos()
        {
            InitializeComponent();
           
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FMBancos_Load(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            CargarCatalogos();
        }


        private void CargarCatalogos()
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;
            AttachDbFilename = C:\C#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
Integrated Security = True"; // Reemplaza esto con tu cadena de conexión
            string query = "ObtenerCatalogos"; // Nombre del procedimiento almacenado

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                // Utiliza un SqlDataAdapter para llenar un DataTable con los resultados del procedimiento almacenado
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                // Asigna el DataTable como origen de datos para el ComboBox
                textBoxcatalogoid.DisplayMember = "Nombre";
                textBoxcatalogoid.ValueMember = "CatalogoID";
                textBoxcatalogoid.DataSource = dt;
            }
        }



        private void FMBancos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Mantenimiento Bancos?", "Cerrar Bancos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Bsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LimpiaObjetos()
        {
            textBoxbanco.Clear();
            textBoxcatalogoid.SelectedIndex = -1;
            textBoxcorreo.Clear();
            textBoxdireccion.Clear();
            textBoxestado.SelectedIndex = -1;
            textBoxnombre.Clear();
            textBoxobservaciones.Clear();
            textBoxoficialdecuentas.Clear();
            textBoxsucursal.Clear();
            textBoxtelefono.Clear();
        }

        private void HabilitaControles(bool valor)
        {
            textBoxbanco.ReadOnly = !valor;
            textBoxcorreo.Enabled = valor;
            textBoxdireccion.Enabled = valor;
            textBoxestado.Enabled = valor;
            textBoxnombre.Enabled = valor;
            textBoxobservaciones.Enabled = valor;
            textBoxoficialdecuentas.Enabled = valor;
            textBoxsucursal.Enabled = valor;
            textBoxtelefono.Enabled = valor;
            if (Program.nuevo)
                textBoxestado.SelectedIndex = 0;
            textBoxcatalogoid.SelectedIndex = 0;
        }

        private void Bnuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
            Program.nuevo = true;
            Program.modificar = false;
            HabilitaBotones();
            textBoxnombre.Focus();

            // Obtener el último ID insertado y asignarlo al textBoxbanco
            int ultimoIDInsertado = ObtenerUltimoBancoIDInsertado();
            textBoxbanco.Text = (ultimoIDInsertado + 1).ToString();
        }

        private void Bguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxbanco.Text) ||
                string.IsNullOrEmpty(textBoxcatalogoid.Text) ||
                string.IsNullOrEmpty(textBoxcorreo.Text) ||
                string.IsNullOrEmpty(textBoxdireccion.Text) ||
                string.IsNullOrEmpty(textBoxestado.Text) ||
                string.IsNullOrEmpty(textBoxnombre.Text) ||
                string.IsNullOrEmpty(textBoxobservaciones.Text) ||
                string.IsNullOrEmpty(textBoxoficialdecuentas.Text) || //cambiar esto a como esta en el pdf pendejo
                string.IsNullOrEmpty(textBoxsucursal.Text) ||
                string.IsNullOrEmpty(textBoxtelefono.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("voy a guardar");

                if (Program.nuevo)
                {
                    mensaje = CNBancos.Insertar(textBoxnombre.Text, textBoxsucursal.Text,
                                                  textBoxdireccion.Text, textBoxestado.Text,
                                                  textBoxtelefono.Text, textBoxcorreo.Text,
                                                  textBoxoficialdecuentas.Text, textBoxobservaciones.Text);

                    int ultimoIDInsertado = ObtenerUltimoBancoIDInsertado();
                    if (ultimoIDInsertado > 0)
                    {
                        textBoxbanco.Text = ultimoIDInsertado.ToString();
                        textBoxbanco.Text = (ultimoIDInsertado + 1).ToString();
                    }
                }
                else
                {
                    mensaje = CNBancos.Actualizar(Program.BancoID, textBoxnombre.Text,
                                                   textBoxsucursal.Text, textBoxdireccion.Text,
                                                   textBoxestado.Text, textBoxtelefono.Text,
                                                   textBoxcorreo.Text, textBoxoficialdecuentas.Text,
                                                   textBoxobservaciones.Text);

                }

            }



            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar banco: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } 

           MessageBox.Show(mensaje, "Mensaje de Conciliacion Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            LimpiaObjetos();
        }

        private void Bcancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            LimpiaObjetos();
        }

        private void Beditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxbanco.Text))
            {
                MessageBox.Show("Debe seleccionar un banco para modificar sus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.modificar = true;
            HabilitaBotones();
        }

        private void FMBancos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            if (Program.modificar)
            {
                RecuperaDatos();
                Beditar_Click(sender, e);
            }
            else
            {
                LimpiaObjetos();
                Bbuscar.Focus();
            }
        }

        public void RecuperaDatos()
        {
            int bancoID = Program.BancoID; // Obtener el ID del banco de Program
            // Llamada al método estático ObtenerBancoPorID de la clase CNBancos
            DataTable dt = CNBancos.ObtenerBancoPorID(bancoID);

            foreach (DataRow row in dt.Rows)
            {
                textBoxbanco.Text = row["BancoID"].ToString();
                textBoxcatalogoid.Text = row["CatalogoID"].ToString();
                textBoxcorreo.Text = row["Correo"].ToString();
                textBoxdireccion.Text = row["Direccion"].ToString();
                textBoxestado.Text = row["Estado"].ToString();
                textBoxnombre.Text = row["Nombre"].ToString();
                textBoxobservaciones.Text = row["Observaciones"].ToString();
                textBoxoficialdecuentas.Text = row["Oficial_de_Cuentas"].ToString();
                textBoxsucursal.Text = row["Sucursal"].ToString();
                textBoxtelefono.Text = row["Telefono"].ToString();
            }
        }



        private int ObtenerUltimoBancoIDInsertado()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;Integrated Security=True";
            string query = "SELECT IDENT_CURRENT('Bancos') AS UltimoID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return 0;
                }
            }
        }




        private void HabilitaBotones()
        {
            if (Program.nuevo || Program.modificar)
            {
                HabilitaControles(true);
                Bnuevo.Enabled = false;
                Bguardar.Enabled = true;
                Beditar.Enabled = false;
                Bbuscar.Enabled = false;
                Bcancelar.Enabled = true;
            }
            else
            {
                HabilitaControles(false);
                Bnuevo.Enabled = true;
                Bguardar.Enabled = false;
                Beditar.Enabled = false;
                Bbuscar.Enabled = true;
                Bcancelar.Enabled = false;
            }
        }
    }
}
