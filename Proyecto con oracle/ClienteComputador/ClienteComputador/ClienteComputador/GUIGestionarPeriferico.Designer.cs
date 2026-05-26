namespace ClienteComputador
{
    partial class GUIGestionarPeriferico
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCodigoComputador = new TextBox();
            this.btnBuscarComputador = new Button();
            this.lblComputador = new Label();
            this.dgvPerifericos = new DataGridView();
            this.txtNombre = new TextBox();
            this.cmbTipo = new ComboBox();
            this.btnAgregar = new Button();
            this.btnEditar = new Button();
            this.btnEliminar = new Button();
            this.btnCerrar = new Button();
            this.panelEditar = new Panel();
            this.txtNombreEditar = new TextBox();
            this.cmbTipoEditar = new ComboBox();
            this.btnGuardarEdicion = new Button();
            this.btnCancelarEdicion = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPerifericos)).BeginInit();
            this.panelEditar.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text = "Gestionar Perifericos";
            this.Size = new Size(700, 580);

            // txtCodigoComputador
            this.txtCodigoComputador.Location = new Point(12, 12);
            this.txtCodigoComputador.Size = new Size(120, 23);
            this.txtCodigoComputador.PlaceholderText = "Codigo computador";

            // btnBuscarComputador
            this.btnBuscarComputador.Text = "Buscar Computador";
            this.btnBuscarComputador.Location = new Point(140, 11);
            this.btnBuscarComputador.Size = new Size(150, 25);
            this.btnBuscarComputador.Click += new EventHandler(this.btnBuscarComputador_Click);

            // lblComputador
            this.lblComputador.Location = new Point(12, 42);
            this.lblComputador.Size = new Size(450, 20);
            this.lblComputador.Text = "";

            // Label nuevo periferico
            var lblNuevo = new Label();
            lblNuevo.Text = "Nuevo periferico - Nombre:";
            lblNuevo.Location = new Point(12, 70);
            lblNuevo.Size = new Size(180, 20);

            // txtNombre
            this.txtNombre.Location = new Point(12, 93);
            this.txtNombre.Size = new Size(200, 23);
            this.txtNombre.PlaceholderText = "Nombre del periferico";

            // Label tipo
            var lblTipo = new Label();
            lblTipo.Text = "Tipo:";
            lblTipo.Location = new Point(220, 70);
            lblTipo.Size = new Size(40, 20);

            // cmbTipo
            this.cmbTipo.Location = new Point(220, 93);
            this.cmbTipo.Size = new Size(140, 23);
            this.cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] { "Entrada", "Salida", "Almacenamiento", "Otro" });
            this.cmbTipo.SelectedIndex = 0;

            // btnAgregar
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new Point(370, 91);
            this.btnAgregar.Size = new Size(80, 25);
            this.btnAgregar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnAgregar.ForeColor = Color.White;
            this.btnAgregar.Click += new EventHandler(this.btnAgregar_Click);

            // dgvPerifericos
            this.dgvPerifericos.Location = new Point(12, 130);
            this.dgvPerifericos.Size = new Size(660, 200);
            this.dgvPerifericos.ReadOnly = true;
            this.dgvPerifericos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerifericos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // btnEditar
            this.btnEditar.Text = "Editar seleccionado";
            this.btnEditar.Location = new Point(12, 340);
            this.btnEditar.Size = new Size(150, 28);
            this.btnEditar.BackColor = Color.FromArgb(15, 52, 96);
            this.btnEditar.ForeColor = Color.White;
            this.btnEditar.Click += new EventHandler(this.btnEditar_Click);

            // btnEliminar
            this.btnEliminar.Text = "Desactivar seleccionado";
            this.btnEliminar.Location = new Point(170, 340);
            this.btnEliminar.Size = new Size(170, 28);
            this.btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            this.btnEliminar.ForeColor = Color.White;
            this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);

            // panelEditar
            this.panelEditar.Location = new Point(12, 380);
            this.panelEditar.Size = new Size(660, 120);
            this.panelEditar.BorderStyle = BorderStyle.FixedSingle;
            this.panelEditar.Visible = false;

            var lblEditarTitulo = new Label();
            lblEditarTitulo.Text = "Editar periferico:";
            lblEditarTitulo.Location = new Point(5, 5);
            lblEditarTitulo.Size = new Size(120, 20);
            lblEditarTitulo.Font = new Font(lblEditarTitulo.Font, FontStyle.Bold);

            var lblEditNombre = new Label();
            lblEditNombre.Text = "Nombre:";
            lblEditNombre.Location = new Point(5, 30);
            lblEditNombre.Size = new Size(60, 20);

            this.txtNombreEditar.Location = new Point(70, 28);
            this.txtNombreEditar.Size = new Size(200, 23);

            var lblEditTipo = new Label();
            lblEditTipo.Text = "Tipo:";
            lblEditTipo.Location = new Point(280, 30);
            lblEditTipo.Size = new Size(40, 20);

            this.cmbTipoEditar.Location = new Point(325, 28);
            this.cmbTipoEditar.Size = new Size(130, 23);
            this.cmbTipoEditar.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoEditar.Items.AddRange(new object[] { "Entrada", "Salida", "Almacenamiento", "Otro" });
            this.cmbTipoEditar.SelectedIndex = 0;

            this.btnGuardarEdicion.Text = "Guardar";
            this.btnGuardarEdicion.Location = new Point(5, 65);
            this.btnGuardarEdicion.Size = new Size(80, 28);
            this.btnGuardarEdicion.BackColor = Color.FromArgb(40, 167, 69);
            this.btnGuardarEdicion.ForeColor = Color.White;
            this.btnGuardarEdicion.Click += new EventHandler(this.btnGuardarEdicion_Click);

            this.btnCancelarEdicion.Text = "Cancelar";
            this.btnCancelarEdicion.Location = new Point(95, 65);
            this.btnCancelarEdicion.Size = new Size(80, 28);
            this.btnCancelarEdicion.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancelarEdicion.ForeColor = Color.White;
            this.btnCancelarEdicion.Click += new EventHandler(this.btnCancelarEdicion_Click);

            this.panelEditar.Controls.AddRange(new Control[] {
                lblEditarTitulo, lblEditNombre, this.txtNombreEditar,
                lblEditTipo, this.cmbTipoEditar,
                this.btnGuardarEdicion, this.btnCancelarEdicion
            });

            // btnCerrar
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new Point(590, 510);
            this.btnCerrar.Size = new Size(80, 28);
            this.btnCerrar.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.Controls.AddRange(new Control[] {
                this.txtCodigoComputador, this.btnBuscarComputador,
                this.lblComputador, lblNuevo, this.txtNombre,
                lblTipo, this.cmbTipo, this.btnAgregar,
                this.dgvPerifericos, this.btnEditar, this.btnEliminar,
                this.panelEditar, this.btnCerrar
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvPerifericos)).EndInit();
            this.panelEditar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private TextBox txtCodigoComputador;
        private Button btnBuscarComputador;
        private Label lblComputador;
        private DataGridView dgvPerifericos;
        private TextBox txtNombre;
        private ComboBox cmbTipo;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCerrar;
        private Panel panelEditar;
        private TextBox txtNombreEditar;
        private ComboBox cmbTipoEditar;
        private Button btnGuardarEdicion;
        private Button btnCancelarEdicion;
    }
}
