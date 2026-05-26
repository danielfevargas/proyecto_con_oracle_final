import { Computador } from "./Computador";

const URL_SERVIDOR = "http://localhost:8080/computadores";

const ComputadorService = {

  async agregar(computador) {
    try {
      var respuesta = await fetch(URL_SERVIDOR, {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(computador.toJson())
      });

      if (respuesta.status === 200 || respuesta.status === 201) {
        return true;
      } else {
        return false;
      }
    } catch (error) {
      console.log("Error al conectar con el servidor: " + error);
      return false;
    }
  },

  async buscarPorCodigo(codigo) {
    try {
      var respuesta = await fetch(URL_SERVIDOR + "/" + codigo);

      if (respuesta.status === 200) {
        var data = await respuesta.json();
        var computador = Computador.fromJson(data);
        return computador;
      } else {
        return null;
      }
    } catch (error) {
      console.log("Error al conectar con el servidor: " + error);
      return null;
    }
  },

  async listar(marca, estado) {
    try {
      var url = URL_SERVIDOR;

      if (marca !== "" && marca !== undefined && marca !== null) {
        url = url + "?marca=" + marca;
      }

      if (estado !== "" && estado !== undefined && estado !== null) {
        if (url.includes("?")) {
          url = url + "&estado=" + estado;
        } else {
          url = url + "?estado=" + estado;
        }
      }

      var respuesta = await fetch(url);

      if (respuesta.status === 200) {
        var data = await respuesta.json();
        var lista = [];
        for (var i = 0; i < data.length; i++) {
          var computador = Computador.fromJson(data[i]);
          lista.push(computador);
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

  async actualizar(codigo, computador) {
    try {
      var respuesta = await fetch(URL_SERVIDOR + "/" + codigo, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(computador.toJson())
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

  async eliminar(codigo) {
    try {
      var respuesta = await fetch(URL_SERVIDOR + "/" + codigo, {
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

export default ComputadorService;
