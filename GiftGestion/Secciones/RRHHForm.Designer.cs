
namespace GiftGestion.Secciones
{
    partial class RRHHForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RRHHForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupAgregarUsuario = new System.Windows.Forms.GroupBox();
            this.comboRol = new System.Windows.Forms.ComboBox();
            this.comboSucursal = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textContraseña = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textDNI = new System.Windows.Forms.TextBox();
            this.buttonAgregarUsuario = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.panelMitad1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridUsuarios = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTRASEÑA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUCURSAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridRoles = new System.Windows.Forms.DataGridView();
            this.Tarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textDNIUsuario = new System.Windows.Forms.Label();
            this.buttonActualizarRoles = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupAgregarUsuario.SuspendLayout();
            this.panelMitad1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRoles)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 125);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1370, 125);
            this.label1.TabIndex = 5;
            this.label1.Text = "RRHH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupAgregarUsuario
            // 
            this.groupAgregarUsuario.Controls.Add(this.comboRol);
            this.groupAgregarUsuario.Controls.Add(this.comboSucursal);
            this.groupAgregarUsuario.Controls.Add(this.label11);
            this.groupAgregarUsuario.Controls.Add(this.textEmail);
            this.groupAgregarUsuario.Controls.Add(this.label10);
            this.groupAgregarUsuario.Controls.Add(this.label9);
            this.groupAgregarUsuario.Controls.Add(this.textContraseña);
            this.groupAgregarUsuario.Controls.Add(this.label8);
            this.groupAgregarUsuario.Controls.Add(this.label6);
            this.groupAgregarUsuario.Controls.Add(this.textDNI);
            this.groupAgregarUsuario.Controls.Add(this.buttonAgregarUsuario);
            this.groupAgregarUsuario.Controls.Add(this.label3);
            this.groupAgregarUsuario.Controls.Add(this.textNombre);
            this.groupAgregarUsuario.Controls.Add(this.label2);
            this.groupAgregarUsuario.Controls.Add(this.textApellido);
            this.groupAgregarUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupAgregarUsuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAgregarUsuario.Location = new System.Drawing.Point(0, 125);
            this.groupAgregarUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.groupAgregarUsuario.Name = "groupAgregarUsuario";
            this.groupAgregarUsuario.Padding = new System.Windows.Forms.Padding(4);
            this.groupAgregarUsuario.Size = new System.Drawing.Size(1370, 114);
            this.groupAgregarUsuario.TabIndex = 5;
            this.groupAgregarUsuario.TabStop = false;
            this.groupAgregarUsuario.Text = "Agregar Usuario";
            // 
            // comboRol
            // 
            this.comboRol.BackColor = System.Drawing.SystemColors.Control;
            this.comboRol.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRol.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboRol.FormattingEnabled = true;
            this.comboRol.ItemHeight = 14;
            this.comboRol.Items.AddRange(new object[] {
            "Super",
            "Admin",
            "Vendedor"});
            this.comboRol.Location = new System.Drawing.Point(521, 66);
            this.comboRol.Margin = new System.Windows.Forms.Padding(2);
            this.comboRol.Name = "comboRol";
            this.comboRol.Size = new System.Drawing.Size(122, 22);
            this.comboRol.TabIndex = 58;
            this.comboRol.SelectedIndexChanged += new System.EventHandler(this.comboRol_SelectedIndexChanged);
            // 
            // comboSucursal
            // 
            this.comboSucursal.BackColor = System.Drawing.SystemColors.Control;
            this.comboSucursal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSucursal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboSucursal.FormattingEnabled = true;
            this.comboSucursal.ItemHeight = 14;
            this.comboSucursal.Items.AddRange(new object[] {
            "Pueyrredon",
            "Stgo del Estero",
            "-"});
            this.comboSucursal.Location = new System.Drawing.Point(854, 66);
            this.comboSucursal.Margin = new System.Windows.Forms.Padding(2);
            this.comboSucursal.Name = "comboSucursal";
            this.comboSucursal.Size = new System.Drawing.Size(122, 22);
            this.comboSucursal.TabIndex = 57;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(1031, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 16);
            this.label11.TabIndex = 56;
            this.label11.Text = "EMAIL";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textEmail
            // 
            this.textEmail.Enabled = false;
            this.textEmail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEmail.Location = new System.Drawing.Point(1035, 64);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(119, 23);
            this.textEmail.TabIndex = 55;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(851, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 16);
            this.label10.TabIndex = 54;
            this.label10.Text = "SUCURSAL";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(678, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 16);
            this.label9.TabIndex = 52;
            this.label9.Text = "CONTRASEÑA";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textContraseña
            // 
            this.textContraseña.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textContraseña.Location = new System.Drawing.Point(682, 64);
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.Size = new System.Drawing.Size(119, 23);
            this.textContraseña.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(518, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 16);
            this.label8.TabIndex = 50;
            this.label8.Text = "ROL";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(24, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 48;
            this.label6.Text = "DNI";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textDNI
            // 
            this.textDNI.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDNI.Location = new System.Drawing.Point(28, 64);
            this.textDNI.Name = "textDNI";
            this.textDNI.Size = new System.Drawing.Size(119, 23);
            this.textDNI.TabIndex = 47;
            // 
            // buttonAgregarUsuario
            // 
            this.buttonAgregarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonAgregarUsuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarUsuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAgregarUsuario.Location = new System.Drawing.Point(1251, 57);
            this.buttonAgregarUsuario.Name = "buttonAgregarUsuario";
            this.buttonAgregarUsuario.Size = new System.Drawing.Size(107, 36);
            this.buttonAgregarUsuario.TabIndex = 46;
            this.buttonAgregarUsuario.Text = "Agregar";
            this.buttonAgregarUsuario.UseVisualStyleBackColor = false;
            this.buttonAgregarUsuario.Click += new System.EventHandler(this.buttonAgregarUsuario_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(349, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Nombre";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textNombre
            // 
            this.textNombre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre.Location = new System.Drawing.Point(353, 64);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(119, 23);
            this.textNombre.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(194, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Apellido";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textApellido
            // 
            this.textApellido.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textApellido.Location = new System.Drawing.Point(198, 64);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(119, 23);
            this.textApellido.TabIndex = 30;
            // 
            // panelMitad1
            // 
            this.panelMitad1.Controls.Add(this.groupBox2);
            this.panelMitad1.Controls.Add(this.groupBox4);
            this.panelMitad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMitad1.Location = new System.Drawing.Point(0, 239);
            this.panelMitad1.Name = "panelMitad1";
            this.panelMitad1.Size = new System.Drawing.Size(1370, 510);
            this.panelMitad1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridUsuarios);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(815, 510);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuarios (click derecho para eliminar)";
            // 
            // dataGridUsuarios
            // 
            this.dataGridUsuarios.AllowUserToResizeColumns = false;
            this.dataGridUsuarios.AllowUserToResizeRows = false;
            this.dataGridUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridUsuarios.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI,
            this.Apellido,
            this.Nombre,
            this.ROL,
            this.CONTRASEÑA,
            this.SUCURSAL,
            this.EMAIL});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridUsuarios.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridUsuarios.Location = new System.Drawing.Point(4, 20);
            this.dataGridUsuarios.Name = "dataGridUsuarios";
            this.dataGridUsuarios.ReadOnly = true;
            this.dataGridUsuarios.RowHeadersVisible = false;
            this.dataGridUsuarios.RowHeadersWidth = 51;
            this.dataGridUsuarios.RowTemplate.Height = 24;
            this.dataGridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUsuarios.Size = new System.Drawing.Size(807, 486);
            this.dataGridUsuarios.TabIndex = 49;
            this.dataGridUsuarios.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridUsuarios_CellMouseClick);
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Width = 58;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 89;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 87;
            // 
            // ROL
            // 
            this.ROL.HeaderText = "ROL";
            this.ROL.Name = "ROL";
            this.ROL.ReadOnly = true;
            this.ROL.Width = 62;
            // 
            // CONTRASEÑA
            // 
            this.CONTRASEÑA.HeaderText = "CONTRASEÑA";
            this.CONTRASEÑA.Name = "CONTRASEÑA";
            this.CONTRASEÑA.ReadOnly = true;
            this.CONTRASEÑA.Width = 133;
            // 
            // SUCURSAL
            // 
            this.SUCURSAL.HeaderText = "SUCURSAL";
            this.SUCURSAL.Name = "SUCURSAL";
            this.SUCURSAL.ReadOnly = true;
            this.SUCURSAL.Width = 111;
            // 
            // EMAIL
            // 
            this.EMAIL.HeaderText = "EMAIL";
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.ReadOnly = true;
            this.EMAIL.Width = 76;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridRoles);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.buttonActualizarRoles);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(815, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(555, 510);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PERMISOS USUARIO";
            // 
            // dataGridRoles
            // 
            this.dataGridRoles.AllowUserToResizeColumns = false;
            this.dataGridRoles.AllowUserToResizeRows = false;
            this.dataGridRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridRoles.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridRoles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tarea,
            this.SI,
            this.NO});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridRoles.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridRoles.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridRoles.Location = new System.Drawing.Point(4, 109);
            this.dataGridRoles.Name = "dataGridRoles";
            this.dataGridRoles.RowHeadersVisible = false;
            this.dataGridRoles.RowHeadersWidth = 51;
            this.dataGridRoles.RowTemplate.Height = 24;
            this.dataGridRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRoles.Size = new System.Drawing.Size(547, 361);
            this.dataGridRoles.TabIndex = 5;
            // 
            // Tarea
            // 
            this.Tarea.HeaderText = "Tarea";
            this.Tarea.Name = "Tarea";
            // 
            // SI
            // 
            this.SI.HeaderText = "SI";
            this.SI.Name = "SI";
            this.SI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NO
            // 
            this.NO.HeaderText = "NO";
            this.NO.Name = "NO";
            this.NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textDNIUsuario);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(4, 20);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(547, 89);
            this.groupBox5.TabIndex = 48;
            this.groupBox5.TabStop = false;
            // 
            // textDNIUsuario
            // 
            this.textDNIUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textDNIUsuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDNIUsuario.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textDNIUsuario.Location = new System.Drawing.Point(4, 20);
            this.textDNIUsuario.Name = "textDNIUsuario";
            this.textDNIUsuario.Size = new System.Drawing.Size(539, 65);
            this.textDNIUsuario.TabIndex = 51;
            this.textDNIUsuario.Text = "Usuario: 00000000";
            this.textDNIUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonActualizarRoles
            // 
            this.buttonActualizarRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonActualizarRoles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonActualizarRoles.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActualizarRoles.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonActualizarRoles.Location = new System.Drawing.Point(4, 470);
            this.buttonActualizarRoles.Name = "buttonActualizarRoles";
            this.buttonActualizarRoles.Size = new System.Drawing.Size(547, 36);
            this.buttonActualizarRoles.TabIndex = 47;
            this.buttonActualizarRoles.Text = "Actualizar";
            this.buttonActualizarRoles.UseVisualStyleBackColor = false;
            this.buttonActualizarRoles.Click += new System.EventHandler(this.buttonActualizarRoles_Click);
            // 
            // RRHHForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelMitad1);
            this.Controls.Add(this.groupAgregarUsuario);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RRHHForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RRHHForm";
            this.Load += new System.EventHandler(this.RRHHForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupAgregarUsuario.ResumeLayout(false);
            this.groupAgregarUsuario.PerformLayout();
            this.panelMitad1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuarios)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRoles)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupAgregarUsuario;
        private System.Windows.Forms.Button buttonAgregarUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.Panel panelMitad1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridRoles;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonActualizarRoles;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textContraseña;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDNI;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTRASEÑA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUCURSAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarea;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NO;
        private System.Windows.Forms.Label textDNIUsuario;
        private System.Windows.Forms.ComboBox comboSucursal;
        private System.Windows.Forms.ComboBox comboRol;
    }
}