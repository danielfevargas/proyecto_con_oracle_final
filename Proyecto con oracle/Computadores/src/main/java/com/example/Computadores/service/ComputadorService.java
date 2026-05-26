package com.example.Computadores.service;

import com.example.Computadores.model.Computador;
import com.example.Computadores.model.Periferico;
import com.example.Computadores.repository.ComputadorRepository;
import com.example.Computadores.repository.PerifericoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Optional;

@Service
public class ComputadorService {

    @Autowired
    private ComputadorRepository computadorRepo;

    @Autowired
    private PerifericoRepository perifericoRepo;

    @Transactional
    public Computador agregar(Computador c) {
        c.setActivo(true);
        if (c.getPerifericos() != null) {
            c.getPerifericos().forEach(p -> {
                p.setActivo(true);
                p.setComputador(c);
            });
        }
        return computadorRepo.save(c);
    }

    public Computador buscarPorCodigo(int codigo) {
        return computadorRepo.findByCodigoAndActivoTrue(codigo).orElse(null);
    }

    @Transactional
    public boolean eliminar(int codigo) {
        Optional<Computador> opt = computadorRepo.findByCodigoAndActivoTrue(codigo);
        if (opt.isEmpty()) return false;
        Computador c = opt.get();
        c.setActivo(false);
        for (Periferico p : perifericoRepo.findByComputadorCodigoAndActivoTrue(codigo)) {
            p.setActivo(false);
            perifericoRepo.save(p);
        }
        computadorRepo.save(c);
        return true;
    }

    @Transactional
    public boolean actualizar(int codigo, Computador nuevo) {
        Optional<Computador> opt = computadorRepo.findByCodigoAndActivoTrue(codigo);
        if (opt.isEmpty()) return false;
        Computador existente = opt.get();
        existente.setMarca(nuevo.getMarca());
        existente.setFechaFabricacion(nuevo.getFechaFabricacion());
        existente.setEstado(nuevo.getEstado());
        existente.setPortatil(nuevo.isPortatil());
        existente.setCostoMantenimiento(nuevo.getCostoMantenimiento());
        computadorRepo.save(existente);
        return true;
    }

    public List<Computador> listarTodos() {
        return computadorRepo.findByActivoTrue();
    }

    public List<Computador> filtrarPorMarca(String marca) {
        return computadorRepo.findActivosByMarca(marca);
    }

    public List<Computador> filtrarPorEstado(String estado) {
        return computadorRepo.findActivosByEstado(estado);
    }

    @Transactional
    public Periferico agregarPeriferico(int codigoComputador, Periferico periferico) {
        Computador c = buscarPorCodigo(codigoComputador);
        if (c == null) return null;
        periferico.setComputador(c);
        periferico.setActivo(true);
        return perifericoRepo.save(periferico);
    }

    public List<Periferico> listarPerifericos(int codigoComputador) {
        return perifericoRepo.findByComputadorCodigoAndActivoTrue(codigoComputador);
    }

    public Periferico buscarPerifericoPorId(int codigoComputador, int idPeriferico) {
        return perifericoRepo.findByIdAndActivoTrue(idPeriferico)
                .filter(p -> p.getComputador().getCodigo() == codigoComputador)
                .orElse(null);
    }

    @Transactional
    public boolean actualizarPeriferico(int codigoComputador, int idPeriferico, Periferico nuevo) {
        Periferico existente = buscarPerifericoPorId(codigoComputador, idPeriferico);
        if (existente == null) return false;
        existente.setNombre(nuevo.getNombre());
        existente.setTipo(nuevo.getTipo());
        perifericoRepo.save(existente);
        return true;
    }

    @Transactional
    public boolean eliminarPeriferico(int codigoComputador, int idPeriferico) {
        Periferico p = buscarPerifericoPorId(codigoComputador, idPeriferico);
        if (p == null) return false;
        p.setActivo(false);
        perifericoRepo.save(p);
        return true;
    }

    public List<Periferico> buscarPerifericosPorTipo(String tipo) {
        return perifericoRepo.findActivosByTipoConComputador(tipo);
    }
}
