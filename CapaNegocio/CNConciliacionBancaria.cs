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
    public class CNConciliacionBancaria
    {//int conciliacionID
        public static string Insertar( int cuentaID, DateTime fecha, string estado, decimal saldoContable, decimal saldoBancario)
        {
            CDConciliacionBancaria objConciliacionBancaria = new CDConciliacionBancaria();
            // Preparamos los datos para insertar una nueva conciliación bancaria
        //    objConciliacionBancaria.ConciliacionID = conciliacionID;
            objConciliacionBancaria.CuentaID = cuentaID;
            objConciliacionBancaria.Fecha = fecha;
            objConciliacionBancaria.Estado = estado;
            objConciliacionBancaria.SaldoContable = saldoContable;
            objConciliacionBancaria.SaldoBancario = saldoBancario;
           

            // Llamamos al método Insertar del ConciliacionesBancarias pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objConciliacionBancaria.Insertar(objConciliacionBancaria);
        }

        public static string Actualizar(int conciliacionID, int cuentaID, DateTime fecha, string estado, decimal saldoContable, decimal saldoBancario)
        {
            CDConciliacionBancaria objConciliacionBancaria = new CDConciliacionBancaria();
            // Preparamos los datos para insertar una nueva conciliación bancaria
            objConciliacionBancaria.ConciliacionID = conciliacionID;
            objConciliacionBancaria.CuentaID = cuentaID;
            objConciliacionBancaria.Fecha = fecha;
            objConciliacionBancaria.Estado = estado;
            objConciliacionBancaria.SaldoContable = saldoContable;
            objConciliacionBancaria.SaldoBancario = saldoBancario;
       
            // Llamamos al método Insertar del ConciliacionesBancarias pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objConciliacionBancaria.Actualizar(objConciliacionBancaria);
        }





        public static DataTable ObtenerConciliacionBancariaPorID(int conciliacionID)
        {
            // Llamada al método estático ObtenerConciliacionBancariaPorID de la clase CNConciliacionesBancarias
            DataTable dt = CNConciliacionBancaria.ObtenerConciliacionBancariaPorID(conciliacionID);

            // Retornamos el DataTable con los datos adquiridos
            return dt;
        }



        public static DataTable ObtenerConciliacionBancariaPorID( string estado, int? ConciliacionID)
        {
            // Crear una instancia de la clase CDBancos
            CDConciliacionBancaria ConciliacionBancaria = new CDConciliacionBancaria();

            // Llamada al método no estático ObtenerBancoPorID de la instancia dbBancos
            DataTable dt = ConciliacionBancaria.ObtenerConciliacionBancariaPorID( estado, ConciliacionID);

            // Retornamos el DataTable con los datos adquiridos
            return dt;
        }



     
            public static DataTable ObtenerConciliacionBancariaPorFecha(DateTime? fechaInicio, DateTime? fechaFin)
            {
                // Crear una instancia de la clase CDCConciliacionBancaria
                CDConciliacionBancaria cdConciliacionBancaria = new CDConciliacionBancaria();

                // Llamar al método ObtenerConciliacionBancariaPorFecha de la instancia cdConciliacionBancaria
                DataTable dt = cdConciliacionBancaria.ObtenerConciliacionBancariaPorFecha(fechaInicio, fechaFin);

                // Retornar el DataTable con los datos obtenidos
                return dt;
            }
        




        //siiiiiiiiiiiiii
        public static DataTable ObtenerConciliacion()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                            Integrated Security=True;Pooling=true";
            string consulta = "SELECT * FROM ConciliacionBancaria";

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

        public static DataTable ObtenerConciliacionE()
        {
            // Cadena de conexión a la base de datos
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                Integrated Security=True;Pooling=true";

            // Consulta SQL para obtener las conciliaciones no conciliadas
            string consulta = "SELECT * FROM ConciliacionBancaria WHERE Estado = 'No Conciliado'";

            // DataTable para almacenar los resultados
            DataTable dt = new DataTable();

            // Establecer la conexión y ejecutar la consulta
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(consulta, connection);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Cargar los resultados en el DataTable
                dt.Load(reader);
            }

            return dt;
        }


    }
}