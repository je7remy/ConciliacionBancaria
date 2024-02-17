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
    // Clase para manejar la conexión y operaciones con la tabla de transacciones internas en la base de datos
    public class CDTransaccionesInternas
    {
      
            // Campos privados para almacenar los datos de la transacción interna
            private int dTransaccionID;
            private int dClienteID;
            private int dCuentaID;
            private DateTime dFecha;
            private string dDescripcion;
            private decimal dMonto;
            private string dTipo;

            // Constructor predeterminado de la clase
            public CDTransaccionesInternas()
            {

            }

            // Constructor con parámetros para inicializar los campos de la clase
            public CDTransaccionesInternas(int TransaccionID, int ClienteID, int CuentaID, DateTime Fecha, string Descripcion, decimal Monto, string Tipo)
            {
                dTransaccionID = TransaccionID;
                dClienteID = ClienteID;
                dCuentaID = CuentaID;
                dFecha = Fecha;
                dDescripcion = Descripcion;
                dMonto = Monto;
                dTipo = Tipo;
            }

            #region Métodos Get y Set
            // Propiedad para obtener o establecer el ID de la transacción interna
            public int TransaccionID
            {
                get { return dTransaccionID; }
                set { dTransaccionID = value; }
            }
            // Propiedad para obtener o establecer el ID del cliente asociado a la transacción interna
            public int ClienteID
            {
                get { return dClienteID; }
                set { dClienteID = value; }
            }
            // Propiedad para obtener o establecer el ID de la cuenta asociada a la transacción interna
            public int CuentaID
            {
                get { return dCuentaID; }
                set { dCuentaID = value; }
            }
            // Propiedad para obtener o establecer la fecha de la transacción interna
            public DateTime Fecha
            {
                get { return dFecha; }
                set { dFecha = value; }
            }
            // Propiedad para obtener o establecer la descripción de la transacción interna
            public string Descripcion
            {
                get { return dDescripcion; }
                set { dDescripcion = value; }
            }
            // Propiedad para obtener o establecer el monto de la transacción interna
            public decimal Monto
            {
                get { return dMonto; }
                set { dMonto = value; }
            }
            // Propiedad para obtener o establecer el tipo de la transacción interna
            public string Tipo
            {
                get { return dTipo; }
                set { dTipo = value; }
            }
            #endregion




            // Método para insertar una nueva transacción interna en la base de datos
            public string Insertar(int ClienteID, int CuentaID, DateTime Fecha, string Descripcion, decimal Monto, string Tipo)
            {
                try
                {
                    // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                    using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                    {
                        // Se crea un comando SQL para ejecutar el procedimiento almacenado de inserción
                        using (SqlCommand micomando = new SqlCommand("InsertarTransaccionInterna", sqlCon))
                        {
                            // Se especifica que el comando es un procedimiento almacenado
                            micomando.CommandType = CommandType.StoredProcedure;
                            // Se añaden los parámetros necesarios para la inserción de la transacción interna
                            micomando.Parameters.AddWithValue("@ClienteID", ClienteID);
                            micomando.Parameters.AddWithValue("@CuentaID", CuentaID);
                            micomando.Parameters.AddWithValue("@Fecha", Fecha);
                            micomando.Parameters.AddWithValue("@Descripcion", Descripcion);
                            micomando.Parameters.AddWithValue("@Monto", Monto);
                            micomando.Parameters.AddWithValue("@Tipo", Tipo);

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
                    throw new Exception("Error al intentar insertar datos de la transacción interna.", ex);
                }
            }

            // Método para actualizar los datos de una transacción interna en la base de datos
            public string Actualizar(int transaccionID, DateTime fecha, string descripcion, decimal monto, string tipo)
            {
                try
                {
                    // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                    using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                    {
                        // Se crea un comando SQL para ejecutar el procedimiento almacenado de actualización
                        using (SqlCommand micomando = new SqlCommand("ActualizarTransaccionInterna", sqlCon))
                        {
                            // Se especifica que el comando es un procedimiento almacenado
                            micomando.CommandType = CommandType.StoredProcedure;
                            // Se añaden los parámetros necesarios para la actualización de la transacción interna
                            micomando.Parameters.AddWithValue("@TransaccionID", TransaccionID);
                            micomando.Parameters.AddWithValue("@Fecha", Fecha);
                            micomando.Parameters.AddWithValue("@Descripcion", Descripcion);
                            micomando.Parameters.AddWithValue("@Monto", Monto);
                            micomando.Parameters.AddWithValue("@Tipo", Tipo);

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
                    throw new Exception("Error al intentar actualizar datos de la transacción interna.", ex);
                }
            }

            // Método para obtener los datos de una transacción interna por su ID
            public DataTable ObtenerTransaccionInternaPorID(int TransaccionID)
            {
                try
                {
                    // Se crea un objeto DataTable para almacenar los resultados de la consulta
                    DataTable dt = new DataTable();

                    // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                    using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                    {
                        // Se crea un comando SQL para ejecutar el procedimiento almacenado de obtención por ID
                        using (SqlCommand micomando = new SqlCommand("ObtenerTransaccionInternaPorID", sqlCon))
                        {
                            // Se especifica que el comando es un procedimiento almacenado
                            micomando.CommandType = CommandType.StoredProcedure;
                            // Se añade el parámetro necesario para la consulta por ID
                            micomando.Parameters.AddWithValue("@TransaccionID", TransaccionID);

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
                    throw new Exception("Error al intentar obtener datos de la transacción interna por ID.", ex);
                }
            }



        }
    }
