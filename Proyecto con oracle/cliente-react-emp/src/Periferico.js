export class Periferico {

  constructor(id, nombre, tipo, activo) {
    this.id = id;
    this.nombre = nombre;
    this.tipo = tipo;
    this.activo = activo;
  }

  toJson() {
    var datos = {
      id: this.id,
      nombre: this.nombre,
      tipo: this.tipo,
      activo: this.activo
    };
    return datos;
  }

  static fromJson(data) {
    var periferico = new Periferico(
      data.id,
      data.nombre,
      data.tipo,
      data.activo
    );
    return periferico;
  }
}
