package com.example.Computadores.repository;

import com.example.Computadores.model.Periferico;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface PerifericoRepository extends JpaRepository<Periferico, Integer> {

    List<Periferico> findByComputadorCodigoAndActivoTrue(int codigoComputador);

    Optional<Periferico> findByIdAndActivoTrue(int id);

    @Query("SELECT p FROM Periferico p JOIN FETCH p.computador c WHERE p.activo = true AND c.activo = true AND LOWER(p.tipo) = LOWER(:tipo)")
    List<Periferico> findActivosByTipoConComputador(@Param("tipo") String tipo);
}
