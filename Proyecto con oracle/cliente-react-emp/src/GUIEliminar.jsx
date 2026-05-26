import { useState } from "react";
import ComputadorService from "./ComputadorService";
import { observador } from "./Observador";

function GUIEliminar({ onMensaje }) {

  var [codigoBuscar, setCodigoBuscar] = useState("");
  var [computador, setComputador] = useState(null);

  async function handleBuscar() {

    if (codigoBuscar === "") {
      onMensaje("Ingrese un codigo.", "error");
      return;
    }

    var resultado = await ComputadorService.buscarPorCodigo(parseInt(codigoBuscar));

    if (resultado === null) {
      setComputador(null);
      onMensaje("No se encontro ningun computador con ese codigo.", "error");
      return;
    }

    setComputador(resultado);
  }

  async function handleEliminar() {

    if (computador === null) {
      return;
    }

    var resultado = await ComputadorService.eliminar(computador.codigo);

    if (resultado === true) {
      onMensaje("Computador desactivado correctamente.", "exito");
      observador.notificar("eliminar");
      handleCancelar();
    } else {
      onMensaje("Error al eliminar el computador.", "error");
    }
  }

  function handleCancelar() {
    setCodigoBuscar("");
    setComputador(null);
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
      <h2>Eliminar Computador</h2>

      <p style={{ color: "#555", fontSize: "14px" }}>
        Paso 1: ingrese el codigo del computador a eliminar.
      </p>

      <div className="fila">
        <div className="grupo">
          <label>Codigo</label>
          <input
            type="number"
            value={codigoBuscar}
            onChange={function(e) { setCodigoBuscar(e.target.value); }}
            placeholder="Ej: 101"
          />
        </div>
      </div>

      <div className="botones">
        <button className="btn-azul" onClick={handleBuscar}>Buscar</button>
      </div>

      {computador !== null && (
        <div className="caja-resultado" style={{ borderLeft: "4px solid #dc3545" }}>
          <p style={{ color: "#dc3545", fontWeight: "bold", marginBottom: "10px" }}>
            Esta es la informacion del computador. Desea desactivarlo?
          </p>
          <p><strong>Codigo:</strong> {computador.codigo}</p>
          <p><strong>Marca:</strong> {computador.marca}</p>
          <p><strong>Fecha Fabricacion:</strong> {formatearFecha(computador.fechaFabricacion)}</p>
          <p><strong>Estado:</strong> {computador.estado}</p>
          <p><strong>Portatil:</strong> {computador.portatil === true ? "Si" : "No"}</p>
          <p><strong>Costo Mantenimiento:</strong> ${Number(computador.costoMantenimiento).toLocaleString("es-CO")}</p>
          <p><strong>Perifericos:</strong> {computador.perifericos !== null && computador.perifericos.length > 0 ? computador.perifericos.map(function(p) { return p.nombre; }).join(", ") : "Ninguno"}</p>
          <p>
            <strong>Estado actual: </strong>
            <span className="badge-activo">Activo</span>
            {" → pasara a → "}
            <span className="badge-inactivo">Inactivo</span>
          </p>

          <div className="botones" style={{ marginTop: "15px" }}>
            <button className="btn-rojo" onClick={handleEliminar}>Confirmar Eliminacion</button>
            <button className="btn-gris" onClick={handleCancelar}>Cancelar</button>
          </div>
        </div>
      )}
    </div>
  );
}

export default GUIEliminar;
