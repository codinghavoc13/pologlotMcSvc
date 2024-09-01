package com.codinghavoc.polyglot_spring.service;

import com.fasterxml.jackson.databind.node.ArrayNode;
import com.fasterxml.jackson.databind.node.ObjectNode;

public interface PolyglotSpringSvc {
    String test();
    String processMessageRT(String msg);
    ObjectNode processMessageWC(String msg);
    ArrayNode getAllVehicles();
}
