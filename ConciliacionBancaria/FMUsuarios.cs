using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CapaDatos;
using CapaNegocio;

namespace ConciliacionBancaria
{
    public partial class FMUsuarios : Form
    {


        // Variables globales
        public string mensaje = "";

        public FMUsuarios()
        {
            InitializeComponent();
            // Establecer la máscara de contraseña para textBoxContraseña
            textBoxcontraseña.PasswordChar = '●';
        }


        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Matenimiento Usuarios?", "Cerrar Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close(); // Cierra el formulario si el usuario confirma
            }


        }



        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FMBancos_Load(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            LimpiaObjetos();
        }

        private void Bsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void LimpiaObjetos()
        {
            textBoxcontraseña.Clear();
            textBoxcorreo.Clear();
            textBoxestado.SelectedIndex = -1;
            textBoxnombre.Clear();
            textBoxrol.SelectedIndex = -1;
            textBoxusuarioid.Clear();


        }


        private void HabilitaControles(bool valor)
        {
            textBoxusuarioid.ReadOnly = !valor;
            textBoxcontraseña.Enabled = valor;
            textBoxcorreo.Enabled = valor;
            textBoxestado.Enabled = valor;
            textBoxnombre.Enabled = valor;
            textBoxrol.Enabled = valor;
            textBoxcorreo.Enabled = valor;

            if (Program.nuevo)
                textBoxestado.SelectedIndex = 0;
            //textBoxcatalogoid.SelectedIndex = 0;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FMUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Mantenimiento Usuarios?", "Cerrar Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Bnuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
            Program.nuevo = true;
            Program.modificar = false;
            HabilitaBotones();
            textBoxnombre.Focus();

            //// Obtener el último ID insertado y asignarlo al textBoxbanco
            int ultimoIDInsertado = ObtenerUltimoIDInsertado("Usuarios");
            textBoxusuarioid.Text = (ultimoIDInsertado + 1).ToString();
        }

        private void Bguardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxusuarioid.Text))
            {
                MessageBox.Show("Debe indicar el ID de Usuario!");
                textBoxusuarioid.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxnombre.Text))
            {
                MessageBox.Show("Debe indicar el Nombre del Usuario!");
                textBoxnombre.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxcorreo.Text))
            {
                MessageBox.Show("Debe indicar el Correo del Usuario!");
                textBoxcorreo.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxrol.Text))
            {
                MessageBox.Show("Debe indicar el Rol del Usuario!");
                textBoxrol.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxcontraseña.Text))
            {
                MessageBox.Show("Debe indicar la Contraseña del Usuario!");
                textBoxcontraseña.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxestado.Text))
            {
                MessageBox.Show("Debe indicar el estado del Usuario!");
                textBoxestado.Focus();
                return;
            }

            string mensaje = "";

            if (Program.nuevo)
            {
                mensaje = CNUsuarios.Insertar(textBoxnombre.Text, textBoxcontraseña.Text, textBoxcorreo.Text, textBoxrol.Text,
                       textBoxestado.Text);




                int ultimoIDInsertado;
                if (int.TryParse(textBoxusuarioid.Text, out ultimoIDInsertado))
                {
                    if (ultimoIDInsertado > 0)
                    {
                        textBoxusuarioid.Text = ultimoIDInsertado.ToString();
                        textBoxusuarioid.Text = (ultimoIDInsertado + 1).ToString();
                    }
                    else
                    {

                        return;
                    }
                }





            }
            else
            {
                mensaje = CNUsuarios.Actualizar(Program.UsuarioID, textBoxnombre.Text, textBoxcontraseña.Text, textBoxcorreo.Text, textBoxrol.Text,
                   textBoxestado.Text);
            }

            MessageBox.Show(mensaje, "Mensaje de Conciliacion Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            LimpiaObjetos();

        }

        private void Bcancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            LimpiaObjetos();
        }

        private void Beditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxusuarioid.Text))
            {
                MessageBox.Show("Debe seleccionar un banco para modificar sus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.modificar = true;
            HabilitaBotones();
        }

        private void FMUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            BusquedaUsuarios BusquedaUsuarios = new BusquedaUsuarios();
            BusquedaUsuarios.ShowDialog();

            if (Program.modificar)
            {
                RecuperaDatos();
                Beditar_Click(sender, e);
            }
            else
            {
                LimpiaObjetos();
                Bbuscar.Focus();
            }
        }

        public void RecuperaDatos()
        {
            int usuarioID = Program.UsuarioID;

            DataTable dt = CNUsuarios.ObtenerUsuarioPorID(usuarioID,null);

            if (dt.Rows.Count > 0)
            {
             

                DataRow row = dt.Rows[0];
                textBoxusuarioid.Text = row["UsuarioID"].ToString();
                textBoxnombre.Text = row["NombreUsuario"].ToString(); // This line is likely causing the issue
                textBoxcorreo.Text = row["CorreoElectronico"].ToString();
                textBoxrol.Text = row["Rol"].ToString();
                textBoxestado.Text = row["Estado"].ToString();
                textBoxcontraseña.Text = row["ContraseñaHash"].ToString();
            }
            else
            {
                // Handle the case when no data is found for the provided ID
                // For example, display an error message or clear the fields
                // Here's an example of how to clear the fields:
                textBoxusuarioid.Text = "";
                textBoxnombre.Text = "";
                textBoxcorreo.Text = "";
                textBoxestado.Text = "";
                textBoxrol.Text = "";
                textBoxcontraseña.Text = "";
            }
        }

        private void ObtenerUltimoIDInsertado()
        {
            try
            {
                // Llamada al método con el nombre de la tabla "Bancos"
                int ultimoID = ObtenerUltimoIDInsertado("Usuarios");

                // Aquí puedes usar el último ID obtenido como desees, por ejemplo, mostrarlo en un MessageBox
                MessageBox.Show("Último ID insertado para la tabla 'Usuarios': " + ultimoID);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error al obtener el último ID insertado: " + ex.Message);
            }
        }

        public static int ObtenerUltimoIDInsertado(string tabla)
        {
            using (SqlConnection connection = CapaPresentacionConexion.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("ObtenerUltimoIDInsertado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Tabla", tabla);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }


        private void HabilitaBotones()
        {
            if (Program.nuevo || Program.modificar)
            {
                HabilitaControles(true);
                Bnuevo.Enabled = false;
                Bguardar.Enabled = true;
                Beditar.Enabled = false;
                Bbuscar.Enabled = false;
                Bcancelar.Enabled = true;
            }
            else
            {
                HabilitaControles(false);
                Bnuevo.Enabled = true;
                Bguardar.Enabled = false;
                Beditar.Enabled = false;
                Bbuscar.Enabled = true;
                Bcancelar.Enabled = false;
            }
        }



     
      
    
} }