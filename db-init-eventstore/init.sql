/*
Navicat MySQL Data Transfer

Source Server         : Docker EventStore
Source Server Version : 50717
Source Host           : localhost:3360
Source Database       : eventstore

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2019-09-03 11:49:43
*/
USE eventstore;
SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for accounts_event
-- ----------------------------
DROP TABLE IF EXISTS `accounts_event`;
CREATE TABLE `accounts_event` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Version` int(255) NOT NULL,
  `TimeStamp` double NOT NULL,
  `Payload` json NOT NULL,
  `ContentType` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for accounts_snapshot
-- ----------------------------
DROP TABLE IF EXISTS `accounts_snapshot`;
CREATE TABLE `accounts_snapshot` (
  `MessageId` int(11) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Version` int(255) NOT NULL,
  `Payload` json NOT NULL,
  `ContentType` varchar(255) NOT NULL,
  PRIMARY KEY (`MessageId`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for clients_event
-- ----------------------------
DROP TABLE IF EXISTS `clients_event`;
CREATE TABLE `clients_event` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Version` int(255) NOT NULL,
  `TimeStamp` double NOT NULL,
  `Payload` json NOT NULL,
  `ContentType` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for clients_snapshot
-- ----------------------------
DROP TABLE IF EXISTS `clients_snapshot`;
CREATE TABLE `clients_snapshot` (
  `MessageId` int(11) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Version` int(255) NOT NULL,
  `Payload` json NOT NULL,
  `ContentType` varchar(255) NOT NULL,
  PRIMARY KEY (`MessageId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for integrationEventLog
-- ----------------------------
DROP TABLE IF EXISTS `integrationEventLog`;
CREATE TABLE `integrationEventLog` (
  `Id` char(36) NOT NULL,
  `CorrelationId` char(36) NOT NULL,
  `TimeStamp` double NOT NULL,
  `Payload` json NOT NULL,
  `ContentType` varchar(255) NOT NULL,
  `State` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for products_event
-- ----------------------------
DROP TABLE IF EXISTS `products_event`;
CREATE TABLE `products_event` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Version` int(255) NOT NULL,
  `TimeStamp` double NOT NULL,
  `Payload` json NOT NULL,
  `ContentType` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for products_snapshot
-- ----------------------------
DROP TABLE IF EXISTS `products_snapshot`;
CREATE TABLE `products_snapshot` (
  `MessageId` int(11) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Version` int(255) NOT NULL,
  `Payload` json NOT NULL,
  `ContentType` varchar(255) NOT NULL,
  PRIMARY KEY (`MessageId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
SET FOREIGN_KEY_CHECKS=1;
