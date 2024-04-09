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
            textBoxconciliacionid.Text = (ultimoIDInsertado + 1).ToString();




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


                // Obteniendo el CatalogoID

                int ConciliacionID;
                Program.ConciliacionID = ConciliacionID = 0;

                // Obteniendo BancoID
                if (textBoxconciliacionid.Text != "")
                {
                    if (int.TryParse(textBoxconciliacionid.Text, out ConciliacionID))
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
                                                      SaldoContable, Diferencia);

                        int ultimoIDInsertado;
                        if (int.TryParse(textBoxconciliacionid.Text, out ultimoIDInsertado))
                        {
                            if (ultimoIDInsertado > 0)
                            {
                                textBoxconciliacionid.Text = ultimoIDInsertado.ToString();
                                textBoxconciliacionid.Text = (ultimoIDInsertado + 1).ToString();
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
                                                          SaldoContable, Diferencia);

                    }

                    MessageBox.Show(mensaje, "Mensaje de Conciliacion Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.nuevo = false;
                    Program.modificar = false;

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
        }



        private void Limpiar()
        {

            textBoxdiferencia.Clear();
            textBoxconciliacionid.Text = null;
            textBoxcuentaid.Text = null;
            textBoxbancoid.Text = null;
            comboBoxestado.Text = null;
            textBoxsaldobancario = null;
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




        public void CalcularSaldoContable(SqlConnection cn, string TransaccionesInternas)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CalcularSaldoContable", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransaccionesInternas", TransaccionesInternas);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // Aquí va el código para leer los datos del SqlDataReader
                        string CodigoCuenta = dr["CuentaID"].ToString();
                        string NombreCuenta = dr["Nombre"].ToString();
                        decimal Saldo = Convert.ToDecimal(dr["Saldo"]);

                        MessageBox.Show($"Codigo Cuenta: {CodigoCuenta}, Nombre Cuenta: {NombreCuenta}, Saldo: {Saldo}");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros.");
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el saldo contable: " + ex.Message);
            }
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
        }

        private void btncalcularsaldo_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                            Integrated Security=True;Pooling=true");
                string TransaccionesInternas = "DEP, TRS";
                CalcularSaldoContable(cn, TransaccionesInternas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el saldo contable: " + ex.Message);
            }
        }
    }
}
