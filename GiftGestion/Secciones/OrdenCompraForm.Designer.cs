
namespace GiftGestion.Secciones
{
    partial class OrdenCompraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenCompraForm));
            this.panelTabla = new System.Windows.Forms.Panel();
            this.dataGridOrdenesCompras = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemitoGenerado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validaHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ganancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelUtiles = new System.Windows.Forms.Panel();
            this.buttonExportar = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonTodos = new System.Windows.Forms.Button();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.panelInsert = new System.Windows.Forms.Panel();
            this.dataGridProductos = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciolista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioefectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.talle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textTOTAL = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textInfo = new System.Windows.Forms.Label();
            this.comboRemitoOC = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonGuardarCambios = new System.Windows.Forms.Button();
            this.comboEstadoOC = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonGenerarOC = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrdenesCompras)).BeginInit();
            this.panelUtiles.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTabla
            // 
            this.panelTabla.Controls.Add(this.dataGridOrdenesCompras);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Location = new System.Drawing.Point(0, 181);
            this.panelTabla.Margin = new System.Windows.Forms.Padding(2);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(742, 375);
            this.panelTabla.TabIndex = 13;
            // 
            // dataGridOrdenesCompras
            // 
            this.dataGridOrdenesCompras.AllowUserToResizeColumns = false;
            this.dataGridOrdenesCompras.AllowUserToResizeRows = false;
            this.dataGridOrdenesCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridOrdenesCompras.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridOrdenesCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridOrdenesCompras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridOrdenesCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridOrdenesCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrdenesCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha,
            this.hora,
            this.estado,
            this.RemitoGenerado,
            this.observacion,
            this.empleado,
            this.validaHasta,
            this.prov,
            this.total,
            this.ganancia,
            this.prioridad});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridOrdenesCompras.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridOrdenesCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridOrdenesCompras.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridOrdenesCompras.Location = new System.Drawing.Point(0, 0);
            this.dataGridOrdenesCompras.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridOrdenesCompras.Name = "dataGridOrdenesCompras";
            this.dataGridOrdenesCompras.ReadOnly = true;
            this.dataGridOrdenesCompras.RowHeadersVisible = false;
            this.dataGridOrdenesCompras.RowHeadersWidth = 51;
            this.dataGridOrdenesCompras.RowTemplate.Height = 24;
            this.dataGridOrdenesCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridOrdenesCompras.Size = new System.Drawing.Size(742, 375);
            this.dataGridOrdenesCompras.TabIndex = 0;
            this.dataGridOrdenesCompras.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridOrdenesCompras_CellMouseDown);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 40;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 62;
            // 
            // hora
            // 
            this.hora.HeaderText = "hora";
            this.hora.MinimumWidth = 6;
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            this.hora.Width = 56;
            // 
            // estado
            // 
            this.estado.HeaderText = "estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 68;
            // 
            // RemitoGenerado
            // 
            this.RemitoGenerado.HeaderText = "remito";
            this.RemitoGenerado.Name = "RemitoGenerado";
            this.RemitoGenerado.ReadOnly = true;
            this.RemitoGenerado.Width = 66;
            // 
            // observacion
            // 
            this.observacion.HeaderText = "observacion";
            this.observacion.MinimumWidth = 6;
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 99;
            // 
            // empleado
            // 
            this.empleado.HeaderText = "empleado";
            this.empleado.MinimumWidth = 6;
            this.empleado.Name = "empleado";
            this.empleado.ReadOnly = true;
            this.empleado.Width = 85;
            // 
            // validaHasta
            // 
            this.validaHasta.HeaderText = "valido Hasta";
            this.validaHasta.MinimumWidth = 6;
            this.validaHasta.Name = "validaHasta";
            this.validaHasta.ReadOnly = true;
            this.validaHasta.Width = 90;
            // 
            // prov
            // 
            this.prov.HeaderText = "proveedor";
            this.prov.MinimumWidth = 6;
            this.prov.Name = "prov";
            this.prov.ReadOnly = true;
            this.prov.Width = 88;
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
            // prioridad
            // 
            this.prioridad.HeaderText = "prioridad";
            this.prioridad.MinimumWidth = 6;
            this.prioridad.Name = "prioridad";
            this.prioridad.ReadOnly = true;
            this.prioridad.Width = 81;
            // 
            // panelUtiles
            // 
            this.panelUtiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUtiles.Controls.Add(this.buttonExportar);
            this.panelUtiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUtiles.Location = new System.Drawing.Point(0, 556);
            this.panelUtiles.Margin = new System.Windows.Forms.Padding(2);
            this.panelUtiles.Name = "panelUtiles";
            this.panelUtiles.Size = new System.Drawing.Size(742, 56);
            this.panelUtiles.TabIndex = 12;
            // 
            // buttonExportar
            // 
            this.buttonExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonExportar.Location = new System.Drawing.Point(11, 15);
            this.buttonExportar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExportar.Name = "buttonExportar";
            this.buttonExportar.Size = new System.Drawing.Size(178, 29);
            this.buttonExportar.TabIndex = 14;
            this.buttonExportar.Text = "Exportar PDF";
            this.buttonExportar.UseVisualStyleBackColor = false;
            this.buttonExportar.Click += new System.EventHandler(this.buttonExportar_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.groupBox4);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 81);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(2);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(742, 100);
            this.panelFiltros.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonTodos);
            this.groupBox4.Controls.Add(this.dateFecha);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(740, 98);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtros";
            // 
            // buttonTodos
            // 
            this.buttonTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonTodos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTodos.Location = new System.Drawing.Point(668, 54);
            this.buttonTodos.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTodos.Name = "buttonTodos";
            this.buttonTodos.Size = new System.Drawing.Size(68, 29);
            this.buttonTodos.TabIndex = 44;
            this.buttonTodos.Text = "Todos";
            this.buttonTodos.UseVisualStyleBackColor = false;
            this.buttonTodos.Click += new System.EventHandler(this.buttonTodos_Click);
            // 
            // dateFecha
            // 
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFecha.Location = new System.Drawing.Point(10, 55);
            this.dateFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(112, 23);
            this.dateFecha.TabIndex = 39;
            this.dateFecha.ValueChanged += new System.EventHandler(this.dateFecha_ValueChanged);
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
            this.panelInsert.Controls.Add(this.dataGridProductos);
            this.panelInsert.Controls.Add(this.label4);
            this.panelInsert.Controls.Add(this.label2);
            this.panelInsert.Controls.Add(this.textTOTAL);
            this.panelInsert.Controls.Add(this.panel2);
            this.panelInsert.Controls.Add(this.buttonGenerarOC);
            this.panelInsert.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInsert.Location = new System.Drawing.Point(742, 81);
            this.panelInsert.Margin = new System.Windows.Forms.Padding(2);
            this.panelInsert.Name = "panelInsert";
            this.panelInsert.Size = new System.Drawing.Size(444, 531);
            this.panelInsert.TabIndex = 10;
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.AllowUserToResizeColumns = false;
            this.dataGridProductos.AllowUserToResizeRows = false;
            this.dataGridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dataGridProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.descripcion,
            this.cantidad,
            this.preciolista,
            this.precioefectivo,
            this.costo,
            this.proveedor,
            this.estacion,
            this.color,
            this.talle,
            this.grupo});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridProductos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridProductos.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridProductos.Location = new System.Drawing.Point(0, 64);
            this.dataGridProductos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.ReadOnly = true;
            this.dataGridProductos.RowHeadersVisible = false;
            this.dataGridProductos.RowHeadersWidth = 51;
            this.dataGridProductos.RowTemplate.Height = 24;
            this.dataGridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProductos.Size = new System.Drawing.Size(442, 239);
            this.dataGridProductos.TabIndex = 19;
            this.dataGridProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProductos_CellContentClick);
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombre.HeaderText = "nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 73;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 96;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 79;
            // 
            // preciolista
            // 
            this.preciolista.HeaderText = "precio lista";
            this.preciolista.MinimumWidth = 6;
            this.preciolista.Name = "preciolista";
            this.preciolista.ReadOnly = true;
            this.preciolista.Width = 85;
            // 
            // precioefectivo
            // 
            this.precioefectivo.HeaderText = "precio efectivo";
            this.precioefectivo.MinimumWidth = 6;
            this.precioefectivo.Name = "precioefectivo";
            this.precioefectivo.ReadOnly = true;
            this.precioefectivo.Width = 105;
            // 
            // costo
            // 
            this.costo.HeaderText = "costo";
            this.costo.MinimumWidth = 6;
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Width = 61;
            // 
            // proveedor
            // 
            this.proveedor.HeaderText = "proveedor";
            this.proveedor.MinimumWidth = 6;
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            this.proveedor.Width = 88;
            // 
            // estacion
            // 
            this.estacion.HeaderText = "estacion";
            this.estacion.MinimumWidth = 6;
            this.estacion.Name = "estacion";
            this.estacion.ReadOnly = true;
            this.estacion.Width = 78;
            // 
            // color
            // 
            this.color.HeaderText = "color";
            this.color.MinimumWidth = 6;
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Width = 59;
            // 
            // talle
            // 
            this.talle.HeaderText = "talle";
            this.talle.MinimumWidth = 6;
            this.talle.Name = "talle";
            this.talle.ReadOnly = true;
            this.talle.Width = 54;
            // 
            // grupo
            // 
            this.grupo.HeaderText = "grupo";
            this.grupo.MinimumWidth = 6;
            this.grupo.Name = "grupo";
            this.grupo.ReadOnly = true;
            this.grupo.Width = 63;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(0, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(442, 32);
            this.label4.TabIndex = 18;
            this.label4.Text = "Detalle Orden Compra";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(0, 303);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(442, 32);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cambiar estado Orden Compra";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textTOTAL
            // 
            this.textTOTAL.Dock = System.Windows.Forms.DockStyle.Top;
            this.textTOTAL.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTOTAL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textTOTAL.Location = new System.Drawing.Point(0, 0);
            this.textTOTAL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textTOTAL.Name = "textTOTAL";
            this.textTOTAL.Size = new System.Drawing.Size(442, 32);
            this.textTOTAL.TabIndex = 16;
            this.textTOTAL.Text = "Total: 0  Seleccion: 0";
            this.textTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textInfo);
            this.panel2.Controls.Add(this.comboRemitoOC);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.buttonGuardarCambios);
            this.panel2.Controls.Add(this.comboEstadoOC);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 335);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 161);
            this.panel2.TabIndex = 15;
            // 
            // textInfo
            // 
            this.textInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.textInfo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textInfo.Location = new System.Drawing.Point(0, 0);
            this.textInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textInfo.Name = "textInfo";
            this.textInfo.Size = new System.Drawing.Size(442, 32);
            this.textInfo.TabIndex = 59;
            this.textInfo.Text = "Info";
            this.textInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboRemitoOC
            // 
            this.comboRemitoOC.BackColor = System.Drawing.SystemColors.Control;
            this.comboRemitoOC.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRemitoOC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboRemitoOC.FormattingEnabled = true;
            this.comboRemitoOC.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.comboRemitoOC.Location = new System.Drawing.Point(251, 76);
            this.comboRemitoOC.Margin = new System.Windows.Forms.Padding(2);
            this.comboRemitoOC.Name = "comboRemitoOC";
            this.comboRemitoOC.Size = new System.Drawing.Size(184, 24);
            this.comboRemitoOC.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(249, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "Remito";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonGuardarCambios
            // 
            this.buttonGuardarCambios.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardarCambios.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardarCambios.Location = new System.Drawing.Point(117, 114);
            this.buttonGuardarCambios.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGuardarCambios.Name = "buttonGuardarCambios";
            this.buttonGuardarCambios.Size = new System.Drawing.Size(249, 33);
            this.buttonGuardarCambios.TabIndex = 13;
            this.buttonGuardarCambios.Text = "Guardar Cambios";
            this.buttonGuardarCambios.UseVisualStyleBackColor = false;
            this.buttonGuardarCambios.Click += new System.EventHandler(this.buttonGuardarCambios_Click);
            // 
            // comboEstadoOC
            // 
            this.comboEstadoOC.BackColor = System.Drawing.SystemColors.Control;
            this.comboEstadoOC.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstadoOC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboEstadoOC.FormattingEnabled = true;
            this.comboEstadoOC.Items.AddRange(new object[] {
            "PENDIENTE",
            "PAGADA"});
            this.comboEstadoOC.Location = new System.Drawing.Point(20, 76);
            this.comboEstadoOC.Margin = new System.Windows.Forms.Padding(2);
            this.comboEstadoOC.Name = "comboEstadoOC";
            this.comboEstadoOC.Size = new System.Drawing.Size(184, 24);
            this.comboEstadoOC.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(18, 58);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 56;
            this.label8.Text = "Estado";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonGenerarOC
            // 
            this.buttonGenerarOC.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonGenerarOC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonGenerarOC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerarOC.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerarOC.Location = new System.Drawing.Point(0, 496);
            this.buttonGenerarOC.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGenerarOC.Name = "buttonGenerarOC";
            this.buttonGenerarOC.Size = new System.Drawing.Size(442, 33);
            this.buttonGenerarOC.TabIndex = 10;
            this.buttonGenerarOC.Text = "Generar Nuevo OC";
            this.buttonGenerarOC.UseVisualStyleBackColor = false;
            this.buttonGenerarOC.Click += new System.EventHandler(this.buttonGenerarOC_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 81);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1186, 81);
            this.label1.TabIndex = 4;
            this.label1.Text = "ORDENES DE COMPRA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrdenCompraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 612);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelUtiles);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelInsert);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OrdenCompraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ORDENES DE COMPRA";
            this.Load += new System.EventHandler(this.OrdenCompraForm_Load);
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrdenesCompras)).EndInit();
            this.panelUtiles.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelInsert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.DataGridView dataGridOrdenesCompras;
        private System.Windows.Forms.Panel panelUtiles;
        private System.Windows.Forms.Button buttonExportar;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelInsert;
        private System.Windows.Forms.Button buttonGenerarOC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTodos;
        private System.Windows.Forms.Button buttonGuardarCambios;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboRemitoOC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboEstadoOC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label textInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemitoGenerado;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn validaHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn prov;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn ganancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridad;
        private System.Windows.Forms.DataGridView dataGridProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciolista;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioefectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn estacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn talle;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label textTOTAL;
    }
}