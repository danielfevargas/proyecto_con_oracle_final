import { useState } from "react";
import ComputadorService from "./ComputadorService";
import PerifericoService from "./PerifericoService";
import { Periferico } from "./Periferico";

function GUIAgregarPeriferico({ onMensaje }) {

  var [codigoComputador, setCodigoComputador] = useState("");
  var [computador, setComputador] = useState(null);
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
      return;
    }
    setComputador(resultado);
  }

  async function handleAgregar() {
    if (nombre === "") {
      onMensaje("El nombre del periferico es obligatorio.", "error");
      return;
    }

    var periferico = new Periferico(0, nombre, tipo, true);
    var resultado = await PerifericoService.agregar(parseInt(codigoComputador), periferico);

    if (resultado !== null) {
      onMensaje("Periferico agregado correctamente.", "exito");
      setNombre("");
      setTipo("Entrada");
    } else {
      onMensaje("Error al agregar el periferico.", "error");
    }
  }

  return (
    <div className="ventana">
      <h2>Agregar Periferico</h2>

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

          <p style={{ color: "#555", fontSize: "14px" }}>Paso 2: ingrese los datos del periferico.</p>
          <div className="fila">
            <div className="grupo">
              <label>Nombre *</label>
              <input
                type="text"
                value={nombre}
                onChange={function(e) { setNombre(e.target.value); }}
                placeholder="Ej: Teclado mecanico"
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
            <button className="btn-verde" onClick={handleAgregar}>Agregar Periferico</button>
          </div>
        </div>
      )}
    </div>
  );
}

export default GUIAgregarPeriferico;
