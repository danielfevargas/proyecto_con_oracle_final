import { useState } from "react";
import ComputadorService from "./ComputadorService";
import PerifericoService from "./PerifericoService";

function GUIEliminarPeriferico({ onMensaje }) {

  var [codigoComputador, setCodigoComputador] = useState("");
  var [computador, setComputador] = useState(null);
  var [listaPerifericos, setListaPerifericos] = useState([]);
  var [perifericoSeleccionado, setPerifericoSeleccionado] = useState(null);

  async function handleBuscarComputador() {
    if (codigoComputador === "") {
      onMensaje("Ingrese el codigo del computador.", "error");
      return;
    }

    var resultado = await ComputadorService.buscarPorCodigo(parseInt(codigoComputador));
    if (resultado === null) {
      onMensaje("No se encontro ningun computador con ese codigo.", "error");
      setComputador(null);
      setListaPerifericos([]);
      setPerifericoSeleccionado(null);
      return;
    }

    setComputador(resultado);
    setPerifericoSeleccionado(null);

    var perifericos = await PerifericoService.listar(parseInt(codigoComputador));
    setListaPerifericos(perifericos);
  }

  function handleSeleccionar(p) {
    setPerifericoSeleccionado(p);
  }

  async function handleEliminar() {
    var resultado = await PerifericoService.eliminar(parseInt(codigoComputador), perifericoSeleccionado.id);

    if (resultado === true) {
      onMensaje("Periferico desactivado correctamente.", "exito");
      setPerifericoSeleccionado(null);
      var perifericos = await PerifericoService.listar(parseInt(codigoComputador));
      setListaPerifericos(perifericos);
    } else {
      onMensaje("Error al eliminar el periferico.", "error");
    }
  }

  return (
    <div className="ventana">
      <h2>Eliminar Periferico</h2>

      <p style={{ color: "#555", fontSize: "14px" }}>Paso 1: ingrese el codigo del computador.</p>
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
        <button className="btn-azul" onClick={handleBuscarComputador}>Buscar Computador</button>
      </div>

      {computador !== null && (
        <div>
          <div className="caja-resultado" style={{ marginTop: "15px", marginBottom: "15px" }}>
            <p><strong>Computador:</strong> {computador.marca} — Codigo: {computador.codigo}</p>
          </div>

          <p style={{ color: "#555", fontSize: "14px" }}>Paso 2: seleccione el periferico a eliminar de la lista.</p>

          <div style={{ overflowX: "auto", marginTop: "10px" }}>
            <table className="tabla">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Nombre</th>
                  <th>Tipo</th>
                  <th>Seleccionar</th>
                </tr>
              </thead>
              <tbody>
                {listaPerifericos.length === 0 ? (
                  <tr>
                    <td colSpan="4" style={{ textAlign: "center", color: "#888", padding: "15px" }}>
                      No hay perifericos registrados.
                    </td>
                  </tr>
                ) : (
                  listaPerifericos.map(function(p) {
                    return (
                      <tr key={p.id} style={{ background: perifericoSeleccionado !== null && perifericoSeleccionado.id === p.id ? "#fff3cd" : "" }}>
                        <td>{p.id}</td>
                        <td>{p.nombre}</td>
                        <td>{p.tipo}</td>
                        <td>
                          <button
                            className="btn-azul"
                            style={{ padding: "4px 12px", fontSize: "12px" }}
                            onClick={function() { handleSeleccionar(p); }}
                          >
                            Seleccionar
                          </button>
                        </td>
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          </div>
        </div>
      )}

      {perifericoSeleccionado !== null && (
        <div className="caja-resultado" style={{ marginTop: "20px", borderLeft: "4px solid #dc3545" }}>
          <p style={{ color: "#dc3545", fontWeight: "bold", marginBottom: "10px" }}>
            Desea desactivar este periferico?
          </p>
          <p><strong>ID:</strong> {perifericoSeleccionado.id}</p>
          <p><strong>Nombre:</strong> {perifericoSeleccionado.nombre}</p>
          <p><strong>Tipo:</strong> {perifericoSeleccionado.tipo}</p>
          <p>
            <strong>Estado actual: </strong>
            <span className="badge-activo">Activo</span>
            {" → "}
            <span className="badge-inactivo">Inactivo</span>
          </p>
          <div className="botones" style={{ marginTop: "12px" }}>
            <button className="btn-rojo" onClick={handleEliminar}>Confirmar Eliminacion</button>
            <button className="btn-gris" onClick={function() { setPerifericoSeleccionado(null); }}>Cancelar</button>
          </div>
        </div>
      )}
    </div>
  );
}

export default GUIEliminarPeriferico;
