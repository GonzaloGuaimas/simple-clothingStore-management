
namespace GiftGestion.Flotante
{
    partial class SeguimientoProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeguimientoProducto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textInformacionProducto = new System.Windows.Forms.Label();
            this.groupVentas = new System.Windows.Forms.GroupBox();
            this.dataGridVentas = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupRemitos = new System.Windows.Forms.GroupBox();
            this.dataGridRemitos = new System.Windows.Forms.DataGridView();
            this.fechaRem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadRem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).BeginInit();
            this.groupRemitos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRemitos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textInformacionProducto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 70);
            this.panel1.TabIndex = 2;
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
            this.textInformacionProducto.Text = "Informacion Producto";
            this.textInformacionProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupVentas
            // 
            this.groupVentas.Controls.Add(this.dataGridVentas);
            this.groupVentas.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupVentas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupVentas.Location = new System.Drawing.Point(0, 70);
            this.groupVentas.Name = "groupVentas";
            this.groupVentas.Size = new System.Drawing.Size(331, 380);
            this.groupVentas.TabIndex = 4;
            this.groupVentas.TabStop = false;
            this.groupVentas.Text = "VENTAS";
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.cantidad,
            this.sucursal,
            this.usuario});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridVentas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridVentas.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridVentas.Location = new System.Drawing.Point(3, 16);
            this.dataGridVentas.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridVentas.Name = "dataGridVentas";
            this.dataGridVentas.ReadOnly = true;
            this.dataGridVentas.RowHeadersVisible = false;
            this.dataGridVentas.RowHeadersWidth = 51;
            this.dataGridVentas.RowTemplate.Height = 24;
            this.dataGridVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridVentas.Size = new System.Drawing.Size(325, 361);
            this.dataGridVentas.TabIndex = 2;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 62;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 79;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "sucursal";
            this.sucursal.Name = "sucursal";
            this.sucursal.ReadOnly = true;
            this.sucursal.Width = 78;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "usuario";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            this.usuario.Width = 72;
            // 
            // groupRemitos
            // 
            this.groupRemitos.Controls.Add(this.dataGridRemitos);
            this.groupRemitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRemitos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupRemitos.Location = new System.Drawing.Point(331, 70);
            this.groupRemitos.Name = "groupRemitos";
            this.groupRemitos.Size = new System.Drawing.Size(469, 380);
            this.groupRemitos.TabIndex = 5;
            this.groupRemitos.TabStop = false;
            this.groupRemitos.Text = "REMITOS";
            // 
            // dataGridRemitos
            // 
            this.dataGridRemitos.AllowUserToResizeColumns = false;
            this.dataGridRemitos.AllowUserToResizeRows = false;
            this.dataGridRemitos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridRemitos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridRemitos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridRemitos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridRemitos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridRemitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRemitos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaRem,
            this.tipo,
            this.cantidadRem,
            this.destino,
            this.observacion});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridRemitos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridRemitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridRemitos.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridRemitos.Location = new System.Drawing.Point(3, 16);
            this.dataGridRemitos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridRemitos.Name = "dataGridRemitos";
            this.dataGridRemitos.ReadOnly = true;
            this.dataGridRemitos.RowHeadersVisible = false;
            this.dataGridRemitos.RowHeadersWidth = 51;
            this.dataGridRemitos.RowTemplate.Height = 24;
            this.dataGridRemitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRemitos.Size = new System.Drawing.Size(463, 361);
            this.dataGridRemitos.TabIndex = 3;
            // 
            // fechaRem
            // 
            this.fechaRem.HeaderText = "fecha";
            this.fechaRem.Name = "fechaRem";
            this.fechaRem.ReadOnly = true;
            this.fechaRem.Width = 62;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 51;
            // 
            // cantidadRem
            // 
            this.cantidadRem.HeaderText = "cantidad";
            this.cantidadRem.Name = "cantidadRem";
            this.cantidadRem.ReadOnly = true;
            this.cantidadRem.Width = 79;
            // 
            // destino
            // 
            this.destino.HeaderText = "destino";
            this.destino.Name = "destino";
            this.destino.ReadOnly = true;
            this.destino.Width = 71;
            // 
            // observacion
            // 
            this.observacion.HeaderText = "observacion";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 99;
            // 
            // SeguimientoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupRemitos);
            this.Controls.Add(this.groupVentas);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeguimientoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeguimientoProducto";
            this.Load += new System.EventHandler(this.SeguimientoProducto_Load);
            this.panel1.ResumeLayout(false);
            this.groupVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).EndInit();
            this.groupRemitos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRemitos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupVentas;
        private System.Windows.Forms.DataGridView dataGridVentas;
        private System.Windows.Forms.GroupBox groupRemitos;
        private System.Windows.Forms.DataGridView dataGridRemitos;
        private System.Windows.Forms.Label textInformacionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadRem;
        private System.Windows.Forms.DataGridViewTextBoxColumn destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
    }
}