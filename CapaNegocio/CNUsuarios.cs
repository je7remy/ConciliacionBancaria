using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using CapaDatos;

namespace CapaNegocio
{
    public class CNUsuarios
    {
        public static string Insertar(string nombreUsuario, string contraseñaHash, string correoElectronico, string rol, string estado)
        {
            CDUsuarios objUsuario = new CDUsuarios();
            // Preparamos los datos para insertar un nuevo usuario
         //   objUsuario.UsuarioID = usuarioID;
            objUsuario.NombreUsuario = nombreUsuario;
            objUsuario.ContraseñaHash = contraseñaHash;
            objUsuario.CorreoElectronico = correoElectronico;
            objUsuario.Rol = rol;
            objUsuario.Estado = estado;

            // Llamamos al método Insertar del Usuario pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objUsuario.Insertar(objUsuario);
        }

        public static string Actualizar(int usuarioID, string nombreUsuario, string contraseñaHash, string correoElectronico, string rol, string estado)
        {
            CDUsuarios objUsuario = new CDUsuarios();
            // Preparamos los datos para insertar un nuevo usuario
            objUsuario.UsuarioID = usuarioID;
            objUsuario.NombreUsuario = nombreUsuario;
            objUsuario.ContraseñaHash = contraseñaHash;
            objUsuario.CorreoElectronico = correoElectronico;
            objUsuario.Rol = rol;
            objUsuario.Estado = estado;

            // Llamamos al método Insertar del Usuario pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objUsuario.Insertar(objUsuario);
        }


       

        public static DataTable ObtenerUsuarioPorID(int? usuarioID, string nombreUsuario)
        {
            CDUsuarios dbUsuarios = new CDUsuarios();

            // Llamada al método estático ObtenerUsuarioPorID de la clase CNUsuarios
            DataTable dt = dbUsuarios.ObtenerUsuarioPorID(usuarioID, nombreUsuario);

            // Retornamos el DataTable con los datos adquiridos
            return dt;
        }

        //siiiiiiiiiiiiii
        public static DataTable ObtenerUsuario()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                            Integrated Security=True;Pooling=true";
            string consulta = "SELECT * FROM Usuarios";

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);
            }

            return dt;
        }
        //public static DataTable ObtenerUsuarioPorID(int usuarioID)
        //{
        //    try
        //    {
        //        // Creamos una instancia de la clase CDUsuarios
        //        CDUsuarios objUsuarios = new CDUsuarios();

        //        // Llamamos al método ObtenerUsuarioPorID de la capa de datos
        //        return objUsuarios.ObtenerUsuarioPorID(usuarioID);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar la excepción o propagarla hacia arriba según sea necesario
        //        // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
        //        throw new Exception("Error al obtener el usuario por ID.", ex);
        //    }
        //}
    }
}