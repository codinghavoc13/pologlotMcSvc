package com.codinghavoc.polyglot_spring.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.NonNull;
import lombok.Setter;

@AllArgsConstructor
@NoArgsConstructor
@Entity
@Getter
@Setter
@Table(name = "vehicles", schema = "polyglot")
public class Vehicle {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "vehicle_id")
    private Long vehicleId;

    @NonNull
    @Column(name = "make")
    private String make;

    @NonNull
    @Column(name = "model")
    private String model;

    @NonNull
    @Column(name = "year")
    private String year;

    @Override
    public String toString() {
        return "Vehicle [vehicleId=" + vehicleId + ", make=" + make + ", model=" + model + ", year=" + year + "]";
    }
}
