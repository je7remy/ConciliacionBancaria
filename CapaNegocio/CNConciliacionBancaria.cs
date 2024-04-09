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

    

    //public static DataTable ObtenerConciliacionBancariaPorID(int conciliacionID)
    //{
    //    try
    //    {
    //        // Creamos una instancia de la clase CDConciliacionBancaria
    //        CDConciliacionBancaria objConciliacionBancaria = new CDConciliacionBancaria();

    //        // Llamamos al método ObtenerConciliacionBancariaPorID de la capa de datos
    //        return objConciliacionBancaria.ObtenerConciliacionBancariaPorID(conciliacionID);
    //    }
    //    catch (Exception ex)
    //    {
    //        // Manejar la excepción o propagarla hacia arriba según sea necesario
    //        // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
    //        throw new Exception("Error al obtener la conciliación bancaria por ID.", ex);
    //    }
    //}
}
}