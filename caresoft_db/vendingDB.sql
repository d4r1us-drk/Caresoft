CREATE DATABASE  IF NOT EXISTS `caresoftdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `caresoftdb`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: caresoftdb
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `afeccion`
--

DROP TABLE IF EXISTS `afeccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `afeccion` (
  `idAfeccion` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `descripcion` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`idAfeccion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `afeccion`
--

LOCK TABLES `afeccion` WRITE;
/*!40000 ALTER TABLE `afeccion` DISABLE KEYS */;
/*!40000 ALTER TABLE `afeccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aseguradora`
--

DROP TABLE IF EXISTS `aseguradora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aseguradora` (
  `idAseguradora` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `direccion` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `telefono` varchar(18) NOT NULL,
  `correo` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`idAseguradora`),
  UNIQUE KEY `correo` (`correo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aseguradora`
--

LOCK TABLES `aseguradora` WRITE;
/*!40000 ALTER TABLE `aseguradora` DISABLE KEYS */;
INSERT INTO `aseguradora` VALUES (1,'Humanos','XXX','8092221111','humanos.@gmail.com'),(2,'Universal','XXX','8093331111','universal@gmail.com'),(3,'Mapfre','XXX','8094441111','mapfre@gmail.com'),(4,'SeNaSa','XXX','8095551111','senasa@gmail.com');
/*!40000 ALTER TABLE `aseguradora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `autorizacion`
--

DROP TABLE IF EXISTS `autorizacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autorizacion` (
  `idAutorizacion` int unsigned NOT NULL AUTO_INCREMENT,
  `idAseguradora` int unsigned NOT NULL,
  `fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `montoAsegurado` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idAutorizacion`),
  KEY `idAseguradora` (`idAseguradora`),
  CONSTRAINT `autorizacion_ibfk_1` FOREIGN KEY (`idAseguradora`) REFERENCES `aseguradora` (`idAseguradora`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autorizacion`
--

LOCK TABLES `autorizacion` WRITE;
/*!40000 ALTER TABLE `autorizacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `autorizacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consulta`
--

DROP TABLE IF EXISTS `consulta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consulta` (
  `consultaCodigo` varchar(30) NOT NULL,
  `documentoPaciente` varchar(30) NOT NULL,
  `documentoMedico` varchar(30) NOT NULL,
  `idConsultorio` int unsigned NOT NULL,
  `idAutorizacion` int unsigned DEFAULT NULL,
  `fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `motivo` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `comentarios` text,
  `estado` enum('P','R') NOT NULL DEFAULT 'P',
  `costo` decimal(4,2) NOT NULL,
  PRIMARY KEY (`consultaCodigo`),
  KEY `documentoPaciente` (`documentoPaciente`),
  KEY `documentoMedico` (`documentoMedico`),
  KEY `idConsultorio` (`idConsultorio`),
  KEY `idAutorizacion` (`idAutorizacion`),
  CONSTRAINT `consulta_ibfk_1` FOREIGN KEY (`documentoPaciente`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `consulta_ibfk_2` FOREIGN KEY (`documentoMedico`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `consulta_ibfk_3` FOREIGN KEY (`idConsultorio`) REFERENCES `consultorio` (`idConsultorio`) ON DELETE CASCADE,
  CONSTRAINT `consulta_ibfk_4` FOREIGN KEY (`idAutorizacion`) REFERENCES `autorizacion` (`idAutorizacion`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consulta`
--

LOCK TABLES `consulta` WRITE;
/*!40000 ALTER TABLE `consulta` DISABLE KEYS */;
/*!40000 ALTER TABLE `consulta` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trCheckDocumentoDiferenteConsulta` BEFORE INSERT ON `consulta` FOR EACH ROW BEGIN
    IF NEW.documentoPaciente = NEW.documentoMedico THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El documento del paciente no puede ser igual al documento del médico';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trActualizarMontoTotalFacturaAfterUpdateConsulta` AFTER UPDATE ON `consulta` FOR EACH ROW BEGIN
    IF OLD.idAutorizacion IS NULL AND OLD.idAutorizacion <> NEW.idAutorizacion THEN
        UPDATE Factura f
        JOIN Autorizacion a ON NEW.idAutorizacion = a.idAutorizacion
        SET f.montoTotal = f.montoSubtotal - a.montoAsegurado
        WHERE f.consultaCodigo = NEW.consultaCodigo;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `consulta_afeccion`
--

DROP TABLE IF EXISTS `consulta_afeccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consulta_afeccion` (
  `consultaCodigo` varchar(30) NOT NULL,
  `idAfeccion` int unsigned NOT NULL,
  PRIMARY KEY (`consultaCodigo`,`idAfeccion`),
  KEY `idAfeccion` (`idAfeccion`),
  CONSTRAINT `consulta_afeccion_ibfk_1` FOREIGN KEY (`consultaCodigo`) REFERENCES `consulta` (`consultaCodigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `consulta_afeccion_ibfk_2` FOREIGN KEY (`idAfeccion`) REFERENCES `afeccion` (`idAfeccion`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consulta_afeccion`
--

LOCK TABLES `consulta_afeccion` WRITE;
/*!40000 ALTER TABLE `consulta_afeccion` DISABLE KEYS */;
/*!40000 ALTER TABLE `consulta_afeccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consultorio`
--

DROP TABLE IF EXISTS `consultorio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consultorio` (
  `idConsultorio` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `direccion` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `telefono` varchar(18) NOT NULL,
  PRIMARY KEY (`idConsultorio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consultorio`
--

LOCK TABLES `consultorio` WRITE;
/*!40000 ALTER TABLE `consultorio` DISABLE KEYS */;
/*!40000 ALTER TABLE `consultorio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuadres`
--

DROP TABLE IF EXISTS `cuadres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuadres` (
  `idCuadre` int unsigned NOT NULL AUTO_INCREMENT,
  `documentoCajero` varchar(30) NOT NULL,
  `idSucursal` int unsigned NOT NULL,
  `montoDescargado` decimal(10,2) NOT NULL,
  `fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idCuadre`),
  KEY `documentoCajero` (`documentoCajero`),
  KEY `idSucursal` (`idSucursal`),
  CONSTRAINT `cuadres_ibfk_1` FOREIGN KEY (`documentoCajero`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE,
  CONSTRAINT `cuadres_ibfk_2` FOREIGN KEY (`idSucursal`) REFERENCES `sucursal` (`idSucursal`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuadres`
--

LOCK TABLES `cuadres` WRITE;
/*!40000 ALTER TABLE `cuadres` DISABLE KEYS */;
INSERT INTO `cuadres` VALUES (1,'40230375483',1,54525.00,'2024-04-18 18:19:14'),(2,'40230375483',1,6325.00,'2024-04-19 18:55:04'),(4,'40230375483',1,6881.00,'2024-04-19 19:23:28');
/*!40000 ALTER TABLE `cuadres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuenta`
--

DROP TABLE IF EXISTS `cuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuenta` (
  `idCuenta` int unsigned NOT NULL AUTO_INCREMENT,
  `documentoUsuario` varchar(30) NOT NULL,
  `balance` decimal(10,2) NOT NULL DEFAULT '0.00',
  `estado` enum('A','D') NOT NULL DEFAULT 'A',
  PRIMARY KEY (`idCuenta`),
  UNIQUE KEY `documentoUsuario` (`documentoUsuario`),
  CONSTRAINT `cuenta_ibfk_1` FOREIGN KEY (`documentoUsuario`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuenta`
--

LOCK TABLES `cuenta` WRITE;
/*!40000 ALTER TABLE `cuenta` DISABLE KEYS */;
INSERT INTO `cuenta` VALUES (1,'0',0.00,'A'),(2,'1',0.00,'A'),(3,'403',0.00,'A'),(4,'2',6325.00,'A'),(5,'5',6881.00,'A'),(6,'40200162359',0.00,'A');
/*!40000 ALTER TABLE `cuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `denominaciones`
--

DROP TABLE IF EXISTS `denominaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `denominaciones` (
  `valorDenominacion` int NOT NULL,
  `cantidadEnCaja` int NOT NULL,
  `total` int GENERATED ALWAYS AS ((`valorDenominacion` * `cantidadEnCaja`)) VIRTUAL,
  `idSucursal` int unsigned NOT NULL,
  PRIMARY KEY (`valorDenominacion`),
  KEY `fk_denominaciones_sucursal` (`idSucursal`),
  CONSTRAINT `fk_denominaciones_sucursal` FOREIGN KEY (`idSucursal`) REFERENCES `sucursal` (`idSucursal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `denominaciones`
--

LOCK TABLES `denominaciones` WRITE;
/*!40000 ALTER TABLE `denominaciones` DISABLE KEYS */;
INSERT INTO `denominaciones` (`valorDenominacion`, `cantidadEnCaja`, `idSucursal`) VALUES (1,0,1),(5,0,1),(10,0,1),(25,0,1),(50,0,1),(100,0,1),(200,0,1),(500,0,1),(1000,0,1),(2000,0,1);
/*!40000 ALTER TABLE `denominaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura` (
  `facturaCodigo` varchar(30) NOT NULL,
  `idCuenta` int unsigned NOT NULL,
  `consultaCodigo` varchar(30) DEFAULT NULL,
  `idIngreso` int unsigned DEFAULT NULL,
  `idSucursal` int unsigned NOT NULL,
  `documentoCajero` varchar(30) NOT NULL,
  `montoSubtotal` decimal(10,2) NOT NULL DEFAULT '0.00',
  `montoTotal` decimal(10,2) NOT NULL DEFAULT '0.00',
  `fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `estado` enum('P','R') NOT NULL DEFAULT 'P',
  PRIMARY KEY (`facturaCodigo`),
  UNIQUE KEY `consultaCodigo` (`consultaCodigo`),
  UNIQUE KEY `idIngreso` (`idIngreso`),
  KEY `idCuenta` (`idCuenta`),
  KEY `idSucursal` (`idSucursal`),
  KEY `documentoCajero` (`documentoCajero`),
  CONSTRAINT `factura_ibfk_1` FOREIGN KEY (`idCuenta`) REFERENCES `cuenta` (`idCuenta`),
  CONSTRAINT `factura_ibfk_2` FOREIGN KEY (`consultaCodigo`) REFERENCES `consulta` (`consultaCodigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `factura_ibfk_3` FOREIGN KEY (`idIngreso`) REFERENCES `ingreso` (`idIngreso`) ON DELETE CASCADE,
  CONSTRAINT `factura_ibfk_4` FOREIGN KEY (`idSucursal`) REFERENCES `sucursal` (`idSucursal`) ON DELETE CASCADE,
  CONSTRAINT `factura_ibfk_5` FOREIGN KEY (`documentoCajero`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura`
--

LOCK TABLES `factura` WRITE;
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
INSERT INTO `factura` VALUES ('006abf-6f48-44f7-8d1f-8e588808',5,NULL,NULL,1,'40230375483',3400.00,3400.00,'2024-04-17 11:18:58','R'),('f18c44-6771-4f2b-8848-e631c168',4,NULL,NULL,1,'40230375483',6325.00,6325.00,'2024-04-19 18:22:08','R'),('faf0c5-1aba-4fb3-9609-d499323a',5,NULL,NULL,1,'40230375483',6881.00,6881.00,'2024-04-19 19:21:44','R');
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trVerificarFacturaRelaciones` BEFORE INSERT ON `factura` FOR EACH ROW BEGIN
    DECLARE consultaCount INT;
    DECLARE ingresoCount INT;
    
    -- Check if both consultaCodigo and idIngreso are provided
    SELECT COUNT(*) INTO consultaCount FROM Factura WHERE NEW.consultaCodigo IS NOT NULL AND NEW.facturaCodigo = facturaCodigo;
    SELECT COUNT(*) INTO ingresoCount FROM Factura WHERE NEW.idIngreso IS NOT NULL AND NEW.facturaCodigo = facturaCodigo;
    
    -- If both consultaCodigo and idIngreso are provided, raise an error
    IF consultaCount > 0 AND ingresoCount > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Una factura no puede incluir una consulta y un ingreso al mismo tiempo.';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trActualizarFacturaAfterInsertFacturaConsulta` AFTER INSERT ON `factura` FOR EACH ROW BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE total DECIMAL(10,2);
    DECLARE costoConsulta   DECIMAL(10,2);
    
    IF NEW.consultaCodigo IS NOT NULL THEN
        SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SELECT montoTotal INTO total FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SELECT costo INTO costoConsulta FROM Consulta WHERE consultaCodigo = NEW.consultaCodigo;
    
        SET subtotal = subtotal + costoConsulta;
        UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
        
        SET total = total + costoConsulta;
        UPDATE Factura SET montoTotal = total WHERE facturaCodigo = NEW.facturaCodigo;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trActualizarFacturaAfterInsertFacturaIngreso` AFTER UPDATE ON `factura` FOR EACH ROW BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE total DECIMAL(10,2);
    DECLARE costo DECIMAL(10,2);
    
    IF NEW.idIngreso IS NOT NULL THEN
        SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SELECT costoEstancia INTO costo FROM Ingreso WHERE idIngreso = NEW.idIngreso;
    
        SET subtotal = subtotal + costo;
    
        UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
        
        SELECT montoTotal INTO total FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SET total = total + costo;
        UPDATE Factura SET montoTotal = total WHERE facturaCodigo = NEW.facturaCodigo;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `factura_metodopago`
--

DROP TABLE IF EXISTS `factura_metodopago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura_metodopago` (
  `facturaCodigo` varchar(30) NOT NULL,
  `idMetodoPago` int unsigned NOT NULL,
  PRIMARY KEY (`facturaCodigo`,`idMetodoPago`),
  KEY `idMetodoPago` (`idMetodoPago`),
  CONSTRAINT `factura_metodopago_ibfk_1` FOREIGN KEY (`facturaCodigo`) REFERENCES `factura` (`facturaCodigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `factura_metodopago_ibfk_2` FOREIGN KEY (`idMetodoPago`) REFERENCES `metodopago` (`idMetodoPago`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_metodopago`
--

LOCK TABLES `factura_metodopago` WRITE;
/*!40000 ALTER TABLE `factura_metodopago` DISABLE KEYS */;
/*!40000 ALTER TABLE `factura_metodopago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura_producto`
--

DROP TABLE IF EXISTS `factura_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura_producto` (
  `facturaCodigo` varchar(30) NOT NULL,
  `idProducto` int unsigned NOT NULL,
  `idAutorizacion` int unsigned DEFAULT NULL,
  `resultados` text,
  `costo` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`facturaCodigo`,`idProducto`),
  UNIQUE KEY `idAutorizacion` (`idAutorizacion`),
  KEY `idProducto` (`idProducto`),
  CONSTRAINT `factura_producto_ibfk_1` FOREIGN KEY (`facturaCodigo`) REFERENCES `factura` (`facturaCodigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `factura_producto_ibfk_2` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idProducto`) ON DELETE CASCADE,
  CONSTRAINT `factura_producto_ibfk_3` FOREIGN KEY (`idAutorizacion`) REFERENCES `autorizacion` (`idAutorizacion`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_producto`
--

LOCK TABLES `factura_producto` WRITE;
/*!40000 ALTER TABLE `factura_producto` DISABLE KEYS */;
INSERT INTO `factura_producto` VALUES ('006abf-6f48-44f7-8d1f-8e588808',1,NULL,'4',50.00),('f18c44-6771-4f2b-8848-e631c168',1,NULL,'4',50.00),('f18c44-6771-4f2b-8848-e631c168',3,NULL,'1',75.00),('faf0c5-1aba-4fb3-9609-d499323a',2,NULL,'1',72.00);
/*!40000 ALTER TABLE `factura_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura_servicio`
--

DROP TABLE IF EXISTS `factura_servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura_servicio` (
  `facturaCodigo` varchar(30) NOT NULL,
  `servicioCodigo` varchar(30) NOT NULL,
  `idAutorizacion` int unsigned DEFAULT NULL,
  `resultados` text,
  `costo` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`facturaCodigo`,`servicioCodigo`),
  UNIQUE KEY `idAutorizacion` (`idAutorizacion`),
  KEY `servicioCodigo` (`servicioCodigo`),
  CONSTRAINT `factura_servicio_ibfk_1` FOREIGN KEY (`facturaCodigo`) REFERENCES `factura` (`facturaCodigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `factura_servicio_ibfk_2` FOREIGN KEY (`servicioCodigo`) REFERENCES `servicio` (`servicioCodigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `factura_servicio_ibfk_3` FOREIGN KEY (`idAutorizacion`) REFERENCES `autorizacion` (`idAutorizacion`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_servicio`
--

LOCK TABLES `factura_servicio` WRITE;
/*!40000 ALTER TABLE `factura_servicio` DISABLE KEYS */;
INSERT INTO `factura_servicio` VALUES ('006abf-6f48-44f7-8d1f-8e588808','CPR',NULL,'1',3200.00),('f18c44-6771-4f2b-8848-e631c168','CON1',NULL,'1',2850.00),('f18c44-6771-4f2b-8848-e631c168','CPR',NULL,'1',3200.00),('faf0c5-1aba-4fb3-9609-d499323a','CON1',NULL,'1',2850.00),('faf0c5-1aba-4fb3-9609-d499323a','CPRIN',NULL,'1',3959.00);
/*!40000 ALTER TABLE `factura_servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingreso`
--

DROP TABLE IF EXISTS `ingreso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingreso` (
  `idIngreso` int unsigned NOT NULL AUTO_INCREMENT,
  `documentoPaciente` varchar(30) NOT NULL,
  `documentoEnfermero` varchar(30) NOT NULL,
  `documentoMedico` varchar(30) NOT NULL,
  `consultaCodigo` varchar(30) DEFAULT NULL,
  `idAutorizacion` int unsigned DEFAULT NULL,
  `numSala` int unsigned NOT NULL,
  `costoEstancia` decimal(10,2) NOT NULL DEFAULT '5000.00',
  `fechaIngreso` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaAlta` datetime DEFAULT NULL,
  PRIMARY KEY (`idIngreso`),
  UNIQUE KEY `consultaCodigo` (`consultaCodigo`),
  KEY `documentoPaciente` (`documentoPaciente`),
  KEY `documentoMedico` (`documentoMedico`),
  KEY `documentoEnfermero` (`documentoEnfermero`),
  KEY `idAutorizacion` (`idAutorizacion`),
  KEY `numSala` (`numSala`),
  CONSTRAINT `ingreso_ibfk_1` FOREIGN KEY (`documentoPaciente`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ingreso_ibfk_2` FOREIGN KEY (`documentoMedico`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ingreso_ibfk_3` FOREIGN KEY (`documentoEnfermero`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ingreso_ibfk_4` FOREIGN KEY (`idAutorizacion`) REFERENCES `autorizacion` (`idAutorizacion`) ON DELETE CASCADE,
  CONSTRAINT `ingreso_ibfk_5` FOREIGN KEY (`numSala`) REFERENCES `sala` (`numSala`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingreso`
--

LOCK TABLES `ingreso` WRITE;
/*!40000 ALTER TABLE `ingreso` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingreso` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trCheckDocumentoDiferenteIngreso` BEFORE INSERT ON `ingreso` FOR EACH ROW BEGIN
    IF NEW.documentoPaciente = NEW.documentoEnfermero OR NEW.documentoPaciente = NEW.documentoMedico OR NEW.documentoEnfermero = NEW.documentoMedico THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Los documentos del paciente, enfermero y médico deben ser diferentes entre sí';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trActualizarMontoTotalFacturaAfterUpdateIngreso` AFTER UPDATE ON `ingreso` FOR EACH ROW BEGIN
    IF OLD.idAutorizacion IS NULL AND OLD.idAutorizacion <> NEW.idAutorizacion THEN
        UPDATE Factura f
        JOIN Autorizacion a ON NEW.idAutorizacion = a.idAutorizacion
        SET f.montoTotal = f.montoSubtotal - a.montoAsegurado
        WHERE f.idIngreso = NEW.idIngreso;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `ingreso_afeccion`
--

DROP TABLE IF EXISTS `ingreso_afeccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingreso_afeccion` (
  `idIngreso` int unsigned NOT NULL,
  `idAfeccion` int unsigned NOT NULL,
  PRIMARY KEY (`idIngreso`,`idAfeccion`),
  KEY `idAfeccion` (`idAfeccion`),
  CONSTRAINT `ingreso_afeccion_ibfk_1` FOREIGN KEY (`idIngreso`) REFERENCES `ingreso` (`idIngreso`) ON DELETE CASCADE,
  CONSTRAINT `ingreso_afeccion_ibfk_2` FOREIGN KEY (`idAfeccion`) REFERENCES `afeccion` (`idAfeccion`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingreso_afeccion`
--

LOCK TABLES `ingreso_afeccion` WRITE;
/*!40000 ALTER TABLE `ingreso_afeccion` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingreso_afeccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL,
  `Thread` varchar(255) NOT NULL,
  `Level` varchar(50) NOT NULL,
  `Logger` varchar(255) NOT NULL,
  `Message` varchar(4000) NOT NULL,
  `Exception` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=520 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
INSERT INTO `log` VALUES (1,'2024-04-19 18:11:40','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(2,'2024-04-19 18:11:40','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(3,'2024-04-19 18:11:40','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(4,'2024-04-19 18:11:49','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(5,'2024-04-19 18:11:49','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(6,'2024-04-19 18:11:53','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(7,'2024-04-19 18:11:54','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(8,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(9,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(10,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(11,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(12,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(13,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(14,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(15,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(16,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(17,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(18,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(19,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(20,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(21,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(22,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(23,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(24,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(25,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(26,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(27,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(28,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(29,'2024-04-19 18:11:55','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(30,'2024-04-19 18:12:04','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(31,'2024-04-19 18:12:05','1','INFO','CajaHospital.views.CuadreCaja','Error al cargar las facturas actuales, mensaje de error: System.InvalidOperationException: Connection must be valid and open.\r\n   en MySql.Data.MySqlClient.MySqlConnection.Throw(Exception ex)\r\n   en MySql.Data.MySqlClient.MySqlCommand.Throw(Exception ex)\r\n   en MySql.Data.MySqlClient.MySqlCommand.CheckState()\r\n   en MySql.Data.MySqlClient.MySqlCommand.<ExecuteReaderAsync>d__111.MoveNext()\r\n--- Fin del seguimiento de la pila de la ubicación anterior donde se produjo la excepción ---\r\n   en System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   en System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   en MySql.Data.MySqlClient.MySqlCommand.ExecuteReader()\r\n   en CajaHospital.views.CuadreCaja.CuadreCaja_Load(Object sender, EventArgs e) en C:\\Users\\user\\source\\repos\\d4r1us-drk\\Caresoft\\caresoft_vending\\CajaHospital\\views\\CuadreCaja.cs:línea 42',''),(32,'2024-04-19 18:12:11','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente',''),(33,'2024-04-19 18:12:38','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(34,'2024-04-19 18:12:38','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(35,'2024-04-19 18:12:38','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(36,'2024-04-19 18:12:47','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(37,'2024-04-19 18:12:47','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(38,'2024-04-19 18:12:51','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(39,'2024-04-19 18:12:51','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(40,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(41,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(42,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(43,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(44,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(45,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(46,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(47,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(48,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(49,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(50,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(51,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(52,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(53,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(54,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(55,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(56,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(57,'2024-04-19 18:12:52','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(58,'2024-04-19 18:12:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(59,'2024-04-19 18:12:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(60,'2024-04-19 18:12:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(61,'2024-04-19 18:12:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(62,'2024-04-19 18:12:56','1','INFO','CajaHospital.views.ReporteFacturas','Consultando facturas...',''),(63,'2024-04-19 18:12:56','1','INFO','CajaHospital.views.ReporteFacturas','Facturas consultadas',''),(64,'2024-04-19 18:13:11','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(65,'2024-04-19 18:13:11','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(66,'2024-04-19 18:13:15','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(67,'2024-04-19 18:13:15','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(68,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(69,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(70,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(71,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(72,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(73,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(74,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(75,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(76,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(77,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(78,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(79,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(80,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(81,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(82,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(83,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(84,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(85,'2024-04-19 18:13:19','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(86,'2024-04-19 18:13:20','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(87,'2024-04-19 18:13:20','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(88,'2024-04-19 18:13:20','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(89,'2024-04-19 18:13:20','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(90,'2024-04-19 18:13:23','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(91,'2024-04-19 18:13:24','1','INFO','CajaHospital.views.CuadreCaja','Error al cargar las facturas actuales, mensaje de error: System.InvalidOperationException: Connection must be valid and open.\r\n   en MySql.Data.MySqlClient.MySqlConnection.Throw(Exception ex)\r\n   en MySql.Data.MySqlClient.MySqlCommand.Throw(Exception ex)\r\n   en MySql.Data.MySqlClient.MySqlCommand.CheckState()\r\n   en MySql.Data.MySqlClient.MySqlCommand.<ExecuteReaderAsync>d__111.MoveNext()\r\n--- Fin del seguimiento de la pila de la ubicación anterior donde se produjo la excepción ---\r\n   en System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   en System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   en MySql.Data.MySqlClient.MySqlCommand.ExecuteReader()\r\n   en CajaHospital.views.CuadreCaja.CuadreCaja_Load(Object sender, EventArgs e) en C:\\Users\\user\\source\\repos\\d4r1us-drk\\Caresoft\\caresoft_vending\\CajaHospital\\views\\CuadreCaja.cs:línea 42',''),(92,'2024-04-19 18:13:30','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente',''),(93,'2024-04-19 18:14:14','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(94,'2024-04-19 18:14:14','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(95,'2024-04-19 18:14:14','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(96,'2024-04-19 18:14:23','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(97,'2024-04-19 18:14:23','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(98,'2024-04-19 18:14:27','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(99,'2024-04-19 18:14:27','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(100,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(101,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(102,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(103,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(104,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(105,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(106,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(107,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(108,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(109,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(110,'2024-04-19 18:14:28','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(111,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(112,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(113,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(114,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(115,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(116,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(117,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(118,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(119,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(120,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(121,'2024-04-19 18:14:29','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(122,'2024-04-19 18:14:56','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(123,'2024-04-19 18:15:13','1','INFO','CajaHospital.views.CuadreCaja','Error al cargar las facturas actuales, mensaje de error: System.InvalidOperationException: Connection must be valid and open.\r\n   en MySql.Data.MySqlClient.MySqlConnection.Throw(Exception ex)\r\n   en MySql.Data.MySqlClient.MySqlCommand.Throw(Exception ex)\r\n   en MySql.Data.MySqlClient.MySqlCommand.CheckState()\r\n   en MySql.Data.MySqlClient.MySqlCommand.<ExecuteReaderAsync>d__111.MoveNext()\r\n--- Fin del seguimiento de la pila de la ubicación anterior donde se produjo la excepción ---\r\n   en System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   en System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   en MySql.Data.MySqlClient.MySqlCommand.ExecuteReader()\r\n   en CajaHospital.views.CuadreCaja.CuadreCaja_Load(Object sender, EventArgs e) en C:\\Users\\user\\source\\repos\\d4r1us-drk\\Caresoft\\caresoft_vending\\CajaHospital\\views\\CuadreCaja.cs:línea 42',''),(124,'2024-04-19 18:15:47','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(125,'2024-04-19 18:16:12','1','INFO','CajaHospital.views.CuadreCaja','Error al cargar las facturas actuales, mensaje de error: System.InvalidOperationException: Connection must be valid and open.\r\n   en MySql.Data.MySqlClient.MySqlConnection.Throw(Exception ex)\r\n   en MySql.Data.MySqlClient.MySqlCommand.Throw(Exception ex)\r\n   en MySql.Data.MySqlClient.MySqlCommand.CheckState()\r\n   en MySql.Data.MySqlClient.MySqlCommand.<ExecuteReaderAsync>d__111.MoveNext()\r\n--- Fin del seguimiento de la pila de la ubicación anterior donde se produjo la excepción ---\r\n   en System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   en System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   en MySql.Data.MySqlClient.MySqlCommand.ExecuteReader()\r\n   en CajaHospital.views.CuadreCaja.CuadreCaja_Load(Object sender, EventArgs e)',''),(126,'2024-04-19 18:16:48','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(127,'2024-04-19 18:16:51','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(128,'2024-04-19 18:17:15','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(129,'2024-04-19 18:17:17','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(130,'2024-04-19 18:20:53','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(131,'2024-04-19 18:20:53','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(132,'2024-04-19 18:20:53','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(133,'2024-04-19 18:21:03','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(134,'2024-04-19 18:21:03','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(135,'2024-04-19 18:21:07','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(136,'2024-04-19 18:21:07','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(137,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(138,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(139,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(140,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(141,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(142,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(143,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(144,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(145,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(146,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(147,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(148,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(149,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(150,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(151,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(152,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(153,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(154,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(155,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(156,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(157,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(158,'2024-04-19 18:21:08','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(159,'2024-04-19 18:21:19','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Solicitando paciente...',''),(160,'2024-04-19 18:21:19','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Paciente de documento #5 encontrado, rellenando formulario...',''),(161,'2024-04-19 18:21:42','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Solicitando paciente...',''),(162,'2024-04-19 18:21:42','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Paciente de documento #5 encontrado, rellenando formulario...',''),(163,'2024-04-19 18:21:50','1','INFO','CajaHospital.views.FacturarView','Consultando servicios...',''),(164,'2024-04-19 18:21:50','1','INFO','CajaHospital.views.FacturarView','Consultando productos...',''),(165,'2024-04-19 18:21:59','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(166,'2024-04-19 18:22:01','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(167,'2024-04-19 18:22:03','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(168,'2024-04-19 18:22:03','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(169,'2024-04-19 18:22:03','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(170,'2024-04-19 18:22:05','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(171,'2024-04-19 18:22:08','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(172,'2024-04-19 18:22:09','1','INFO','CajaHospital.views.FacturarView','Recuperando cuenta con el documento 2...',''),(173,'2024-04-19 18:22:09','1','INFO','CajaHospital.views.FacturarView','Creando factura #f18c44-6771-4f2b-8848-e631c168...',''),(174,'2024-04-19 18:22:09','1','INFO','CajaHospital.views.FacturarView','Factura creada correctamente con ID: f18c44-6771-4f2b-8848-e631c168',''),(175,'2024-04-19 18:22:09','1','INFO','CajaHospital.views.FacturarView','Relacionando servicio CPR con factura f18c44-6771-4f2b-8848-e631c168...',''),(176,'2024-04-19 18:22:09','1','INFO','CajaHospital.views.FacturarView','Relacionando servicio CON1 con factura f18c44-6771-4f2b-8848-e631c168...',''),(177,'2024-04-19 18:22:09','1','INFO','CajaHospital.views.FacturarView','Relacionando producto 1 con factura f18c44-6771-4f2b-8848-e631c168...',''),(178,'2024-04-19 18:22:09','1','INFO','CajaHospital.views.FacturarView','Relacionando producto 3 con factura f18c44-6771-4f2b-8848-e631c168...',''),(179,'2024-04-19 18:22:09','1','INFO','CajaHospital.views.FacturarView','Incrementando balance de la cuenta 4...',''),(180,'2024-04-19 18:22:09','1','INFO','CajaHospital.views.FacturarView','Balance de la cuenta 4 incrementado $6325',''),(181,'2024-04-19 18:22:15','1','INFO','CajaHospital.views.ReporteFacturas','Consultando facturas...',''),(182,'2024-04-19 18:22:15','1','INFO','CajaHospital.views.ReporteFacturas','Facturas consultadas',''),(183,'2024-04-19 18:22:17','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(184,'2024-04-19 18:22:17','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(185,'2024-04-19 18:23:25','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente',''),(186,'2024-04-19 18:24:53','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(187,'2024-04-19 18:24:53','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(188,'2024-04-19 18:24:53','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(189,'2024-04-19 18:25:03','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(190,'2024-04-19 18:25:03','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(191,'2024-04-19 18:25:07','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(192,'2024-04-19 18:25:07','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(193,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(194,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(195,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(196,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(197,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(198,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(199,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(200,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(201,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(202,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(203,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(204,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(205,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(206,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(207,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(208,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(209,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(210,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(211,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(212,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(213,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(214,'2024-04-19 18:25:09','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(215,'2024-04-19 18:25:17','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(216,'2024-04-19 18:25:17','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(217,'2024-04-19 18:25:43','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente',''),(218,'2024-04-19 18:26:51','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(219,'2024-04-19 18:26:51','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(220,'2024-04-19 18:26:51','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(221,'2024-04-19 18:27:01','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(222,'2024-04-19 18:27:01','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(223,'2024-04-19 18:27:05','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(224,'2024-04-19 18:27:05','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(225,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(226,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(227,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(228,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(229,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(230,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(231,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(232,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(233,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(234,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(235,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(236,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(237,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(238,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(239,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(240,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(241,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(242,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(243,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(244,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(245,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(246,'2024-04-19 18:27:07','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(247,'2024-04-19 18:27:13','1','INFO','CajaHospital.views.ReporteFacturas','Consultando facturas...',''),(248,'2024-04-19 18:27:13','1','INFO','CajaHospital.views.ReporteFacturas','Facturas consultadas',''),(249,'2024-04-19 18:27:22','1','INFO','CajaHospital.views.frmDetallesFactura','Cargando productos para factura f18c44-6771-4f2b-8848-e631c168...',''),(250,'2024-04-19 18:27:22','1','INFO','CajaHospital.views.frmDetallesFactura','Cargando servicios para factura f18c44-6771-4f2b-8848-e631c168...',''),(251,'2024-04-19 18:27:40','1','INFO','CajaHospital.views.PagoControl','Ingresando denominaciones...',''),(252,'2024-04-19 18:27:40','1','INFO','CajaHospital.views.PagoControl','Denominaciones ingresadas',''),(253,'2024-04-19 18:27:40','1','INFO','CajaHospital.views.frmDetallesFactura','Procesando pago para cuenta 4...',''),(254,'2024-04-19 18:27:40','1','INFO','CajaHospital.views.frmDetallesFactura','Pago exitoso para cuenta: 4',''),(255,'2024-04-19 18:27:40','1','INFO','CajaHospital.views.frmDetallesFactura','Codigo de factura: f18c44-6771-4f2b-8848-e631c168',''),(256,'2024-04-19 18:27:55','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(257,'2024-04-19 18:27:55','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(258,'2024-04-19 18:28:00','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(259,'2024-04-19 18:28:00','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(260,'2024-04-19 18:28:21','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(261,'2024-04-19 18:28:21','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(262,'2024-04-19 18:28:25','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(263,'2024-04-19 18:28:25','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(264,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(265,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(266,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(267,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(268,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(269,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(270,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(271,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(272,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(273,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(274,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(275,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(276,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(277,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(278,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(279,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(280,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(281,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(282,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(283,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(284,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(285,'2024-04-19 18:29:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(286,'2024-04-19 18:29:14','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Solicitando paciente...',''),(287,'2024-04-19 18:29:14','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Paciente de documento #2 encontrado, rellenando formulario...',''),(288,'2024-04-19 18:29:34','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(289,'2024-04-19 18:29:34','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(290,'2024-04-19 18:30:05','1','INFO','CajaHospital.views.ReporteFacturas','Consultando facturas...',''),(291,'2024-04-19 18:30:05','1','INFO','CajaHospital.views.ReporteFacturas','Facturas consultadas',''),(292,'2024-04-19 18:30:11','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(293,'2024-04-19 18:30:11','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(294,'2024-04-19 18:33:33','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(295,'2024-04-19 18:33:33','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(296,'2024-04-19 18:33:52','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente',''),(297,'2024-04-19 18:54:09','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(298,'2024-04-19 18:54:09','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(299,'2024-04-19 18:54:09','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(300,'2024-04-19 18:54:21','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(301,'2024-04-19 18:54:21','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(302,'2024-04-19 18:54:25','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(303,'2024-04-19 18:54:25','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(304,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(305,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(306,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(307,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(308,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(309,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(310,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(311,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(312,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(313,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(314,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(315,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(316,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(317,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(318,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(319,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(320,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(321,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(322,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(323,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(324,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(325,'2024-04-19 18:54:26','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(326,'2024-04-19 18:54:28','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(327,'2024-04-19 18:54:28','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(328,'2024-04-19 18:55:05','1','INFO','CajaHospital.views.CuadreCaja','Realizando el cuadre, documento del cajero: 40230375483',''),(329,'2024-04-19 18:55:21','1','INFO','CajaHospital.views.CuadreCaja','Realizando el cuadre, documento del cajero: 40230375483',''),(330,'2024-04-19 18:56:45','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente',''),(331,'2024-04-19 18:57:21','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(332,'2024-04-19 18:57:21','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(333,'2024-04-19 18:57:21','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(334,'2024-04-19 18:57:30','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(335,'2024-04-19 18:57:30','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(336,'2024-04-19 18:57:34','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(337,'2024-04-19 18:57:34','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(338,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(339,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(340,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(341,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(342,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(343,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(344,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(345,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(346,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(347,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(348,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(349,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(350,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(351,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(352,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(353,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(354,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(355,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(356,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(357,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(358,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(359,'2024-04-19 18:57:35','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(360,'2024-04-19 18:57:48','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(361,'2024-04-19 18:57:48','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(362,'2024-04-19 18:58:20','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(363,'2024-04-19 18:58:20','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(364,'2024-04-19 18:58:28','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente',''),(365,'2024-04-19 19:19:33','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(366,'2024-04-19 19:19:33','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(367,'2024-04-19 19:19:33','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(368,'2024-04-19 19:19:42','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(369,'2024-04-19 19:19:42','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(370,'2024-04-19 19:19:46','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(371,'2024-04-19 19:19:46','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(372,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(373,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(374,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(375,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(376,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(377,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(378,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(379,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(380,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(381,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(382,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(383,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(384,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(385,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(386,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(387,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(388,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(389,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(390,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(391,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(392,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(393,'2024-04-19 19:19:48','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(394,'2024-04-19 19:19:50','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(395,'2024-04-19 19:19:50','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(396,'2024-04-19 19:20:41','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente',''),(397,'2024-04-19 19:21:05','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(398,'2024-04-19 19:21:05','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(399,'2024-04-19 19:21:05','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(400,'2024-04-19 19:21:17','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(401,'2024-04-19 19:21:17','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(402,'2024-04-19 19:21:21','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(403,'2024-04-19 19:21:21','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(404,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(405,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(406,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(407,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(408,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(409,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(410,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(411,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(412,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(413,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(414,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(415,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(416,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(417,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(418,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(419,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(420,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(421,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(422,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(423,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(424,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(425,'2024-04-19 19:21:22','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(426,'2024-04-19 19:21:29','1','INFO','CajaHospital.views.FacturarView','Consultando servicios...',''),(427,'2024-04-19 19:21:29','1','INFO','CajaHospital.views.FacturarView','Consultando productos...',''),(428,'2024-04-19 19:21:38','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(429,'2024-04-19 19:21:40','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(430,'2024-04-19 19:21:42','1','INFO','CajaHospital.views.FacturarView','Calculando subtotal...',''),(431,'2024-04-19 19:21:44','1','INFO','CajaHospital.views.FacturarView','Recuperando cuenta con el documento 5...',''),(432,'2024-04-19 19:21:44','1','INFO','CajaHospital.views.FacturarView','Creando factura #faf0c5-1aba-4fb3-9609-d499323a...',''),(433,'2024-04-19 19:21:44','1','INFO','CajaHospital.views.FacturarView','Factura creada correctamente con ID: faf0c5-1aba-4fb3-9609-d499323a',''),(434,'2024-04-19 19:21:44','1','INFO','CajaHospital.views.FacturarView','Relacionando servicio CON1 con factura faf0c5-1aba-4fb3-9609-d499323a...',''),(435,'2024-04-19 19:21:44','1','INFO','CajaHospital.views.FacturarView','Relacionando servicio CPRIN con factura faf0c5-1aba-4fb3-9609-d499323a...',''),(436,'2024-04-19 19:21:44','1','INFO','CajaHospital.views.FacturarView','Relacionando producto 2 con factura faf0c5-1aba-4fb3-9609-d499323a...',''),(437,'2024-04-19 19:21:44','1','INFO','CajaHospital.views.FacturarView','Incrementando balance de la cuenta 5...',''),(438,'2024-04-19 19:21:44','1','INFO','CajaHospital.views.FacturarView','Balance de la cuenta 5 incrementado $6881',''),(439,'2024-04-19 19:22:00','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Solicitando paciente...',''),(440,'2024-04-19 19:22:00','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Paciente de documento #5 encontrado, rellenando formulario...',''),(441,'2024-04-19 19:22:06','1','INFO','CajaHospital.views.ReporteFacturas','Consultando facturas...',''),(442,'2024-04-19 19:22:06','1','INFO','CajaHospital.views.ReporteFacturas','Facturas consultadas',''),(443,'2024-04-19 19:22:11','1','INFO','CajaHospital.views.frmDetallesFactura','Cargando productos para factura faf0c5-1aba-4fb3-9609-d499323a...',''),(444,'2024-04-19 19:22:11','1','INFO','CajaHospital.views.frmDetallesFactura','Cargando servicios para factura faf0c5-1aba-4fb3-9609-d499323a...',''),(445,'2024-04-19 19:22:30','1','INFO','CajaHospital.views.PagoControl','Ingresando denominaciones...',''),(446,'2024-04-19 19:22:31','1','INFO','CajaHospital.views.PagoControl','Denominaciones ingresadas',''),(447,'2024-04-19 19:22:31','1','INFO','CajaHospital.views.frmDetallesFactura','Procesando pago para cuenta 5...',''),(448,'2024-04-19 19:22:31','1','INFO','CajaHospital.views.frmDetallesFactura','Pago exitoso para cuenta: 5',''),(449,'2024-04-19 19:22:31','1','INFO','CajaHospital.views.frmDetallesFactura','Codigo de factura: faf0c5-1aba-4fb3-9609-d499323a',''),(450,'2024-04-19 19:22:38','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Solicitando paciente...',''),(451,'2024-04-19 19:22:38','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Paciente de documento #5 encontrado, rellenando formulario...',''),(452,'2024-04-19 19:22:40','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Solicitando paciente...',''),(453,'2024-04-19 19:22:40','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Paciente de documento #5 encontrado, rellenando formulario...',''),(454,'2024-04-19 19:22:49','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(455,'2024-04-19 19:22:49','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(456,'2024-04-19 19:23:00','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(457,'2024-04-19 19:23:00','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(458,'2024-04-19 19:23:05','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(459,'2024-04-19 19:23:05','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(460,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(461,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(462,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(463,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(464,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(465,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(466,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(467,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(468,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(469,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(470,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(471,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(472,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(473,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(474,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(475,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(476,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(477,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(478,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(479,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(480,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(481,'2024-04-19 19:23:05','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(482,'2024-04-19 19:23:16','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Solicitando paciente...',''),(483,'2024-04-19 19:23:16','1','INFO','CajaHospital.views.ConsultarCuentaCliente','Paciente de documento #5 encontrado, rellenando formulario...',''),(484,'2024-04-19 19:23:20','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(485,'2024-04-19 19:23:20','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(486,'2024-04-19 19:23:28','1','INFO','CajaHospital.views.CuadreCaja','Realizando el cuadre, documento del cajero: 40230375483',''),(487,'2024-04-19 19:23:34','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente',''),(488,'2024-04-19 19:23:36','1','INFO','CajaHospital.Program','Configuracion del servicio de registros conpletada',''),(489,'2024-04-19 19:23:36','1','INFO','CajaHospital.Program','Preparandose para correr el sistema de caja...',''),(490,'2024-04-19 19:23:36','1','INFO','CajaHospital.Program','Sistema de caja corriendo correctamente',''),(491,'2024-04-19 19:23:47','1','INFO','CajaHospital.Login','Se ha registrado un intento de login',''),(492,'2024-04-19 19:23:47','1','INFO','CajaHospital.Login','Solicitando informacion al core a través de la capa de integración...',''),(493,'2024-04-19 19:23:52','1','INFO','CajaHospital.Login','Intentando obtener el inicio de sesion desde la base de datos local...',''),(494,'2024-04-19 19:23:52','1','INFO','CajaHospital.Login','Se ha iniciado sesión de manera satisfactoria para usuario 40230375483',''),(495,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Consultando total de la caja...',''),(496,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Total de la caja consultado',''),(497,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(498,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(499,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(500,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(501,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(502,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(503,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(504,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(505,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(506,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(507,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(508,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(509,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(510,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(511,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(512,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(513,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(514,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(515,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Solicitando denominaciones...',''),(516,'2024-04-19 19:23:53','1','INFO','CajaHospital.views.PrincipalView','Denominaciones solicitadas',''),(517,'2024-04-19 19:23:56','1','INFO','CajaHospital.views.CuadreCaja','Consultando facturas para realizar un cuadre...',''),(518,'2024-04-19 19:23:56','1','INFO','CajaHospital.views.CuadreCaja','Facturas cargadas con exito.',''),(519,'2024-04-19 19:25:17','1','INFO','CajaHospital.Program','Sistema de caja apagado correctamente','');
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `metodopago`
--

DROP TABLE IF EXISTS `metodopago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `metodopago` (
  `idMetodoPago` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`idMetodoPago`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `metodopago`
--

LOCK TABLES `metodopago` WRITE;
/*!40000 ALTER TABLE `metodopago` DISABLE KEYS */;
INSERT INTO `metodopago` VALUES (1,'Efectivo'),(2,'Tarjeta');
/*!40000 ALTER TABLE `metodopago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movimientos_caja`
--

DROP TABLE IF EXISTS `movimientos_caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `movimientos_caja` (
  `idMovimiento` int NOT NULL AUTO_INCREMENT,
  `tipoMovimiento` enum('RC','DC') NOT NULL,
  `montoMovimiento` int NOT NULL,
  PRIMARY KEY (`idMovimiento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movimientos_caja`
--

LOCK TABLES `movimientos_caja` WRITE;
/*!40000 ALTER TABLE `movimientos_caja` DISABLE KEYS */;
/*!40000 ALTER TABLE `movimientos_caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pago`
--

DROP TABLE IF EXISTS `pago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pago` (
  `idPago` int unsigned NOT NULL AUTO_INCREMENT,
  `idCuenta` int unsigned NOT NULL,
  `montoPagado` decimal(10,2) NOT NULL,
  `fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `codigoFactura` varchar(30) NOT NULL,
  PRIMARY KEY (`idPago`),
  KEY `idCuenta` (`idCuenta`),
  KEY `fk_idPago_facturaCodigo` (`codigoFactura`),
  CONSTRAINT `fk_idPago_facturaCodigo` FOREIGN KEY (`codigoFactura`) REFERENCES `factura` (`facturaCodigo`),
  CONSTRAINT `pago_ibfk_1` FOREIGN KEY (`idCuenta`) REFERENCES `cuenta` (`idCuenta`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pago`
--

LOCK TABLES `pago` WRITE;
/*!40000 ALTER TABLE `pago` DISABLE KEYS */;
INSERT INTO `pago` VALUES (1,5,3400.00,'2024-04-17 11:23:28','006abf-6f48-44f7-8d1f-8e588808'),(2,4,6325.00,'2024-04-19 18:27:39','f18c44-6771-4f2b-8848-e631c168'),(3,5,6881.00,'2024-04-19 19:22:30','faf0c5-1aba-4fb3-9609-d499323a');
/*!40000 ALTER TABLE `pago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `perfilusuario`
--

DROP TABLE IF EXISTS `perfilusuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perfilusuario` (
  `documento` varchar(30) NOT NULL,
  `tipoDocumento` enum('I','P') NOT NULL DEFAULT 'I',
  `numLicenciaMedica` int unsigned DEFAULT NULL,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `apellido` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `genero` enum('M','F') NOT NULL,
  `fechaNacimiento` date NOT NULL,
  `telefono` varchar(18) NOT NULL,
  `correo` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `direccion` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `rol` enum('P','A','M','E','C') NOT NULL,
  PRIMARY KEY (`documento`),
  UNIQUE KEY `numLicenciaMedica` (`numLicenciaMedica`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfilusuario`
--

LOCK TABLES `perfilusuario` WRITE;
/*!40000 ALTER TABLE `perfilusuario` DISABLE KEYS */;
INSERT INTO `perfilusuario` VALUES ('0','I',NULL,'0','0','M','2000-01-01','0','0','0','A'),('1','I',NULL,'Juan','Sport','M','2001-02-19','8092223451','juan@gmail.com','YYY','P'),('2','I',NULL,'Alexandra','Perez','F','2002-02-28','8091112222','ale@gmail.com','GGG','P'),('40200162359','I',NULL,'Keven','Chen','M','2004-03-16','8093540291','keven.chen@gmail.com','Luis Betancourt no.324','P'),('40230375483','I',NULL,'Jose Manuel','Matos Diaz','M','2024-05-25','8292850048','jose@gmail.com','XXX','A'),('403','I',NULL,'Pepito','Arrozal','M','1954-06-16','8292283456','pepito@gmail.com','Ciudad XXX','P'),('5','I',NULL,'David','Mendoza','M','2004-05-29','8097231453','david.mendoza@gmail.com','campo xxx','P');
/*!40000 ALTER TABLE `perfilusuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trVerificarNumLicenciaMedica` BEFORE INSERT ON `perfilusuario` FOR EACH ROW BEGIN
    IF (NEW.rol = 'M' OR NEW.rol = 'E') AND NEW.numLicenciaMedica IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Los médicos y enfermeros deben tener un número de licencia médica.';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `prescripcion_producto`
--

DROP TABLE IF EXISTS `prescripcion_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prescripcion_producto` (
  `consultaCodigo` varchar(30) NOT NULL,
  `idProducto` int unsigned NOT NULL,
  `cantidad` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`consultaCodigo`,`idProducto`),
  KEY `idProducto` (`idProducto`),
  CONSTRAINT `prescripcion_producto_ibfk_1` FOREIGN KEY (`consultaCodigo`) REFERENCES `consulta` (`consultaCodigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `prescripcion_producto_ibfk_2` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idProducto`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prescripcion_producto`
--

LOCK TABLES `prescripcion_producto` WRITE;
/*!40000 ALTER TABLE `prescripcion_producto` DISABLE KEYS */;
/*!40000 ALTER TABLE `prescripcion_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prescripcion_servicio`
--

DROP TABLE IF EXISTS `prescripcion_servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prescripcion_servicio` (
  `consultaCodigo` varchar(30) NOT NULL,
  `servicioCodigo` varchar(30) NOT NULL,
  PRIMARY KEY (`consultaCodigo`,`servicioCodigo`),
  KEY `servicioCodigo` (`servicioCodigo`),
  CONSTRAINT `prescripcion_servicio_ibfk_1` FOREIGN KEY (`consultaCodigo`) REFERENCES `consulta` (`consultaCodigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `prescripcion_servicio_ibfk_2` FOREIGN KEY (`servicioCodigo`) REFERENCES `servicio` (`servicioCodigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prescripcion_servicio`
--

LOCK TABLES `prescripcion_servicio` WRITE;
/*!40000 ALTER TABLE `prescripcion_servicio` DISABLE KEYS */;
/*!40000 ALTER TABLE `prescripcion_servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producto` (
  `idProducto` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `descripcion` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `costo` decimal(10,2) NOT NULL,
  `loteDisponible` int unsigned NOT NULL,
  PRIMARY KEY (`idProducto`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (1,'Aspirinas','Medicamento para los dolores de cabeza',50.00,99),(2,'Azitromicina Jarabe','Antialergico',72.00,99),(3,'Zyrtec Pastillas','Antialercico',75.00,99);
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proveedor` (
  `rncProveedor` int unsigned NOT NULL,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `direccion` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `telefono` varchar(18) NOT NULL,
  `correo` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`rncProveedor`),
  UNIQUE KEY `correo` (`correo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor_producto`
--

DROP TABLE IF EXISTS `proveedor_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proveedor_producto` (
  `idProducto` int unsigned NOT NULL,
  `rncProveedor` int unsigned NOT NULL,
  PRIMARY KEY (`idProducto`,`rncProveedor`),
  KEY `rncProveedor` (`rncProveedor`),
  CONSTRAINT `proveedor_producto_ibfk_1` FOREIGN KEY (`rncProveedor`) REFERENCES `proveedor` (`rncProveedor`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `proveedor_producto_ibfk_2` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idProducto`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor_producto`
--

LOCK TABLES `proveedor_producto` WRITE;
/*!40000 ALTER TABLE `proveedor_producto` DISABLE KEYS */;
/*!40000 ALTER TABLE `proveedor_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservaservicio`
--

DROP TABLE IF EXISTS `reservaservicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservaservicio` (
  `idReserva` int unsigned NOT NULL AUTO_INCREMENT,
  `documentoPaciente` varchar(30) NOT NULL,
  `documentoMedico` varchar(30) NOT NULL,
  `servicioCodigo` varchar(30) NOT NULL,
  `fechaReservada` datetime NOT NULL,
  `estado` enum('P','R') NOT NULL DEFAULT 'P',
  PRIMARY KEY (`idReserva`,`documentoPaciente`,`documentoMedico`,`servicioCodigo`),
  KEY `documentoPaciente` (`documentoPaciente`),
  KEY `documentoMedico` (`documentoMedico`),
  KEY `servicioCodigo` (`servicioCodigo`),
  CONSTRAINT `reservaservicio_ibfk_1` FOREIGN KEY (`documentoPaciente`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reservaservicio_ibfk_2` FOREIGN KEY (`documentoMedico`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reservaservicio_ibfk_3` FOREIGN KEY (`servicioCodigo`) REFERENCES `servicio` (`servicioCodigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservaservicio`
--

LOCK TABLES `reservaservicio` WRITE;
/*!40000 ALTER TABLE `reservaservicio` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservaservicio` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trCheckDocumentoDiferenteReserva` BEFORE INSERT ON `reservaservicio` FOR EACH ROW BEGIN
    IF NEW.documentoPaciente = NEW.documentoMedico THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El documento del paciente no puede ser igual al documento del médico';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `sala`
--

DROP TABLE IF EXISTS `sala`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sala` (
  `numSala` int unsigned NOT NULL AUTO_INCREMENT,
  `estado` enum('D','O') NOT NULL DEFAULT 'D',
  PRIMARY KEY (`numSala`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sala`
--

LOCK TABLES `sala` WRITE;
/*!40000 ALTER TABLE `sala` DISABLE KEYS */;
/*!40000 ALTER TABLE `sala` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicio`
--

DROP TABLE IF EXISTS `servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicio` (
  `servicioCodigo` varchar(30) NOT NULL,
  `idTipoServicio` int unsigned NOT NULL,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `descripcion` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `costo` decimal(10,2) NOT NULL,
  PRIMARY KEY (`servicioCodigo`),
  KEY `idTipoServicio` (`idTipoServicio`),
  CONSTRAINT `servicio_ibfk_1` FOREIGN KEY (`idTipoServicio`) REFERENCES `tiposervicio` (`idTipoServicio`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicio`
--

LOCK TABLES `servicio` WRITE;
/*!40000 ALTER TABLE `servicio` DISABLE KEYS */;
INSERT INTO `servicio` VALUES ('CON1',1,'Consulta dermatologica','Consulta inicial en el area de dermatologia',2850.00),('CPR',2,'Coprologico regular','Estudio a traves de las heces fecales',3200.00),('CPRIN',2,'Coprologico intensivo','Estudio a traves de las heces fecales, de manera completa',3959.00);
/*!40000 ALTER TABLE `servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sucursal`
--

DROP TABLE IF EXISTS `sucursal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sucursal` (
  `idSucursal` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `direccion` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `telefono` varchar(18) NOT NULL,
  PRIMARY KEY (`idSucursal`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sucursal`
--

LOCK TABLES `sucursal` WRITE;
/*!40000 ALTER TABLE `sucursal` DISABLE KEYS */;
INSERT INTO `sucursal` VALUES (1,'Luperon','XXX','8009320540');
/*!40000 ALTER TABLE `sucursal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiposervicio`
--

DROP TABLE IF EXISTS `tiposervicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tiposervicio` (
  `idTipoServicio` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`idTipoServicio`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiposervicio`
--

LOCK TABLES `tiposervicio` WRITE;
/*!40000 ALTER TABLE `tiposervicio` DISABLE KEYS */;
INSERT INTO `tiposervicio` VALUES (1,'consulta'),(2,'coprologico'),(3,'colonoscopia'),(4,'prueba de alergenos');
/*!40000 ALTER TABLE `tiposervicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `usuarioCodigo` varchar(30) NOT NULL,
  `documentoUsuario` varchar(30) NOT NULL,
  `usuarioContra` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`usuarioCodigo`),
  UNIQUE KEY `documentoUsuario` (`documentoUsuario`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`documentoUsuario`) REFERENCES `perfilusuario` (`documento`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES ('0','0','xlshdshafafnsdbj'),('1','40230375483','123456'),('APere','2','usuarioCaresoft1'),('DMendoz','5','usuarioCaresoft1'),('juancitoSport','1','123456'),('KChe','40200162359','usuarioCaresoft1'),('PArroza','403','usuarioCaresoft1');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'caresoftdb'
--

--
-- Dumping routines for database 'caresoftdb'
--
/*!50003 DROP PROCEDURE IF EXISTS `spAseguradoraActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAseguradoraActualizar`(
    IN p_idAseguradora INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Aseguradora SET
        nombre = p_nombre,
        direccion = p_direccion,
        telefono = p_telefono,
        correo = p_correo
    WHERE idAseguradora = p_idAseguradora;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAseguradoraCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAseguradoraCrear`(
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;
    
    INSERT INTO Aseguradora(nombre, direccion, telefono, correo) VALUES (p_nombre, p_direccion, p_telefono, p_correo);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAseguradoraEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAseguradoraEliminar`(
    IN p_idAseguradora INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Aseguradora WHERE idAseguradora = p_idAseguradora;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAseguradoraListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAseguradoraListar`(
    IN p_idAseguradora INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_idAseguradora IS NULL AND p_nombre IS NULL AND p_telefono IS NULL AND p_correo IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todas las aseguradoras
        SELECT * FROM Aseguradora;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM Aseguradora WHERE 1 = 1';
        
        IF p_idAseguradora IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND idAseguradora = ', p_idAseguradora);
        END IF;
        
        IF p_nombre IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND nombre = "', p_nombre, '"');
        END IF;
        
        IF p_telefono IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND telefono = "', p_telefono, '"');
        END IF;
        
        IF p_correo IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND correo = "', p_correo, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAutorizacionActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAutorizacionActualizar`(
    IN p_idAutorizacion INT UNSIGNED,
    IN p_idAseguradora INT UNSIGNED,
    IN p_montoAsegurado DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Autorizacion SET idAseguradora = p_idAseguradora, montoAsegurado = p_montoAsegurado WHERE idAutorizacion = p_idAutorizacion;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAutorizacionCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAutorizacionCrear`(
    IN p_idAseguradora INT UNSIGNED,
    IN p_montoAsegurado DECIMAL(10,2),
    IN p_facturaCodigo VARCHAR(30),
    IN p_idIngreso INT UNSIGNED,
    IN p_consultaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED
)
BEGIN
    DECLARE autorizacion_id INT UNSIGNED;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Insertar la autorización
    INSERT INTO Autorizacion (idAseguradora, montoAsegurado) VALUES (p_idAseguradora, p_montoAsegurado);
    
    -- Obtener el ID de la autorización recién insertada
    SELECT LAST_INSERT_ID() INTO autorizacion_id;
    
    -- Verificar si se proporcionó un ingreso y asociar la autorización con él
    IF p_idIngreso IS NOT NULL THEN
        UPDATE Ingreso SET idAutorizacion = autorizacion_id WHERE idIngreso = p_idIngreso;
    END IF;

    -- Verificar si se proporcionó una consulta y asociar la autorización con ella
    IF p_consultaCodigo IS NOT NULL THEN
        UPDATE Consulta SET idAutorizacion = autorizacion_id WHERE consultaCodigo = p_consultaCodigo;
    END IF;

    -- Verificar si se proporcionó un servicio y asociar la autorización con él
    IF p_servicioCodigo IS NOT NULL AND p_facturaCodigo IS NOT NULL THEN
        UPDATE Factura_Servicio SET idAutorizacion = autorizacion_id WHERE servicioCodigo = p_servicioCodigo;
    END IF;

    -- Verificar si se proporcionó un producto y asociar la autorización con él
    IF p_idProducto IS NOT NULL AND p_facturaCodigo IS NOT NULL  THEN
        UPDATE Factura_Producto SET idAutorizacion = autorizacion_id WHERE idProducto = p_idProducto;
    END IF;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAutorizacionEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAutorizacionEliminar`(
    IN p_idAutorizacion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Autorizacion WHERE idAutorizacion = p_idAutorizacion;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAutorizacionListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAutorizacionListar`(
    IN p_idAseguradora INT UNSIGNED
)
BEGIN
    -- Verificar si se ha proporcionado un filtro de aseguradora
    IF p_idAseguradora IS NULL THEN
        -- Si no se proporciona un filtro, seleccionar todas las autorizaciones
        SELECT * FROM Autorizacion;
    ELSE
        -- Si se proporciona un filtro, seleccionar las autorizaciones para la aseguradora específica
        SELECT * FROM Autorizacion WHERE idAseguradora = p_idAseguradora;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spCierreDiario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spCierreDiario`()
BEGIN
	truncate movimientos_caja;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaActualizar`(
    IN p_consultaCodigo VARCHAR(30),
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_idConsultorio INT UNSIGNED,
    IN p_motivo NVARCHAR(255),
    IN p_comentarios TEXT,
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Actualizar los datos de la consulta
    UPDATE Consulta
    SET documentoPaciente = p_documentoPaciente,
        documentoMedico = p_documentoMedico,
        idConsultorio = p_idConsultorio,
        motivo = p_motivo,
        comentarios = p_comentarios,
        costo = p_costo
    WHERE consultaCodigo = p_consultaCodigo;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaCrear`(
    IN p_consultaCodigo VARCHAR(30),
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_idConsultorio INT UNSIGNED,
    IN p_motivo NVARCHAR(255),
    IN p_comentarios TEXT,
    IN p_costo DECIMAL(10,2),
    IN p_estado ENUM('P', 'R')  -- Estado de la consulta
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Crear la nueva consulta
    INSERT INTO Consulta (consultaCodigo, documentoPaciente, documentoMedico, idConsultorio, motivo, comentarios, costo, estado)
    VALUES (p_consultaCodigo, p_documentoPaciente, p_documentoMedico, p_idConsultorio, p_motivo, p_comentarios, p_costo, p_estado);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaDesrelacionarAfeccion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaDesrelacionarAfeccion`(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAfeccion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Registrar la afección tratada en la consulta
    DELETE FROM Consulta_Afeccion WHERE consultaCodigo = p_consultaCodigo AND idAfeccion = p_idAfeccion;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaDesrelacionarProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaDesrelacionarProducto`(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED,
    IN p_cantidad INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Prescripcion_Producto WHERE consultaCodigo = p_consultaCodigo AND idProducto = p_idProducto;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaDesrelacionarServicio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaDesrelacionarServicio`(
    IN p_consultaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Prescribir el servicio en la consulta
    DELETE FROM Prescripcion_Servicio WHERE consultaCodigo = p_consultaCodigo AND servicioCodigo = p_servicioCodigo;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaEliminar`(
    IN p_consultaCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Consulta WHERE consultaCodigo = p_consultaCodigo;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaListarAfecciones` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaListarAfecciones`(
    IN p_consultaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Consulta_Afeccion WHERE consultaCodigo = p_consultaCodigo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaListarProductos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaListarProductos`(
    IN p_consultaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Prescripcion_Producto WHERE consultaCodigo = p_consultaCodigo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaListarServicios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaListarServicios`(
    IN p_consultaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Prescripcion_Servicio WHERE consultaCodigo = p_consultaCodigo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaRelacionarAfeccion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaRelacionarAfeccion`(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAfeccion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Registrar la afección tratada en la consulta
    INSERT INTO Consulta_Afeccion (consultaCodigo, idAfeccion) VALUES (p_consultaCodigo, p_idAfeccion);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaRelacionarProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaRelacionarProducto`(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED,
    IN p_cantidad INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Prescribir el producto en la consulta
    INSERT INTO Prescripcion_Producto (consultaCodigo, idProducto, cantidad) VALUES (p_consultaCodigo, p_idProducto, p_cantidad);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultaRelacionarServicio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaRelacionarServicio`(
    IN p_consultaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Prescribir el servicio en la consulta
    INSERT INTO Prescripcion_Servicio (consultaCodigo, servicioCodigo) VALUES (p_consultaCodigo, p_servicioCodigo);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spConsultasListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultasListar`(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_fechaInicio DATETIME,
    IN p_fechaFin DATETIME
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documentoPaciente IS NULL AND p_documentoMedico IS NULL AND p_fechaInicio IS NULL AND p_fechaFin IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todas las consultas
        SELECT *
        FROM Consulta;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM Consulta WHERE 1 = 1';
        
        IF p_documentoPaciente IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoPaciente = "', p_documentoPaciente, '"');
        END IF;
        
        IF p_documentoMedico IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoMedico = "', p_documentoMedico, '"');
        END IF;
        
        IF p_fechaInicio IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha >= "', p_fechaInicio, '"');
        END IF;
        
        IF p_fechaFin IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha <= "', p_fechaFin, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaActualizar`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idCuenta INT UNSIGNED,
    IN p_consultaCodigo VARCHAR(30),
    IN p_idIngreso INT UNSIGNED,
    IN p_idSucursal INT UNSIGNED,
    IN p_documentoCajero VARCHAR(30),
    IN p_montoSubtotal DECIMAL(10,2),
    IN p_montoTotal DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    IF p_consultaCodigo IS NOT NULL THEN
        UPDATE Factura
        SET idCuenta = p_idCuenta,
            consultaCodigo = p_consultaCodigo,
            idSucursal = p_idSucursal,
            documentoCajero = p_documentoCajero,
            montoSubtotal = p_montoSubtotal,
            montoTotal = p_montoTotal
        WHERE facturaCodigo = p_facturaCodigo;
    ELSEIF p_ingreso IS NOT NULL THEN
        UPDATE Factura
        SET idCuenta = p_idCuenta,
            idSucursal = p_idSucursal,
            idIngreso = p_idIngreso,
            documentoCajero = p_documentoCajero,
            montoSubtotal = p_montoSubtotal,
            montoTotal = p_montoTotal
        WHERE facturaCodigo = p_facturaCodigo;
    ELSE
        UPDATE Factura
        SET idCuenta = p_idCuenta,
            idSucursal = p_idSucursal,
            documentoCajero = p_documentoCajero,
            montoSubtotal = p_montoSubtotal,
            montoTotal = p_montoTotal
        WHERE facturaCodigo = p_facturaCodigo;
    END IF;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaCrear`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idCuenta INT UNSIGNED,
    IN p_idSucursal INT UNSIGNED,
    IN p_documentoCajero VARCHAR(30),
    IN p_monto decimal(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura (facturaCodigo, idCuenta, idSucursal, documentoCajero, montoSubtotal, montoTotal)
    VALUES (p_facturaCodigo, p_idCuenta, p_idSucursal, p_documentoCajero, p_monto, p_monto);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaCrearConsulta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaCrearConsulta`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idCuenta INT UNSIGNED,
    IN p_consultaCodigo VARCHAR(30),
    IN p_idSucursal INT UNSIGNED,
    IN p_documentoCajero VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura (facturaCodigo, idCuenta, consultaCodigo, idSucursal, documentoCajero)
    VALUES (p_facturaCodigo, p_idCuenta, p_consultaCodigo, p_idSucursal, p_documentoCajero);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaCrearIngreso` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaCrearIngreso`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idCuenta INT UNSIGNED,
    IN p_idIngreso INT UNSIGNED,
    IN p_idSucursal INT UNSIGNED,
    IN p_documentoCajero VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura (facturaCodigo, idCuenta, idIngreso, idSucursal, documentoCajero)
    VALUES (p_facturaCodigo, p_idCuenta, p_idIngreso, p_idSucursal, p_documentoCajero);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaDesrelacionarMetodoPago` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaDesrelacionarMetodoPago`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idMetodoPago INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Factura_MetodoPago WHERE facturaCodigo = p_facturaCodigo AND idMetodoPago = p_idMetodoPago;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaDesrelacionarProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaDesrelacionarProducto`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Factura_Producto WHERE facturaCodigo = p_facturaCodigo AND idProducto = p_idProducto;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaDesrelacionarServicio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaDesrelacionarServicio`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Factura_Servicio WHERE facturaCodigo = p_facturaCodigo AND servicioCodigo = p_servicioCodigo;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaEliminar`(
    IN p_facturaCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Factura WHERE facturaCodigo = p_facturaCodigo;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaListar`(
    IN p_documentoCajero VARCHAR(30),
    IN p_fechaInicio DATETIME,
    IN p_fechaFin DATETIME
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documentoCajero IS NULL AND p_fechaInicio IS NULL AND p_fechaFin IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todas las facturas
        SELECT *
        FROM Factura;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM Factura WHERE 1 = 1';
        
        IF p_documentoCajero IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoCajero = "', p_documentoCajero, '"');
        END IF;
        
        IF p_fechaInicio IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha >= "', p_fechaInicio, '"');
        END IF;
        
        IF p_fechaFin IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha <= "', p_fechaFin, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaListarMetodoPagos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaListarMetodoPagos`(
    IN p_facturaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Factura_MetodoPago WHERE facturaCodigo = p_facturaCodigo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaListarProductos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaListarProductos`(
    IN p_facturaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Factura_Producto WHERE facturaCodigo = p_facturaCodigo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaListarServicios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaListarServicios`(
    IN p_facturaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Factura_Servicio WHERE facturaCodigo = p_facturaCodigo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaRelacionarMetodoPago` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaRelacionarMetodoPago`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idMetodoPago INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura_MetodoPago (facturaCodigo, idMetodoPago)
    VALUES (p_facturaCodigo, p_idMetodoPago);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaRelacionarProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaRelacionarProducto`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED,
    IN p_resultados TEXT,
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO factura_producto (facturaCodigo, idProducto, resultados, costo)
    VALUES (p_facturaCodigo, p_idProducto, p_resultados, p_costo);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturaRelacionarServicio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturaRelacionarServicio`(
    IN p_facturaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_resultados TEXT,
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO factura_servicio (facturaCodigo, servicioCodigo, resultados, costo)
    VALUES (p_facturaCodigo, p_servicioCodigo, p_resultados, p_costo);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFacturasActualesListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFacturasActualesListar`( IN p_idSucursal int unsigned )
BEGIN
	select * from factura
    where fecha > (select max(fecha) from cuadres where idSucursal = p_idSucursal)
    &&
    estado = 'R'
    &&
    idSucursal = p_idSucursal
    order by montoTotal desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCantidadDenominacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCantidadDenominacion`(in valor_denominacion int, in p_idSucursal int unsigned, out cantidad int)
BEGIN
	select cantidadEnCaja into cantidad from denominaciones
    where valorDenominacion = valor_denominacion && idSucursal = p_idSucursal;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCuadres` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCuadres`(IN p_idSucursal int unsigned)
BEGIN
	select * from cuadres 
    where idSucursal = p_idSucursal;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTotalCaja` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTotalCaja`(in p_idSucursal int unsigned,out totalCaja int)
BEGIN
	select sum(total) into totalCaja
    from denominaciones
    where idSucursal = p_idSucursal;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTotalMovimientos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTotalMovimientos`(out total int)
BEGIN
	Select (select sum(montoMovimiento) from movimientos_caja where tipoMovimiento = 'RC') - (select sum(montoMovimiento) from movimientos_caja where tipoMovimiento = 'DC') into total;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIncrementaBalanceCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIncrementaBalanceCuenta`( in p_idCuenta int, in p_monto decimal(10,2))
BEGIN
	update cuenta
    set balance = balance + p_monto
    where idCuenta = p_idCuenta;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresarDenominaciones` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIngresarDenominaciones`(IN p_2000 int, IN p_1000 int, IN p_500 int, IN p_200 int, IN p_100 int, IN p_50 int, IN p_25 int, IN p_10 int, IN p_5 int, IN p_1 int, IN p_idSucursal int unsigned)
BEGIN
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_2000
    where valorDenominacion = 2000 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_1000
    where valorDenominacion = 1000 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_500
    where valorDenominacion = 500 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_200
    where valorDenominacion = 200 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_100
    where valorDenominacion = 100 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_50
    where valorDenominacion = 50 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_25
    where valorDenominacion = 25 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_10
    where valorDenominacion = 10 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_5
    where valorDenominacion = 5 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = cantidadEnCaja + p_1
    where valorDenominacion = 1 && idSucursal = p_idSucursal;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresoActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIngresoActualizar`(
    IN p_idIngreso INT UNSIGNED,
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoEnfermero VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAutorizacion INT UNSIGNED,
    IN p_numSala INT UNSIGNED,
    IN p_costoEstancia DECIMAL(10,2),
    IN p_fechaAlta DATETIME
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Actualizar los datos del ingreso
    UPDATE Ingreso SET
        documentoPaciente = p_documentoPaciente,
        documentoEnfermero = p_documentoEnfermero,
        documentoMedico = p_documentoMedico,
        consultaCodigo = p_consultaCodigo,
        idAutorizacion = p_idAutorizacion,
        numSala = p_numSala,
        costoEstancia = p_costoEstancia,
        fechaAlta = p_fechaAlta
    WHERE idIngreso = p_idIngreso;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresoCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIngresoCrear`(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoEnfermero VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAutorizacion INT UNSIGNED,
    IN p_numSala INT UNSIGNED,
    IN p_costoEstancia DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Insertar el ingreso
    INSERT INTO Ingreso (documentoPaciente, documentoEnfermero, documentoMedico, consultaCodigo, idAutorizacion, numSala, costoEstancia)
    VALUES (p_documentoPaciente, p_documentoEnfermero, p_documentoMedico, p_consultaCodigo, p_idAutorizacion, p_numSala, p_costoEstancia);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresoDeselacionarAfeccion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIngresoDeselacionarAfeccion`(
    IN p_idIngreso INT UNSIGNED,
    IN p_idAfeccion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Desrelacionar la afección al ingreso
    DELETE FROM Ingreso_Afeccion WHERE idIngreso = p_idIngreso AND idAfeccion = p_idAfeccion;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresoEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIngresoEliminar`(
    IN p_idIngreso INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Eliminar el ingreso
    DELETE FROM Ingreso WHERE idIngreso = p_idIngreso;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresoListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIngresoListar`(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoEnfermero VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAutorizacion INT UNSIGNED,
    IN p_numSala INT UNSIGNED,
    IN p_costoEstancia DECIMAL(10,2),
    IN p_fechaIngreso DATETIME,
    IN p_fechaAlta DATETIME
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documentoPaciente IS NULL AND p_documentoEnfermero IS NULL AND p_documentoMedico IS NULL AND p_consultaCodigo IS NULL
        AND p_idAutorizacion IS NULL AND p_numSala IS NULL AND p_costoEstancia IS NULL AND p_fechaIngreso IS NULL AND p_fechaAlta IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todos los ingresos
        SELECT * FROM Ingreso;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM Ingreso WHERE 1 = 1';
        
        IF p_documentoPaciente IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoPaciente = "', p_documentoPaciente, '"');
        END IF;
        
        IF p_documentoEnfermero IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoEnfermero = "', p_documentoEnfermero, '"');
        END IF;
        
        IF p_documentoMedico IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoMedico = "', p_documentoMedico, '"');
        END IF;
        
        IF p_consultaCodigo IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND consultaCodigo = "', p_consultaCodigo, '"');
        END IF;
        
        IF p_idAutorizacion IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND idAutorizacion = "', p_idAutorizacion, '"');
        END IF;
        
        IF p_numSala IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND numSala = "', p_numSala, '"');
        END IF;
        
        IF p_costoEstancia IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND costoEstancia = "', p_costoEstancia, '"');
        END IF;

        IF p_fechaIngreso IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fechaIngreso = "', p_fechaIngreso, '"');
        END IF;
        
        IF p_fechaAlta IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fechaAlta = "', p_fechaAlta, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresoObtenerAfecciones` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIngresoObtenerAfecciones`(
    IN p_idIngreso INT UNSIGNED
)
BEGIN
    SELECT * FROM Ingreso_Afeccion WHERE idIngreso = p_idIngreso;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresoRelacionarAfeccion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spIngresoRelacionarAfeccion`(
    IN p_idIngreso INT UNSIGNED,
    IN p_idAfeccion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Relacionar la afección al ingreso
    INSERT INTO Ingreso_Afeccion (idIngreso, idAfeccion) VALUES (p_idIngreso, p_idAfeccion);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spListarCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spListarCuenta`( in p_documentoUsuario varchar(30))
BEGIN
	select * from cuenta where documentoUsuario = p_documentoUsuario;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMetodoPagoActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMetodoPagoActualizar`(
    IN p_idMetodoPago INT UNSIGNED,
    IN p_nombre NVARCHAR(100)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE MetodoPago
    SET nombre = p_nombre
    WHERE idMetodoPago = p_idMetodoPago;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMetodoPagoCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMetodoPagoCrear`(
    IN p_nombre NVARCHAR(100)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO MetodoPago (nombre)
    VALUES (p_nombre);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMetodoPagoEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMetodoPagoEliminar`(
    IN p_idMetodoPago INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM MetodoPago WHERE idMetodoPago = p_idMetodoPago;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMetodoPagoListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMetodoPagoListar`()
BEGIN
    SELECT * FROM MetodoPago;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spMovimientoCajaCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spMovimientoCajaCrear`(in tipo varchar(2), in monto int)
BEGIN
	insert into movimientos_caja(tipoMovimiento, montoMovimiento)
    values (tipo, monto);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPagoActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPagoActualizar`(
    IN p_idPago INT UNSIGNED,
    IN p_idCuenta INT UNSIGNED,
    IN p_montoPagado DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Pago SET idCuenta = p_idCuenta, montoPagado = p_montoPagado WHERE idPago = p_idPago;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPagoCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPagoCrear`(
    IN p_idCuenta INT UNSIGNED,
    IN p_montoPagado DECIMAL(10,2),
    IN p_facturaCodigo varchar(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Pago (idCuenta, montoPagado, codigoFactura) VALUES (p_idCuenta, p_montoPagado, p_facturaCodigo);
	UPDATE factura
    set estado = 'R'
    where facturaCodigo = p_facturaCodigo;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPagoEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPagoEliminar`(
    IN p_idPago INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Pago WHERE idPago = p_idPago;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPagoListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPagoListar`()
BEGIN
    SELECT * FROM Pago;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProductoActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProductoActualizar`(
    IN p_idProducto INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2),
    IN p_loteDisponible INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Producto
    SET nombre = p_nombre,
        descripcion = p_descripcion,
        costo = p_costo,
        loteDisponible = p_loteDisponible
    WHERE idProducto = p_idProducto;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProductoCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProductoCrear`(
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2),
    IN p_loteDisponible INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Producto (nombre, descripcion, costo, loteDisponible)
    VALUES (p_nombre, p_descripcion, p_costo, p_loteDisponible);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProductoDesrelacionarProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProductoDesrelacionarProveedor`(
    IN p_idProducto INT UNSIGNED,
    IN p_rncProveedor INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Proveedor_Producto WHERE idProducto = p_idProducto AND rncProveedor = p_rncProveedor;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProductoEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProductoEliminar`(
    IN p_idProducto INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Producto WHERE idProducto = p_idProducto;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProductoListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProductoListar`(
    IN p_costo DECIMAL(10,2)
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF  p_costo IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todos los productos
        SELECT * FROM Producto;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SELECT * FROM Producto WHERE costo = p_costo;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProductoListarProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProductoListarProveedor`(
    IN p_idProducto INT UNSIGNED
)
BEGIN
    SELECT * FROM Proveedor_Producto WHERE idProducto = p_idProducto;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProductoRelacionarProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProductoRelacionarProveedor`(
    IN p_idProducto INT UNSIGNED,
    IN p_rncProveedor INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Proveedor_Producto (idProducto, rncProveedor)
    VALUES (p_idProducto, p_rncProveedor);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProveedorActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProveedorActualizar`(
    IN p_rncProveedor INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Proveedor
    SET nombre = p_nombre, direccion = p_direccion, telefono = p_telefono, correo = p_correo
    WHERE rncProveedor = p_rncProveedor;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProveedorCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProveedorCrear`(
    IN p_rncProveedor INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Proveedor (rncProveedor, nombre, direccion, telefono, correo)
    VALUES (p_rncProveedor, p_nombre, p_direccion, p_telefono, p_correo);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProveedorEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProveedorEliminar`(
    IN p_rncProveedor INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Proveedor WHERE rncProveedor = p_rncProveedor;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spProveedorListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spProveedorListar`(
)
BEGIN
    SELECT * FROM Proveedor;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPurgarMovimientos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spPurgarMovimientos`()
BEGIN
	truncate movimientos_caja;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spRealizaCuadre` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spRealizaCuadre`( IN p_montoDescargado decimal(10,2), IN p_documentoCajero varchar(30), IN p_idSucursal int unsigned)
BEGIN
	insert into cuadres(montoDescargado, documentoCajero, idSucursal)
    values (p_montoDescargado, p_documentoCajero, p_idSucursal);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spReservaActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spReservaActualizar`(
    IN p_idReserva INT UNSIGNED,
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_fechaReserva DATETIME
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si la reserva existe
    SELECT COUNT(*) INTO @reservaExiste FROM ReservaServicio WHERE idReserva = p_idReserva;

    IF @reservaExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La reserva especificada no existe';
    END IF;

    -- Verificar si el paciente y el médico existen
    SELECT COUNT(*) INTO @pacienteExiste FROM PerfilUsuario WHERE documento = p_documentoPaciente;
    SELECT COUNT(*) INTO @medicoExiste FROM PerfilUsuario WHERE documento = p_documentoMedico;
    SELECT COUNT(*) INTO @servicioExiste FROM Servicio WHERE servicioCodigo = p_servicioCodigo;

    IF @pacienteExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El paciente especificado no existe';
    END IF;
    
    IF @medicoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico especificado no existe';
    END IF;
    
    IF @servicioExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El servicio especificado no existe';
    END IF;

    -- Verificar disponibilidad del médico para el servicio
    SELECT COUNT(*) INTO @medicoDisponible
    FROM ReservaServicio
    WHERE documentoMedico = p_documentoMedico
    AND servicioCodigo = p_servicioCodigo
    AND fechaReservada = p_fechaReserva
    AND idReserva != p_idReserva;

    IF @medicoDisponible > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico ya tiene una reserva para el servicio en la fecha especificada';
    END IF;

    -- Actualizar los datos de la reserva del servicio
    UPDATE ReservaServicio
    SET documentoPaciente = p_documentoPaciente,
        documentoMedico = p_documentoMedico,
        servicioCodigo = p_servicioCodigo,
        fechaReservada = p_fechaReserva
    WHERE idReserva = p_idReserva;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spReservaCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spReservaCrear`(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_fechaReserva DATETIME
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;
    
    -- Verificar si el paciente y el médico existen
    SELECT COUNT(*) INTO @pacienteExiste FROM PerfilUsuario WHERE documento = p_documentoPaciente;
    SELECT COUNT(*) INTO @medicoExiste FROM PerfilUsuario WHERE documento = p_documentoMedico;
    SELECT COUNT(*) INTO @servicioExiste FROM Servicio WHERE servicioCodigo = p_servicioCodigo;

    IF @pacienteExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El paciente especificado no existe';
    END IF;
    
    IF @medicoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico especificado no existe';
    END IF;
    
    IF @servicioExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El servicio especificado no existe';
    END IF;

    -- Verificar disponibilidad del médico para el servicio
    SELECT COUNT(*) INTO @medicoDisponible
    FROM ReservaServicio
    WHERE documentoMedico = p_documentoMedico
    AND servicioCodigo = p_servicioCodigo
    AND fechaReservada = p_fechaReserva;

    IF @medicoDisponible > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico ya tiene una reserva para el servicio en la fecha especificada';
    END IF;

    -- Crear la reserva del servicio
    INSERT INTO ReservaServicio (documentoPaciente, documentoMedico, servicioCodigo, fechaReservada)
    VALUES (p_documentoPaciente, p_documentoMedico, p_servicioCodigo, p_fechaReserva);
    
    SELECT LAST_INSERT_ID() AS idReserva; -- Devolver el ID de la reserva creada

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spReservaEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spReservaEliminar`(
    IN p_idReserva INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM ReservaServicio WHERE idReserva = p_idReserva;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spReservaListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spReservaListar`(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_fechaReserva DATETIME,
    IN p_estado ENUM('P', 'R')  -- Nuevo atributo de estado
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documentoPaciente IS NULL AND p_documentoMedico IS NULL AND p_servicioCodigo IS NULL AND p_fechaReserva IS NULL AND p_estado IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todas las reservas
        SELECT * FROM ReservaServicio;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM ReservaServicio WHERE 1 = 1';
        
        IF p_documentoPaciente IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoPaciente = "', p_documentoPaciente, '"');
        END IF;
        
        IF p_documentoMedico IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoMedico = "', p_documentoMedico, '"');
        END IF;
        
        IF p_servicioCodigo IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND servicioCodigo = "', p_servicioCodigo, '"');
        END IF;
        
        IF p_fechaReserva IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fechaReservada = "', p_fechaReserva, '"');
        END IF;
        
        IF p_estado IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND estado = "', p_estado, '"');  -- Agregar filtro por estado
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spReservaToggleEstado` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spReservaToggleEstado`(
    IN p_idReserva INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si la reserva existe
    SELECT COUNT(*) INTO @reservaExiste FROM ReservaServicio WHERE idReserva = p_idReserva;
    
    IF @reservaExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La reserva especificada no existe';
    END IF;

    -- Obtener el estado actual de la reserva
    SELECT estado INTO @estadoActual FROM ReservaServicio WHERE idReserva = p_idReserva;

    -- Cambiar el estado de la reserva
    IF @estadoActual = 'P' THEN
        UPDATE ReservaServicio
        SET estado = 'R'
        WHERE idReserva = p_idReserva;
    ELSE
        UPDATE ReservaServicio
        SET estado = 'P'
        WHERE idReserva = p_idReserva;
    END IF;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spResetDenominaciones` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spResetDenominaciones`(IN p_idSucursal int unsigned)
BEGIN
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 2000 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 1000 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 500 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 200 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 100 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 50 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 25 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 10 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 5 && idSucursal = p_idSucursal;
	update denominaciones
    set cantidadEnCaja = 0
    where valorDenominacion = 1 && idSucursal = p_idSucursal;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spSalaCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSalaCrear`(
    IN p_estado ENUM('D', 'O') -- Disponible por defecto
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Insertar la nueva sala
    INSERT INTO Sala (estado) VALUES (p_estado);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spSalaEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSalaEliminar`(
    IN p_numSala INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Eliminar la sala
    DELETE FROM Sala WHERE numSala = p_numSala;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spSalaListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSalaListar`()
BEGIN
    SELECT * FROM Sala;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spSalaToggleEstado` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSalaToggleEstado`(
    IN p_numSala INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Obtener el estado actual de la sala
    SELECT estado INTO @estadoActual FROM Sala WHERE numSala = p_numSala;

    -- Toggle del estado de la sala
    IF @estadoActual = 'D' THEN
        UPDATE Sala SET estado = 'O' WHERE numSala = p_numSala; -- Cambiar a Ocupada
    ELSE
        UPDATE Sala SET estado = 'D' WHERE numSala = p_numSala; -- Cambiar a Disponible
    END IF;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spServicioActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spServicioActualizar`(
    IN p_servicioCodigo VARCHAR(30),
    IN p_idTipoServicio INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Servicio
    SET idTipoServicio = p_idTipoServicio, nombre = p_nombre, descripcion = p_descripcion, costo = p_costo
    WHERE servicioCodigo = p_servicioCodigo;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spServicioCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spServicioCrear`(
    IN p_servicioCodigo VARCHAR(30),
    IN p_idTipoServicio INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Servicio (servicioCodigo, idTipoServicio, nombre, descripcion, costo)
    VALUES (p_servicioCodigo, p_idTipoServicio, p_nombre, p_descripcion, p_costo);
    
    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spServicioEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spServicioEliminar`(
    IN p_servicioCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Servicio WHERE servicioCodigo = p_servicioCodigo;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spServicioListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spServicioListar`()
BEGIN
    SELECT * FROM Servicio;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spSucursalActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSucursalActualizar`(
    IN p_idSucursal INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Sucursal
    SET nombre = p_nombre, direccion = p_direccion, telefono = p_telefono
    WHERE idSucursal = p_idSucursal;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spSucursalCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSucursalCrear`(
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Sucursal (nombre, direccion, telefono)
    VALUES (p_nombre, p_direccion, p_telefono);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spSucursalEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSucursalEliminar`(
    IN p_idSucursal INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Sucursal WHERE idSucursal = p_idSucursal;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spSucursalListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSucursalListar`()
BEGIN
    SELECT * FROM Sucursal;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spTipoServicioActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spTipoServicioActualizar`(
    IN p_idTipoServicio INT UNSIGNED,
    IN p_nuevoNombre NVARCHAR(100)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;
    
    UPDATE TipoServicio SET nombre = p_nuevoNombre WHERE idTipoServicio = p_idTipoServicio;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spTipoServicioCrear` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spTipoServicioCrear`(
    IN p_nombre NVARCHAR(100)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;
    
    INSERT INTO TipoServicio(nombre) VALUES (p_nombre);

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spTipoServicioEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spTipoServicioEliminar`(
    IN p_idTipoServicio INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM TipoServicio WHERE idTipoServicio = p_idTipoServicio;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spTipoServicioListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spTipoServicioListar`()
BEGIN
    SELECT * FROM TipoServicio;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUpsertDenominacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpsertDenominacion`(valor_denominacion int, cantidad_en_caja int)
BEGIN
	if not exists (select 1 from denominaciones where valorDenominacion = valor_denominacion)
	then
		insert into denominaciones(valorDenominacion, cantidadEnCaja)
		values (valor_denominacion, cantidad_en_caja);
	else
		update denominaciones
		set cantidadEnCaja = cantidad_en_caja
		where valorDenominacion = valor_denominacion;
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUsuarioActualizar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUsuarioActualizar`(
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255),
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_numLicenciaMedica INT,
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_rol ENUM('P', 'A', 'M', 'E', 'C')
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Actualizar los datos de PerfilUsuario
    UPDATE PerfilUsuario
    SET 
        tipoDocumento = p_tipoDocumento,
        numLicenciaMedica = p_numLicenciaMedica,
        nombre = p_nombre,
        apellido = p_apellido,
        genero = p_genero,
        fechaNacimiento = p_fechaNacimiento,
        telefono = p_telefono,
        correo = p_correo,
        direccion = p_direccion,
        rol = p_rol
    WHERE documento = p_documento;

    UPDATE Usuario
    SET
        usuarioCodigo = p_usuarioCodigo,
        usuarioContra = p_usuarioContra
    WHERE documentoUsuario = p_documento;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUsuarioCrearPaciente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUsuarioCrearPaciente`(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255)
)
BEGIN
    DECLARE perfil_doc_exist INT;
    DECLARE cuenta_doc_exist INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el documento ya existe en PerfilUsuario
    SELECT COUNT(*) INTO perfil_doc_exist FROM PerfilUsuario WHERE documento = p_documento;
    
    -- Verificar si el documento ya existe en Usuario
    SELECT COUNT(*) INTO cuenta_doc_exist FROM Usuario WHERE documentoUsuario = p_documento;

    -- Si el documento no existe en PerfilUsuario ni en Usuario, insertarlo
    IF perfil_doc_exist = 0 AND cuenta_doc_exist = 0 THEN
        INSERT INTO PerfilUsuario (documento, tipoDocumento, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol)
        VALUES (p_documento, p_tipoDocumento, p_nombre, p_apellido, p_genero, p_fechaNacimiento, p_telefono, p_correo, p_direccion, 'P');
        
        INSERT INTO Usuario (usuarioCodigo, documentoUsuario, usuarioContra)
        VALUES (p_usuarioCodigo, p_documento, p_usuarioContra);
        
        INSERT INTO Cuenta (documentoUsuario)
        VALUES (p_documento);
        
        COMMIT;
    ELSE
        -- Si el documento existe en PerfilUsuario o en Usuario, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario ya existe.';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUsuarioCrearPersonal` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUsuarioCrearPersonal`(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_rol ENUM('A', 'C'),
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255)
)
BEGIN
    DECLARE perfil_doc_exist INT;
    DECLARE cuenta_doc_exist INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el documento ya existe en PerfilUsuario
    SELECT COUNT(*) INTO perfil_doc_exist FROM PerfilUsuario WHERE documento = p_documento;
    
    -- Verificar si el documento ya existe en Usuario
    SELECT COUNT(*) INTO cuenta_doc_exist FROM Usuario WHERE documentoUsuario = p_documento;

    -- Si el documento no existe en PerfilUsuario ni en Usuario, insertarlo
    IF perfil_doc_exist = 0 AND cuenta_doc_exist = 0 THEN
        INSERT INTO PerfilUsuario (documento, tipoDocumento, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol)
        VALUES (p_documento, p_tipoDocumento, p_nombre, p_apellido, p_genero, p_fechaNacimiento, p_telefono, p_correo, p_direccion, p_rol);
        
        INSERT INTO Usuario (usuarioCodigo, documentoUsuario, usuarioContra)
        VALUES (p_usuarioCodigo, p_documento, p_usuarioContra);
        
        COMMIT;
    ELSE
        -- Si el documento existe en PerfilUsuario o en Usuario, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario ya existe.';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUsuarioCrearPersonalMedico` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUsuarioCrearPersonalMedico`(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_numLicenciaMedica INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_rol ENUM('M', 'E'),
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255)
)
BEGIN
    DECLARE perfil_doc_exist INT;
    DECLARE cuenta_doc_exist INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el documento ya existe en PerfilUsuario
    SELECT COUNT(*) INTO perfil_doc_exist FROM PerfilUsuario WHERE documento = p_documento;
    
    -- Verificar si el documento ya existe en Usuario
    SELECT COUNT(*) INTO cuenta_doc_exist FROM Usuario WHERE documentoUsuario = p_documento;

    -- Si el documento no existe en PerfilUsuario ni en Usuario, insertarlo
    IF perfil_doc_exist = 0 AND cuenta_doc_exist = 0 THEN
        INSERT INTO PerfilUsuario (documento, tipoDocumento, numLicenciaMedica, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol)
        VALUES (p_documento, p_tipoDocumento, p_numLicenciaMedica, p_nombre, p_apellido, p_genero, p_fechaNacimiento, p_telefono, p_correo, p_direccion, p_rol);
        
        INSERT INTO Usuario (usuarioCodigo, documentoUsuario, usuarioContra)
        VALUES (p_usuarioCodigo, p_documento, p_usuarioContra);
        
        COMMIT;
    ELSE
        -- Si el documento existe en PerfilUsuario o en Usuario, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario ya existe.';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUsuarioEliminar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUsuarioEliminar`(
    IN p_documentoOUsuarioCodigo VARCHAR(30)
)
BEGIN
    DECLARE esUsuarioCodigo INT;
    DECLARE documento VARCHAR(30);

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el parámetro es un código de usuario o un documento
    SELECT COUNT(*) INTO esUsuarioCodigo FROM Usuario WHERE usuarioCodigo = p_documentoOUsuarioCodigo;

    IF esUsuarioCodigo > 0 THEN
        -- Obtener el documento del usuario a partir del código de usuario
        SELECT documentoUsuario INTO documento FROM Usuario WHERE usuarioCodigo = p_documentoOUsuarioCodigo;
        -- Eliminar usuario por código de usuario y su perfil asociado
        DELETE FROM PerfilUsuario WHERE documento = documento;
    ELSE
        -- Eliminar usuario por documento y su perfil asociado
        DELETE FROM PerfilUsuario WHERE documento = p_documentoOUsuarioCodigo;
    END IF;

    COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUsuarioListar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUsuarioListar`(
    IN p_usuarioCodigo VARCHAR(30),
    IN p_documento VARCHAR(30),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_rol ENUM('P', 'A', 'M', 'E', 'C')
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_usuarioCodigo IS NULL AND p_documento IS NULL AND p_genero IS NULL AND p_fechaNacimiento IS NULL AND p_rol IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todos los usuarios con sus datos asociados
        SELECT U.usuarioCodigo, U.usuarioContra, P.*
        FROM Usuario U
        JOIN PerfilUsuario P ON U.documentoUsuario = P.documento;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT U.usuarioCodigo, U.usuarioContra, P.* FROM Usuario U JOIN PerfilUsuario P ON U.documentoUsuario = P.documento WHERE 1 = 1';

        IF p_usuarioCodigo IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND U.usuarioCodigo = "', p_usuarioCodigo, '"');
        END IF;
        
        IF p_documento IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND P.documento = "', p_documento, '"');
        END IF;
        
        IF p_genero IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND P.genero = "', p_genero, '"');
        END IF;
        
        IF p_fechaNacimiento IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND P.fechaNacimiento = "', p_fechaNacimiento, '"');
        END IF;
        
        IF p_rol IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND P.rol = "', p_rol, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-19 19:25:53
