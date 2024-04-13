using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace ConciliacionBancaria
{
    public partial class ConsultaFMCB : Form
    {


        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";



        public ConsultaFMCB()
        {
            InitializeComponent();
         
        }

        private void BusquedaBancos_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.BancoID = 0; //variable global que tomará el valor seleccionado
            MostrarDatos(); //Llamo al Método que llena el DataGrid
            //Tbuscar.Focus(); //El TextBox Buscar recibe el cursor
        }

        private void BusquedaBancos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar la Consulta General de Conciliacion?", "Cerrar Consulta General de Conciliacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BusquedaBancos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void DGVDatos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (DGVDatos.CurrentRow != null) //Si el DataGridView no está vacío
                indice = DGVDatos.CurrentRow.Index; //El valor de índice será la fila actual
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            //Program.modificar = false; //variable global a toda la solución
            //Close(); //Se cierra el formulario
           
            ReporteConciliacionBancaria ReporteConciliacionBancaria = new ReporteConciliacionBancaria();
            ReporteConciliacionBancaria.ShowDialog();
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            //if (DGVDatos.CurrentRow != null) //Si el DataGridView no está vacío
            //{
                
            //    Program.modificar = true;
            //    Program.BancoID = Convert.ToInt32(DGVDatos.CurrentRow.Cells[0].Value);
               
            //}
            this.Close();


        }

        private void BPrimero_Click(object sender, EventArgs e)
        {
            if (DGVDatos.Rows.Count > 1) //Si no estamos al inicio del DataGridView, vamos al inicio
            {
                indice = 0;
                DGVDatos.CurrentCell = DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void BAnterior_Click(object sender, EventArgs e)
        {
            if (indice > 0) //Si no estamos al inicio del DataGridView, retrocedemos 1 fila
            {
                indice = indice - 1;
                DGVDatos.CurrentCell =
                DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void BSiguiente_Click(object sender, EventArgs e)
        {
            if (indice < this.DGVDatos.RowCount - 1) //Si no estamos al final del DataGridView, avanzamos 1 fila
            {
                indice++;
                DGVDatos.CurrentCell =
               DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void BUltimo_Click(object sender, EventArgs e)
        {
            if (indice < this.DGVDatos.RowCount - 1) //Si no estamos al final del DataGridView
            {
                indice = DGVDatos.Rows.Count - 2; //vamos a la última fila del DataGridView
                DGVDatos.CurrentCell =
               DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ////si se pulsa en el encabezado, RowIndex será menor que cero y no se hará nada
            //if (!(e.RowIndex > -1))
            //{
            //    return;
            //}
            //BAceptar_Click(sender, e); //Se ejecuta el método del botón Aceptar

            //if (e.RowIndex > -1)
            //{
            //    if (int.TryParse(DGVDatos.Rows[e.RowIndex].Cells["BancoID"].Value.ToString(), out int valor))
            //    {
            //        Program.modificar = true;
            //        Program.BancoID= valor;
            //    }
            //    Close();
            //}

        }





        private void MostrarDatos1()
        {
            if (int.TryParse(valorparametro, out int Conciliacion))
            {
                DataTable dt = CNConciliacionBancaria.ObtenerConciliacionBancariaPorID( valorparametro, Conciliacion);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DGVDatos.DataSource = dt;

                }
            }
            else
            {
                MessageBox.Show("Solo Numeros!");
            }
        }

        private void btncargarporfecha_Click(object sender, EventArgs e)
        {
            //if (fechainicio.Value > fechafinal.Value )
            //{
            //    MessageBox.Show("si es mayor");
            //    fechainicio.Focus();
            //}
            //else
            //{

            //crear procedimiento almacenado que consulte por rango de fechas
            //  }

            // Verificar si la fecha de inicio es mayor que la fecha final
            if (fechainicio.Value > fechafinal.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.");
                fechainicio.Focus();
            }
            else
            {
                try
                {
                    // Obtener los datos de conciliación bancaria por el rango de fechas
                    DataTable dtConciliacion = CNConciliacionBancaria.ObtenerConciliacionBancariaPorFecha(fechainicio.Value, fechafinal.Value);

                    // Mostrar los datos en el DataGridView o en el control que estés utilizando para mostrar la información
                    // Por ejemplo, si tienes un DataGridView llamado dgvConciliacionBancaria:
                    DGVDatos.DataSource = dtConciliacion;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos de conciliación bancaria: " + ex.Message);
                }
            }
        



        }



        //private void btncargarporfecha_Click(object sender, EventArgs e)
        //{
        //    // Verificar si la fecha de inicio es mayor que la fecha final
        //    if (fechainicio.Value > fechafinal.Value)
        //    {
        //        MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.");
        //        fechainicio.Focus();
        //    }
        //    else
        //    {
        //        try
        //        {
        //            // Obtener los datos de conciliación bancaria por el rango de fechas
        //            DataTable dtConciliacion = NegocioConciliacionBancaria.ObtenerConciliacionBancariaPorFecha(fechainicio.Value, fechafinal.Value);

        //            // Mostrar los datos en el DataGridView o en el control que estés utilizando para mostrar la información
        //            // Por ejemplo, si tienes un DataGridView llamado dgvConciliacionBancaria:
        //            dgvConciliacionBancaria.DataSource = dtConciliacion;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error al cargar los datos de conciliación bancaria: " + ex.Message);
        //        }
        //    }
        //}


        private void MostrarDatos()
        {
          //  valorparametro = Tbuscar.Text.Trim();
            //string valorparametro = Tbuscar.Text.Trim();
            DataTable dt = CNConciliacionBancaria.ObtenerConciliacion(); // Acceder al método estático

            if (dt != null && dt.Rows.Count > 0)
            {
                DGVDatos.DataSource = dt;

                DGVDatos.Columns[0].Width = 30;  
                DGVDatos.Columns[1].Width = 30;  
                DGVDatos.Columns[2].Width = 100; 
                DGVDatos.Columns[3].Width = 120; 
                DGVDatos.Columns[4].Width = 100; 
                DGVDatos.Columns[5].Width = 60;
                DGVDatos.Columns[6].Width = 80; 
               
            }
            else
            {
                // Manejar el caso en el que el DataTable esté vacío
            }
            DGVDatos.Refresh(); //Se refresca el DataGridView
            LCantMov.Text = Convert.ToString(DGVDatos.RowCount - 1); //Se muestra la cantidad de datos
            if (DGVDatos.RowCount <= 0) //Si no se obtienen datos de retorno
            {
                MessageBox.Show("Ningún dato que mostrar!"); //Se muestra un mensaje de error
            }
        }
    }
}
