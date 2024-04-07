using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace CapaDatos
{
    
    /// Clase para manejar la conexión y operaciones con la tabla de cuentas bancarias en la base de datos.
   
    public class CDCuentasBancarias
    {
        // Campos privados para almacenar los datos de la cuenta bancaria
        private int dCuentaID;
        private int dBancoID;
        private string dClienteID;
        private string dTipoCuenta;
        private string dNumeroCuenta;
        private decimal dSaldoInicial;
        private DateTime dFechaApertura;
        private string dMoneda;
        private decimal dDebito;
        private decimal dCredito;
        private string dEstado;
        private string dObservacion;

        // Constructor predeterminado de la clase
        public CDCuentasBancarias()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDCuentasBancarias(int CuentaID, int BancoID, string ClienteID, string TipoCuenta, string NumeroCuenta, decimal SaldoInicial, DateTime FechaApertura, string Moneda, decimal Debito, decimal Credito, string Estado, string Observacion)
        {
            dCuentaID = CuentaID;
            dBancoID = BancoID;
            dClienteID = ClienteID;
            dTipoCuenta = TipoCuenta;
            dNumeroCuenta = NumeroCuenta;
            dSaldoInicial = SaldoInicial;
            dFechaApertura = FechaApertura;
            dMoneda = Moneda;
            dDebito = Debito;
            dCredito = Credito;
            dEstado = Estado;
            dObservacion = Observacion;
        }

        // Métodos Get y Set

        // Propiedad para obtener o establecer el ID de la cuenta bancaria
        public int CuentaID
        {
            get { return dCuentaID; }
            set { dCuentaID = value; }
        }

        // Propiedad para obtener o establecer el ID del banco asociado a la cuenta bancaria
        public int BancoID
        {
            get { return dBancoID; }
            set { dBancoID = value; }
        }

        // Propiedad para obtener o establecer el ID del cliente asociado a la cuenta bancaria
        public string ClienteID
        {
            get { return dClienteID; }
            set { dClienteID = value; }
        }

        // Propiedad para obtener o establecer el tipo de cuenta bancaria
        public string TipoCuenta
        {
            get { return dTipoCuenta; }
            set { dTipoCuenta = value; }
        }

        // Propiedad para obtener o establecer el número de cuenta bancaria
        public string NumeroCuenta
        {
            get { return dNumeroCuenta; }
            set { dNumeroCuenta = value; }
        }

        // Propiedad para obtener o establecer el saldo inicial de la cuenta bancaria
        public decimal SaldoInicial
        {
            get { return dSaldoInicial; }
            set { dSaldoInicial = value; }
        }

        // Propiedad para obtener o establecer la fecha de apertura de la cuenta bancaria
        public DateTime FechaApertura
        {
            get { return dFechaApertura; }
            set { dFechaApertura = value; }
        }

        // Propiedad para obtener o establecer la moneda de la cuenta bancaria
        public string Moneda
        {
            get { return dMoneda; }
            set { dMoneda = value; }
        }

        // Propiedad para obtener o establecer el monto de débito de la cuenta bancaria
        public decimal Debito
        {
            get { return dDebito; }
            set { dDebito = value; }
        }

        // Propiedad para obtener o establecer el monto de crédito de la cuenta bancaria
        public decimal Credito
        {
            get { return dCredito; }
            set { dCredito = value; }
        }

        // Propiedad para obtener o establecer el estado de la cuenta bancaria
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        // Propiedad para obtener o establecer las observaciones de la cuenta bancaria
        public string Observacion
        {
            get { return dObservacion; }
            set { dObservacion = value; }
        }

        // Método para insertar una nueva Cuenta. Recibirá el objeto objCuenta como parámetro
        public string Insertar(CDCuentasBancarias objCuentasBancarias)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso CuentaInsertar
                SqlCommand micomando = new SqlCommand("InsertarCuentaBancaria", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objCuenta que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@CuentaID", objCuentasBancarias.CuentaID);
                micomando.Parameters.AddWithValue("@BancoID", objCuentasBancarias.BancoID);
                micomando.Parameters.AddWithValue("@ClienteID", objCuentasBancarias.ClienteID);
                micomando.Parameters.AddWithValue("@TipoCuenta", objCuentasBancarias.TipoCuenta);
                micomando.Parameters.AddWithValue("@NumeroCuenta", objCuentasBancarias.NumeroCuenta);
                micomando.Parameters.AddWithValue("@SaldoInicial", objCuentasBancarias.SaldoInicial);
                micomando.Parameters.AddWithValue("@FechaApertura", objCuentasBancarias.FechaApertura);
                micomando.Parameters.AddWithValue("@Moneda", objCuentasBancarias.Moneda);
                micomando.Parameters.AddWithValue("@Debito", objCuentasBancarias.Debito);
                micomando.Parameters.AddWithValue("@Credito", objCuentasBancarias.Credito);
                micomando.Parameters.AddWithValue("@Estado", objCuentasBancarias.Estado);
                micomando.Parameters.AddWithValue("@Observacion", objCuentasBancarias.Observacion);

                // Ejecutamos la instrucción. Si se devuelve el valor 1 significa que todo funcionó correctamente,
                // de lo contrario, se devuelve un mensaje indicando que fue incorrecto.
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Inserción de datos completada correctamente!" : "No se pudo insertar correctamente los nuevos datos!";
            }
            catch (Exception ex) // Si ocurre algún error, lo capturamos y mostramos el mensaje
            {
                mensaje = ex.Message;
            }
            finally // Luego de realizar el proceso de forma correcta o no 
            {
                // Cerramos la conexión si está abierta
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            // Devolvemos el mensaje correspondiente de acuerdo a lo que haya resultado del comando
            return mensaje;
        }


        // Método para insertar una nueva Cuenta. Recibirá el objeto objCuenta como parámetro
        public string Actualizar(CDCuentasBancarias objCuentasBancarias)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso CuentaInsertar
                SqlCommand micomando = new SqlCommand("ActualizarCuentaBancaria", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objCuenta que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@CuentaID", objCuentasBancarias.CuentaID);
                micomando.Parameters.AddWithValue("@BancoID", objCuentasBancarias.BancoID);
                micomando.Parameters.AddWithValue("@ClienteID", objCuentasBancarias.ClienteID);
                micomando.Parameters.AddWithValue("@TipoCuenta", objCuentasBancarias.TipoCuenta);
                micomando.Parameters.AddWithValue("@NumeroCuenta", objCuentasBancarias.NumeroCuenta);
                micomando.Parameters.AddWithValue("@SaldoInicial", objCuentasBancarias.SaldoInicial);
                micomando.Parameters.AddWithValue("@FechaApertura", objCuentasBancarias.FechaApertura);
                micomando.Parameters.AddWithValue("@Moneda", objCuentasBancarias.Moneda);
                micomando.Parameters.AddWithValue("@Debito", objCuentasBancarias.Debito);
                micomando.Parameters.AddWithValue("@Credito", objCuentasBancarias.Credito);
                micomando.Parameters.AddWithValue("@Estado", objCuentasBancarias.Estado);
                micomando.Parameters.AddWithValue("@Observacion", objCuentasBancarias.Observacion);

                // Ejecutamos la instrucción. Si se devuelve el valor 1 significa que todo funcionó correctamente,
                // de lo contrario, se devuelve un mensaje indicando que fue incorrecto.
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Inserción de datos completada correctamente!" : "No se pudo insertar correctamente los nuevos datos!";
            }
            catch (Exception ex) // Si ocurre algún error, lo capturamos y mostramos el mensaje
            {
                mensaje = ex.Message;
            }
            finally // Luego de realizar el proceso de forma correcta o no 
            {
                // Cerramos la conexión si está abierta
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            // Devolvemos el mensaje correspondiente de acuerdo a lo que haya resultado del comando
            return mensaje;
        }

     

        public DataTable ObtenerCuentaBancariaPorID(int? cuentaID, string tipoCuenta)
        {
            DataTable dt = new DataTable(); // Se crea DataTable que tomará los datos de la cuenta bancaria
            SqlDataReader leerDatos; // Creamos el DataReader
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion)) // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                {
                    SqlCommand sqlCmd = new SqlCommand(); // Establecer el comando
                    sqlCmd.Connection = sqlCon; // Asignar la conexión al comando
                    sqlCon.Open(); // Se abre la conexión
                    sqlCmd.CommandText = "ObtenerCuentaBancariaPorID"; // Nombre del Proc. Almacenado a usar
                    sqlCmd.CommandType = CommandType.StoredProcedure; // Se trata de un proc. almacenado
                    sqlCmd.Parameters.AddWithValue("@CuentaID", cuentaID ?? (object)DBNull.Value); // Se pasa el ID de la cuenta bancaria a buscar
                    sqlCmd.Parameters.AddWithValue("@TipoCuenta", tipoCuenta ?? (object)DBNull.Value); // Se pasa el Tipo de Cuenta a buscar
                    leerDatos = sqlCmd.ExecuteReader(); // Llenamos el SqlDataReader con los datos resultantes
                    dt.Load(leerDatos); // Se cargan los registros devueltos al DataTable
                    sqlCon.Close(); // Se cierra la conexión
                }
            }
            catch (Exception)
            {
                dt = null; // Si ocurre algún error se anula el DataTable
            }
            return dt; // Se retorna el DataTable según lo ocurrido arriba
        }

      
    }
}