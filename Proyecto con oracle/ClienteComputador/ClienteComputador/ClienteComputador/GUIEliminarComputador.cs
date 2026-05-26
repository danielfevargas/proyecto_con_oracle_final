using RestSharp;

namespace ClienteComputador
{
    public partial class GUIEliminarComputador : Form
    {
        private int codigoSeleccionado = 0;

        public GUIEliminarComputador()
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
                    dgvResultado.DataSource = new List<Computador> { response };
                    OcultarColumnas();
                    codigoSeleccionado = response.codigo;
                    btnEliminar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontro el computador.", "Aviso");
                    dgvResultado.DataSource = null;
                    codigoSeleccionado = 0;
                    btnEliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (codigoSeleccionado == 0)
            {
                MessageBox.Show("Primero busque un computador.", "Aviso");
                return;
            }

            var confirmar = MessageBox.Show(
                "¿Esta seguro que desea eliminar el computador con codigo " + codigoSeleccionado + "?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    var client = new RestClient("http://localhost:8080");
                    var request = new RestRequest("/computadores/" + codigoSeleccionado, Method.Delete);
                    var response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        MessageBox.Show("Computador eliminado correctamente.", "Exito");
                        dgvResultado.DataSource = null;
                        txtCodigo.Text = "";
                        codigoSeleccionado = 0;
                        btnEliminar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar. Codigo: " + response.StatusCode, "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error");
                }
            }
        }

        private void OcultarColumnas()
        {
            string[] ocultar = { "activo", "perifericos", "portatil" };
            foreach (var col in ocultar)
                if (dgvResultado.Columns.Contains(col))
                    dgvResultado.Columns[col].Visible = false;

            if (dgvResultado.Columns.Contains("codigo")) dgvResultado.Columns["codigo"].HeaderText = "Codigo";
            if (dgvResultado.Columns.Contains("marca")) dgvResultado.Columns["marca"].HeaderText = "Marca";
            if (dgvResultado.Columns.Contains("fechaFabricacion")) dgvResultado.Columns["fechaFabricacion"].HeaderText = "Fecha";
            if (dgvResultado.Columns.Contains("estado")) dgvResultado.Columns["estado"].HeaderText = "Estado";
            if (dgvResultado.Columns.Contains("costoMantenimiento")) dgvResultado.Columns["costoMantenimiento"].HeaderText = "Costo";
            if (dgvResultado.Columns.Contains("PortatilStr")) dgvResultado.Columns["PortatilStr"].HeaderText = "Portatil";
            if (dgvResultado.Columns.Contains("PericosStr")) dgvResultado.Columns["PericosStr"].HeaderText = "Perifericos";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
