import { Software } from "./Software";

// Los clientes solo hablan con el microservicio A-B (puerto 8080)
// que actua como proxy hacia el microservicio C (puerto 8081)
const URL_SERVIDOR = "http://localhost:8080/softwares";

const SoftwareService = {

  async agregar(software) {
    try {
      var resp = await fetch(URL_SERVIDOR, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(software.toJson())
      });
      if (resp.status === 200 || resp.status === 201) {
        var data = await resp.json();
        return Software.fromJson(data);
      }
      return null;
    } catch (error) {
      console.log("Error al conectar: " + error);
      return null;
    }
  },

  async listar(tipo, nombre, codigoComputador) {
    try {
      var url = URL_SERVIDOR + "?x=1";
      if (tipo)              url += "&tipo=" + tipo;
      if (nombre)            url += "&nombre=" + nombre;
      if (codigoComputador)  url += "&codigoComputador=" + codigoComputador;
      var resp = await fetch(url);
      if (resp.status === 200) {
        var data = await resp.json();
        return data.map(function(d) { return Software.fromJson(d); });
      }
      return [];
    } catch (error) {
      console.log("Error al conectar: " + error);
      return [];
    }
  },

  async buscar(id) {
    try {
      var resp = await fetch(URL_SERVIDOR + "/" + id);
      if (resp.status === 200) {
        var data = await resp.json();
        return Software.fromJson(data);
      }
      return null;
    } catch (error) {
      console.log("Error al conectar: " + error);
      return null;
    }
  },

  async actualizar(id, software) {
    try {
      var resp = await fetch(URL_SERVIDOR + "/" + id, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(software.toJson())
      });
      return resp.status === 200;
    } catch (error) {
      console.log("Error al conectar: " + error);
      return false;
    }
  },

  async eliminar(id) {
    try {
      var resp = await fetch(URL_SERVIDOR + "/" + id, {
        method: "DELETE"
      });
      return resp.status === 200;
    } catch (error) {
      console.log("Error al conectar: " + error);
      return false;
    }
  }

};

export default SoftwareService;
