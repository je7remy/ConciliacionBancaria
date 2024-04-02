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
    // Clase para manejar la conexión y operaciones con la tabla de catálogos en la base de datos
    public class CDCatalogos
    {
        // Campos privados para almacenar los datos del catálogo
        private int dCatalogoID;
        private string dNombre;
        private string dDescripcion;
        private string dCuentasPadres;
        private string dOrigen;
        private decimal dBalance;
        private string dEstado;

        // Constructor predeterminado de la clase
        public CDCatalogos()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDCatalogos(int CatalogoID, string Nombre, string Descripcion, string CuentasPadres, string Origen, decimal Balance, string Estado)
        {
            dCatalogoID = CatalogoID;
            dNombre = Nombre;
            dDescripcion = Descripcion;
            dCuentasPadres = CuentasPadres;
            dOrigen = Origen;
            dBalance = Balance;
            dEstado = Estado;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID del catálogo
        public int CatalogoID
        {
            get { return dCatalogoID; }
            set { dCatalogoID = value; }
        }
        // Propiedad para obtener o establecer el nombre del catálogo
        public string Nombre
        {
            get { return dNombre; }
            set { dNombre = value; }
        }
        // Propiedad para obtener o establecer la descripción del catálogo
        public string Descripcion
        {
            get { return dDescripcion; }
            set { dDescripcion = value; }
        }
        // Propiedad para obtener o establecer las cuentas padres del catálogo
        public string CuentasPadres
        {
            get { return dCuentasPadres; }
            set { dCuentasPadres = value; }
        }
        // Propiedad para obtener o establecer el origen del catálogo
        public string Origen
        {
            get { return dOrigen; }
            set { dOrigen = value; }
        }
        // Propiedad para obtener o establecer el balance del catálogo
        public decimal Balance
        {
            get { return dBalance; }
            set { dBalance = value; }
        }
        // Propiedad para obtener o establecer el estado del catálogo
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }
        #endregion

        // Método para insertar un nuevo catálogo en la base de datos
        // Método para insertar un nuevo catálogo. Recibirá el objeto objCatalogo como parámetro
        public string Insertar(CDCatalogos objCatalogo)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso CatalogoInsertar
                SqlCommand micomando = new SqlCommand("InsertarCatalogo", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objCatalogo que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@CatalogoID", objCatalogo.CatalogoID);
                micomando.Parameters.AddWithValue("@Nombre", objCatalogo.Nombre);
                micomando.Parameters.AddWithValue("@Descripcion", objCatalogo.Descripcion);
                micomando.Parameters.AddWithValue("@Cuentas_padres", objCatalogo.CuentasPadres);
                micomando.Parameters.AddWithValue("@Origen", objCatalogo.Origen);
                micomando.Parameters.AddWithValue("@Balance", objCatalogo.Balance);
                micomando.Parameters.AddWithValue("@Estado", objCatalogo.Estado);

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


        // Método para actualizar los datos de un catálogo en la base de datos
        // Método para insertar un nuevo catálogo. Recibirá el objeto objCatalogo como parámetro
        public string Actualizar(CDCatalogos objCatalogo)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso CatalogoInsertar
                SqlCommand micomando = new SqlCommand("ActualizarCatalogo", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objCatalogo que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@CatalogoID", objCatalogo.CatalogoID);
                micomando.Parameters.AddWithValue("@Nombre", objCatalogo.Nombre);
                micomando.Parameters.AddWithValue("@Descripcion", objCatalogo.Descripcion);
                micomando.Parameters.AddWithValue("@Cuentas_padres", objCatalogo.CuentasPadres);
                micomando.Parameters.AddWithValue("@Origen", objCatalogo.Origen);
                micomando.Parameters.AddWithValue("@Balance", objCatalogo.Balance);
                micomando.Parameters.AddWithValue("@Estado", objCatalogo.Estado);

                // Ejecutamos la instrucción. Si se devuelve el valor 1 significa que todo funcionó correctamente,
                // de lo contrario, se devuelve un mensaje indicando que fue incorrecto.
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Actualizacion de datos completada correctamente!" : "No se pudo insertar correctamente los nuevos datos!";
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

        // Método para obtener los datos de un catálogo por su ID
        // Método para obtener los datos de un catálogo por su ID
        public DataTable ObtenerCatalogoPorID(int catalogoID)
        {
            DataTable dt = new DataTable(); // Se crea DataTable que tomará los datos del Catálogo
            SqlDataReader leerDatos; // Creamos el DataReader
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion)) // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                {
                    SqlCommand sqlCmd = new SqlCommand(); // Establecer el comando
                    sqlCmd.Connection = sqlCon; // Asignar la conexión al comando
                    sqlCon.Open(); // Se abre la conexión
                    sqlCmd.CommandText = "ObtenerCatalogoPorID"; // Nombre del Proc. Almacenado a usar
                    sqlCmd.CommandType = CommandType.StoredProcedure; // Se trata de un proc. almacenado
                    sqlCmd.Parameters.AddWithValue("@CatalogoID", catalogoID); // Se pasa el ID del catálogo a buscar
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



        // Método para obtener los datos de un catálogo por su ID
        public DataTable ObtenerCatalogos(int catalogoID)
        {
            DataTable dt = new DataTable(); // Se crea DataTable que tomará los datos del Catálogo
            SqlDataReader leerDatos; // Creamos el DataReader
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion)) // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                {
                    SqlCommand sqlCmd = new SqlCommand(); // Establecer el comando
                    sqlCmd.Connection = sqlCon; // Asignar la conexión al comando
                    sqlCon.Open(); // Se abre la conexión
                    sqlCmd.CommandText = "ObtenerCatalogos"; // Nombre del Proc. Almacenado a usar
                    sqlCmd.CommandType = CommandType.StoredProcedure; // Se trata de un proc. almacenado
                    sqlCmd.Parameters.AddWithValue("@CatalogoID", catalogoID); // Se pasa el ID del catálogo a buscar
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