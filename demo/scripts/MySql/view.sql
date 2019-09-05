/*
Navicat MySQL Data Transfer

Source Server         : Docker View
Source Server Version : 50717
Source Host           : localhost:3366
Source Database       : view

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2019-09-05 08:26:08
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for accounts
-- ----------------------------
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `Id` int(255) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Number` char(20) NOT NULL,
  `ClientId` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_clientId` (`ClientId`),
  KEY `fk_productId` (`ProductId`),
  CONSTRAINT `fk_clientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_productId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for accounts.version
-- ----------------------------
DROP TABLE IF EXISTS `accounts.version`;
CREATE TABLE `accounts.version` (
  `AggregateId` char(36) NOT NULL,
  `Version` int(11) NOT NULL,
  `TimeStamp` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for clients
-- ----------------------------
DROP TABLE IF EXISTS `clients`;
CREATE TABLE `clients` (
  `Id` int(255) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`),
  FULLTEXT KEY `search` (`Name`,`LastName`,`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for clients.version
-- ----------------------------
DROP TABLE IF EXISTS `clients.version`;
CREATE TABLE `clients.version` (
  `AggregateId` char(36) NOT NULL,
  `Version` int(11) NOT NULL,
  `TimeStamp` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for operations
-- ----------------------------
DROP TABLE IF EXISTS `operations`;
CREATE TABLE `operations` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Amount` double(255,0) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `AccountId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_accountId` (`AccountId`),
  CONSTRAINT `fk_accountId` FOREIGN KEY (`AccountId`) REFERENCES `accounts` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for products
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products` (
  `Id` int(255) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `ProductType` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for products.version
-- ----------------------------
DROP TABLE IF EXISTS `products.version`;
CREATE TABLE `products.version` (
  `AggregateId` char(36) NOT NULL,
  `Version` int(11) NOT NULL,
  `TimeStamp` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- View structure for view.accounts
-- ----------------------------
DROP VIEW IF EXISTS `view.accounts`;
CREATE ALGORITHM=UNDEFINED DEFINER=`dbuser`@`%` SQL SECURITY DEFINER VIEW `view.accounts` AS select `accounts`.`AggregateId` AS `AggregateId`,`accounts`.`Number` AS `number`,`products`.`AggregateId` AS `product.AggregateId`,`products`.`Name` AS `product.name`,`clients`.`AggregateId` AS `client.AggregateId`,`clients`.`Name` AS `client.name`,`clients`.`LastName` AS `client.lastName`,`clients`.`Email` AS `client.email`,`accounts`.`Id` AS `Id` from ((`accounts` join `clients` on((`accounts`.`ClientId` = `clients`.`Id`))) join `products` on((`accounts`.`ProductId` = `products`.`Id`))) ;

-- ----------------------------
-- View structure for view.operations
-- ----------------------------
DROP VIEW IF EXISTS `view.operations`;
CREATE ALGORITHM=UNDEFINED DEFINER=`dbuser`@`%` SQL SECURITY DEFINER VIEW `view.operations` AS select `operations`.`Date` AS `Date`,`operations`.`Amount` AS `Amount`,`operations`.`Description` AS `Description`,`operations`.`AccountId` AS `AccountId` from `operations` ;
SET FOREIGN_KEY_CHECKS=1;
