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
       
            LimpiaObjetos();
            ObtenerCatalogos();

            

         
        }





        public DataTable ObtenerCatalogos()
        {
            try
            {
                // Defina la consulta para obtener los datos del catálogo
                string query = "ObtenerCatalogos";

                // Utiliza un bloque using para garantizar que la conexión se cierre correctamente
                using (SqlConnection sqlCon = CapaPresentacionConexion.ObtenerConexion())
                {
                    // Crea un nuevo comando SQL con la consulta y el tipo de comando
                    using (SqlCommand command = new SqlCommand(query, sqlCon))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Abre la conexión y ejecuta la consulta
                        sqlCon.Open();
                        DataTable dt = new DataTable();

                        // Utiliza un SqlDataAdapter para llenar un DataTable con los resultados de la consulta
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }


                        // Asigna el DataTable como origen de datos para el ComboBox

                        textBoxcatalogoid.DisplayMember = "Nombre";
                        textBoxcatalogoid.ValueMember = "CatalogoID";
                        textBoxcatalogoid.DataSource = dt;



                        return dt; // Devuelve el DataTable con los datos del catálogo
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error al cargar catálogos: " + ex.Message);
                return null; // Agrega este return para manejar todas las rutas de acceso del código
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
            //textBoxbanco.Clear();
            textBoxcatalogoid.SelectedIndex = -1;
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
            textBoxcatalogoid.Enabled = valor;
            textBoxdireccion.Enabled = valor;
            textBoxestado.Enabled = valor;
            textBoxnombre.Enabled = valor;
            textBoxobservaciones.Enabled = valor;
            textBoxoficialdecuentas.Enabled = valor;
            textBoxsucursal.Enabled = valor;
            textBoxtelefono.Enabled = valor;
            if (Program.nuevo)
                textBoxestado.SelectedIndex = 0;
           // textBoxcatalogoid.SelectedIndex = 0;
        }

        private void Bnuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
            Program.nuevo = true;
            Program.modificar = false;
            HabilitaBotones();
            textBoxnombre.Focus();

            //// Obtener el último ID insertado y asignarlo al textBoxbanco
            int ultimoIDInsertado = ObtenerUltimoIDInsertado("Bancos");
            textBoxbanco.Text = (ultimoIDInsertado + 1).ToString();
        }

        private void Bguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxbanco.Text))
                {
                    MessageBox.Show("Debe indicar el nombre del Banco!");
                    textBoxbanco.Focus();
                    return; // Agregamos un return aquí para salir del método si un campo está vacío
                }
                else if (string.IsNullOrEmpty(textBoxcatalogoid.Text))
                {
                    MessageBox.Show("Debe indicar el ID del Catálogo!");
                    textBoxcatalogoid.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxcorreo.Text))
                {
                    MessageBox.Show("Debe indicar el Correo del Suplidor!");
                    textBoxcorreo.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxdireccion.Text))
                {
                    MessageBox.Show("Debe indicar la Dirección del Suplidor!");
                    textBoxdireccion.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxestado.Text))
                {
                    MessageBox.Show("Debe indicar el Estado!");
                    textBoxestado.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxnombre.Text))
                {
                    MessageBox.Show("Debe indicar el Nombre del Suplidor!");
                    textBoxnombre.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxobservaciones.Text))
                {
                    MessageBox.Show("Debe indicar Observaciones!");
                    textBoxobservaciones.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxoficialdecuentas.Text))
                {
                    MessageBox.Show("Debe indicar el Oficial de Cuentas!");
                    textBoxoficialdecuentas.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxsucursal.Text))
                {
                    MessageBox.Show("Debe indicar la Sucursal!");
                    textBoxsucursal.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxtelefono.Text))
                {
                    MessageBox.Show("Debe indicar el Teléfono!");
                    textBoxtelefono.Focus();
                    return;
                }

                string mensaje = "";


                // Obteniendo el CatalogoID

                int CatalogoID;
                Program.CatalogoID = CatalogoID = 0;

                if (textBoxcatalogoid.SelectedItem != null && textBoxcatalogoid.SelectedItem is DataRowView)
                {
                    DataRowView selectedRow = textBoxcatalogoid.SelectedItem as DataRowView;

                    // Intenta convertir el valor de la columna "Id_Catalogo" a un entero
                    if (selectedRow.Row["CatalogoID"] != null && int.TryParse(selectedRow.Row["CatalogoID"].ToString(), out CatalogoID))
                    {
                        // La conversión fue exitosa, ahora puedes usar el valor del CatalogoID
                        //  MessageBox.Show("Los datos del banco han sido guardados correctamente.", "Éxito al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        // La conversión falló, el valor de "Id_Catalogo" no es un número entero válido
                        MessageBox.Show("El valor del ID del Catálogo no es un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (Program.nuevo)
                    {
                        mensaje = CNBancos.Insertar(CatalogoID, textBoxnombre.Text, textBoxsucursal.Text,
                                                      textBoxdireccion.Text, textBoxestado.Text,
                                                      textBoxtelefono.Text, textBoxcorreo.Text,
                                                      textBoxoficialdecuentas.Text, textBoxobservaciones.Text);

                        int ultimoIDInsertado;
                        if (int.TryParse(textBoxbanco.Text, out ultimoIDInsertado))
                        {
                            if (ultimoIDInsertado > 0)
                            {
                                textBoxbanco.Text = ultimoIDInsertado.ToString();
                                textBoxbanco.Text = (ultimoIDInsertado + 1).ToString();
                            }
                            else
                            {
                              
                                return;
                            }
                        }
                     
                    }
                    else
                    {//CatalogoID
                        mensaje = CNBancos.Actualizar(Program.BancoID, CatalogoID, textBoxnombre.Text,
                                                       textBoxsucursal.Text, textBoxdireccion.Text,
                                                       textBoxestado.Text, textBoxtelefono.Text,
                                                       textBoxcorreo.Text, textBoxoficialdecuentas.Text,
                                                       textBoxobservaciones.Text);

                    }

                    MessageBox.Show(mensaje, "Mensaje de Conciliacion Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.nuevo = false;
                    Program.modificar = false;
                    HabilitaBotones();
                    LimpiaObjetos();
                }

                else
                {
                    MessageBox.Show("Debe seleccionar un catálogo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
            textBoxcatalogoidm.Visible = false;
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
            BusquedaBancos busqueda_Bancos = new BusquedaBancos();
            busqueda_Bancos.ShowDialog();

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

        /// <summary>
        /// Recupera los datos del banco y su catálogo asociado y los muestra en los controles correspondientes.
        /// </summary>
        public void RecuperaDatos()
        {
            // Obtener el ID del banco de Program
            int bancoID = Program.BancoID;

            // Llamada al método estático ObtenerBancoPorID de la clase CNBancos para obtener los datos del banco
            DataTable dtBanco = CNBancos.ObtenerBancoPorID(bancoID);

            // Verificar si se encontraron datos del banco
            if (dtBanco.Rows.Count > 0)
            {
                // Obtener la primera fila de los resultados del banco
                DataRow rowBanco = dtBanco.Rows[0];

                // Mostrar los datos del banco en los controles correspondientes
                textBoxbanco.Text = rowBanco["BancoID"].ToString();
                textBoxcorreo.Text = rowBanco["Correo"].ToString();
                textBoxdireccion.Text = rowBanco["Direccion"].ToString();
                textBoxestado.Text = rowBanco["Estado"].ToString();
                textBoxnombre.Text = rowBanco["Nombre"].ToString();
                textBoxobservaciones.Text = rowBanco["Observaciones"].ToString();
                textBoxoficialdecuentas.Text = rowBanco["Oficial_de_Cuentas"].ToString();
                textBoxsucursal.Text = rowBanco["Sucursal"].ToString();
                textBoxtelefono.Text = rowBanco["Telefono"].ToString();

                // Obtener el ID del catálogo asociado al banco
                int catalogoID = Convert.ToInt32(rowBanco["CatalogoID"]);

                // Llamada al método estático ObtenerCatalogoPorID de la clase CNCatalogos para obtener los datos del catálogo
                DataTable dtCatalogo = CNCatalogos.ObtenerCatalogoPorID(catalogoID);

                // Verificar si se encontraron datos del catálogo
                if (dtCatalogo.Rows.Count > 0)
                {
                    // Obtener la primera fila de los resultados del catálogo
                    DataRow rowCatalogo = dtCatalogo.Rows[0];

                    // Obtener el nombre del catálogo
                    string nombreCatalogo = rowCatalogo["Nombre"].ToString();

                    // Agregar el nombre del catálogo al ComboBox textBoxcatalogoid y seleccionarlo
                    textBoxcatalogoidm.Items.Add(nombreCatalogo);
                    textBoxcatalogoidm.SelectedIndex = textBoxcatalogoidm.Items.Count - 1;
                    textBoxcatalogoidm.Visible = true;
                }
                else
                {
                    // Limpiar el campo si no se encontraron datos del catálogo
                    textBoxcatalogoidm.Text = "";
                }
            }
            else
            {
                // Limpiar todos los controles si no se encontraron datos del banco
                textBoxbanco.Text = "";
                textBoxcorreo.Text = "";
                textBoxdireccion.Text = "";
                textBoxestado.Text = "";
                textBoxnombre.Text = "";
                textBoxobservaciones.Text = "";
                textBoxoficialdecuentas.Text = "";
                textBoxsucursal.Text = "";
                textBoxtelefono.Text = "";

                // Limpiar el campo catalogonombre si no se encontraron datos del banco
                textBoxcatalogoidm.Text = "";
            }
        }






        private void ObtenerUltimoIDInsertado()
        {
            try
            {
                // Llamada al método con el nombre de la tabla "Bancos"
                int ultimoID = ObtenerUltimoIDInsertado("Bancos");

                // Aquí puedes usar el último ID obtenido como desees, por ejemplo, mostrarlo en un MessageBox
                MessageBox.Show("Último ID insertado para la tabla 'Bancos': " + ultimoID);
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

        private void textBoxcatalogoidm_Click(object sender, EventArgs e)
        {
            textBoxcatalogoidm.Visible = false;
        }
    }
}
