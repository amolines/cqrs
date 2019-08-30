/*
Navicat MySQL Data Transfer

Source Server         : Docker View
Source Server Version : 50717
Source Host           : localhost:3366
Source Database       : view

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2019-08-26 10:26:07
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for account
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account` (
  `Id` int(255) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Version` int(11) NOT NULL,
  `TimeStamp` double NOT NULL,
  `Number` char(20) NOT NULL,
  `ClientId` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_clientId` (`ClientId`),
  KEY `fk_productId` (`ProductId`),
  CONSTRAINT `fk_clientId` FOREIGN KEY (`ClientId`) REFERENCES `client` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_productId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for client
-- ----------------------------
DROP TABLE IF EXISTS `client`;
CREATE TABLE `client` (
  `Id` int(255) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Version` int(11) NOT NULL,
  `TimeStamp` double NOT NULL,
  `Name` varchar(255) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`),
  FULLTEXT KEY `search` (`Name`,`LastName`,`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for operation
-- ----------------------------
DROP TABLE IF EXISTS `operation`;
CREATE TABLE `operation` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Amount` double(255,0) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `AccountId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_accountId` (`AccountId`),
  CONSTRAINT `fk_accountId` FOREIGN KEY (`AccountId`) REFERENCES `account` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
  `Id` int(255) NOT NULL AUTO_INCREMENT,
  `AggregateId` char(36) NOT NULL,
  `Version` int(11) NOT NULL,
  `TimeStamp` double NOT NULL,
  `Name` varchar(255) NOT NULL,
  `ProductType` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- ----------------------------
-- View structure for query.account
-- ----------------------------
DROP VIEW IF EXISTS `query.account`;
CREATE ALGORITHM=UNDEFINED DEFINER=`dbuser`@`%` SQL SECURITY DEFINER VIEW `query.account` AS select `account`.`AggregateId` AS `AggregateId`,`account`.`Number` AS `number`,`product`.`AggregateId` AS `product.AggregateId`,`product`.`Name` AS `product.name`,`client`.`AggregateId` AS `client.AggregateId`,`client`.`Name` AS `client.name`,`client`.`LastName` AS `client.lastName`,`client`.`Email` AS `client.email`,`account`.`Id` AS `Id` from ((`account` join `client` on((`account`.`ClientId` = `client`.`Id`))) join `product` on((`account`.`ProductId` = `product`.`Id`))) ;

-- ----------------------------
-- View structure for query.operation
-- ----------------------------
DROP VIEW IF EXISTS `query.operation`;
CREATE ALGORITHM=UNDEFINED DEFINER=`dbuser`@`%` SQL SECURITY DEFINER VIEW `query.operation` AS select `operation`.`Date` AS `Date`,`operation`.`Amount` AS `Amount`,`operation`.`Description` AS `Description`,`operation`.`AccountId` AS `AccountId` from `operation` ;
SET FOREIGN_KEY_CHECKS=1;
