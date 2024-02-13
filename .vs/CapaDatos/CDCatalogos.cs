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
    // Clase para manejar la conexión y operaciones con la tabla de catalogos en la base de datos
    public class CDCatalogos
    {

        // Campos privados para almacenar los datos del catálogo
        private int dCatalogoID;
        private string dNombre;
        private string dDescripcion;
        private string dOtrosDetalles;

        // Constructor predeterminado de la clase
        public CDCatalogos()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDCatalogos(int CatalogoID, string Nombre, string Descripcion, string OtrosDetalles)
        {
            dCatalogoID = CatalogoID;
            dNombre = Nombre;
            dDescripcion = Descripcion;
            dOtrosDetalles = OtrosDetalles;
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
        // Propiedad para obtener o establecer otros detalles del catálogo
        public string OtrosDetalles
        {
            get { return dOtrosDetalles; }
            set { dOtrosDetalles = value; }
        }
        #endregion

        // Método para insertar un nuevo catálogo en la base de datos
        public string Insertar(CDCatalogos objCatalogo)
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
                        micomando.Parameters.AddWithValue("@Nombre", objCatalogo.dNombre);
                        micomando.Parameters.AddWithValue("@Descripcion", objCatalogo.dDescripcion);
                        micomando.Parameters.AddWithValue("@OtrosDetalles", objCatalogo.dOtrosDetalles);

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
        public string Actualizar(CDCatalogos objCatalogo)
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
                        micomando.Parameters.AddWithValue("@CatalogoID", objCatalogo.dCatalogoID);
                        micomando.Parameters.AddWithValue("@Nombre", objCatalogo.dNombre);
                        micomando.Parameters.AddWithValue("@Descripcion", objCatalogo.dDescripcion);
                        micomando.Parameters.AddWithValue("@OtrosDetalles", objCatalogo.dOtrosDetalles);

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

        // Método para obtener los datos de un catálogo por su ID
        public DataTable ObtenerCatalogoPorID(int CatalogoID)
        {
            try
            {
                // Se crea un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de obtención por ID
                    using (SqlCommand micomando = new SqlCommand("ObtenerCatalogoPorID", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añade el parámetro necesario para la consulta por ID
                        micomando.Parameters.AddWithValue("@CatalogoID", CatalogoID);

                        // Se crea un adaptador de datos para ejecutar la consulta y llenar el DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(micomando);
                        adapter.Fill(dt);
                    }
                }

                // Se retorna el DataTable con los datos obtenidos
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
