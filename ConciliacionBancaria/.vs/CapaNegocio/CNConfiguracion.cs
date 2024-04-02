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
   public class CNConfiguracion
    {

        public static string Insertar(string nombreConfiguracion, string valorConfiguracion, string descripcion, string tipoConfiguracion, string tablaRelacionada, string otrosDetalles)
        {
            try
            {
                // Creamos una instancia de la clase CDConfiguracion
                CDConfiguracion objConfiguracion = new CDConfiguracion();

                // Llamamos al método InsertarConfiguracion de la capa de datos pasándole los parámetros recibidos
                return objConfiguracion.Insertar(nombreConfiguracion, valorConfiguracion, descripcion, tipoConfiguracion, tablaRelacionada, otrosDetalles);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar la configuración: " + ex.Message;
            }
        }

        public static string Actualizar(int configuracionID, string nombreConfiguracion, string valorConfiguracion, string descripcion, string tipoConfiguracion, string tablaRelacionada, string otrosDetalles)
        {
            try
            {
                // Creamos una instancia de la clase CDConfiguracion
                CDConfiguracion objConfiguracion = new CDConfiguracion();

                // Llamamos al método ActualizarConfiguracion de la capa de datos pasándole los parámetros recibidos
                return objConfiguracion.Actualizar(configuracionID, nombreConfiguracion, valorConfiguracion, descripcion, tipoConfiguracion, tablaRelacionada, otrosDetalles);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar la configuración: " + ex.Message;
            }
        }

        public static DataTable ObtenerConfiguracionPorID(int configuracionID)
        {
            try
            {
                // Creamos una instancia de la clase CDConfiguracion
                CDConfiguracion objConfiguracion = new CDConfiguracion();

                // Llamamos al método ObtenerConfiguracionPorID de la capa de datos
                return objConfiguracion.ObtenerConfiguracionPorID(configuracionID);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
                throw new Exception("Error al obtener la configuración por ID.", ex);
            }
        }

    }
}
