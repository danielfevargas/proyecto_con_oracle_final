namespace ClienteComputador
{
    public partial class GUIPrincipal : Form
    {
        public GUIPrincipal()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        // --- Menu Computadores ---

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAgregarComputador frm = new GUIAgregarComputador();
            frm.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIBuscarComputador frm = new GUIBuscarComputador();
            frm.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIListarComputador frm = new GUIListarComputador();
            frm.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIEliminarComputador frm = new GUIEliminarComputador();
            frm.Show();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIActualizarComputador frm = new GUIActualizarComputador();
            frm.Show();
        }

        // --- Menu Perifericos ---

        private void agregarPericoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAgregarPeriferico frm = new GUIAgregarPeriferico();
            frm.Show();
        }

        private void listarPericosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIListarPerifericos frm = new GUIListarPerifericos();
            frm.Show();
        }

        private void actualizarPericoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIActualizarPeriferico frm = new GUIActualizarPeriferico();
            frm.Show();
        }

        private void eliminarPericoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIEliminarPeriferico frm = new GUIEliminarPeriferico();
            frm.Show();
        }

        // --- Menu Software ---

        private void agregarSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAgregarSoftware frm = new GUIAgregarSoftware();
            frm.Show();
        }

        private void buscarSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIBuscarSoftware frm = new GUIBuscarSoftware();
            frm.Show();
        }

        private void listarSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIListarSoftware frm = new GUIListarSoftware();
            frm.Show();
        }

        private void actualizarSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIActualizarSoftware frm = new GUIActualizarSoftware();
            frm.Show();
        }

        private void eliminarSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIEliminarSoftware frm = new GUIEliminarSoftware();
            frm.Show();
        }

        // --- Menu Ayuda ---

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Gestion de Computadores\nVersion 1.0\n\n" +
                "Integrantes:\n- Integrante 1\n- Integrante 2\n- Integrante 3",
                "Acerca de",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
