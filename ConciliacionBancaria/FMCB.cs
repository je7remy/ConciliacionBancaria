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
           
            int ultimoIDInsertado = ObtenerUltimoIDInsertado("ConciliacionBancaria");
            textBoxconciliacionid.Text = (ultimoIDInsertado +1).ToString();

            button2.Focus();
            Program.nuevo = true;

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

            try
            {
                if (string.IsNullOrEmpty(textBoxconciliacionid.Text))
                {
                    MessageBox.Show("Debe indicar el id de la conciliacion!");
                    textBoxconciliacionid.Focus();
                    return; // Agregamos un return aquí para salir del método si un campo está vacío
                }
                else if (string.IsNullOrEmpty(textBoxcuentaid.Text))
                {
                    MessageBox.Show("Debe indicar la cuenta id!");
                    textBoxcuentaid.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxfechadeconcilicacion.Text))
                {
                    MessageBox.Show("Debe indicar la fecha de conciliacion!");
                    textBoxfechadeconcilicacion.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxsaldobancario.Text))
                {
                    MessageBox.Show("Debe indicar el saldo bancario!");
                    textBoxsaldobancario.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxbancoid.Text))
                {
                    MessageBox.Show("Debe indicar el banco!");
                    textBoxbancoid.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxdiferencia.Text))
                {
                    MessageBox.Show("Debe indicar la diferencia!");
                    textBoxdiferencia.Focus();
                    return;
                }


                string mensaje = "";


                //// Obteniendo el CatalogoID

                //int ConciliacionID;
                //Program.ConciliacionID = ConciliacionID = 0;

                //// Obteniendo BancoID
                //if (textBoxconciliacionid.Text != "")
                //{
                //    if (int.TryParse(textBoxconciliacionid.Text, out ConciliacionID))
                //    {
                //        // La conversión fue exitosa
                //    }
                //    else
                //    {
                //        // Manejar el error de conversión
                //        MessageBox.Show("Error al convertir el ID del Saldo Contable.");
                //        return;
                //    }
                //}



                decimal SaldoContable = 0;

                // Obteniendo BancoID
                if (textBoxsaldocontable.Text != "")
                {
                    if (decimal.TryParse(textBoxsaldocontable.Text, out SaldoContable))
                    {
                        // La conversión fue exitosa
                    }
                    else
                    {
                        // Manejar el error de conversión
                        MessageBox.Show("Error al convertir el ID del Saldo Contable.");
                        return;
                    }
                }



                decimal SaldoBancario = 0;

                // Obteniendo SaldoBancario
                if (textBoxsaldobancario.Text != "")
                {
                    if (decimal.TryParse(textBoxsaldobancario.Text, out SaldoBancario))
                    {
                        // La conversión fue exitosa
                    }
                    else
                    {
                        // Manejar el error de conversión
                        MessageBox.Show("Error al convertir el ID del Saldo Bancario.");
                        return;
                    }
                }




                decimal Diferencia = 0;

                // Obteniendo Diferencia
                if (textBoxdiferencia.Text != "")
                {
                    if (decimal.TryParse(textBoxdiferencia.Text, out Diferencia))
                    {
                        // La conversión fue exitosa
                    }
                    else
                    {
                        // Manejar el error de conversión
                        MessageBox.Show("Error al convertir el ID de la Diferencia.");
                        return;
                    }


                    int CuentaID = 0;

                    // Obteniendo SaldoBancario
                    if (textBoxcuentaid.Text != "")
                    {
                        if (int.TryParse(textBoxcuentaid.Text, out CuentaID))
                        {
                            // La conversión fue exitosa
                        }
                        else
                        {
                            // Manejar el error de conversión
                            MessageBox.Show("Error al convertir el ID de la cuenta.");
                            return;
                        }
                    }





                    if (Program.nuevo)
                    {
                        mensaje = CNConciliacionBancaria.Insertar(CuentaID, textBoxfechadeconcilicacion.Value,
                                                      comboBoxestado.Text, SaldoBancario,
                                                      SaldoContable);

                        int ultimoIDInsertado;
                        if (int.TryParse(textBoxconciliacionid.Text, out ultimoIDInsertado))
                        {
                            if (ultimoIDInsertado > 0)
                            {
                                textBoxconciliacionid.Text = ultimoIDInsertado.ToString();
                                textBoxconciliacionid.Text = (ultimoIDInsertado +1).ToString();
                            }
                            else
                            {

                                return;
                            }
                        }

                    }
                    else
                    {

                        mensaje = CNConciliacionBancaria.Actualizar(Program.ConciliacionID, CuentaID, textBoxfechadeconcilicacion.Value,
                                                          comboBoxestado.Text, SaldoBancario,
                                                          SaldoContable);

                    }

                    MessageBox.Show(mensaje, "Mensaje de Conciliacion Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.nuevo = false;
                 // Program.modificar = false;

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
            Limpiar();
            btncalcularsaldo.Enabled = false;
        }



        private void Limpiar()
        {

            textBoxdiferencia.Clear();
          //  textBoxconciliacionid.Clear();
            textBoxcuentaid.SelectedIndex = -1;
            textBoxbancoid.SelectedIndex = -1;
            comboBoxestado.SelectedIndex = -1;
            textBoxsaldobancario.SelectedIndex = -1;
            textBoxsaldocontable.Clear();
            textBoxfechadeconcilicacion.Value = System.DateTime.Now.Date;
          
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

        private void textBoxcuentaid_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }





        public void RecuperaDatos()
        {
            // Obtener el ID de la cuenta de Program
            int cuentaID = Program.CuentaID;

            // Crear una instancia de CDCuentasBancarias
            CDCuentasBancarias cuentasBancarias = new CDCuentasBancarias();

            // Llamada al método no estático ObtenerCuentaPorID de la instancia de CDCuentasBancarias para obtener los datos de la cuenta bancaria
            DataTable dtCuenta = cuentasBancarias.ObtenerCuentaBancariaPorID(cuentaID, null);

            // Verificar si se encontraron datos de la cuenta bancaria
            if (dtCuenta.Rows.Count > 0)
            {
                // Obtener la primera fila de los resultados de la cuenta bancaria
                DataRow rowCuenta = dtCuenta.Rows[0];

                string nombreCuenta = rowCuenta["CuentaID"].ToString();


                // Agregar el nombre del catálogo al ComboBox textBoxcatalogoid y seleccionarlo
                textBoxcuentaid.Items.Add(nombreCuenta);
                textBoxcuentaid.SelectedIndex = textBoxcuentaid.Items.Count - 1;


                string SaldoBancario = rowCuenta["SaldoInicial"].ToString();


                // Agregar el nombre del catálogo al ComboBox textBoxcatalogoid y seleccionarlo
                textBoxsaldobancario.Items.Add(SaldoBancario);
                textBoxsaldobancario.SelectedIndex = textBoxcuentaid.Items.Count - 1;

                //  textBoxcuentaid.Text = rowCuenta["CuentaID"].ToString();




                // Obtener el ID del banco de la cuenta bancaria
                int bancoID = Convert.ToInt32(rowCuenta["BancoID"]);

                // Llamada al método estático ObtenerBancoPorID de la clase CNBancos para obtener los datos del banco
                DataTable dtBanco = CNBancos.ObtenerBancoPorID(bancoID, null);

                // Verificar si se encontraron datos del banco
                if (dtBanco.Rows.Count > 0)
                {
                    // Obtener la primera fila de los resultados del banco
                    DataRow rowBanco = dtBanco.Rows[0];

                    // Mostrar los datos del banco en los controles correspondientes
                    string nombreBanco = rowBanco["Nombre"].ToString();


                    // Agregar el nombre del catálogo al ComboBox textBoxcatalogoid y seleccionarlo
                    textBoxbancoid.Items.Add(nombreBanco);
                    textBoxbancoid.SelectedIndex = textBoxbancoid.Items.Count - 1;
                 
                }
                else
                {
                    // Manejar el caso en el que no se encuentren datos del banco para el ID proporcionado
                    MessageBox.Show("No se encontraron datos del banco para el ID proporcionado.");
                    Limpiar(); // Limpia los controles del banco
                }
            }
            else
            {
                // Manejar el caso en el que no se encuentren datos de la cuenta bancaria para el ID proporcionado
                MessageBox.Show("No se encontraron datos de la cuenta bancaria para el ID proporcionado.");
                Limpiar(); // Limpia los controles de la cuenta bancaria
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusquedaCuentasBancarias busqueda_Bancos = new BusquedaCuentasBancarias();
            busqueda_Bancos.ShowDialog();
            RecuperaDatos();
            btncalcularsaldo.Enabled = true;
          
        }

        private void btncalcularsaldo_Click(object sender, EventArgs e)
        {

            try
            {
                int CuentaID = 0;

                // Obteniendo SaldoBancario
                if (textBoxcuentaid.Text != "")
                {
                    if (int.TryParse(textBoxcuentaid.Text, out CuentaID))
                    {
                        // La conversión fue exitosa
                    }
                    else
                    {
                        // Manejar el error de conversión
                        MessageBox.Show("Error al convertir el ID de la cuenta.");
                        return;
                    }
                }

                string selectedItemString = textBoxcuentaid.SelectedItem.ToString();

                if (int.TryParse(selectedItemString, out int selectedItem))
                {
                 //   string result = ObtenerSaldoContable(selectedItem);
                    decimal result = ObtenerSaldoContable(selectedItem);
                    string saldoContableString = result.ToString();

                    textBoxsaldocontable.Text = result.ToString(); ;
                }
                else
                {
                    MessageBox.Show("Error al convertir el ID de la cuenta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el saldo contable: " + ex.Message);
            }

            
        }

        decimal ObtenerSaldoContable(int selectedItem)
        {
            decimal saldoContable = 0;

            try
            {
                // Establece la conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;
                AttachDbFilename = C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                            Integrated Security = True; Pooling = true"))
                {
                    // Crea el comando SQL para llamar al procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("CalcularSaldoContable", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Establece el parámetro del procedimiento almacenado
                        command.Parameters.AddWithValue("@CuentaID", selectedItem);

                        // Abre la conexión y ejecuta el comando
                        connection.Open();

                        // Ejecuta el comando y obtén el resultado (saldo contable)
                        object result = command.ExecuteScalar();

                        // Verifica si el resultado es nulo y, si no lo es, conviértelo a decimal
                        if (result != DBNull.Value)
                        {
                            saldoContable = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error al obtener el saldo contable: " + ex.Message);
            }

            return saldoContable;
       
        }

        private void textBoxdiferencia_TextChanged(object sender, EventArgs e)
        {
         

        }

        private void CalcularDiferencia(object sender, EventArgs e)
        {

            // Verificar si ambos textBox tienen valores
            if (!string.IsNullOrEmpty(textBoxsaldocontable.Text) && !string.IsNullOrEmpty(textBoxsaldobancario.Text))
            {
                // Variables para almacenar los saldos convertidos a decimal
                decimal saldoContable;
                decimal saldoBancario;

                // Verificar si los valores ingresados son números decimales válidos
                if (decimal.TryParse(textBoxsaldocontable.Text, out saldoContable) && decimal.TryParse(textBoxsaldobancario.Text, out saldoBancario))
                {
                    // Calcular la diferencia restando el saldo bancario del saldo contable
                    decimal diferencia = saldoContable - saldoBancario;

                    // Mostrar el resultado en el textBox de diferencia
                    textBoxdiferencia.Text = diferencia.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor, asegúrese de ingresar números válidos en ambos campos.");
                }
            }
            else
            {
                MessageBox.Show("Ambos campos deben estar llenos para realizar el cálculo.");
            }


        }

        private void textBoxsaldocontable_TextChanged(object sender, EventArgs e)
        {
            // Verificar si ambos textBox tienen valores
            if (!string.IsNullOrEmpty(textBoxsaldocontable.Text) && !string.IsNullOrEmpty(textBoxsaldobancario.Text))
            {
                // Variables para almacenar los saldos convertidos a decimal
                decimal saldoContable;
                decimal saldoBancario;

                // Verificar si los valores ingresados son números decimales válidos
                if (decimal.TryParse(textBoxsaldocontable.Text, out saldoContable) && decimal.TryParse(textBoxsaldobancario.Text, out saldoBancario))
                {
                    // Calcular la diferencia restando el saldo bancario del saldo contable
                    decimal diferencia = saldoContable - saldoBancario;

                    // Mostrar el resultado en el textBox de diferencia
                    textBoxdiferencia.Text = diferencia.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor, asegúrese de ingresar números válidos en ambos campos.");
                }
            }
            else
            {
                MessageBox.Show("Ambos campos deben estar llenos para realizar el cálculo.");
            }
        }
    
    }
}
