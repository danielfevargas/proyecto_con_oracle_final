using RestSharp;

namespace ClienteComputador
{
    public partial class GUIGestionarPeriferico : Form
    {
        private int codigoComputador = 0;
        private int idPerifericoSeleccionado = 0;

        public GUIGestionarPeriferico()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnBuscarComputador_Click(object sender, EventArgs e)
        {
            if (txtCodigoComputador.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del computador.", "Aviso");
                return;
            }

            try
            {
                int codigo = int.Parse(txtCodigoComputador.Text);
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores/" + codigo, Method.Get);
                var response = client.Get<Computador>(request);

                if (response != null)
                {
                    codigoComputador = response.codigo;
                    lblComputador.Text = "Computador: " + response.marca + " - Codigo: " + response.codigo;
                    CargarPerifericos();
                }
                else
                {
                    MessageBox.Show("No se encontro ningun computador con ese codigo.", "Aviso");
                    codigoComputador = 0;
                    lblComputador.Text = "";
                    dgvPerifericos.DataSource = null;
                }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (codigoComputador == 0)
            {
                MessageBox.Show("Primero busque un computador.", "Aviso");
                return;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("El nombre del periferico es obligatorio.", "Aviso");
                return;
            }

            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores/" + codigoComputador + "/perifericos", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(new
                {
                    nombre = txtNombre.Text,
                    tipo = cmbTipo.Text,
                    activo = true
                });

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Periferico agregado correctamente.", "Exito");
                    txtNombre.Text = "";
                    CargarPerifericos();
                }
                else
                {
                    MessageBox.Show("Error al agregar: " + response.StatusCode, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPerifericos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un periferico de la tabla.", "Aviso");
                return;
            }

            var periferico = (Periferico)dgvPerifericos.CurrentRow.DataBoundItem;
            idPerifericoSeleccionado = periferico.id;
            txtNombreEditar.Text = periferico.nombre;
            cmbTipoEditar.Text = periferico.tipo;

            panelEditar.Visible = true;
        }

        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            if (idPerifericoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un periferico para editar.", "Aviso");
                return;
            }

            try
            {
                var client = new RestClient("http://localhost:8080");
                var request = new RestRequest("/computadores/" + codigoComputador + "/perifericos/" + idPerifericoSeleccionado, Method.Put);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(new
                {
                    nombre = txtNombreEditar.Text,
                    tipo = cmbTipoEditar.Text,
                    activo = true
                });

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
                    MessageBox.Show("Error al actualizar: " + response.StatusCode, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPerifericos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un periferico de la tabla.", "Aviso");
                return;
            }

            var periferico = (Periferico)dgvPerifericos.CurrentRow.DataBoundItem;

            var confirmar = MessageBox.Show(
                "Desea desactivar el periferico: " + periferico.nombre + "?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    var client = new RestClient("http://localhost:8080");
                    var request = new RestRequest("/computadores/" + codigoComputador + "/perifericos/" + periferico.id, Method.Delete);
                    var response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        MessageBox.Show("Periferico desactivado correctamente.", "Exito");
                        CargarPerifericos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar: " + response.StatusCode, "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error");
                }
            }
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            panelEditar.Visible = false;
            idPerifericoSeleccionado = 0;
        }

        private void OcultarColumnas()
        {
            string[] ocultar = { "activo" };
            foreach (var col in ocultar)
                if (dgvPerifericos.Columns.Contains(col))
                    dgvPerifericos.Columns[col].Visible = false;

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
