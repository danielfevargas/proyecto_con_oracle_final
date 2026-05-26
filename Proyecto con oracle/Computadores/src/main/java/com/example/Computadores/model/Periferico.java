package com.example.Computadores.model;

import com.fasterxml.jackson.annotation.JsonBackReference;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "PERIFERICO")
@Data
@AllArgsConstructor
@NoArgsConstructor
public class Periferico {

    @Id
    @Column(name = "ID")
    private int id;

    @Column(name = "NOMBRE", nullable = false, length = 100)
    private String nombre;

    @Column(name = "TIPO", nullable = false, length = 50)
    private String tipo;

    @Column(name = "ACTIVO", nullable = false)
    private boolean activo = true;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "COMPUTADOR_CODIGO", nullable = false)
    @JsonBackReference
    private Computador computador;

    @Transient
    private Integer codigoComputador;

    @PostLoad
    public void postLoad() {
        if (computador != null) {
            this.codigoComputador = computador.getCodigo();
        }
    }
}
