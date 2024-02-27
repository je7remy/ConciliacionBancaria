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
    public class CNCatalogos
    {

        public static string Insertar(string nombre, string descripcion, string cuentasPadres, string origen, decimal balance, string estado)
        {
            try
            {
                // Creamos una instancia de la clase CDCatalogos
                CDCatalogos objCatalogos = new CDCatalogos();

                // Llamamos al método InsertarCatalogo de la capa de datos pasándole los parámetros recibidos
                return objCatalogos.Insertar(nombre, descripcion, cuentasPadres, origen, balance, estado);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar el catálogo: " + ex.Message;
            }
        }

        public static string Actualizar(int catalogoID, string nombre, string descripcion, string cuentasPadres, string origen, decimal balance, string estado)
        {
            try
            {
                // Creamos una instancia de la clase CDCatalogos
                CDCatalogos objCatalogos = new CDCatalogos();

                // Llamamos al método ActualizarCatalogo de la capa de datos pasándole los parámetros recibidos
                return objCatalogos.Actualizar(catalogoID, nombre, descripcion, cuentasPadres, origen, balance, estado);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar el catálogo: " + ex.Message;
            }
        }

        public static DataTable ObtenerCatalogoPorID(int catalogoID)
        {
            try
            {
                // Creamos una instancia de la clase CDCatalogos
                CDCatalogos objCatalogos = new CDCatalogos();

                // Llamamos al método ObtenerCatalogoPorID de la capa de datos
                return objCatalogos.ObtenerCatalogoPorID(catalogoID);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
                throw new Exception("Error al obtener el catálogo por ID.", ex);
            }
        }

    }
}