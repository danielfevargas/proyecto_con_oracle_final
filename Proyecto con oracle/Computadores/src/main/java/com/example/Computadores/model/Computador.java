package com.example.Computadores.model;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "COMPUTADOR")
@Data
@AllArgsConstructor
@NoArgsConstructor
public class Computador {

    @Id
    @SequenceGenerator(name = "seq_comp", sequenceName = "SEQ_COMPUTADOR", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "seq_comp")
    @Column(name = "CODIGO")
    private int codigo;

    @Column(name = "MARCA", nullable = false, length = 100)
    private String marca;

    @Column(name = "FECHAFABRICACION", nullable = false)
    @JsonFormat(pattern = "yyyy-MM-dd'T'HH:mm:ss")
    private LocalDateTime fechaFabricacion;

    @Column(name = "ESTADO", nullable = false, length = 50)
    private String estado;

    @Column(name = "PORTATIL", nullable = false)
    private boolean portatil;

    @Column(name = "COSTOMANTENIMIENTO")
    private double costoMantenimiento;

    @Column(name = "ACTIVO", nullable = false)
    private boolean activo = true;

    @OneToMany(mappedBy = "computador", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    @JsonManagedReference
    private List<Periferico> perifericos = new ArrayList<>();
}
