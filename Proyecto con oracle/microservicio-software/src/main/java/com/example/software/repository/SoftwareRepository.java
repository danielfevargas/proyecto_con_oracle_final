package com.example.software.repository;

import com.example.software.model.Software;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface SoftwareRepository extends JpaRepository<Software, Integer> {

    Optional<Software> findByIdAndActivoTrue(int id);

    List<Software> findByActivoTrue();

    @Query("SELECT s FROM Software s WHERE s.activo = true AND LOWER(s.tipo) LIKE LOWER(CONCAT('%', :tipo, '%'))")
    List<Software> findActivosByTipo(@Param("tipo") String tipo);

    @Query("SELECT s FROM Software s WHERE s.activo = true AND LOWER(s.nombre) LIKE LOWER(CONCAT('%', :nombre, '%'))")
    List<Software> findActivosByNombre(@Param("nombre") String nombre);

    List<Software> findByCodigoComputadorAndActivoTrue(int codigoComputador);

    boolean existsByIdAndActivoTrue(int id);
}
