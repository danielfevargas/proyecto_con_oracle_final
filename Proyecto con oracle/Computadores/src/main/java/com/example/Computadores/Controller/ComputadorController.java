package com.example.Computadores.Controller;

import com.example.Computadores.model.Computador;
import com.example.Computadores.model.Periferico;
import com.example.Computadores.service.ComputadorService;
import com.example.Computadores.service.ICambiable;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.logging.Logger;

@RestController
@RequestMapping("/computadores")
@CrossOrigin(origins = "*")
public class ComputadorController implements ICambiable {

    private static final Logger logger = Logger.getLogger(ComputadorController.class.getName());

    @Autowired
    private ComputadorService service;

    public ComputadorController() {}

    @Override
    public void cambio() {
        logger.info("Cambio detectado en los datos de computadores");
    }

    @GetMapping("/healthCheck")
    public String healthCheck() {
        return "Servicio Computadores Ok!";
    }


    @PostMapping
    public ResponseEntity<Computador> crear(@RequestBody Computador c) {
        return ResponseEntity.ok(service.agregar(c));
    }

    @GetMapping
    public ResponseEntity<List<Computador>> listar(
            @RequestParam(required = false) String marca,
            @RequestParam(required = false) String estado) {
        if (marca != null) return ResponseEntity.ok(service.filtrarPorMarca(marca));
        if (estado != null) return ResponseEntity.ok(service.filtrarPorEstado(estado));
        return ResponseEntity.ok(service.listarTodos());
    }

    @GetMapping("/{codigo}")
    public ResponseEntity<Computador> buscar(@PathVariable int codigo) {
        Computador c = service.buscarPorCodigo(codigo);
        if (c == null) return ResponseEntity.notFound().build();
        return ResponseEntity.ok(c);
    }

    @PutMapping("/{codigo}")
    public ResponseEntity<String> actualizar(@PathVariable int codigo, @RequestBody Computador nuevo) {
        if (!service.actualizar(codigo, nuevo)) return ResponseEntity.notFound().build();
        return ResponseEntity.ok("Computador actualizado");
    }

    @DeleteMapping("/{codigo}")
    public ResponseEntity<String> eliminar(@PathVariable int codigo) {
        if (!service.eliminar(codigo)) return ResponseEntity.notFound().build();
        return ResponseEntity.ok("Computador eliminado");
    }

    // ===== PERIFERICO =====

    @PostMapping("/{codigo}/perifericos")
    public ResponseEntity<Periferico> agregarPeriferico(@PathVariable int codigo, @RequestBody Periferico periferico) {
        Periferico nuevo = service.agregarPeriferico(codigo, periferico);
        if (nuevo == null) return ResponseEntity.notFound().build();
        return ResponseEntity.ok(nuevo);
    }

    @GetMapping("/{codigo}/perifericos")
    public ResponseEntity<List<Periferico>> listarPerifericos(@PathVariable int codigo) {
        return ResponseEntity.ok(service.listarPerifericos(codigo));
    }

    @GetMapping("/{codigo}/perifericos/{idPeriferico}")
    public ResponseEntity<Periferico> buscarPeriferico(@PathVariable int codigo, @PathVariable int idPeriferico) {
        Periferico p = service.buscarPerifericoPorId(codigo, idPeriferico);
        if (p == null) return ResponseEntity.notFound().build();
        return ResponseEntity.ok(p);
    }

    @PutMapping("/{codigo}/perifericos/{idPeriferico}")
    public ResponseEntity<String> actualizarPeriferico(@PathVariable int codigo, @PathVariable int idPeriferico, @RequestBody Periferico nuevo) {
        if (!service.actualizarPeriferico(codigo, idPeriferico, nuevo)) return ResponseEntity.notFound().build();
        return ResponseEntity.ok("Periferico actualizado");
    }

    @DeleteMapping("/{codigo}/perifericos/{idPeriferico}")
    public ResponseEntity<String> eliminarPeriferico(@PathVariable int codigo, @PathVariable int idPeriferico) {
        if (!service.eliminarPeriferico(codigo, idPeriferico)) return ResponseEntity.notFound().build();
        return ResponseEntity.ok("Periferico desactivado");
    }

    // ===== CONSULTA ESPECIAL: periféricos por tipo con info de computador =====
    @GetMapping("/perifericos/porTipo")
    public ResponseEntity<List<Periferico>> buscarPorTipo(@RequestParam String tipo) {
        return ResponseEntity.ok(service.buscarPerifericosPorTipo(tipo));
    }
}
