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
   public class CNEmpresas
    {

        public static string Insertar(string nombreEmpresa, string direccion, string informacionContacto, string otrosDetalles)
        {
            try
            {
                // Creamos una instancia de la clase CDEmpresas
                CDEmpresas objEmpresas = new CDEmpresas();

                // Llamamos al método InsertarEmpresa de la capa de datos pasándole los parámetros recibidos
                return objEmpresas.Insertar(nombreEmpresa, direccion, informacionContacto, otrosDetalles);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar la empresa: " + ex.Message;
            }
        }

        public static string Actualizar(int empresaID, string nombreEmpresa, string direccion, string informacionContacto, string otrosDetalles)
        {
            try
            {
                // Creamos una instancia de la clase CDEmpresas
                CDEmpresas objEmpresas = new CDEmpresas();

                // Llamamos al método ActualizarEmpresa de la capa de datos pasándole los parámetros recibidos
                return objEmpresas.Actualizar(empresaID, nombreEmpresa, direccion, informacionContacto, otrosDetalles);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar la empresa: " + ex.Message;
            }
        }

        public static DataTable ObtenerEmpresaPorID(int empresaID)
        {
            try
            {
                // Creamos una instancia de la clase CDEmpresas
                CDEmpresas objEmpresas = new CDEmpresas();

                // Llamamos al método ObtenerEmpresaPorID de la capa de datos
                return objEmpresas.ObtenerEmpresaPorID(empresaID);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
                throw new Exception("Error al obtener la empresa por ID.", ex);
            }
        }

    }
}
