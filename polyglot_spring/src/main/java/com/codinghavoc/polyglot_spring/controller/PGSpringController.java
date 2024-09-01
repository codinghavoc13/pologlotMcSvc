package com.codinghavoc.polyglot_spring.controller;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.codinghavoc.polyglot_spring.service.PolyglotSpringSvc;
import com.fasterxml.jackson.databind.node.ArrayNode;
import com.fasterxml.jackson.databind.node.ObjectNode;

import lombok.AllArgsConstructor;

@AllArgsConstructor
@RestController
@RequestMapping("/polyglot")
public class PGSpringController {
    private PolyglotSpringSvc svc;

    @GetMapping("/test")
    public ResponseEntity<String> testCall(){
        return new ResponseEntity<>(svc.test(),HttpStatus.OK);
    }

    @GetMapping("/getAllVehicles")
    public ResponseEntity<ArrayNode> getAllVehicles(){
        return new ResponseEntity<>(svc.getAllVehicles(),HttpStatus.OK);
    }
    
    @PostMapping("/processMsgRT")
    public ResponseEntity<String> processMsgRT(@RequestBody String message){
        return new ResponseEntity<>(svc.processMessageRT(message), HttpStatus.OK);
    }
    
    @PostMapping("/processMsgWC")
    public ResponseEntity<ObjectNode> processMsgWC(@RequestBody String message){
        return new ResponseEntity<>(svc.processMessageWC(message), HttpStatus.OK);
    }
}
