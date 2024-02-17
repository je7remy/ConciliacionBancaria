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


        public static string Insertar(int clienteID, int cuentaID, DateTime fecha, string descripcion, decimal monto, string tipo)
        {
            try
            {
                // Creamos una instancia de la clase CDTransaccionesInternas
                CDTransaccionesInternas objTransaccionesInternas = new CDTransaccionesInternas();

                // Llamamos al método InsertarTransaccionInterna de la capa de datos pasándole los parámetros recibidos
                return objTransaccionesInternas.Insertar(clienteID, cuentaID, fecha, descripcion, monto, tipo);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar la transacción interna: " + ex.Message;
            }
        }

        public static string Actualizar(int transaccionID, DateTime fecha, string descripcion, decimal monto, string tipo)
        {
            try
            {
                // Creamos una instancia de la clase CDTransaccionesInternas
                CDTransaccionesInternas objTransaccionesInternas = new CDTransaccionesInternas();

                // Llamamos al método ActualizarTransaccionInterna de la capa de datos pasándole los parámetros recibidos
                return objTransaccionesInternas.Actualizar(transaccionID, fecha, descripcion, monto, tipo);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar la transacción interna: " + ex.Message;
            }
        }

        public static DataTable ObtenerTransaccionInternaPorID(int transaccionID)
        {
            try
            {
                // Creamos una instancia de la clase CDTransaccionesInternas
                CDTransaccionesInternas objTransaccionesInternas = new CDTransaccionesInternas();

                // Llamamos al método ObtenerTransaccionInternaPorID de la capa de datos
                return objTransaccionesInternas.ObtenerTransaccionInternaPorID(transaccionID);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
                throw new Exception("Error al obtener la transacción interna por ID.", ex);
            }
        }


    }
}
