import { useState } from "react";
import ComputadorService from "./ComputadorService";
import { Computador } from "./Computador";
import { observador } from "./Observador";

function GUIActualizar({ onMensaje }) {

  var [codigoBuscar, setCodigoBuscar] = useState("");
  var [computador, setComputador] = useState(null);

  var [marca, setMarca] = useState("");
  var [fecha, setFecha] = useState("");
  var [estado, setEstado] = useState("Bueno");
  var [portatil, setPortatil] = useState(false);
  var [costo, setCosto] = useState("");
  var [perifericos, setPerifericos] = useState("");

  async function handleBuscar() {

    if (codigoBuscar === "") {
      onMensaje("Ingrese un codigo.", "error");
      return;
    }

    var resultado = await ComputadorService.buscarPorCodigo(parseInt(codigoBuscar));

    if (resultado === null) {
      onMensaje("No se encontro ningun computador con ese codigo.", "error");
      setComputador(null);
      return;
    }

    setComputador(resultado);
    setMarca(resultado.marca);
    setEstado(resultado.estado);
    setCosto(resultado.costoMantenimiento);
    setPortatil(resultado.portatil);

    if (resultado.perifericos !== null && resultado.perifericos.length > 0) {
      setPerifericos(resultado.perifericos.map(function(p) { return p.nombre; }).join(", "));
    } else {
      setPerifericos("");
    }

    if (resultado.fechaFabricacion !== null && resultado.fechaFabricacion !== "") {
      setFecha(resultado.fechaFabricacion.slice(0, 16));
    }

    onMensaje("Computador encontrado. Edite los campos.", "exito");
  }

  async function handleActualizar() {

    if (computador === null) {
      onMensaje("Primero busque un computador.", "error");
      return;
    }

    var listaPerifericos = [];
    if (perifericos.trim() !== "") {
      var partes = perifericos.split(",");
      for (var i = 0; i < partes.length; i++) {
        listaPerifericos.push(partes[i].trim());
      }
    }

    var computadorActualizado = new Computador(
      computador.codigo,
      marca,
      fecha !== "" ? fecha + ":00" : computador.fechaFabricacion,
      estado,
      portatil,
      parseFloat(costo) || 0,
      listaPerifericos,
      true
    );

    var resultado = await ComputadorService.actualizar(computador.codigo, computadorActualizado);

    if (resultado === true) {
      onMensaje("Computador actualizado correctamente.", "exito");
      observador.notificar("actualizar"); // Notifica al Observer
      handleCancelar();
    } else {
      onMensaje("Error al actualizar el computador.", "error");
    }
  }

  function handleCancelar() {
    setCodigoBuscar("");
    setComputador(null);
    setMarca("");
    setFecha("");
    setEstado("Bueno");
    setPortatil(false);
    setCosto("");
    setPerifericos("");
  }

  return (
    <div className="ventana">
      <h2>Actualizar Computador</h2>

      {/* Paso 1: buscar */}
      <p style={{ color: "#555", fontSize: "14px" }}>Paso 1: ingrese el codigo del computador a actualizar.</p>

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
        <div className="caja-resultado">
          <p style={{ fontWeight: "bold", marginBottom: "12px" }}>Paso 2: edite los campos y guarde.</p>

          <div className="fila">
            <div className="grupo">
              <label>Marca</label>
              <input
                type="text"
                value={marca}
                onChange={function(e) { setMarca(e.target.value); }}
              />
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
              <label>Fecha de Fabricacion</label>
              <input
                type="datetime-local"
                value={fecha}
                onChange={function(e) { setFecha(e.target.value); }}
              />
            </div>
            <div className="grupo">
              <label>Costo Mantenimiento</label>
              <input
                type="number"
                value={costo}
                onChange={function(e) { setCosto(e.target.value); }}
              />
            </div>
          </div>

          <div className="grupo">
            <label>Perifericos (separar con coma)</label>
            <input
              type="text"
              value={perifericos}
              onChange={function(e) { setPerifericos(e.target.value); }}
            />
          </div>

          <div className="grupo">
            <label>
              <input
                type="checkbox"
                checked={portatil}
                onChange={function(e) { setPortatil(e.target.checked); }}
              />
              {" "}Es portatil?
            </label>
          </div>

          <div className="botones">
            <button className="btn-verde" onClick={handleActualizar}>Guardar Cambios</button>
            <button className="btn-gris" onClick={handleCancelar}>Cancelar</button>
          </div>
        </div>
      )}
    </div>
  );
}

export default GUIActualizar;
