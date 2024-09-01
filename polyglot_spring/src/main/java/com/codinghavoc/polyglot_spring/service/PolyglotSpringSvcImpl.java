package com.codinghavoc.polyglot_spring.service;

import java.util.ArrayList;
import java.util.Arrays;

import org.springframework.http.MediaType;
import org.springframework.stereotype.Service;
import org.springframework.web.reactive.function.client.WebClient;

import com.codinghavoc.polyglot_spring.entity.Vehicle;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.node.ArrayNode;
import com.fasterxml.jackson.databind.node.ObjectNode;

import lombok.AllArgsConstructor;

@AllArgsConstructor
@Service
public class PolyglotSpringSvcImpl implements PolyglotSpringSvc {
    private static ArrayList<Vehicle> vehicles = new ArrayList<>(Arrays.asList(
            new Vehicle(1l, "Jeep", "Wangler", "2014"),
            new Vehicle(2l, "Hyundai", "Santa Fe", "1999"),
            new Vehicle(3l, "Dodge", "Dakota", "2003"),
            new Vehicle(4l, "Jeep", "Cherokee", "1999"),
            new Vehicle(5l, "Chevrolet", "Silverado", "2004")));

    private static String nodeUri = "http://localhost:5001/polyglot/test";

    public String test() {
        // String result = "";
        WebClient client = WebClient.create();
        WebClient.ResponseSpec response = client.get()
                .uri(nodeUri)
                .retrieve();
        System.out.println(response.bodyToMono(String.class).block());
        return response.bodyToMono(String.class).block();
    }

    public ArrayNode getAllVehicles() {
        ObjectMapper mapper = new ObjectMapper();
        ArrayNode res = mapper.createArrayNode();
        for (Vehicle v : vehicles) {
            // System.out.println(v.toString());
            res.add(mapper.valueToTree(v));
        }
        return res;
    }

    public String processMessageRT(String msg) {
        System.out.println("PolyglotSpringSvcImpl.processMessageRT");
        System.out.println(msg);
        String result = "";
        // RestTemplate restTemplate = new RestTemplate();

        // HttpHeaders headers = new HttpHeaders();
        // headers.setAccept(Arrays.asList(MediaType.APPLICATION_JSON));
        // HttpEntity<String> entity = new HttpEntity<String>(msg,headers);
        // System.out.println(entity.toString());

        // return restTemplate.exchange(nodeUri, HttpMethod.POST, entity,
        // String.class).getBody();

        // String result = restTemplate.exchange(nodeUri, HttpMethod.POST, entity,
        // String.class).getBody();

        // return result;

        return result;
    }

    public ObjectNode processMessageWC(String msg) {
        System.out.println("PolyglotSpringSvcImpl.processMessageWC");
        ObjectMapper mapper = new ObjectMapper();
        try {
            JsonNode node = mapper.readTree(msg);
            String temp = node.get("message").toString().replace("\"", "") + " from Spring";
            ((ObjectNode) node).put("message2", temp);
            ArrayList<String> favoriteShows = new ArrayList<>(Arrays.asList("Expanse", "Vikings", "Foundation"));
            ArrayNode favShowNode = mapper.valueToTree(favoriteShows);
            ((ObjectNode) node).set("favoriteShows", favShowNode);

            JsonNode vehicleNode = mapper.valueToTree(getVehicleById(node.get("vehicleId").asLong()));
            // System.out.println(getVehicleById(node.get("vehicleId").asLong()).toString());
            ((ObjectNode) node).set("vehicle", vehicleNode);

            ((ObjectNode) node).remove("vehicleId");
            WebClient client = WebClient.create();
            String response = client.post()
                    .uri(nodeUri)
                    .accept(MediaType.APPLICATION_JSON)
                    .bodyValue(node)
                    .retrieve()
                    .bodyToMono(String.class)
                    .block();
            JsonNode nodeRes = mapper.readTree(response);
            return (ObjectNode) nodeRes;
        } catch (JsonProcessingException e) {
            e.printStackTrace();
            ObjectNode errNode = mapper.createObjectNode();
            errNode.put("errorMsg", "An error occurred when processing the message");
            return errNode;
        }
    }

    /*
     * MOCK DATABASE Calls
     */

    private static Vehicle getVehicleById(Long id) {
        for (Vehicle v : vehicles) {
            if (v.getVehicleId() == id) {
                return v;
            }
        }
        return new Vehicle();
    }
}
