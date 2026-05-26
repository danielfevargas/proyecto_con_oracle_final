import { useState } from "react";
import SoftwareService from "./SoftwareService";

function GUIListarSoftware({ onMensaje }) {
  var [lista, setLista] = useState([]);
  var [filtroTipo, setFiltroTipo] = useState("");
  var [filtroNombre, setFiltroNombre] = useState("");
  var [cargando, setCargando] = useState(false);

  async function handleListar() {
    setCargando(true);
    var resultado = await SoftwareService.listar(
      filtroTipo !== "" ? filtroTipo : null,
      filtroNombre !== "" ? filtroNombre : null,
      null
    );
    setLista(resultado);
    setCargando(false);
    if (resultado.length === 0) {
      onMensaje("No se encontraron softwares.", "error");
    }
  }

  function handleLimpiar() {
    setFiltroTipo("");
    setFiltroNombre("");
    setLista([]);
  }

  return (
    <div className="ventana">
      <h2>Listar Softwares</h2>

      <div className="fila">
        <div className="grupo">
          <label>Filtrar por Tipo</label>
          <input type="text" value={filtroTipo} onChange={function(e) { setFiltroTipo(e.target.value); }} placeholder="Ej: Diseño (opcional)" />
        </div>
        <div className="grupo">
          <label>Filtrar por Nombre</label>
          <input type="text" value={filtroNombre} onChange={function(e) { setFiltroNombre(e.target.value); }} placeholder="Ej: Office (opcional)" />
        </div>
      </div>

      <div className="botones">
        <button className="btn-azul" onClick={handleListar}>{cargando ? "Cargando..." : "Listar"}</button>
        <button className="btn-gris" onClick={handleLimpiar}>Limpiar</button>
      </div>

      {lista.length > 0 && (
        <div style={{ overflowX: "auto", marginTop: "20px" }}>
          <table className="tabla">
            <thead>
              <tr>
                <th>ID</th>
                <th>Computador</th>
                <th>Nombre</th>
                <th>Version</th>
                <th>Tipo</th>
                <th>Precio</th>
                <th>Fecha Instalacion</th>
              </tr>
            </thead>
            <tbody>
              {lista.map(function(s) {
                return (
                  <tr key={s.id}>
                    <td>{s.id}</td>
                    <td>{s.codigoComputador}</td>
                    <td>{s.nombre}</td>
                    <td>{s.version}</td>
                    <td>{s.tipo}</td>
                    <td>${s.precio}</td>
                    <td>{s.fechaInstalacion}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}

export default GUIListarSoftware;
