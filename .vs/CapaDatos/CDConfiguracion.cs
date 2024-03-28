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
    // Clase para manejar la conexión y operaciones con la tabla de configuracion en la base de datos
    public class CDConfiguracion
    {

        // Campos privados para almacenar los datos de la configuración
        private int dConfiguracionID;
        private string dNombreConfiguracion;
        private string dValorConfiguracion;
        private string dDescripcion;
        private string dTipoConfiguracion;
        private string dTablaRelacionada;
        private string dOtrosDetalles;

        // Constructor predeterminado de la clase
        public CDConfiguracion()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDConfiguracion(int ConfiguracionID, string NombreConfiguracion, string ValorConfiguracion, string Descripcion, string TipoConfiguracion, string TablaRelacionada, string OtrosDetalles)
        {
            dConfiguracionID = ConfiguracionID;
            dNombreConfiguracion = NombreConfiguracion;
            dValorConfiguracion = ValorConfiguracion;
            dDescripcion = Descripcion;
            dTipoConfiguracion = TipoConfiguracion;
            dTablaRelacionada = TablaRelacionada;
            dOtrosDetalles = OtrosDetalles;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID de la configuración
        public int ConfiguracionID
        {
            get { return dConfiguracionID; }
            set { dConfiguracionID = value; }
        }
        // Propiedad para obtener o establecer el nombre de la configuración
        public string NombreConfiguracion
        {
            get { return dNombreConfiguracion; }
            set { dNombreConfiguracion = value; }
        }
        // Propiedad para obtener o establecer el valor de la configuración
        public string ValorConfiguracion
        {
            get { return dValorConfiguracion; }
            set { dValorConfiguracion = value; }
        }
        // Propiedad para obtener o establecer la descripción de la configuración
        public string Descripcion
        {
            get { return dDescripcion; }
            set { dDescripcion = value; }
        }
        // Propiedad para obtener o establecer el tipo de configuración
        public string TipoConfiguracion
        {
            get { return dTipoConfiguracion; }
            set { dTipoConfiguracion = value; }
        }
        // Propiedad para obtener o establecer la tabla relacionada de la configuración
        public string TablaRelacionada
        {
            get { return dTablaRelacionada; }
            set { dTablaRelacionada = value; }
        }
        // Propiedad para obtener o establecer otros detalles de la configuración
        public string OtrosDetalles
        {
            get { return dOtrosDetalles; }
            set { dOtrosDetalles = value; }
        }
        #endregion

        // Método para insertar una nueva configuración en la base de datos
        public string Insertar(string NombreConfiguracion, string ValorConfiguracion, string Descripcion, string TipoConfiguracion, string TablaRelacionada, string OtrosDetalles)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de inserción
                    using (SqlCommand micomando = new SqlCommand("InsertarConfiguracion", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la inserción de la configuración
                        micomando.Parameters.AddWithValue("@NombreConfiguracion", NombreConfiguracion);
                        micomando.Parameters.AddWithValue("@ValorConfiguracion", ValorConfiguracion);
                        micomando.Parameters.AddWithValue("@Descripcion", Descripcion);
                        micomando.Parameters.AddWithValue("@TipoConfiguracion", TipoConfiguracion);
                        micomando.Parameters.AddWithValue("@TablaRelacionada", TablaRelacionada);
                        micomando.Parameters.AddWithValue("@OtrosDetalles", OtrosDetalles);

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
                throw new Exception("Error al intentar insertar datos de la configuración.", ex);
            }
        }

        // Método para actualizar los datos de una configuración en la base de datos
        public string Actualizar(int ConfiguracionID, string NombreConfiguracion, string ValorConfiguracion, string Descripcion, string TipoConfiguracion, string TablaRelacionada, string OtrosDetalles)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de actualización
                    using (SqlCommand micomando = new SqlCommand("ActualizarConfiguracion", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la actualización de la configuración
                        micomando.Parameters.AddWithValue("@ConfiguracionID", ConfiguracionID);
                        micomando.Parameters.AddWithValue("@NombreConfiguracion", NombreConfiguracion);
                        micomando.Parameters.AddWithValue("@ValorConfiguracion", ValorConfiguracion);
                        micomando.Parameters.AddWithValue("@Descripcion", Descripcion);
                        micomando.Parameters.AddWithValue("@TipoConfiguracion", TipoConfiguracion);
                        micomando.Parameters.AddWithValue("@TablaRelacionada", TablaRelacionada);
                        micomando.Parameters.AddWithValue("@OtrosDetalles", OtrosDetalles);

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
                throw new Exception("Error al intentar actualizar datos de la configuración.", ex);
            }
        }

        // Método para obtener los datos de una configuración por su ID
        public DataTable ObtenerConfiguracionPorID(int ConfiguracionID)
        {
            try
            {
                // Se crea un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de obtención por ID
                    using (SqlCommand micomando = new SqlCommand("ObtenerConfiguracionPorID", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añade el parámetro necesario para la consulta por ID
                        micomando.Parameters.AddWithValue("@ConfiguracionID", ConfiguracionID);

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
                throw new Exception("Error al intentar obtener datos de la configuración por ID.", ex);
            }
        }

    }
}
