
namespace GiftGestion.Secciones
{
    partial class ProductosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductosForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textRemito = new System.Windows.Forms.TextBox();
            this.buttonObtenerID = new System.Windows.Forms.Button();
            this.textID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.buttonMinimizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInsert = new System.Windows.Forms.Panel();
            this.panelAgregarProducto = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.textCosto = new System.Windows.Forms.TextBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textColor = new System.Windows.Forms.TextBox();
            this.comboTalle = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboGrupo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboEstacion = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboProveedor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textPrecioEfectivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPrecioLista = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonInsertar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.buttonTodos = new System.Windows.Forms.Button();
            this.comboFiltroSucursal = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonFiltrarNombre = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textNombreFiltrar = new System.Windows.Forms.TextBox();
            this.comboFiltroProveedor = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboFiltroGrupo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panelUtiles = new System.Windows.Forms.Panel();
            this.textIDProducto = new System.Windows.Forms.Label();
            this.buttonSeguimiento = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textCantidadEtiqueta = new System.Windows.Forms.Label();
            this.buttonExportar = new System.Windows.Forms.Button();
            this.panelResultado = new System.Windows.Forms.Panel();
            this.buttonGenerarEtiqueta = new System.Windows.Forms.Button();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.dataGridProductos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantStgo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantGal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pueyrredon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.talle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_lista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_efectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etiqueta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelInsert.SuspendLayout();
            this.panelAgregarProducto.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelUtiles.SuspendLayout();
            this.panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.textRemito);
            this.panel1.Controls.Add(this.buttonObtenerID);
            this.panel1.Controls.Add(this.textID);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 80);
            this.panel1.TabIndex = 0;
            // 
            // textRemito
            // 
            this.textRemito.Location = new System.Drawing.Point(11, 46);
            this.textRemito.Margin = new System.Windows.Forms.Padding(2);
            this.textRemito.Name = "textRemito";
            this.textRemito.Size = new System.Drawing.Size(87, 20);
            this.textRemito.TabIndex = 63;
            this.textRemito.Visible = false;
            // 
            // buttonObtenerID
            // 
            this.buttonObtenerID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonObtenerID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonObtenerID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonObtenerID.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonObtenerID.Location = new System.Drawing.Point(120, 28);
            this.buttonObtenerID.Margin = new System.Windows.Forms.Padding(2);
            this.buttonObtenerID.Name = "buttonObtenerID";
            this.buttonObtenerID.Size = new System.Drawing.Size(34, 30);
            this.buttonObtenerID.TabIndex = 59;
            this.buttonObtenerID.Text = "ID";
            this.buttonObtenerID.UseVisualStyleBackColor = false;
            this.buttonObtenerID.Click += new System.EventHandler(this.buttonObtenerID_Click);
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(10, 21);
            this.textID.Margin = new System.Windows.Forms.Padding(2);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(87, 20);
            this.textID.TabIndex = 57;
            this.textID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonVolver);
            this.panel2.Controls.Add(this.buttonMinimizar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1064, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(122, 80);
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
            this.buttonVolver.TabIndex = 35;
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
            this.buttonMinimizar.TabIndex = 34;
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
            this.label1.Size = new System.Drawing.Size(1186, 80);
            this.label1.TabIndex = 3;
            this.label1.Text = "PRODUCTOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInsert
            // 
            this.panelInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panelInsert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInsert.Controls.Add(this.panelAgregarProducto);
            this.panelInsert.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInsert.Location = new System.Drawing.Point(952, 80);
            this.panelInsert.Margin = new System.Windows.Forms.Padding(2);
            this.panelInsert.Name = "panelInsert";
            this.panelInsert.Size = new System.Drawing.Size(234, 532);
            this.panelInsert.TabIndex = 1;
            // 
            // panelAgregarProducto
            // 
            this.panelAgregarProducto.Controls.Add(this.label17);
            this.panelAgregarProducto.Controls.Add(this.textCosto);
            this.panelAgregarProducto.Controls.Add(this.buttonLimpiar);
            this.panelAgregarProducto.Controls.Add(this.label12);
            this.panelAgregarProducto.Controls.Add(this.textColor);
            this.panelAgregarProducto.Controls.Add(this.comboTalle);
            this.panelAgregarProducto.Controls.Add(this.label11);
            this.panelAgregarProducto.Controls.Add(this.comboGrupo);
            this.panelAgregarProducto.Controls.Add(this.label10);
            this.panelAgregarProducto.Controls.Add(this.comboEstacion);
            this.panelAgregarProducto.Controls.Add(this.label9);
            this.panelAgregarProducto.Controls.Add(this.comboProveedor);
            this.panelAgregarProducto.Controls.Add(this.label8);
            this.panelAgregarProducto.Controls.Add(this.label7);
            this.panelAgregarProducto.Controls.Add(this.label6);
            this.panelAgregarProducto.Controls.Add(this.textPrecioEfectivo);
            this.panelAgregarProducto.Controls.Add(this.label2);
            this.panelAgregarProducto.Controls.Add(this.textPrecioLista);
            this.panelAgregarProducto.Controls.Add(this.label5);
            this.panelAgregarProducto.Controls.Add(this.textDescripcion);
            this.panelAgregarProducto.Controls.Add(this.label4);
            this.panelAgregarProducto.Controls.Add(this.buttonInsertar);
            this.panelAgregarProducto.Controls.Add(this.label3);
            this.panelAgregarProducto.Controls.Add(this.textNombre);
            this.panelAgregarProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAgregarProducto.Location = new System.Drawing.Point(0, 0);
            this.panelAgregarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.panelAgregarProducto.Name = "panelAgregarProducto";
            this.panelAgregarProducto.Size = new System.Drawing.Size(232, 530);
            this.panelAgregarProducto.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label17.Location = new System.Drawing.Point(26, 396);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 16);
            this.label17.TabIndex = 56;
            this.label17.Text = "Costo";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label17.Visible = false;
            // 
            // textCosto
            // 
            this.textCosto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCosto.Location = new System.Drawing.Point(28, 414);
            this.textCosto.Margin = new System.Windows.Forms.Padding(2);
            this.textCosto.Name = "textCosto";
            this.textCosto.Size = new System.Drawing.Size(87, 23);
            this.textCosto.TabIndex = 41;
            this.textCosto.Visible = false;
            this.textCosto.TextChanged += new System.EventHandler(this.textCosto_TextChanged);
            this.textCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCosto_KeyPress);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLimpiar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiar.Location = new System.Drawing.Point(146, 39);
            this.buttonLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(66, 21);
            this.buttonLimpiar.TabIndex = 55;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = false;
            this.buttonLimpiar.Visible = false;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(26, 272);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 16);
            this.label12.TabIndex = 54;
            this.label12.Text = "color";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label12.Visible = false;
            // 
            // textColor
            // 
            this.textColor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textColor.Location = new System.Drawing.Point(28, 291);
            this.textColor.Margin = new System.Windows.Forms.Padding(2);
            this.textColor.Name = "textColor";
            this.textColor.Size = new System.Drawing.Size(184, 23);
            this.textColor.TabIndex = 38;
            this.textColor.Visible = false;
            // 
            // comboTalle
            // 
            this.comboTalle.BackColor = System.Drawing.SystemColors.Control;
            this.comboTalle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTalle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboTalle.FormattingEnabled = true;
            this.comboTalle.ItemHeight = 16;
            this.comboTalle.Location = new System.Drawing.Point(28, 244);
            this.comboTalle.Margin = new System.Windows.Forms.Padding(2);
            this.comboTalle.Name = "comboTalle";
            this.comboTalle.Size = new System.Drawing.Size(184, 24);
            this.comboTalle.TabIndex = 37;
            this.comboTalle.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(26, 228);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 16);
            this.label11.TabIndex = 53;
            this.label11.Text = "talle";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label11.Visible = false;
            // 
            // comboGrupo
            // 
            this.comboGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboGrupo.BackColor = System.Drawing.SystemColors.Control;
            this.comboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrupo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGrupo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboGrupo.FormattingEnabled = true;
            this.comboGrupo.ItemHeight = 16;
            this.comboGrupo.Location = new System.Drawing.Point(28, 198);
            this.comboGrupo.Margin = new System.Windows.Forms.Padding(2);
            this.comboGrupo.Name = "comboGrupo";
            this.comboGrupo.Size = new System.Drawing.Size(184, 24);
            this.comboGrupo.TabIndex = 36;
            this.comboGrupo.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(26, 183);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 52;
            this.label10.Text = "grupo";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label10.Visible = false;
            // 
            // comboEstacion
            // 
            this.comboEstacion.BackColor = System.Drawing.SystemColors.Control;
            this.comboEstacion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstacion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboEstacion.FormattingEnabled = true;
            this.comboEstacion.ItemHeight = 16;
            this.comboEstacion.Items.AddRange(new object[] {
            "verano",
            "otoño",
            "primavera"});
            this.comboEstacion.Location = new System.Drawing.Point(28, 155);
            this.comboEstacion.Margin = new System.Windows.Forms.Padding(2);
            this.comboEstacion.Name = "comboEstacion";
            this.comboEstacion.Size = new System.Drawing.Size(184, 24);
            this.comboEstacion.TabIndex = 35;
            this.comboEstacion.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(26, 140);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 51;
            this.label9.Text = "estacion";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Visible = false;
            // 
            // comboProveedor
            // 
            this.comboProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.comboProveedor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProveedor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboProveedor.FormattingEnabled = true;
            this.comboProveedor.Location = new System.Drawing.Point(28, 340);
            this.comboProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.comboProveedor.Name = "comboProveedor";
            this.comboProveedor.Size = new System.Drawing.Size(184, 24);
            this.comboProveedor.TabIndex = 39;
            this.comboProveedor.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(26, 322);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 16);
            this.label8.TabIndex = 50;
            this.label8.Text = "proveedor";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(27, 375);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 16);
            this.label7.TabIndex = 49;
            this.label7.Text = "Stock (carga en Remito)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(122, 439);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 48;
            this.label6.Text = "Precio Efectivo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Visible = false;
            // 
            // textPrecioEfectivo
            // 
            this.textPrecioEfectivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPrecioEfectivo.Location = new System.Drawing.Point(125, 457);
            this.textPrecioEfectivo.Margin = new System.Windows.Forms.Padding(2);
            this.textPrecioEfectivo.Name = "textPrecioEfectivo";
            this.textPrecioEfectivo.Size = new System.Drawing.Size(87, 23);
            this.textPrecioEfectivo.TabIndex = 43;
            this.textPrecioEfectivo.Visible = false;
            this.textPrecioEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPrecioEfectivo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(26, 439);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Precio Lista";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Visible = false;
            // 
            // textPrecioLista
            // 
            this.textPrecioLista.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPrecioLista.Location = new System.Drawing.Point(28, 457);
            this.textPrecioLista.Margin = new System.Windows.Forms.Padding(2);
            this.textPrecioLista.Name = "textPrecioLista";
            this.textPrecioLista.Size = new System.Drawing.Size(87, 23);
            this.textPrecioLista.TabIndex = 42;
            this.textPrecioLista.Visible = false;
            this.textPrecioLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPrecioLista_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(26, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "descripcion";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Visible = false;
            // 
            // textDescripcion
            // 
            this.textDescripcion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescripcion.Location = new System.Drawing.Point(28, 112);
            this.textDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(184, 23);
            this.textDescripcion.TabIndex = 34;
            this.textDescripcion.Visible = false;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 34);
            this.label4.TabIndex = 45;
            this.label4.Text = "Nuevo Producto";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // buttonInsertar
            // 
            this.buttonInsertar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsertar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsertar.Location = new System.Drawing.Point(28, 496);
            this.buttonInsertar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInsertar.Name = "buttonInsertar";
            this.buttonInsertar.Size = new System.Drawing.Size(184, 29);
            this.buttonInsertar.TabIndex = 44;
            this.buttonInsertar.Text = "Actualizar Productos";
            this.buttonInsertar.UseVisualStyleBackColor = false;
            this.buttonInsertar.Click += new System.EventHandler(this.buttonInsertar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(26, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Nombre Articulo";
            this.label3.Visible = false;
            // 
            // textNombre
            // 
            this.textNombre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre.Location = new System.Drawing.Point(28, 65);
            this.textNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(184, 23);
            this.textNombre.TabIndex = 33;
            this.textNombre.Visible = false;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.groupBox4);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 80);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(2);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(952, 107);
            this.panelFiltros.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.textCodigo);
            this.groupBox4.Controls.Add(this.buttonTodos);
            this.groupBox4.Controls.Add(this.comboFiltroSucursal);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.buttonFiltrarNombre);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.textNombreFiltrar);
            this.groupBox4.Controls.Add(this.comboFiltroProveedor);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.comboFiltroGrupo);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(950, 105);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtros";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label20.Location = new System.Drawing.Point(4, 22);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 14);
            this.label20.TabIndex = 41;
            this.label20.Text = "Codigo Barras";
            // 
            // textCodigo
            // 
            this.textCodigo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCodigo.Location = new System.Drawing.Point(7, 43);
            this.textCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.Size = new System.Drawing.Size(184, 23);
            this.textCodigo.TabIndex = 39;
            this.textCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCodigo_KeyPress);
            // 
            // buttonTodos
            // 
            this.buttonTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonTodos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTodos.Location = new System.Drawing.Point(823, 37);
            this.buttonTodos.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTodos.Name = "buttonTodos";
            this.buttonTodos.Size = new System.Drawing.Size(68, 29);
            this.buttonTodos.TabIndex = 38;
            this.buttonTodos.Text = "Todos";
            this.buttonTodos.UseVisualStyleBackColor = false;
            this.buttonTodos.Click += new System.EventHandler(this.buttonTodos_Click);
            // 
            // comboFiltroSucursal
            // 
            this.comboFiltroSucursal.BackColor = System.Drawing.SystemColors.Control;
            this.comboFiltroSucursal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFiltroSucursal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboFiltroSucursal.FormattingEnabled = true;
            this.comboFiltroSucursal.ItemHeight = 14;
            this.comboFiltroSucursal.Items.AddRange(new object[] {
            "Stgo del Estero",
            "Galeria Palacio",
            "Pueyrredon",
            "Deposito"});
            this.comboFiltroSucursal.Location = new System.Drawing.Point(721, 41);
            this.comboFiltroSucursal.Margin = new System.Windows.Forms.Padding(2);
            this.comboFiltroSucursal.Name = "comboFiltroSucursal";
            this.comboFiltroSucursal.Size = new System.Drawing.Size(98, 22);
            this.comboFiltroSucursal.TabIndex = 36;
            this.comboFiltroSucursal.SelectedIndexChanged += new System.EventHandler(this.comboDestino_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label16.Location = new System.Drawing.Point(719, 22);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 14);
            this.label16.TabIndex = 37;
            this.label16.Text = "Sucursal";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonFiltrarNombre
            // 
            this.buttonFiltrarNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonFiltrarNombre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltrarNombre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonFiltrarNombre.Location = new System.Drawing.Point(431, 36);
            this.buttonFiltrarNombre.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFiltrarNombre.Name = "buttonFiltrarNombre";
            this.buttonFiltrarNombre.Size = new System.Drawing.Size(68, 29);
            this.buttonFiltrarNombre.TabIndex = 35;
            this.buttonFiltrarNombre.Text = "Filtrar";
            this.buttonFiltrarNombre.UseVisualStyleBackColor = false;
            this.buttonFiltrarNombre.Click += new System.EventHandler(this.buttonFiltrarNombre_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label15.Location = new System.Drawing.Point(234, 23);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 14);
            this.label15.TabIndex = 34;
            this.label15.Text = "Nombre del Articulo";
            // 
            // textNombreFiltrar
            // 
            this.textNombreFiltrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombreFiltrar.Location = new System.Drawing.Point(234, 42);
            this.textNombreFiltrar.Margin = new System.Windows.Forms.Padding(2);
            this.textNombreFiltrar.Name = "textNombreFiltrar";
            this.textNombreFiltrar.Size = new System.Drawing.Size(184, 23);
            this.textNombreFiltrar.TabIndex = 33;
            this.textNombreFiltrar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombreFiltrar_KeyPress);
            // 
            // comboFiltroProveedor
            // 
            this.comboFiltroProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.comboFiltroProveedor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFiltroProveedor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboFiltroProveedor.FormattingEnabled = true;
            this.comboFiltroProveedor.ItemHeight = 14;
            this.comboFiltroProveedor.Location = new System.Drawing.Point(619, 42);
            this.comboFiltroProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.comboFiltroProveedor.Name = "comboFiltroProveedor";
            this.comboFiltroProveedor.Size = new System.Drawing.Size(98, 22);
            this.comboFiltroProveedor.TabIndex = 32;
            this.comboFiltroProveedor.SelectedIndexChanged += new System.EventHandler(this.comboFiltroProveedor_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(616, 23);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 14);
            this.label13.TabIndex = 31;
            this.label13.Text = "Proveedor";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboFiltroGrupo
            // 
            this.comboFiltroGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboFiltroGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboFiltroGrupo.BackColor = System.Drawing.SystemColors.Control;
            this.comboFiltroGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFiltroGrupo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFiltroGrupo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboFiltroGrupo.FormattingEnabled = true;
            this.comboFiltroGrupo.ItemHeight = 14;
            this.comboFiltroGrupo.Location = new System.Drawing.Point(513, 42);
            this.comboFiltroGrupo.Margin = new System.Windows.Forms.Padding(2);
            this.comboFiltroGrupo.Name = "comboFiltroGrupo";
            this.comboFiltroGrupo.Size = new System.Drawing.Size(102, 22);
            this.comboFiltroGrupo.TabIndex = 24;
            this.comboFiltroGrupo.SelectedIndexChanged += new System.EventHandler(this.comboFiltroGrupo_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label14.Location = new System.Drawing.Point(511, 23);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 14);
            this.label14.TabIndex = 27;
            this.label14.Text = "Grupo";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelUtiles
            // 
            this.panelUtiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUtiles.Controls.Add(this.textIDProducto);
            this.panelUtiles.Controls.Add(this.buttonSeguimiento);
            this.panelUtiles.Controls.Add(this.label18);
            this.panelUtiles.Controls.Add(this.label19);
            this.panelUtiles.Controls.Add(this.textCantidadEtiqueta);
            this.panelUtiles.Controls.Add(this.buttonExportar);
            this.panelUtiles.Controls.Add(this.panelResultado);
            this.panelUtiles.Controls.Add(this.buttonGenerarEtiqueta);
            this.panelUtiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUtiles.Location = new System.Drawing.Point(0, 556);
            this.panelUtiles.Margin = new System.Windows.Forms.Padding(2);
            this.panelUtiles.Name = "panelUtiles";
            this.panelUtiles.Size = new System.Drawing.Size(952, 56);
            this.panelUtiles.TabIndex = 3;
            // 
            // textIDProducto
            // 
            this.textIDProducto.AutoSize = true;
            this.textIDProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIDProducto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textIDProducto.Location = new System.Drawing.Point(53, 1);
            this.textIDProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textIDProducto.Name = "textIDProducto";
            this.textIDProducto.Size = new System.Drawing.Size(91, 13);
            this.textIDProducto.TabIndex = 32;
            this.textIDProducto.Text = "00000000000000";
            this.textIDProducto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonSeguimiento
            // 
            this.buttonSeguimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonSeguimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeguimiento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeguimiento.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSeguimiento.Location = new System.Drawing.Point(4, 15);
            this.buttonSeguimiento.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeguimiento.Name = "buttonSeguimiento";
            this.buttonSeguimiento.Size = new System.Drawing.Size(178, 29);
            this.buttonSeguimiento.TabIndex = 31;
            this.buttonSeguimiento.Text = "Seguimiento Producto";
            this.buttonSeguimiento.UseVisualStyleBackColor = false;
            this.buttonSeguimiento.Click += new System.EventHandler(this.buttonSeguimiento_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label18.Location = new System.Drawing.Point(511, 32);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 30;
            this.label18.Text = "21 Max";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label19.Location = new System.Drawing.Point(417, 15);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 14);
            this.label19.TabIndex = 29;
            this.label19.Text = "Cantidad Etiquetas";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textCantidadEtiqueta
            // 
            this.textCantidadEtiqueta.AutoSize = true;
            this.textCantidadEtiqueta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCantidadEtiqueta.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textCantidadEtiqueta.Location = new System.Drawing.Point(462, 32);
            this.textCantidadEtiqueta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textCantidadEtiqueta.Name = "textCantidadEtiqueta";
            this.textCantidadEtiqueta.Size = new System.Drawing.Size(14, 14);
            this.textCantidadEtiqueta.TabIndex = 28;
            this.textCantidadEtiqueta.Text = "0";
            this.textCantidadEtiqueta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonExportar
            // 
            this.buttonExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonExportar.Enabled = false;
            this.buttonExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonExportar.Location = new System.Drawing.Point(185, 15);
            this.buttonExportar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExportar.Name = "buttonExportar";
            this.buttonExportar.Size = new System.Drawing.Size(178, 29);
            this.buttonExportar.TabIndex = 13;
            this.buttonExportar.Text = "Exportar Excel";
            this.buttonExportar.UseVisualStyleBackColor = false;
            this.buttonExportar.Click += new System.EventHandler(this.buttonExportar_Click);
            // 
            // panelResultado
            // 
            this.panelResultado.Location = new System.Drawing.Point(746, 6);
            this.panelResultado.Margin = new System.Windows.Forms.Padding(2);
            this.panelResultado.Name = "panelResultado";
            this.panelResultado.Size = new System.Drawing.Size(194, 45);
            this.panelResultado.TabIndex = 12;
            // 
            // buttonGenerarEtiqueta
            // 
            this.buttonGenerarEtiqueta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonGenerarEtiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerarEtiqueta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerarEtiqueta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonGenerarEtiqueta.Location = new System.Drawing.Point(562, 15);
            this.buttonGenerarEtiqueta.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGenerarEtiqueta.Name = "buttonGenerarEtiqueta";
            this.buttonGenerarEtiqueta.Size = new System.Drawing.Size(178, 29);
            this.buttonGenerarEtiqueta.TabIndex = 11;
            this.buttonGenerarEtiqueta.Text = "Generar Etiqueta";
            this.buttonGenerarEtiqueta.UseVisualStyleBackColor = false;
            this.buttonGenerarEtiqueta.Click += new System.EventHandler(this.buttonGenerarEtiqueta_Click);
            // 
            // panelTabla
            // 
            this.panelTabla.Controls.Add(this.dataGridProductos);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Location = new System.Drawing.Point(0, 187);
            this.panelTabla.Margin = new System.Windows.Forms.Padding(2);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(952, 369);
            this.panelTabla.TabIndex = 4;
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.AllowUserToResizeColumns = false;
            this.dataGridProductos.AllowUserToResizeRows = false;
            this.dataGridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridProductos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.descripcion,
            this.stock,
            this.deposito,
            this.cantStgo,
            this.cantGal,
            this.Pueyrredon,
            this.proveedor,
            this.estacion,
            this.color,
            this.talle,
            this.grupo,
            this.precio_lista,
            this.precio_efectivo,
            this.costo,
            this.fecha,
            this.etiqueta});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridProductos.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridProductos.Location = new System.Drawing.Point(0, 0);
            this.dataGridProductos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.RowHeadersVisible = false;
            this.dataGridProductos.RowHeadersWidth = 51;
            this.dataGridProductos.RowTemplate.Height = 24;
            this.dataGridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProductos.Size = new System.Drawing.Size(952, 369);
            this.dataGridProductos.TabIndex = 0;
            this.dataGridProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProductos_CellContentClick);
            this.dataGridProductos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridProductos_CellMouseClick);
            this.dataGridProductos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridProductos_CellMouseDown);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 40;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.Width = 73;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 96;
            // 
            // stock
            // 
            this.stock.HeaderText = "stock Gral";
            this.stock.MinimumWidth = 6;
            this.stock.Name = "stock";
            this.stock.Width = 80;
            // 
            // deposito
            // 
            this.deposito.HeaderText = "deposito";
            this.deposito.MinimumWidth = 6;
            this.deposito.Name = "deposito";
            this.deposito.Width = 78;
            // 
            // cantStgo
            // 
            this.cantStgo.HeaderText = "Stgo del Estero";
            this.cantStgo.MinimumWidth = 6;
            this.cantStgo.Name = "cantStgo";
            this.cantStgo.Width = 105;
            // 
            // cantGal
            // 
            this.cantGal.HeaderText = "Galeria Palacio";
            this.cantGal.MinimumWidth = 6;
            this.cantGal.Name = "cantGal";
            this.cantGal.Width = 105;
            // 
            // Pueyrredon
            // 
            this.Pueyrredon.HeaderText = "Pueyrredon";
            this.Pueyrredon.MinimumWidth = 6;
            this.Pueyrredon.Name = "Pueyrredon";
            this.Pueyrredon.Width = 95;
            // 
            // proveedor
            // 
            this.proveedor.HeaderText = "proveedor";
            this.proveedor.MinimumWidth = 6;
            this.proveedor.Name = "proveedor";
            this.proveedor.Width = 88;
            // 
            // estacion
            // 
            this.estacion.HeaderText = "estacion";
            this.estacion.MinimumWidth = 6;
            this.estacion.Name = "estacion";
            this.estacion.Width = 78;
            // 
            // color
            // 
            this.color.HeaderText = "color";
            this.color.MinimumWidth = 6;
            this.color.Name = "color";
            this.color.Width = 59;
            // 
            // talle
            // 
            this.talle.HeaderText = "talle";
            this.talle.MinimumWidth = 6;
            this.talle.Name = "talle";
            this.talle.Width = 54;
            // 
            // grupo
            // 
            this.grupo.HeaderText = "grupo";
            this.grupo.MinimumWidth = 6;
            this.grupo.Name = "grupo";
            this.grupo.Width = 63;
            // 
            // precio_lista
            // 
            this.precio_lista.HeaderText = "precio lista";
            this.precio_lista.MinimumWidth = 6;
            this.precio_lista.Name = "precio_lista";
            this.precio_lista.Width = 85;
            // 
            // precio_efectivo
            // 
            this.precio_efectivo.HeaderText = "precio efectivo";
            this.precio_efectivo.MinimumWidth = 6;
            this.precio_efectivo.Name = "precio_efectivo";
            this.precio_efectivo.Width = 105;
            // 
            // costo
            // 
            this.costo.HeaderText = "costo";
            this.costo.MinimumWidth = 6;
            this.costo.Name = "costo";
            this.costo.Width = 61;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.Width = 62;
            // 
            // etiqueta
            // 
            this.etiqueta.HeaderText = "etiqueta";
            this.etiqueta.Name = "etiqueta";
            this.etiqueta.Width = 76;
            // 
            // ProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1186, 612);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelUtiles);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelInsert);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRODUCTOS";
            this.Load += new System.EventHandler(this.ProductosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelInsert.ResumeLayout(false);
            this.panelAgregarProducto.ResumeLayout(false);
            this.panelAgregarProducto.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelUtiles.ResumeLayout(false);
            this.panelUtiles.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelInsert;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Panel panelUtiles;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.DataGridView dataGridProductos;
        private System.Windows.Forms.Button buttonGenerarEtiqueta;
        private System.Windows.Forms.Panel panelResultado;
        private System.Windows.Forms.Button buttonExportar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboFiltroProveedor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboFiltroGrupo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonFiltrarNombre;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textNombreFiltrar;
        private System.Windows.Forms.Button buttonMinimizar;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.ComboBox comboFiltroSucursal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelAgregarProducto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textCosto;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textColor;
        private System.Windows.Forms.ComboBox comboTalle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboGrupo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboEstacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textPrecioEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPrecioLista;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonInsertar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Button buttonTodos;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label textCantidadEtiqueta;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Button buttonObtenerID;
        private System.Windows.Forms.Button buttonSeguimiento;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label textIDProducto;
        private System.Windows.Forms.TextBox textRemito;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn deposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantStgo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantGal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pueyrredon;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn estacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn talle;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_lista;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_efectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn etiqueta;
    }
}