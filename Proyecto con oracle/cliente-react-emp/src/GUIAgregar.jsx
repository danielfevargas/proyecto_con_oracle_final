import { useState } from "react";
import ComputadorService from "./ComputadorService";
import { Computador } from "./Computador";

function GUIAgregar({ onMensaje }) {

  var [codigo, setCodigo] = useState("");
  var [marca, setMarca] = useState("");
  var [fecha, setFecha] = useState("");
  var [estado, setEstado] = useState("Bueno");
  var [portatil, setPortatil] = useState(false);
  var [costo, setCosto] = useState("");

  async function handleGuardar() {
    if (codigo === "" || marca === "") {
      onMensaje("El codigo y la marca son obligatorios.", "error");
      return;
    }
    if (isNaN(parseInt(codigo)) || parseInt(codigo) <= 0) {
      onMensaje("El codigo debe ser un numero entero positivo.", "error");
      return;
    }

    var computador = new Computador(
      parseInt(codigo),
      marca,
      fecha !== "" ? fecha + ":00" : new Date().toISOString().slice(0, 19),
      estado,
      portatil,
      parseFloat(costo) || 0,
      [],
      true
    );

    var resultado = await ComputadorService.agregar(computador);

    if (resultado === true) {
      onMensaje("Computador agregado correctamente.", "exito");
      handleLimpiar();
    } else {
      onMensaje("Error al agregar el computador.", "error");
    }
  }

  function handleLimpiar() {
    setCodigo("");
    setMarca("");
    setFecha("");
    setEstado("Bueno");
    setPortatil(false);
    setCosto("");
  }

  return (
    <div className="ventana">
      <h2>Agregar Computador</h2>

      <div className="fila">
        <div className="grupo">
          <label>Codigo *</label>
          <input type="number" value={codigo} onChange={function(e) { setCodigo(e.target.value); }} placeholder="Ej: 101" />
        </div>
        <div className="grupo">
          <label>Marca *</label>
          <input type="text" value={marca} onChange={function(e) { setMarca(e.target.value); }} placeholder="Ej: Dell" />
        </div>
      </div>

      <div className="fila">
        <div className="grupo">
          <label>Fecha de Fabricacion</label>
          <input type="datetime-local" value={fecha} onChange={function(e) { setFecha(e.target.value); }} />
        </div>
        <div className="grupo">
          <label>Estado</label>
          <select value={estado} onChange={function(e) { setEstado(e.target.value); }}>
            <option value="Bueno">Bueno</option>
            <option value="Regular">Regular</option>
            <option value="Malo">Malo</option>
          </select>
        </div>
      </div>

      <div className="fila">
        <div className="grupo">
          <label>Costo Mantenimiento</label>
          <input type="number" value={costo} onChange={function(e) { setCosto(e.target.value); }} placeholder="Ej: 150000" />
        </div>
        <div className="grupo" style={{ justifyContent: "center" }}>
          <label>&nbsp;</label>
          <label>
            <input type="checkbox" checked={portatil} onChange={function(e) { setPortatil(e.target.checked); }} />
            {" "}Es portatil?
          </label>
        </div>
      </div>

      <div className="botones" style={{ marginTop: "20px" }}>
        <button className="btn-azul" onClick={handleGuardar}>Guardar Computador</button>
        <button className="btn-gris" onClick={handleLimpiar}>Limpiar</button>
      </div>
    </div>
  );
}

export default GUIAgregar;
