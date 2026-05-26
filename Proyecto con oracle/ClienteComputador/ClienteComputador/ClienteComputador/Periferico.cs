namespace ClienteComputador
{
    public class Periferico
    {
        public int id { get; set; }
        public string nombre { get; set; } = "";
        public string tipo { get; set; } = "";
        public bool activo { get; set; }

        public string ActivoStr => activo ? "Activo" : "Inactivo";
    }
}
