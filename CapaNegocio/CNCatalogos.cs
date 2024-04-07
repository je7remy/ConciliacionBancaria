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
    public class CNCatalogos
    {

        public static string Insertar( string nombre, string descripcion, string cuentasPadres, string origen, decimal balance, string estado)
        {
            CDCatalogos objCatalogo = new CDCatalogos();
            // Preparamos los datos para insertar un nuevo catálogo
           // objCatalogo.CatalogoID = catalogoID;
            objCatalogo.Nombre = nombre;
            objCatalogo.Descripcion = descripcion;
            objCatalogo.CuentasPadres = cuentasPadres;
            objCatalogo.Origen = origen;
            objCatalogo.Balance = balance;
            objCatalogo.Estado = estado;

            // Llamamos al método Insertar del Catalogo pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objCatalogo.Insertar(objCatalogo);
        }

        public static string Actualizar(int catalogoID, string nombre, string descripcion, string cuentasPadres, string origen, decimal balance, string estado)
        {
            CDCatalogos objCatalogo = new CDCatalogos();
            // Preparamos los datos para insertar un nuevo catálogo
            objCatalogo.CatalogoID = catalogoID;
            objCatalogo.Nombre = nombre;
            objCatalogo.Descripcion = descripcion;
            objCatalogo.CuentasPadres = cuentasPadres;
            objCatalogo.Origen = origen;
            objCatalogo.Balance = balance;
            objCatalogo.Estado = estado;

            // Llamamos al método Insertar del Catalogo pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objCatalogo.Actualizar(objCatalogo);
        }






        public static DataTable ObtenerCatalogoPorID(int? catalogoID, string nombre)
        {
            CDCatalogos dbcatalogos = new CDCatalogos();
            // Llamada al método estático ObtenerCatalogoPorID de la clase CNCatalogos
            DataTable dt = dbcatalogos.ObtenerCatalogoPorID(catalogoID, nombre);

            // Retornamos el DataTable con los datos adquiridos
            return dt;
        }

       
        //siiiiiiiiiiiiii
        public static DataTable ObtenerCatalogo()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                            Integrated Security=True;Pooling=true";
            string consulta = "SELECT * FROM Catalogos";

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