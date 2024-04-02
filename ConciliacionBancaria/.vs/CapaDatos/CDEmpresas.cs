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
   
    /// Clase para manejar la conexión y operaciones con la tabla de empresas en la base de datos.
    
    public class CDEmpresas
    {
        // Campos privados para almacenar los datos de la empresa
        private int dEmpresaID;
        private string dNombreEmpresa;
        private string dDireccion;
        private string dInformacionContacto;
        private string dTelefono;
        private string dCorreo;
        private string dEstado;

        // Constructor predeterminado de la clase
        public CDEmpresas()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDEmpresas(int EmpresaID, string NombreEmpresa, string Direccion, string InformacionContacto, string Telefono, string Correo, string Estado)
        {
            dEmpresaID = EmpresaID;
            dNombreEmpresa = NombreEmpresa;
            dDireccion = Direccion;
            dInformacionContacto = InformacionContacto;
            dTelefono = Telefono;
            dCorreo = Correo;
            dEstado = Estado;
        }

        // Métodos Get y Set

        // Propiedad para obtener o establecer el ID de la empresa
        public int EmpresaID
        {
            get { return dEmpresaID; }
            set { dEmpresaID = value; }
        }

        // Propiedad para obtener o establecer el nombre de la empresa
        public string NombreEmpresa
        {
            get { return dNombreEmpresa; }
            set { dNombreEmpresa = value; }
        }

        // Propiedad para obtener o establecer la dirección de la empresa
        public string Direccion
        {
            get { return dDireccion; }
            set { dDireccion = value; }
        }

        // Propiedad para obtener o establecer la información de contacto de la empresa
        public string InformacionContacto
        {
            get { return dInformacionContacto; }
            set { dInformacionContacto = value; }
        }

        // Propiedad para obtener o establecer el teléfono de la empresa
        public string Telefono
        {
            get { return dTelefono; }
            set { dTelefono = value; }
        }

        // Propiedad para obtener o establecer el correo electrónico de la empresa
        public string Correo
        {
            get { return dCorreo; }
            set { dCorreo = value; }
        }

        // Propiedad para obtener o establecer el estado de la empresa
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        // Método para insertar una nueva empresa en la base de datos
        // Método para insertar una nueva empresa. Recibirá el objeto objEmpresa como parámetro
        public string Insertar(CDEmpresas objEmpresa)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso EmpresaInsertar
                SqlCommand micomando = new SqlCommand("InsertarEmpresa", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objEmpresa que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@EmpresaID", objEmpresa.EmpresaID);
                micomando.Parameters.AddWithValue("@NombreEmpresa", objEmpresa.NombreEmpresa);
                micomando.Parameters.AddWithValue("@Direccion", objEmpresa.Direccion);
                micomando.Parameters.AddWithValue("@InformacionContacto", objEmpresa.InformacionContacto);
                micomando.Parameters.AddWithValue("@Telefono", objEmpresa.Telefono);
                micomando.Parameters.AddWithValue("@Correo", objEmpresa.Correo);
                micomando.Parameters.AddWithValue("@Estado", objEmpresa.Estado);

                // Ejecutamos la instrucción. Si se devuelve el valor 1 significa que todo funcionó correctamente,
                // de lo contrario, se devuelve un mensaje indicando que fue incorrecto.
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Inserción de datos completada correctamente!" : "No se pudo insertar correctamente los nuevos datos!";
            }
            catch (Exception ex) // Si ocurre algún error, lo capturamos y mostramos el mensaje
            {
                mensaje = ex.Message;
            }
            finally // Luego de realizar el proceso de forma correcta o no 
            {
                // Cerramos la conexión si está abierta
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            // Devolvemos el mensaje correspondiente de acuerdo a lo que haya resultado del comando
            return mensaje;
        }

        // Método para actualizar los datos de una empresa en la base de datos
        // Método para insertar una nueva empresa. Recibirá el objeto objEmpresa como parámetro
        public string Actualizar(CDEmpresas objEmpresa)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso EmpresaInsertar
                SqlCommand micomando = new SqlCommand("ActualizarEmpresa", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objEmpresa que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@EmpresaID", objEmpresa.EmpresaID);
                micomando.Parameters.AddWithValue("@NombreEmpresa", objEmpresa.NombreEmpresa);
                micomando.Parameters.AddWithValue("@Direccion", objEmpresa.Direccion);
                micomando.Parameters.AddWithValue("@InformacionContacto", objEmpresa.InformacionContacto);
                micomando.Parameters.AddWithValue("@Telefono", objEmpresa.Telefono);
                micomando.Parameters.AddWithValue("@Correo", objEmpresa.Correo);
                micomando.Parameters.AddWithValue("@Estado", objEmpresa.Estado);

                // Ejecutamos la instrucción. Si se devuelve el valor 1 significa que todo funcionó correctamente,
                // de lo contrario, se devuelve un mensaje indicando que fue incorrecto.
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Actualizacion de datos completada correctamente!" : "No se pudo insertar correctamente los nuevos datos!";
            }
            catch (Exception ex) // Si ocurre algún error, lo capturamos y mostramos el mensaje
            {
                mensaje = ex.Message;
            }
            finally // Luego de realizar el proceso de forma correcta o no 
            {
                // Cerramos la conexión si está abierta
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            // Devolvemos el mensaje correspondiente de acuerdo a lo que haya resultado del comando
            return mensaje;
        }

        // Método para obtener los datos de una empresa por su ID
        public DataTable ObtenerEmpresaPorID(int empresaID)
        {
            DataTable dt = new DataTable(); // Se crea DataTable que tomará los datos de la Empresa
            SqlDataReader leerDatos; // Creamos el DataReader
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion)) // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                {
                    SqlCommand sqlCmd = new SqlCommand(); // Establecer el comando
                    sqlCmd.Connection = sqlCon; // Asignar la conexión al comando
                    sqlCon.Open(); // Se abre la conexión
                    sqlCmd.CommandText = "ObtenerEmpresaPorID"; // Nombre del Proc. Almacenado a usar
                    sqlCmd.CommandType = CommandType.StoredProcedure; // Se trata de un proc. almacenado
                    sqlCmd.Parameters.AddWithValue("@empresaID", empresaID); // Se pasa el ID del banco a buscar
                    leerDatos = sqlCmd.ExecuteReader(); // Llenamos el SqlDataReader con los datos resultantes
                    dt.Load(leerDatos); // Se cargan los registros devueltos al DataTable
                    sqlCon.Close(); // Se cierra la conexión
                }
            }
            catch (Exception)
            {
                dt = null; // Si ocurre algún error se anula el DataTable
            }
            return dt; // Se retorna el DataTable según lo ocurrido arriba

        }
            
            }
}