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
    public class CNConciliacionBancaria
    {
        public static string Insertar(int cuentaID, DateTime fecha, decimal saldoContable, decimal saldoBancario)
        {
            try
            {
                // Creamos una instancia de la clase CDConciliacionBancaria
                CDConciliacionBancaria objConciliacionBancaria = new CDConciliacionBancaria();

                // Llamamos al método InsertarConciliacionBancaria de la capa de datos pasándole los parámetros recibidos
                return objConciliacionBancaria.Insertar(cuentaID, fecha, saldoContable, saldoBancario);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar la conciliación bancaria: " + ex.Message;
            }
        }

        public static string Actualizar(int conciliacionID, DateTime fecha, decimal saldoContable, decimal saldoBancario)
        {
            try
            {
                // Creamos una instancia de la clase CDConciliacionBancaria
                CDConciliacionBancaria objConciliacionBancaria = new CDConciliacionBancaria();

                // Llamamos al método ActualizarConciliacionBancaria de la capa de datos pasándole los parámetros recibidos
                return objConciliacionBancaria.Actualizar(conciliacionID, fecha, saldoContable, saldoBancario);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar la conciliación bancaria: " + ex.Message;
            }
        }

        public static DataTable ObtenerConciliacionBancariaPorID(int conciliacionID)
        {
            try
            {
                // Creamos una instancia de la clase CDConciliacionBancaria
                CDConciliacionBancaria objConciliacionBancaria = new CDConciliacionBancaria();

                // Llamamos al método ObtenerConciliacionBancariaPorID de la capa de datos
                return objConciliacionBancaria.ObtenerConciliacionBancariaPorID(conciliacionID);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
                throw new Exception("Error al obtener la conciliación bancaria por ID.", ex);
            }
        }
    }
}