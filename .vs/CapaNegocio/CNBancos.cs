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
        public static string Insertar(int CatalogoID, string nombre, string sucursal, string direccion, string estado, string telefono, string correo, string oficialCuentas, string observaciones)
        {
            CDBancos objBanco = new CDBancos();
            // Preparamos los datos para insertar un nuevo Banco
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


        public static string Actualizar(int bancoID, string nombre, string sucursal, string direccion, string estado, string telefono, string correo, string oficialCuentas, string observaciones)
        {
            CDBancos objBanco = new CDBancos();
            objBanco.BancoID = bancoID;
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
            // Llamada al método estático ObtenerBancoPorID de la clase CNBancos
            DataTable dt = CNBancos.ObtenerBancoPorID(bancoID);

            // Retornamos el DataTable con los datos adquiridos
            return dt;
        }

        //public DataTable ObtenerBancoPorID(int bancoID)
        //{
        //    // Crear una instancia de CDBanco
        //    CDBancos objCDBanco = new CDBancos();

        //    // Crear un nuevo DataTable
        //    DataTable dt = new DataTable();

        //    // Llenar el DataTable con todos los datos devueltos por el método ObtenerBancoPorID
        //    dt = ObtenerBancoPorID(bancoID);

        //    // Retornar el DataTable con los datos adquiridos
        //    return dt;
        //}


    }
}