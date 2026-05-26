namespace ClienteComputador
{
    partial class GUIListarPerifericos
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
            lblComputador = new Label();
            dgvPerifericos = new DataGridView();
            lblTotal = new Label();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)(dgvPerifericos)).BeginInit();
            SuspendLayout();

            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(70, 130, 180);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Size = new Size(300, 28);
            lblTitulo.Text = "Listar Perifericos";

            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(12, 55);
            lblCodigo.Text = "Codigo computador:";

            txtCodigo.Location = new Point(150, 52);
            txtCodigo.Size = new Size(100, 23);

            btnBuscar.Text = "Buscar";
            btnBuscar.Location = new Point(260, 51);
            btnBuscar.Size = new Size(80, 25);
            btnBuscar.BackColor = Color.FromArgb(15, 52, 96);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Click += new EventHandler(this.btnBuscar_Click);

            lblComputador.Location = new Point(12, 85);
            lblComputador.Size = new Size(450, 20);
            lblComputador.Text = "";

            dgvPerifericos.Location = new Point(12, 115);
            dgvPerifericos.Size = new Size(560, 220);
            dgvPerifericos.ReadOnly = true;
            dgvPerifericos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPerifericos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPerifericos.AllowUserToAddRows = false;

            lblTotal.Location = new Point(12, 342);
            lblTotal.Size = new Size(200, 20);
            lblTotal.Text = "";

            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(492, 345);
            btnCerrar.Size = new Size(80, 28);
            btnCerrar.BackColor = Color.FromArgb(108, 117, 125);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.Text = "Listar Perifericos";
            this.Size = new Size(600, 410);
            this.Controls.AddRange(new Control[] { lblTitulo, lblCodigo, txtCodigo, btnBuscar, lblComputador, dgvPerifericos, lblTotal, btnCerrar });

            ((System.ComponentModel.ISupportInitialize)(dgvPerifericos)).EndInit();
            ResumeLayout(false);
        }

        private Label lblTitulo, lblCodigo, lblComputador, lblTotal;
        private TextBox txtCodigo;
        private Button btnBuscar, btnCerrar;
        private DataGridView dgvPerifericos;
    }
}
