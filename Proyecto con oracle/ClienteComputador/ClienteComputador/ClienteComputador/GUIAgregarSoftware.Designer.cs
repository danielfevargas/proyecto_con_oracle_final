namespace ClienteComputador
{
    partial class GUIAgregarSoftware
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblId = new Label();
            this.txtId = new TextBox();
            this.lblCodigoComp = new Label();
            this.txtCodigoComp = new TextBox();
            this.lblNombre = new Label();
            this.txtNombre = new TextBox();
            this.lblVersion = new Label();
            this.txtVersion = new TextBox();
            this.lblTipo = new Label();
            this.cmbTipo = new ComboBox();
            this.lblPrecio = new Label();
            this.txtPrecio = new TextBox();
            this.lblFecha = new Label();
            this.dtpFechaInstalacion = new DateTimePicker();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            this.SuspendLayout();

            this.lblId.Text = "ID *:";
            this.lblId.Location = new Point(20, 20);
            this.lblId.Size = new Size(160, 23);

            this.txtId.Location = new Point(190, 20);
            this.txtId.Size = new Size(200, 23);

            this.lblCodigoComp.Text = "Codigo Computador *:";
            this.lblCodigoComp.Location = new Point(20, 55);
            this.lblCodigoComp.Size = new Size(160, 23);

            this.txtCodigoComp.Location = new Point(190, 55);
            this.txtCodigoComp.Size = new Size(200, 23);

            this.lblNombre.Text = "Nombre *:";
            this.lblNombre.Location = new Point(20, 90);
            this.lblNombre.Size = new Size(160, 23);

            this.txtNombre.Location = new Point(190, 90);
            this.txtNombre.Size = new Size(200, 23);

            this.lblVersion.Text = "Version *:";
            this.lblVersion.Location = new Point(20, 125);
            this.lblVersion.Size = new Size(160, 23);

            this.txtVersion.Location = new Point(190, 125);
            this.txtVersion.Size = new Size(200, 23);

            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Location = new Point(20, 160);
            this.lblTipo.Size = new Size(160, 23);

            this.cmbTipo.Location = new Point(190, 160);
            this.cmbTipo.Size = new Size(200, 23);
            this.cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new string[] { "Ofimatica", "Diseño", "Desarrollo", "Seguridad", "Educacion", "Entretenimiento", "Otro" });
            this.cmbTipo.SelectedIndex = 0;

            this.lblPrecio.Text = "Precio (USD):";
            this.lblPrecio.Location = new Point(20, 195);
            this.lblPrecio.Size = new Size(160, 23);

            this.txtPrecio.Location = new Point(190, 195);
            this.txtPrecio.Size = new Size(200, 23);

            this.lblFecha.Text = "Fecha Instalacion *:";
            this.lblFecha.Location = new Point(20, 230);
            this.lblFecha.Size = new Size(160, 23);

            this.dtpFechaInstalacion.Location = new Point(190, 230);
            this.dtpFechaInstalacion.Size = new Size(200, 23);
            this.dtpFechaInstalacion.Format = DateTimePickerFormat.Short;

            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new Point(190, 270);
            this.btnGuardar.Size = new Size(90, 30);
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new Point(290, 270);
            this.btnCancelar.Size = new Size(90, 30);
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            this.Text = "Agregar Software";
            this.ClientSize = new Size(430, 320);
            this.Controls.AddRange(new Control[] {
                lblId, txtId,
                lblCodigoComp, txtCodigoComp,
                lblNombre, txtNombre,
                lblVersion, txtVersion,
                lblTipo, cmbTipo,
                lblPrecio, txtPrecio,
                lblFecha, dtpFechaInstalacion,
                btnGuardar, btnCancelar
            });
            this.ResumeLayout(false);
        }

        private Label lblId;
        private TextBox txtId;
        private Label lblCodigoComp;
        private TextBox txtCodigoComp;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblVersion;
        private TextBox txtVersion;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblFecha;
        private DateTimePicker dtpFechaInstalacion;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
