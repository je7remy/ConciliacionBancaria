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
    public partial class FMTransacciones_Internas : Form
    {

        // Variables globales
        public string mensaje = "";

        public FMTransacciones_Internas()
        {
            InitializeComponent();

        }


        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Matenimiento Bancos?", "Cerrar Bancos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            CargarBancos();
            CargarCuentas();
            CargarUsuario();
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



        private void CargarUsuario()
        {
            try
            {
                string query = "ObtenerUsuarios";

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
                        textBoxusuarioid.DisplayMember = "NombreUsuario";
                        textBoxusuarioid.ValueMember = "UsuarioID";
                        textBoxusuarioid.DataSource = dt;
                    }
                } // La conexión se cerrará automáticamente al salir del bloque using
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error al cargar Usuario: " + ex.Message);
            }
        }

        private void Bsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void LimpiaObjetos()
        {


            textBoxbancoid.SelectedIndex = -1;
            textBoxclienteid.SelectedIndex = -1;
            textBoxcuentaid.SelectedIndex = -1;
            textBoxdescripcion.Clear();
            textBoxfecha.CustomFormat = "dd/MM/yyyy";
            textBoxfecha.Format = DateTimePickerFormat.Custom;
            textBoxmonto.Clear();
            textBoxobservacion.Clear();
            textBoxtipo.SelectedIndex = -1;
            textBoxtransaccionid.Clear();
            textBoxusuarioid.SelectedIndex = -1;

            if (textBoxfecha.Value == DateTime.MinValue)
            {
                textBoxfecha.Text = "01/01/1750";
            }

        }


        private void HabilitaControles(bool valor)
        {
            textBoxtransaccionid.ReadOnly = !valor;
            textBoxbancoid.Enabled = valor;
            textBoxclienteid.Enabled = valor;
            textBoxcuentaid.Enabled = valor;
            textBoxdescripcion.Enabled = valor;
            textBoxfecha.Enabled = valor;
            textBoxmonto.Enabled = valor;
            textBoxobservacion.Enabled = valor;
            textBoxobservacion.Enabled = valor;
            textBoxtipo.Enabled = valor;
            textBoxusuarioid.Enabled = valor;
            if (Program.nuevo)

                textBoxbancoid.SelectedIndex = 0;
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




        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FMTransacciones_Internas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Mantenimiento Transacciones Internas?", "Cerrar Transacciones Internas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
            textBoxfecha.Focus();


            //// Obtener el último ID insertado y asignarlo al textBoxbanco
            int ultimoIDInsertado = ObtenerUltimoIDInsertado("TransaccionesInternas");
            textBoxtransaccionid.Text = (ultimoIDInsertado + 1).ToString();
            //+ 1
        }


        private void Bguardar_Click(object sender, EventArgs e)
        {
           
                //Validamos los datos requeridos antes de Insertar o Actualizar
                if (textBoxtransaccionid.Text == String.Empty)
                {
                    MessageBox.Show("Debe seleccionar el ID de la Transacción!");
                    textBoxtransaccionid.Focus();
                }
                else if (textBoxclienteid.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el Cliente!");
                    textBoxclienteid.Focus();
                }
                else if (textBoxtipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el Tipo de Transacción!");
                    textBoxtipo.Focus();
                }
                else if (textBoxbancoid.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el ID del Banco!");
                    textBoxbancoid.Focus();
                }
                else if (textBoxdescripcion.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar la Descripción de la Transacción!");
                    textBoxdescripcion.Focus();
                }
                else if (textBoxmonto.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar el Monto!");
                    textBoxmonto.Focus();
                }
                else if (textBoxfecha.Value == null)
                {
                    MessageBox.Show("Debe indicar la Fecha!");
                    textBoxfecha.Focus();
                }
                else if (textBoxusuarioid.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el ID del Usuario!");
                    textBoxusuarioid.Focus();
                }
                else if (textBoxcuentaid.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el ID de la Cuenta!");
                    textBoxcuentaid.Focus();
                }
                else if (textBoxmonto.Text == String.Empty)
                {
                    MessageBox.Show("Debe seleccionar el Monto");
                    textBoxmonto.Focus();
                }
                else if (textBoxobservacion.Text == String.Empty)
                {
                    MessageBox.Show("Debe seleccionar la Observacion");
                    textBoxobservacion.Focus();
                }
                else
                {
                    string mensaje = "";

                    int BancoID =0;

                    // Obteniendo BancoID
                    if (textBoxbancoid.SelectedItem != null && textBoxbancoid.SelectedItem is DataRowView)
                    {
                        DataRowView selectedRow = textBoxbancoid.SelectedItem as DataRowView;
                        if (selectedRow.Row["BancoID"] != null && int.TryParse(selectedRow.Row["BancoID"].ToString(), out BancoID))
                        {
                            // La conversión fue exitosa
                        }
                        else
                        {
                            // Manejar el error de conversión
                            MessageBox.Show("Error al convertir el ID del Banco a entero.");
                            return;
                        }
                    }

                    // Obteniendo CuentaID
                    int CuentaID = 0;
                    if (textBoxcuentaid.SelectedItem != null && textBoxcuentaid.SelectedItem is DataRowView)
                    {
                        DataRowView selectedRow = textBoxcuentaid.SelectedItem as DataRowView;
                        if (selectedRow.Row["CuentaID"] != null && int.TryParse(selectedRow.Row["CuentaID"].ToString(), out CuentaID))
                        {
                            // La conversión fue exitosa
                        }
                        else
                        {
                            // Manejar el error de conversión
                            MessageBox.Show("Error al convertir el ID de la Cuenta a entero.");
                            return;
                        }
                    }

                    // Obteniendo UsuarioID
                    int UsuarioID = 0;
                    if (textBoxusuarioid.SelectedItem != null && textBoxusuarioid.SelectedItem is DataRowView)
                    {
                        DataRowView selectedRow = textBoxusuarioid.SelectedItem as DataRowView;
                        if (selectedRow.Row["UsuarioID"] != null && int.TryParse(selectedRow.Row["UsuarioID"].ToString(), out UsuarioID))
                        {
                            // La conversión fue exitosa
                        }
                        else
                        {
                            // Manejar el error de conversión
                            MessageBox.Show("Error al convertir el ID del Usuario a entero.");
                            return;
                        }
                    }


                    // Repite el mismo proceso para CuentaID y UsuarioID

                    // Continúa con tu lógica después de asegurarte de que todos los IDs se han obtenido correctamente.


                    // Obteniendo el monto
                    decimal Monto = 0;                    
                    if (textBoxmonto.Text == String.Empty || !decimal.TryParse(textBoxmonto.Text, out Monto))
                    {
                        MessageBox.Show("El valor ingresado para el Monto no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                //string ClienteID = string.Empty;
                //if (textBoxclienteid.SelectedItem != null && textBoxclienteid.SelectedItem is DataRowView)
                //{
                //    DataRowView selectedRow = textBoxclienteid.SelectedItem as DataRowView;
                //    if (selectedRow.Row["ClienteID"] != null)
                //    {
                //        ClienteID = selectedRow.Row["ClienteID"].ToString();
                //    }
                //    else
                //    {
                //        MessageBox.Show("El ID del Cliente seleccionado no es válido.");
                //        return;
                //    }
                //}


                if (Program.nuevo) //Si la variable nuevo llega con valor true se van a Insertar nuevos datos
                    {
                        //Se llama al método Insertar de la clase CDCuentas de la capa de negocio
                        //pasándole como parámetros los valores leídos en los controles del formulario.
                        //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
                        mensaje = CNTransaccionesInternas.Insertar(
                           UsuarioID,
                           BancoID,
                           CuentaID,
                           //   textBoxclienteid.Text,
                           textBoxclienteid.Text,
                           textBoxfecha.Value,
                           textBoxdescripcion.Text,
                           Monto,
                           textBoxtipo.Text,
                           textBoxobservacion.Text
                          
                       );


                        int ultimoIDInsertado;
                        if (int.TryParse(textBoxtransaccionid.Text, out ultimoIDInsertado))
                        {
                            if (ultimoIDInsertado > 0)
                            {
                                textBoxtransaccionid.Text = ultimoIDInsertado.ToString();
                                textBoxtransaccionid.Text = (ultimoIDInsertado + 1).ToString();
                            }
                            else
                            {

                                return;
                            }
                        }


                    }
                    else //de lo contrario se Modificarán los datos del registro correspondiente
                    {
                        //Se llama al método Actualizar de la clase CDCuentas de la capa de negocio
                        //pasándole como parámetros los valores leídos en los controles del formulario.
                        //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
                        mensaje = CNTransaccionesInternas.Actualizar(Program.TransaccionID,
                          
                           UsuarioID,
                           BancoID,
                           CuentaID,
                           //textBoxclienteid.Text,
                           textBoxclienteid.Text,
                           textBoxfecha.Value,
                           textBoxdescripcion.Text,
                           Monto,
                           textBoxtipo.Text,
                           textBoxobservacion.Text

                       );
                    }







                  MessageBox.Show(mensaje, "Mensaje de Transacciones Internas", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // MessageBox.Show($"Transacción exitosa. Detalles: {mensaje}", "Mensaje de Transacciones Internas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //    MessageBox.Show($"Error al insertar Transacciones Internas: {ex.Message}. Caja de texto: {ex.TargetSite.Name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show($"Error al insertar Transacciones Internas. Método: {System.Reflection.MethodBase.GetCurrentMethod().Name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //  MessageBox.Show($"Error al insertar Transacciones Internas: {ex.Message}. Caja de texto: {System.Reflection.MethodBase.GetCurrentMethod().Name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    Program.nuevo = false;
                    Program.modificar = false;
                    HabilitaBotones();
                    LimpiaObjetos();
                }
            }


        private void Bcancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
            textBoxcuentaidm.Visible = false;
            textBoxusuarioidm.Visible = false;
            textBoxbancoidm.Visible = false;
        }

        private void Beditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxtransaccionid.Text))
            {
                MessageBox.Show("Debe seleccionar una Transacciones Internas para modificar sus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.modificar = true;
            HabilitaBotones();
        }

        private void FMTransacciones_Internas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            BusquedaTransaccionesInternas busquedaTransaccionesInternas = new BusquedaTransaccionesInternas();
            busquedaTransaccionesInternas.ShowDialog();

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
            // Obtener el ID de la transacción de Program
            int transaccionID = Program.TransaccionID;

            // Crear una instancia de CDTransaccionesInternas
            CDTransaccionesInternas transaccionesInternas = new CDTransaccionesInternas();

            // Llamada al método no estático ObtenerTransaccionInternaPorID de la instancia de CDTransaccionesInternas para obtener los datos de la transacción interna
            DataTable dtTransaccion = transaccionesInternas.ObtenerTransaccionInternaPorID(transaccionID);

            // Verificar si se encontraron datos de la transacción interna
            if (dtTransaccion.Rows.Count > 0)
            {
                // Obtener la primera fila de los resultados de la transacción interna
                DataRow rowTransaccion = dtTransaccion.Rows[0];

                // Mostrar los datos de la transacción interna en los controles correspondientes
                textBoxtransaccionid.Text = rowTransaccion["TransaccionID"].ToString();
                textBoxclienteid.Text = rowTransaccion["ClienteID"].ToString();
                textBoxtipo.SelectedIndex = rowTransaccion.Table.Columns.Contains("TipoDeTransaccion") ? rowTransaccion.Field<int>("TipoDeTransaccion") : -1;
                textBoxbancoid.Text = rowTransaccion.Table.Columns.Contains("BancoID") ? rowTransaccion["BancoID"].ToString() : "";
                textBoxusuarioid.Text = rowTransaccion.Table.Columns.Contains("UsuarioID") ? rowTransaccion["UsuarioID"].ToString() : "";
                textBoxdescripcion.Text = rowTransaccion["Descripcion"].ToString();
                textBoxmonto.Text = rowTransaccion["Monto"].ToString();
                textBoxfecha.Text = rowTransaccion.Table.Columns.Contains("Fecha") ? rowTransaccion["Fecha"].ToString() : "";
                textBoxfecha.Value = rowTransaccion.Table.Columns.Contains("Fecha") ? DateTime.Parse(rowTransaccion["Fecha"].ToString()) : DateTime.MinValue;
                textBoxobservacion.Text = rowTransaccion["Observacion"].ToString();

                // Obtener el ID de la cuenta bancaria de la transacción interna
                int cuentaID = Convert.ToInt32(rowTransaccion["CuentaID"]);

                // Obtener el nombre de la cuenta bancaria
                string nombreCuentaBancaria = ObtenerNombreCuentaBancaria(cuentaID);
                textBoxcuentaidm.Text = nombreCuentaBancaria;
                textBoxcuentaidm.Items.Add(nombreCuentaBancaria);
                textBoxcuentaidm.SelectedIndex = textBoxcuentaidm.Items.Count - 1;
                textBoxcuentaidm.Visible = true;

                // Obtener el ID del usuario de la transacción interna
                int usuarioID = Convert.ToInt32(rowTransaccion["UsuarioID"]);

                // Obtener el nombre del usuario
                string nombreUsuario = ObtenerNombreUsuario(usuarioID);
                textBoxusuarioidm.Text = nombreUsuario;
                textBoxusuarioidm.Items.Add(nombreUsuario);
                textBoxusuarioidm.SelectedIndex = textBoxusuarioidm.Items.Count - 1;
                textBoxusuarioidm.Visible = true;

                // Obtener el ID del banco de la transacción interna
                int bancoID = Convert.ToInt32(rowTransaccion["BancoID"]);

                // Obtener el nombre del banco
                string nombreBanco = ObtenerNombreBanco(bancoID);
                textBoxbancoidm.Text = nombreBanco;
                textBoxbancoidm.Items.Add(nombreBanco);
                textBoxbancoidm.SelectedIndex = textBoxbancoidm.Items.Count - 1;
                textBoxbancoidm.Visible = true;
            }
            else
            {
                // Manejar el caso en el que no se encuentren datos de la transacción interna para el ID proporcionado
                MessageBox.Show("No se encontraron datos de la transacción interna para el ID proporcionado.");
                LimpiarControlesTransaccion();
            }
        }

        // Método para obtener el nombre de la cuenta bancaria
        private string ObtenerNombreCuentaBancaria(int cuentaID)
        {
            // Crear una instancia de CDCuentasBancarias
            CDCuentasBancarias cuentasBancarias = new CDCuentasBancarias();

            // Llamada al método estático ObtenerCuentaPorID de la instancia de CDCuentasBancarias para obtener los datos de la cuenta bancaria
            DataTable dtCuenta = cuentasBancarias.ObtenerCuentaBancariaPorID(cuentaID);

            // Verificar si se encontraron datos de la cuenta bancaria
            if (dtCuenta.Rows.Count > 0)
            {
                // Obtener la primera fila de los resultados de la cuenta bancaria
                DataRow rowCuenta = dtCuenta.Rows[0];

                // Devolver el nombre de la cuenta bancaria
                return rowCuenta["TipoCuenta"].ToString(); // Reemplaza "NombreCuenta" con el nombre real de la columna que contiene el nombre de la cuenta bancaria
            }
            else
            {
                // Manejar el caso en el que no se encuentren datos de la cuenta bancaria para el ID proporcionado
                return "Nombre de cuenta no encontrado"; // Puedes cambiar este mensaje según sea necesario
            }
        }

        // Método para obtener el nombre del usuario
        private string ObtenerNombreUsuario(int usuarioID)
        {
            // Llamada al método estático ObtenerUsuarioPorID de la clase CNUsuarios para obtener los datos del usuario
            DataTable dtUsuario = CNUsuarios.ObtenerUsuarioPorID(usuarioID);

            // Verificar si se encontraron datos del usuario
            if (dtUsuario.Rows.Count > 0)
            {
                // Obtener la primera fila de los resultados del usuario
                DataRow rowUsuario = dtUsuario.Rows[0];

                // Devolver el nombre del usuario
                return rowUsuario["NombreUsuario"].ToString(); // Reemplaza "NombreUsuario" con el nombre real de la columna que contiene el nombre del usuario
            }
            else
            {
                // Manejar el caso en el que no se encuentren datos del usuario para el ID proporcionado
                return "Nombre de usuario no encontrado"; // Puedes cambiar este mensaje según sea necesario
            }
        }

        // Método para obtener el nombre del banco
        private string ObtenerNombreBanco(int bancoID)
        {
            // Llamada al método estático ObtenerBancoPorID de la clase CNBancos para obtener los datos del banco
            DataTable dtBanco = CNBancos.ObtenerBancoPorID(bancoID);

            // Verificar si se encontraron datos del banco
            if (dtBanco.Rows.Count > 0)
            {
                // Obtener la primera fila de los resultados del banco
                DataRow rowBanco = dtBanco.Rows[0];

                // Devolver el nombre del banco
                return rowBanco["Nombre"].ToString(); // Reemplaza "Nombre" con el nombre real de la columna que contiene el nombre del banco
            }
            else
            {
                // Manejar el caso en el que no se encuentren datos del banco para el ID proporcionado
                return "Nombre de banco no encontrado"; // Puedes cambiar este mensaje según sea necesario
            }
        }

        // Método para limpiar los controles de la transacción
        private void LimpiarControlesTransaccion()
        {
            textBoxtransaccionid.Text = "";
            textBoxclienteid.Text = "";
            textBoxtipo.SelectedIndex = -1;
            textBoxbancoid.Text = "";
            textBoxusuarioid.Text = "";
            textBoxdescripcion.Text = "";
            textBoxmonto.Text = "";
            textBoxfecha.Text = "";
            textBoxfecha.Value = DateTime.MinValue;
            textBoxobservacion.Text = "";
            textBoxcuentaidm.Text = "";
            textBoxusuarioidm.Text = "";
            textBoxbancoidm.Text = "";
        }


        private void ObtenerUltimoIDInsertado()
        {
            try
            {
                // Llamada al método con el nombre de la tabla "Bancos"
                int ultimoID = ObtenerUltimoIDInsertado("TransaccionesInternas");

                // Aquí puedes usar el último ID obtenido como desees, por ejemplo, mostrarlo en un MessageBox
                MessageBox.Show("Último ID insertado para la tabla 'TransaccionesInternas': " + ultimoID);
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

        private void textBoxcuentaidm_Click(object sender, EventArgs e)
        {
            textBoxcuentaidm.Visible = false;
        }

        private void textBoxusuarioidm_Click(object sender, EventArgs e)
        {
            textBoxusuarioidm.Visible = false;
        }

        private void textBoxbancoidm_Click(object sender, EventArgs e)
        {
            textBoxbancoidm.Visible = false;
        }
    }
   
    }
