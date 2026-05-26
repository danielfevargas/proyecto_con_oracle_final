using RestSharp;

namespace ClienteComputador
{
    public partial class GUIListarPerifericos : Form
    {
        public GUIListarPerifericos()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
                    return;
                }
                lblComputador.Text = "Computador: " + comp.marca + " — Codigo: " + comp.codigo;

                var reqPer = new RestRequest("/computadores/" + txtCodigo.Text + "/perifericos", Method.Get);
                var lista = client.Get<List<Periferico>>(reqPer);

                if (lista != null)
                {
                    dgvPerifericos.DataSource = lista;
                    OcultarColumnas();
                    lblTotal.Text = "Total: " + lista.Count + " perifericos";
                }
                else
                {
                    dgvPerifericos.DataSource = null;
                    lblTotal.Text = "Total: 0 perifericos";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
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
