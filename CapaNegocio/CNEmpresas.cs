﻿using System;
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
    public class CNEmpresas
    {
        public static string Insertar( string nombreEmpresa, string direccion, string informacionContacto, string telefono, string correo, string estado)
        {
            CDEmpresas objEmpresa = new CDEmpresas();
            // Preparamos los datos para insertar una nueva empresa
           // objEmpresa.EmpresaID = empresaID;
            objEmpresa.NombreEmpresa = nombreEmpresa;
            objEmpresa.Direccion = direccion;
            objEmpresa.InformacionContacto = informacionContacto;
            objEmpresa.Telefono = telefono;
            objEmpresa.Correo = correo;
            objEmpresa.Estado = estado;

            // Llamamos al método Insertar del Empresa pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objEmpresa.Insertar(objEmpresa);
        }

        public static string Actualizar(int empresaID, string nombreEmpresa, string direccion, string informacionContacto, string telefono, string correo, string estado)
        {
            CDEmpresas objEmpresa = new CDEmpresas();
            // Preparamos los datos para insertar una nueva empresa
            objEmpresa.EmpresaID = empresaID;
            objEmpresa.NombreEmpresa = nombreEmpresa;
            objEmpresa.Direccion = direccion;
            objEmpresa.InformacionContacto = informacionContacto;
            objEmpresa.Telefono = telefono;
            objEmpresa.Correo = correo;
            objEmpresa.Estado = estado;

            // Llamamos al método Insertar del Empresa pasándole el objeto creado y retornando el mensaje que indica si se pudo o no realizar la acción
            return objEmpresa.Actualizar(objEmpresa);
        }





        public static DataTable ObtenerEmpresaPorID(int? empresaID, string nombreEmpresa)
        {

            CDEmpresas dbBancos = new CDEmpresas();
            // Llamada al método estático ObtenerEmpresaPorID de la clase CNEmpresas
            DataTable dt = dbBancos.ObtenerEmpresaPorID(empresaID, nombreEmpresa);

            // Retornamos el DataTable con los datos adquiridos
            return dt;
        }


        //siiiiiiiiiiiiii
        public static DataTable ObtenerEmpresa()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                            Integrated Security=True;Pooling=true";
            string consulta = "SELECT * FROM Empresas";

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


        //public static DataTable ObtenerEmpresaPorID(int empresaID)
        //{
        //    try
        //    {
        //        // Creamos una instancia de la clase CDEmpresas
        //        CDEmpresas objEmpresas = new CDEmpresas();

        //        // Llamamos al método ObtenerEmpresaPorID de la capa de datos
        //        return objEmpresas.ObtenerEmpresaPorID(empresaID);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar la excepción o propagarla hacia arriba según sea necesario
        //        // En este caso, podrías lanzar la excepción o devolver un DataTable vacío
        //        throw new Exception("Error al obtener la empresa por ID.", ex);
        //    }
        //}
    }
}