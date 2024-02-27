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
    // Clase para manejar la conexión y operaciones con la tabla de usuarios en la base de datos
    public class CDUsuarios
    {

        // Campos privados para almacenar los datos del usuario
        private int dUsuarioID;
        private string dNombreUsuario;
        private string dContraseñaHash;
        private string dCorreoElectronico;
        private string dRol;
        private string dEstado;

        // Constructor predeterminado de la clase
        public CDUsuarios()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDUsuarios(int UsuarioID, string NombreUsuario, string ContraseñaHash, string CorreoElectronico, string Rol, string Estado)
        {
            dUsuarioID = UsuarioID;
            dNombreUsuario = NombreUsuario;
            dContraseñaHash = ContraseñaHash;
            dCorreoElectronico = CorreoElectronico;
            dRol = Rol;
            dEstado = Estado;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID del usuario
        public int UsuarioID
        {
            get { return dUsuarioID; }
            set { dUsuarioID = value; }
        }
        // Propiedad para obtener o establecer el nombre de usuario
        public string NombreUsuario
        {
            get { return dNombreUsuario; }
            set { dNombreUsuario = value; }
        }
        // Propiedad para obtener o establecer el hash de la contraseña del usuario
        public string ContraseñaHash
        {
            get { return dContraseñaHash; }
            set { dContraseñaHash = value; }
        }
        // Propiedad para obtener o establecer el correo electrónico del usuario
        public string CorreoElectronico
        {
            get { return dCorreoElectronico; }
            set { dCorreoElectronico = value; }
        }
        // Propiedad para obtener o establecer el rol del usuario
        public string Rol
        {
            get { return dRol; }
            set { dRol = value; }
        }
        // Propiedad para obtener o establecer el estado del usuario
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }
        #endregion

        // Método para insertar un nuevo usuario en la base de datos
        public string Insertar(string NombreUsuario, string ContraseñaHash, string CorreoElectronico, string Rol, string Estado)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de inserción
                    using (SqlCommand micomando = new SqlCommand("InsertarUsuario", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la inserción del usuario
                        micomando.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                        micomando.Parameters.AddWithValue("@ContraseñaHash", ContraseñaHash);
                        micomando.Parameters.AddWithValue("@CorreoElectronico", CorreoElectronico);
                        micomando.Parameters.AddWithValue("@Rol", Rol);
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
                throw new Exception("Error al intentar insertar datos del usuario.", ex);
            }
        }

        // Método para actualizar los datos de un usuario en la base de datos
        public string Actualizar(int UsuarioID, string NombreUsuario, string ContraseñaHash, string CorreoElectronico, string Rol, string Estado)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de actualización
                    using (SqlCommand micomando = new SqlCommand("ActualizarUsuario", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la actualización del usuario
                        micomando.Parameters.AddWithValue("@UsuarioID", UsuarioID);
                        micomando.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                        micomando.Parameters.AddWithValue("@ContraseñaHash", ContraseñaHash);
                        micomando.Parameters.AddWithValue("@CorreoElectronico", CorreoElectronico);
                        micomando.Parameters.AddWithValue("@Rol", Rol);
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
                throw new Exception("Error al intentar actualizar datos del usuario.", ex);
            }
        }

        // Método para obtener los datos de un usuario por su ID
        public DataTable ObtenerUsuarioPorID(int UsuarioID)
        {
            try
            {
                // Se crea un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de obtención por ID
                    using (SqlCommand micomando = new SqlCommand("ObtenerUsuarioPorID", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añade el parámetro necesario para la consulta por ID
                        micomando.Parameters.AddWithValue("@UsuarioID", UsuarioID);

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
                throw new Exception("Error al intentar obtener datos del usuario por ID.", ex);
            }
        }

    }
}