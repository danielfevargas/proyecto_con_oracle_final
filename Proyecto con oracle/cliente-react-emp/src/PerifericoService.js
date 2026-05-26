import { Periferico } from "./Periferico";

const URL_SERVIDOR = "http://localhost:8080/computadores";

const PerifericoService = {

  async agregar(codigoComputador, periferico) {
    try {
      var respuesta = await fetch(URL_SERVIDOR + "/" + codigoComputador + "/perifericos", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(periferico.toJson())
      });
      if (respuesta.status === 200 || respuesta.status === 201) {
        var data = await respuesta.json();
        return Periferico.fromJson(data);
      } else {
        return null;
      }
    } catch (error) {
      console.log("Error al conectar con el servidor: " + error);
      return null;
    }
  },

  async listar(codigoComputador) {
    try {
      var respuesta = await fetch(URL_SERVIDOR + "/" + codigoComputador + "/perifericos");
      if (respuesta.status === 200) {
        var data = await respuesta.json();
        var lista = [];
        for (var i = 0; i < data.length; i++) {
          lista.push(Periferico.fromJson(data[i]));
        }
        return lista;
      } else {
        return [];
      }
    } catch (error) {
      console.log("Error al conectar con el servidor: " + error);
      return [];
    }
  },

  async actualizar(codigoComputador, idPeriferico, periferico) {
    try {
      var respuesta = await fetch(URL_SERVIDOR + "/" + codigoComputador + "/perifericos/" + idPeriferico, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(periferico.toJson())
      });
      if (respuesta.status === 200) {
        return true;
      } else {
        return false;
      }
    } catch (error) {
      console.log("Error al conectar con el servidor: " + error);
      return false;
    }
  },

  async eliminar(codigoComputador, idPeriferico) {
    try {
      var respuesta = await fetch(URL_SERVIDOR + "/" + codigoComputador + "/perifericos/" + idPeriferico, {
        method: "DELETE"
      });
      if (respuesta.status === 200) {
        return true;
      } else {
        return false;
      }
    } catch (error) {
      console.log("Error al conectar con el servidor: " + error);
      return false;
    }
  }

};

export default PerifericoService;
