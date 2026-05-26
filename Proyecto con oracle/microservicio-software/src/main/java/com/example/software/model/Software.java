package com.example.software.model;

import com.fasterxml.jackson.annotation.JsonFormat;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Entity
@Table(name = "SOFTWARE")
@Data
@AllArgsConstructor
@NoArgsConstructor
public class Software {

    @Id
    @Column(name = "ID")
    private int id;

    @Column(name = "CODIGO_COMPUTADOR", nullable = false)
    private int codigoComputador;

    @Column(name = "NOMBRE", nullable = false, length = 150)
    private String nombre;

    @Column(name = "VERSION", nullable = false, length = 50)
    private String version;

    @Column(name = "TIPO", nullable = false, length = 80)
    private String tipo;

    @Column(name = "PRECIO", nullable = false)
    private double precio;

    @Column(name = "FECHA_INSTALACION", nullable = false)
    @JsonFormat(pattern = "yyyy-MM-dd'T'HH:mm:ss")
    private LocalDateTime fechaInstalacion;

    @Column(name = "ACTIVO", nullable = false)
    private boolean activo = true;
}
