package com.example.software.service;

import com.example.software.model.Software;
import com.example.software.repository.SoftwareRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Optional;

@Service
public class SoftwareService {

    @Autowired
    private SoftwareRepository repo;

    @Transactional
    public Software agregar(Software s) {
        if (repo.existsByIdAndActivoTrue(s.getId())) {
            return null;
        }
        s.setActivo(true);
        return repo.save(s);
    }

    public Software buscarPorId(int id) {
        return repo.findByIdAndActivoTrue(id).orElse(null);
    }

    @Transactional
    public boolean eliminar(int id) {
        Optional<Software> opt = repo.findByIdAndActivoTrue(id);
        if (opt.isEmpty()) return false;
        Software s = opt.get();
        s.setActivo(false);
        repo.save(s);
        return true;
    }

    @Transactional
    public boolean actualizar(int id, Software nuevo) {
        Optional<Software> opt = repo.findByIdAndActivoTrue(id);
        if (opt.isEmpty()) return false;
        Software existente = opt.get();
        existente.setCodigoComputador(nuevo.getCodigoComputador());
        existente.setNombre(nuevo.getNombre());
        existente.setVersion(nuevo.getVersion());
        existente.setTipo(nuevo.getTipo());
        existente.setPrecio(nuevo.getPrecio());
        existente.setFechaInstalacion(nuevo.getFechaInstalacion());
        repo.save(existente);
        return true;
    }

    public List<Software> listarTodos() {
        return repo.findByActivoTrue();
    }

    public List<Software> filtrarPorTipo(String tipo) {
        return repo.findActivosByTipo(tipo);
    }

    public List<Software> filtrarPorNombre(String nombre) {
        return repo.findActivosByNombre(nombre);
    }

    public List<Software> listarPorComputador(int codigoComputador) {
        return repo.findByCodigoComputadorAndActivoTrue(codigoComputador);
    }
}
