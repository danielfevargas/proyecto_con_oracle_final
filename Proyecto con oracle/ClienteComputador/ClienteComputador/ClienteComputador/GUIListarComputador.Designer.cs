namespace ClienteComputador
{
    partial class GUIListarComputador
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
            lblFiltroMarca = new Label();
            txtFiltroMarca = new TextBox();
            lblFiltroEstado = new Label();
            txtFiltroEstado = new TextBox();
            btnListar = new Button();
            dgvLista = new DataGridView();
            lblTotal = new Label();
            btnCerrar = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();

            lblTitulo.AutoSize = false;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(70, 130, 180);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Size = new Size(660, 30);
            lblTitulo.Text = "Listar Computadores";

            lblFiltroMarca.AutoSize = true;
            lblFiltroMarca.Location = new Point(12, 55);
            lblFiltroMarca.Text = "Filtrar marca:";

            txtFiltroMarca.Location = new Point(100, 52);
            txtFiltroMarca.Size = new Size(130, 23);
            txtFiltroMarca.PlaceholderText = "Ej: Dell";

            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Location = new Point(245, 55);
            lblFiltroEstado.Text = "Filtrar estado:";

            txtFiltroEstado.Location = new Point(335, 52);
            txtFiltroEstado.Size = new Size(130, 23);
            txtFiltroEstado.PlaceholderText = "Ej: bueno";

            btnListar.BackColor = Color.FromArgb(70, 130, 180);
            btnListar.ForeColor = Color.White;
            btnListar.FlatStyle = FlatStyle.Flat;
            btnListar.Location = new Point(480, 50);
            btnListar.Size = new Size(90, 27);
            btnListar.Text = "Listar";
            btnListar.Click += new EventHandler(btnListar_Click);

            dgvLista.Location = new Point(12, 90);
            dgvLista.Size = new Size(660, 280);
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.ReadOnly = true;
            dgvLista.AllowUserToAddRows = false;
            dgvLista.RowHeadersVisible = false;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.BackgroundColor = Color.White;

            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 382);
            lblTotal.ForeColor = Color.Gray;
            lblTotal.Text = "";

            btnCerrar.Location = new Point(580, 380);
            btnCerrar.Size = new Size(90, 27);
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += new EventHandler(btnCerrar_Click);

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(690, 420);
            Controls.Add(lblTitulo);
            Controls.Add(lblFiltroMarca); Controls.Add(txtFiltroMarca);
            Controls.Add(lblFiltroEstado); Controls.Add(txtFiltroEstado);
            Controls.Add(btnListar);
            Controls.Add(dgvLista);
            Controls.Add(lblTotal);
            Controls.Add(btnCerrar);
            Name = "GUIListarComputador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listar Computadores";
            Load += new EventHandler(GUIListarComputador_Load);

            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo, lblFiltroMarca, lblFiltroEstado, lblTotal;
        private TextBox txtFiltroMarca, txtFiltroEstado;
        private Button btnListar, btnCerrar;
        private DataGridView dgvLista;
    }
}
