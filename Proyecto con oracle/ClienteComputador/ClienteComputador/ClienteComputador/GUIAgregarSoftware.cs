using RestSharp;

namespace ClienteComputador
{
    public partial class GUIAgregarSoftware : Form
    {
        public GUIAgregarSoftware()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtNombre.Text == "" || txtVersion.Text == "" || txtCodigoComp.Text == "")
            {
                MessageBox.Show("ID, codigo computador, nombre y version son obligatorios.", "Aviso");
                return;
            }

            if (!int.TryParse(txtId.Text, out int idSoftware) || idSoftware <= 0)
            {
                MessageBox.Show("El ID debe ser un numero entero positivo.", "Aviso");
                return;
            }

            double precio = 0;
            if (txtPrecio.Text != "" && !double.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un numero valido.", "Aviso");
                return;
            }
            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.", "Aviso");
                return;
            }

            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/softwares", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(new
                {
                    id = idSoftware,
                    codigoComputador = int.Parse(txtCodigoComp.Text),
                    nombre = txtNombre.Text,
                    version = txtVersion.Text,
                    tipo = cmbTipo.Text,
                    precio = precio,
                    fechaInstalacion = dtpFechaInstalacion.Value.ToString("yyyy-MM-dd") + "T00:00:00",
                    activo = true
                });

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Software agregado correctamente.", "Exito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode + "\n" + response.Content, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtCodigoComp.Text = "";
            txtNombre.Text = "";
            txtVersion.Text = "";
            cmbTipo.SelectedIndex = 0;
            txtPrecio.Text = "";
            dtpFechaInstalacion.Value = DateTime.Now;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
