var suscriptores = {};
var contadorId = 0;

export var observador = {

  suscribir: function(funcion) {
    var id = contadorId;
    contadorId = contadorId + 1;
    suscriptores[id] = funcion;
    return id;
  },

  desuscribir: function(id) {
    delete suscriptores[id];
  },

  notificar: function(evento) {
    var ids = Object.keys(suscriptores);
    for (var i = 0; i < ids.length; i++) {
      suscriptores[ids[i]](evento);
    }
  }

};
