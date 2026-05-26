function GUIAcercaDe() {
  return (
    <div className="ventana">
      <h2>Acerca de</h2>

      <div style={{ textAlign: "center", padding: "10px" }}>
        <h3 style={{ color: "#e94560", fontSize: "22px" }}>ComputerApp - Cliente React</h3>
        <p style={{ color: "#555" }}>Version 2.0</p>
        <p style={{ color: "#555", marginBottom: "20px" }}>
          Desarrollo de Aplicaciones Empresariales
          <br />
          Universidad de Ibague
        </p>

        <p style={{ fontWeight: "bold", marginBottom: "10px" }}>Integrantes del equipo:</p>

        <div className="integrante">Fredy Ortiz</div>
        <div className="integrante">Alejandro Lozano</div>
        <div className="integrante">Daniel Vargas</div>
        <div className="integrante">Juan Bahamon</div>
      </div>
    </div>
  );
}

export default GUIAcercaDe;
