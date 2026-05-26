using RestSharp;

namespace ClienteComputador
{
    public partial class GUIBuscarComputador : Form
    {
        public GUIBuscarComputador()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Ingrese un codigo.", "Aviso");
                return;
            }

            try
            {
                int codigo = int.Parse(txtCodigo.Text);
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores/" + codigo, Method.Get);
                var response = client.Get<Computador>(request);

                if (response != null)
                {
                    LlenarCampos(response);
                }
                else
                {
                    MessageBox.Show("No se encontro ningun computador con ese codigo.", "Aviso");
                    LimpiarCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El codigo debe ser un numero entero.", "Aviso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void LlenarCampos(Computador c)
        {
            txtBuscarMarca.Text = c.marca;
            dptFechaBuscar.Value = DateTime.TryParse(c.fechaFabricacion, out DateTime fecha)
                                   ? fecha : DateTime.Now;
            txtEstado.Text = c.estado;
            chkPortatil.Checked = c.portatil;
            txtCosto.Text = c.costoMantenimiento.ToString("C0");
            txtPerifericos.Text = c.PericosStr;
        }

        private void LimpiarCampos()
        {
            txtBuscarMarca.Text = "";
            dptFechaBuscar.Value = DateTime.Now;
            txtEstado.Text = "";
            chkPortatil.Checked = false;
            txtCosto.Text = "0";
            txtPerifericos.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void GUIBuscarComputador_Load(object sender, EventArgs e) { }
        private void txtCodigo_TextChanged(object sender, EventArgs e) { }
    }
}