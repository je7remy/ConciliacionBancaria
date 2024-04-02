using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Agregamos lo siguiente para utilizar SQL
using System.Data.SqlClient;
using System.Data.SqlTypes;

using CapaNegocio;
namespace ConciliacionBancaria
{
    public partial class FConciliacionBancaria : Form
    {
        public FConciliacionBancaria()
        {
            InitializeComponent();
        }

        private void Conciliacion_Bancaria_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           statusStrip1.Items[1].Text = "Fecha/Hora: " + DateTime.Now.ToString();
        }
    }
}
