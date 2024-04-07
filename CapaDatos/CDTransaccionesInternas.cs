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
    // Clase para manejar la conexión y operaciones con la tabla de transacciones internas en la base de datos
    public class CDTransaccionesInternas
    {
        // Campos privados para almacenar los datos de la transacción interna
        private int dTransaccionID;
        private int dUsuarioID;
        private int dBancoID;
        private int dCuentaID;
        private string dClienteID;
        private DateTime dFecha;
        private string dDescripcion;
        private decimal dMonto;
        private string dTipo;
        private string dObservacion;

        // Constructor predeterminado de la clase
        public CDTransaccionesInternas()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDTransaccionesInternas(int TransaccionID, int UsuarioID, int BancoID, int CuentaID, string ClienteID, DateTime Fecha, string Descripcion, decimal Monto, string Tipo, string Observacion)
        {
            dTransaccionID = TransaccionID;
            dUsuarioID = UsuarioID;
            dBancoID = BancoID;
            dCuentaID = CuentaID;
            dClienteID = ClienteID;
            dFecha = Fecha;
            dDescripcion = Descripcion;
            dMonto = Monto;
            dTipo = Tipo;
            dObservacion = Observacion;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID de la transacción interna
        public int TransaccionID
        {
            get { return dTransaccionID; }
            set { dTransaccionID = value; }
        }
        // Propiedad para obtener o establecer el ID del usuario asociado a la transacción interna
        public int UsuarioID
        {
            get { return dUsuarioID; }
            set { dUsuarioID = value; }
        }
        // Propiedad para obtener o establecer el ID del banco asociado a la transacción interna
        public int BancoID
        {
            get { return dBancoID; }
            set { dBancoID = value; }
        }
        // Propiedad para obtener o establecer el ID de la cuenta asociada a la transacción interna
        public int CuentaID
        {
            get { return dCuentaID; }
            set { dCuentaID = value; }
        }
        // Propiedad para obtener o establecer el ID del cliente asociado a la transacción interna
        public string ClienteID
        {
            get { return dClienteID; }
            set { dClienteID = value; }
        }
        // Propiedad para obtener o establecer la fecha de la transacción interna
        public DateTime Fecha
        {
            get { return dFecha; }
            set { dFecha = value; }
        }
        // Propiedad para obtener o establecer la descripción de la transacción interna
        public string Descripcion
        {
            get { return dDescripcion; }
            set { dDescripcion = value; }
        }
        // Propiedad para obtener o establecer el monto de la transacción interna
        public decimal Monto
        {
            get { return dMonto; }
            set { dMonto = value; }
        }
        // Propiedad para obtener o establecer el tipo de la transacción interna
        public string Tipo
        {
            get { return dTipo; }
            set { dTipo = value; }
        }
  
        // Propiedad para obtener o establecer la observación de la transacción interna
        public string Observacion
        {
            get { return dObservacion; }
            set { dObservacion = value; }
        }
        #endregion

        // Método para insertar una nueva Transacción Interna. Recibirá el objeto objTransaccionInterna como parámetro
        public string Insertar(CDTransaccionesInternas objTransaccionesInternas)
        {
            // Creamos un nuevo objeto de tipo SqlConnection
            using (SqlConnection sqlCon = new SqlConnection())
            {
                // Asignamos a sqlCon la conexión con la base de datos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Abrimos la conexión
                sqlCon.Open();
                // Creamos un nuevo objeto SqlCommand
                SqlCommand micomando = new SqlCommand("InsertarTransaccionInterna", sqlCon);
                // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;
                // Agregamos los parámetros necesarios al objeto SqlCommand
                micomando.Parameters.AddWithValue("@TransaccionID", objTransaccionesInternas.TransaccionID);
                micomando.Parameters.AddWithValue("@UsuarioID", objTransaccionesInternas.UsuarioID);
                micomando.Parameters.AddWithValue("@BancoID", objTransaccionesInternas.BancoID);
                micomando.Parameters.AddWithValue("@CuentaID", objTransaccionesInternas.CuentaID);
                micomando.Parameters.AddWithValue("@ClienteID", objTransaccionesInternas.ClienteID);
                micomando.Parameters.AddWithValue("@Fecha", objTransaccionesInternas.Fecha);
                micomando.Parameters.AddWithValue("@Descripcion", objTransaccionesInternas.Descripcion);
                micomando.Parameters.AddWithValue("@Monto", objTransaccionesInternas.Monto);
                micomando.Parameters.AddWithValue("@Tipo", objTransaccionesInternas.Tipo);
                micomando.Parameters.AddWithValue("@Observacion", objTransaccionesInternas.Observacion);

                try
                {
                    // Ejecutamos la instrucción de inserción
                    micomando.ExecuteNonQuery();
                    return "Registro insertado con éxito.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    // Cerramos la conexión
                    sqlCon.Close();
                }
            }
        }

        public string Actualizar(CDTransaccionesInternas objTransaccionesInternas)
        {
            // Creamos un nuevo objeto de tipo SqlConnection
            using (SqlConnection sqlCon = new SqlConnection())
            {
                // Asignamos a sqlCon la conexión con la base de datos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Abrimos la conexión
                sqlCon.Open();
                // Creamos un nuevo objeto SqlCommand
                SqlCommand micomando = new SqlCommand("ActualizarTransaccionInterna", sqlCon);
                // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;
                // Agregamos los parámetros necesarios al objeto SqlCommand
                micomando.Parameters.AddWithValue("@TransaccionID", objTransaccionesInternas.TransaccionID);
                micomando.Parameters.AddWithValue("@UsuarioID", objTransaccionesInternas.UsuarioID);
                micomando.Parameters.AddWithValue("@BancoID", objTransaccionesInternas.BancoID);
                micomando.Parameters.AddWithValue("@CuentaID", objTransaccionesInternas.CuentaID);
                micomando.Parameters.AddWithValue("@ClienteID", objTransaccionesInternas.ClienteID);
                micomando.Parameters.AddWithValue("@Fecha", objTransaccionesInternas.Fecha);
                micomando.Parameters.AddWithValue("@Descripcion", objTransaccionesInternas.Descripcion);
                micomando.Parameters.AddWithValue("@Monto", objTransaccionesInternas.Monto);
                micomando.Parameters.AddWithValue("@Tipo", objTransaccionesInternas.Tipo);
                micomando.Parameters.AddWithValue("@Observacion", objTransaccionesInternas.Observacion);

                try
                {
                    // Ejecutamos la instrucción de actualización
                    micomando.ExecuteNonQuery();
                    return "Registro actualizado con éxito.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    // Cerramos la conexión
                    sqlCon.Close();
                }
            }
        }

        // Método para obtener los datos de una transacción interna por su ID
        public DataTable ObtenerTransaccionInternaPorID(int? TransaccionID, string Tipo)
        {
            DataTable dt = new DataTable(); // Se crea DataTable que tomará los datos de la transacción interna
            SqlDataReader leerDatos; // Creamos el DataReader
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion)) // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                {
                    SqlCommand sqlCmd = new SqlCommand(); // Establecer el comando
                    sqlCmd.Connection = sqlCon; // Asignar la conexión al comando
                    sqlCon.Open(); // Se abre la conexión
                    sqlCmd.CommandText = "ObtenerTransaccionInternaPorID"; // Nombre del Proc. Almacenado a usar
                    sqlCmd.CommandType = CommandType.StoredProcedure; // Se trata de un proc. almacenado
                    sqlCmd.Parameters.AddWithValue("@TransaccionID", TransaccionID ?? (object)DBNull.Value); // Se pasa el ID de la transacción interna a buscar
                    sqlCmd.Parameters.AddWithValue("@Tipo", Tipo ?? (object)DBNull.Value); // Se pasa el tipo de transacción interna a buscar                    leerDatos = sqlCmd.ExecuteReader(); // Llenamos el SqlDataReader con los datos resultantes
                    leerDatos = sqlCmd.ExecuteReader();
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