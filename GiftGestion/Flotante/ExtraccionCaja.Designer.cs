
namespace GiftGestion.Flotante
{
    partial class ExtraccionCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraccionCaja));
            this.groupRemitos = new System.Windows.Forms.GroupBox();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.comboEmpleado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textMonto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textMotivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboSucursal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.groupExtraccion = new System.Windows.Forms.GroupBox();
            this.dataGridGastos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textTotalExtraccion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonTodos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboFiltroSucursal = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dateFiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textInformacionProducto = new System.Windows.Forms.Label();
            this.groupRemitos.SuspendLayout();
            this.groupExtraccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGastos)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupRemitos
            // 
            this.groupRemitos.Controls.Add(this.buttonAgregar);
            this.groupRemitos.Controls.Add(this.comboEmpleado);
            this.groupRemitos.Controls.Add(this.label5);
            this.groupRemitos.Controls.Add(this.label4);
            this.groupRemitos.Controls.Add(this.textMonto);
            this.groupRemitos.Controls.Add(this.label17);
            this.groupRemitos.Controls.Add(this.textMotivo);
            this.groupRemitos.Controls.Add(this.label2);
            this.groupRemitos.Controls.Add(this.comboSucursal);
            this.groupRemitos.Controls.Add(this.label3);
            this.groupRemitos.Controls.Add(this.dateFecha);
            this.groupRemitos.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupRemitos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupRemitos.Location = new System.Drawing.Point(559, 70);
            this.groupRemitos.Name = "groupRemitos";
            this.groupRemitos.Size = new System.Drawing.Size(241, 380);
            this.groupRemitos.TabIndex = 8;
            this.groupRemitos.TabStop = false;
            this.groupRemitos.Text = "NUEVO GASTO";
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonAgregar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAgregar.Location = new System.Drawing.Point(45, 288);
            this.buttonAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(182, 29);
            this.buttonAgregar.TabIndex = 2;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = false;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // comboEmpleado
            // 
            this.comboEmpleado.BackColor = System.Drawing.SystemColors.Control;
            this.comboEmpleado.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEmpleado.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboEmpleado.FormattingEnabled = true;
            this.comboEmpleado.ItemHeight = 14;
            this.comboEmpleado.Location = new System.Drawing.Point(44, 145);
            this.comboEmpleado.Margin = new System.Windows.Forms.Padding(2);
            this.comboEmpleado.Name = "comboEmpleado";
            this.comboEmpleado.Size = new System.Drawing.Size(122, 22);
            this.comboEmpleado.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(42, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 14);
            this.label5.TabIndex = 58;
            this.label5.Text = "Empleado";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(40, 226);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 56;
            this.label4.Text = "Monto";
            // 
            // textMonto
            // 
            this.textMonto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMonto.Location = new System.Drawing.Point(43, 242);
            this.textMonto.Margin = new System.Windows.Forms.Padding(2);
            this.textMonto.Name = "textMonto";
            this.textMonto.Size = new System.Drawing.Size(184, 23);
            this.textMonto.TabIndex = 1;
            this.textMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textMonto_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label17.Location = new System.Drawing.Point(40, 176);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 14);
            this.label17.TabIndex = 54;
            this.label17.Text = "Motivo";
            // 
            // textMotivo
            // 
            this.textMotivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMotivo.Location = new System.Drawing.Point(43, 192);
            this.textMotivo.Margin = new System.Windows.Forms.Padding(2);
            this.textMotivo.Name = "textMotivo";
            this.textMotivo.Size = new System.Drawing.Size(184, 23);
            this.textMotivo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(40, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 52;
            this.label2.Text = "Fecha";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboSucursal
            // 
            this.comboSucursal.BackColor = System.Drawing.SystemColors.Control;
            this.comboSucursal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSucursal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboSucursal.FormattingEnabled = true;
            this.comboSucursal.ItemHeight = 14;
            this.comboSucursal.Items.AddRange(new object[] {
            "Stgo del Estero",
            "Pueyrredon"});
            this.comboSucursal.Location = new System.Drawing.Point(43, 94);
            this.comboSucursal.Margin = new System.Windows.Forms.Padding(2);
            this.comboSucursal.Name = "comboSucursal";
            this.comboSucursal.Size = new System.Drawing.Size(122, 22);
            this.comboSucursal.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(41, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 51;
            this.label3.Text = "Sucursal";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateFecha
            // 
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFecha.Location = new System.Drawing.Point(43, 44);
            this.dateFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(122, 20);
            this.dateFecha.TabIndex = 49;
            // 
            // groupExtraccion
            // 
            this.groupExtraccion.Controls.Add(this.dataGridGastos);
            this.groupExtraccion.Controls.Add(this.panel3);
            this.groupExtraccion.Controls.Add(this.panel2);
            this.groupExtraccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupExtraccion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupExtraccion.Location = new System.Drawing.Point(0, 70);
            this.groupExtraccion.Name = "groupExtraccion";
            this.groupExtraccion.Size = new System.Drawing.Size(800, 380);
            this.groupExtraccion.TabIndex = 7;
            this.groupExtraccion.TabStop = false;
            this.groupExtraccion.Text = "GASTOS DIARIOS";
            // 
            // dataGridGastos
            // 
            this.dataGridGastos.AllowUserToResizeColumns = false;
            this.dataGridGastos.AllowUserToResizeRows = false;
            this.dataGridGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridGastos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridGastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridGastos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridGastos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha,
            this.monto,
            this.motivo,
            this.empleado,
            this.sucursal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridGastos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridGastos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridGastos.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridGastos.Location = new System.Drawing.Point(3, 80);
            this.dataGridGastos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridGastos.Name = "dataGridGastos";
            this.dataGridGastos.ReadOnly = true;
            this.dataGridGastos.RowHeadersVisible = false;
            this.dataGridGastos.RowHeadersWidth = 51;
            this.dataGridGastos.RowTemplate.Height = 24;
            this.dataGridGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridGastos.Size = new System.Drawing.Size(794, 251);
            this.dataGridGastos.TabIndex = 6;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 21;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 62;
            // 
            // monto
            // 
            this.monto.HeaderText = "monto";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Width = 65;
            // 
            // motivo
            // 
            this.motivo.HeaderText = "motivo";
            this.motivo.Name = "motivo";
            this.motivo.ReadOnly = true;
            this.motivo.Width = 67;
            // 
            // empleado
            // 
            this.empleado.HeaderText = "empleado";
            this.empleado.Name = "empleado";
            this.empleado.ReadOnly = true;
            this.empleado.Width = 85;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "sucursal";
            this.sucursal.Name = "sucursal";
            this.sucursal.ReadOnly = true;
            this.sucursal.Width = 78;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textTotalExtraccion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 331);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 46);
            this.panel3.TabIndex = 5;
            // 
            // textTotalExtraccion
            // 
            this.textTotalExtraccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.textTotalExtraccion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalExtraccion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textTotalExtraccion.Location = new System.Drawing.Point(0, 0);
            this.textTotalExtraccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textTotalExtraccion.Name = "textTotalExtraccion";
            this.textTotalExtraccion.Size = new System.Drawing.Size(794, 30);
            this.textTotalExtraccion.TabIndex = 51;
            this.textTotalExtraccion.Text = "Total Extraccción:";
            this.textTotalExtraccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonTodos);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboFiltroSucursal);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.dateFiltroFecha);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 64);
            this.panel2.TabIndex = 3;
            // 
            // buttonTodos
            // 
            this.buttonTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonTodos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTodos.Location = new System.Drawing.Point(436, 23);
            this.buttonTodos.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTodos.Name = "buttonTodos";
            this.buttonTodos.Size = new System.Drawing.Size(106, 29);
            this.buttonTodos.TabIndex = 60;
            this.buttonTodos.Text = "Todos";
            this.buttonTodos.UseVisualStyleBackColor = false;
            this.buttonTodos.Click += new System.EventHandler(this.buttonTodos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(21, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 48;
            this.label1.Text = "Fecha";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboFiltroSucursal
            // 
            this.comboFiltroSucursal.BackColor = System.Drawing.SystemColors.Control;
            this.comboFiltroSucursal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFiltroSucursal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboFiltroSucursal.FormattingEnabled = true;
            this.comboFiltroSucursal.ItemHeight = 14;
            this.comboFiltroSucursal.Items.AddRange(new object[] {
            "Pueyrredon",
            "Stgo del Estero"});
            this.comboFiltroSucursal.Location = new System.Drawing.Point(188, 26);
            this.comboFiltroSucursal.Margin = new System.Windows.Forms.Padding(2);
            this.comboFiltroSucursal.Name = "comboFiltroSucursal";
            this.comboFiltroSucursal.Size = new System.Drawing.Size(122, 22);
            this.comboFiltroSucursal.TabIndex = 46;
            this.comboFiltroSucursal.SelectedIndexChanged += new System.EventHandler(this.comboFiltroSucursal_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label14.Location = new System.Drawing.Point(186, 8);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 14);
            this.label14.TabIndex = 47;
            this.label14.Text = "Sucursal";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateFiltroFecha
            // 
            this.dateFiltroFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFiltroFecha.Location = new System.Drawing.Point(24, 26);
            this.dateFiltroFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dateFiltroFecha.Name = "dateFiltroFecha";
            this.dateFiltroFecha.Size = new System.Drawing.Size(101, 20);
            this.dateFiltroFecha.TabIndex = 45;
            this.dateFiltroFecha.ValueChanged += new System.EventHandler(this.dateFiltroFecha_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textInformacionProducto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 70);
            this.panel1.TabIndex = 6;
            // 
            // textInformacionProducto
            // 
            this.textInformacionProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.textInformacionProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInformacionProducto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInformacionProducto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textInformacionProducto.Location = new System.Drawing.Point(0, 0);
            this.textInformacionProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textInformacionProducto.Name = "textInformacionProducto";
            this.textInformacionProducto.Size = new System.Drawing.Size(798, 68);
            this.textInformacionProducto.TabIndex = 39;
            this.textInformacionProducto.Text = "Gastos Diarios";
            this.textInformacionProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExtraccionCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupRemitos);
            this.Controls.Add(this.groupExtraccion);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExtraccionCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.ExtraccionCaja_Load);
            this.groupRemitos.ResumeLayout(false);
            this.groupRemitos.PerformLayout();
            this.groupExtraccion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGastos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRemitos;
        private System.Windows.Forms.GroupBox groupExtraccion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label textInformacionProducto;
        private System.Windows.Forms.DataGridView dataGridGastos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateFiltroFecha;
        private System.Windows.Forms.Label textTotalExtraccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboFiltroSucursal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textMotivo;
        private System.Windows.Forms.ComboBox comboEmpleado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textMonto;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.Button buttonTodos;
    }
}