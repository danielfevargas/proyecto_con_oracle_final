using RestSharp;

namespace ClienteComputador
{
    public partial class GUIActualizarComputador : Form
    {
        private int codigoSeleccionado = 0;

        public GUIActualizarComputador()
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

                    // Llenar los campos con la info actual
                    txtMarca.Text = response.marca;
                    txtEstado.Text = response.estado;
                    txtCosto.Text = response.costoMantenimiento.ToString();
                    chkPortatil.Checked = response.portatil;
                    txtPerifericos.Text = response.PericosStr;

                    try { dtpFecha.Value = DateTime.Parse(response.fechaFabricacion); }
                    catch { dtpFecha.Value = DateTime.Now; }

                    btnActualizar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontro el computador.", "Aviso");
                    dgvResultado.DataSource = null;
                    codigoSeleccionado = 0;
                    btnActualizar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (codigoSeleccionado == 0)
            {
                MessageBox.Show("Primero busque un computador.", "Aviso");
                return;
            }

            try
            {
                var perifericos = new List<string>();
                if (txtPerifericos.Text.Trim() != "")
                {
                    foreach (var p in txtPerifericos.Text.Split(','))
                        perifericos.Add(p.Trim());
                }

                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores/" + codigoSeleccionado, Method.Put);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(new
                {
                    codigo = codigoSeleccionado,
                    marca = txtMarca.Text,
                    fechaFabricacion = dtpFecha.Value.ToString("yyyy-MM-dd") + "T00:00:00",
                    estado = txtEstado.Text,
                    portatil = chkPortatil.Checked,
                    costoMantenimiento = double.Parse(txtCosto.Text),
                    perifericos = perifericos,
                    activo = true
                });

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Computador actualizado correctamente.", "Exito");
                    // Refrescar la tabla
                    btnBuscar_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Error al actualizar: " + response.StatusCode + "\n" + response.Content, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
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
