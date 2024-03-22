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
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar el Menu Principal?", "Cerrar Conciliacion Bancaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close(); // Cierra el formulario si el usuario confirma
            }


        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                iconrestaurar.Visible = true;
                iconmaximizar.Visible = false;
            }
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal;
                iconrestaurar.Visible = false;
                iconmaximizar.Visible = true;
            }
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
            // Instanciar el formulario FMBancos
            FMBancos formularioFMBancos = new FMBancos();

            // Mostrar el formulario
            formularioFMBancos.Show();
            hideSubMenu();
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            // Instanciar el formulario FMBancos
            FMCuentas_Bancarias formularioFMCuentas_Bancarias = new FMCuentas_Bancarias();

            // Mostrar el formulario
            formularioFMCuentas_Bancarias.Show();
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

            formularioDialogo.Deactivate += (s, args) =>
            {
                formularioDialogo.Close();
                formularioDialogo.Dispose(); // Liberar recursos
            };

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
            formularioDialogo.Size = new Size(233, 80); // Ajustar la altura para acomodar dos botones

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

            formularioDialogo.Deactivate += (s, args) =>
            {
                formularioDialogo.Close();
                formularioDialogo.Dispose(); // Liberar recursos
            };

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

            formularioDialogo.Deactivate += (s, args) =>
            {
                formularioDialogo.Close();
                formularioDialogo.Dispose(); // Liberar recursos
            };

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
            // Crear formulario de diálogo personalizado
            Form formularioDialogo = new Form();
            formularioDialogo.StartPosition = FormStartPosition.Manual;

            // Obtener la ubicación del botón en la pantalla
            Point buttonLocation = button5.PointToScreen(Point.Empty);

            // Ajustar la ubicación del formulario de diálogo para que aparezca al lado del botón
            formularioDialogo.Location = new Point(buttonLocation.X + button5.Width, buttonLocation.Y);

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
                MostrarFormularioDatosGenerales1();
            };

            // Agregar hint al botón "Datos Generales"
            ToolTip toolTipDatosGenerales = new ToolTip();
            toolTipDatosGenerales.SetToolTip(btnDatosGenerales, "Visualizar e imprimir informaciones generales de los usuarios");


            // Crear botón "Por Rol"
            Button btnPorRol = new Button();
            btnPorRol.Text = "Por Rol";
            btnPorRol.Size = new Size(formularioDialogo.Width, 40);
            btnPorRol.Location = new Point(0, 40);
            btnPorRol.BackColor = Color.FromArgb(75, 177, 224);
            btnPorRol.ForeColor = Color.White;
            btnPorRol.FlatStyle = FlatStyle.Flat;
            btnPorRol.FlatAppearance.BorderSize = 0;
            btnPorRol.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnPorRol.MouseEnter += (s, args) => { btnPorRol.BackColor = Color.FromArgb(45, 45, 48); };
            btnPorRol.MouseLeave += (s, args) => { btnPorRol.BackColor = Color.FromArgb(75, 177, 224); };
            btnPorRol.Click += (s, args) =>
            {
                formularioDialogo.DialogResult = DialogResult.No;
                formularioDialogo.Close();
                // Llamar al formulario correspondiente
                MostrarFormularioPorRol();
            };

            // Agregar hint al botón "Por Rol"
            ToolTip toolTipPorRol = new ToolTip();
            toolTipPorRol.SetToolTip(btnPorRol, "Visualizar e imprimir informaciones de los usuarios por rol");

            // Agregar botones al formulario
            formularioDialogo.Controls.Add(btnDatosGenerales);
            formularioDialogo.Controls.Add(btnPorRol);


            formularioDialogo.Deactivate += (s, args) =>
            {
                formularioDialogo.Close();
                formularioDialogo.Dispose(); // Liberar recursos
            };


            // Suscribirse al evento Click de los botones para cerrar el formulario
            btnDatosGenerales.Click += (s, args) => formularioDialogo.Close();
            btnPorRol.Click += (s, args) => formularioDialogo.Close();

            // Mostrar el formulario
            formularioDialogo.Show();
        }

        private void MostrarFormularioDatosGenerales2()
        {
            // Aquí puedes mostrar el formulario correspondiente a los datos generales
            FConciliacionBancaria formDatosGenerales = new FConciliacionBancaria();
            formDatosGenerales.Show();
        }

        private void MostrarFormularioPorRol()
        {
            // Aquí puedes mostrar el formulario correspondiente al estado
            FConciliacionBancaria formPorRol = new FConciliacionBancaria();
            formPorRol.Show();
        }
    

        private void button6_Click(object sender, EventArgs e)
        { // Crear formulario de diálogo personalizado
            Form formularioDialogo = new Form();
            formularioDialogo.StartPosition = FormStartPosition.Manual;

            // Obtener la ubicación del botón en la pantalla
            Point buttonLocation = button6.PointToScreen(Point.Empty);

            // Ajustar la ubicación del formulario de diálogo para que aparezca al lado del botón
            formularioDialogo.Location = new Point(buttonLocation.X + button6.Width, buttonLocation.Y);

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
            ToolTip toolTipDatosGenerales = new ToolTip();
            toolTipDatosGenerales.SetToolTip(btnDatosGenerales, "Visualizar e imprimir informaciones generales de las empresas");


            // Crear botón "Por Ubicación"
            Button btnPorUbicacion = new Button();
            btnPorUbicacion.Text = "Por Ubicación";
            btnPorUbicacion.Size = new Size(formularioDialogo.Width, 40);
            btnPorUbicacion.Location = new Point(0, 40);
            btnPorUbicacion.BackColor = Color.FromArgb(75, 177, 224);
            btnPorUbicacion.ForeColor = Color.White;
            btnPorUbicacion.FlatStyle = FlatStyle.Flat;
            btnPorUbicacion.FlatAppearance.BorderSize = 0;
            btnPorUbicacion.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnPorUbicacion.MouseEnter += (s, args) => { btnPorUbicacion.BackColor = Color.FromArgb(45, 45, 48); };
            btnPorUbicacion.MouseLeave += (s, args) => { btnPorUbicacion.BackColor = Color.FromArgb(75, 177, 224); };
            btnPorUbicacion.Click += (s, args) =>
            {
                formularioDialogo.DialogResult = DialogResult.No;
                formularioDialogo.Close();
                // Llamar al formulario correspondiente
                MostrarFormularioPorUbicacion();
            };

            // Agregar hint al botón "Por Ubicación"
            ToolTip toolTipPorUbicacion = new ToolTip();
            toolTipPorUbicacion.SetToolTip(btnPorUbicacion, "Visualizar e imprimir informaciones de las empresas por ubicación");

            // Agregar botones al formulario
            formularioDialogo.Controls.Add(btnDatosGenerales);
            formularioDialogo.Controls.Add(btnPorUbicacion);


            formularioDialogo.Deactivate += (s, args) =>
            {
                formularioDialogo.Close();
                formularioDialogo.Dispose(); // Liberar recursos
            };

            // Suscribirse al evento Click de los botones para cerrar el formulario
            btnDatosGenerales.Click += (s, args) => formularioDialogo.Close();
            btnPorUbicacion.Click += (s, args) => formularioDialogo.Close();

            // Mostrar el formulario
            formularioDialogo.Show();
        }

        private void MostrarFormularioDatosGenerale()
        {
            // Aquí puedes mostrar el formulario correspondiente a los datos generales
            FConciliacionBancaria formDatosGenerales = new FConciliacionBancaria();
            formDatosGenerales.Show();
        }

        private void MostrarFormularioPorUbicacion()
        {
            // Aquí puedes mostrar el formulario correspondiente a la ubicación
            FConciliacionBancaria formPorUbicacion = new FConciliacionBancaria();
            formPorUbicacion.Show();
        }
    

        private void button7_Click(object sender, EventArgs e)
        {
            // Crear formulario de diálogo personalizado
            Form formularioDialogo = new Form();
            formularioDialogo.StartPosition = FormStartPosition.Manual;

            // Obtener la ubicación del botón en la pantalla
            Point buttonLocation = button7.PointToScreen(Point.Empty);

            // Ajustar la ubicación del formulario de diálogo para que aparezca al lado del botón
            formularioDialogo.Location = new Point(buttonLocation.X + button7.Width, buttonLocation.Y);

            formularioDialogo.FormBorderStyle = FormBorderStyle.None;
            formularioDialogo.BackColor = Color.WhiteSmoke;
            formularioDialogo.Size = new Size(233, 120);

            // Crear botón "Reporte de Conciliación Bancaria"
            Button btnReporteConciliacion = new Button();
            btnReporteConciliacion.Text = "Reporte de Conciliación Bancaria";
            btnReporteConciliacion.Size = new Size(formularioDialogo.Width, 40);
            btnReporteConciliacion.Location = new Point(0, 0);
            btnReporteConciliacion.BackColor = Color.FromArgb(75, 177, 224);
            btnReporteConciliacion.ForeColor = Color.White;
            btnReporteConciliacion.FlatStyle = FlatStyle.Flat;
            btnReporteConciliacion.FlatAppearance.BorderSize = 0;
            btnReporteConciliacion.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReporteConciliacion.MouseEnter += (s, args) => { btnReporteConciliacion.BackColor = Color.FromArgb(45, 45, 48); };
            btnReporteConciliacion.MouseLeave += (s, args) => { btnReporteConciliacion.BackColor = Color.FromArgb(75, 177, 224); };
            btnReporteConciliacion.Click += (s, args) =>
            {
                formularioDialogo.DialogResult = DialogResult.Yes;
                formularioDialogo.Close();
                // Llamar al formulario correspondiente
                MostrarFormularioConciliacionBancaria();
            };

            // Agregar hint al botón "Reporte de Conciliación Bancaria"
            ToolTip toolTipReporteConciliacion = new ToolTip();
            toolTipReporteConciliacion.SetToolTip(btnReporteConciliacion, "Visualizar e imprimir informaciones generales de las conciliaciones bancarias");


            // Crear botón "Reporte de Transacciones no Conciliadas"
            Button btnReporteTransacciones = new Button();
            btnReporteTransacciones.Text = "Reporte de Transacciones no Conciliadas";
            btnReporteTransacciones.Size = new Size(formularioDialogo.Width, 40);
            btnReporteTransacciones.Location = new Point(0, 40);
            btnReporteTransacciones.BackColor = Color.FromArgb(75, 177, 224);
            btnReporteTransacciones.ForeColor = Color.White;
            btnReporteTransacciones.FlatStyle = FlatStyle.Flat;
            btnReporteTransacciones.FlatAppearance.BorderSize = 0;
            btnReporteTransacciones.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReporteTransacciones.MouseEnter += (s, args) => { btnReporteTransacciones.BackColor = Color.FromArgb(45, 45, 48); };
            btnReporteTransacciones.MouseLeave += (s, args) => { btnReporteTransacciones.BackColor = Color.FromArgb(75, 177, 224); };
            btnReporteTransacciones.Click += (s, args) =>
            {
                formularioDialogo.DialogResult = DialogResult.No;
                formularioDialogo.Close();
                // Llamar al formulario correspondiente
                MostrarFormularioTransaccionesNoConciliadas();
            };

            // Agregar hint al botón "Reporte de Transacciones no Conciliadas"
            ToolTip toolTipReporteTransacciones = new ToolTip();
            toolTipReporteTransacciones.SetToolTip(btnReporteTransacciones, "Visualizar e imprimir informaciones de las conciliaciones bancarias no conciliadas");

            // Crear botón "Reporte de Discrepancias"
            Button btnReporteDiscrepancias = new Button();
            btnReporteDiscrepancias.Text = "Reporte de Discrepancias";
            btnReporteDiscrepancias.Size = new Size(formularioDialogo.Width, 40);
            btnReporteDiscrepancias.Location = new Point(0, 80);
            btnReporteDiscrepancias.BackColor = Color.FromArgb(75, 177, 224);
            btnReporteDiscrepancias.ForeColor = Color.White;
            btnReporteDiscrepancias.FlatStyle = FlatStyle.Flat;
            btnReporteDiscrepancias.FlatAppearance.BorderSize = 0;
            btnReporteDiscrepancias.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReporteDiscrepancias.MouseEnter += (s, args) => { btnReporteDiscrepancias.BackColor = Color.FromArgb(45, 45, 48); };
            btnReporteDiscrepancias.MouseLeave += (s, args) => { btnReporteDiscrepancias.BackColor = Color.FromArgb(75, 177, 224); };
            btnReporteDiscrepancias.Click += (s, args) =>
            {
                formularioDialogo.DialogResult = DialogResult.Cancel;
                formularioDialogo.Close();
                // Llamar al formulario correspondiente
                MostrarFormularioDiscrepancias();
            };

            // Agregar hint al botón "Reporte de Discrepancias"
            ToolTip toolTipReporteDiscrepancias = new ToolTip();
            toolTipReporteDiscrepancias.SetToolTip(btnReporteDiscrepancias, "Visualizar e imprimir informaciones generales de las discrepancias en las conciliaciones bancarias");

            // Agregar botones al formulario
            formularioDialogo.Controls.Add(btnReporteConciliacion);
            formularioDialogo.Controls.Add(btnReporteTransacciones);
            formularioDialogo.Controls.Add(btnReporteDiscrepancias);

            formularioDialogo.Deactivate += (s, args) =>
            {
                formularioDialogo.Close();
                formularioDialogo.Dispose(); // Liberar recursos
            };

            // Suscribirse al evento Click de los botones para cerrar el formulario
            btnReporteConciliacion.Click += (s, args) => formularioDialogo.Close();
            btnReporteTransacciones.Click += (s, args) => formularioDialogo.Close();
            btnReporteDiscrepancias.Click += (s, args) => formularioDialogo.Close();

            // Mostrar el formulario
            formularioDialogo.Show();
        }

        private void MostrarFormularioConciliacionBancaria()
        {
            // Aquí puedes mostrar el formulario correspondiente a la conciliación bancaria
            FConciliacionBancaria formConciliacion = new FConciliacionBancaria();
            formConciliacion.Show();
        }

        private void MostrarFormularioTransaccionesNoConciliadas()
        {
            // Aquí puedes mostrar el formulario correspondiente a las transacciones no conciliadas
            FConciliacionBancaria formTransacciones = new FConciliacionBancaria();
            formTransacciones.Show();
        }

        private void MostrarFormularioDiscrepancias()
        {
            // Aquí puedes mostrar el formulario correspondiente a las discrepancias
            FConciliacionBancaria formDiscrepancias = new FConciliacionBancaria();
            formDiscrepancias.Show();
        }

    

    private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
