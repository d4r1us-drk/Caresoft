-- Script principal DDL para la base de datos del sistema (WIP)

DROP DATABASE IF EXISTS CaresoftDB;
CREATE DATABASE CaresoftDB;
USE CaresoftDB;

CREATE TABLE Paciente
(
    cedula      VARCHAR(50)     PRIMARY KEY,
    nombres     VARCHAR(100)    NOT NULL,
    apellidos   VARCHAR(100)    NOT NULL,
    telefono    VARCHAR(20)     UNIQUE NOT NULL,
    correo      VARCHAR(255)    UNIQUE NOT NULL,
    direccion   VARCHAR(255)    NOT NULL
);

CREATE TABLE Doctor
(
    cedula      VARCHAR(50)     PRIMARY KEY,
    nombres     VARCHAR(100)    NOT NULL,
    apellidos   VARCHAR(100)    NOT NULL,
    telefono    VARCHAR(20)     UNIQUE NOT NULL,
    correo      VARCHAR(255)    UNIQUE NOT NULL,
    direccion   VARCHAR(255)    NOT NULL
);