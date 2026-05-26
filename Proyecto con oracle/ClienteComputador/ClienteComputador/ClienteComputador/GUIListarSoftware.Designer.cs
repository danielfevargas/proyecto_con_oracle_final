namespace ClienteComputador
{
    partial class GUIListarSoftware
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFiltroTipo = new Label();
            this.txtFiltroTipo = new TextBox();
            this.lblFiltroNombre = new Label();
            this.txtFiltroNombre = new TextBox();
            this.btnListar = new Button();
            this.dgvSoftware = new DataGridView();
            this.btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftware)).BeginInit();
            this.SuspendLayout();

            this.lblFiltroTipo.Text = "Filtrar por Tipo:";
            this.lblFiltroTipo.Location = new Point(10, 15);
            this.lblFiltroTipo.Size = new Size(120, 23);

            this.txtFiltroTipo.Location = new Point(135, 12);
            this.txtFiltroTipo.Size = new Size(160, 23);
            this.txtFiltroTipo.PlaceholderText = "Ej: Diseño (opcional)";

            this.lblFiltroNombre.Text = "Filtrar por Nombre:";
            this.lblFiltroNombre.Location = new Point(310, 15);
            this.lblFiltroNombre.Size = new Size(130, 23);

            this.txtFiltroNombre.Location = new Point(445, 12);
            this.txtFiltroNombre.Size = new Size(160, 23);
            this.txtFiltroNombre.PlaceholderText = "Ej: Office (opcional)";

            this.btnListar.Text = "Listar";
            this.btnListar.Location = new Point(620, 10);
            this.btnListar.Size = new Size(80, 27);
            this.btnListar.Click += new EventHandler(this.btnListar_Click);

            this.dgvSoftware.Location = new Point(10, 50);
            this.dgvSoftware.Size = new Size(760, 320);
            this.dgvSoftware.ReadOnly = true;
            this.dgvSoftware.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSoftware.AllowUserToAddRows = false;

            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new Point(690, 380);
            this.btnCerrar.Size = new Size(80, 30);
            this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.Text = "Listar Softwares";
            this.ClientSize = new Size(790, 425);
            this.Controls.AddRange(new Control[] {
                lblFiltroTipo, txtFiltroTipo,
                lblFiltroNombre, txtFiltroNombre,
                btnListar, dgvSoftware, btnCerrar
            });
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftware)).EndInit();
            this.ResumeLayout(false);
        }

        private Label lblFiltroTipo;
        private TextBox txtFiltroTipo;
        private Label lblFiltroNombre;
        private TextBox txtFiltroNombre;
        private Button btnListar;
        private DataGridView dgvSoftware;
        private Button btnCerrar;
    }
}
