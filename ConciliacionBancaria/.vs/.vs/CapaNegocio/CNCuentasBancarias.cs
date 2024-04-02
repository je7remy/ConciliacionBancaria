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
    public class CNCuentasBancarias
    {
        public static string Insertar(int bancoID, int clienteID, string tipoCuenta, string numeroCuenta, decimal saldoInicial, DateTime fechaApertura, string moneda, decimal debito, decimal credito, string estado, string observacion)
        {
            try
            {
                // Creamos una instancia de la clase CDCuentasBancarias
                CDCuentasBancarias objCuentasBancarias = new CDCuentasBancarias();

                // Llamamos al método Insertar de la capa de datos pasándole los parámetros recibidos
                return objCuentasBancarias.Insertar(bancoID, clienteID, tipoCuenta, numeroCuenta, saldoInicial, fechaApertura, moneda, debito, credito, estado, observacion);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al insertar la cuenta bancaria: " + ex.Message;
            }
        }

        public static string Actualizar(int cuentaID, int bancoID, int clienteID, string tipoCuenta, string numeroCuenta, decimal saldoInicial, DateTime fechaApertura, string moneda, decimal debito, decimal credito, string estado, string observacion)
        {
            try
            {
                // Creamos una instancia de la clase CDCuentasBancarias
                CDCuentasBancarias objCuentasBancarias = new CDCuentasBancarias();

                // Llamamos al método Actualizar de la capa de datos pasándole los parámetros recibidos
                return objCuentasBancarias.Actualizar(cuentaID, bancoID, clienteID, tipoCuenta, numeroCuenta, saldoInicial, fechaApertura, moneda, debito, credito, estado, observacion);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                return "Error al actualizar la cuenta bancaria: " + ex.Message;
            }
        }

        public static DataTable ObtenerCuentaBancariaPorID(int cuentaID)
        {
            try
            {
                // Creamos una instancia de la clase CDCuentasBancarias
                CDCuentasBancarias objCuentasBancarias = new CDCuentasBancarias();

                // Llamamos al método ObtenerCuentaBancariaPorID de la capa de datos
                return objCuentasBancarias.ObtenerCuentaPorID(cuentaID);
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla hacia arriba según sea necesario
                // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
                throw new Exception("Error al obtener la cuenta bancaria por ID.", ex);
            }
        }

    }
}