using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConciliacionBancaria
{
    static class Program
    {


        //Program.variable donde se necesiten
        public static int BancoID =0;
        public static int CatalogoID = 0;
        public static int ConciliacionID = 0;
        public static int CuentaID = 0;
        public static int EmpresaID = 0;
        public static int TransaccionBancariaID = 0;
        public static int TransaccionID = 0;
        public static int UsuarioID = 0;

          //variables que tomarán el valor de la clave 
         //primaria de la tabla correspondiente
        //colocar una por cada clave primaria que tengamos 
                                        //en nuestra base de datos 
        public static bool nuevo = false; //variable usada para identificar si se trabaja con 
                                          //un nuevo dato o no
        public static bool modificar = false; //variable usada para identificar si se está
                                             //modificando un dato o no
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FConciliacionBancariaPrueba());
        }
    }
}
