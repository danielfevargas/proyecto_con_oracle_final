package com.example.Computadores.repository;

import com.example.Computadores.model.Computador;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface ComputadorRepository extends JpaRepository<Computador, Integer> {


    Optional<Computador> findByCodigoAndActivoTrue(int codigo);

    List<Computador> findByActivoTrue();

    @Query("SELECT c FROM Computador c WHERE c.activo = true AND LOWER(c.marca) LIKE LOWER(CONCAT('%', :marca, '%'))")
    List<Computador> findActivosByMarca(@Param("marca") String marca);

    @Query("SELECT c FROM Computador c WHERE c.activo = true AND LOWER(c.estado) = LOWER(:estado)")
    List<Computador> findActivosByEstado(@Param("estado") String estado);
}
