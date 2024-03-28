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
    public class CNTransaccionesInternas
    {
        //int TransaccionID,
        public static string Insertar( int usuarioID, int bancoID, int cuentaID, string clienteID, DateTime fecha, string descripcion, decimal monto, string tipo, string observacion)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo CDBancos
            CDTransaccionesInternas objTransaccionesInternas = new CDTransaccionesInternas();

            try
            {
                // Preparamos los datos para insertar una nueva transacción
                //objTransaccionesInternas.TransaccionID = TransaccionID;
                objTransaccionesInternas.UsuarioID = usuarioID;
                objTransaccionesInternas.BancoID = bancoID;
                objTransaccionesInternas.CuentaID = cuentaID;
                objTransaccionesInternas.ClienteID = clienteID;
                objTransaccionesInternas.Fecha = fecha;
                objTransaccionesInternas.Descripcion = descripcion;
                objTransaccionesInternas.Monto = monto;
                objTransaccionesInternas.Tipo = tipo;
                objTransaccionesInternas.Observacion = observacion;

                // Llamamos al método Insertar del Banco pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
                mensaje = objTransaccionesInternas.Insertar(objTransaccionesInternas);
            }
            catch (Exception ex)
            {
                mensaje = "Error al insertar la transacción: " + ex.Message;
            }

            return mensaje;
        }


        public static string Actualizar(int TransaccionID, int usuarioID, int bancoID, int cuentaID, string clienteID, DateTime fecha, string descripcion, decimal monto, string tipo, string observacion)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo CDBancos
            CDTransaccionesInternas objTransaccionesInternas = new CDTransaccionesInternas();

            try
            {
                // Preparamos los datos para insertar una nueva transacción
                objTransaccionesInternas.TransaccionID = TransaccionID;
                objTransaccionesInternas.UsuarioID = usuarioID;
                objTransaccionesInternas.BancoID = bancoID;
                objTransaccionesInternas.CuentaID = cuentaID;
                objTransaccionesInternas.ClienteID = clienteID;
                objTransaccionesInternas.Fecha = fecha;
                objTransaccionesInternas.Descripcion = descripcion;
                objTransaccionesInternas.Monto = monto;
                objTransaccionesInternas.Tipo = tipo;
                objTransaccionesInternas.Observacion = observacion;

                // Llamamos al método Insertar del Banco pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
                mensaje = objTransaccionesInternas.Actualizar(objTransaccionesInternas);
            }
            catch (Exception ex)
            {
                mensaje = "Error al insertar la transacción: " + ex.Message;
            }

            return mensaje;
        }




        public static DataTable ObtenerTransaccionInternaPorID(int transaccionID)
        {
            // Llamada al método estático ObtenerTransaccionInternaPorID de la clase CNTransaccionesInternas
            DataTable dt = CNTransaccionesInternas.ObtenerTransaccionInternaPorID(transaccionID);

            // Retornamos el DataTable con los datos adquiridos
            return dt;
        }

        //public static DataTable ObtenerTransaccionInternaPorID(int transaccionID)
        //{
        //    try
        //    {
        //        // Creamos una instancia de la clase CDTransaccionesInternas
        //        CDTransaccionesInternas objTransaccionesInternas = new CDTransaccionesInternas();

        //        // Llamamos al método ObtenerTransaccionInternaPorID de la capa de datos
        //        return objTransaccionesInternas.ObtenerTransaccionInternaPorID(transaccionID);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar la excepción o propagarla hacia arriba según sea necesario
        //        // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
        //        throw new Exception("Error al obtener la transacción interna por ID.", ex);
        //    }
        //}
    }
}