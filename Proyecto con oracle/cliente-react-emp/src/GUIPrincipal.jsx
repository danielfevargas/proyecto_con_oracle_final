import { useState } from "react";
import GUIAgregar from "./GUIAgregar";
import GUIBuscar from "./GUIBuscar";
import GUIListar from "./GUIListar";
import GUIActualizar from "./GUIActualizar";
import GUIEliminar from "./GUIEliminar";
import GUIListarPerifericos from "./GUIListarPerifericos";
import GUIAgregarPeriferico from "./GUIAgregarPeriferico";
import GUIActualizarPeriferico from "./GUIActualizarPeriferico";
import GUIEliminarPeriferico from "./GUIEliminarPeriferico";
import GUIAgregarSoftware from "./GUIAgregarSoftware";
import GUIBuscarSoftware from "./GUIBuscarSoftware";
import GUIListarSoftware from "./GUIListarSoftware";
import GUIActualizarSoftware from "./GUIActualizarSoftware";
import GUIEliminarSoftware from "./GUIEliminarSoftware";
import GUIAcercaDe from "./GUIAcercaDe";

function GUIPrincipal() {

  var [ventanaActiva, setVentanaActiva] = useState("agregar");
  var [mensaje, setMensaje] = useState(null);

  function mostrarMensaje(texto, tipo) {
    setMensaje({ texto: texto, tipo: tipo });
    setTimeout(function() {
      setMensaje(null);
    }, 3000);
  }

  function renderizarVentana() {
    if (ventanaActiva === "agregar")              return <GUIAgregar onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "buscar")               return <GUIBuscar onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "listar")               return <GUIListar onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "actualizar")           return <GUIActualizar onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "eliminar")             return <GUIEliminar onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "listarPerifericos")    return <GUIListarPerifericos onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "agregarPeriferico")    return <GUIAgregarPeriferico onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "actualizarPeriferico") return <GUIActualizarPeriferico onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "eliminarPeriferico")   return <GUIEliminarPeriferico onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "agregarSoftware")      return <GUIAgregarSoftware onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "buscarSoftware")       return <GUIBuscarSoftware onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "listarSoftware")       return <GUIListarSoftware onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "actualizarSoftware")   return <GUIActualizarSoftware onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "eliminarSoftware")     return <GUIEliminarSoftware onMensaje={mostrarMensaje} />;
    if (ventanaActiva === "acerca")               return <GUIAcercaDe />;
  }

  function btn(id, label) {
    return (
      <button
        className={ventanaActiva === id ? "activo" : ""}
        onClick={function() { setVentanaActiva(id); }}
      >
        {label}
      </button>
    );
  }

  return (
    <div>
      <div className="navbar">
        <span>ComputerApp</span>
        <span className="nav-separador">Computadores:</span>
        {btn("agregar",    "Agregar")}
        {btn("buscar",     "Buscar")}
        {btn("listar",     "Listar")}
        {btn("actualizar", "Actualizar")}
        {btn("eliminar",   "Eliminar")}
        <span className="nav-separador">Perifericos:</span>
        {btn("listarPerifericos",    "Listar")}
        {btn("agregarPeriferico",    "Agregar")}
        {btn("actualizarPeriferico", "Actualizar")}
        {btn("eliminarPeriferico",   "Eliminar")}
        <span className="nav-separador">Software:</span>
        {btn("agregarSoftware",    "Agregar")}
        {btn("buscarSoftware",     "Buscar")}
        {btn("listarSoftware",     "Listar")}
        {btn("actualizarSoftware", "Actualizar")}
        {btn("eliminarSoftware",   "Eliminar")}
        <span className="nav-separador">|</span>
        {btn("acerca", "Acerca de")}
      </div>

      <div className="contenido">
        {renderizarVentana()}
      </div>

      {mensaje !== null && (
        <div className={"mensaje " + mensaje.tipo}>
          {mensaje.texto}
        </div>
      )}
    </div>
  );
}

export default GUIPrincipal;
