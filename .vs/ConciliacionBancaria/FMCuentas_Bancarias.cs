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
            CargarCatalogos();
        }

        private void CargarCatalogos()
        {
            try
            {
                string query = "ObtenerCatalogos";

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
                        //////textBoxcatalogoid.DisplayMember = "Nombre";
                        //////textBoxcatalogoid.ValueMember = "CatalogoID";
                        //////textBoxcatalogoid.DataSource = dt;
                    }
                } // La conexión se cerrará automáticamente al salir del bloque using
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error al cargar catálogos: " + ex.Message);
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
            textBoxfechadeapertura.Clear();
            textBoxmoneda.Clear();
            textBoxdebito.Clear();
            textBoxcredito.Clear();
            textBoxestado.Clear();
            textBoxobservacion.Clear();
        }


        private void HabilitaControles(bool valor)
        {
            textBoxcuentaid.ReadOnly = !valor;
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
                textBoxclienteid.SelectedIndex = 0;
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
        }

        private void Bguardar_Click(object sender, EventArgs e)
        {
            //Validamos los datos requeridos antes de Insertar o Actualizar
            if (textBoxclienteid.SelectedIndex == -1) //Si el combobox está en el valor por defecto (-1) mostrar un error y ubicar el cursor en dicho combobox
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
            else if (textBoxfechadeapertura.Text == String.Empty)
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
                //Si todo es correcto procede a Insertar o actualizar según corresponda
                if (Program.nuevo) //Si la variable nuevo llega con valor true se van a Insertar nuevos datos
                {
                    //Se llama al método Insertar de la clase CDCuentas de la capa de negocio
                    //pasándole como parámetros los valores leídos en los controles del formulario.
                    //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
                    mensaje = CDCuentasBancarias.Insertar(Program.CuentaID, int.Parse(textBoxclienteid.SelectedItem.ToString()), textBoxcuentaid.Text, textBoxtipodecuenta.Text,
                        int.Parse(textBoxbancoid.SelectedItem.ToString()), textBoxnumerodecuenta.Text, decimal.Parse(textBoxsaldoinicial.Text),
                        textBoxfechadeapertura.Text, textBoxmoneda.Text, decimal.Parse(textBoxdebito.Text), decimal.Parse(textBoxcredito.Text),
                        textBoxestado.Text, textBoxobservacion.Text);
                }
                else //de lo contrario se Modificarán los datos del registro correspondiente
                {
                    //Se llama al método Actualizar de la clase CDCuentas de la capa de negocio
                    //pasándole como parámetros los valores leídos en los controles del formulario.
                    //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
                    mensaje = CDCuentasBancarias.Actualizar(Program.CuentaID, int.Parse(textBoxclienteid.SelectedItem.ToString()), textBoxcuentaid.Text, textBoxtipodecuenta.Text,
                         int.Parse(textBoxbancoid.SelectedItem.ToString()), textBoxnumerodecuenta.Text, decimal.Parse(textBoxsaldoinicial.Text),
                         textBoxfechadeapertura.Text, textBoxmoneda.Text, decimal.Parse(textBoxdebito.Text), decimal.Parse(textBoxcredito.Text),
                         textBoxestado.Text, textBoxobservacion.Text);
                }
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

            // Llamada al método ObtenerCuentaPorID de la clase CDClientes
            DataTable dt = CDCuentasBancarias.ObtenerCuentaBancariaPorID(cuentaID);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                textBoxclienteid.SelectedIndex = -1;
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
                textBoxclienteid.SelectedIndex = -1;
                textBoxcuentaid.Clear();
                textBoxtipodecuenta.Clear();
                textBoxbancoid.SelectedIndex = -1;
                textBoxnumerodecuenta.Clear();
                textBoxsaldoinicial.Clear();
                textBoxfechadeapertura.Clear();
                textBoxmoneda.Clear();
                textBoxdebito.Clear();
                textBoxcredito.Clear();
                textBoxestado.Clear();
                textBoxobservacion.Clear();
            }
        }

    }
}
