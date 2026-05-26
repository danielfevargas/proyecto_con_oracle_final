export class Computador {

  constructor(codigo, marca, fechaFabricacion, estado, portatil, costoMantenimiento, perifericos, activo) {
    this.codigo = codigo;
    this.marca = marca;
    this.fechaFabricacion = fechaFabricacion;
    this.estado = estado;
    this.portatil = portatil;
    this.costoMantenimiento = costoMantenimiento;
    this.perifericos = perifericos;
    this.activo = activo;
  }

  toJson() {
    var datos = {
      codigo: this.codigo,
      marca: this.marca,
      fechaFabricacion: this.fechaFabricacion,
      estado: this.estado,
      portatil: this.portatil,
      costoMantenimiento: this.costoMantenimiento,
      perifericos: this.perifericos,
      activo: this.activo
    };
    return datos;
  }

  static fromJson(data) {
    var computador = new Computador(
      data.codigo,
      data.marca,
      data.fechaFabricacion,
      data.estado,
      data.portatil,
      data.costoMantenimiento,
      data.perifericos,
      data.activo
    );
    return computador;
  }
}
