namespace ClienteComputador
{
    partial class GUIAgregarPeriferico
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
            panelAgregar = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            btnGuardar = new Button();
            btnCerrar = new Button();
            panelAgregar.SuspendLayout();
            SuspendLayout();

            // lblTitulo
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(70, 130, 180);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Size = new Size(350, 28);
            lblTitulo.Text = "Agregar Periferico";

            // lblCodigo
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(12, 55);
            lblCodigo.Text = "Codigo computador:";

            // txtCodigo
            txtCodigo.Location = new Point(150, 52);
            txtCodigo.Size = new Size(100, 23);

            // btnBuscarComputador
            btnBuscarComputador.Text = "Buscar";
            btnBuscarComputador.Location = new Point(260, 51);
            btnBuscarComputador.Size = new Size(80, 25);
            btnBuscarComputador.BackColor = Color.FromArgb(15, 52, 96);
            btnBuscarComputador.ForeColor = Color.White;
            btnBuscarComputador.Click += new EventHandler(this.btnBuscarComputador_Click);

            // lblComputador
            lblComputador.Location = new Point(12, 85);
            lblComputador.Size = new Size(380, 20);
            lblComputador.Text = "";

            // panelAgregar
            panelAgregar.Location = new Point(12, 115);
            panelAgregar.Size = new Size(400, 130);
            panelAgregar.BorderStyle = BorderStyle.FixedSingle;
            panelAgregar.Visible = false;

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(8, 15);
            lblNombre.Text = "Nombre:";

            // txtNombre
            txtNombre.Location = new Point(80, 12);
            txtNombre.Size = new Size(200, 23);
            txtNombre.PlaceholderText = "Ej: Teclado mecanico";

            // lblTipo
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(8, 50);
            lblTipo.Text = "Tipo:";

            // cmbTipo
            cmbTipo.Location = new Point(80, 47);
            cmbTipo.Size = new Size(150, 23);
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Items.AddRange(new object[] { "Entrada", "Salida", "Almacenamiento", "Otro" });
            cmbTipo.SelectedIndex = 0;

            // btnGuardar
            btnGuardar.Text = "Guardar Periferico";
            btnGuardar.Location = new Point(8, 85);
            btnGuardar.Size = new Size(150, 28);
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            panelAgregar.Controls.AddRange(new Control[] { lblNombre, txtNombre, lblTipo, cmbTipo, btnGuardar });

            // btnCerrar
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(320, 260);
            btnCerrar.Size = new Size(80, 28);
            btnCerrar.BackColor = Color.FromArgb(108, 117, 125);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.Text = "Agregar Periferico";
            this.Size = new Size(430, 320);
            this.Controls.AddRange(new Control[] { lblTitulo, lblCodigo, txtCodigo, btnBuscarComputador, lblComputador, panelAgregar, btnCerrar });

            panelAgregar.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label lblTitulo, lblCodigo, lblComputador, lblNombre, lblTipo;
        private TextBox txtCodigo, txtNombre;
        private Button btnBuscarComputador, btnGuardar, btnCerrar;
        private ComboBox cmbTipo;
        private Panel panelAgregar;
    }
}
