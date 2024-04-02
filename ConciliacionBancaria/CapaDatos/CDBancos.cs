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
    // Clase para manejar la conexión y operaciones con la tabla de bancos en la base de datos
    public class CDBancos
    {
        // Campos privados para almacenar los datos del banco
        private int dBancoID;
        private int dCatalogoID;
        private string dNombre;
        private string dSucursal;
        private string dDireccion;
        private string dEstado;
        private string dTelefono;
        private string dCorreo;
        private string dOficialCuentas;
        private string dObservaciones;

        // Constructor predeterminado de la clase
        public CDBancos()
        {

        }

        // Constructor con parámetros para inicializar los campos de la clase
        public CDBancos(int BancoID, int CatalogoID, string Nombre, string Sucursal, string Direccion, string Estado, string Telefono, string Correo, string OficialCuentas, string Observaciones)
        {
            dBancoID = BancoID;
            dCatalogoID = CatalogoID;
            dNombre = Nombre;
            dSucursal = Sucursal;
            dDireccion = Direccion;
            dEstado = Estado;
            dTelefono = Telefono;
            dCorreo = Correo;
            dOficialCuentas = OficialCuentas;
            dObservaciones = Observaciones;
        }

        #region Métodos Get y Set
        // Propiedad para obtener o establecer el ID del banco
        public int BancoID
        {
            get { return dBancoID; }
            set { dBancoID = value; }
        }
        // Propiedad para obtener o establecer el ID del catálogo asociado al banco
        public int CatalogoID
        {
            get { return dCatalogoID; }
            set { dCatalogoID = value; }
        }
        // Propiedad para obtener o establecer el nombre del banco
        public string Nombre
        {
            get { return dNombre; }
            set { dNombre = value; }
        }
        // Propiedad para obtener o establecer la sucursal del banco
        public string Sucursal
        {
            get { return dSucursal; }
            set { dSucursal = value; }
        }
        // Propiedad para obtener o establecer la dirección del banco
        public string Direccion
        {
            get { return dDireccion; }
            set { dDireccion = value; }
        }
        // Propiedad para obtener o establecer el estado del banco
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }
        // Propiedad para obtener o establecer el teléfono del banco
        public string Telefono
        {
            get { return dTelefono; }
            set { dTelefono = value; }
        }
        // Propiedad para obtener o establecer el correo del banco
        public string Correo
        {
            get { return dCorreo; }
            set { dCorreo = value; }
        }
        // Propiedad para obtener o establecer el oficial de cuentas del banco
        public string OficialCuentas
        {
            get { return dOficialCuentas; }
            set { dOficialCuentas = value; }
        }
        // Propiedad para obtener o establecer las observaciones del banco
        public string Observaciones
        {
            get { return dObservaciones; }
            set { dObservaciones = value; }
        }
        #endregion

        // Método para insertar un nuevo Banco. Recibirá el objeto objBanco como parámetro
        public string Insertar(CDBancos objBanco)
        {
            string mensaje = "";
            // Creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            // Trataremos de hacer algunas operaciones con la tabla
            try
            {
                // Asignamos a sqlCon la conexión con la base de datos a través de la clase que creamos
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                // Escribimos el nombre del procedimiento almacenado que utilizaremos, en este caso BancoInsertar
                SqlCommand micomando = new SqlCommand("InsertarBanco", sqlCon);
                sqlCon.Open(); // Abrimos la conexión
                               // Indicamos que se ejecutará un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /* Enviamos los parámetros al procedimiento almacenado.
                 * Los nombres que aparecen con el signo @ delante son los parámetros que hemos
                 * creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual 
                 * aparecen en dicho procedimiento almacenado (respetar mayúsculas y minúsculas).
                 * Los nombres que aparecen al lado son las propiedades del objeto objBanco que se pasará 
                 * como parámetro con los valores deseados. 
                 */
                micomando.Parameters.AddWithValue("@BancoID", objBanco.BancoID);
                micomando.Parameters.AddWithValue("@CatalogoID", objBanco.CatalogoID);
                micomando.Parameters.AddWithValue("@Nombre", objBanco.Nombre);
                micomando.Parameters.AddWithValue("@Sucursal", objBanco.Sucursal);
                micomando.Parameters.AddWithValue("@Direccion", objBanco.Direccion);
                micomando.Parameters.AddWithValue("@Estado", objBanco.Estado);
                micomando.Parameters.AddWithValue("@Telefono", objBanco.Telefono);
                micomando.Parameters.AddWithValue("@Correo", objBanco.Correo);
                micomando.Parameters.AddWithValue("@Oficial_de_cuentas", objBanco.OficialCuentas);
                micomando.Parameters.AddWithValue("@Observaciones", objBanco.Observaciones);

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



        // Método para actualizar los datos del Banco. Recibirá el objeto objBanco como parámetro
        public string Actualizar(CDBancos objBanco)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = CapaPresentacionConexion.miconexion;
                SqlCommand micomando = new SqlCommand("ActualizarBanco", sqlCon); // Suponiendo que el procedimiento almacenado se llama BancoActualizar
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@BancoID", objBanco.BancoID);
                micomando.Parameters.AddWithValue("@CatalogoID", objBanco.CatalogoID);
                micomando.Parameters.AddWithValue("@Nombre", objBanco.Nombre);
                micomando.Parameters.AddWithValue("@Sucursal", objBanco.Sucursal);
                micomando.Parameters.AddWithValue("@Direccion", objBanco.Direccion);
                micomando.Parameters.AddWithValue("@Estado", objBanco.Estado);
                micomando.Parameters.AddWithValue("@Telefono", objBanco.Telefono);
                micomando.Parameters.AddWithValue("@Correo", objBanco.Correo);
                micomando.Parameters.AddWithValue("@Oficial_de_cuentas", objBanco.OficialCuentas);
                micomando.Parameters.AddWithValue("@Observaciones", objBanco.Observaciones);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos actualizados correctamente!" :
                    "No se pudo actualizar correctamente los datos!";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }


        // Método para obtener los datos de un banco por su ID
        public DataTable ObtenerBancoPorID(int bancoID)
        {
            DataTable dt = new DataTable(); // Se crea DataTable que tomará los datos del Banco
            SqlDataReader leerDatos; // Creamos el DataReader
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion)) // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                {
                    SqlCommand sqlCmd = new SqlCommand(); // Establecer el comando
                    sqlCmd.Connection = sqlCon; // Asignar la conexión al comando
                    sqlCon.Open(); // Se abre la conexión
                    sqlCmd.CommandText = "ObtenerBancoPorID"; // Nombre del Proc. Almacenado a usar
                    sqlCmd.CommandType = CommandType.StoredProcedure; // Se trata de un proc. almacenado
                    sqlCmd.Parameters.AddWithValue("@bancoID", bancoID); // Se pasa el ID del banco a buscar
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
