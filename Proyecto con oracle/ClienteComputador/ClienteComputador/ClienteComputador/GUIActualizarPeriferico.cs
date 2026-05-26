using RestSharp;

namespace ClienteComputador
{
    public partial class GUIActualizarPeriferico : Form
    {
        private int codigoComputador = 0;
        private int idPerifericoSeleccionado = 0;

        public GUIActualizarPeriferico()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnBuscarComputador_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo del computador.", "Aviso");
                return;
            }

            try
            {
                var client = new RestClient("http://localhost:8080");
                var reqComp = new RestRequest("/computadores/" + txtCodigo.Text.Trim(), Method.Get);
                var comp = client.Get<Computador>(reqComp);

                if (comp == null)
                {
                    MessageBox.Show("No se encontro ningun computador con ese codigo.", "Aviso");
                    lblComputador.Text = "";
                    dgvPerifericos.DataSource = null;
                    panelEditar.Visible = false;
                    return;
                }

                codigoComputador = comp.codigo;
                lblComputador.Text = "Computador: " + comp.marca + " — Codigo: " + comp.codigo;
                idPerifericoSeleccionado = 0;
                panelEditar.Visible = false;
                CargarPerifericos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error");
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
            txtNombre.Text = p.nombre;
            cmbTipo.Text = p.tipo;
            panelEditar.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El nombre no puede estar vacio.", "Aviso");
                return;
            }

            try
            {
                var options = new RestClientOptions("http://localhost:8080");
                var client = new RestClient(options);
                var request = new RestRequest("/computadores/" + codigoComputador + "/perifericos/" + idPerifericoSeleccionado, Method.Put);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");

                var body = new
                {
                    id = idPerifericoSeleccionado,
                    nombre = txtNombre.Text.Trim(),
                    tipo = cmbTipo.Text,
                    activo = true
                };
                request.AddJsonBody(body);

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Periferico actualizado correctamente.", "Exito");
                    panelEditar.Visible = false;
                    idPerifericoSeleccionado = 0;
                    CargarPerifericos();
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

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            panelEditar.Visible = false;
            idPerifericoSeleccionado = 0;
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
