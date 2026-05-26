using RestSharp;

namespace ClienteComputador
{
    public partial class GUIBuscarSoftware : Form
    {
        public GUIBuscarSoftware()
        {
            InitializeComponent();
            this.CenterToScreen();
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
                var software = client.Get<Software>(request);

                if (software != null)
                {
                    lblResultado.Text =
                        "ID: " + software.id + "\n" +
                        "Computador: " + software.codigoComputador + "\n" +
                        "Nombre: " + software.nombre + "\n" +
                        "Version: " + software.version + "\n" +
                        "Tipo: " + software.tipo + "\n" +
                        "Precio: $" + software.precio.ToString("F2") + "\n" +
                        "Fecha Instalacion: " + software.fechaInstalacion + "\n" +
                        "Estado: " + software.ActivoStr;
                }
                else
                {
                    lblResultado.Text = "No se encontro software con ese ID.";
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
