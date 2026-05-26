namespace ClienteComputador
{
    partial class GUIEliminarPeriferico
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
            panelConfirmar = new Panel();
            lblConfirmar = new Label();
            btnConfirmarEliminar = new Button();
            btnCancelar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)(dgvPerifericos)).BeginInit();
            panelConfirmar.SuspendLayout();
            SuspendLayout();

            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(70, 130, 180);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Size = new Size(300, 28);
            lblTitulo.Text = "Eliminar Periferico";

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
            dgvPerifericos.Size = new Size(560, 190);
            dgvPerifericos.ReadOnly = true;
            dgvPerifericos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPerifericos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPerifericos.AllowUserToAddRows = false;

            btnSeleccionar.Text = "Seleccionar para eliminar";
            btnSeleccionar.Location = new Point(12, 313);
            btnSeleccionar.Size = new Size(190, 28);
            btnSeleccionar.BackColor = Color.FromArgb(220, 53, 69);
            btnSeleccionar.ForeColor = Color.White;
            btnSeleccionar.Click += new EventHandler(this.btnSeleccionar_Click);

            panelConfirmar.Location = new Point(12, 350);
            panelConfirmar.Size = new Size(560, 90);
            panelConfirmar.BorderStyle = BorderStyle.FixedSingle;
            panelConfirmar.BackColor = Color.FromArgb(255, 243, 205);
            panelConfirmar.Visible = false;

            lblConfirmar.Location = new Point(8, 10);
            lblConfirmar.Size = new Size(540, 30);
            lblConfirmar.Text = "";

            btnConfirmarEliminar.Text = "Confirmar Eliminacion";
            btnConfirmarEliminar.Location = new Point(8, 48);
            btnConfirmarEliminar.Size = new Size(170, 28);
            btnConfirmarEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnConfirmarEliminar.ForeColor = Color.White;
            btnConfirmarEliminar.Click += new EventHandler(this.btnConfirmarEliminar_Click);

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(188, 48);
            btnCancelar.Size = new Size(80, 28);
            btnCancelar.BackColor = Color.FromArgb(108, 117, 125);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            panelConfirmar.Controls.AddRange(new Control[] { lblConfirmar, btnConfirmarEliminar, btnCancelar });

            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(492, 458);
            btnCerrar.Size = new Size(80, 28);
            btnCerrar.BackColor = Color.FromArgb(108, 117, 125);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.Text = "Eliminar Periferico";
            this.Size = new Size(600, 520);
            this.Controls.AddRange(new Control[] { lblTitulo, lblCodigo, txtCodigo, btnBuscarComputador, lblComputador, dgvPerifericos, btnSeleccionar, panelConfirmar, btnCerrar });

            ((System.ComponentModel.ISupportInitialize)(dgvPerifericos)).EndInit();
            panelConfirmar.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label lblTitulo, lblCodigo, lblComputador, lblConfirmar;
        private TextBox txtCodigo;
        private Button btnBuscarComputador, btnSeleccionar, btnConfirmarEliminar, btnCancelar, btnCerrar;
        private DataGridView dgvPerifericos;
        private Panel panelConfirmar;
    }
}
