using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciliacionBancaria
{
    class ClassReporteConciliacionBancaria
    {
        

        public string ConciliacionID { get; set; }
        public string CuentaID { get; set; }
        public string Fecha { get; set; }
        public string SaldoContable { get; set; }
        public string SaldoBancario { get; set; }
        public string Estado { get; set; }
        public string Diferencia { get; set; }

        public ClassReporteConciliacionBancaria(string v) { }
    }
}
