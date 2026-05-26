export class Software {

  constructor(id, codigoComputador, nombre, version, tipo, precio, fechaInstalacion, activo) {
    this.id = id;
    this.codigoComputador = codigoComputador;
    this.nombre = nombre;
    this.version = version;
    this.tipo = tipo;
    this.precio = precio;
    this.fechaInstalacion = fechaInstalacion;
    this.activo = activo;
  }

  toJson() {
    return {
      id: this.id,
      codigoComputador: this.codigoComputador,
      nombre: this.nombre,
      version: this.version,
      tipo: this.tipo,
      precio: this.precio,
      fechaInstalacion: this.fechaInstalacion,
      activo: this.activo
    };
  }

  static fromJson(data) {
    return new Software(
      data.id,
      data.codigoComputador,
      data.nombre,
      data.version,
      data.tipo,
      data.precio,
      data.fechaInstalacion,
      data.activo
    );
  }
}
