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
        public static string Insertar(string nombre, string sucursal, string direccion, string estado, string telefono, string correo, string oficialCuentas, string observaciones)
        {
            try
            {
                // Creamos una instancia de la clase CDBancos
                CDBancos objBancos = new CDBancos();

                // Llamamos al método InsertarBanco de la capa de datos pasándole los parámetros recibidos
                return objBancos.Insertar(nombre, sucursal, direccion, estado, telefono, correo, oficialCuentas, observaciones);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar el banco: " + ex.Message;
            }
        }

        public static string Actualizar(int bancoID, string nombre, string sucursal, string direccion, string estado, string telefono, string correo, string oficialCuentas, string observaciones)
        {
            try
            {
                // Creamos una instancia de la clase CDBancos
                CDBancos objBancos = new CDBancos();

                // Llamamos al método ActualizarBanco de la capa de datos pasándole los parámetros recibidos
                return objBancos.Actualizar(bancoID, nombre, sucursal, direccion, estado, telefono, correo, oficialCuentas, observaciones);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar el banco: " + ex.Message;
            }
        }

        public static DataTable ObtenerBancoPorID(int bancoID)
        {
            try
            {
                // Creamos una instancia de la clase CDBancos
                CDBancos objBancos = new CDBancos();

                // Llamamos al método ObtenerBancoPorID de la capa de datos
                return objBancos.ObtenerBancoPorID(bancoID);
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