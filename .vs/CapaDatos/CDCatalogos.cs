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
        public string Insertar(string Nombre, string Descripcion, string CuentasPadres, string Origen, decimal Balance, string Estado)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de inserción
                    using (SqlCommand micomando = new SqlCommand("InsertarCatalogo", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la inserción del catálogo
                        micomando.Parameters.AddWithValue("@Nombre", Nombre);
                        micomando.Parameters.AddWithValue("@Descripcion", Descripcion);
                        micomando.Parameters.AddWithValue("@CuentasPadres", CuentasPadres);
                        micomando.Parameters.AddWithValue("@Origen", Origen);
                        micomando.Parameters.AddWithValue("@Balance", Balance);
                        micomando.Parameters.AddWithValue("@Estado", Estado);

                        // Se abre la conexión a la base de datos
                        sqlCon.Open();
                        // Se ejecuta el comando y se obtiene el número de filas afectadas
                        int rowsAffected = micomando.ExecuteNonQuery();

                        // Se retorna un mensaje indicando el resultado de la operación
                        return rowsAffected == 1 ? "Inserción de datos completada correctamente!" :
                                                   "No se pudo insertar correctamente los nuevos datos!";
                    }
                }
            }
            catch (Exception ex)
            {
                // Se lanza una excepción con un mensaje descriptivo y la excepción original
                throw new Exception("Error al intentar insertar datos del catálogo.", ex);
            }
        }

        // Método para actualizar los datos de un catálogo en la base de datos
        public string Actualizar(int CatalogoID, string Nombre, string Descripcion, string CuentasPadres, string Origen, decimal Balance, string Estado)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de actualización
                    using (SqlCommand micomando = new SqlCommand("ActualizarCatalogo", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la actualización del catálogo
                        micomando.Parameters.AddWithValue("@CatalogoID", CatalogoID);
                        micomando.Parameters.AddWithValue("@Nombre", Nombre);
                        micomando.Parameters.AddWithValue("@Descripcion", Descripcion);
                        micomando.Parameters.AddWithValue("@CuentasPadres", CuentasPadres);
                        micomando.Parameters.AddWithValue("@Origen", Origen);
                        micomando.Parameters.AddWithValue("@Balance", Balance);
                        micomando.Parameters.AddWithValue("@Estado", Estado);

                        // Se abre la conexión a la base de datos
                        sqlCon.Open();
                        // Se ejecuta el comando y se obtiene el número de filas afectadas
                        int rowsAffected = micomando.ExecuteNonQuery();

                        // Se retorna un mensaje indicando el resultado de la operación
                        return rowsAffected == 1 ? "Actualización de datos completada correctamente!" :
                                                   "No se pudo actualizar correctamente los datos!";
                    }
                }
            }
            catch (Exception ex)
            {
                // Se lanza una excepción con un mensaje descriptivo y la excepción original
                throw new Exception("Error al intentar actualizar datos del catálogo.", ex);
            }
        }

        // Método utilizado para obtener un DataTable con los datos de un catálogo por su ID
        public DataTable ObtenerCatalogoPorID(int catalogoID)
        {
            try
            {
                // Se crea un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Se instancia un objeto de la clase CDCatalogos
                CDCatalogos objCatalogo = new CDCatalogos();

                // Se llena el DataTable con los datos del catálogo correspondiente al ID proporcionado
                dt = objCatalogo.ObtenerCatalogoPorID(catalogoID);

                // Se retorna el DataTable con los datos adquiridos
                return dt;
            }
            catch (Exception ex)
            {
                // Se lanza una excepción con un mensaje descriptivo y la excepción original
                throw new Exception("Error al intentar obtener datos del catálogo por ID.", ex);
            }
        }

    }
}