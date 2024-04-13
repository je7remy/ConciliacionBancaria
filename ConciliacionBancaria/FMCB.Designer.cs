
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
            this.Bbuscar = new System.Windows.Forms.Button();
            this.Bsalir = new System.Windows.Forms.Button();
            this.Bcancelar = new System.Windows.Forms.Button();
            this.Bguardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxcuentaid = new System.Windows.Forms.ComboBox();
            this.textBoxsaldocontable = new System.Windows.Forms.TextBox();
            this.textBoxfechadeconcilicacion = new System.Windows.Forms.DateTimePicker();
            this.btncalcularsaldocontable = new System.Windows.Forms.Button();
            this.btncalcularsaldo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxestado = new System.Windows.Forms.ComboBox();
            this.textBoxdiferencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btncargartransacciones = new System.Windows.Forms.Button();
            this.DGVDatos = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxbancoid = new System.Windows.Forms.ComboBox();
            this.textBoxconciliacionid = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxsaldobancario = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BarraTitulo.SuspendLayout();
            this.Pbotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatos)).BeginInit();
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
            this.BarraTitulo.Size = new System.Drawing.Size(1294, 45);
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
            this.Pbotones.Controls.Add(this.Bbuscar);
            this.Pbotones.Controls.Add(this.Bsalir);
            this.Pbotones.Controls.Add(this.Bcancelar);
            this.Pbotones.Controls.Add(this.Bguardar);
            this.Pbotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pbotones.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pbotones.Location = new System.Drawing.Point(0, 649);
            this.Pbotones.Name = "Pbotones";
            this.Pbotones.Size = new System.Drawing.Size(1294, 100);
            this.Pbotones.TabIndex = 35;
            // 
            // Bbuscar
            // 
            this.Bbuscar.BackColor = System.Drawing.SystemColors.Window;
            this.Bbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bbuscar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.Bbuscar.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.Bbuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.Bbuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.Bbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bbuscar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bbuscar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Bbuscar.Image = ((System.Drawing.Image)(resources.GetObject("Bbuscar.Image")));
            this.Bbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bbuscar.Location = new System.Drawing.Point(814, 30);
            this.Bbuscar.Name = "Bbuscar";
            this.Bbuscar.Size = new System.Drawing.Size(112, 43);
            this.Bbuscar.TabIndex = 6;
            this.Bbuscar.Text = "&Buscar";
            this.Bbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bbuscar.UseVisualStyleBackColor = false;
            this.Bbuscar.Click += new System.EventHandler(this.Bbuscar_Click);
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
            this.Bcancelar.Location = new System.Drawing.Point(596, 30);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(753, 88);
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
            this.textBoxcuentaid.Location = new System.Drawing.Point(368, 149);
            this.textBoxcuentaid.Name = "textBoxcuentaid";
            this.textBoxcuentaid.Size = new System.Drawing.Size(251, 39);
            this.textBoxcuentaid.TabIndex = 78;
            this.textBoxcuentaid.SelectedIndexChanged += new System.EventHandler(this.textBoxcuentaid_SelectedIndexChanged);
            // 
            // textBoxsaldocontable
            // 
            this.textBoxsaldocontable.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxsaldocontable.Location = new System.Drawing.Point(1040, 214);
            this.textBoxsaldocontable.Name = "textBoxsaldocontable";
            this.textBoxsaldocontable.Size = new System.Drawing.Size(251, 39);
            this.textBoxsaldocontable.TabIndex = 76;
            this.textBoxsaldocontable.TextChanged += new System.EventHandler(this.textBoxsaldocontable_TextChanged);
            // 
            // textBoxfechadeconcilicacion
            // 
            this.textBoxfechadeconcilicacion.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxfechadeconcilicacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.textBoxfechadeconcilicacion.Location = new System.Drawing.Point(1040, 82);
            this.textBoxfechadeconcilicacion.Name = "textBoxfechadeconcilicacion";
            this.textBoxfechadeconcilicacion.Size = new System.Drawing.Size(251, 39);
            this.textBoxfechadeconcilicacion.TabIndex = 73;
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
            // btncalcularsaldo
            // 
            this.btncalcularsaldo.Enabled = false;
            this.btncalcularsaldo.Location = new System.Drawing.Point(759, 214);
            this.btncalcularsaldo.Name = "btncalcularsaldo";
            this.btncalcularsaldo.Size = new System.Drawing.Size(251, 39);
            this.btncalcularsaldo.TabIndex = 94;
            this.btncalcularsaldo.Text = "Calcular Saldo Contable";
            this.btncalcularsaldo.UseVisualStyleBackColor = true;
            this.btncalcularsaldo.Click += new System.EventHandler(this.btncalcularsaldo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 31);
            this.label1.TabIndex = 96;
            this.label1.Text = "Conciliacion ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(753, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 31);
            this.label2.TabIndex = 98;
            this.label2.Text = "Estado";
            // 
            // comboBoxestado
            // 
            this.comboBoxestado.AutoCompleteCustomSource.AddRange(new string[] {
            "Conciliado",
            "No Conciliado"});
            this.comboBoxestado.BackColor = System.Drawing.Color.White;
            this.comboBoxestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxestado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxestado.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxestado.Items.AddRange(new object[] {
            "Conciliado",
            "No Conciliado"});
            this.comboBoxestado.Location = new System.Drawing.Point(1040, 284);
            this.comboBoxestado.Name = "comboBoxestado";
            this.comboBoxestado.Size = new System.Drawing.Size(251, 39);
            this.comboBoxestado.TabIndex = 99;
            // 
            // textBoxdiferencia
            // 
            this.textBoxdiferencia.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxdiferencia.Location = new System.Drawing.Point(368, 284);
            this.textBoxdiferencia.Name = "textBoxdiferencia";
            this.textBoxdiferencia.Size = new System.Drawing.Size(251, 39);
            this.textBoxdiferencia.TabIndex = 97;
            this.textBoxdiferencia.TextChanged += new System.EventHandler(this.textBoxdiferencia_TextChanged);
            this.textBoxdiferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxdiferencia_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 31);
            this.label3.TabIndex = 100;
            this.label3.Text = "Diferencia";
            // 
            // btncargartransacciones
            // 
            this.btncargartransacciones.Location = new System.Drawing.Point(530, 352);
            this.btncargartransacciones.Name = "btncargartransacciones";
            this.btncargartransacciones.Size = new System.Drawing.Size(89, 39);
            this.btncargartransacciones.TabIndex = 103;
            this.btncargartransacciones.Text = "Cargar";
            this.btncargartransacciones.UseVisualStyleBackColor = true;
            this.btncargartransacciones.Click += new System.EventHandler(this.btncargartransacciones_Click);
            // 
            // DGVDatos
            // 
            this.DGVDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDatos.Location = new System.Drawing.Point(81, 413);
            this.DGVDatos.Name = "DGVDatos";
            this.DGVDatos.Size = new System.Drawing.Size(1210, 189);
            this.DGVDatos.TabIndex = 102;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(75, 353);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(264, 31);
            this.label15.TabIndex = 101;
            this.label15.Text = "Cargar Transacciones";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(75, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 31);
            this.label10.TabIndex = 104;
            this.label10.Text = "Banco:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(753, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(359, 31);
            this.label5.TabIndex = 106;
            this.label5.Text = "Transacciones No Conciliadas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1202, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 39);
            this.button1.TabIndex = 107;
            this.button1.Text = "Cargar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.textBoxbancoid.Location = new System.Drawing.Point(368, 214);
            this.textBoxbancoid.Name = "textBoxbancoid";
            this.textBoxbancoid.Size = new System.Drawing.Size(251, 39);
            this.textBoxbancoid.TabIndex = 105;
            // 
            // textBoxconciliacionid
            // 
            this.textBoxconciliacionid.Enabled = false;
            this.textBoxconciliacionid.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxconciliacionid.Location = new System.Drawing.Point(368, 85);
            this.textBoxconciliacionid.Name = "textBoxconciliacionid";
            this.textBoxconciliacionid.Size = new System.Drawing.Size(251, 39);
            this.textBoxconciliacionid.TabIndex = 109;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(81, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 39);
            this.button2.TabIndex = 110;
            this.button2.Text = "Cargar Cuenta Bancaria";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxsaldobancario
            // 
            this.textBoxsaldobancario.BackColor = System.Drawing.Color.White;
            this.textBoxsaldobancario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBoxsaldobancario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textBoxsaldobancario.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxsaldobancario.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.textBoxsaldobancario.Location = new System.Drawing.Point(1040, 147);
            this.textBoxsaldobancario.Name = "textBoxsaldobancario";
            this.textBoxsaldobancario.Size = new System.Drawing.Size(251, 39);
            this.textBoxsaldobancario.TabIndex = 111;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(753, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 31);
            this.label6.TabIndex = 112;
            this.label6.Text = "Saldo Bancario";
            // 
            // FMCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1294, 749);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxsaldobancario);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxconciliacionid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxbancoid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btncargartransacciones);
            this.Controls.Add(this.DGVDatos);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxestado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxdiferencia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncalcularsaldo);
            this.Controls.Add(this.btncalcularsaldocontable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxcuentaid);
            this.Controls.Add(this.textBoxsaldocontable);
            this.Controls.Add(this.textBoxfechadeconcilicacion);
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
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatos)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox textBoxcuentaid;
        private System.Windows.Forms.TextBox textBoxsaldocontable;
        private System.Windows.Forms.DateTimePicker textBoxfechadeconcilicacion;
        private System.Windows.Forms.Button btncalcularsaldocontable;
        private System.Windows.Forms.Button btncalcularsaldo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxestado;
        private System.Windows.Forms.TextBox textBoxdiferencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btncargartransacciones;
        private System.Windows.Forms.DataGridView DGVDatos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox textBoxbancoid;
        private System.Windows.Forms.TextBox textBoxconciliacionid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox textBoxsaldobancario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Bbuscar;
    }
}