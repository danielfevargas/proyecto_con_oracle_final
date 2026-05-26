using RestSharp;

namespace ClienteComputador
{
    public partial class GUIListarSoftware : Form
    {
        public GUIListarSoftware()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new RestClient("http://localhost:8080");
                string url = "/softwares?x=1";
                if (txtFiltroTipo.Text != "")   url += "&tipo=" + txtFiltroTipo.Text;
                if (txtFiltroNombre.Text != "") url += "&nombre=" + txtFiltroNombre.Text;

                var request = new RestRequest(url, Method.Get);
                var lista = client.Get<List<Software>>(request);

                if (lista != null && lista.Count > 0)
                {
                    dgvSoftware.DataSource = lista;
                    OcultarColumnas();
                }
                else
                {
                    dgvSoftware.DataSource = null;
                    MessageBox.Show("No se encontraron softwares.", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void OcultarColumnas()
        {
            if (dgvSoftware.Columns.Contains("activo"))     dgvSoftware.Columns["activo"].Visible = false;
            if (dgvSoftware.Columns.Contains("ActivoStr"))  dgvSoftware.Columns["ActivoStr"].Visible = false;
            if (dgvSoftware.Columns.Contains("PrecioStr"))  dgvSoftware.Columns["PrecioStr"].Visible = false;
            if (dgvSoftware.Columns.Contains("id"))         dgvSoftware.Columns["id"].HeaderText = "ID";
            if (dgvSoftware.Columns.Contains("codigoComputador")) dgvSoftware.Columns["codigoComputador"].HeaderText = "Computador";
            if (dgvSoftware.Columns.Contains("nombre"))    dgvSoftware.Columns["nombre"].HeaderText = "Nombre";
            if (dgvSoftware.Columns.Contains("version"))   dgvSoftware.Columns["version"].HeaderText = "Version";
            if (dgvSoftware.Columns.Contains("tipo"))      dgvSoftware.Columns["tipo"].HeaderText = "Tipo";
            if (dgvSoftware.Columns.Contains("precio"))    dgvSoftware.Columns["precio"].HeaderText = "Precio";
            if (dgvSoftware.Columns.Contains("fechaInstalacion")) dgvSoftware.Columns["fechaInstalacion"].HeaderText = "Fecha Instalacion";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
