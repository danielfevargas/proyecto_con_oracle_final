import { useState } from "react";
import SoftwareService from "./SoftwareService";
import { Software } from "./Software";

function GUIAgregarSoftware({ onMensaje }) {
  var [id, setId] = useState("");
  var [codigoComputador, setCodigoComputador] = useState("");
  var [nombre, setNombre] = useState("");
  var [version, setVersion] = useState("");
  var [tipo, setTipo] = useState("Ofimatica");
  var [precio, setPrecio] = useState("");
  var [fechaInstalacion, setFechaInstalacion] = useState("");

  async function handleGuardar() {
    if (id === "" || codigoComputador === "" || nombre === "" || version === "" || fechaInstalacion === "") {
      onMensaje("ID, codigo computador, nombre, version y fecha son obligatorios.", "error");
      return;
    }
    if (isNaN(parseInt(id)) || parseInt(id) <= 0) {
      onMensaje("El ID debe ser un numero entero positivo.", "error");
      return;
    }
    if (isNaN(parseFloat(precio)) || parseFloat(precio) < 0) {
      onMensaje("El precio debe ser mayor o igual a 0.", "error");
      return;
    }

    var soft = new Software(
      parseInt(id),
      parseInt(codigoComputador),
      nombre,
      version,
      tipo,
      parseFloat(precio),
      fechaInstalacion + "T00:00:00",
      true
    );

    var resultado = await SoftwareService.agregar(soft);
    if (resultado !== null) {
      onMensaje("Software agregado correctamente.", "exito");
      handleLimpiar();
    } else {
      onMensaje("Error: ya existe un software con ese ID o el microservicio no esta corriendo.", "error");
    }
  }

  function handleLimpiar() {
    setId("");
    setCodigoComputador("");
    setNombre("");
    setVersion("");
    setTipo("Ofimatica");
    setPrecio("");
    setFechaInstalacion("");
  }

  return (
    <div className="ventana">
      <h2>Agregar Software</h2>

      <div className="fila">
        <div className="grupo">
          <label>ID *</label>
          <input type="number" value={id} onChange={function(e) { setId(e.target.value); }} placeholder="Ej: 1" />
        </div>
        <div className="grupo">
          <label>Codigo Computador *</label>
          <input type="number" value={codigoComputador} onChange={function(e) { setCodigoComputador(e.target.value); }} placeholder="Ej: 101" />
        </div>
      </div>

      <div className="fila">
        <div className="grupo">
          <label>Nombre *</label>
          <input type="text" value={nombre} onChange={function(e) { setNombre(e.target.value); }} placeholder="Ej: Microsoft Office" />
        </div>
        <div className="grupo">
          <label>Version *</label>
          <input type="text" value={version} onChange={function(e) { setVersion(e.target.value); }} placeholder="Ej: 2021" />
        </div>
      </div>

      <div className="fila">
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
        <div className="grupo">
          <label>Precio (USD)</label>
          <input type="number" step="0.01" value={precio} onChange={function(e) { setPrecio(e.target.value); }} placeholder="0.00" />
        </div>
      </div>

      <div className="fila">
        <div className="grupo">
          <label>Fecha de Instalacion *</label>
          <input type="date" value={fechaInstalacion} onChange={function(e) { setFechaInstalacion(e.target.value); }} />
        </div>
        <div className="grupo" />
      </div>

      <div className="botones" style={{ marginTop: "20px" }}>
        <button className="btn-azul" onClick={handleGuardar}>Guardar</button>
        <button className="btn-gris" onClick={handleLimpiar}>Limpiar</button>
      </div>
    </div>
  );
}

export default GUIAgregarSoftware;
