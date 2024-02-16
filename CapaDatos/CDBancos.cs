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
    // Clase para manejar la conexión y operaciones con la tabla de bancos en la base de datos
    public class CDBancos
    {
        // Campos privados para almacenar los datos del banco
        private int dBancosID;
        private string dNombre, dDireccion;

        // Constructor predeterminado de la clase
        public CDBancos()
        {

        }

        public string Insertar(string nombre, string direccion)
        {
            throw new NotImplementedException();
        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDBancos(int BancosID, string Nombre, string Direccion)
        {
            dBancosID = BancosID;
            dNombre = Nombre;
            dDireccion = Direccion;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID del banco
        public int BancosID
        {
            get { return dBancosID; }
            set { dBancosID = value; }
        }
        // Propiedad para obtener o establecer el nombre del banco
        public string Nombre
        {
            get { return dNombre; }
            set { dNombre = value; }
        }

        public string Actualizar(int bancosID, string nombre, string direccion)
        {
            throw new NotImplementedException();
        }

        // Propiedad para obtener o establecer la dirección del banco
        public string Direccion
        {
            get { return dDireccion; }
            set { dDireccion = value; }
        }
        #endregion

        // Método para insertar un nuevo banco en la base de datos
        public string Insertar(CDBancos objBancos)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de inserción
                    using (SqlCommand micomando = new SqlCommand("InsertarBanco", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la inserción del banco
                        micomando.Parameters.AddWithValue("@Nombre", objBancos.dNombre);
                        micomando.Parameters.AddWithValue("@Direccion", objBancos.dDireccion);

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
                throw new Exception("Error al intentar insertar datos del banco.", ex);
            }
        }

        // Método para actualizar los datos de un banco en la base de datos
        public string Actualizar(int bancosID, CDBancos objBancos)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de actualización
                    using (SqlCommand micomando = new SqlCommand("ActualizarBanco", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la actualización del banco
                        micomando.Parameters.AddWithValue("@BancosID", objBancos.dBancosID);
                        micomando.Parameters.AddWithValue("@Nombre", objBancos.dNombre);
                        micomando.Parameters.AddWithValue("@Direccion", objBancos.dDireccion);

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
                throw new Exception("Error al intentar actualizar datos del banco.", ex);
            }
        }

        // Método para obtener los datos de un banco por su ID
        public DataTable ObtenerBancoPorID(int BancosID)
        {
            try
            {
                // Se crea un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de obtención por ID
                    using (SqlCommand micomando = new SqlCommand("ObtenerBancoPorID", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añade el parámetro necesario para la consulta por ID
                        micomando.Parameters.AddWithValue("@BancosID", BancosID);

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
                throw new Exception("Error al intentar obtener datos del banco por ID.", ex);
            }
        }
    }
}
