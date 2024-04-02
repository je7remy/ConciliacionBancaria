using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;


namespace CapaDatos
{
    public class CapaPresentacionConexion
    {
        // Define la cadena de conexión a la base de datos
        public static string miconexion = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                            Integrated Security=True;Pooling=true";

        // Método para obtener una conexión a la base de datos
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection sqlCon = new SqlConnection(miconexion);
            return sqlCon;
        }
    }
}
