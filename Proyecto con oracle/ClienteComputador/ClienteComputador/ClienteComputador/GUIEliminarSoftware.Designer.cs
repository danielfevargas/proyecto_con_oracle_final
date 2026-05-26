namespace ClienteComputador
{
    partial class GUIEliminarSoftware
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
            this.lblInfo = new Label();
            this.btnEliminar = new Button();
            this.btnCerrar = new Button();
            this.SuspendLayout();

            this.lblId.Text = "ID del Software:";
            this.lblId.Location = new Point(20, 20);
            this.lblId.Size = new Size(130, 23);

            this.txtId.Location = new Point(160, 20);
            this.txtId.Size = new Size(150, 23);

            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new Point(320, 18);
            this.btnBuscar.Size = new Size(80, 27);
            this.btnBuscar.Click += new EventHandler(this.btnBuscar_Click);

            this.lblInfo.Location = new Point(20, 60);
            this.lblInfo.Size = new Size(400, 180);
            this.lblInfo.BorderStyle = BorderStyle.FixedSingle;

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new Point(20, 255);
            this.btnEliminar.Size = new Size(100, 30);
            this.btnEliminar.Enabled = false;
            this.btnEliminar.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);

            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new Point(320, 255);
            this.btnCerrar.Size = new Size(80, 30);
            this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.Text = "Eliminar Software";
            this.ClientSize = new Size(430, 305);
            this.Controls.AddRange(new Control[] { lblId, txtId, btnBuscar, lblInfo, btnEliminar, btnCerrar });
            this.ResumeLayout(false);
        }

        private Label lblId;
        private TextBox txtId;
        private Button btnBuscar;
        private Label lblInfo;
        private Button btnEliminar;
        private Button btnCerrar;
    }
}
