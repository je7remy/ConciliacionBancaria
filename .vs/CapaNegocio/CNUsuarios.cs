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
            try
            {
                // Creamos una instancia de la clase CDUsuarios
                CDUsuarios objUsuarios = new CDUsuarios();

                // Llamamos al método InsertarUsuario de la capa de datos pasándole los parámetros recibidos
                return objUsuarios.Insertar(nombreUsuario, contraseñaHash, correoElectronico, rol, estado);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar el usuario: " + ex.Message;
            }
        }

        public static string Actualizar(int usuarioID, string nombreUsuario, string contraseñaHash, string correoElectronico, string rol, string estado)
        {
            try
            {
                // Creamos una instancia de la clase CDUsuarios
                CDUsuarios objUsuarios = new CDUsuarios();

                // Llamamos al método ActualizarUsuario de la capa de datos pasándole los parámetros recibidos
                return objUsuarios.Actualizar(usuarioID, nombreUsuario, contraseñaHash, correoElectronico, rol, estado);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar el usuario: " + ex.Message;
            }
        }

        public static DataTable ObtenerUsuarioPorID(int usuarioID)
        {
            try
            {
                // Creamos una instancia de la clase CDUsuarios
                CDUsuarios objUsuarios = new CDUsuarios();

                // Llamamos al método ObtenerUsuarioPorID de la capa de datos
                return objUsuarios.ObtenerUsuarioPorID(usuarioID);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
                throw new Exception("Error al obtener el usuario por ID.", ex);
            }
        }
    }
}