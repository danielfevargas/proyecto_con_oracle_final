using RestSharp;

namespace ClienteComputador
{
    public partial class GUIEliminarPeriferico : Form
    {
        private int codigoComputador = 0;
        private int idPerifericoSeleccionado = 0;

        public GUIEliminarPeriferico()
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
                var reqComp = new RestRequest("/computadores/" + txtCodigo.Text, Method.Get);
                var comp = client.Get<Computador>(reqComp);

                if (comp == null)
                {
                    MessageBox.Show("No se encontro ningun computador con ese codigo.", "Aviso");
                    lblComputador.Text = "";
                    dgvPerifericos.DataSource = null;
                    panelConfirmar.Visible = false;
                    return;
                }

                codigoComputador = comp.codigo;
                lblComputador.Text = "Computador: " + comp.marca + " — Codigo: " + comp.codigo;
                idPerifericoSeleccionado = 0;
                panelConfirmar.Visible = false;
                CargarPerifericos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void CargarPerifericos()
        {
            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores/" + codigoComputador + "/perifericos", Method.Get);
                var lista = client.Get<List<Periferico>>(request);

                if (lista != null)
                {
                    dgvPerifericos.DataSource = lista;
                    OcultarColumnas();
                }
                else
                {
                    dgvPerifericos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar perifericos: " + ex.Message, "Error");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvPerifericos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un periferico de la tabla.", "Aviso");
                return;
            }

            var p = (Periferico)dgvPerifericos.CurrentRow.DataBoundItem;
            idPerifericoSeleccionado = p.id;

            lblConfirmar.Text = "Va a desactivar: " + p.nombre + " (ID: " + p.id + ") — Tipo: " + p.tipo;
            panelConfirmar.Visible = true;
        }

        private void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            if (idPerifericoSeleccionado == 0) return;

            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores/" + codigoComputador + "/perifericos/" + idPerifericoSeleccionado, Method.Delete);
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Periferico desactivado correctamente.", "Exito");
                    idPerifericoSeleccionado = 0;
                    panelConfirmar.Visible = false;
                    CargarPerifericos();
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idPerifericoSeleccionado = 0;
            panelConfirmar.Visible = false;
        }

        private void OcultarColumnas()
        {
            if (dgvPerifericos.Columns.Contains("activo")) dgvPerifericos.Columns["activo"].Visible = false;
            if (dgvPerifericos.Columns.Contains("id")) dgvPerifericos.Columns["id"].HeaderText = "ID";
            if (dgvPerifericos.Columns.Contains("nombre")) dgvPerifericos.Columns["nombre"].HeaderText = "Nombre";
            if (dgvPerifericos.Columns.Contains("tipo")) dgvPerifericos.Columns["tipo"].HeaderText = "Tipo";
            if (dgvPerifericos.Columns.Contains("ActivoStr")) dgvPerifericos.Columns["ActivoStr"].HeaderText = "Estado";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
