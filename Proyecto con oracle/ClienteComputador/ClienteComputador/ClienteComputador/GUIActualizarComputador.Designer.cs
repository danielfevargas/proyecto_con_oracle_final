namespace ClienteComputador
{
    partial class GUIActualizarComputador
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
            lblBuscar = new Label();
            txtCodigo = new TextBox();
            btnBuscar = new Button();
            dgvResultado = new DataGridView();
            lblSeparador = new Label();
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblEstado = new Label();
            txtEstado = new TextBox();
            lblPortatil = new Label();
            chkPortatil = new CheckBox();
            lblCosto = new Label();
            txtCosto = new TextBox();
            lblPerifericos = new Label();
            txtPerifericos = new TextBox();
            btnActualizar = new Button();
            btnCerrar = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvResultado).BeginInit();
            SuspendLayout();

            lblTitulo.AutoSize = false;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(70, 130, 180);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Size = new Size(550, 30);
            lblTitulo.Text = "Actualizar Computador";

            // Busqueda
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 52);
            lblBuscar.Text = "Codigo:";

            txtCodigo.Location = new Point(70, 49);
            txtCodigo.Size = new Size(120, 23);

            btnBuscar.BackColor = Color.FromArgb(70, 130, 180);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(200, 47);
            btnBuscar.Size = new Size(90, 27);
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += new EventHandler(btnBuscar_Click);

            dgvResultado.Location = new Point(12, 85);
            dgvResultado.Size = new Size(560, 90);
            dgvResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultado.ReadOnly = true;
            dgvResultado.AllowUserToAddRows = false;
            dgvResultado.RowHeadersVisible = false;
            dgvResultado.BackgroundColor = Color.White;

            // Separador
            lblSeparador.AutoSize = false;
            lblSeparador.BorderStyle = BorderStyle.Fixed3D;
            lblSeparador.Location = new Point(12, 185);
            lblSeparador.Size = new Size(560, 2);

            // Campos de edicion
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(12, 198);
            lblMarca.Text = "Marca:";
            txtMarca.Location = new Point(110, 195);
            txtMarca.Size = new Size(180, 23);

            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(12, 233);
            lblFecha.Text = "Fecha fabr.:";
            dtpFecha.Location = new Point(110, 230);
            dtpFecha.Size = new Size(180, 23);
            dtpFecha.Format = DateTimePickerFormat.Short;

            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(12, 268);
            lblEstado.Text = "Estado:";
            txtEstado.Location = new Point(110, 265);
            txtEstado.Size = new Size(180, 23);

            lblPortatil.AutoSize = true;
            lblPortatil.Location = new Point(12, 303);
            lblPortatil.Text = "Es portatil:";
            chkPortatil.Location = new Point(110, 301);
            chkPortatil.Size = new Size(60, 23);
            chkPortatil.Text = "Si";

            lblCosto.AutoSize = true;
            lblCosto.Location = new Point(320, 198);
            lblCosto.Text = "Costo:";
            txtCosto.Location = new Point(375, 195);
            txtCosto.Size = new Size(150, 23);

            lblPerifericos.AutoSize = true;
            lblPerifericos.Location = new Point(320, 233);
            lblPerifericos.Text = "Perifericos:";
            txtPerifericos.Location = new Point(400, 230);
            txtPerifericos.Size = new Size(160, 23);
            txtPerifericos.PlaceholderText = "mouse, teclado";

            btnActualizar.BackColor = Color.FromArgb(40, 167, 69);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Location = new Point(12, 345);
            btnActualizar.Size = new Size(130, 30);
            btnActualizar.Text = "Guardar cambios";
            btnActualizar.Enabled = false;
            btnActualizar.Click += new EventHandler(btnActualizar_Click);

            btnCerrar.Location = new Point(480, 345);
            btnCerrar.Size = new Size(90, 30);
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += new EventHandler(btnCerrar_Click);

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(590, 395);
            Controls.Add(lblTitulo);
            Controls.Add(lblBuscar); Controls.Add(txtCodigo); Controls.Add(btnBuscar);
            Controls.Add(dgvResultado);
            Controls.Add(lblSeparador);
            Controls.Add(lblMarca); Controls.Add(txtMarca);
            Controls.Add(lblFecha); Controls.Add(dtpFecha);
            Controls.Add(lblEstado); Controls.Add(txtEstado);
            Controls.Add(lblPortatil); Controls.Add(chkPortatil);
            Controls.Add(lblCosto); Controls.Add(txtCosto);
            Controls.Add(lblPerifericos); Controls.Add(txtPerifericos);
            Controls.Add(btnActualizar); Controls.Add(btnCerrar);
            Name = "GUIActualizarComputador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar Computador";

            ((System.ComponentModel.ISupportInitialize)dgvResultado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo, lblBuscar, lblMarca, lblFecha, lblEstado, lblPortatil, lblCosto, lblPerifericos, lblSeparador;
        private TextBox txtCodigo, txtMarca, txtEstado, txtCosto, txtPerifericos;
        private DateTimePicker dtpFecha;
        private CheckBox chkPortatil;
        private Button btnBuscar, btnActualizar, btnCerrar;
        private DataGridView dgvResultado;
    }
}
