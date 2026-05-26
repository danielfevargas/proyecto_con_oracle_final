using RestSharp;

namespace ClienteComputador
{
    public partial class GUIEliminarSoftware : Form
    {
        private Software? softwareEncontrado = null;

        public GUIEliminarSoftware()
        {
            InitializeComponent();
            this.CenterToScreen();
            lblInfo.Text = "";
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
                    lblInfo.Text =
                        "ID: " + softwareEncontrado.id + "\n" +
                        "Computador: " + softwareEncontrado.codigoComputador + "\n" +
                        "Nombre: " + softwareEncontrado.nombre + "\n" +
                        "Version: " + softwareEncontrado.version + "\n" +
                        "Tipo: " + softwareEncontrado.tipo + "\n" +
                        "Precio: $" + softwareEncontrado.precio.ToString("F2") + "\n" +
                        "Fecha Instalacion: " + softwareEncontrado.fechaInstalacion;
                    btnEliminar.Enabled = true;
                }
                else
                {
                    lblInfo.Text = "No se encontro software con ese ID.";
                    btnEliminar.Enabled = false;
                    softwareEncontrado = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (softwareEncontrado == null) return;

            var confirmacion = MessageBox.Show(
                "¿Esta seguro de eliminar el software '" + softwareEncontrado.nombre + "'?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    var client = new RestClient("http://localhost:8080");
                    var request = new RestRequest("/softwares/" + softwareEncontrado.id, Method.Delete);
                    var response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        MessageBox.Show("Software eliminado correctamente.", "Exito");
                        txtId.Text = "";
                        lblInfo.Text = "";
                        btnEliminar.Enabled = false;
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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
