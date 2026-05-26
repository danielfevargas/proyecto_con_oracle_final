import { useState } from "react";
import ComputadorService from "./ComputadorService";
import PerifericoService from "./PerifericoService";

function GUIListarPerifericos({ onMensaje }) {

  var [codigoComputador, setCodigoComputador] = useState("");
  var [computador, setComputador] = useState(null);
  var [lista, setLista] = useState([]);

  async function handleBuscarComputador() {
    if (codigoComputador === "") {
      onMensaje("Ingrese el codigo del computador.", "error");
      return;
    }

    var resultado = await ComputadorService.buscarPorCodigo(parseInt(codigoComputador));
    if (resultado === null) {
      onMensaje("No se encontro ningun computador con ese codigo.", "error");
      setComputador(null);
      setLista([]);
      return;
    }

    setComputador(resultado);
    var perifericos = await PerifericoService.listar(parseInt(codigoComputador));
    setLista(perifericos);
  }

  return (
    <div className="ventana">
      <h2>Listar Perifericos</h2>

      <div className="fila">
        <div className="grupo">
          <label>Codigo del Computador</label>
          <input
            type="number"
            value={codigoComputador}
            onChange={function(e) { setCodigoComputador(e.target.value); }}
            placeholder="Ej: 101"
          />
        </div>
      </div>
      <div className="botones">
        <button className="btn-azul" onClick={handleBuscarComputador}>Buscar</button>
      </div>

      {computador !== null && (
        <div>
          <div className="caja-resultado" style={{ marginTop: "15px", marginBottom: "15px" }}>
            <p><strong>Computador:</strong> {computador.marca} — Codigo: {computador.codigo}</p>
          </div>

          <div style={{ overflowX: "auto" }}>
            <table className="tabla">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Nombre</th>
                  <th>Tipo</th>
                  <th>Estado</th>
                </tr>
              </thead>
              <tbody>
                {lista.length === 0 ? (
                  <tr>
                    <td colSpan="4" style={{ textAlign: "center", color: "#888", padding: "20px" }}>
                      No hay perifericos registrados.
                    </td>
                  </tr>
                ) : (
                  lista.map(function(p) {
                    return (
                      <tr key={p.id}>
                        <td>{p.id}</td>
                        <td>{p.nombre}</td>
                        <td>{p.tipo}</td>
                        <td>
                          {p.activo === true ? (
                            <span className="badge-activo">Activo</span>
                          ) : (
                            <span className="badge-inactivo">Inactivo</span>
                          )}
                        </td>
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          </div>
          <p style={{ marginTop: "10px", color: "#555", fontSize: "13px" }}>
            Total: {lista.length} perifericos
          </p>
        </div>
      )}
    </div>
  );
}

export default GUIListarPerifericos;
