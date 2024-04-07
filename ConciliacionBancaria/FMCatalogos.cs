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
    public partial class FMCatalogos : Form
    {


        // Variables globales
        public string mensaje = "";


        public FMCatalogos()
        {
            InitializeComponent();

        }


        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Matenimiento Catalogos?", "Cerrar Catalogos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            textBoxbalance.Clear();
            textBoxcatalogoid.Clear();
            textBoxcuentaspadres.SelectedIndex = -1;
            textBoxdescripcion.Clear();
            textBoxestado.SelectedIndex = -1;
            textBoxnombre.Clear();
            textBoxorigen.Clear();


        }



        private void HabilitaControles(bool valor)
        {
            textBoxcatalogoid.ReadOnly = !valor;
            textBoxbalance.Enabled = valor;
            textBoxcuentaspadres.Enabled = valor;
            textBoxdescripcion.Enabled = valor;
            textBoxestado.Enabled = valor;
            textBoxnombre.Enabled = valor;
            textBoxorigen.Enabled = valor;

            if (Program.nuevo)
                textBoxcuentaspadres.SelectedIndex = 0;
            textBoxestado.SelectedIndex = 0;
        }



        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FMCatalogos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Mantenimiento Catalogos?", "Cerrar Catalogos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
            int ultimoIDInsertado = ObtenerUltimoIDInsertado("Catalogos");
            textBoxcatalogoid.Text = (ultimoIDInsertado + 1).ToString();
        }


        private void Bguardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(textBoxcuentaspadres.Text))
                {
                    MessageBox.Show("Debe indicar el nombre de la cuenta padre!");
                    textBoxcuentaspadres.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBoxnombre.Text))
                {
                    MessageBox.Show("Debe indicar el nombre de la cuenta!");
                    textBoxnombre.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxcatalogoid.Text))
                {
                    MessageBox.Show("Debe indicar el ID del Catálogo!");
                    textBoxcatalogoid.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxdescripcion.Text))
                {
                    MessageBox.Show("Debe indicar la Descripción de la cuenta!");
                    textBoxdescripcion.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxorigen.Text))
                {
                    MessageBox.Show("Debe indicar el Origen de la cuenta!");
                    textBoxorigen.Focus();
                    return;
                }

                // Obteniendo el monto
                decimal Balance = 0;
                if (textBoxbalance.Text == String.Empty || !decimal.TryParse(textBoxbalance.Text, out Balance))
                {
                    MessageBox.Show("El valor ingresado para el balance no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string mensaje = "";

                if (Program.nuevo)
                {
                    mensaje = CNCatalogos.Insertar(textBoxnombre.Text,
                                                      textBoxdescripcion.Text,
                                                      textBoxcuentaspadres.Text,
                                                      textBoxorigen.Text,
                                                      Balance,
                                                      textBoxestado.Text);

                    int ultimoIDInsertado;
                    if (int.TryParse(textBoxcatalogoid.Text, out ultimoIDInsertado))
                    {
                        if (ultimoIDInsertado > 0)
                        {
                            textBoxcatalogoid.Text = ultimoIDInsertado.ToString();
                            textBoxcatalogoid.Text = (ultimoIDInsertado + 1).ToString();
                        }
                        else
                        {

                            return;
                        }
                    }

                }
                else
                {
                    mensaje = CNCatalogos.Actualizar(Program.CatalogoID, textBoxnombre.Text,
                                                              textBoxdescripcion.Text,
                                                              textBoxcuentaspadres.Text,
                                                              textBoxorigen.Text,
                                                              Balance,
                                                              textBoxestado.Text);

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
            BusquedaCatalogos BusquedaCatalogos = new BusquedaCatalogos();
            BusquedaCatalogos.ShowDialog();

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

        private void FMCatalogos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Beditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxcatalogoid.Text))
            {
                MessageBox.Show("Debe seleccionar un banco para modificar sus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.modificar = true;
            HabilitaBotones();
        }



        public void RecuperaDatos()
       
            {
                int CatalogoID = Program.CatalogoID;
                // Llamada al método estático ObtenerCuentaPorID de la clase CNCuentas
                DataTable dt = CNCatalogos.ObtenerCatalogoPorID(CatalogoID, null);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0]; // Obtener la primera fila de los resultados

                    textBoxbalance.Text = row["Balance"].ToString();
                    textBoxcatalogoid.Text = row["CatalogoID"].ToString();
                    textBoxcuentaspadres.SelectedItem = row["Cuentas_Padres"].ToString();
                    textBoxdescripcion.Text = row["Descripcion"].ToString();
                    textBoxestado.SelectedItem = row["Estado"].ToString();
                    textBoxnombre.Text = row["Nombre"].ToString();
                    textBoxorigen.Text = row["Origen"].ToString();
                }
                else
                {
                    // Manejar el caso en el que no se encuentren datos para el ID proporcionado
                    // Por ejemplo, mostrar un mensaje de error o limpiar los campos
                    // Aquí se muestra un ejemplo de cómo limpiar los campos:
                    textBoxbalance.Text = "";
                    textBoxcatalogoid.Text = "";
                    textBoxcuentaspadres.SelectedItem = null;
                    textBoxdescripcion.Text = "";
                    textBoxestado.SelectedItem = null;
                    textBoxnombre.Text = "";
                    textBoxorigen.Text = "";
                }
            }




        private void ObtenerUltimoIDInsertado()
        {
            try
            {
                // Llamada al método con el nombre de la tabla "Bancos"
                int ultimoID = ObtenerUltimoIDInsertado("Catalogos");

                // Aquí puedes usar el último ID obtenido como desees, por ejemplo, mostrarlo en un MessageBox
                MessageBox.Show("Último ID insertado para la tabla 'Catalogos': " + ultimoID);
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