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
    // Clase para manejar la conexión y operaciones con la tabla de conciliación bancaria en la base de datos
    public class  CDConciliacionBancaria
    {

        // Campos privados para almacenar los datos de la conciliación bancaria
        private int dConciliacionID;
        private int dCuentaID;
        private DateTime dFecha;
        private decimal dSaldoContable;
        private decimal dSaldoBancario;
        private decimal dDiferencia;

        // Constructor predeterminado de la clase
        public CDConciliacionBancaria()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDConciliacionBancaria(int ConciliacionID, int CuentaID, DateTime Fecha, decimal SaldoContable, decimal SaldoBancario, decimal Diferencia)
        {
            dConciliacionID = ConciliacionID;
            dCuentaID = CuentaID;
            dFecha = Fecha;
            dSaldoContable = SaldoContable;
            dSaldoBancario = SaldoBancario;
            dDiferencia = Diferencia;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID de la conciliación bancaria
        public int ConciliacionID
        {
            get { return dConciliacionID; }
            set { dConciliacionID = value; }
        }
        // Propiedad para obtener o establecer el ID de la cuenta asociada a la conciliación bancaria
        public int CuentaID
        {
            get { return dCuentaID; }
            set { dCuentaID = value; }
        }
        // Propiedad para obtener o establecer la fecha de la conciliación bancaria
        public DateTime Fecha
        {
            get { return dFecha; }
            set { dFecha = value; }
        }
        // Propiedad para obtener o establecer el saldo contable de la conciliación bancaria
        public decimal SaldoContable
        {
            get { return dSaldoContable; }
            set { dSaldoContable = value; }
        }
        // Propiedad para obtener o establecer el saldo bancario de la conciliación bancaria
        public decimal SaldoBancario
        {
            get { return dSaldoBancario; }
            set { dSaldoBancario = value; }
        }
        // Propiedad para obtener o establecer la diferencia de la conciliación bancaria
        public decimal Diferencia
        {
            get { return dDiferencia; }
            set { dDiferencia = value; }
        }
        #endregion

        // Método para insertar una nueva conciliación bancaria en la base de datos
        public string Insertar(CDConciliacionBancaria objConciliacion)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de inserción
                    using (SqlCommand micomando = new SqlCommand("InsertarConciliacionBancaria", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la inserción de la conciliación bancaria
                        micomando.Parameters.AddWithValue("@CuentaID", objConciliacion.dCuentaID);
                        micomando.Parameters.AddWithValue("@Fecha", objConciliacion.dFecha);
                        micomando.Parameters.AddWithValue("@SaldoContable", objConciliacion.dSaldoContable);
                        micomando.Parameters.AddWithValue("@SaldoBancario", objConciliacion.dSaldoBancario);
                        micomando.Parameters.AddWithValue("@Diferencia", objConciliacion.dDiferencia);

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
                throw new Exception("Error al intentar insertar datos de la conciliación bancaria.", ex);
            }
        }

        // Método para actualizar los datos de una conciliación bancaria en la base de datos
        public string Actualizar(CDConciliacionBancaria objConciliacion)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de actualización
                    using (SqlCommand micomando = new SqlCommand("ActualizarConciliacionBancaria", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la actualización de la conciliación bancaria
                        micomando.Parameters.AddWithValue("@ConciliacionID", objConciliacion.dConciliacionID);
                        micomando.Parameters.AddWithValue("@Fecha", objConciliacion.dFecha);
                        micomando.Parameters.AddWithValue("@SaldoContable", objConciliacion.dSaldoContable);
                        micomando.Parameters.AddWithValue("@SaldoBancario", objConciliacion.dSaldoBancario);
                        micomando.Parameters.AddWithValue("@Diferencia", objConciliacion.dDiferencia);

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
                throw new Exception("Error al intentar actualizar datos de la conciliación bancaria.", ex);
            }
        }

        // Método para obtener los datos de una conciliación bancaria por su ID
        public DataTable ObtenerConciliacionPorID(int ConciliacionID)
        {
            try
            {
                // Se crea un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de obtención por ID
                    using (SqlCommand micomando = new SqlCommand("ObtenerConciliacionBancariaPorID", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añade el parámetro necesario para la consulta por ID
                        micomando.Parameters.AddWithValue("@ConciliacionID", ConciliacionID);

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
                throw new Exception("Error al intentar obtener datos de la conciliación bancaria por ID.", ex);
            }
        }

}
}
