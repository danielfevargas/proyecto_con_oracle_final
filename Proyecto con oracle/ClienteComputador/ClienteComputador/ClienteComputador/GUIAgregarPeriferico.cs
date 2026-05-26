using RestSharp;

namespace ClienteComputador
{
    public partial class GUIAgregarPeriferico : Form
    {
        public GUIAgregarPeriferico()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnBuscarComputador_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del computador.", "Aviso");
                return;
            }

            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores/" + txtCodigo.Text.Trim(), Method.Get);
                var response = client.Get<Computador>(request);

                if (response != null)
                {
                    lblComputador.Text = "Computador: " + response.marca + " — Codigo: " + response.codigo;
                    panelAgregar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se encontro ningun computador con ese codigo.", "Aviso");
                    lblComputador.Text = "";
                    panelAgregar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El nombre del periferico es obligatorio.", "Aviso");
                return;
            }

            try
            {
                var options = new RestClientOptions("http://localhost:8080");
                var client = new RestClient(options);
                var request = new RestRequest("/computadores/" + txtCodigo.Text.Trim() + "/perifericos", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");

                var body = new
                {
                    id = 0,
                    nombre = txtNombre.Text.Trim(),
                    tipo = cmbTipo.Text,
                    activo = true
                };
                request.AddJsonBody(body);

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Periferico agregado correctamente.", "Exito");
                    txtNombre.Text = "";
                    cmbTipo.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Error del servidor: " + response.StatusCode + "\n" + response.Content, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
