namespace ClienteComputador
{
    partial class GUIBuscarSoftware
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
            this.btnBuscar = new Button();
            this.lblResultado = new Label();
            this.btnCerrar = new Button();
            this.SuspendLayout();

            this.lblId.Text = "ID del Software:";
            this.lblId.Location = new Point(20, 20);
            this.lblId.Size = new Size(130, 23);

            this.txtId.Location = new Point(160, 20);
            this.txtId.Size = new Size(150, 23);

            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new Point(320, 20);
            this.btnBuscar.Size = new Size(80, 23);
            this.btnBuscar.Click += new EventHandler(this.btnBuscar_Click);

            this.lblResultado.Text = "";
            this.lblResultado.Location = new Point(20, 60);
            this.lblResultado.Size = new Size(400, 180);
            this.lblResultado.BorderStyle = BorderStyle.FixedSingle;

            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new Point(320, 250);
            this.btnCerrar.Size = new Size(80, 30);
            this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.Text = "Buscar Software";
            this.ClientSize = new Size(430, 300);
            this.Controls.AddRange(new Control[] { lblId, txtId, btnBuscar, lblResultado, btnCerrar });
            this.ResumeLayout(false);
        }

        private Label lblId;
        private TextBox txtId;
        private Button btnBuscar;
        private Label lblResultado;
        private Button btnCerrar;
    }
}
