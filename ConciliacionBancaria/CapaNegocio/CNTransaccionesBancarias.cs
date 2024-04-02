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
   public class CNTransaccionesBancarias
    {

        public static string Insertar(int cuentaID, DateTime fecha, string descripcion, decimal monto, string tipo)
        {
            try
            {
                // Creamos una instancia de la clase CDTransaccionesBancarias
                CDTransaccionesBancarias objTransaccionesBancarias = new CDTransaccionesBancarias();

                // Llamamos al método InsertarTransaccionBancaria de la capa de datos pasándole los parámetros recibidos
                return objTransaccionesBancarias.Insertar(cuentaID, fecha, descripcion, monto, tipo);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar la transacción bancaria: " + ex.Message;
            }
        }

        public static string Actualizar(int transaccionBancariaID, DateTime fecha, string descripcion, decimal monto, string tipo)
        {
            try
            {
                // Creamos una instancia de la clase CDTransaccionesBancarias
                CDTransaccionesBancarias objTransaccionesBancarias = new CDTransaccionesBancarias();

                // Llamamos al método ActualizarTransaccionBancaria de la capa de datos pasándole los parámetros recibidos
                return objTransaccionesBancarias.Actualizar(transaccionBancariaID, fecha, descripcion, monto, tipo);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar la transacción bancaria: " + ex.Message;
            }
        }

        public static DataTable ObtenerTransaccionBancariaPorID(int transaccionBancariaID)
        {
            try
            {
                // Creamos una instancia de la clase CDTransaccionesBancarias
                CDTransaccionesBancarias objTransaccionesBancarias = new CDTransaccionesBancarias();

                // Llamamos al método ObtenerTransaccionBancariaPorID de la capa de datos
                return objTransaccionesBancarias.ObtenerTransaccionBancariaPorID(transaccionBancariaID);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
                throw new Exception("Error al obtener la transacción bancaria por ID.", ex);
            }
        }

    }
}
