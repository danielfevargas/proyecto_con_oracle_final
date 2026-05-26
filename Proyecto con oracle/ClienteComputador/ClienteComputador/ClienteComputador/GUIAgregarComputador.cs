using RestSharp;

namespace ClienteComputador
{
    public partial class GUIAgregarComputador : Form
    {
        public GUIAgregarComputador()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "" || txtMarca.Text == "")
            {
                MessageBox.Show("El codigo y la marca son obligatorios.", "Aviso");
                return;
            }

            if (!int.TryParse(txtCodigo.Text, out int codigo) || codigo <= 0)
            {
                MessageBox.Show("El codigo debe ser un numero entero positivo.", "Aviso");
                return;
            }

            double costo = 0;
            if (txtCosto.Text != "" && !double.TryParse(txtCosto.Text, out costo))
            {
                MessageBox.Show("El costo debe ser un numero valido.", "Aviso");
                return;
            }

            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(new
                {
                    codigo = codigo,
                    marca = txtMarca.Text,
                    fechaFabricacion = dtpFecha.Value.ToString("yyyy-MM-dd") + "T00:00:00",
                    estado = cmbEstado.Text,
                    portatil = chkPortatil.Checked,
                    costoMantenimiento = costo,
                    perifericos = new object[] { },
                    activo = true
                });

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Computador agregado correctamente.", "Exito");
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
            txtCodigo.Text = "";
            txtMarca.Text = "";
            cmbEstado.SelectedIndex = 0;
            txtCosto.Text = "";
            chkPortatil.Checked = false;
            dtpFecha.Value = DateTime.Now;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
