
namespace GiftGestion.Secciones
{
    partial class CambiosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.dataGridVentas = new System.Windows.Forms.DataGridView();
            this.panelUtiles = new System.Windows.Forms.Panel();
            this.buttonExportar = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.buttonTodas = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.panelInsert = new System.Windows.Forms.Panel();
            this.dataGridPagos = new System.Windows.Forms.DataGridView();
            this.formaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridProductos = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonGenerarCambio = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.buttonMinimizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ganancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).BeginInit();
            this.panelUtiles.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTabla
            // 
            this.panelTabla.Controls.Add(this.dataGridVentas);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Location = new System.Drawing.Point(0, 226);
            this.panelTabla.Margin = new System.Windows.Forms.Padding(2);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(723, 316);
            this.panelTabla.TabIndex = 17;
            // 
            // dataGridVentas
            // 
            this.dataGridVentas.AllowUserToResizeColumns = false;
            this.dataGridVentas.AllowUserToResizeRows = false;
            this.dataGridVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridVentas.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha,
            this.hora,
            this.sucursal,
            this.tipo_pago,
            this.total,
            this.ganancia,
            this.estado,
            this.empleado,
            this.cliente,
            this.observacion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridVentas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridVentas.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridVentas.Location = new System.Drawing.Point(0, 0);
            this.dataGridVentas.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridVentas.Name = "dataGridVentas";
            this.dataGridVentas.ReadOnly = true;
            this.dataGridVentas.RowHeadersVisible = false;
            this.dataGridVentas.RowHeadersWidth = 51;
            this.dataGridVentas.RowTemplate.Height = 24;
            this.dataGridVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridVentas.Size = new System.Drawing.Size(723, 316);
            this.dataGridVentas.TabIndex = 0;
            this.dataGridVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVentas_CellContentClick);
            // 
            // panelUtiles
            // 
            this.panelUtiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUtiles.Controls.Add(this.buttonExportar);
            this.panelUtiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUtiles.Location = new System.Drawing.Point(0, 542);
            this.panelUtiles.Margin = new System.Windows.Forms.Padding(2);
            this.panelUtiles.Name = "panelUtiles";
            this.panelUtiles.Size = new System.Drawing.Size(723, 70);
            this.panelUtiles.TabIndex = 16;
            // 
            // buttonExportar
            // 
            this.buttonExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonExportar.Location = new System.Drawing.Point(8, 26);
            this.buttonExportar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExportar.Name = "buttonExportar";
            this.buttonExportar.Size = new System.Drawing.Size(178, 29);
            this.buttonExportar.TabIndex = 14;
            this.buttonExportar.Text = "Exportar Excel";
            this.buttonExportar.UseVisualStyleBackColor = false;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.groupBox4);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 101);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(2);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(723, 125);
            this.panelFiltros.TabIndex = 15;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateFecha);
            this.groupBox4.Controls.Add(this.buttonTodas);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(721, 123);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtros";
            // 
            // dateFecha
            // 
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFecha.Location = new System.Drawing.Point(8, 57);
            this.dateFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(112, 23);
            this.dateFecha.TabIndex = 46;
            // 
            // buttonTodas
            // 
            this.buttonTodas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTodas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTodas.Location = new System.Drawing.Point(613, 51);
            this.buttonTodas.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTodas.Name = "buttonTodas";
            this.buttonTodas.Size = new System.Drawing.Size(94, 29);
            this.buttonTodas.TabIndex = 45;
            this.buttonTodas.Text = "Todas";
            this.buttonTodas.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label15.Location = new System.Drawing.Point(8, 33);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 34;
            this.label15.Text = "Fecha";
            // 
            // panelInsert
            // 
            this.panelInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panelInsert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInsert.Controls.Add(this.dataGridPagos);
            this.panelInsert.Controls.Add(this.label5);
            this.panelInsert.Controls.Add(this.dataGridProductos);
            this.panelInsert.Controls.Add(this.label4);
            this.panelInsert.Controls.Add(this.buttonGenerarCambio);
            this.panelInsert.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInsert.Location = new System.Drawing.Point(723, 101);
            this.panelInsert.Margin = new System.Windows.Forms.Padding(2);
            this.panelInsert.Name = "panelInsert";
            this.panelInsert.Size = new System.Drawing.Size(463, 511);
            this.panelInsert.TabIndex = 14;
            // 
            // dataGridPagos
            // 
            this.dataGridPagos.AllowUserToResizeColumns = false;
            this.dataGridPagos.AllowUserToResizeRows = false;
            this.dataGridPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPagos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dataGridPagos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridPagos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.formaPago,
            this.fechaPago,
            this.montoPago});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridPagos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridPagos.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridPagos.Location = new System.Drawing.Point(0, 237);
            this.dataGridPagos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridPagos.Name = "dataGridPagos";
            this.dataGridPagos.ReadOnly = true;
            this.dataGridPagos.RowHeadersVisible = false;
            this.dataGridPagos.RowHeadersWidth = 51;
            this.dataGridPagos.RowTemplate.Height = 24;
            this.dataGridPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPagos.Size = new System.Drawing.Size(461, 173);
            this.dataGridPagos.TabIndex = 13;
            // 
            // formaPago
            // 
            this.formaPago.HeaderText = "Forma Pago";
            this.formaPago.MinimumWidth = 6;
            this.formaPago.Name = "formaPago";
            this.formaPago.ReadOnly = true;
            // 
            // fechaPago
            // 
            this.fechaPago.HeaderText = "fecha";
            this.fechaPago.MinimumWidth = 6;
            this.fechaPago.Name = "fechaPago";
            this.fechaPago.ReadOnly = true;
            // 
            // montoPago
            // 
            this.montoPago.HeaderText = "montoPago";
            this.montoPago.MinimumWidth = 6;
            this.montoPago.Name = "montoPago";
            this.montoPago.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(0, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(461, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Detalle Pago";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.AllowUserToResizeColumns = false;
            this.dataGridProductos.AllowUserToResizeRows = false;
            this.dataGridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dataGridProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.descripcion,
            this.monto});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridProductos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridProductos.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridProductos.Location = new System.Drawing.Point(0, 32);
            this.dataGridProductos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.ReadOnly = true;
            this.dataGridProductos.RowHeadersVisible = false;
            this.dataGridProductos.RowHeadersWidth = 51;
            this.dataGridProductos.RowTemplate.Height = 24;
            this.dataGridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProductos.Size = new System.Drawing.Size(461, 173);
            this.dataGridProductos.TabIndex = 11;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // monto
            // 
            this.monto.HeaderText = "monto";
            this.monto.MinimumWidth = 6;
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(461, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Detalle Cambio";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonGenerarCambio
            // 
            this.buttonGenerarCambio.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonGenerarCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerarCambio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerarCambio.Location = new System.Drawing.Point(117, 467);
            this.buttonGenerarCambio.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGenerarCambio.Name = "buttonGenerarCambio";
            this.buttonGenerarCambio.Size = new System.Drawing.Size(249, 33);
            this.buttonGenerarCambio.TabIndex = 10;
            this.buttonGenerarCambio.Text = "Generar Nuevo Cambio";
            this.buttonGenerarCambio.UseVisualStyleBackColor = false;
            this.buttonGenerarCambio.Click += new System.EventHandler(this.buttonGenerarCambio_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 101);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonVolver);
            this.panel2.Controls.Add(this.buttonMinimizar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1088, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(98, 101);
            this.panel2.TabIndex = 36;
            // 
            // buttonVolver
            // 
            this.buttonVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolver.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVolver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonVolver.Location = new System.Drawing.Point(8, 46);
            this.buttonVolver.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(81, 30);
            this.buttonVolver.TabIndex = 37;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = false;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // buttonMinimizar
            // 
            this.buttonMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimizar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinimizar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonMinimizar.Location = new System.Drawing.Point(8, 10);
            this.buttonMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMinimizar.Name = "buttonMinimizar";
            this.buttonMinimizar.Size = new System.Drawing.Size(81, 31);
            this.buttonMinimizar.TabIndex = 36;
            this.buttonMinimizar.Text = "-";
            this.buttonMinimizar.UseVisualStyleBackColor = false;
            this.buttonMinimizar.Click += new System.EventHandler(this.buttonMinimizar_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1186, 101);
            this.label1.TabIndex = 3;
            this.label1.Text = "CAMBIOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 21;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fecha.HeaderText = "fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 62;
            // 
            // hora
            // 
            this.hora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.hora.HeaderText = "hora";
            this.hora.MinimumWidth = 6;
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            this.hora.Width = 56;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "sucursal";
            this.sucursal.MinimumWidth = 6;
            this.sucursal.Name = "sucursal";
            this.sucursal.ReadOnly = true;
            this.sucursal.Width = 78;
            // 
            // tipo_pago
            // 
            this.tipo_pago.HeaderText = "tipo pago";
            this.tipo_pago.MinimumWidth = 6;
            this.tipo_pago.Name = "tipo_pago";
            this.tipo_pago.ReadOnly = true;
            this.tipo_pago.Width = 82;
            // 
            // total
            // 
            this.total.HeaderText = "total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 55;
            // 
            // ganancia
            // 
            this.ganancia.HeaderText = "ganancia";
            this.ganancia.MinimumWidth = 6;
            this.ganancia.Name = "ganancia";
            this.ganancia.ReadOnly = true;
            this.ganancia.Width = 82;
            // 
            // estado
            // 
            this.estado.HeaderText = "estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            this.estado.Width = 68;
            // 
            // empleado
            // 
            this.empleado.HeaderText = "empleado";
            this.empleado.MinimumWidth = 6;
            this.empleado.Name = "empleado";
            this.empleado.ReadOnly = true;
            this.empleado.Width = 85;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "cliente";
            this.cliente.MinimumWidth = 6;
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 68;
            // 
            // observacion
            // 
            this.observacion.HeaderText = "observacion";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 99;
            // 
            // CambiosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 612);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelUtiles);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelInsert);
            this.Controls.Add(this.panel1);
            this.Name = "CambiosForm";
            this.Text = "CambiosForm";
            this.Load += new System.EventHandler(this.CambiosForm_Load);
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).EndInit();
            this.panelUtiles.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelInsert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.DataGridView dataGridVentas;
        private System.Windows.Forms.Panel panelUtiles;
        private System.Windows.Forms.Button buttonExportar;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Button buttonTodas;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelInsert;
        private System.Windows.Forms.DataGridView dataGridPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn formaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGenerarCambio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Button buttonMinimizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn ganancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
    }
}