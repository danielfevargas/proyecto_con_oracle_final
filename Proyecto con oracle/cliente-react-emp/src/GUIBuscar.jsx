import { useState } from "react";
import ComputadorService from "./ComputadorService";

function GUIBuscar({ onMensaje }) {

  var [codigo, setCodigo] = useState("");
  var [computador, setComputador] = useState(null);

  async function handleBuscar() {

    if (codigo === "") {
      onMensaje("Ingrese un codigo.", "error");
      return;
    }

    var resultado = await ComputadorService.buscarPorCodigo(parseInt(codigo));

    if (resultado !== null) {
      setComputador(resultado);
    } else {
      setComputador(null);
      onMensaje("No se encontro ningun computador con ese codigo.", "error");
    }
  }

  function formatearFecha(fecha) {
    if (fecha === null || fecha === undefined || fecha === "") {
      return "Sin fecha";
    }
    var d = new Date(fecha);
    return d.toLocaleDateString("es-CO");
  }

  return (
    <div className="ventana">
      <h2>Buscar Computador</h2>

      <div className="fila">
        <div className="grupo">
          <label>Codigo del Computador</label>
          <input
            type="number"
            value={codigo}
            onChange={function(e) { setCodigo(e.target.value); }}
            placeholder="Ej: 101"
          />
        </div>
      </div>

      <div className="botones">
        <button className="btn-azul" onClick={handleBuscar}>Buscar</button>
      </div>

      {computador !== null && (
        <div className="caja-resultado">
          <p><strong>Codigo:</strong> {computador.codigo}</p>
          <p><strong>Marca:</strong> {computador.marca}</p>
          <p><strong>Fecha Fabricacion:</strong> {formatearFecha(computador.fechaFabricacion)}</p>
          <p><strong>Estado:</strong> {computador.estado}</p>
          <p><strong>Portatil:</strong> {computador.portatil === true ? "Si" : "No"}</p>
          <p><strong>Costo Mantenimiento:</strong> ${Number(computador.costoMantenimiento).toLocaleString("es-CO")}</p>
          <p><strong>Perifericos:</strong> {computador.perifericos !== null && computador.perifericos.length > 0 ? computador.perifericos.map(function(p) { return p.nombre; }).join(", ") : "Ninguno"}</p>
          <p><strong>Activo:</strong> {computador.activo === true ? "Si" : "No"}</p>
        </div>
      )}
    </div>
  );
}

export default GUIBuscar;
