import { useState } from "react";
import PerifericoService from "./PerifericoService";
import { Periferico } from "./Periferico";
import ComputadorService from "./ComputadorService";

function GUIGestionarPeriferico({ onMensaje }) {

  var [codigoComputador, setCodigoComputador] = useState("");
  var [computadorEncontrado, setComputadorEncontrado] = useState(null);
  var [lista, setLista] = useState([]);
  var [nuevoNombre, setNuevoNombre] = useState("");
  var [nuevoTipo, setNuevoTipo] = useState("Entrada");
  var [perifericoEditando, setPerifericoEditando] = useState(null);
  var [editNombre, setEditNombre] = useState("");
  var [editTipo, setEditTipo] = useState("");
  var [perifericoEliminar, setPerifericoEliminar] = useState(null);

  async function handleBuscarComputador() {
    if (codigoComputador === "") {
      onMensaje("Ingrese el codigo del computador.", "error");
      return;
    }

    var resultado = await ComputadorService.buscarPorCodigo(parseInt(codigoComputador));

    if (resultado === null) {
      onMensaje("No se encontro ningun computador con ese codigo.", "error");
      setComputadorEncontrado(null);
      setLista([]);
      return;
    }

    setComputadorEncontrado(resultado);
    cargarPerifericos(parseInt(codigoComputador));
  }

  async function cargarPerifericos(codigo) {
    var resultado = await PerifericoService.listar(codigo);
    setLista(resultado);
  }

  async function handleAgregar() {
    if (nuevoNombre === "") {
      onMensaje("El nombre del periferico es obligatorio.", "error");
      return;
    }

    var periferico = new Periferico(0, nuevoNombre, nuevoTipo, true);
    var resultado = await PerifericoService.agregar(parseInt(codigoComputador), periferico);

    if (resultado !== null) {
      onMensaje("Periferico agregado correctamente.", "exito");
      setNuevoNombre("");
      setNuevoTipo("Entrada");
      cargarPerifericos(parseInt(codigoComputador));
    } else {
      onMensaje("Error al agregar el periferico.", "error");
    }
  }

  function handleIniciarEdicion(p) {
    setPerifericoEditando(p);
    setEditNombre(p.nombre);
    setEditTipo(p.tipo);
    setPerifericoEliminar(null);
  }

  async function handleGuardarEdicion() {
    if (editNombre === "") {
      onMensaje("El nombre no puede estar vacio.", "error");
      return;
    }

    var actualizado = new Periferico(perifericoEditando.id, editNombre, editTipo, true);
    var resultado = await PerifericoService.actualizar(parseInt(codigoComputador), perifericoEditando.id, actualizado);

    if (resultado === true) {
      onMensaje("Periferico actualizado correctamente.", "exito");
      setPerifericoEditando(null);
      cargarPerifericos(parseInt(codigoComputador));
    } else {
      onMensaje("Error al actualizar el periferico.", "error");
    }
  }

  function handleIniciarEliminar(p) {
    setPerifericoEliminar(p);
    setPerifericoEditando(null);
  }

  async function handleConfirmarEliminar() {
    var resultado = await PerifericoService.eliminar(parseInt(codigoComputador), perifericoEliminar.id);

    if (resultado === true) {
      onMensaje("Periferico desactivado correctamente.", "exito");
      setPerifericoEliminar(null);
      cargarPerifericos(parseInt(codigoComputador));
    } else {
      onMensaje("Error al eliminar el periferico.", "error");
    }
  }

  return (
    <div className="ventana">
      <h2>Gestionar Perifericos</h2>

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

      {computadorEncontrado !== null && (
        <div>
          <div className="caja-resultado" style={{ marginTop: "15px", marginBottom: "20px" }}>
            <p><strong>Computador:</strong> {computadorEncontrado.marca} — Codigo: {computadorEncontrado.codigo}</p>
            <p><strong>Estado:</strong> {computadorEncontrado.estado}</p>
          </div>

          <h3 style={{ marginBottom: "12px", color: "#1a1a2e" }}>Agregar nuevo periferico</h3>
          <div className="fila">
            <div className="grupo">
              <label>Nombre</label>
              <input
                type="text"
                value={nuevoNombre}
                onChange={function(e) { setNuevoNombre(e.target.value); }}
                placeholder="Ej: Teclado mecanico"
              />
            </div>
            <div className="grupo">
              <label>Tipo</label>
              <select value={nuevoTipo} onChange={function(e) { setNuevoTipo(e.target.value); }}>
                <option value="Entrada">Entrada</option>
                <option value="Salida">Salida</option>
                <option value="Almacenamiento">Almacenamiento</option>
                <option value="Otro">Otro</option>
              </select>
            </div>
          </div>
          <div className="botones">
            <button className="btn-verde" onClick={handleAgregar}>Agregar Periferico</button>
          </div>

          <h3 style={{ marginTop: "20px", marginBottom: "12px", color: "#1a1a2e" }}>Perifericos del computador</h3>
          <div style={{ overflowX: "auto" }}>
            <table className="tabla">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Nombre</th>
                  <th>Tipo</th>
                  <th>Estado</th>
                  <th>Acciones</th>
                </tr>
              </thead>
              <tbody>
                {lista.length === 0 ? (
                  <tr>
                    <td colSpan="5" style={{ textAlign: "center", color: "#888", padding: "20px" }}>
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
                        <td>
                          <button
                            className="btn-azul"
                            style={{ padding: "5px 12px", fontSize: "12px", marginRight: "6px" }}
                            onClick={function() { handleIniciarEdicion(p); }}
                          >
                            Editar
                          </button>
                          <button
                            className="btn-rojo"
                            style={{ padding: "5px 12px", fontSize: "12px" }}
                            onClick={function() { handleIniciarEliminar(p); }}
                          >
                            Eliminar
                          </button>
                        </td>
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          </div>

          {perifericoEditando !== null && (
            <div className="caja-resultado" style={{ marginTop: "20px" }}>
              <p style={{ fontWeight: "bold", marginBottom: "12px" }}>Editando periferico ID: {perifericoEditando.id}</p>
              <div className="fila">
                <div className="grupo">
                  <label>Nombre</label>
                  <input type="text" value={editNombre} onChange={function(e) { setEditNombre(e.target.value); }} />
                </div>
                <div className="grupo">
                  <label>Tipo</label>
                  <select value={editTipo} onChange={function(e) { setEditTipo(e.target.value); }}>
                    <option value="Entrada">Entrada</option>
                    <option value="Salida">Salida</option>
                    <option value="Almacenamiento">Almacenamiento</option>
                    <option value="Otro">Otro</option>
                  </select>
                </div>
              </div>
              <div className="botones">
                <button className="btn-verde" onClick={handleGuardarEdicion}>Guardar Cambios</button>
                <button className="btn-gris" onClick={function() { setPerifericoEditando(null); }}>Cancelar</button>
              </div>
            </div>
          )}

          {perifericoEliminar !== null && (
            <div className="caja-resultado" style={{ marginTop: "20px", borderLeft: "4px solid #dc3545" }}>
              <p style={{ color: "#dc3545", fontWeight: "bold", marginBottom: "10px" }}>
                Desea desactivar este periferico?
              </p>
              <p><strong>ID:</strong> {perifericoEliminar.id}</p>
              <p><strong>Nombre:</strong> {perifericoEliminar.nombre}</p>
              <p><strong>Tipo:</strong> {perifericoEliminar.tipo}</p>
              <div className="botones" style={{ marginTop: "12px" }}>
                <button className="btn-rojo" onClick={handleConfirmarEliminar}>Confirmar Eliminacion</button>
                <button className="btn-gris" onClick={function() { setPerifericoEliminar(null); }}>Cancelar</button>
              </div>
            </div>
          )}
        </div>
      )}
    </div>
  );
}

export default GUIGestionarPeriferico;
