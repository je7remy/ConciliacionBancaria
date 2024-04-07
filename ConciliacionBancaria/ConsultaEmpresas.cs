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
    public partial class ConsultaEmpresas : Form
    {


        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";



        public ConsultaEmpresas()
        {
            InitializeComponent();
          
        }

        private void BusquedaBancos_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.EmpresaID = 0; //variable global que tomará el valor seleccionado
            MostrarDatos(); //Llamo al Método que llena el DataGrid
            Tbuscar.Focus(); //El TextBox Buscar recibe el cursor
        }

        private void BusquedaBancos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar la Consulta Empresas?", "Cerrar Consulta Empresas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            //if (DGVDatos.CurrentRow != null) //Si el DataGridView no está vacío
            //{
                
            //    Program.modificar = true;
            //    Program.EmpresaID = Convert.ToInt32(DGVDatos.CurrentRow.Cells[0].Value);
               
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
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tbuscar.Text.Trim())) // Si se introdujo un dato en el textbox
            {
                vtieneparametro = 1; // Se indica que se trabajará con parámetros

                // Verificar si el valor de búsqueda es un número
                if (int.TryParse(Tbuscar.Text.Trim(), out int EmpresaID))
                {
                    valorparametro = Tbuscar.Text.Trim();
                    MostrarDatos1(EmpresaID, null); // Pasar null para indicar que no se busca por Nombre
                }
                else // Si no es un número, se asume que es el nombre de la empresa
                {
                    valorparametro = Tbuscar.Text.Trim();
                    MostrarDatos1(null, valorparametro); // Pasa null para indicar que no se busca por ID
                }
            }
            else // Si el textbox está vacío
            {
                vtieneparametro = 0; // Se indica que no se trabajarán con parámetros
                valorparametro = ""; // Se vuelve vacía la variable del parámetro
                MostrarDatos(); // Se llama al método MostrarDatos
            }

            Tbuscar.Focus(); // Se le pasa el cursor al textbox
        }

        private void Tbuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tbuscar.Text.Trim())) // Si se introdujo un dato en el textbox
            {
                vtieneparametro = 1; // Se indica que se trabajará con parámetros

                // Verificar si el valor de búsqueda es un número
                if (int.TryParse(Tbuscar.Text.Trim(), out int EmpresaID))
                {
                    valorparametro = Tbuscar.Text.Trim();
                    MostrarDatos1(EmpresaID, null); // Pasar null para indicar que no se busca por Nombre
                }
                else // Si no es un número, se asume que es el nombre de la empresa
                {
                    valorparametro = Tbuscar.Text.Trim();
                    MostrarDatos1(null, valorparametro); // Pasa null para indicar que no se busca por ID
                }
            }
            else // Si el textbox está vacío
            {
                vtieneparametro = 0; // Se indica que no se trabajarán con parámetros
                valorparametro = ""; // Se vuelve vacía la variable del parámetro
                MostrarDatos();
            }
        }

        private void MostrarDatos1(int? EmpresaID, string NombreEmpresa)
        {
            DataTable dt = CNEmpresas.ObtenerEmpresaPorID(EmpresaID, NombreEmpresa);

            if (dt != null && dt.Rows.Count > 0)
            {
                DGVDatos.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No se encontraron empresas."); // Mensaje si no se encontraron resultados
            }
        }




        private void MostrarDatos()
        {
            valorparametro = Tbuscar.Text.Trim();
            //string valorparametro = Tbuscar.Text.Trim();
            DataTable dt = CNEmpresas.ObtenerEmpresa(); // Acceder al método estático

            if (dt != null && dt.Rows.Count > 0)
            {
                DGVDatos.DataSource = dt;

                DGVDatos.Columns[0].Width = 30;  
                DGVDatos.Columns[1].Width = 30;  
                DGVDatos.Columns[2].Width = 80;
                DGVDatos.Columns[3].Width = 80; 
                DGVDatos.Columns[4].Width = 100; 
                DGVDatos.Columns[5].Width = 30; 
               
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
