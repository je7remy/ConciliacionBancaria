using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using CapaDatos;

namespace ConciliacionBancaria
{
    public partial class ReporteConciliacionBancaria : Form
    {
        public ReporteConciliacionBancaria()
        {
            InitializeComponent();
        }
private void ReporteConciliacionBancaria_Load(object sender, EventArgs e)
{
    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                AttachDbFilename=C:\c#\ConciliacionBancaria\CapaDatos\ConciliacionBancaria.mdf;
                                Integrated Security=True;Pooling=true";

    string consulta = "SELECT * FROM ConciliacionBancaria";

    DataTable dt = new DataTable();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(consulta, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        dt.Load(reader);
    }

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ClassReporteConciliacionBancaria", dt));
            this.reportViewer1.RefreshReport();
}
    }
}