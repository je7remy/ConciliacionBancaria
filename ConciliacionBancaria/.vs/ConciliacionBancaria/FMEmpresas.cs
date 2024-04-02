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
    public partial class FMEmpresas : Form
    {


        // Variables globales
        public string mensaje = "";



        public FMEmpresas()
        {
            InitializeComponent();

        }


        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Matenimiento Empresas?", "Cerrar Empresas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close(); // Cierra el formulario si el usuario confirma
            }


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
            LimpiaObjetos();
        }

        private void Bsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public void LimpiaObjetos()
        {
            textBoxcorreo.Clear();
            textBoxdireccion.Clear();
            textBoxempresa.Clear();
            textBoxestado.SelectedIndex = -1;
            textBoxinoinformacion.Clear();
            textBoxnombre.Clear();
            textBoxtelefono.Clear();

        }


        private void HabilitaControles(bool valor)
        {
            textBoxempresa.ReadOnly = !valor;
            textBoxcorreo.Enabled = valor;
            textBoxinoinformacion.Enabled = valor;
            textBoxdireccion.Enabled = valor;
            textBoxestado.Enabled = valor;
            textBoxnombre.Enabled = valor;
            textBoxtelefono.Enabled = valor;
            if (Program.nuevo)
                textBoxestado.SelectedIndex = 0;
            //    textBoxcatalogoid.SelectedIndex = 0;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FMEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Mantenimiento Empresas?", "Cerrar Empresas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Bnuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
            Program.nuevo = true;
            Program.modificar = false;
            HabilitaBotones();
            textBoxnombre.Focus();

            //// Obtener el último ID insertado y asignarlo al textBoxbanco
            int ultimoIDInsertado = ObtenerUltimoIDInsertado("Empresas");
            textBoxempresa.Text = (ultimoIDInsertado + 1).ToString();
            //+ 1
        }

        private void Bguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxcorreo.Text))
                {
                    MessageBox.Show("Debe indicar el Correo de la Empresa!");
                    textBoxcorreo.Focus();
                    return; // Agregamos un return aquí para salir del método si un campo está vacío
                }
                else if (string.IsNullOrEmpty(textBoxdireccion.Text))
                {
                    MessageBox.Show("Debe indicar la Dirección de la Empresa!");
                    textBoxdireccion.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxempresa.Text))
                {
                    MessageBox.Show("Debe indicar la Empresa!");
                    textBoxempresa.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxestado.Text))
                {
                    MessageBox.Show("Debe indicar el Estado!");
                    textBoxestado.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxinoinformacion.Text))
                {
                    MessageBox.Show("Debe indicar Información!");
                    textBoxinoinformacion.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxnombre.Text))
                {
                    MessageBox.Show("Debe indicar el Nombre del Suplidor!");
                    textBoxnombre.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxtelefono.Text))
                {
                    MessageBox.Show("Debe indicar el Teléfono!");
                    textBoxtelefono.Focus();
                    return;
                }
                string mensaje = "";

                if (Program.nuevo)
                {
                    mensaje = CNEmpresas.Insertar(textBoxnombre.Text, textBoxdireccion.Text, textBoxinoinformacion.Text, textBoxtelefono.Text,
                        textBoxcorreo.Text, textBoxestado.Text);

                    int ultimoIDInsertado;
                    if (int.TryParse(textBoxempresa.Text, out ultimoIDInsertado))
                    {
                        if (ultimoIDInsertado > 0)
                        {
                            textBoxempresa.Text = ultimoIDInsertado.ToString();
                            textBoxempresa.Text = (ultimoIDInsertado + 1).ToString();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    mensaje = CNEmpresas.Actualizar(Program.EmpresaID, textBoxnombre.Text, textBoxdireccion.Text, textBoxinoinformacion.Text, textBoxtelefono.Text,
                        textBoxcorreo.Text, textBoxestado.Text);
                }

                MessageBox.Show(mensaje, "Mensaje de Conciliacion Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Program.nuevo = false;
                Program.modificar = false;
                HabilitaBotones();
                LimpiaObjetos();

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al insertar banco: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Bcancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            LimpiaObjetos();
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {


            BusquedaEmpresas BusquedaEmpresas = new BusquedaEmpresas();
            BusquedaEmpresas.ShowDialog();

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

        private void FMEmpresas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Beditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxempresa.Text))
            {
                MessageBox.Show("Debe seleccionar un banco para modificar sus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.modificar = true;
            HabilitaBotones();
        }


        public void RecuperaDatos()
        {
            int empresaID = Program.EmpresaID;
            // Llamada al método estático ObtenerBancoPorID de la clase CNBancos
            DataTable dt = CNEmpresas.ObtenerEmpresaPorID(empresaID);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0]; // Obtener la primera fila de los resultados

                textBoxcorreo.Text = row["Correo"].ToString();
                textBoxdireccion.Text = row["Direccion"].ToString();
                textBoxempresa.Text = row["EmpresaID"].ToString(); // Reemplaza "Empresa" con el nombre de la columna que contiene los datos de la empresa en la tabla
                textBoxestado.SelectedItem = row["Estado"].ToString(); // Establece el elemento seleccionado en el ComboBox según el valor del campo "Estado" en la tabla
                textBoxinoinformacion.Text = row["InformacionContacto"].ToString(); // Reemplaza "Info_Ino" con el nombre de la columna que contiene la información enooinformación en la tabla
                textBoxnombre.Text = row["NombreEmpresa"].ToString();
                textBoxtelefono.Text = row["Telefono"].ToString();
            }
            else
            {
                // Manejar el caso en el que no se encuentren datos para el ID proporcionado
                // Por ejemplo, mostrar un mensaje de error o limpiar los campos
                // Aquí se muestra un ejemplo de cómo limpiar los campos:
                textBoxcorreo.Text = "";
                textBoxdireccion.Text = "";
                textBoxempresa.Text = "";
                textBoxestado.SelectedItem = null;
                textBoxinoinformacion.Text = "";
                textBoxnombre.Text = "";
                textBoxtelefono.Text = "";

            }

        }



        private void ObtenerUltimoIDInsertado()
        {
            try
            {
                // Llamada al método con el nombre de la tabla "Bancos"
                int ultimoID = ObtenerUltimoIDInsertado("Empresas");

                // Aquí puedes usar el último ID obtenido como desees, por ejemplo, mostrarlo en un MessageBox
                MessageBox.Show("Último ID insertado para la tabla 'Empresas': " + ultimoID);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error al obtener el último ID insertado: " + ex.Message);
            }
        }

        public static int ObtenerUltimoIDInsertado(string tabla)
        {
            using (SqlConnection connection = CapaPresentacionConexion.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("ObtenerUltimoIDInsertado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Tabla", tabla);

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