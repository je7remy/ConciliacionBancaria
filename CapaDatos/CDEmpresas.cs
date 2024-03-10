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
        public string Insertar(string NombreEmpresa, string Direccion, string InformacionContacto, string Telefono, string Correo, string Estado)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    using (SqlCommand micomando = new SqlCommand("InsertarEmpresa", sqlCon))
                    {
                        micomando.CommandType = CommandType.StoredProcedure;
                        micomando.Parameters.AddWithValue("@NombreEmpresa", dNombreEmpresa);
                        micomando.Parameters.AddWithValue("@Direccion", dDireccion);
                        micomando.Parameters.AddWithValue("@InformacionContacto", dInformacionContacto);
                        micomando.Parameters.AddWithValue("@Telefono", dTelefono);
                        micomando.Parameters.AddWithValue("@Correo", dCorreo);
                        micomando.Parameters.AddWithValue("@Estado", dEstado);



                        SqlParameter outputParam = new SqlParameter("@EmpresaID", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        micomando.Parameters.Add(outputParam);

                        sqlCon.Open();
                        int rowsAffected = micomando.ExecuteNonQuery();

                        // Lee el valor devuelto por el procedimiento almacenado
                        int newEmpresaID = Convert.ToInt32(outputParam.Value);

                        CDEmpresas nuevaEmpresa = new CDEmpresas(newEmpresaID, NombreEmpresa, Direccion, InformacionContacto, Telefono, Correo, Estado);


                        // Se retorna un mensaje indicando el resultado de la operación
                        return rowsAffected == 1 ? "Inserción de datos completada correctamente! Transacción ID: " + newEmpresaID :
                                                    "No se pudo insertar correctamente los nuevos datos!";

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar datos de la empresa.", ex);
            }
        }

        // Método para actualizar los datos de una empresa en la base de datos
        public string Actualizar(int EmpresaID, string NombreEmpresa, string Direccion, string InformacionContacto, string Telefono, string Correo, string Estado)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    using (SqlCommand micomando = new SqlCommand("ActualizarEmpresa", sqlCon))
                    {
                        micomando.CommandType = CommandType.StoredProcedure;
                        micomando.Parameters.AddWithValue("@EmpresaID", dEmpresaID);
                        micomando.Parameters.AddWithValue("@NombreEmpresa", dNombreEmpresa);
                        micomando.Parameters.AddWithValue("@Direccion", dDireccion);
                        micomando.Parameters.AddWithValue("@InformacionContacto", dInformacionContacto);
                        micomando.Parameters.AddWithValue("@Telefono", dTelefono);
                        micomando.Parameters.AddWithValue("@Correo", dCorreo);
                        micomando.Parameters.AddWithValue("@Estado", dEstado);

                        sqlCon.Open();
                        int rowsAffected = micomando.ExecuteNonQuery();

                        return rowsAffected == 1 ? "Actualización de datos completada correctamente!" :
                                                   "No se pudo actualizar correctamente los datos!";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar actualizar datos de la empresa.", ex);
            }
        }

        // Método para obtener los datos de una empresa por su ID
        public DataTable ObtenerEmpresaPorID(int EmpresaID)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection sqlCon = new SqlConnection(CapaPresentacionConexion.miconexion))
                {
                    using (SqlCommand micomando = new SqlCommand("ObtenerEmpresaPorID", sqlCon))
                    {
                        micomando.CommandType = CommandType.StoredProcedure;
                        micomando.Parameters.AddWithValue("@EmpresaID", EmpresaID);

                        SqlDataAdapter adapter = new SqlDataAdapter(micomando);
                        adapter.Fill(dt);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar obtener datos de la empresa por ID.", ex);
            }
        }
    }
}