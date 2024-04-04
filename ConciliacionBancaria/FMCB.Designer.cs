
namespace ConciliacionBancaria
{
    partial class FMCB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMCB));
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Pbotones = new System.Windows.Forms.Panel();
            this.Bsalir = new System.Windows.Forms.Button();
            this.Bcancelar = new System.Windows.Forms.Button();
            this.Bguardar = new System.Windows.Forms.Button();
            this.btncargarsaldobancario = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxcuentaid = new System.Windows.Forms.ComboBox();
            this.textBoxsaldocontable = new System.Windows.Forms.TextBox();
            this.textBoxfechadeapertura = new System.Windows.Forms.DateTimePicker();
            this.textBoxbancoid = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxsaldobancario = new System.Windows.Forms.TextBox();
            this.btnregistrarconciliacion = new System.Windows.Forms.Button();
            this.btncalcularsaldocontable = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btncalcularsaldo = new System.Windows.Forms.Button();
            this.BarraTitulo.SuspendLayout();
            this.Pbotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BarraTitulo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BarraTitulo.BackgroundImage")));
            this.BarraTitulo.Controls.Add(this.bunifuCustomLabel1);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1742, 45);
            this.BarraTitulo.TabIndex = 4;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(169)))), ((int)(((byte)(214)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(500, 3);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(428, 39);
            this.bunifuCustomLabel1.TabIndex = 5;
            this.bunifuCustomLabel1.Text = "Conciliacion Bancaria";
            // 
            // Pbotones
            // 
            this.Pbotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(169)))), ((int)(((byte)(214)))));
            this.Pbotones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pbotones.Controls.Add(this.Bsalir);
            this.Pbotones.Controls.Add(this.Bcancelar);
            this.Pbotones.Controls.Add(this.Bguardar);
            this.Pbotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pbotones.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pbotones.Location = new System.Drawing.Point(0, 632);
            this.Pbotones.Name = "Pbotones";
            this.Pbotones.Size = new System.Drawing.Size(1742, 100);
            this.Pbotones.TabIndex = 35;
            // 
            // Bsalir
            // 
            this.Bsalir.BackColor = System.Drawing.SystemColors.Window;
            this.Bsalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bsalir.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.Bsalir.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.Bsalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.Bsalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.Bsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bsalir.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bsalir.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Bsalir.Image = ((System.Drawing.Image)(resources.GetObject("Bsalir.Image")));
            this.Bsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bsalir.Location = new System.Drawing.Point(1009, 30);
            this.Bsalir.Name = "Bsalir";
            this.Bsalir.Size = new System.Drawing.Size(94, 43);
            this.Bsalir.TabIndex = 5;
            this.Bsalir.Text = "&Salir";
            this.Bsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bsalir.UseVisualStyleBackColor = false;
            this.Bsalir.Click += new System.EventHandler(this.Bsalir_Click);
            // 
            // Bcancelar
            // 
            this.Bcancelar.BackColor = System.Drawing.SystemColors.Window;
            this.Bcancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bcancelar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.Bcancelar.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.Bcancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.Bcancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.Bcancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bcancelar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bcancelar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Bcancelar.Image = ((System.Drawing.Image)(resources.GetObject("Bcancelar.Image")));
            this.Bcancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bcancelar.Location = new System.Drawing.Point(698, 30);
            this.Bcancelar.Name = "Bcancelar";
            this.Bcancelar.Size = new System.Drawing.Size(130, 43);
            this.Bcancelar.TabIndex = 3;
            this.Bcancelar.Text = "&Cancelar";
            this.Bcancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bcancelar.UseVisualStyleBackColor = false;
            this.Bcancelar.Click += new System.EventHandler(this.Bcancelar_Click);
            // 
            // Bguardar
            // 
            this.Bguardar.BackColor = System.Drawing.SystemColors.Window;
            this.Bguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bguardar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.Bguardar.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.Bguardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.Bguardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.Bguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bguardar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bguardar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Bguardar.Image = ((System.Drawing.Image)(resources.GetObject("Bguardar.Image")));
            this.Bguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bguardar.Location = new System.Drawing.Point(384, 30);
            this.Bguardar.Name = "Bguardar";
            this.Bguardar.Size = new System.Drawing.Size(130, 43);
            this.Bguardar.TabIndex = 1;
            this.Bguardar.Text = "&Guardar";
            this.Bguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bguardar.UseVisualStyleBackColor = false;
            this.Bguardar.Click += new System.EventHandler(this.Bguardar_Click);
            // 
            // btncargarsaldobancario
            // 
            this.btncargarsaldobancario.Location = new System.Drawing.Point(760, 149);
            this.btncargarsaldobancario.Name = "btncargarsaldobancario";
            this.btncargarsaldobancario.Size = new System.Drawing.Size(251, 39);
            this.btncargarsaldobancario.TabIndex = 84;
            this.btncargarsaldobancario.Text = "Cargar Saldo Bancario";
            this.btncargarsaldobancario.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(82, 446);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1210, 102);
            this.dataGridView1.TabIndex = 82;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(369, 209);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(251, 39);
            this.dateTimePicker1.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(76, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 31);
            this.label6.TabIndex = 80;
            this.label6.Text = "Transacciones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 31);
            this.label4.TabIndex = 79;
            this.label4.Text = "Fecha Conciliacion";
            // 
            // textBoxcuentaid
            // 
            this.textBoxcuentaid.BackColor = System.Drawing.Color.White;
            this.textBoxcuentaid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBoxcuentaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textBoxcuentaid.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxcuentaid.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.textBoxcuentaid.Location = new System.Drawing.Point(1041, 93);
            this.textBoxcuentaid.Name = "textBoxcuentaid";
            this.textBoxcuentaid.Size = new System.Drawing.Size(251, 39);
            this.textBoxcuentaid.TabIndex = 78;
            // 
            // textBoxsaldocontable
            // 
            this.textBoxsaldocontable.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxsaldocontable.Location = new System.Drawing.Point(1041, 214);
            this.textBoxsaldocontable.Name = "textBoxsaldocontable";
            this.textBoxsaldocontable.Size = new System.Drawing.Size(251, 39);
            this.textBoxsaldocontable.TabIndex = 76;
            // 
            // textBoxfechadeapertura
            // 
            this.textBoxfechadeapertura.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxfechadeapertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.textBoxfechadeapertura.Location = new System.Drawing.Point(369, 91);
            this.textBoxfechadeapertura.Name = "textBoxfechadeapertura";
            this.textBoxfechadeapertura.Size = new System.Drawing.Size(251, 39);
            this.textBoxfechadeapertura.TabIndex = 73;
            // 
            // textBoxbancoid
            // 
            this.textBoxbancoid.BackColor = System.Drawing.Color.White;
            this.textBoxbancoid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBoxbancoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textBoxbancoid.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxbancoid.FormattingEnabled = true;
            this.textBoxbancoid.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.textBoxbancoid.Location = new System.Drawing.Point(369, 152);
            this.textBoxbancoid.Name = "textBoxbancoid";
            this.textBoxbancoid.Size = new System.Drawing.Size(251, 39);
            this.textBoxbancoid.TabIndex = 72;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(76, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 31);
            this.label10.TabIndex = 71;
            this.label10.Text = "Bancos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(754, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 31);
            this.label9.TabIndex = 70;
            this.label9.Text = "Cuenta Bancaria";
            // 
            // textBoxsaldobancario
            // 
            this.textBoxsaldobancario.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxsaldobancario.Location = new System.Drawing.Point(1041, 149);
            this.textBoxsaldobancario.Name = "textBoxsaldobancario";
            this.textBoxsaldobancario.Size = new System.Drawing.Size(251, 39);
            this.textBoxsaldobancario.TabIndex = 69;
            // 
            // btnregistrarconciliacion
            // 
            this.btnregistrarconciliacion.Location = new System.Drawing.Point(369, 580);
            this.btnregistrarconciliacion.Name = "btnregistrarconciliacion";
            this.btnregistrarconciliacion.Size = new System.Drawing.Size(89, 39);
            this.btnregistrarconciliacion.TabIndex = 91;
            this.btnregistrarconciliacion.Text = "Registrar";
            this.btnregistrarconciliacion.UseVisualStyleBackColor = true;
            // 
            // btncalcularsaldocontable
            // 
            this.btncalcularsaldocontable.Location = new System.Drawing.Point(1653, -85);
            this.btncalcularsaldocontable.Name = "btncalcularsaldocontable";
            this.btncalcularsaldocontable.Size = new System.Drawing.Size(89, 39);
            this.btncalcularsaldocontable.TabIndex = 90;
            this.btncalcularsaldocontable.Text = "Calcular";
            this.btncalcularsaldocontable.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(507, 393);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(251, 39);
            this.dateTimePicker2.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(359, 31);
            this.label5.TabIndex = 87;
            this.label5.Text = "Transacciones No Conciliadas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 581);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 31);
            this.label3.TabIndex = 86;
            this.label3.Text = "Registrar Conciliación";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(82, 272);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1210, 102);
            this.dataGridView2.TabIndex = 93;
            // 
            // btncalcularsaldo
            // 
            this.btncalcularsaldo.Location = new System.Drawing.Point(760, 214);
            this.btncalcularsaldo.Name = "btncalcularsaldo";
            this.btncalcularsaldo.Size = new System.Drawing.Size(251, 39);
            this.btncalcularsaldo.TabIndex = 94;
            this.btncalcularsaldo.Text = "Calcular Saldo Contable";
            this.btncalcularsaldo.UseVisualStyleBackColor = true;
            // 
            // FMCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.btncalcularsaldo);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnregistrarconciliacion);
            this.Controls.Add(this.btncalcularsaldocontable);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btncargarsaldobancario);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxcuentaid);
            this.Controls.Add(this.textBoxsaldocontable);
            this.Controls.Add(this.textBoxfechadeapertura);
            this.Controls.Add(this.textBoxbancoid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxsaldobancario);
            this.Controls.Add(this.Pbotones);
            this.Controls.Add(this.BarraTitulo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMCB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bancos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMBancos_FormClosing);
            this.Load += new System.EventHandler(this.FMBancos_Load);
            this.BarraTitulo.ResumeLayout(false);
            this.Pbotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel BarraTitulo;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel Pbotones;
        private System.Windows.Forms.Button Bsalir;
        private System.Windows.Forms.Button Bcancelar;
        private System.Windows.Forms.Button Bguardar;
        private System.Windows.Forms.Button btncargarsaldobancario;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox textBoxcuentaid;
        private System.Windows.Forms.TextBox textBoxsaldocontable;
        private System.Windows.Forms.DateTimePicker textBoxfechadeapertura;
        private System.Windows.Forms.ComboBox textBoxbancoid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxsaldobancario;
        private System.Windows.Forms.Button btnregistrarconciliacion;
        private System.Windows.Forms.Button btncalcularsaldocontable;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btncalcularsaldo;
    }
}