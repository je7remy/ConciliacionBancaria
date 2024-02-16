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
   public class CNBancos
    {
        public static string Insertar(string Nombre, string Direccion)
        {
            try
            {
                // Creamos una instancia de la clase CDBancos
                CDBancos objBancos = new CDBancos();

                // Llamamos al método Insertar de la capa de datos pasándole los parámetros recibidos
                return objBancos.Insertar(Nombre, Direccion);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar el banco: " + ex.Message;
            }
        }

        public static string Actualizar(int BancosID, string Nombre, string Direccion)
        {
            try
            {
                // Creamos una instancia de la clase CDBancos
                CDBancos objBancos = new CDBancos();

                // Llamamos al método Actualizar de la capa de datos pasándole los parámetros recibidos
                return objBancos.Actualizar(BancosID, Nombre, Direccion);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar el banco: " + ex.Message;
            }
        }

        public static DataTable ObtenerBancoPorID(int BancosID)
        {
            try
            {
                // Creamos una instancia de la clase CDBancos
                CDBancos objBancos = new CDBancos();

                // Llamamos al método ObtenerBancoPorID de la capa de datos
                return objBancos.ObtenerBancoPorID(BancosID);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
                throw new Exception("Error al obtener el banco por ID.", ex);
            }
        }

    }
}
