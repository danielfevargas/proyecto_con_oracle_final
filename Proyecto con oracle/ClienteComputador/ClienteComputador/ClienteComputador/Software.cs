namespace ClienteComputador
{
    public class Software
    {
        public int id { get; set; }
        public int codigoComputador { get; set; }
        public string nombre { get; set; } = "";
        public string version { get; set; } = "";
        public string tipo { get; set; } = "";
        public double precio { get; set; }
        public string fechaInstalacion { get; set; } = "";
        public bool activo { get; set; }

        public string ActivoStr => activo ? "Activo" : "Inactivo";
        public string PrecioStr => "$" + precio.ToString("F2");
    }
}
