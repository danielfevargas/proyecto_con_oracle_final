import { useState } from "react";
import SoftwareService from "./SoftwareService";

function GUIEliminarSoftware({ onMensaje }) {
  var [id, setId] = useState("");
  var [software, setSoftware] = useState(null);

  async function handleBuscar() {
    if (id === "") {
      onMensaje("Ingrese el ID del software.", "error");
      return;
    }
    var resultado = await SoftwareService.buscar(parseInt(id));
    if (resultado !== null) {
      setSoftware(resultado);
    } else {
      setSoftware(null);
      onMensaje("No se encontro software con ese ID.", "error");
    }
  }

  async function handleEliminar() {
    if (software === null) return;
    var ok = await SoftwareService.eliminar(software.id);
    if (ok) {
      onMensaje("Software '" + software.nombre + "' eliminado correctamente.", "exito");
      setSoftware(null);
      setId("");
    } else {
      onMensaje("Error al eliminar el software.", "error");
    }
  }

  return (
    <div className="ventana">
      <h2>Eliminar Software</h2>

      <div className="fila">
        <div className="grupo">
          <label>ID del Software</label>
          <input type="number" value={id} onChange={function(e) { setId(e.target.value); }} placeholder="Ingrese el ID" />
        </div>
        <div className="grupo" style={{ justifyContent: "flex-end" }}>
          <label>&nbsp;</label>
          <button className="btn-azul" onClick={handleBuscar}>Buscar</button>
        </div>
      </div>

      {software !== null && (
        <>
          <div className="caja-resultado" style={{ marginTop: "20px" }}>
            <div className="fila">
              <div className="grupo">
                <label>ID</label>
                <input type="text" readOnly value={software.id} />
              </div>
              <div className="grupo">
                <label>Computador</label>
                <input type="text" readOnly value={software.codigoComputador} />
              </div>
            </div>
            <div className="fila">
              <div className="grupo">
                <label>Nombre</label>
                <input type="text" readOnly value={software.nombre} />
              </div>
              <div className="grupo">
                <label>Version</label>
                <input type="text" readOnly value={software.version} />
              </div>
            </div>
            <div className="fila">
              <div className="grupo">
                <label>Tipo</label>
                <input type="text" readOnly value={software.tipo} />
              </div>
              <div className="grupo">
                <label>Precio</label>
                <input type="text" readOnly value={"$" + software.precio} />
              </div>
            </div>
            <div className="fila">
              <div className="grupo">
                <label>Fecha Instalacion</label>
                <input type="text" readOnly value={software.fechaInstalacion} />
              </div>
              <div className="grupo" />
            </div>
          </div>
          <div className="botones" style={{ marginTop: "15px" }}>
            <button className="btn-rojo" onClick={handleEliminar}>Confirmar Eliminacion</button>
          </div>
        </>
      )}
    </div>
  );
}

export default GUIEliminarSoftware;
