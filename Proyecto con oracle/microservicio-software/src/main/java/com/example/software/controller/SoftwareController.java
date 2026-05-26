package com.example.software.controller;

import com.example.software.model.Software;
import com.example.software.service.SoftwareService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/softwares")
@CrossOrigin(origins = "*")
public class SoftwareController {

    @Autowired
    private SoftwareService service;

    @GetMapping("/healthCheck")
    public String healthCheck() {
        return "Servicio Software Ok!";
    }

    @PostMapping
    public ResponseEntity<Object> crear(@RequestBody Software s) {
        Software resultado = service.agregar(s);
        if (resultado == null) return ResponseEntity.badRequest().body("Ya existe un software con ese ID.");
        return ResponseEntity.ok(resultado);
    }

    @GetMapping("/{id}")
    public ResponseEntity<Software> buscar(@PathVariable int id) {
        Software s = service.buscarPorId(id);
        if (s == null) return ResponseEntity.notFound().build();
        return ResponseEntity.ok(s);
    }

    @GetMapping
    public ResponseEntity<List<Software>> listar(
            @RequestParam(required = false) String tipo,
            @RequestParam(required = false) String nombre,
            @RequestParam(required = false) Integer codigoComputador) {
        if (tipo != null)             return ResponseEntity.ok(service.filtrarPorTipo(tipo));
        if (nombre != null)           return ResponseEntity.ok(service.filtrarPorNombre(nombre));
        if (codigoComputador != null) return ResponseEntity.ok(service.listarPorComputador(codigoComputador));
        return ResponseEntity.ok(service.listarTodos());
    }

    @PutMapping("/{id}")
    public ResponseEntity<String> actualizar(@PathVariable int id, @RequestBody Software nuevo) {
        if (!service.actualizar(id, nuevo)) return ResponseEntity.notFound().build();
        return ResponseEntity.ok("Software actualizado correctamente");
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<String> eliminar(@PathVariable int id) {
        if (!service.eliminar(id)) return ResponseEntity.notFound().build();
        return ResponseEntity.ok("Software eliminado correctamente");
    }
}
