using RestSharp;

namespace ClienteComputador
{
    public partial class GUIListarComputador : Form
    {
        public GUIListarComputador()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void GUIListarComputador_Load(object sender, EventArgs e)
        {
            // Cargar todos al abrir
            CargarLista();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores", Method.Get);

                // Filtro por marca si escribio algo
                if (txtFiltroMarca.Text.Trim() != "")
                    request.AddQueryParameter("marca", txtFiltroMarca.Text.Trim());

                // Filtro por estado si escribio algo
                if (txtFiltroEstado.Text.Trim() != "")
                    request.AddQueryParameter("estado", txtFiltroEstado.Text.Trim());

                var lista = client.Get<List<Computador>>(request);

                if (lista != null && lista.Count > 0)
                {
                    dgvLista.DataSource = lista;
                    OcultarColumnas();
                    lblTotal.Text = "Total: " + lista.Count + " registros";
                }
                else
                {
                    dgvLista.DataSource = null;
                    lblTotal.Text = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error");
            }
        }

        private void OcultarColumnas()
        {
            string[] ocultar = { "activo", "perifericos", "portatil" };
            foreach (var col in ocultar)
                if (dgvLista.Columns.Contains(col))
                    dgvLista.Columns[col].Visible = false;

            if (dgvLista.Columns.Contains("codigo")) dgvLista.Columns["codigo"].HeaderText = "Codigo";
            if (dgvLista.Columns.Contains("marca")) dgvLista.Columns["marca"].HeaderText = "Marca";
            if (dgvLista.Columns.Contains("fechaFabricacion")) dgvLista.Columns["fechaFabricacion"].HeaderText = "Fecha";
            if (dgvLista.Columns.Contains("estado")) dgvLista.Columns["estado"].HeaderText = "Estado";
            if (dgvLista.Columns.Contains("costoMantenimiento")) dgvLista.Columns["costoMantenimiento"].HeaderText = "Costo";
            if (dgvLista.Columns.Contains("PortatilStr")) dgvLista.Columns["PortatilStr"].HeaderText = "Portatil";
            if (dgvLista.Columns.Contains("ActivoStr")) dgvLista.Columns["ActivoStr"].HeaderText = "Activo";
            if (dgvLista.Columns.Contains("PericosStr")) dgvLista.Columns["PericosStr"].HeaderText = "Perifericos";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
