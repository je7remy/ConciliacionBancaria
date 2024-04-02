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
        // Método para insertar un nuevo usuario. Recibirá el objeto objUsuario como parámetro
        public string Insertar(CDUsuarios objUsuario)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso InsertarUsuario
                SqlCommand micomando = new SqlCommand("InsertarUsuario", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objUsuario que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@UsuarioID", objUsuario.UsuarioID);
                micomando.Parameters.AddWithValue("@NombreUsuario", objUsuario.NombreUsuario);
                micomando.Parameters.AddWithValue("@ContraseñaHash", objUsuario.ContraseñaHash);
                micomando.Parameters.AddWithValue("@CorreoElectronico", objUsuario.CorreoElectronico);
                micomando.Parameters.AddWithValue("@Rol", objUsuario.Rol);
                micomando.Parameters.AddWithValue("@Estado", objUsuario.Estado);

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

        // Método para actualizar los datos de un usuario en la base de datos
       
        public string Actualizar(CDUsuarios objUsuario)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso InsertarUsuario
                SqlCommand micomando = new SqlCommand("ActualizarUsuario", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objUsuario que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@UsuarioID", objUsuario.UsuarioID);
                micomando.Parameters.AddWithValue("@NombreUsuario", objUsuario.NombreUsuario);
                micomando.Parameters.AddWithValue("@ContraseñaHash", objUsuario.ContraseñaHash);
                micomando.Parameters.AddWithValue("@CorreoElectronico", objUsuario.CorreoElectronico);
                micomando.Parameters.AddWithValue("@Rol", objUsuario.Rol);
                micomando.Parameters.AddWithValue("@Estado", objUsuario.Estado);

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

        // Método para obtener los datos de un usuario por su ID
        // Método para obtener los datos de un usuario por su ID
        public DataTable ObtenerUsuarioPorID(int usuarioID)
        {
            DataTable dt = new DataTable(); // Se crea DataTable que tomará los datos del Usuario
            SqlDataReader leerDatos; // Creamos el DataReader
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion)) // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                {
                    SqlCommand sqlCmd = new SqlCommand(); // Establecer el comando
                    sqlCmd.Connection = sqlCon; // Asignar la conexión al comando
                    sqlCon.Open(); // Se abre la conexión
                    sqlCmd.CommandText = "ObtenerUsuarioPorID"; // Nombre del Proc. Almacenado a usar
                    sqlCmd.CommandType = CommandType.StoredProcedure; // Se trata de un proc. almacenado
                    sqlCmd.Parameters.AddWithValue("@usuarioID", usuarioID); // Se pasa el ID del usuario a buscar
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