using RestSharp;

namespace ClienteComputador
{
    public partial class GUIActualizarSoftware : Form
    {
        private Software? softwareEncontrado = null;

        public GUIActualizarSoftware()
        {
            InitializeComponent();
            this.CenterToScreen();
            HabilitarCampos(false);
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtCodigoComp.Enabled = habilitar;
            txtNombre.Enabled = habilitar;
            txtVersion.Enabled = habilitar;
            cmbTipo.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            dtpFechaInstalacion.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Ingrese el ID del software.", "Aviso");
                return;
            }

            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/softwares/" + txtId.Text, Method.Get);
                softwareEncontrado = client.Get<Software>(request);

                if (softwareEncontrado != null)
                {
                    txtCodigoComp.Text = softwareEncontrado.codigoComputador.ToString();
                    txtNombre.Text = softwareEncontrado.nombre;
                    txtVersion.Text = softwareEncontrado.version;
                    cmbTipo.Text = softwareEncontrado.tipo;
                    txtPrecio.Text = softwareEncontrado.precio.ToString("F2");
                    if (softwareEncontrado.fechaInstalacion != null && softwareEncontrado.fechaInstalacion.Length >= 10)
                        dtpFechaInstalacion.Value = DateTime.Parse(softwareEncontrado.fechaInstalacion.Substring(0, 10));
                    HabilitarCampos(true);
                }
                else
                {
                    MessageBox.Show("No se encontro software con ese ID.", "Aviso");
                    HabilitarCampos(false);
                    softwareEncontrado = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (softwareEncontrado == null) return;

            if (txtNombre.Text == "" || txtVersion.Text == "" || txtCodigoComp.Text == "")
            {
                MessageBox.Show("Codigo computador, nombre y version son obligatorios.", "Aviso");
                return;
            }

            double precio = 0;
            if (txtPrecio.Text != "" && !double.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un numero valido.", "Aviso");
                return;
            }

            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/softwares/" + softwareEncontrado.id, Method.Put);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(new
                {
                    id = softwareEncontrado.id,
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
                    MessageBox.Show("Software actualizado correctamente.", "Exito");
                    txtId.Text = "";
                    HabilitarCampos(false);
                    softwareEncontrado = null;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
