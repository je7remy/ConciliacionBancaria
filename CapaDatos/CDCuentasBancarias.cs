using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace CapaDatos
{
    /// <summary>
    /// Clase para manejar la conexión y operaciones con la tabla de cuentas bancarias en la base de datos.
    /// </summary>
    public class CDCuentasBancarias
    {
        // Campos privados para almacenar los datos de la cuenta bancaria
        private int dCuentaID;
        private int dBancoID;
        private int dClienteID;
        private string dTipoCuenta;
        private string dNumeroCuenta;
        private decimal dSaldoInicial;
        private DateTime dFechaApertura;
        private string dMoneda;
        private decimal dDebito;
        private decimal dCredito;
        private string dEstado;
        private string dObservacion;

        // Constructor predeterminado de la clase
        public CDCuentasBancarias()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDCuentasBancarias(int CuentaID, int BancoID, int ClienteID, string TipoCuenta, string NumeroCuenta, decimal SaldoInicial, DateTime FechaApertura, string Moneda, decimal Debito, decimal Credito, string Estado, string Observacion)
        {
            dCuentaID = CuentaID;
            dBancoID = BancoID;
            dClienteID = ClienteID;
            dTipoCuenta = TipoCuenta;
            dNumeroCuenta = NumeroCuenta;
            dSaldoInicial = SaldoInicial;
            dFechaApertura = FechaApertura;
            dMoneda = Moneda;
            dDebito = Debito;
            dCredito = Credito;
            dEstado = Estado;
            dObservacion = Observacion;
        }

        // Métodos Get y Set

        // Propiedad para obtener o establecer el ID de la cuenta bancaria
        public int CuentaID
        {
            get { return dCuentaID; }
            set { dCuentaID = value; }
        }

        // Propiedad para obtener o establecer el ID del banco asociado a la cuenta bancaria
        public int BancoID
        {
            get { return dBancoID; }
            set { dBancoID = value; }
        }

        // Propiedad para obtener o establecer el ID del cliente asociado a la cuenta bancaria
        public int ClienteID
        {
            get { return dClienteID; }
            set { dClienteID = value; }
        }

        // Propiedad para obtener o establecer el tipo de cuenta bancaria
        public string TipoCuenta
        {
            get { return dTipoCuenta; }
            set { dTipoCuenta = value; }
        }

        // Propiedad para obtener o establecer el número de cuenta bancaria
        public string NumeroCuenta
        {
            get { return dNumeroCuenta; }
            set { dNumeroCuenta = value; }
        }

        // Propiedad para obtener o establecer el saldo inicial de la cuenta bancaria
        public decimal SaldoInicial
        {
            get { return dSaldoInicial; }
            set { dSaldoInicial = value; }
        }

        // Propiedad para obtener o establecer la fecha de apertura de la cuenta bancaria
        public DateTime FechaApertura
        {
            get { return dFechaApertura; }
            set { dFechaApertura = value; }
        }

        // Propiedad para obtener o establecer la moneda de la cuenta bancaria
        public string Moneda
        {
            get { return dMoneda; }
            set { dMoneda = value; }
        }

        // Propiedad para obtener o establecer el monto de débito de la cuenta bancaria
        public decimal Debito
        {
            get { return dDebito; }
            set { dDebito = value; }
        }

        // Propiedad para obtener o establecer el monto de crédito de la cuenta bancaria
        public decimal Credito
        {
            get { return dCredito; }
            set { dCredito = value; }
        }

        // Propiedad para obtener o establecer el estado de la cuenta bancaria
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        // Propiedad para obtener o establecer las observaciones de la cuenta bancaria
        public string Observacion
        {
            get { return dObservacion; }
            set { dObservacion = value; }
        }

        // Método para insertar una nueva cuenta bancaria en la base de datos
        public string Insertar(int bancoID, int clienteID, string tipoCuenta, string numeroCuenta, decimal saldoInicial, DateTime fechaApertura, string moneda, decimal debito, decimal credito, string estado, string observacion)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    using (SqlCommand micomando = new SqlCommand("InsertarCuentaBancaria", sqlCon))
                    {
                        micomando.CommandType = CommandType.StoredProcedure;
                        micomando.Parameters.AddWithValue("@BancoID", dBancoID);
                        micomando.Parameters.AddWithValue("@ClienteID", dClienteID);
                        micomando.Parameters.AddWithValue("@TipoCuenta", dTipoCuenta);
                        micomando.Parameters.AddWithValue("@NumeroCuenta", dNumeroCuenta);
                        micomando.Parameters.AddWithValue("@SaldoInicial", dSaldoInicial);
                        micomando.Parameters.AddWithValue("@FechaApertura", dFechaApertura);
                        micomando.Parameters.AddWithValue("@Moneda", dMoneda);
                        micomando.Parameters.AddWithValue("@Debito", dDebito);
                        micomando.Parameters.AddWithValue("@Credito", dCredito);
                        micomando.Parameters.AddWithValue("@Estado", dEstado);
                        micomando.Parameters.AddWithValue("@Observacion", dObservacion);

                        sqlCon.Open();
                        int rowsAffected = micomando.ExecuteNonQuery();

                        return rowsAffected == 1 ? "Inserción de datos completada correctamente!" :
                                                   "No se pudo insertar correctamente los nuevos datos!";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar datos de la cuenta bancaria.", ex);
            }
        }

        // Método para actualizar los datos de una cuenta bancaria en la base de datos
        public string Actualizar(int cuentaID, int bancoID, int clienteID, string tipoCuenta, string numeroCuenta, decimal saldoInicial, DateTime fechaApertura, string moneda, decimal debito, decimal credito, string estado, string observacion)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    using (SqlCommand micomando = new SqlCommand("ActualizarCuentaBancaria", sqlCon))
                    {
                        micomando.CommandType = CommandType.StoredProcedure;
                        micomando.Parameters.AddWithValue("@CuentaID", dCuentaID);
                        micomando.Parameters.AddWithValue("@TipoCuenta", dTipoCuenta);
                        micomando.Parameters.AddWithValue("@NumeroCuenta", dNumeroCuenta);
                        micomando.Parameters.AddWithValue("@SaldoInicial", dSaldoInicial);

                        sqlCon.Open();
                        int rowsAffected = micomando.ExecuteNonQuery();

                        return rowsAffected == 1 ? "Actualización de datos completada correctamente!" :
                                                   "No se pudo actualizar correctamente los datos!";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar actualizar datos de la cuenta bancaria.", ex);
            }
        }

        // Método para obtener los datos de una cuenta bancaria por su ID
        public DataTable ObtenerCuentaPorID(int CuentaID)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    using (SqlCommand micomando = new SqlCommand("ObtenerCuentaBancariaPorID", sqlCon))
                    {
                        micomando.CommandType = CommandType.StoredProcedure;
                        micomando.Parameters.AddWithValue("@CuentaID", CuentaID);

                        SqlDataAdapter adapter = new SqlDataAdapter(micomando);
                        adapter.Fill(dt);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar obtener datos de la cuenta bancaria por ID.", ex);
            }
        }
    }
}