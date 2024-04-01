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
        //int BancoID,
        public static string Insertar(int CatalogoID, string nombre, string sucursal, string direccion, string estado, string telefono, string correo, string oficialCuentas, string observaciones)
        {
            CDBancos objBanco = new CDBancos();
            // Preparamos los datos para insertar un nuevo Banco
            //  objBanco.BancoID = BancoID;
            objBanco.CatalogoID = CatalogoID;
            objBanco.Nombre = nombre;
            objBanco.Sucursal = sucursal;
            objBanco.Direccion = direccion;
            objBanco.Estado = estado;
            objBanco.Telefono = telefono;
            objBanco.Correo = correo;
            objBanco.OficialCuentas = oficialCuentas;
            objBanco.Observaciones = observaciones;

            // Llamamos al método Insertar del Banco pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objBanco.Insertar(objBanco);
        }


        public static string Actualizar(int bancoID, int CatalogoID, string nombre, string sucursal, string direccion, string estado, string telefono, string correo, string oficialCuentas, string observaciones)
        {
            CDBancos objBanco = new CDBancos();
            objBanco.BancoID = bancoID;
            objBanco.CatalogoID = CatalogoID;
            objBanco.Nombre = nombre;
            objBanco.Sucursal = sucursal;
            objBanco.Direccion = direccion;
            objBanco.Estado = estado;
            objBanco.Telefono = telefono;
            objBanco.Correo = correo;
            objBanco.OficialCuentas = oficialCuentas;
            objBanco.Observaciones = observaciones;
            return objBanco.Actualizar(objBanco);
        }


        public static DataTable ObtenerBancoPorID(int bancoID)
        {
            // Crear una instancia de la clase CDBancos
            CDBancos dbBancos = new CDBancos();

            // Llamada al método no estático ObtenerBancoPorID de la instancia dbBancos
            DataTable dt = dbBancos.ObtenerBancoPorID(bancoID);

            // Retornamos el DataTable con los datos adquiridos
            return dt;
        }



        //siiiiiiiiiiiiii
        public static DataTable ObtenerBanco()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                            Integrated Security=True;Pooling=true";
            string consulta = "SELECT * FROM Bancos";

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


        //// Método para obtener los catálogos
        //public static DataTable ObtenerCatalogos()
        //{
        //    // Establecer la conexión
        //    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        //                                    AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
        //                                    Integrated Security=True;Pooling=true"; // Reemplaza con tu cadena de conexión
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        // Definir la consulta SQL
        //        string query = "SELECT CatalogoID, Nombre FROM Catalogos";

        //        // Crear un objeto DataTable para almacenar los resultados
        //        DataTable dt = new DataTable();

        //        // Utilizar un SqlDataAdapter para ejecutar la consulta y llenar el DataTable
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
        //        {
        //            try
        //            {
        //                // Abrir la conexión y llenar el DataTable
        //                connection.Open();
        //                adapter.Fill(dt);
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejo de excepciones: podrías lanzar la excepción o registrarla según tus necesidades
        //                throw new Exception("Error al obtener los catálogos.", ex);
        //            }
        //        }

        //        // Devolver el DataTable con los resultados
        //        return dt;
        //    }
        //}
    



}
}