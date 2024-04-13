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
    {//int cuentaID,
        public static string Insertar( int bancoID, string clienteID, string tipoCuenta, string numeroCuenta, decimal saldoInicial, DateTime fechaApertura, string moneda, decimal debito, decimal credito, string estado, string observacion)
        {
            CDCuentasBancarias objCuentasBancarias = new CDCuentasBancarias();

            // Preparamos los datos para insertar una nueva cuenta bancaria
          //  objCuentasBancarias.CuentaID = cuentaID;
            objCuentasBancarias.BancoID = bancoID; // Agregamos el argumento bancoID aquí
            objCuentasBancarias.ClienteID = clienteID;
            objCuentasBancarias.TipoCuenta = tipoCuenta;
            objCuentasBancarias.NumeroCuenta = numeroCuenta;
            objCuentasBancarias.SaldoInicial = saldoInicial;
            objCuentasBancarias.FechaApertura = fechaApertura;
            objCuentasBancarias.Moneda = moneda;
            objCuentasBancarias.Debito = debito;
            objCuentasBancarias.Credito = credito;
            objCuentasBancarias.Estado = estado;
            objCuentasBancarias.Observacion = observacion;

            // Llamamos al método Insertar de la clase CDCuentasBancarias pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objCuentasBancarias.Insertar(objCuentasBancarias);
                //(cuentaID, bancoID, clienteID, tipoCuenta, numeroCuenta, saldoInicial, fechaApertura, moneda, debito, credito, estado, observacion);
        }



        public static string Actualizar(int cuentaID, int bancoID, string clienteID, string tipoCuenta, string numeroCuenta, decimal saldoInicial, DateTime fechaApertura, string moneda, decimal debito, decimal credito, string estado, string observacion)
              {
            CDCuentasBancarias objCuentasBancarias = new CDCuentasBancarias();

            // Preparamos los datos para insertar una nueva cuenta bancaria
            objCuentasBancarias.CuentaID = cuentaID;
            objCuentasBancarias.BancoID = bancoID;
            objCuentasBancarias.ClienteID = clienteID;
            objCuentasBancarias.TipoCuenta = tipoCuenta;
            objCuentasBancarias.NumeroCuenta = numeroCuenta;
            objCuentasBancarias.SaldoInicial = saldoInicial;
            objCuentasBancarias.FechaApertura = fechaApertura;
            objCuentasBancarias.Moneda = moneda;
            objCuentasBancarias.Debito = debito;
            objCuentasBancarias.Credito = credito;
            objCuentasBancarias.Estado = estado;
            objCuentasBancarias.Observacion = observacion;

            // Llamamos al método Insertar de la clase CDCuentasBancarias pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objCuentasBancarias.Actualizar(objCuentasBancarias);
        }



        public static DataTable ObtenerCuentaBancariaPorID(int? cuentaID, string tipoCuenta)
        {
            CDCuentasBancarias dbcuentas = new CDCuentasBancarias();
            // Llamada al método estático ObtenerBancoPorID de la clase CNBancos
            // y se cambia el nombre del método y parámetro por los correspondientes a Cuenta
            DataTable dt = dbcuentas.ObtenerCuentaBancariaPorID(cuentaID, tipoCuenta);

            // Retornamos el DataTable con los datos adquiridos
            return dt;
        }



        //siiiiiiiiiiiiii
        public static DataTable ObtenerCuenta()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                            Integrated Security=True;Pooling=true";
            string consulta = "SELECT * FROM CuentasBancarias";

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);
            }

            return dt;
        }



    }
}