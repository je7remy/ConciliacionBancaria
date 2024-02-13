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
    // Clase para manejar la conexión y operaciones con la tabla de empresas en la base de datos
    public class CDEmpresas
    {

        // Campos privados para almacenar los datos de la empresa
        private int dEmpresaID;
        private string dNombreEmpresa;
        private string dDireccion;
        private string dInformacionContacto;
        private string dOtrosDetalles;

        // Constructor predeterminado de la clase
        public CDEmpresas()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDEmpresas(int EmpresaID, string NombreEmpresa, string Direccion, string InformacionContacto, string OtrosDetalles)
        {
            dEmpresaID = EmpresaID;
            dNombreEmpresa = NombreEmpresa;
            dDireccion = Direccion;
            dInformacionContacto = InformacionContacto;
            dOtrosDetalles = OtrosDetalles;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID de la empresa
        public int EmpresaID
        {
            get { return dEmpresaID; }
            set { dEmpresaID = value; }
        }
        // Propiedad para obtener o establecer el nombre de la empresa
        public string NombreEmpresa
        {
            get { return dNombreEmpresa; }
            set { dNombreEmpresa = value; }
        }
        // Propiedad para obtener o establecer la dirección de la empresa
        public string Direccion
        {
            get { return dDireccion; }
            set { dDireccion = value; }
        }
        // Propiedad para obtener o establecer la información de contacto de la empresa
        public string InformacionContacto
        {
            get { return dInformacionContacto; }
            set { dInformacionContacto = value; }
        }
        // Propiedad para obtener o establecer otros detalles de la empresa
        public string OtrosDetalles
        {
            get { return dOtrosDetalles; }
            set { dOtrosDetalles = value; }
        }
        #endregion

        // Método para insertar una nueva empresa en la base de datos
        public string Insertar(CDEmpresas objEmpresa)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de inserción
                    using (SqlCommand micomando = new SqlCommand("InsertarEmpresa", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la inserción de la empresa
                        micomando.Parameters.AddWithValue("@NombreEmpresa", objEmpresa.dNombreEmpresa);
                        micomando.Parameters.AddWithValue("@Direccion", objEmpresa.dDireccion);
                        micomando.Parameters.AddWithValue("@InformacionContacto", objEmpresa.dInformacionContacto);
                        micomando.Parameters.AddWithValue("@OtrosDetalles", objEmpresa.dOtrosDetalles);

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
                throw new Exception("Error al intentar insertar datos de la empresa.", ex);
            }
        }

        // Método para actualizar los datos de una empresa en la base de datos
        public string Actualizar(CDEmpresas objEmpresa)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de actualización
                    using (SqlCommand micomando = new SqlCommand("ActualizarEmpresa", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la actualización de la empresa
                        micomando.Parameters.AddWithValue("@EmpresaID", objEmpresa.dEmpresaID);
                        micomando.Parameters.AddWithValue("@NombreEmpresa", objEmpresa.dNombreEmpresa);
                        micomando.Parameters.AddWithValue("@Direccion", objEmpresa.dDireccion);
                        micomando.Parameters.AddWithValue("@InformacionContacto", objEmpresa.dInformacionContacto);
                        micomando.Parameters.AddWithValue("@OtrosDetalles", objEmpresa.dOtrosDetalles);

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
                throw new Exception("Error al intentar actualizar datos de la empresa.", ex);
            }
        }

        // Método para obtener los datos de una empresa por su ID
        public DataTable ObtenerEmpresaPorID(int EmpresaID)
        {
            try
            {
                // Se crea un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de obtención por ID
                    using (SqlCommand micomando = new SqlCommand("ObtenerEmpresaPorID", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añade el parámetro necesario para la consulta por ID
                        micomando.Parameters.AddWithValue("@EmpresaID", EmpresaID);

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
                throw new Exception("Error al intentar obtener datos de la empresa por ID.", ex);
            }
        }

    }
}
