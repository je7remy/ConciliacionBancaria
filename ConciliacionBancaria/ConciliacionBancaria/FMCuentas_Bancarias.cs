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
    public partial class FMCuentas_Bancarias : Form
    {

        // Variables globales
        public string mensaje = "";


        public FMCuentas_Bancarias()
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
            CargarBancos();
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
                        textBoxbancoid.ValueMember = "BancooID";
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


        private void Bsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LimpiaObjetos()
        {
            //textBoxbanco.Clear();
            textBoxclienteid.SelectedIndex = -1;
            textBoxcuentaid.Clear();
            textBoxtipodecuenta.Clear();
            textBoxbancoid.SelectedIndex = -1;
            textBoxnumerodecuenta.Clear();
            textBoxsaldoinicial.Clear();
            textBoxfechadeapertura.CustomFormat = "dd/MM/yyyy";
            textBoxfechadeapertura.Format = DateTimePickerFormat.Custom;

            if (textBoxfechadeapertura.Value == DateTime.MinValue)
            {
                textBoxfechadeapertura.Text = "01/01/1750";
            }
            textBoxmoneda.Clear();
            textBoxdebito.Clear();
            textBoxcredito.Clear();
            textBoxestado.SelectedIndex = -1;
            textBoxobservacion.Clear();
        }


        private void HabilitaControles(bool valor)
        {
            textBoxcuentaid.ReadOnly = !valor;
            textBoxclienteid.Enabled = valor;
            textBoxcredito.Enabled = valor;
            textBoxdebito.Enabled = valor;
            textBoxestado.Enabled = valor;
            textBoxfechadeapertura.Enabled = valor;
            textBoxmoneda.Enabled = valor;
            textBoxnumerodecuenta.Enabled = valor;
            textBoxobservacion.Enabled = valor;
            textBoxsaldoinicial.Enabled = valor;
            textBoxtipodecuenta.Enabled = valor;
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

        private void FMCuentas_Bancarias_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Mantenimiento Cuentas Bancarias?", "Cerrar Cuentas Bancarias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
            textBoxtipodecuenta.Focus();


            //// Obtener el último ID insertado y asignarlo al textBoxbanco
            int ultimoIDInsertado = ObtenerUltimoIDInsertado("CuentasBancarias");
            textBoxcuentaid.Text = (ultimoIDInsertado +1).ToString();
        }

        private void Bguardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validamos los datos requeridos antes de Insertar o Actualizar
                if (textBoxclienteid.Text == String.Empty) //Si el combobox está en el valor por defecto (-1) mostrar un error y ubicar el cursor en dicho combobox
                {
                    MessageBox.Show("Debe seleccionar el ID del Cliente!");
                    textBoxclienteid.Focus();
                }
                else if (textBoxcuentaid.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar el número de Cuenta!");
                    textBoxcuentaid.Focus();
                }
                else if (textBoxtipodecuenta.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar el tipo de Cuenta!");
                    textBoxtipodecuenta.Focus();
                }
                else if (textBoxbancoid.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el ID del Banco!");
                    textBoxbancoid.Focus();
                }
                else if (textBoxnumerodecuenta.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar el número de Cuenta!");
                    textBoxnumerodecuenta.Focus();
                }
                else if (textBoxsaldoinicial.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar el saldo inicial!");
                    textBoxsaldoinicial.Focus();
                }
                else if (textBoxfechadeapertura.Value == null)
                {
                    MessageBox.Show("Debe indicar la fecha de apertura!");
                    textBoxfechadeapertura.Focus();
                }
                else if (textBoxmoneda.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar la moneda!");
                    textBoxmoneda.Focus();
                }
                else if (textBoxdebito.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar los débitos!");
                    textBoxdebito.Focus();
                }
                else if (textBoxcredito.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar los créditos!");
                    textBoxcredito.Focus();
                }
                else if (textBoxestado.Text == String.Empty)
                {
                    MessageBox.Show("Debe indicar el estado!");
                    textBoxestado.Focus();
                }
                else
                {
                    string mensaje = "";


                    // Obteniendo el BancoID
                    int BancoID;

                    if (textBoxbancoid.SelectedItem != null && textBoxbancoid.SelectedItem is DataRowView)
                    {
                        DataRowView selectedRow = textBoxbancoid.SelectedItem as DataRowView;

                        // Intenta convertir el valor de la columna "Id_Catalogo" a un entero
                        if (selectedRow.Row["BancoID"] != null && int.TryParse(selectedRow.Row["BancoID"].ToString(), out BancoID))
                        {
                            // La conversión fue exitosa, ahora puedes usar el valor del CatalogoID
                            //  MessageBox.Show("Los datos del banco han sido guardados correctamente.", "Éxito al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            // La conversión falló, el valor de "Id_Catalogo" no es un número entero válido
                            MessageBox.Show("El valor del ID del Banco no es un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int SaldoInicial, Debito, Credito;


                        if (!int.TryParse(textBoxsaldoinicial.Text, out SaldoInicial))
                        {
                            MessageBox.Show("El valor ingresado para el Saldo Inicial no es válido.");
                            return;
                        }
                        if (!int.TryParse(textBoxdebito.Text, out Debito))
                        {
                            MessageBox.Show("El valor ingresado para el Débito no es válido.");
                            return;
                        }
                        if (!int.TryParse(textBoxcredito.Text, out Credito))
                        {
                            MessageBox.Show("El valor ingresado para el Crédito no es válido.");
                            return;
                        }


                        //Si todo es correcto procede a Insertar o actualizar según corresponda
                        if (Program.nuevo) //Si la variable nuevo llega con valor true se van a Insertar nuevos datos
                        {
                            //Se llama al método Insertar de la clase CDCuentas de la capa de negocio
                            //pasándole como parámetros los valores leídos en los controles del formulario.
                            //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
                            mensaje = CNCuentasBancarias.Insertar(

                               BancoID,
                               textBoxclienteid.Text,
                               textBoxtipodecuenta.Text,
                               textBoxnumerodecuenta.Text,
                               SaldoInicial,
                               textBoxfechadeapertura.Value,
                               textBoxmoneda.Text,
                               Debito,
                               Credito,
                               textBoxestado.Text,
                               textBoxobservacion.Text

                           );


                            int ultimoIDInsertado;
                            if (int.TryParse(textBoxcuentaid.Text, out ultimoIDInsertado))
                            {
                                if (ultimoIDInsertado > 0)
                                {
                                    textBoxcuentaid.Text = ultimoIDInsertado.ToString();
                                    textBoxcuentaid.Text = (ultimoIDInsertado + 1).ToString();
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
                            mensaje = CNCuentasBancarias.Actualizar(Program.CuentaID,

                               BancoID,
                               textBoxclienteid.Text,
                               textBoxtipodecuenta.Text,
                               textBoxnumerodecuenta.Text,
                               SaldoInicial,
                               textBoxfechadeapertura.Value,
                               textBoxmoneda.Text,
                               Debito,
                               Credito,
                               textBoxestado.Text,
                               textBoxobservacion.Text

                           );
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
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos

        }

        private void Beditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxcuentaid.Text))
            {
                MessageBox.Show("Debe seleccionar una cuenta bancaria para modificar sus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.modificar = true;
            HabilitaBotones();
        }

        private void FMCuentas_Bancarias_KeyDown(object sender, KeyEventArgs e)
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
            int cuentaID = Program.CuentaID; // Obtener el ID de la cuenta de Program

            // Crear una instancia de CDCuentasBancarias
            CDCuentasBancarias cuentasBancarias = new CDCuentasBancarias();

            // Llamada al método no estático ObtenerCuentaPorID de la instancia de CDCuentasBancarias
            DataTable dt = cuentasBancarias.ObtenerCuentaBancariaPorID(cuentaID);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                textBoxclienteid.Text = row["ClienteID"].ToString();
                textBoxcuentaid.Text = row["CuentaID"].ToString();
                textBoxtipodecuenta.Text = row["TipoDeCuenta"].ToString();
                textBoxbancoid.SelectedIndex = -1;
                textBoxnumerodecuenta.Text = row["NumeroDeCuenta"].ToString();
                textBoxsaldoinicial.Text = row["SaldoInicial"].ToString();
                textBoxfechadeapertura.Text = row["FechaDeApertura"].ToString();
                textBoxmoneda.Text = row["Moneda"].ToString();
                textBoxdebito.Text = row["Debito"].ToString();
                textBoxcredito.Text = row["Credito"].ToString();
                textBoxestado.Text = row["Estado"].ToString();
                textBoxobservacion.Text = row["Observacion"].ToString();
            }
            else
            {
                textBoxclienteid.Text = "";
                textBoxcuentaid.Text = "";
                textBoxtipodecuenta.Text = "";
                textBoxbancoid.SelectedIndex = -1;
                textBoxnumerodecuenta.Text = "";
                textBoxsaldoinicial.Text = "";
                textBoxfechadeapertura.Text = "";
                textBoxmoneda.Text = "";
                textBoxdebito.Text = "";
                textBoxcredito.Text = "";
                textBoxestado.Text = "";
                textBoxobservacion.Text = "";
            }
        }



        private void ObtenerUltimoIDInsertado()
        {
            try
            {
                // Llamada al método con el nombre de la tabla "Bancos"
                int ultimoID = ObtenerUltimoIDInsertado("CuentasBancarias");

                // Aquí puedes usar el último ID obtenido como desees, por ejemplo, mostrarlo en un MessageBox
                MessageBox.Show("Último ID insertado para la tabla 'CuentasBancarias': " + ultimoID);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
