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
        public class CDConciliacionBancaria
        {
            // Campos privados para almacenar los datos de la conciliación bancaria
            private int dConciliacionID;
            private int dCuentaID;
            private DateTime dFecha;
            private decimal dSaldoContable;
            private decimal dSaldoBancario;

            // Constructor predeterminado de la clase
            public CDConciliacionBancaria()
            {

            }

            // Constructor con parámetros para inicializar los campos de la clase
            public CDConciliacionBancaria(int ConciliacionID, int CuentaID, DateTime Fecha, decimal SaldoContable, decimal SaldoBancario)
            {
                dConciliacionID = ConciliacionID;
                dCuentaID = CuentaID;
                dFecha = Fecha;
                dSaldoContable = SaldoContable;
                dSaldoBancario = SaldoBancario;
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
            // Propiedad para obtener la diferencia de la conciliación bancaria (solo lectura)
            public decimal Diferencia
            {
                get { return dSaldoContable - dSaldoBancario; }
            }
            #endregion

            // Método para insertar una nueva conciliación bancaria en la base de datos
            public string Insertar(int CuentaID, DateTime Fecha, decimal SaldoContable, decimal SaldoBancario)
            {
                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                    {
                        using (SqlCommand micomando = new SqlCommand("INSERT INTO ConciliacionBancaria (CuentaID, Fecha, SaldoContable, SaldoBancario) VALUES (@CuentaID, @Fecha, @SaldoContable, @SaldoBancario)", sqlCon))
                        {
                            micomando.Parameters.AddWithValue("@CuentaID", CuentaID);
                            micomando.Parameters.AddWithValue("@Fecha", Fecha);
                            micomando.Parameters.AddWithValue("@SaldoContable", SaldoContable);
                            micomando.Parameters.AddWithValue("@SaldoBancario", SaldoBancario);

                            sqlCon.Open();
                            int rowsAffected = micomando.ExecuteNonQuery();

                            return rowsAffected == 1 ? "Inserción de datos completada correctamente!" :
                                                       "No se pudo insertar correctamente los nuevos datos!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al intentar insertar datos de la conciliación bancaria.", ex);
                }
            }

            public string Actualizar(int ConciliacionID, DateTime Fecha, decimal SaldoContable, decimal SaldoBancario)
            {
                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                    {
                        using (SqlCommand micomando = new SqlCommand("UPDATE ConciliacionBancaria SET Fecha = @Fecha, SaldoContable = @SaldoContable, SaldoBancario = @SaldoBancario WHERE ConciliacionID = @ConciliacionID", sqlCon))
                        {
                            micomando.Parameters.AddWithValue("@ConciliacionID", ConciliacionID);
                            micomando.Parameters.AddWithValue("@Fecha", Fecha);
                            micomando.Parameters.AddWithValue("@SaldoContable", SaldoContable);
                            micomando.Parameters.AddWithValue("@SaldoBancario", SaldoBancario);

                            sqlCon.Open();
                            int rowsAffected = micomando.ExecuteNonQuery();

                            return rowsAffected == 1 ? "Actualización de datos completada correctamente!" :
                                                       "No se pudo actualizar correctamente los datos!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al intentar actualizar datos de la conciliación bancaria.", ex);
                }
            }

            public DataTable ObtenerConciliacionBancariaPorID(int ConciliacionID)
            {
                try
                {
                    DataTable dt = new DataTable();

                    using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                    {
                        using (SqlCommand micomando = new SqlCommand("SELECT * FROM ConciliacionBancaria WHERE ConciliacionID = @ConciliacionID", sqlCon))
                        {
                            micomando.Parameters.AddWithValue("@ConciliacionID", ConciliacionID);

                            SqlDataAdapter adapter = new SqlDataAdapter(micomando);
                            adapter.Fill(dt);
                        }
                    }

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al intentar obtener datos de la conciliación bancaria por ID.", ex);
                }
            }
        }
    }
