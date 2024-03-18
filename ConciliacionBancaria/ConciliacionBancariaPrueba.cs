using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
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
    }
}
