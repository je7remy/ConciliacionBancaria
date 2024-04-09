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
    public class CDConciliacionBancaria
    {
        // Campos privados para almacenar los datos de la conciliación bancaria
        private int dConciliacionID;
        private int dCuentaID;
        private DateTime dFecha;
        private string dEstado;
        private decimal dSaldoContable;
        private decimal dSaldoBancario;

        // Constructor predeterminado de la clase
        public CDConciliacionBancaria()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDConciliacionBancaria(int ConciliacionID, int CuentaID, DateTime Fecha, string Estado, decimal SaldoContable, decimal SaldoBancario)
        {
            dConciliacionID = ConciliacionID;
            dCuentaID = CuentaID;
            dFecha = Fecha;
            dEstado = Estado;
            dSaldoContable = SaldoContable;
            dSaldoBancario = SaldoBancario;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID de la conciliación bancaria
        public int ConciliacionID
        {
            get { return dConciliacionID; }
            set { dConciliacionID = value; }
        }
        // Propiedad para obtener o establecer el ID de la cuenta asociada a la conciliación bancaria
        public int CuentaID
        {
            get { return dCuentaID; }
            set { dCuentaID = value; }
        }
        // Propiedad para obtener o establecer la fecha de la conciliación bancaria
        public DateTime Fecha
        {
            get { return dFecha; }
            set { dFecha = value; }
        }
        // Propiedad para obtener o establecer el Estado de la conciliación bancaria
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }
        // Propiedad para obtener o establecer el saldo contable de la conciliación bancaria
        public decimal SaldoContable
        {
            get { return dSaldoContable; }
            set { dSaldoContable = value; }
        }
        // Propiedad para obtener o establecer el saldo bancario de la conciliación bancaria
        public decimal SaldoBancario
        {
            get { return dSaldoBancario; }
            set { dSaldoBancario = value; }
        }
        // Propiedad para obtener la diferencia de la conciliación bancaria (solo lectura)
        public decimal Diferencia
        {
            get { return dSaldoContable - dSaldoBancario; }
        }
        #endregion

        // Método para insertar una nueva conciliación. Recibirá el objeto objConciliacion como parámetro
        public string Insertar(CDConciliacionBancaria objConciliacion)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso ConciliacionInsertar
                SqlCommand micomando = new SqlCommand("InsertarConciliacion", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objConciliacion que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@ConciliacionID", objConciliacion.ConciliacionID);
                micomando.Parameters.AddWithValue("@CuentaID", objConciliacion.CuentaID);
                micomando.Parameters.AddWithValue("@Fecha", objConciliacion.Fecha);
                micomando.Parameters.AddWithValue("@Estado", objConciliacion.Estado);
                micomando.Parameters.AddWithValue("@SaldoContable", objConciliacion.SaldoContable);
                micomando.Parameters.AddWithValue("@SaldoBancario", objConciliacion.SaldoBancario);
              

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

        // Método para insertar una nueva conciliación. Recibirá el objeto objConciliacion como parámetro
        public string Actualizar(CDConciliacionBancaria objConciliacion)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso ConciliacionInsertar
                SqlCommand micomando = new SqlCommand("ActualizarConciliacion", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objConciliacion que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@ConciliacionID", objConciliacion.ConciliacionID);
                micomando.Parameters.AddWithValue("@CuentaID", objConciliacion.CuentaID);
                micomando.Parameters.AddWithValue("@Fecha", objConciliacion.Fecha);
                micomando.Parameters.AddWithValue("@Estado", objConciliacion.Estado);
                micomando.Parameters.AddWithValue("@SaldoContable", objConciliacion.SaldoContable);
                micomando.Parameters.AddWithValue("@SaldoBancario", objConciliacion.SaldoBancario);
                

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



        public DataTable ObtenerConciliacionBancariaPorID(int ConciliacionID)
        {
            DataTable dt = new DataTable(); // Se crea DataTable que tomará los datos de la conciliación
            SqlDataReader leerDatos; // Creamos el DataReader
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion)) // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                {
                    SqlCommand sqlCmd = new SqlCommand(); // Establecer el comando
                    sqlCmd.Connection = sqlCon; // Asignar la conexión al comando
                    sqlCon.Open(); // Se abre la conexión
                    sqlCmd.CommandText = "ObtenerConciliacionBancariaPorID"; // Nombre del Proc. Almacenado a usar
                    sqlCmd.CommandType = CommandType.StoredProcedure; // Se trata de un proc. almacenado
                    sqlCmd.Parameters.AddWithValue("@ConciliacionID", ConciliacionID); // Se pasa el ID de la conciliación a buscar
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
