namespace ClienteComputador
{
    partial class GUIAgregarComputador
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
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            lblPortatil = new Label();
            chkPortatil = new CheckBox();
            lblCosto = new Label();
            txtCosto = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();

            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(70, 130, 180);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Size = new Size(400, 30);
            lblTitulo.Text = "Agregar Computador";

            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(12, 55);
            lblCodigo.Text = "Codigo *:";

            txtCodigo.Location = new Point(160, 52);
            txtCodigo.Size = new Size(200, 23);
            txtCodigo.PlaceholderText = "Ej: 101";

            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(12, 90);
            lblMarca.Text = "Marca *:";

            txtMarca.Location = new Point(160, 87);
            txtMarca.Size = new Size(200, 23);
            txtMarca.PlaceholderText = "Ej: Dell";

            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(12, 125);
            lblFecha.Text = "Fecha Fabricacion:";

            dtpFecha.Location = new Point(160, 122);
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.Format = DateTimePickerFormat.Short;

            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(12, 160);
            lblEstado.Text = "Estado:";

            cmbEstado.Location = new Point(160, 157);
            cmbEstado.Size = new Size(200, 23);
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Items.AddRange(new string[] { "Bueno", "Regular", "Malo" });
            cmbEstado.SelectedIndex = 0;

            lblCosto.AutoSize = true;
            lblCosto.Location = new Point(12, 195);
            lblCosto.Text = "Costo Mantenimiento:";

            txtCosto.Location = new Point(160, 192);
            txtCosto.Size = new Size(200, 23);
            txtCosto.PlaceholderText = "Ej: 150000";

            lblPortatil.AutoSize = true;
            lblPortatil.Location = new Point(12, 230);
            lblPortatil.Text = "Es portatil:";

            chkPortatil.Location = new Point(160, 228);
            chkPortatil.Size = new Size(20, 20);

            btnGuardar.Text = "Guardar Computador";
            btnGuardar.Location = new Point(12, 270);
            btnGuardar.Size = new Size(160, 30);
            btnGuardar.BackColor = Color.FromArgb(15, 52, 96);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(182, 270);
            btnCancelar.Size = new Size(80, 30);
            btnCancelar.BackColor = Color.FromArgb(108, 117, 125);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            this.Text = "Agregar Computador";
            this.Size = new Size(420, 360);
            this.Controls.AddRange(new Control[] {
                lblTitulo, lblCodigo, txtCodigo,
                lblMarca, txtMarca,
                lblFecha, dtpFecha,
                lblEstado, cmbEstado,
                lblCosto, txtCosto,
                lblPortatil, chkPortatil,
                btnGuardar, btnCancelar
            });

            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblMarca;
        private TextBox txtMarca;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Label lblPortatil;
        private CheckBox chkPortatil;
        private Label lblCosto;
        private TextBox txtCosto;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
