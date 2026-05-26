namespace ClienteComputador
{
    partial class GUIBuscarComputador
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            btnBuscar = new Button();
            btnCerrar = new Button();
            label1 = new Label();
            txtBuscarMarca = new TextBox();
            label2 = new Label();
            dptFechaBuscar = new DateTimePicker();
            label3 = new Label();
            txtEstado = new TextBox();
            label4 = new Label();
            chkPortatil = new CheckBox();
            label5 = new Label();
            txtCosto = new TextBox();
            label6 = new Label();
            txtPerifericos = new TextBox();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(70, 130, 180);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(560, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Buscar Computador";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(12, 55);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(49, 15);
            lblCodigo.TabIndex = 1;
            lblCodigo.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(70, 52);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(120, 23);
            txtCodigo.TabIndex = 2;
            txtCodigo.TextChanged += txtCodigo_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(70, 130, 180);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(200, 50);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 27);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(482, 352);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(90, 27);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 108);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 6;
            label1.Text = "Marca:";
            label1.Click += label1_Click;
            // 
            // txtBuscarMarca
            // 
            txtBuscarMarca.Location = new Point(70, 105);
            txtBuscarMarca.Name = "txtBuscarMarca";
            txtBuscarMarca.Size = new Size(120, 23);
            txtBuscarMarca.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 151);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 8;
            label2.Text = "Fecha de fabricación:";
            // 
            // dptFechaBuscar
            // 
            dptFechaBuscar.Location = new Point(143, 145);
            dptFechaBuscar.Name = "dptFechaBuscar";
            dptFechaBuscar.Size = new Size(215, 23);
            dptFechaBuscar.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 185);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 10;
            label3.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(70, 182);
            txtEstado.Name = "txtEstado";
            txtEstado.PlaceholderText = "Ej: bueno, malo, regular";
            txtEstado.Size = new Size(149, 23);
            txtEstado.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 223);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 12;
            label4.Text = "Es portatil:";
            // 
            // chkPortatil
            // 
            chkPortatil.AutoSize = true;
            chkPortatil.Location = new Point(86, 223);
            chkPortatil.Name = "chkPortatil";
            chkPortatil.Size = new Size(35, 19);
            chkPortatil.TabIndex = 13;
            chkPortatil.Text = "Sí";
            chkPortatil.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 257);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 14;
            label5.Text = "Costo:";
            label5.Click += label5_Click;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(66, 254);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(100, 23);
            txtCosto.TabIndex = 15;
            txtCosto.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 297);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 16;
            label6.Text = "Perifericos:";
            // 
            // txtPerifericos
            // 
            txtPerifericos.Location = new Point(93, 294);
            txtPerifericos.Name = "txtPerifericos";
            txtPerifericos.PlaceholderText = "teclado, mouse, monitor";
            txtPerifericos.Size = new Size(197, 23);
            txtPerifericos.TabIndex = 17;
            // 
            // GUIBuscarComputador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(590, 391);
            Controls.Add(txtPerifericos);
            Controls.Add(label6);
            Controls.Add(txtCosto);
            Controls.Add(label5);
            Controls.Add(chkPortatil);
            Controls.Add(label4);
            Controls.Add(txtEstado);
            Controls.Add(label3);
            Controls.Add(dptFechaBuscar);
            Controls.Add(label2);
            Controls.Add(txtBuscarMarca);
            Controls.Add(label1);
            Controls.Add(lblTitulo);
            Controls.Add(lblCodigo);
            Controls.Add(txtCodigo);
            Controls.Add(btnBuscar);
            Controls.Add(btnCerrar);
            Name = "GUIBuscarComputador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar Computador";
            Load += GUIBuscarComputador_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo, lblCodigo;
        private TextBox txtCodigo;
        private Button btnBuscar, btnCerrar;
        private Label label1;
        private TextBox txtBuscarMarca;
        private Label label2;
        private DateTimePicker dptFechaBuscar;
        private Label label3;
        private TextBox txtEstado;
        private Label label4;
        private CheckBox chkPortatil;
        private Label label5;
        private TextBox txtCosto;
        private Label label6;
        private TextBox txtPerifericos;
    }
}
