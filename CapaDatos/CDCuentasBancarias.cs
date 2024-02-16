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
    // Clase para manejar la conexión y operaciones con la tabla de cuenta bancarias en la base de datos
    public class CDCuentasBancarias
    {
        // Campos privados para almacenar los datos de la cuenta bancaria
        private int dCuentaID;
        private int dClienteID;
        private string dTipoCuenta;
        private string dNumeroCuenta;
        private decimal dSaldoInicial;

        // Constructor predeterminado de la clase
        public CDCuentasBancarias()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDCuentasBancarias(int CuentaID, int ClienteID, string TipoCuenta, string NumeroCuenta, decimal SaldoInicial)
        {
            dCuentaID = CuentaID;
            dClienteID = ClienteID;
            dTipoCuenta = TipoCuenta;
            dNumeroCuenta = NumeroCuenta;
            dSaldoInicial = SaldoInicial;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID de la cuenta bancaria
        public int CuentaID
        {
            get { return dCuentaID; }
            set { dCuentaID = value; }
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
        #endregion

        // Método para insertar una nueva cuenta bancaria en la base de datos
        public string Insertar(int ClienteID, string TipoCuenta, string NumeroCuenta, decimal SaldoInicial)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de inserción
                    using (SqlCommand micomando = new SqlCommand("InsertarCuentaBancaria", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la inserción de la cuenta bancaria
                        micomando.Parameters.AddWithValue("@ClienteID", ClienteID);
                        micomando.Parameters.AddWithValue("@TipoCuenta", TipoCuenta);
                        micomando.Parameters.AddWithValue("@NumeroCuenta", NumeroCuenta);
                        micomando.Parameters.AddWithValue("@SaldoInicial", SaldoInicial);

                        // Se abre la conexión a la base de datos
                        sqlCon.Open();
                        // Se ejecuta el comando y se obtiene el número de filas afectadas
                        int rowsAffected = micomando.ExecuteNonQuery();

                        // Se retorna un mensaje indicando el resultado de la operación
                        return rowsAffected == 1 ? "Inserción de datos completada correctamente!" :
                                                   "No se pudo insertar correctamente los nuevos datos!";
                    }
                }
            }
            catch (Exception ex)
            {
                // Se lanza una excepción con un mensaje descriptivo y la excepción original
                throw new Exception("Error al intentar insertar datos de la cuenta bancaria.", ex);
            }
        }

        // Método para actualizar los datos de una cuenta bancaria en la base de datos
        public string Actualizar(int CuentaID, string TipoCuenta, string NumeroCuenta, decimal SaldoInicial)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de actualización
                    using (SqlCommand micomando = new SqlCommand("ActualizarCuentaBancaria", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la actualización de la cuenta bancaria
                        micomando.Parameters.AddWithValue("@CuentaID", CuentaID);
                        micomando.Parameters.AddWithValue("@TipoCuenta", TipoCuenta);
                        micomando.Parameters.AddWithValue("@NumeroCuenta", NumeroCuenta);
                        micomando.Parameters.AddWithValue("@SaldoInicial", SaldoInicial);

                        // Se abre la conexión a la base de datos
                        sqlCon.Open();
                        // Se ejecuta el comando y se obtiene el número de filas afectadas
                        int rowsAffected = micomando.ExecuteNonQuery();

                        // Se retorna un mensaje indicando el resultado de la operación
                        return rowsAffected == 1 ? "Actualización de datos completada correctamente!" :
                                                   "No se pudo actualizar correctamente los datos!";
                    }
                }
            }
            catch (Exception ex)
            {
                // Se lanza una excepción con un mensaje descriptivo y la excepción original
                throw new Exception("Error al intentar actualizar datos de la cuenta bancaria.", ex);
            }
        }

        // Método para obtener los datos de una cuenta bancaria por su ID
        public DataTable ObtenerCuentaPorID(int CuentaID)
        {
            try
            {
                // Se crea un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de obtención por ID
                    using (SqlCommand micomando = new SqlCommand("ObtenerCuentaBancariaPorID", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añade el parámetro necesario para la consulta por ID
                        micomando.Parameters.AddWithValue("@CuentaID", CuentaID);

                        // Se crea un adaptador de datos para ejecutar la consulta y llenar el DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(micomando);
                        adapter.Fill(dt);
                    }
                }

                // Se retorna el DataTable con los datos obtenidos
                return dt;
            }
            catch (Exception ex)
            {
                // Se lanza una excepción con un mensaje descriptivo y la excepción original
                throw new Exception("Error al intentar obtener datos de la cuenta bancaria por ID.", ex);
            }
        }
    }
}
