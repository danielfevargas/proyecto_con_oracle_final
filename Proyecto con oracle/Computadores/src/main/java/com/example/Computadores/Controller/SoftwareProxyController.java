package com.example.Computadores.Controller;

import org.springframework.http.*;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.HttpClientErrorException;
import org.springframework.web.client.RestTemplate;

import java.util.logging.Logger;

/**
 * Proxy que expone el microservicio de Software (puerto 8081)
 * de forma transparente a los clientes GUI.
 * Los clientes solo hablan con el puerto 8080.
 */
@RestController
@RequestMapping("/softwares")
@CrossOrigin(origins = "*")
public class SoftwareProxyController {

    private static final Logger logger = Logger.getLogger(SoftwareProxyController.class.getName());
    private static final String SOFTWARE_URL = "http://localhost:8081/softwares";

    private final RestTemplate restTemplate = new RestTemplate();

    // POST /softwares - agregar
    @PostMapping
    public ResponseEntity<String> crear(@RequestBody String body) {
        try {
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            HttpEntity<String> entity = new HttpEntity<>(body, headers);
            ResponseEntity<String> resp = restTemplate.postForEntity(SOFTWARE_URL, entity, String.class);
            return ResponseEntity.status(resp.getStatusCode()).body(resp.getBody());
        } catch (HttpClientErrorException e) {
            return ResponseEntity.status(e.getStatusCode()).body(e.getResponseBodyAsString());
        } catch (Exception e) {
            logger.warning("Error llamando microservicio software: " + e.getMessage());
            return ResponseEntity.status(HttpStatus.SERVICE_UNAVAILABLE).body("Microservicio de software no disponible");
        }
    }

    // GET /softwares - listar con parametros opcionales
    @GetMapping
    public ResponseEntity<String> listar(
            @RequestParam(required = false) String tipo,
            @RequestParam(required = false) String nombre,
            @RequestParam(required = false) Integer codigoComputador) {
        try {
            StringBuilder url = new StringBuilder(SOFTWARE_URL + "?x=1");
            if (tipo != null)             url.append("&tipo=").append(tipo);
            if (nombre != null)           url.append("&nombre=").append(nombre);
            if (codigoComputador != null) url.append("&codigoComputador=").append(codigoComputador);
            ResponseEntity<String> resp = restTemplate.getForEntity(url.toString(), String.class);
            return ResponseEntity.status(resp.getStatusCode()).body(resp.getBody());
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.SERVICE_UNAVAILABLE).body("Microservicio de software no disponible");
        }
    }

    // GET /softwares/{id} - buscar por id
    @GetMapping("/{id}")
    public ResponseEntity<String> buscar(@PathVariable int id) {
        try {
            ResponseEntity<String> resp = restTemplate.getForEntity(SOFTWARE_URL + "/" + id, String.class);
            return ResponseEntity.status(resp.getStatusCode()).body(resp.getBody());
        } catch (HttpClientErrorException e) {
            return ResponseEntity.status(e.getStatusCode()).body(e.getResponseBodyAsString());
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.SERVICE_UNAVAILABLE).body("Microservicio de software no disponible");
        }
    }

    // PUT /softwares/{id} - actualizar
    @PutMapping("/{id}")
    public ResponseEntity<String> actualizar(@PathVariable int id, @RequestBody String body) {
        try {
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            HttpEntity<String> entity = new HttpEntity<>(body, headers);
            ResponseEntity<String> resp = restTemplate.exchange(
                    SOFTWARE_URL + "/" + id, HttpMethod.PUT, entity, String.class);
            return ResponseEntity.status(resp.getStatusCode()).body(resp.getBody());
        } catch (HttpClientErrorException e) {
            return ResponseEntity.status(e.getStatusCode()).body(e.getResponseBodyAsString());
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.SERVICE_UNAVAILABLE).body("Microservicio de software no disponible");
        }
    }

    // DELETE /softwares/{id} - eliminar
    @DeleteMapping("/{id}")
    public ResponseEntity<String> eliminar(@PathVariable int id) {
        try {
            ResponseEntity<String> resp = restTemplate.exchange(
                    SOFTWARE_URL + "/" + id, HttpMethod.DELETE, null, String.class);
            return ResponseEntity.status(resp.getStatusCode()).body(resp.getBody());
        } catch (HttpClientErrorException e) {
            return ResponseEntity.status(e.getStatusCode()).body(e.getResponseBodyAsString());
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.SERVICE_UNAVAILABLE).body("Microservicio de software no disponible");
        }
    }
}
