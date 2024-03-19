using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConciliacionBancaria
{
    public partial class FConciliacionBancariaPrueba : Form
    {
        public FConciliacionBancariaPrueba()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            bunifuPanelSubmenu.Visible = false;
            bunifuPanel1.Visible = false;
            bunifuPanel2.Visible = false;

            bunifuPanel5.Visible = false;
            bunifuPanel6.Visible = false;
            //no va ...
            bunifuPanel7.Visible = false;


        }

        private void HideSubMenu(Panel subMenu)
        {
            if (bunifuPanelSubmenu.Visible == true)
                bunifuPanelSubmenu.Visible = false;
            if (bunifuPanel1.Visible == true)
                bunifuPanel1.Visible = false;
            if (bunifuPanel2.Visible == true)
                bunifuPanel2.Visible = false;

            if (bunifuPanel5.Visible == true)
                bunifuPanel5.Visible = false;
            if (bunifuPanel6.Visible == true)
                bunifuPanel6.Visible = false;
        }

        private void showSubMenu(Panel bunifuPanelSubmenu)
        {
            if (bunifuPanelSubmenu.Visible == false)
            {
                hideSubMenu();
                bunifuPanelSubmenu.Visible = true;
            }
            else
                bunifuPanelSubmenu.Visible = false;
        }


        private void showPanel1(Panel bunifuPanel1)
        {
            if (bunifuPanel1.Visible == false)
            {
                hideSubMenu();
                bunifuPanel1.Visible = true;
            }
            else
                bunifuPanel1.Visible = false;
        }

        private void showPanel2(Panel bunifuPanel2)
        {
            if (bunifuPanel2.Visible == false)
            {
                hideSubMenu();
                bunifuPanel2.Visible = true;
            }
            else
                bunifuPanel2.Visible = false;
        }

        private void showPanel3(Panel bunifuPanel3)
        {
            if (bunifuPanel3.Visible == false)
            {
                hideSubMenu();
                bunifuPanel3.Visible = true;
            }
            else
                bunifuPanel3.Visible = false;
        }

        private void showPanel5(Panel bunifuPanel5)
        {
            if (bunifuPanel5.Visible == false)
            {
                hideSubMenu();
                bunifuPanel5.Visible = true;
            }
            else
                bunifuPanel5.Visible = false;
        }

        private void showPanel6(Panel bunifuPanel6)
        {
            if (bunifuPanel6.Visible == false)
            {
                hideSubMenu();
                bunifuPanel6.Visible = true;
            }
            else
                bunifuPanel6.Visible = false;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 250;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            //   showSubMenu(bunifuPanel5);
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void btnMantesicierto_Click(object sender, EventArgs e)
        {
            showSubMenu(bunifuPanelSubmenu);
        }

        private void btnBancos_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void BtnTransacciones_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(bunifuPanel2);
        }

        private void btnConciliacion_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            showSubMenu(bunifuPanel1);

        }

        private void btnCbanco_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCcuenta_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCtransaciones_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCusuarios_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCempresa_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCcatalogos_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnUtilidades_Click(object sender, EventArgs e)
        {
            showSubMenu(bunifuPanel5);
        }

        private void btnSeguridad_Click_1(object sender, EventArgs e)
        {
            showSubMenu(bunifuPanel6);
        }

        private void btnCopia_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCuentasdeusuario_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnAyuda_Click_1(object sender, EventArgs e)
        {
            showSubMenu(bunifuPanel7);
        }

        private void btnContenido_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnAcerca_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnReproductor_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Crear formulario de diálogo personalizado
            Form formularioDialogo = new Form();
            formularioDialogo.StartPosition = FormStartPosition.Manual;

            // Obtener la ubicación del botón en la pantalla
            Point buttonLocation = button2.PointToScreen(Point.Empty);

            // Ajustar la ubicación del formulario de diálogo para que aparezca al lado del botón
            formularioDialogo.Location = new Point(buttonLocation.X + button2.Width, buttonLocation.Y);

            formularioDialogo.FormBorderStyle = FormBorderStyle.None;
            formularioDialogo.BackColor = Color.WhiteSmoke;
            formularioDialogo.Size = new Size(233, 80);

            // Crear botón "Datos Generales"
            Button btnDatosGenerales = new Button();
            btnDatosGenerales.Text = "Datos Generales";
            btnDatosGenerales.Size = new Size(formularioDialogo.Width, 40);
            btnDatosGenerales.Location = new Point(0, 0);
            btnDatosGenerales.BackColor = Color.FromArgb(75, 177, 224);
            btnDatosGenerales.ForeColor = Color.White;
            btnDatosGenerales.FlatStyle = FlatStyle.Flat;
            btnDatosGenerales.FlatAppearance.BorderSize = 0;
            btnDatosGenerales.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDatosGenerales.MouseEnter += (s, args) => { btnDatosGenerales.BackColor = Color.FromArgb(45, 45, 48); };
            btnDatosGenerales.MouseLeave += (s, args) => { btnDatosGenerales.BackColor = Color.FromArgb(75, 177, 224); };
            btnDatosGenerales.Click += (s, args) =>
            {
                formularioDialogo.DialogResult = DialogResult.Yes;
                formularioDialogo.Close();
                // Llamar al formulario correspondiente
                MostrarFormularioDatosGenerales();
            };

            // Agregar hint al botón "Datos Generales"
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnDatosGenerales, "Visualizar e imprimir informaciones generales de los bancos y organizaciones");


            // Crear botón "Por Estado"
            Button btnPorEstado = new Button();
            btnPorEstado.Text = "Por Estado";
            btnPorEstado.Size = new Size(formularioDialogo.Width, 40);
            btnPorEstado.Location = new Point(0, 40);
            btnPorEstado.BackColor = Color.FromArgb(75, 177, 224);
            btnPorEstado.ForeColor = Color.White;
            btnPorEstado.FlatStyle = FlatStyle.Flat;
            btnPorEstado.FlatAppearance.BorderSize = 0;
            btnPorEstado.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnPorEstado.MouseEnter += (s, args) => { btnPorEstado.BackColor = Color.FromArgb(45, 45, 48); };
            btnPorEstado.MouseLeave += (s, args) => { btnPorEstado.BackColor = Color.FromArgb(75, 177, 224); };
            btnPorEstado.Click += (s, args) =>
            {
                formularioDialogo.DialogResult = DialogResult.No;
                formularioDialogo.Close();
                // Llamar al formulario correspondiente
                MostrarFormularioPorEstado();
            };

            // Agregar hint al botón "Por Estado"
            ToolTip toolTipPorEstado = new ToolTip();
            toolTipPorEstado.SetToolTip(btnPorEstado, "Visualizar e imprimir informaciones por estado de los bancos y organizaciones");

            // Agregar botones al formulario
            formularioDialogo.Controls.Add(btnDatosGenerales);
            formularioDialogo.Controls.Add(btnPorEstado);

            // Suscribirse al evento Click de los botones para cerrar el formulario
            btnDatosGenerales.Click += (s, args) => formularioDialogo.Close();
            btnPorEstado.Click += (s, args) => formularioDialogo.Close();

            // Mostrar el formulario
            formularioDialogo.Show();
        }

        private void MostrarFormularioDatosGenerales()
        {
            // Aquí puedes mostrar el formulario correspondiente a los datos generales
            FConciliacionBancaria formDatosGenerales = new FConciliacionBancaria();
            formDatosGenerales.Show();
        }

        private void MostrarFormularioPorEstado()
        {
            // Aquí puedes mostrar el formulario correspondiente al estado
            FConciliacionBancaria formPorEstado = new FConciliacionBancaria();
            formPorEstado.Show();
        }










        private void button3_Click(object sender, EventArgs e)
        {
            // Crear formulario de diálogo personalizado
            Form formularioDialogo = new Form();
            formularioDialogo.StartPosition = FormStartPosition.Manual;

            // Obtener la ubicación del botón en la pantalla
            Point buttonLocation = button3.PointToScreen(Point.Empty);

            // Ajustar la ubicación del formulario de diálogo para que aparezca al lado del botón
            formularioDialogo.Location = new Point(buttonLocation.X + button3.Width, buttonLocation.Y);

            formularioDialogo.FormBorderStyle = FormBorderStyle.None;
            formularioDialogo.BackColor = Color.WhiteSmoke;
            formularioDialogo.Size = new Size(233, 120); // Ajustar la altura para acomodar dos botones

            // Crear botón "Datos Generales"
            Button btnDatosGenerales = new Button();
            btnDatosGenerales.Text = "Datos Generales";
            btnDatosGenerales.Size = new Size(formularioDialogo.Width, 40);
            btnDatosGenerales.Location = new Point(0, 0);
            btnDatosGenerales.BackColor = Color.FromArgb(75, 177, 224);
            btnDatosGenerales.ForeColor = Color.White;
            btnDatosGenerales.FlatStyle = FlatStyle.Flat;
            btnDatosGenerales.FlatAppearance.BorderSize = 0;
            btnDatosGenerales.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDatosGenerales.MouseEnter += (s, args) => { btnDatosGenerales.BackColor = Color.FromArgb(45, 45, 48); };
            btnDatosGenerales.MouseLeave += (s, args) => { btnDatosGenerales.BackColor = Color.FromArgb(75, 177, 224); };
            btnDatosGenerales.Click += (s, args) =>
            {
                formularioDialogo.DialogResult = DialogResult.Yes;
                formularioDialogo.Close();
                // Llamar al formulario correspondiente
                MostrarFormularioDatosGenerales();
            };

            // Agregar hint al botón "Datos Generales"
            ToolTip toolTipDatosGenerales = new ToolTip();
            toolTipDatosGenerales.SetToolTip(btnDatosGenerales, "Visualizar e imprimir informaciones generales de cuentas bancarias");

            // Crear botón "Por Tipo"
            Button btnPorTipo = new Button();
            btnPorTipo.Text = "Por Tipo";
            btnPorTipo.Size = new Size(formularioDialogo.Width, 40);
            btnPorTipo.Location = new Point(0, 40);
            btnPorTipo.BackColor = Color.FromArgb(75, 177, 224);
            btnPorTipo.ForeColor = Color.White;
            btnPorTipo.FlatStyle = FlatStyle.Flat;
            btnPorTipo.FlatAppearance.BorderSize = 0;
            btnPorTipo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnPorTipo.MouseEnter += (s, args) => { btnPorTipo.BackColor = Color.FromArgb(45, 45, 48); };
            btnPorTipo.MouseLeave += (s, args) => { btnPorTipo.BackColor = Color.FromArgb(75, 177, 224); };
            btnPorTipo.Click += (s, args) =>
            {
                formularioDialogo.DialogResult = DialogResult.No;
                formularioDialogo.Close();
                // Llamar al formulario correspondiente
                MostrarFormularioPorTipo();
            };

            // Agregar hint al botón "Por Tipo"
            ToolTip toolTipPorTipo = new ToolTip();
            toolTipPorTipo.SetToolTip(btnPorTipo, "Visualizar e imprimir informaciones de cuentas bancarias por tipo");

            // Agregar botones al formulario
            formularioDialogo.Controls.Add(btnDatosGenerales);
            formularioDialogo.Controls.Add(btnPorTipo);

            // Suscribirse al evento Click de los botones para cerrar el formulario
            btnDatosGenerales.Click += (s, args) => formularioDialogo.Close();
            btnPorTipo.Click += (s, args) => formularioDialogo.Close();

            // Mostrar el formulario
            formularioDialogo.Show();
        }

        private void MostrarFormularioDatosGenerales1()
        {
            // Aquí puedes mostrar el formulario correspondiente a los datos generales
            // Por ejemplo:
            FConciliacionBancaria formDatosGenerales = new FConciliacionBancaria();
            formDatosGenerales.Show();
        }

        private void MostrarFormularioPorTipo()
        {
            // Aquí puedes mostrar el formulario correspondiente al tipo
            // Por ejemplo:
            FConciliacionBancaria formPorTipo = new FConciliacionBancaria();
            formPorTipo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Crear formulario de diálogo personalizado
            Form formularioDialogo = new Form();
            formularioDialogo.StartPosition = FormStartPosition.Manual;

            // Obtener la ubicación del botón en la pantalla
            Point buttonLocation = button4.PointToScreen(Point.Empty);

            // Ajustar la ubicación del formulario de diálogo para que aparezca al lado del botón
            formularioDialogo.Location = new Point(buttonLocation.X + button4.Width, buttonLocation.Y);

            formularioDialogo.FormBorderStyle = FormBorderStyle.None;
            formularioDialogo.BackColor = Color.WhiteSmoke;
            formularioDialogo.Size = new Size(233, 200); // Ajustar la altura para acomodar los botones

            // Crear botones
            string[] nombresBotones = { "Datos Generales", "Por Tipo", "Por Usuario", "Por Fecha", "Por Cuenta Bancaria" };
            string[] hints = {
        "Visualizar e imprimir informaciones generales de las transacciones internas",
        "Visualizar e imprimir informaciones de transacciones internas por tipo",
        "Visualizar e imprimir informaciones de transacciones internas por usuario",
        "Visualizar e imprimir informaciones de transacciones internas por fecha",
        "Visualizar e imprimir informaciones de transacciones internas por cuenta bancaria"
    };

            for (int i = 0; i < nombresBotones.Length; i++)
            {
                Button btn = new Button();
                btn.Text = nombresBotones[i];
                btn.Size = new Size(formularioDialogo.Width, 40);
                btn.Location = new Point(0, i * 40);
                btn.BackColor = Color.FromArgb(75, 177, 224);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.MouseEnter += (s, args) => { btn.BackColor = Color.FromArgb(45, 45, 48); };
                btn.MouseLeave += (s, args) => { btn.BackColor = Color.FromArgb(75, 177, 224); };

                // Agregar hint al botón
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(btn, hints[i]);

                // Agregar evento Click
                int index = i; // Capturar el valor actual de i para usarlo en el cierre del formulario
                btn.Click += (s, args) =>
                {
                    formularioDialogo.DialogResult = DialogResult.Yes;
                    formularioDialogo.Close();
                    // Llamar al formulario correspondiente
                    MostrarFormulario(nombresBotones[index]);
                };

                // Agregar botón al formulario
                formularioDialogo.Controls.Add(btn);
            }

            // Suscribirse al evento Click de los botones para cerrar el formulario
            foreach (Control control in formularioDialogo.Controls)
            {
                if (control is Button)
                {
                    control.Click += (s, args) => formularioDialogo.Close();
                }
            }

            // Mostrar el formulario
            formularioDialogo.Show();
        }

        private void MostrarFormulario(string nombreFormulario)
        {
            // Aquí puedes mostrar el formulario correspondiente según el nombre recibido
            // Por ejemplo:
            switch (nombreFormulario)
            {
                case "Datos Generales":
                    FConciliacionBancaria formDatosGenerales = new FConciliacionBancaria();
                    formDatosGenerales.Show();
                    break;
                case "Por Tipo":
                    FConciliacionBancaria formPorTipo = new FConciliacionBancaria();
                    formPorTipo.Show();
                    break;
                case "Por Usuario":
                    FConciliacionBancaria formPorUsuario = new FConciliacionBancaria();
                    formPorUsuario.Show();
                    break;
                case "Por Fecha":
                    FConciliacionBancaria formPorFecha = new FConciliacionBancaria();
                    formPorFecha.Show();
                    break;
                case "Por Cuenta Bancaria":
                    FConciliacionBancaria formPorCuentaBancaria = new FConciliacionBancaria();
                    formPorCuentaBancaria.Show();
                    break;
                default:
                    break;
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
