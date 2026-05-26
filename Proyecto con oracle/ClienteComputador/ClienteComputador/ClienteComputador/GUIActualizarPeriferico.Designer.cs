namespace ClienteComputador
{
    partial class GUIActualizarPeriferico
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
            btnBuscarComputador = new Button();
            lblComputador = new Label();
            dgvPerifericos = new DataGridView();
            btnSeleccionar = new Button();
            panelEditar = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            btnGuardar = new Button();
            btnCancelarEdicion = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)(dgvPerifericos)).BeginInit();
            panelEditar.SuspendLayout();
            SuspendLayout();

            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(70, 130, 180);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Size = new Size(300, 28);
            lblTitulo.Text = "Actualizar Periferico";

            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(12, 55);
            lblCodigo.Text = "Codigo computador:";

            txtCodigo.Location = new Point(150, 52);
            txtCodigo.Size = new Size(100, 23);

            btnBuscarComputador.Text = "Buscar";
            btnBuscarComputador.Location = new Point(260, 51);
            btnBuscarComputador.Size = new Size(80, 25);
            btnBuscarComputador.BackColor = Color.FromArgb(15, 52, 96);
            btnBuscarComputador.ForeColor = Color.White;
            btnBuscarComputador.Click += new EventHandler(this.btnBuscarComputador_Click);

            lblComputador.Location = new Point(12, 85);
            lblComputador.Size = new Size(450, 20);
            lblComputador.Text = "";

            dgvPerifericos.Location = new Point(12, 115);
            dgvPerifericos.Size = new Size(560, 180);
            dgvPerifericos.ReadOnly = true;
            dgvPerifericos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPerifericos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPerifericos.AllowUserToAddRows = false;

            btnSeleccionar.Text = "Editar seleccionado";
            btnSeleccionar.Location = new Point(12, 303);
            btnSeleccionar.Size = new Size(160, 28);
            btnSeleccionar.BackColor = Color.FromArgb(15, 52, 96);
            btnSeleccionar.ForeColor = Color.White;
            btnSeleccionar.Click += new EventHandler(this.btnSeleccionar_Click);

            panelEditar.Location = new Point(12, 342);
            panelEditar.Size = new Size(560, 110);
            panelEditar.BorderStyle = BorderStyle.FixedSingle;
            panelEditar.Visible = false;

            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(8, 15);
            lblNombre.Text = "Nombre:";

            txtNombre.Location = new Point(80, 12);
            txtNombre.Size = new Size(200, 23);

            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(8, 50);
            lblTipo.Text = "Tipo:";

            cmbTipo.Location = new Point(80, 47);
            cmbTipo.Size = new Size(150, 23);
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Items.AddRange(new object[] { "Entrada", "Salida", "Almacenamiento", "Otro" });
            cmbTipo.SelectedIndex = 0;

            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.Location = new Point(8, 78);
            btnGuardar.Size = new Size(130, 25);
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            btnCancelarEdicion.Text = "Cancelar";
            btnCancelarEdicion.Location = new Point(148, 78);
            btnCancelarEdicion.Size = new Size(80, 25);
            btnCancelarEdicion.BackColor = Color.FromArgb(108, 117, 125);
            btnCancelarEdicion.ForeColor = Color.White;
            btnCancelarEdicion.Click += new EventHandler(this.btnCancelarEdicion_Click);

            panelEditar.Controls.AddRange(new Control[] { lblNombre, txtNombre, lblTipo, cmbTipo, btnGuardar, btnCancelarEdicion });

            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(492, 468);
            btnCerrar.Size = new Size(80, 28);
            btnCerrar.BackColor = Color.FromArgb(108, 117, 125);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.Text = "Actualizar Periferico";
            this.Size = new Size(600, 530);
            this.Controls.AddRange(new Control[] { lblTitulo, lblCodigo, txtCodigo, btnBuscarComputador, lblComputador, dgvPerifericos, btnSeleccionar, panelEditar, btnCerrar });

            ((System.ComponentModel.ISupportInitialize)(dgvPerifericos)).EndInit();
            panelEditar.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label lblTitulo, lblCodigo, lblComputador, lblNombre, lblTipo;
        private TextBox txtCodigo, txtNombre;
        private Button btnBuscarComputador, btnSeleccionar, btnGuardar, btnCancelarEdicion, btnCerrar;
        private ComboBox cmbTipo;
        private DataGridView dgvPerifericos;
        private Panel panelEditar;
    }
}
