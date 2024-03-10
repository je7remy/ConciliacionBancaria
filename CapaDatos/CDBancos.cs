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

        // Método para insertar un nuevo banco en la base de datos
        public string Insertar(string nombre, string sucursal, string direccion, string estado, string telefono, string correo, string oficialCuentas, string observaciones)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de inserción
                    using (SqlCommand micomando = new SqlCommand("InsertarBanco", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la inserción del banco
                        micomando.Parameters.AddWithValue("@Nombre", nombre);
                        micomando.Parameters.AddWithValue("@Sucursal", sucursal);
                        micomando.Parameters.AddWithValue("@Direccion", direccion);
                        micomando.Parameters.AddWithValue("@Estado", estado);
                        micomando.Parameters.AddWithValue("@Telefono", telefono);
                        micomando.Parameters.AddWithValue("@Correo", correo);
                        micomando.Parameters.AddWithValue("@Oficial_de_cuentas", oficialCuentas);
                        micomando.Parameters.AddWithValue("@Observaciones", observaciones);



                        SqlParameter outputParam = new SqlParameter("@BancoID", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        micomando.Parameters.Add(outputParam);

                        sqlCon.Open();
                        int rowsAffected = micomando.ExecuteNonQuery();

                        // Lee el valor devuelto por el procedimiento almacenado
                        int newBancoID = Convert.ToInt32(outputParam.Value);

                        CDBancos nuevoBanco = new CDBancos(newBancoID, CatalogoID, Nombre, Sucursal, Direccion, Estado, Telefono, Correo, OficialCuentas, Observaciones);


                        // Se retorna un mensaje indicando el resultado de la operación
                        return rowsAffected == 1 ? "Inserción de datos completada correctamente! Transacción ID: " + newBancoID :
                                                    "No se pudo insertar correctamente los nuevos datos!";
                    }
                }
            }
            catch (Exception ex)
            {
                // Se lanza una excepción con un mensaje descriptivo y la excepción original
                throw new Exception("Error al intentar insertar datos del banco.", ex);
            }
        }

        // Método para actualizar los datos de un banco en la base de datos
        public string Actualizar(int bancoID, string nombre, string sucursal, string direccion, string estado, string telefono, string correo, string oficialCuentas, string observaciones)
        {
            try
            {
                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de actualización
                    using (SqlCommand micomando = new SqlCommand("ActualizarBanco", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añaden los parámetros necesarios para la actualización del banco
                        micomando.Parameters.AddWithValue("@BancoID", bancoID);
                        micomando.Parameters.AddWithValue("@Nombre", nombre);
                        micomando.Parameters.AddWithValue("@Sucursal", sucursal);
                        micomando.Parameters.AddWithValue("@Direccion", direccion);
                        micomando.Parameters.AddWithValue("@Estado", estado);
                        micomando.Parameters.AddWithValue("@Telefono", telefono);
                        micomando.Parameters.AddWithValue("@Correo", correo);
                        micomando.Parameters.AddWithValue("@Oficial_de_cuentas", oficialCuentas);
                        micomando.Parameters.AddWithValue("@Observaciones", observaciones);

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
                throw new Exception("Error al intentar actualizar datos del banco.", ex);
            }
        }

        // Método para obtener los datos de un banco por su ID
        public DataTable ObtenerBancoPorID(int bancoID)
        {
            try
            {
                // Se crea un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Se establece la conexión a la base de datos utilizando la cadena de conexión proporcionada
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    // Se crea un comando SQL para ejecutar el procedimiento almacenado de obtención por ID
                    using (SqlCommand micomando = new SqlCommand("ObtenerBancoPorID", sqlCon))
                    {
                        // Se especifica que el comando es un procedimiento almacenado
                        micomando.CommandType = CommandType.StoredProcedure;
                        // Se añade el parámetro necesario para la consulta por ID
                        micomando.Parameters.AddWithValue("@BancoID", bancoID);

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
                throw new Exception("Error al intentar obtener datos del banco por ID.", ex);
            }
        }
    }
}
