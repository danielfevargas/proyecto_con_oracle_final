import { useState } from "react";
import ComputadorService from "./ComputadorService";
import PerifericoService from "./PerifericoService";
import { Periferico } from "./Periferico";

function GUIActualizarPeriferico({ onMensaje }) {

  var [codigoComputador, setCodigoComputador] = useState("");
  var [computador, setComputador] = useState(null);
  var [listaPerifericos, setListaPerifericos] = useState([]);
  var [perifericoSeleccionado, setPerifericoSeleccionado] = useState(null);
  var [nombre, setNombre] = useState("");
  var [tipo, setTipo] = useState("Entrada");

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
    setNombre(p.nombre);
    setTipo(p.tipo);
  }

  async function handleActualizar() {
    if (nombre === "") {
      onMensaje("El nombre no puede estar vacio.", "error");
      return;
    }

    var actualizado = new Periferico(perifericoSeleccionado.id, nombre, tipo, true);
    var resultado = await PerifericoService.actualizar(parseInt(codigoComputador), perifericoSeleccionado.id, actualizado);

    if (resultado === true) {
      onMensaje("Periferico actualizado correctamente.", "exito");
      setPerifericoSeleccionado(null);
      var perifericos = await PerifericoService.listar(parseInt(codigoComputador));
      setListaPerifericos(perifericos);
    } else {
      onMensaje("Error al actualizar el periferico.", "error");
    }
  }

  return (
    <div className="ventana">
      <h2>Actualizar Periferico</h2>

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

          <p style={{ color: "#555", fontSize: "14px" }}>Paso 2: seleccione el periferico a actualizar.</p>

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
        <div className="caja-resultado" style={{ marginTop: "20px" }}>
          <p style={{ fontWeight: "bold", marginBottom: "12px" }}>Paso 3: edite los campos del periferico ID: {perifericoSeleccionado.id}</p>
          <div className="fila">
            <div className="grupo">
              <label>Nombre</label>
              <input
                type="text"
                value={nombre}
                onChange={function(e) { setNombre(e.target.value); }}
              />
            </div>
            <div className="grupo">
              <label>Tipo</label>
              <select value={tipo} onChange={function(e) { setTipo(e.target.value); }}>
                <option value="Entrada">Entrada</option>
                <option value="Salida">Salida</option>
                <option value="Almacenamiento">Almacenamiento</option>
                <option value="Otro">Otro</option>
              </select>
            </div>
          </div>
          <div className="botones">
            <button className="btn-verde" onClick={handleActualizar}>Guardar Cambios</button>
            <button className="btn-gris" onClick={function() { setPerifericoSeleccionado(null); }}>Cancelar</button>
          </div>
        </div>
      )}
    </div>
  );
}

export default GUIActualizarPeriferico;
