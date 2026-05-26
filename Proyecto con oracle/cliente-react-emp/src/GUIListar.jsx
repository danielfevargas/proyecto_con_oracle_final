import { useState, useEffect } from "react";
import ComputadorService from "./ComputadorService";
import { observador } from "./Observador";

function GUIListar({ onMensaje }) {

  var [lista, setLista] = useState([]);
  var [filtroMarca, setFiltroMarca] = useState("");
  var [filtroEstado, setFiltroEstado] = useState("");

  useEffect(function() {
    cargarLista();

    var idSuscripcion = observador.suscribir(function(evento) {
      cargarLista();
    });

    return function() {
      observador.desuscribir(idSuscripcion);
    };
  }, []);

  async function cargarLista() {
    var resultado = await ComputadorService.listar(filtroMarca, filtroEstado);
    setLista(resultado);
  }

  function handleVerTodos() {
    setFiltroMarca("");
    setFiltroEstado("");
    ComputadorService.listar("", "").then(function(resultado) {
      setLista(resultado);
    });
  }

  function formatearFecha(fecha) {
    if (fecha === null || fecha === undefined || fecha === "") {
      return "Sin fecha";
    }
    var d = new Date(fecha);
    return d.toLocaleDateString("es-CO");
  }

  function formatearPerifericos(perifericos) {
    if (perifericos === null || perifericos === undefined || perifericos.length === 0) {
      return "Ninguno";
    }
    var nombres = [];
    for (var i = 0; i < perifericos.length; i++) {
      nombres.push(perifericos[i].nombre);
    }
    return nombres.join(", ");
  }

  return (
    <div className="ventana">
      <h2>Listar Computadores</h2>

      <div className="fila" style={{ marginBottom: "15px" }}>
        <div className="grupo">
          <label>Filtrar por Marca</label>
          <input
            type="text"
            value={filtroMarca}
            onChange={function(e) { setFiltroMarca(e.target.value); }}
            placeholder="Ej: Dell"
            style={{ width: "160px" }}
          />
        </div>
        <div className="grupo">
          <label>Filtrar por Estado</label>
          <select
            value={filtroEstado}
            onChange={function(e) { setFiltroEstado(e.target.value); }}
            style={{ width: "140px" }}
          >
            <option value="">Todos</option>
            <option value="Bueno">Bueno</option>
            <option value="Regular">Regular</option>
            <option value="Malo">Malo</option>
          </select>
        </div>
        <div className="grupo" style={{ justifyContent: "flex-end" }}>
          <label>&nbsp;</label>
          <div style={{ display: "flex", gap: "8px" }}>
            <button className="btn-azul" onClick={cargarLista}>Buscar</button>
            <button className="btn-gris" onClick={handleVerTodos}>Ver todos</button>
          </div>
        </div>
      </div>

      <div style={{ overflowX: "auto" }}>
        <table className="tabla">
          <thead>
            <tr>
              <th>Codigo</th>
              <th>Marca</th>
              <th>Fecha Fabricacion</th>
              <th>Estado</th>
              <th>Portatil</th>
              <th>Costo Mantenimiento</th>
              <th>Perifericos</th>
              <th>Activo</th>
            </tr>
          </thead>
          <tbody>
            {lista.length === 0 ? (
              <tr>
                <td colSpan="8" style={{ textAlign: "center", color: "#888", padding: "20px" }}>
                  No hay registros.
                </td>
              </tr>
            ) : (
              lista.map(function(c) {
                return (
                  <tr key={c.codigo}>
                    <td>{c.codigo}</td>
                    <td>{c.marca}</td>
                    <td>{formatearFecha(c.fechaFabricacion)}</td>
                    <td>{c.estado}</td>
                    <td>{c.portatil === true ? "Si" : "No"}</td>
                    <td>${Number(c.costoMantenimiento).toLocaleString("es-CO")}</td>
                    <td>{formatearPerifericos(c.perifericos)}</td>
                    <td>
                      {c.activo === true ? (
                        <span className="badge-activo">Activo</span>
                      ) : (
                        <span className="badge-inactivo">Inactivo</span>
                      )}
                    </td>
                  </tr>
                );
              })
            )}
          </tbody>
        </table>
      </div>

      <p style={{ marginTop: "10px", color: "#555", fontSize: "13px" }}>
        Total de registros: {lista.length}
      </p>
    </div>
  );
}

export default GUIListar;
