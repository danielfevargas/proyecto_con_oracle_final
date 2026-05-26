import { useState } from "react";
import SoftwareService from "./SoftwareService";
import { Software } from "./Software";

function GUIActualizarSoftware({ onMensaje }) {
  var [id, setId] = useState("");
  var [software, setSoftware] = useState(null);
  var [codigoComputador, setCodigoComputador] = useState("");
  var [nombre, setNombre] = useState("");
  var [version, setVersion] = useState("");
  var [tipo, setTipo] = useState("Ofimatica");
  var [precio, setPrecio] = useState("");
  var [fechaInstalacion, setFechaInstalacion] = useState("");

  async function handleBuscar() {
    if (id === "") {
      onMensaje("Ingrese el ID del software.", "error");
      return;
    }
    var resultado = await SoftwareService.buscar(parseInt(id));
    if (resultado !== null) {
      setSoftware(resultado);
      setCodigoComputador(resultado.codigoComputador);
      setNombre(resultado.nombre);
      setVersion(resultado.version);
      setTipo(resultado.tipo);
      setPrecio(resultado.precio);
      setFechaInstalacion(resultado.fechaInstalacion ? resultado.fechaInstalacion.substring(0, 10) : "");
    } else {
      setSoftware(null);
      onMensaje("No se encontro software con ese ID.", "error");
    }
  }

  async function handleActualizar() {
    if (nombre === "" || version === "" || codigoComputador === "") {
      onMensaje("Codigo computador, nombre y version son obligatorios.", "error");
      return;
    }
    if (isNaN(parseFloat(precio)) || parseFloat(precio) < 0) {
      onMensaje("El precio debe ser mayor o igual a 0.", "error");
      return;
    }

    var actualizado = new Software(
      software.id,
      parseInt(codigoComputador),
      nombre,
      version,
      tipo,
      parseFloat(precio),
      fechaInstalacion + "T00:00:00",
      true
    );

    var ok = await SoftwareService.actualizar(software.id, actualizado);
    if (ok) {
      onMensaje("Software actualizado correctamente.", "exito");
      setSoftware(null);
      setId("");
    } else {
      onMensaje("Error al actualizar el software.", "error");
    }
  }

  return (
    <div className="ventana">
      <h2>Actualizar Software</h2>

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
          <hr style={{ margin: "20px 0", borderColor: "#dee2e6" }} />

          <div className="fila">
            <div className="grupo">
              <label>Codigo Computador *</label>
              <input type="number" value={codigoComputador} onChange={function(e) { setCodigoComputador(e.target.value); }} />
            </div>
            <div className="grupo">
              <label>Nombre *</label>
              <input type="text" value={nombre} onChange={function(e) { setNombre(e.target.value); }} />
            </div>
          </div>

          <div className="fila">
            <div className="grupo">
              <label>Version *</label>
              <input type="text" value={version} onChange={function(e) { setVersion(e.target.value); }} />
            </div>
            <div className="grupo">
              <label>Tipo</label>
              <select value={tipo} onChange={function(e) { setTipo(e.target.value); }}>
                <option>Ofimatica</option>
                <option>Diseño</option>
                <option>Desarrollo</option>
                <option>Seguridad</option>
                <option>Educacion</option>
                <option>Entretenimiento</option>
                <option>Otro</option>
              </select>
            </div>
          </div>

          <div className="fila">
            <div className="grupo">
              <label>Precio (USD)</label>
              <input type="number" step="0.01" value={precio} onChange={function(e) { setPrecio(e.target.value); }} />
            </div>
            <div className="grupo">
              <label>Fecha Instalacion *</label>
              <input type="date" value={fechaInstalacion} onChange={function(e) { setFechaInstalacion(e.target.value); }} />
            </div>
          </div>

          <div className="botones" style={{ marginTop: "20px" }}>
            <button className="btn-azul" onClick={handleActualizar}>Guardar Cambios</button>
          </div>
        </>
      )}
    </div>
  );
}

export default GUIActualizarSoftware;
