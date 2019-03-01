#
# DUMP FILE
#
# Database is ported from MS Access
#------------------------------------------------------------------
# Created using "MS Access to MySQL" form http://www.bullzip.com
# Program Version 5.5.282
#
# OPTIONS:
#   sourcefilename=E:/USERS/GIANGNT/GIT/MY WORK/ParkingManagement/ParkingMangement/bin/Debug/ParkingManagement/ParkingManagement.mdb
#   sourceusername=
#   sourcepassword=
#   sourcesystemdatabase=
#   destinationdatabase=movedb
#   storageengine=MyISAM
#   dropdatabase=0
#   createtables=1
#   unicode=1
#   autocommit=1
#   transferdefaultvalues=1
#   transferindexes=1
#   transferautonumbers=1
#   transferrecords=1
#   columnlist=1
#   tableprefix=
#   negativeboolean=0
#   ignorelargeblobs=0
#   memotype=LONGTEXT
#   datetimetype=DATETIME
#

CREATE DATABASE IF NOT EXISTS `movedb`;
USE `movedb`;

#
# Table structure for table 'BlackCar'
#

DROP TABLE IF EXISTS `BlackCar`;

CREATE TABLE `BlackCar` (
  `Identify` INTEGER NOT NULL AUTO_INCREMENT, 
  `Digit` VARCHAR(255), 
  PRIMARY KEY (`Identify`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'BlackCar'
#

INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (1, '71B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (2, '72B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (3, '73B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (4, '74B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (5, '75B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (6, '76B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (7, '77B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (8, '78B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (9, '79B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (10, '80B6-98765');
INSERT INTO `BlackCar` (`Identify`, `Digit`) VALUES (12, '111');
# 11 records

#
# Table structure for table 'Car'
#

DROP TABLE IF EXISTS `Car`;

CREATE TABLE `Car` (
  `Identify` INTEGER NOT NULL AUTO_INCREMENT, 
  `ID` VARCHAR(255), 
  `TimeStart` DATETIME, 
  `TimeEnd` DATETIME, 
  `Digit` VARCHAR(255), 
  `IDIn` VARCHAR(255), 
  `IDOut` VARCHAR(255), 
  `Cost` INTEGER DEFAULT 0, 
  `Part` VARCHAR(255), 
  `Seri` INTEGER DEFAULT 0, 
  `IDTicketMonth` VARCHAR(255), 
  `IDPart` VARCHAR(255), 
  `Images` LONGTEXT, 
  `Images2` LONGTEXT, 
  `Images3` LONGTEXT, 
  `Images4` LONGTEXT, 
  `IsLostCard` INTEGER DEFAULT 0, 
  `Computer` VARCHAR(255), 
  `Note` LONGTEXT, 
  `Account` VARCHAR(255), 
  `CostBefore` INTEGER DEFAULT 0, 
  `DateUpdate` DATETIME, 
  `DateLostCard` DATETIME, 
  INDEX (`IDIn`), 
  INDEX (`ID`), 
  INDEX (`IDOut`), 
  INDEX (`IDPart`), 
  INDEX (`IDTicketMonth`), 
  PRIMARY KEY (`Identify`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'Car'
#

INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (18, '112', '2018-02-08 00:00:00', '2018-02-12 00:00:00', '62H37132', '2', '3', 0, NULL, 1, '112', '2', 'image1.jpg', 'image3.jpg', 'image4.jpg', 'image2.jpg', 1, 'TRUONGGIANG', NULL, '3', 200, '2018-02-03 00:00:00', '2018-03-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (19, '113', '2018-02-05 00:00:00', '2018-02-05 00:00:00', '63H37132', '1', '3', 0, NULL, 1, '113', '2', 'image3.jpg', 'image1.jpg', 'image2.jpg', 'image4.jpg', 1, 'TRUONGGIANG', NULL, '3', 200, '2018-02-03 00:00:00', '2018-03-12 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (20, '114', '2018-02-03 00:00:00', '2018-02-16 00:00:00', '63H37132', '1', '3', 0, NULL, 1, '114', '4', 'image3.jpg', 'image2.jpg', 'image4.jpg', 'image1.jpg', 1, 'TRUONGGIANG', NULL, '3', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (21, '115', '2018-02-03 00:00:00', '2018-02-03 04:00:00', '63H37132', '1', '1', 0, NULL, 1, '115', '4', 'image4.jpg', 'image2.jpg', 'image1.jpg', 'image3.jpg', 1, 'TRUONGGIANG', NULL, '1', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (22, '116', '2018-02-03 00:00:00', '2018-02-03 03:00:00', '63H37132', '1', '1', 0, NULL, 1, '116', '6', 'image3.jpg', 'image4.jpg', 'image1.jpg', 'image2.jpg', 0, 'TRUONGGIANG', NULL, '1', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (23, '117', '2018-02-03 00:00:00', '2018-02-03 01:00:00', '63H37132', '1', '2', 3000, NULL, 1, NULL, '6', 'image2.jpg', 'image1.jpg', 'image3.jpg', 'image4.jpg', 0, 'TRUONGGIANG', NULL, '2', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (24, '118', '2018-02-03 00:00:00', '2018-02-03 07:00:00', '63H37132', '1', '2', 5000, NULL, 1, NULL, '7', 'image1.jpg', 'image3.jpg', 'image2.jpg', 'image4.jpg', 0, 'TRUONGGIANG', NULL, '2', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (25, '118', '2018-02-03 00:00:00', '2018-02-03 09:00:00', '63H37132', '1', '3', 5000, NULL, 1, NULL, '8', 'image1.jpg', 'image3.jpg', 'image2.jpg', 'image4.jpg', 0, 'TRUONGGIANG', NULL, '2', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (26, '116', '2018-02-03 00:00:00', '2018-02-03 08:00:00', '63H37132', '3', '1', 4000, NULL, 1, NULL, '1', 'image3.jpg', 'image4.jpg', 'image1.jpg', 'image2.jpg', 0, 'TRUONGGIANG', NULL, '1', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (27, '117', '2018-02-03 00:00:00', '2018-02-03 09:00:00', '63H37132', '2', '3', 3000, NULL, 1, NULL, '1', 'image2.jpg', 'image1.jpg', 'image3.jpg', 'image4.jpg', 0, 'TRUONGGIANG', NULL, '2', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (28, '118', '2018-02-03 00:00:00', '2018-02-03 09:00:00', '63H37132', '1', '2', 5000, NULL, 1, NULL, '2', 'image1.jpg', 'image3.jpg', 'image2.jpg', 'image4.jpg', 0, 'TRUONGGIANG', NULL, '2', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (29, '118', '2018-02-03 00:00:00', '2018-02-03 09:00:00', '63H37132', '1', '2', 5000, NULL, 1, NULL, '3', 'image1.jpg', 'image3.jpg', 'image2.jpg', 'image4.jpg', 0, 'TRUONGGIANG', NULL, '2', 200, '2018-02-03 00:00:00', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (30, '111', '2018-04-16 16:57:24', '2001-01-01 00:00:00', '', '6', '6', 0, NULL, 0, NULL, '4', '636594946449249661.jpg', '636594946448693807.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-16 16:57:24', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (31, '111', '2018-04-16 16:57:28', '2018-04-17 10:30:15', '', '6', '6', 5000, NULL, 0, NULL, '3', '636594946484862958.jpg', '636594946483827022.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 10:30:15', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (32, '111', '2018-04-17 10:30:17', '2018-04-17 10:46:42', '', '6', '6', 5000, NULL, 0, NULL, '4', '636595578173434799.jpg', '636595578171977240.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 10:46:42', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (33, '111', '2018-04-17 10:48:08', '2018-04-17 10:48:47', '', '6', '6', 5000, NULL, 0, NULL, '5', '636595588885549409.jpg', '636595588885019086.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 10:48:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (34, '111', '2018-04-17 11:00:55', '2018-04-17 11:01:03', '', '6', '6', 5000, NULL, 0, NULL, '6', '636595596555827864.jpg', '636595596552451360.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 11:01:03', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (283, '3118189600', '2018-09-22 16:22:06', '2018-09-22 17:16:35', '', '6', '6', 0, NULL, 0, '3118189600', '3', '636732301267908198.jpg', '636732301268757659.jpg', '636732333953770612.jpg', '636732333953930522.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-22 17:16:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (284, '3118189600', '2018-09-22 17:16:36', '2018-09-22 17:16:38', '', '6', '6', 0, NULL, 0, '3118189600', '4', '636732333967992117.jpg', '636732333968162008.jpg', '636732333982044531.jpg', '636732333982214426.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-22 17:16:38', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (285, '3118189600', '2018-09-22 17:16:48', '2018-09-22 17:16:49', '', '6', '6', 0, NULL, 0, '3118189600', '5', '636732334084625542.jpg', '636732334084785443.jpg', '636732334096009075.jpg', '636732334096168981.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-22 17:16:49', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (286, '3118189600', '2018-09-23 08:49:57', '2018-09-23 08:50:07', '', '6', '6', 0, NULL, 0, '3118189600', '6', '636732893973203710.jpg', '636732893973983236.jpg', '636732894075846608.jpg', '636732894076186509.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-23 08:50:07', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (287, '3118189600', '2018-09-23 08:50:08', '2018-09-23 08:50:16', '', '6', '6', 0, NULL, 0, '3118189600', '7', '636732894087791959.jpg', '636732894088301638.jpg', '636732894166035926.jpg', '636732894166875697.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-23 08:50:16', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (288, '3118189600', '2018-09-23 08:50:28', '2018-09-23 08:50:29', '', '6', '6', 0, NULL, 0, '3118189600', '8', '636732894280248092.jpg', '636732894280707794.jpg', '636732894296396961.jpg', '636732894296566911.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-23 08:50:29', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (289, '3118189600', '2018-09-25 14:14:01', '2018-09-25 14:18:03', '', '6', '6', 0, NULL, 0, '3118189600', '8', '636734816414222963.jpg', '636734816415324273.jpg', '636734818836380835.jpg', '636734818836862258.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-25 14:18:03', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (290, '3118244928', '2018-09-25 14:18:33', '2018-09-25 14:18:53', '', '6', '6', 2000, NULL, 0, '', '7', '636734819137826171.jpg', '636734819138647016.jpg', '636734819341528707.jpg', '636734819342188019.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-25 14:18:54', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (291, '3118189600', '2018-09-25 14:18:37', '2018-09-25 14:18:58', '', '6', '6', 0, NULL, 0, '3118189600', '6', '636734819176839336.jpg', '636734819178433885.jpg', '636734819384029866.jpg', '636734819384531397.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-25 14:18:58', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (294, '3118244928', '2018-09-25 15:28:34', '2018-09-25 15:31:56', '', '6', '1', 0, NULL, 0, '', '4', '636734861144514548.jpg', '636734861145382624.jpg', '', '', 100000, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-25 15:31:56', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (295, '3118189600', '2018-09-25 15:28:40', '2018-09-26 20:31:01', '', '6', '6', 0, NULL, 0, '3118189600', '5', '636734861199725071.jpg', '636734861200654142.jpg', '636735906616375609.jpg', '636735906617025151.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-26 20:31:01', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (35, '111', '2018-04-17 11:01:42', '2018-04-17 11:04:21', '', '6', '6', 5000, NULL, 0, NULL, '7', '636595597023230549.jpg', '636595597019915876.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 11:04:21', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (36, '112', '2018-04-17 11:06:39', '2018-04-17 11:06:59', '', '6', '6', 5000, NULL, 0, NULL, '8', '636595599725897306.jpg', '636595599725110000.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 11:06:59', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (37, '112', '2018-04-17 11:07:16', '2018-04-17 11:08:16', '', '6', '', 5000, NULL, 0, NULL, '8', '636595600361301233.jpg', '636595600358088789.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 11:08:16', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (38, '111', '2018-04-17 11:07:29', '2018-04-17 13:24:26', '', '6', '', 5000, NULL, 0, NULL, '7', '636595600493703078.jpg', '636595600490724247.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:24:26', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (39, '112', '2018-04-17 13:21:37', '2018-04-17 13:21:42', '', '6', '6', 5000, NULL, 0, '', '6', '636595680976997823.jpg', '636595680976647707.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:21:42', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (40, '111', '2018-04-17 13:24:36', '2018-04-17 13:24:38', '', '6', '6', 5000, NULL, 0, '', '4', '636595682769412283.jpg', '636595682767350439.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:24:38', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (41, '111', '2018-04-17 13:24:43', '2018-04-17 13:24:49', '', '6', '6', 5000, NULL, 0, '', '5', '636595682830954700.jpg', '636595682830769547.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:24:49', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (42, '112', '2018-04-17 13:24:45', '2018-04-17 13:24:47', '', '6', '6', 5000, NULL, 0, '', '1', '636595682859357176.jpg', '636595682857414758.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:24:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (43, '111', '2018-04-17 13:24:51', '2018-04-17 13:28:50', '', '6', '6', 5000, NULL, 0, '', '2', '636595682911716932.jpg', '636595682910491050.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:28:50', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (44, '112', '2018-04-17 13:24:58', '2018-04-17 13:24:59', '', '6', '6', 5000, NULL, 0, '', '3', '636595682982808837.jpg', '636595682980713085.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:24:59', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (45, '112', '2018-04-17 13:31:49', '2018-04-17 13:31:50', '', '6', '6', 5000, NULL, 0, '', '4', '636595687095719846.jpg', '636595687092809676.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:31:50', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (46, '111', '2018-04-17 13:34:21', '2018-04-17 13:37:53', '', '6', '6', 5000, NULL, 0, '', '5', '636595688616911981.jpg', '636595688613443257.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:37:53', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (47, '112', '2018-04-17 13:34:23', '2018-04-17 13:34:23', '', '6', '6', 5000, NULL, 0, '', '6', '636595688629546037.jpg', '636595688627767490.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:34:23', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (48, '112', '2018-04-17 13:35:26', '2018-04-17 13:35:28', '', '6', '6', 5000, NULL, 0, '', '7', '636595689266864264.jpg', '636595689253098998.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:35:28', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (49, '112', '2018-04-17 13:37:52', '2018-04-17 13:38:28', '', '6', '6', 5000, NULL, 0, '', '8', '636595690724510136.jpg', '636595690723239079.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:38:28', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (50, '112', '2018-04-17 13:38:30', '2018-04-17 13:38:32', '', '6', '6', 5000, NULL, 0, '', '1', '636595691106429344.jpg', '636595691105404128.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:38:32', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (51, '112', '2018-04-17 13:38:35', '2018-04-17 13:38:39', '', '6', '6', 5000, NULL, 0, '', '1', '636595691151683956.jpg', '636595691149801791.jpg', '', '', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 13:38:39', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (52, '112', '2018-04-17 14:02:42', '2018-04-17 15:40:32', '', '6', '6', 5000, NULL, 0, '', '2', '636595705621010063.jpg', '636595705620656477.jpg', '636595764328186794.jpg', '636595764328296822.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 15:40:32', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (53, '111', '2018-04-17 14:02:44', '2018-04-17 15:40:41', '', '6', '6', 5000, NULL, 0, '', '3', '636595705641866853.jpg', '636595705640397265.jpg', '636595764412722134.jpg', '636595764412802158.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 15:40:41', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (54, '112', '2018-04-17 15:40:48', '2018-04-17 15:40:51', '', '6', '6', 5000, NULL, 0, '', '4', '636595764482301942.jpg', '636595764481766564.jpg', '636595764511313695.jpg', '636595764512066619.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 15:40:51', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (55, '111', '2018-04-17 15:40:50', '2018-04-17 15:40:50', '', '6', '6', 5000, NULL, 0, '', '3', '636595764482301942.jpg', '636595764503122784.jpg', '636595764508240147.jpg', '636595764508310069.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 15:40:50', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (56, '112', '2018-04-17 15:42:21', '2018-04-17 15:42:36', '', '6', '6', 5000, NULL, 0, '', '4', '636595765410735639.jpg', '636595765408841828.jpg', '636595765565324635.jpg', '636595765565404656.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 15:42:36', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (57, '112', '2018-04-17 15:52:04', '2018-04-17 15:52:20', '', '6', '6', 5000, NULL, 0, '', '5', '636595771243713788.jpg', '636595771242127963.jpg', '636595771403152786.jpg', '636595771403242678.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 15:52:20', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (58, '111', '2018-04-17 15:52:19', '2018-04-17 15:52:20', '', '6', '6', 5000, NULL, 0, '', '6', '636595771397863772.jpg', '636595771396103639.jpg', '636595771407649300.jpg', '636595771407729141.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 15:52:20', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (59, '111', '2018-04-17 16:14:05', '2018-04-17 16:14:09', '', '6', '6', 5000, NULL, 0, '', '7', '', '', '636595784499613314.jpg', '636595784499693447.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 16:14:09', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (60, '112', '2018-04-17 16:15:55', '2018-04-17 16:16:10', '', '6', '6', 5000, NULL, 0, '', '8', '', '', '636595785706666569.jpg', '636595785706796769.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 16:16:10', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (61, '111', '2018-04-17 16:18:23', '2018-04-17 16:18:25', '', '6', '6', 5000, NULL, 0, '', '8', '636595787034533237.jpg', '636595787028432888.jpg', '636595787058438825.jpg', '636595787058528851.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 16:18:25', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (62, '111', '2018-04-17 16:18:31', '2018-04-17 16:18:36', '', '6', '6', 5000, NULL, 0, '', '7', '636595787112934849.jpg', '636595787110400658.jpg', '636595787160220023.jpg', '636595787160300037.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 16:18:36', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (63, '111', '2018-04-17 16:18:38', '2018-04-17 16:24:32', '', '6', '6', 5000, NULL, 0, '', '6', '636595787186986664.jpg', '636595787184775454.jpg', '636595790727051361.jpg', '636595790727146328.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-04-17 16:24:32', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (64, '111', '2018-04-17 16:24:36', '2018-07-08 14:32:57', '', '6', '6', 5000, NULL, 0, '', '4', '636595790758489891.jpg', '636595790762824574.jpg', '636666571774104634.jpg', '636666571774274551.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-07-08 14:32:57', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (65, '112', '2018-07-08 14:11:38', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '5', '636666558982455433.jpg', '', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:11:38', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (66, '115', '2018-07-08 14:35:36', '2018-07-08 14:35:36', '', '6', '6', 5000, NULL, 0, '', '1', '636666573361695739.jpg', '', '636666573364785793.jpg', '636666573364955705.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:35:36', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (67, '115', '2018-07-08 14:36:44', '2018-07-08 14:36:44', '', '6', '6', 5000, NULL, 0, '', '2', '636666574042405040.jpg', '', '636666574045313534.jpg', '636666574045483437.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:36:44', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (68, '117', '2018-07-08 14:37:38', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '3', '636666574494067498.jpg', '', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:37:38', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (69, '116', '2018-07-08 14:40:00', '2018-07-08 14:40:06', '', '6', '6', 5000, NULL, 0, '', '4', '636666575947489988.jpg', '', '636666576068880547.jpg', '636666576069050442.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:40:06', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (70, '119', '2018-07-08 14:41:18', '2018-07-08 14:41:18', '', '6', '6', 5000, NULL, 0, '', '5', '636666576780945401.jpg', '', '636666576783903889.jpg', '636666576784073763.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:41:18', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (71, '121', '2018-07-08 14:42:10', '2018-07-08 14:52:59', '', '6', '6', 5000, NULL, 0, '', '6', '636666577236265257.jpg', '', '636666583792167074.jpg', '636666583792336965.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:52:59', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (72, '119', '2018-07-08 14:43:52', '2018-07-08 14:43:52', '', '6', '6', 5000, NULL, 0, '', '7', '636666578321788865.jpg', '', '636666578324707309.jpg', '636666578324877363.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:43:52', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (73, '120', '2018-07-08 14:44:44', '2018-07-08 14:44:51', '', '6', '6', 5000, NULL, 0, '', '8', '636666578687280754.jpg', '', '636666578918093044.jpg', '636666578918902549.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:44:51', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (74, '119', '2018-07-08 14:47:45', '2018-07-08 15:09:07', '', '6', '6', 5000, NULL, 0, '', '1', '636666580589858181.jpg', '', '636666593472573828.jpg', '636666593472753820.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 15:09:07', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (75, '120', '2018-07-08 14:49:44', '2018-07-08 14:49:47', '', '6', '6', 5000, NULL, 0, '', '1', '636666581845359808.jpg', '636666581845979422.jpg', '636666581878202617.jpg', '636666581878372503.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:49:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (76, '121', '2018-07-08 14:54:06', '2018-07-08 14:54:12', '', '6', '6', 5000, NULL, 0, '', '2', '636666584465633986.jpg', '636666584466263581.jpg', '636666584530104157.jpg', '636666584530284055.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:54:13', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (77, '121', '2018-07-08 14:54:16', '2018-07-08 14:54:18', '', '6', '6', 5000, NULL, 0, '', '3', '636666584559442738.jpg', '636666584559952411.jpg', '636666584584005102.jpg', '636666584584165384.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:54:18', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (78, '121', '2018-07-08 14:54:21', '2018-07-08 14:54:23', '', '6', '6', 5000, NULL, 0, '', '4', '636666584611177607.jpg', '636666584611727272.jpg', '636666584638197250.jpg', '636666584638367119.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:54:23', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (79, '121', '2018-07-08 14:54:25', '2018-07-08 14:54:29', '', '6', '6', 5000, NULL, 0, '', '3', '636666584653985820.jpg', '636666584654475732.jpg', '636666584694763937.jpg', '636666584695603415.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:54:29', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (80, '121', '2018-07-08 14:54:31', '2018-07-08 14:54:40', '', '6', '6', 5000, NULL, 0, '', '4', '636666584712217449.jpg', '636666584712716243.jpg', '636666584806718418.jpg', '636666584806878307.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:54:40', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (81, '121', '2018-07-08 14:54:43', '2018-07-08 14:54:44', '', '6', '6', 5000, NULL, 0, '', '5', '636666584834403222.jpg', '636666584834882922.jpg', '636666584848716215.jpg', '636666584848876108.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:54:44', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (82, '120', '2018-07-08 14:59:04', '2018-07-08 14:59:06', '', '6', '6', 5000, NULL, 0, '', '6', '636666587448352704.jpg', '636666587448962306.jpg', '636666587466833559.jpg', '636666587467003463.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:59:06', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (83, '120', '2018-07-08 14:59:07', '2018-07-08 14:59:08', '', '6', '6', 5000, NULL, 0, '', '7', '636666587477912239.jpg', '636666587478395510.jpg', '636666587487570323.jpg', '636666587487730229.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 14:59:08', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (84, '120', '2018-07-08 15:05:20', '2018-07-08 15:05:22', '', '6', '6', 5000, NULL, 0, '', '8', '636666591204763526.jpg', '636666591205313179.jpg', '636666591222951028.jpg', '636666591223614940.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 15:05:22', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (85, '120', '2018-07-08 15:11:24', '2018-07-08 15:11:25', '', '6', '6', 5000, NULL, 0, '', '8', '636666594841902257.jpg', '636666594842441924.jpg', '636666594854091895.jpg', '636666594854244813.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 15:11:25', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (86, '120', '2018-07-08 15:11:30', '2018-07-08 15:11:31', '', '6', '6', 5000, NULL, 0, '', '7', '636666594900493438.jpg', '636666594901033105.jpg', '636666594914322972.jpg', '636666594914492876.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-08 15:11:31', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (87, '119', '2018-07-15 12:24:54', '2018-07-15 12:25:02', '', '6', '6', 5000, NULL, 0, '', '6', '636672542947597735.jpg', '636672542948547137.jpg', '636672543024279751.jpg', '636672543024449642.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:25:02', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (88, '119', '2018-07-15 12:25:03', '2018-07-15 12:25:04', '', '6', '6', 5000, NULL, 0, '', '4', '636672543037048357.jpg', '636672543037538418.jpg', '636672543043855785.jpg', '636672543044018458.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:25:04', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (89, '119', '2018-07-15 12:25:04', '2018-07-15 12:25:05', '', '6', '6', 5000, NULL, 0, '', '5', '636672543047786481.jpg', '636672543048536023.jpg', '636672543055566797.jpg', '636672543055740199.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:25:05', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (90, '120', '2018-07-15 12:26:14', '2018-07-15 12:57:49', '', '6', '6', 5000, NULL, 0, '', '1', '636672543745314479.jpg', '636672543746653636.jpg', '636672562698693354.jpg', '636672562698863258.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:57:49', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (91, '121', '2018-07-15 12:28:31', '2018-07-15 12:43:54', '', '6', '6', 5000, NULL, 0, '', '2', '636672545109455802.jpg', '636672545113894285.jpg', '636672554346078018.jpg', '636672554346427785.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:43:54', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (92, '121', '2018-07-15 12:44:03', '2018-07-15 12:44:05', '', '6', '6', 5000, NULL, 0, '', '3', '636672554435011748.jpg', '636672554435991139.jpg', '636672554451507024.jpg', '636672554451656936.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:44:05', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (93, '121', '2018-07-15 12:44:07', '2018-07-15 12:44:09', '', '6', '6', 5000, NULL, 0, '', '4', '636672554472318496.jpg', '636672554472838124.jpg', '636672554493848118.jpg', '636672554494008015.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:44:09', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (94, '121', '2018-07-15 12:44:11', '2018-07-15 12:44:12', '', '6', '6', 5000, NULL, 0, '', '5', '636672554513532715.jpg', '636672554514192313.jpg', '636672554520766364.jpg', '636672554520926265.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:44:12', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (95, '121', '2018-07-15 12:44:12', '2018-07-15 12:44:13', '', '6', '6', 5000, NULL, 0, '', '6', '636672554524385869.jpg', '636672554524945515.jpg', '636672554532195354.jpg', '636672554532325330.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:44:13', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (96, '121', '2018-07-15 12:44:13', '2018-07-15 12:44:14', '', '6', '6', 5000, NULL, 0, '', '7', '636672554536882656.jpg', '636672554537392329.jpg', '636672554544357876.jpg', '636672554544547746.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:44:14', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (97, '121', '2018-07-15 12:44:43', NULL, '', '6', '6', 5000, NULL, 0, '', '8', '636672554835967136.jpg', '636672554836926536.jpg', '636672576145452486.jpg', '636672576145612400.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:20:14', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (98, '119', '2018-07-15 12:46:53', '2018-07-15 12:47:00', '', '6', '6', 5000, NULL, 0, '', '1', '636672556135090356.jpg', '636672556135709982.jpg', '636672556208996103.jpg', '636672556209165985.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:47:00', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (99, '120', '2018-07-15 12:57:53', NULL, '', '6', '', 0, NULL, 0, '', '1', '636672562734899404.jpg', '636672562736319734.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 12:57:53', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (100, '119', '2018-07-15 13:09:58', '2018-07-15 13:10:06', '', '6', '6', 5000, NULL, 0, '', '2', '636672569978686333.jpg', '636672569984968300.jpg', '636672570063208367.jpg', '636672570063378241.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:10:06', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (101, '119', '2018-07-15 13:10:08', '2018-07-15 13:10:25', '', '6', '6', 5000, NULL, 0, '', '3', '636672570087526744.jpg', '636672570088046410.jpg', '636672570255817806.jpg', '636672570255977707.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:10:25', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (102, '119', '2018-07-15 13:10:30', NULL, '', '6', '', 0, NULL, 0, '', '4', '636672570309083041.jpg', '636672570309572722.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:10:31', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (103, '121', '2018-07-15 13:20:22', '2018-07-15 13:20:36', '', '6', '6', 5000, NULL, 0, '', '3', '636672576223318816.jpg', '636672576223818512.jpg', '636672576369505558.jpg', '636672576369675462.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:20:37', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (104, '3118189600', '2018-07-15 13:21:57', '2018-07-15 13:22:14', '', '6', '6', 5000, NULL, 0, '', '4', '636672577178818044.jpg', '636672577179337715.jpg', '636672577342074560.jpg', '636672577342224459.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:22:14', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (105, '3118189600', '2018-07-15 13:23:14', '2018-07-15 13:31:23', '', '6', '6', 5000, NULL, 0, '', '5', '636672577943728179.jpg', '636672577944337799.jpg', '636672582836952511.jpg', '636672582837122402.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:31:23', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (106, '3118244928', '2018-07-15 13:23:19', '2018-07-15 13:44:56', '', '6', '6', 5000, NULL, 0, '', '6', '636672577995546548.jpg', '636672577996797553.jpg', '636672590965513496.jpg', '636672590965693394.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:44:56', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (107, '3113934112', '2018-07-15 13:23:38', '2018-07-15 13:31:44', '', '6', '6', 5000, NULL, 0, '', '7', '636672578181283747.jpg', '636672578181823397.jpg', '636672583043776981.jpg', '636672583044617237.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:31:44', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (108, '3117202048', '2018-07-15 13:31:48', '2018-07-15 13:43:58', '', '6', '6', 5000, NULL, 0, '', '8', '636672583085007741.jpg', '636672583086272139.jpg', '636672590389388822.jpg', '636672590389558700.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:43:58', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (109, '3113963712', '2018-07-15 13:32:17', '2018-07-15 13:43:45', '', '6', '6', 5000, NULL, 0, '', '1', '636672583377502886.jpg', '636672583378002552.jpg', '636672590259885059.jpg', '636672590260044909.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:43:46', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (110, '3118189600', '2018-07-15 13:32:21', '2018-07-15 13:32:23', '', '6', '6', 5000, NULL, 0, '', '2', '636672583413646565.jpg', '636672583414865804.jpg', '636672583435000317.jpg', '636672583435193116.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:32:23', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (111, '3118189600', '2018-07-15 13:32:24', '2018-07-15 13:32:51', '', '6', '6', 5000, NULL, 0, '', '3', '636672583447254216.jpg', '636672583447804655.jpg', '636672583712271550.jpg', '636672583712441454.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:32:51', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (112, '3118189600', '2018-07-15 13:33:17', '2018-07-15 13:35:14', '', '6', '6', 5000, NULL, 0, '', '4', '636672583970860619.jpg', '636672583971404678.jpg', '636672585143144876.jpg', '636672585143314788.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:35:14', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (113, '3118189600', '2018-07-15 13:36:20', '2018-07-15 13:36:24', '', '6', '6', 5000, NULL, 0, '', '5', '636672585800267116.jpg', '636672585801616280.jpg', '636672585840920137.jpg', '636672585841100039.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:36:24', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (114, '3118189600', '2018-07-15 13:36:25', '2018-07-15 13:36:26', '', '6', '6', 5000, NULL, 0, '', '6', '636672585849545674.jpg', '636672585850806553.jpg', '636672585870040560.jpg', '636672585870215270.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:36:27', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (115, '3118189600', '2018-07-15 13:36:30', '2018-07-15 13:36:31', '', '6', '6', 5000, NULL, 0, '', '7', '636672585906081366.jpg', '636672585906621046.jpg', '636672585911717963.jpg', '636672585911877865.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:36:31', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (116, '3118189600', '2018-07-15 13:36:31', '2018-07-15 13:36:32', '', '6', '6', 5000, NULL, 0, '', '8', '636672585914456262.jpg', '636672585914995929.jpg', '636672585920744918.jpg', '636672585920904841.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:36:32', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (117, '3118189600', '2018-07-15 13:36:34', '2018-07-15 13:36:35', '', '6', '6', 5000, NULL, 0, '', '1', '636672585946083013.jpg', '636672585946592707.jpg', '636672585958229656.jpg', '636672585958389515.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:36:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (118, '3118189600', '2018-07-15 13:36:36', '2018-07-15 13:36:37', '', '6', '6', 5000, NULL, 0, '', '1', '636672585965321056.jpg', '636672585965850721.jpg', '636672585973968189.jpg', '636672585974138093.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:36:37', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (119, '3118189600', '2018-07-15 13:36:42', '2018-07-15 13:36:52', '', '6', '6', 5000, NULL, 0, '', '2', '636672586023231716.jpg', '636672586023871304.jpg', '636672586129745816.jpg', '636672586129915711.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:36:52', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (120, '3118189600', '2018-07-15 13:39:53', '2018-07-15 13:40:39', '', '6', '6', 5000, NULL, 0, '', '3', '636672587932982511.jpg', '636672587933841960.jpg', '636672588394610925.jpg', '636672588394770835.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:40:39', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (121, '3118189600', '2018-07-15 13:40:49', '2018-07-15 13:40:53', '', '6', '6', 5000, NULL, 0, '', '4', '636672588490406581.jpg', '636672588491645821.jpg', '636672588539687799.jpg', '636672588539847709.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:40:53', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (122, '3118189600', '2018-07-15 13:41:07', '2018-07-15 13:41:14', '', '6', '6', 5000, NULL, 0, '', '3', '636672588670777987.jpg', '636672588672074517.jpg', '636672588747012606.jpg', '636672588747172525.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:41:14', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (123, '3118189600', '2018-07-15 13:41:21', '2018-07-15 13:41:23', '', '6', '6', 5000, NULL, 0, '', '4', '636672588813681088.jpg', '636672588814310687.jpg', '636672588838538225.jpg', '636672588838708125.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:41:23', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (124, '3118189600', '2018-07-15 13:43:23', '2018-07-15 13:43:31', '', '6', '6', 5000, NULL, 0, '', '5', '636672590029952740.jpg', '636672590031301973.jpg', '636672590114128565.jpg', '636672590114288462.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:43:31', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (125, '3118189600', '2018-07-15 13:43:40', '2018-07-15 13:51:26', '', '6', '6', 5000, NULL, 0, '', '6', '636672590207407609.jpg', '636672590207917269.jpg', '636672594869906603.jpg', '636672594870075378.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:51:27', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (126, '3113963712', '2018-07-15 13:43:52', '2018-07-15 13:44:12', '', '6', '6', 5000, NULL, 0, '', '7', '636672590322197107.jpg', '636672590323429326.jpg', '636672590529786587.jpg', '636672590529946411.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:44:12', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (127, '3117202048', '2018-07-15 13:44:02', '2018-07-15 13:44:23', '', '6', '6', 5000, NULL, 0, '', '8', '636672590428767545.jpg', '636672590429337202.jpg', '636672590636406583.jpg', '636672590636556499.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:44:23', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (128, '3113934112', '2018-07-15 13:44:06', '2018-07-15 13:51:42', '', '6', '6', 5000, NULL, 0, '', '8', '636672590459921395.jpg', '636672590460401073.jpg', '636672595022185685.jpg', '636672595022345608.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:51:42', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (129, '3118244928', '2018-07-15 13:45:00', '2018-07-15 13:45:05', '', '6', '6', 5000, NULL, 0, '', '7', '636672591003222804.jpg', '636672591003742462.jpg', '636672591051196253.jpg', '636672591051366169.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:45:05', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (130, '3118244928', '2018-07-15 13:45:25', '2018-07-15 13:45:27', '', '6', '6', 5000, NULL, 0, '', '6', '636672591249559346.jpg', '636672591250059021.jpg', '636672591279428532.jpg', '636672591279598432.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:45:27', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (131, '3118244928', '2018-07-15 13:45:29', '2018-07-15 13:45:31', '', '6', '6', 5000, NULL, 0, '', '4', '636672591297398008.jpg', '636672591297901981.jpg', '636672591310228185.jpg', '636672591310398298.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:45:31', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (132, '3118189600', '2018-07-15 13:51:34', '2018-07-15 13:51:38', '', '6', '6', 5000, NULL, 0, '', '5', '636672594944269210.jpg', '636672594944921316.jpg', '636672594990057126.jpg', '636672594990237024.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:51:39', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (133, '3113934112', '2018-07-15 13:51:52', '2018-07-15 13:51:58', '', '6', '6', 5000, NULL, 0, '', '1', '636672595126183935.jpg', '636672595126683631.jpg', '636672595182656636.jpg', '636672595182816533.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:51:58', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (134, '3113963712', '2018-07-15 13:51:59', '2018-07-15 14:10:06', '', '6', '6', 5000, NULL, 0, '', '2', '636672595198441631.jpg', '636672595198961328.jpg', '636672606070051272.jpg', '636672606070211156.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 14:10:07', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (135, '3118189600', '2018-07-15 13:54:07', '2018-07-15 13:54:10', '', '6', '6', 5000, NULL, 0, '', '3', '636672596473895286.jpg', '636672596475154505.jpg', '636672596504259631.jpg', '636672596504429535.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:54:10', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (136, '3118189600', '2018-07-15 13:54:10', '2018-07-15 13:54:11', '', '6', '6', 5000, NULL, 0, '', '4', '636672596508168312.jpg', '636672596508698811.jpg', '636672596515136378.jpg', '636672596515306269.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:54:11', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (137, '3118189600', '2018-07-15 13:54:55', '2018-07-15 13:55:00', '', '6', '6', 5000, NULL, 0, '', '5', '636672596950034239.jpg', '636672596950653848.jpg', '636672597002071789.jpg', '636672597002238293.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:55:00', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (138, '3118189600', '2018-07-15 13:55:00', '2018-07-15 13:55:11', '', '6', '6', 5000, NULL, 0, '', '6', '636672597007816817.jpg', '636672597008624424.jpg', '636672597115369772.jpg', '636672597115539655.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:55:11', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (139, '3118189600', '2018-07-15 13:55:29', '2018-07-15 13:55:44', '', '6', '6', 5000, NULL, 0, '', '7', '636672597289806656.jpg', '636672597291145437.jpg', '636672597441991086.jpg', '636672597442170970.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 13:55:44', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (140, '3118189600', '2018-07-15 14:04:18', '2018-07-15 14:04:26', '', '6', '6', 5000, NULL, 0, '', '8', '636672602583962694.jpg', '636672602584602287.jpg', '636672602661801947.jpg', '636672602662031818.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 14:04:26', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (141, '3118244928', '2018-07-15 14:04:23', '2018-07-15 14:04:29', '', '6', '6', 5000, NULL, 0, '', '1', '636672602633594722.jpg', '636672602634074431.jpg', '636672602695433593.jpg', '636672602695613456.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 14:04:29', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (142, '3118189600', '2018-07-15 14:04:31', '2018-07-15 14:04:33', '', '6', '6', 5000, NULL, 0, '', '1', '636672602715398116.jpg', '636672602716048041.jpg', '636672602733748214.jpg', '636672602733919276.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 14:04:33', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (143, '3117202048', '2018-07-15 14:07:48', '2018-07-15 14:07:56', '', '6', '6', 5000, NULL, 0, '', '2', '636672604685529191.jpg', '636672604686258732.jpg', '636672604769206662.jpg', '636672604769376562.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 14:07:56', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (144, '3118244928', '2018-07-15 14:09:41', '2018-08-19 08:07:02', '', '6', '6', 5000, NULL, 0, '', '3', '636672605815669673.jpg', '636672605816299349.jpg', '636702628221447646.jpg', '636702628221607565.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:07:02', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (145, '3118189600', '2018-07-15 14:09:45', '2018-07-17 23:00:00', '', '6', '6', 5000, NULL, 0, '', '4', '636672605853589736.jpg', '636672605854089419.jpg', '636674652003440388.jpg', '636674652003640171.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-17 23:00:00', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (146, '3113934112', '2018-07-15 14:10:09', '2018-07-15 14:12:00', '', '6', '6', 5000, NULL, 0, '', '3', '636672606095886570.jpg', '636672606096366270.jpg', '636672607201227461.jpg', '636672607201397352.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 14:12:00', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (147, '3117202048', '2018-07-15 14:10:16', '2018-07-17 22:59:34', '', '6', '6', 5000, NULL, 0, '', '4', '636672606167647675.jpg', '636672606168157369.jpg', '636674651746945476.jpg', '636674651747445411.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-17 22:59:34', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (148, '3113963712', '2018-07-15 14:10:30', '2018-07-15 14:10:31', '', '6', '6', 5000, NULL, 0, '', '5', '636672606301700619.jpg', '636672606302190321.jpg', '636672606316195947.jpg', '636672606316375862.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 14:10:31', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (149, '3113963712', '2018-07-15 14:10:34', '2018-07-15 14:10:36', '', '6', '6', 5000, NULL, 0, '', '6', '636672606348045294.jpg', '636672606348544986.jpg', '636672606361709090.jpg', '636672606361877942.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 14:10:36', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (150, '3113934112', '2018-07-15 14:12:04', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '7', '636672607244788235.jpg', '636672607245547853.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-15 14:12:04', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (151, '3113963712', '2018-07-15 14:12:07', '2018-08-17 22:54:44', '', '6', '6', 5000, NULL, 0, '', '8', '636672607273398536.jpg', '636672607273908226.jpg', '636701432849310778.jpg', '636701432849800472.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-17 22:54:44', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (152, '3117202048', '2018-07-17 22:59:45', '2018-07-17 22:59:47', '', '6', '6', 5000, NULL, 0, '', '8', '636674651849172049.jpg', '636674651849821991.jpg', '636674651870739961.jpg', '636674651870930186.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-17 22:59:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (153, '3117202048', '2018-07-17 23:00:05', '2018-07-17 23:00:15', '', '6', '6', 5000, NULL, 0, '', '7', '636674652052984418.jpg', '636674652053563047.jpg', '636674652158875390.jpg', '636674652159075356.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-17 23:00:15', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (154, '3118189600', '2018-07-17 23:00:06', '2018-07-17 23:00:09', '', '6', '6', 5000, NULL, 0, '', '6', '636674652067584786.jpg', '636674652068219564.jpg', '636674652096995030.jpg', '636674652097145049.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-17 23:00:09', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (155, '3118189600', '2018-07-17 23:00:17', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '4', '636674652177810364.jpg', '636674652178564349.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-07-17 23:00:17', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (156, 'gggffffggssfsfs3113963712', '2018-08-17 22:55:06', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '5', '636701433061377493.jpg', '636701433062627052.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-17 22:55:06', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (157, '3117202048', '2018-08-18 10:11:25', '2018-08-18 10:11:45', '', '6', '6', 5000, NULL, 0, '', '1', '636701838848431930.jpg', '636701838849621812.jpg', '636701839055874251.jpg', '636701839056054153.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-18 10:11:45', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (158, '3117202048', '2018-08-18 10:11:50', '2018-08-18 10:11:53', '', '6', '6', 5000, NULL, 0, '', '2', '636701839106476738.jpg', '636701839107026391.jpg', '636701839134678074.jpg', '636701839134867957.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-18 10:11:53', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (159, '3117202048', '2018-08-18 10:14:46', '2018-08-18 11:32:30', '', '6', '5', 5000, NULL, 0, '', '3', '636701840868192625.jpg', '636701840868872193.jpg', '636701887503623444.jpg', '636701887504123140.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-18 11:32:30', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (160, '3117202048', '2018-08-18 10:15:09', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '4', '636701841088072789.jpg', '636701841088542499.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-18 10:15:09', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (161, '3117202048', '2018-08-18 11:32:33', '2018-08-18 11:32:34', '', '5', '5', 5000, NULL, 0, '', '5', '636701887530960178.jpg', '636701887531459853.jpg', '636701887546463469.jpg', '636701887546623362.jpg', 0, 'TRUONGGIANG', NULL, '5', 0, '2018-08-18 11:32:34', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (162, '3117202048', '2018-08-18 11:32:35', '2018-08-18 11:39:35', '', '5', '6', 5000, NULL, 0, '', '6', '636701887548024188.jpg', '636701887549544487.jpg', '636701891755575185.jpg', '636701891755735082.jpg', 0, 'TRUONGGIANG', NULL, '5', 0, '2018-08-18 11:39:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (163, '3117202048', '2018-08-18 11:39:37', '2018-08-18 11:41:00', '', '6', '6', 5000, NULL, 0, '', '7', '636701891770357713.jpg', '636701891770847680.jpg', '636701892608134462.jpg', '636701892608304349.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-18 11:41:00', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (164, '3117202048', '2018-08-18 11:41:01', '2018-08-18 15:51:05', '', '6', '6', 5000, NULL, 0, '', '8', '636701892610034570.jpg', '636701892610545210.jpg', '636702042654873647.jpg', '636702042655203430.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-18 15:51:05', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (165, '3117202048', '2018-08-18 15:54:04', '2018-08-18 19:55:02', '', '6', '6', 5000, NULL, 0, '', '1', '636702044447136607.jpg', '636702044447756212.jpg', '636702189023405091.jpg', '636702189024094713.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-18 19:55:02', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (166, '3117202048', '2018-08-18 19:57:32', '2018-08-19 07:38:43', '', '6', '6', 5000, NULL, 0, '', '1', '636702190523277485.jpg', '636702190523777190.jpg', '636702611236751796.jpg', '636702611236928332.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:38:43', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (167, '3117202048', '2018-08-19 07:53:25', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '2', '636702620057413292.jpg', '636702620057573181.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:53:25', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (168, '3117202048', '2018-08-19 07:53:26', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '3', '636702620068290646.jpg', '636702620068460554.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:53:26', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (169, '3117202048', '2018-08-19 07:53:28', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '4', '636702620085685675.jpg', '636702620085845602.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:53:28', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (170, '3117202048', '2018-08-19 07:54:08', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '3', '636702620483111152.jpg', '636702620483271054.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:54:08', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (171, '3117202048', '2018-08-19 07:54:15', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '4', '636702620554894135.jpg', '636702620555064026.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:54:15', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (172, '3113934112', '2018-08-19 07:54:26', '2018-08-19 08:31:06', '', '6', '6', 5000, NULL, 0, '', '5', '636702620669684959.jpg', '636702620669854855.jpg', '636702642670032533.jpg', '636702642670212418.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:31:07', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (173, '3118189600', '2018-08-19 07:54:42', '2018-08-19 08:06:35', '', '6', '6', 5000, NULL, 0, '', '6', '636702620822624888.jpg', '636702620822784798.jpg', '636702627953209919.jpg', '636702627953379797.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:06:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (174, '3117202048', '2018-08-19 07:56:26', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '7', '636702621867296582.jpg', '636702621867456487.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:56:26', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (175, '3117202048', '2018-08-19 07:56:31', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '8', '636702621910630555.jpg', '636702621910800514.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:56:31', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (176, '3117202048', '2018-08-19 07:57:08', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '8', '636702622283114667.jpg', '636702622283274582.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:57:08', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (177, '3117202048', '2018-08-19 07:57:09', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '7', '636702622296841420.jpg', '636702622297001334.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 07:57:09', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (178, '3117202048', '2018-08-19 08:00:00', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '1', '636702624004984888.jpg', '636702624005144793.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:00:00', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (179, '3117202048', '2018-08-19 08:00:04', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '2', '636702624039952048.jpg', '636702624040121956.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:00:04', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (180, '3117202048', '2018-08-19 08:00:05', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '3', '636702624057172987.jpg', '636702624057343147.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:00:05', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (181, '3117202048', '2018-08-19 08:02:14', '2018-08-19 08:32:07', '', '6', '6', 5000, NULL, 0, '', '4', '636702625340975644.jpg', '636702625341145544.jpg', '636702643279625022.jpg', '636702643279794909.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:32:08', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (182, '3117202048', '2018-08-19 08:34:15', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '5', '636702644557722404.jpg', '636702644557882310.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:34:15', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (183, '3113934112', '2018-08-19 08:34:20', '2018-08-19 08:47:25', '', '6', '6', 5000, NULL, 0, '', '6', '636702644607589970.jpg', '636702644607759831.jpg', '636702652451512258.jpg', '636702652451672134.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:47:25', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (184, '3117202048', '2018-08-19 08:34:22', '2018-08-19 08:48:17', '', '6', '6', 5000, NULL, 0, '', '7', '636702644626492918.jpg', '636702644626663887.jpg', '636702652973937652.jpg', '636702652974097544.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:48:17', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (185, '3118244928', '2018-08-19 08:34:36', '2018-08-19 08:35:04', '', '6', '6', 5000, NULL, 0, '', '8', '636702644767225851.jpg', '636702644767395742.jpg', '636702645049850219.jpg', '636702645050020118.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:35:05', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (186, '3118189600', '2018-08-19 08:34:39', '2018-08-19 08:48:19', '', '6', '6', 5000, NULL, 0, '', '1', '636702644789978625.jpg', '636702644790148520.jpg', '636702652998693649.jpg', '636702652998863545.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:48:19', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (187, '3117202048', '2018-08-19 08:49:05', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '1', '636702653456696776.jpg', '636702653456856678.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:49:05', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (188, '3117202048', '2018-08-19 08:51:08', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '2', '636702654687435140.jpg', '636702654687595028.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:51:08', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (189, '3118189600', '2018-08-19 08:51:13', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '3', '636702654732771571.jpg', '636702654732941475.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:51:13', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (190, '3118189600', '2018-08-19 08:54:17', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '4', '636702656570936780.jpg', '636702656571096695.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:54:17', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (191, '3117202048', '2018-08-19 08:54:20', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '3', '636702656605745724.jpg', '636702656605915636.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:54:20', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (192, '3113934112', '2018-08-19 08:54:34', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '4', '636702656741113843.jpg', '636702656741273749.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:54:34', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (193, '3117202048', '2018-08-19 08:54:35', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '5', '636702656758679892.jpg', '636702656758849783.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:54:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (194, '3118244928', '2018-08-19 08:54:38', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '6', '636702656782777614.jpg', '636702656782941240.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 08:54:38', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (195, '3113934112', '2018-08-19 09:03:59', '2018-09-17 18:29:10', '', '6', '6', 5000, NULL, 0, '', '7', '636702662396662031.jpg', '636702662396821936.jpg', '636728057506045856.jpg', '636728057506898280.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-17 18:29:10', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (196, '3113963712', '2018-08-19 11:13:40', '2018-09-26 20:30:50', '', '6', '6', 390000, NULL, 0, '', '8', '636702740206302494.jpg', '636702740207160914.jpg', '636735906507430638.jpg', '636735906508086958.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-26 20:30:50', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (197, '3118244928', '2018-08-19 11:13:43', '2018-09-25 14:18:12', '', '6', '6', 375000, NULL, 0, '', '8', '636702740237581356.jpg', '636702740237757058.jpg', '636734818925386405.jpg', '636734818925895880.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-25 14:18:12', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (198, '3117202048', '2018-08-19 11:13:45', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '7', '636702740256994039.jpg', '636702740257829756.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 11:13:45', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (199, '3118189600', '2018-08-19 11:13:47', '2018-09-17 14:28:07', '', '6', '6', 0, NULL, 0, '', '6', '636702740276245631.jpg', '636702740276406131.jpg', '636727912881229072.jpg', '636727912881399318.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-17 14:28:08', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (200, '3117202048', '2018-08-19 12:04:21', '2018-08-19 18:20:40', '', '6', '6', 5000, NULL, 0, '', '4', '636702770613837398.jpg', '636702770614438396.jpg', '636702996405917289.jpg', '636702996406087184.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 18:20:40', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (201, '0353401904', '2018-08-19 15:58:23', '2018-08-19 15:58:46', '', '6', '6', 5000, NULL, 0, '', '5', '636702911008446281.jpg', '636702911024950698.jpg', '636702911263046838.jpg', '636702911263216738.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 15:58:46', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (202, '0353401904', '2018-08-19 15:58:59', '2018-08-19 15:59:01', '', '6', '6', 5000, NULL, 0, '', '1', '636702911392569076.jpg', '636702911392738976.jpg', '636702911417170326.jpg', '636702911417340221.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 15:59:01', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (203, '0353401904', '2018-08-19 15:59:03', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '2', '636702911439609323.jpg', '636702911439769224.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 15:59:04', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (204, '0353401904', '2018-08-19 15:59:15', '2018-08-19 15:59:16', '', '6', '6', 5000, NULL, 0, '', '3', '636702911553220189.jpg', '636702911553380068.jpg', '636702911564927148.jpg', '636702911565087053.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 15:59:16', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (205, '0353401904', '2018-08-19 15:59:18', '2018-08-19 15:59:19', '', '6', '6', 5000, NULL, 0, '', '4', '636702911587518181.jpg', '636702911587678378.jpg', '636702911598564295.jpg', '636702911600060508.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 15:59:20', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (206, '0353401904', '2018-08-19 15:59:38', '2018-08-19 16:12:35', '', '6', '6', 5000, NULL, 0, '', '5', '636702911788209782.jpg', '636702911788479624.jpg', '636702919557427856.jpg', '636702919557597743.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:12:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (207, '0353401904', '2018-08-19 16:21:31', '2018-08-19 16:21:41', '', '6', '6', 5000, NULL, 0, '', '6', '636702924888104387.jpg', '636702924888344235.jpg', '636702925010497319.jpg', '636702925010657212.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:21:41', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (208, '0353401904', '2018-08-19 16:21:46', '2018-08-19 16:21:57', '', '6', '6', 5000, NULL, 0, '', '7', '636702925045130296.jpg', '636702925045654191.jpg', '636702925177495418.jpg', '636702925177655303.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:21:57', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (209, '0353401904', '2018-08-19 16:22:57', '2018-08-19 16:23:06', '', '6', '6', 5000, NULL, 0, '', '8', '636702925737493960.jpg', '636702925744855540.jpg', '636702925867742570.jpg', '636702925867902488.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:23:06', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (210, '0353401904', '2018-08-19 16:23:21', '2018-08-19 16:44:12', '', '6', '6', 5000, NULL, 0, '', '1', '636702925984156118.jpg', '636702925990972806.jpg', '636702938528845743.jpg', '636702938529175535.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:44:12', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (211, '0353401904', '2018-08-19 16:44:16', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '1', '636702938561659566.jpg', '636702938561829803.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:44:16', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (212, '0353401904', '2018-08-19 16:44:17', '2018-08-19 16:46:01', '', '6', '6', 5000, NULL, 0, '', '2', '636702938573691373.jpg', '636702938573851437.jpg', '636702939612844747.jpg', '636702939613017520.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:46:01', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (213, '0353401904', '2018-08-19 16:46:03', '2018-08-19 16:46:05', '', '6', '6', 5000, NULL, 0, '', '3', '636702939631909762.jpg', '636702939632070412.jpg', '636702939655498284.jpg', '636702939655668525.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:46:05', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (214, '0353401904', '2018-08-19 16:46:20', '2018-08-19 16:46:29', '', '6', '6', 5000, NULL, 0, '', '4', '636702939805100318.jpg', '636702939805290205.jpg', '636702939897470432.jpg', '636702939897640322.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:46:29', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (215, '0353401904', '2018-08-19 16:53:14', '2018-08-19 16:53:16', '', '6', '6', 5000, NULL, 0, '', '3', '636702943947350887.jpg', '636702943947590738.jpg', '636702943960312765.jpg', '636702943960482677.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:53:16', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (216, '0353401904', '2018-08-19 16:53:17', '2018-08-19 16:53:17', '', '6', '6', 5000, NULL, 0, '', '4', '636702943971530810.jpg', '636702943971690711.jpg', '636702943978728195.jpg', '636702943978898184.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:53:17', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (217, '0353401904', '2018-08-19 16:53:39', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '5', '636702944194086927.jpg', '636702944194246832.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 16:53:39', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (218, '0353401904', '2018-08-19 16:53:41', '2018-08-19 17:00:28', '', '6', '6', 5000, NULL, 0, '', '6', '636702944211659215.jpg', '636702944211819142.jpg', '636702948286216137.jpg', '636702948286376055.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:00:28', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (219, '0353401904', '2018-08-19 17:00:36', '2018-08-19 17:00:39', '', '6', '6', 5000, NULL, 0, '', '7', '636702948367712584.jpg', '636702948367872477.jpg', '636702948391813959.jpg', '636702948391983893.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:00:39', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (220, '0353401904', '2018-08-19 17:00:39', '2018-08-19 17:00:40', '', '6', '6', 5000, NULL, 0, '', '8', '636702948398495921.jpg', '636702948398655814.jpg', '636702948404714528.jpg', '636702948404874442.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:00:40', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (221, '0353401904', '2018-08-19 17:00:41', '2018-08-19 17:00:47', '', '6', '6', 5000, NULL, 0, '', '8', '636702948413390541.jpg', '636702948413560449.jpg', '636702948470777574.jpg', '636702948470957463.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:00:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (222, '0353401904', '2018-08-19 17:00:59', '2018-08-19 17:01:04', '', '6', '6', 5000, NULL, 0, '', '7', '636702948598636643.jpg', '636702948598796565.jpg', '636702948643300661.jpg', '636702948643470552.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:01:04', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (223, '0353401904', '2018-08-19 17:26:20', '2018-08-19 17:26:21', '', '6', '6', 5000, NULL, 0, '', '6', '636702963799491317.jpg', '636702963799691207.jpg', '636702963816439845.jpg', '636702963816582979.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:26:21', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (224, '0353401904', '2018-08-19 17:26:30', '2018-08-19 17:26:46', '', '6', '6', 5000, NULL, 0, '', '4', '636702963903431594.jpg', '636702963903601493.jpg', '636702964068437737.jpg', '636702964068587636.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:26:46', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (225, '0353401904', '2018-08-19 17:27:02', '2018-08-19 17:27:06', '', '6', '6', 5000, NULL, 0, '', '5', '636702964225457671.jpg', '636702964225717498.jpg', '636702964266906031.jpg', '636702964267075947.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:27:06', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (226, '0353401904', '2018-08-19 17:27:11', '2018-08-19 17:27:13', '', '6', '6', 5000, NULL, 0, '', '1', '636702964312567392.jpg', '636702964312727293.jpg', '636702964336333749.jpg', '636702964336503640.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:27:13', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (227, '0353401904', '2018-08-19 17:27:28', '2018-08-19 17:27:35', '', '6', '6', 5000, NULL, 0, '', '2', '636702964482916923.jpg', '636702964483076816.jpg', '636702964559040792.jpg', '636702964559220676.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:27:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (228, '0353401904', '2018-08-19 17:27:38', '2018-08-19 17:27:42', '', '6', '6', 5000, NULL, 0, '', '3', '636702964579291663.jpg', '636702964579461563.jpg', '636702964623135419.jpg', '636702964623305331.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:27:42', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (229, '0353401904', '2018-08-19 17:27:44', '2018-08-19 17:29:40', '', '6', '6', 5000, NULL, 0, '', '4', '636702964643718614.jpg', '636702964643878506.jpg', '636702965807856462.jpg', '636702965808026365.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:29:40', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (230, '0353401904', '2018-08-19 17:29:46', '2018-08-19 17:34:12', '', '6', '6', 5000, NULL, 0, '', '5', '636702965686504863.jpg', '636702965686704714.jpg', '636702968525517236.jpg', '636702968525678822.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:34:12', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (231, '0353401904', '2018-08-19 17:34:34', '2018-08-19 17:34:48', '', '6', '6', 5000, NULL, 0, '', '6', '636702968629857377.jpg', '636702968647825433.jpg', '636702968889126498.jpg', '636702968889466297.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:34:48', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (232, '0353401904', '2018-08-19 17:35:28', '2018-08-19 17:35:57', '', '6', '6', 5000, NULL, 0, '', '7', '636702969270379296.jpg', '636702969270649108.jpg', '636702969573522321.jpg', '636702969573692220.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:35:57', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (233, '0353401904', '2018-08-19 17:36:02', '2018-08-19 17:37:35', '', '6', '6', 5000, NULL, 0, '', '8', '636702969615197456.jpg', '636702969615347363.jpg', '636702970558613337.jpg', '636702970558783236.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:37:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (262, '3113934112', '2018-09-17 18:29:39', '2018-09-17 21:35:20', '', '6', '6', 3000, NULL, 0, '', '3', '636728057791186410.jpg', '636728057791356305.jpg', '636728169203353157.jpg', '636728169203513058.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-17 21:35:20', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (263, '3113934112', '2018-09-17 21:35:25', '2018-09-17 23:35:36', '', '6', '6', 3000, NULL, 0, '', '4', '636728169249694760.jpg', '636728169249864659.jpg', '636728241369249971.jpg', '636728241369419861.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-17 23:35:36', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (264, '3113934112', '2018-09-17 18:36:49', '2018-09-17 23:36:57', '', '6', '6', 6000, NULL, 0, '', '3', '636728062093969376.jpg', '636728062094958759.jpg', '636728242176763488.jpg', '636728242176923384.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-17 23:36:57', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (265, '3113934112', '2018-09-17 23:37:04', '2018-09-18 05:37:15', '', '6', '6', 6000, NULL, 0, '', '4', '636728242243365456.jpg', '636728242243515346.jpg', '636728458356331672.jpg', '636728458356501567.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-18 05:37:15', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (266, '3113934112', '2018-09-18 05:38:04', '2018-09-18 07:38:21', '', '6', '6', 5000, NULL, 0, '', '5', '636728458846114152.jpg', '636728458846274057.jpg', '636728531014545334.jpg', '636728531014715233.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-18 07:38:21', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (267, '3113934112', '2018-09-18 17:38:39', '2018-09-18 19:38:47', '', '6', '6', 6000, NULL, 0, '', '6', '636728891189253869.jpg', '636728891189413787.jpg', '636728963272374097.jpg', '636728963272533993.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-18 19:38:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (268, '3113934112', '2018-09-18 19:39:52', '2018-09-19 07:40:03', '', '6', '6', 10000, NULL, 0, '', '7', '636728963928148927.jpg', '636728963928308836.jpg', '636729396032259473.jpg', '636729396032429372.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-19 07:40:03', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (269, '3113934112', '2018-09-19 07:40:40', '2018-09-20 07:40:56', '', '6', '6', 15000, NULL, 0, '', '8', '636729396406419553.jpg', '636729396406749365.jpg', '636730260564860141.jpg', '636730260565010052.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-20 07:40:56', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (270, '3113934112', '2018-09-20 20:23:30', '2018-09-21 20:23:51', '', '6', '6', 16000, NULL, 0, '', '1', '636730718104042588.jpg', '636730718104505891.jpg', '636731582315992399.jpg', '636731582316542037.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-21 20:23:51', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (271, '3113934112', '2018-09-21 20:24:28', '2018-09-22 08:24:42', '', '6', '6', 10000, NULL, 0, '', '2', '636731582678956947.jpg', '636731582679106854.jpg', '636732014830087753.jpg', '636732014830267834.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-22 08:24:43', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (272, '3113934112', '2018-09-22 08:24:58', '2018-09-23 20:28:30', '', '6', '6', 10000, NULL, 0, '', '3', '636732014987547487.jpg', '636732014987717382.jpg', '636733313110368326.jpg', '636733313110538204.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-23 20:28:31', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (273, '3113934112', '2018-09-23 20:32:51', '2018-09-25 08:32:59', '', '6', '6', 10000, NULL, 0, '', '4', '636733315714865497.jpg', '636733315715917229.jpg', '636734612048149768.jpg', '636734612048319654.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-25 08:33:24', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (274, '3113934112', '2018-09-25 08:41:07', '2018-09-26 20:41:18', '', '6', '6', 10000, NULL, 0, '', '5', '636734616675492801.jpg', '636734616675742727.jpg', '636735912789868973.jpg', '636735912790018944.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-26 20:41:19', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (275, '3113934112', '2018-09-28 08:41:37', '2018-09-29 20:41:46', '', '6', '6', 10000, NULL, 0, '', '6', '636737208978009977.jpg', '636737208978197555.jpg', '636738505068961999.jpg', '636738505069111988.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-29 20:41:46', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (276, '3113934112', '2018-09-26 20:42:08', '2018-09-28 08:42:38', '', '6', '6', 20000, NULL, 0, '', '7', '636735913287624255.jpg', '636735913287774230.jpg', '636737211568050223.jpg', '636737211568200148.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-28 08:45:56', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (277, '3113934112', '2018-09-28 08:47:29', '2018-09-29 20:47:38', '', '6', '6', 10000, NULL, 0, '', '8', '636737212490662691.jpg', '636737212490857761.jpg', '636738508582913700.jpg', '636738508583063684.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-29 20:47:38', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (278, '3113934112', '2018-09-26 20:48:18', '2018-09-28 08:48:30', '', '6', '6', 20000, NULL, 0, '', '1', '636735916988959763.jpg', '636735916989109820.jpg', '636737213305788521.jpg', '636737213305938501.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-28 08:48:50', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (279, '3113934112', '2018-09-26 20:49:29', '2018-09-28 08:49:36', '', '6', '6', 20000, NULL, 0, '', '1', '636735917694731883.jpg', '636735917694881876.jpg', '636737213770917748.jpg', '636737213771117722.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-28 08:49:37', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (280, '3113934112', '2018-09-26 20:49:54', '2018-09-28 20:50:01', '', '6', '6', 26000, NULL, 0, '', '2', '636735917940573198.jpg', '636735917940737192.jpg', '636737646019889700.jpg', '636737646020039680.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-28 20:50:02', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (281, '3118189600', '2018-09-18 10:38:28', '2018-09-18 10:38:30', '', '6', '6', 0, NULL, 0, '3118189600', '3', '636728639082995066.jpg', '636728639084663360.jpg', '636728639104001647.jpg', '636728639104161483.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-18 10:38:30', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (282, '3113934112', '2018-09-18 10:38:35', NULL, '', '6', '6', 2000, NULL, 0, '', '4', '636728639155350140.jpg', '636728639155519972.jpg', '636728639179192863.jpg', '636728639179352689.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-18 10:38:37', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (296, '3113934112', '2018-09-26 20:30:43', '2018-09-26 20:48:11', '', '6', '1', 0, NULL, 0, '', '1', '636735906437162049.jpg', '636735906439795860.jpg', '', '', 100000, 'TRUONGGIANG', NULL, '6', 0, '2018-09-26 20:48:11', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (297, '3113963712', '2018-09-26 20:30:53', '2018-12-05 22:15:30', '', '6', '6', 706000, NULL, 0, '', '2', '636735906532314043.jpg', '636735906533374217.jpg', '636796449306792752.jpg', '636796449308031966.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-12-05 22:15:30', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (299, '3118244928', '2018-09-26 20:31:06', '2018-09-26 20:49:38', '', '6', '1', 0, NULL, 0, '', '3', '636735906660374424.jpg', '636735906661610718.jpg', '', '', 100000, 'TRUONGGIANG', NULL, '6', 0, '2018-09-26 20:49:38', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (300, '3117202048', '2018-09-26 20:31:12', '2018-10-01 13:26:11', '', '6', '6', 10000, NULL, 0, '', '4', '636735906728432708.jpg', '636735906729450751.jpg', '636739971712811536.jpg', '636739971713631144.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-10-01 13:26:11', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (301, '3118244928', '2018-09-26 21:19:47', '2018-11-06 13:58:31', '', '6', '6', 10000, NULL, 0, '', '5', '636735935868800585.jpg', '636735935870070123.jpg', '636771095116605814.jpg', '636771095117404996.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-11-06 13:58:31', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (378, '3113934112', '2018-11-28 10:22:49', '2018-12-05 22:16:03', '111', '6', '6', 0, NULL, 0, '3113934112', '6', '636789973696314668.jpg', '636789973697143680.jpg', '636796449632174508.jpg', '636796449632664488.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-12-05 22:16:03', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (379, '3117202048', '2018-11-28 11:07:57', NULL, '-', '6', '', 0, NULL, 0, '', '4', '636790000768803460.jpg', '636790000769792343.jpg', NULL, NULL, 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-28 11:07:57', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (303, '3117202048', '2018-10-01 13:26:14', '2018-10-01 13:26:29', '', '6', '6', 0, NULL, 0, '', '6', '636739971742968110.jpg', '636739971744387293.jpg', '', '', 100000, 'WIN10-GIANGNT', NULL, '6', 0, '2018-10-01 13:26:29', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (304, '3117202048', '2018-10-01 13:26:58', '2018-10-01 13:27:02', '', '6', '6', 2000, NULL, 0, '', '7', '636739972187515117.jpg', '636739972188686169.jpg', '636739972224895825.jpg', '636739972225565553.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-10-01 13:27:02', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (305, '3117202048', '2018-10-01 14:00:56', '2018-10-01 14:01:02', '', '6', '6', 0, NULL, 0, '', '8', '636739992558736618.jpg', '636739992559695505.jpg', '', '', 100000, 'WIN10-GIANGNT', NULL, '6', 0, '2018-10-01 14:01:02', '2018-10-01 14:01:02');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (306, '3117202048', '2018-10-01 14:02:08', '2018-10-01 14:02:15', '', '6', '6', 0, NULL, 0, '', '1', '636739993288099570.jpg', '636739993289460070.jpg', '', '', 100000, 'WIN10-GIANGNT', NULL, '6', 0, '2018-10-01 14:02:15', '2018-10-01 14:02:15');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (307, '3117202048', '2018-10-01 14:05:07', '2018-10-01 14:05:14', '', '6', '6', 0, NULL, 0, '', '1', '636739995078867855.jpg', '636739995079797360.jpg', '', '', 100000, 'WIN10-GIANGNT', NULL, '6', 0, '2018-10-01 14:05:14', '2018-10-01 14:05:14');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (308, '3118244928', '2018-11-06 13:58:36', '2018-11-06 13:58:40', '', '6', '6', 2000, NULL, 0, '', '2', '636771095161330029.jpg', '636771095162478849.jpg', '636771095202927441.jpg', '636771095203426930.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-06 13:58:40', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (309, '3118244928', '2018-11-06 14:05:00', '2018-11-06 14:05:03', '', '6', '6', 2000, NULL, 0, '', '7', '636771099007402088.jpg', '636771099008341124.jpg', '636771099037291503.jpg', '636771099037960802.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-06 14:05:03', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (310, '3118244928', '2018-11-06 14:05:13', '2018-11-06 15:44:35', '', '6', '6', 5000, NULL, 0, '', '6', '636771099131984545.jpg', '636771099133063440.jpg', '636771158756588258.jpg', '636771158757217614.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-06 15:44:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (311, '3118244928', '2018-11-08 11:43:44', '2018-11-08 11:43:46', '', '6', '6', 2000, NULL, 0, '', '4', '636772742245117262.jpg', '636772742246246113.jpg', '636772742262689130.jpg', '636772742263358422.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 11:43:46', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (312, '3118244928', '2018-11-08 11:43:48', '2018-11-08 11:43:49', '', '6', '6', 2000, NULL, 0, '', '5', '636772742279761636.jpg', '636772742280770603.jpg', '636772742296704292.jpg', '636772742297373606.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 11:43:49', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (313, '3118244928', '2018-11-08 11:43:58', '2018-11-08 11:44:05', '', '6', '6', 2000, NULL, 0, '', '1', '636772742388280908.jpg', '636772742389309487.jpg', '636772742454582672.jpg', '636772742455281966.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 11:44:05', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (314, '3118244928', '2018-11-08 11:45:08', '2018-11-08 11:45:10', '', '6', '6', 2000, NULL, 0, '', '2', '636772743086519625.jpg', '636772743087648469.jpg', '636772743106652515.jpg', '636772743107451671.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 11:45:10', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (315, '3118244928', '2018-11-08 11:45:13', '2018-11-08 11:45:46', '', '6', '6', 2000, NULL, 0, '', '3', '636772743137715820.jpg', '636772743138755067.jpg', '636772743467774606.jpg', '636772743468394318.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 11:45:46', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (316, '3118244928', '2018-11-08 11:45:50', '2018-11-08 11:55:16', '', '6', '6', 5000, NULL, 0, '', '4', '636772743508642785.jpg', '636772743509641749.jpg', '636772749169014542.jpg', '636772749169863708.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 11:55:17', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (317, '3113934112', '2018-11-08 11:51:24', '2018-11-08 11:51:25', '', '6', '6', 2000, NULL, 0, '', '5', '636772746847870886.jpg', '636772746848850079.jpg', '636772746858789542.jpg', '636772746859289024.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 11:51:25', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (318, '3113934112', '2018-11-08 11:51:29', '2018-11-08 13:17:00', '', '6', '6', 5000, NULL, 0, '', '6', '636772746893044474.jpg', '636772746894043605.jpg', '636772798209257652.jpg', '636772798210276612.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 13:17:01', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (319, '3118244928', '2018-11-08 11:55:17', '2018-11-08 11:58:56', '', '6', '6', 5000, NULL, 0, '', '7', '636772749176416935.jpg', '636772749178045284.jpg', '636772751369711623.jpg', '636772751370370955.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 11:58:57', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (320, '3118244928', '2018-11-08 11:59:31', '2018-11-08 11:59:32', '', '6', '6', 2000, NULL, 0, '', '8', '636772751713839346.jpg', '636772751714878382.jpg', '636772751726306571.jpg', '636772751726816062.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 11:59:32', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (321, '3118244928', '2018-11-08 11:59:39', '2018-11-08 16:28:41', '', '6', '6', 0, NULL, 0, '', '1', '636772751789052340.jpg', '636772751790071441.jpg', '636772913215816812.jpg', '636772913217001340.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:28:41', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (322, '3113934112', '2018-11-08 13:17:08', '2018-11-08 13:17:10', '', '6', '6', 2000, NULL, 0, '', '1', '636772798287048017.jpg', '636772798288027018.jpg', '636772798307137467.jpg', '636772798307806775.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 13:17:10', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (323, '3113934112', '2018-11-08 13:17:51', '2018-11-08 13:51:44', '', '6', '6', 5000, NULL, 0, '', '2', '636772798713841101.jpg', '636772798714880047.jpg', '636772819050341245.jpg', '636772819051440142.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 13:51:45', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (324, '3113934112', '2018-11-08 13:51:47', '2018-11-08 13:51:48', '', '6', '6', 2000, NULL, 0, '', '3', '636772819071519907.jpg', '636772819072678724.jpg', '636772819086110316.jpg', '636772819086609834.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 13:51:48', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (325, '3113934112', '2018-11-08 13:51:50', '2018-11-08 13:51:54', '', '6', '6', 2000, NULL, 0, '', '4', '636772819104351771.jpg', '636772819105350620.jpg', '636772819150983914.jpg', '636772819151643232.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 13:51:55', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (326, '3113934112', '2018-11-08 13:52:04', '2018-11-08 13:52:08', '', '6', '6', 2000, NULL, 0, '', '3', '636772819242390330.jpg', '636772819243938767.jpg', '636772819290181562.jpg', '636772819290700896.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 13:52:09', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (327, '3113934112', '2018-11-08 13:52:14', '2018-11-08 13:53:20', '', '6', '6', 5000, NULL, 0, '', '4', '636772819347302945.jpg', '636772819348312046.jpg', '636772820011752716.jpg', '636772820012412045.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 13:53:21', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (328, '3113934112', '2018-11-08 13:53:34', '2018-11-08 13:55:46', '', '6', '6', 5000, NULL, 0, '', '5', '636772820144197134.jpg', '636772820145176132.jpg', '636772821472656461.jpg', '636772821473365741.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 13:55:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (329, '3113934112', '2018-11-08 13:55:52', '2018-11-08 13:55:54', '', '6', '6', 2000, NULL, 0, '', '6', '636772821520277749.jpg', '636772821521346789.jpg', '636772821550556723.jpg', '636772821551216042.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 13:55:55', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (330, '3113934112', '2018-11-08 14:00:42', '2018-11-08 14:00:46', '', '6', '6', 2000, NULL, 0, '', '7', '636772824428623535.jpg', '636772824429862642.jpg', '636772824471130027.jpg', '636772824471959169.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 14:00:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (331, '3113934112', '2018-11-08 14:25:47', '2018-11-08 14:25:48', '', '6', '6', 2000, NULL, 0, '', '8', '636772839477229222.jpg', '636772839478258172.jpg', '636772839488647373.jpg', '636772839489146865.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 14:25:48', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (332, '3113934112', '2018-11-08 14:58:12', '2018-11-08 15:10:40', '', '6', '6', 5000, NULL, 0, '', '1', '636772858925626062.jpg', '636772858926625036.jpg', '636772866411220659.jpg', '636772866411854622.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 15:10:41', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (333, '3113934112', '2018-11-08 15:10:50', '2018-11-08 15:45:36', '', '6', '6', 5000, NULL, 0, '', '2', '636772866498882523.jpg', '636772866500216145.jpg', '636772887369278173.jpg', '636772887370087335.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 15:45:37', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (334, '3113934112', '2018-11-08 15:45:42', '2018-11-08 16:24:38', '888', '6', '6', 5000, NULL, 0, '', '3', '636772887428407801.jpg', '636772887429746267.jpg', '636772910792728016.jpg', '636772910793560350.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:24:39', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (335, '3113934112', '2018-11-08 16:24:40', '2018-11-08 16:24:46', '', '6', '6', 2000, NULL, 0, '', '4', '636772910803192592.jpg', '636772910804387481.jpg', '636772910869714015.jpg', '636772910870757533.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:24:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (336, '3113934112', '2018-11-08 16:24:51', '2018-11-08 16:25:20', '789456', '6', '6', 2000, NULL, 0, '', '5', '636772910917023100.jpg', '636772910918269923.jpg', '636772911210990750.jpg', '636772911211853921.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:25:21', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (337, '3113934112', '2018-11-08 16:25:36', '2018-11-08 16:26:36', '471', '6', '6', 5000, NULL, 0, '', '6', '636772911360312985.jpg', '636772911361827592.jpg', '636772911963426881.jpg', '636772911964096199.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:26:36', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (338, '3113934112', '2018-11-08 16:26:43', '2018-11-08 16:26:56', '765', '6', '6', 2000, NULL, 0, '', '7', '636772912030866063.jpg', '636772912032528707.jpg', '636772912171159202.jpg', '636772912171962985.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:26:57', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (339, '3118244928', '2018-11-08 16:28:42', '2018-11-08 16:29:15', '444', '6', '6', 0, NULL, 0, '3118244928', '8', '636772913227144950.jpg', '636772913228388686.jpg', '636772913551760628.jpg', '636772913552566348.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:29:15', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (340, '3113934112', '2018-11-08 16:29:00', '2018-11-08 16:29:18', '', '6', '6', 2000, NULL, 0, '', '1', '636772913400774151.jpg', '636772913402097902.jpg', '636772913590777471.jpg', '636772913591577194.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:29:19', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (341, '3113934112', '2018-11-08 16:32:17', '2018-11-08 16:32:42', '111', '6', '6', 2000, NULL, 0, '', '1', '636772915376962364.jpg', '636772915378141285.jpg', '636772915630902404.jpg', '636772915631561732.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:32:43', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (342, '3118244928', '2018-11-08 16:32:28', '2018-11-08 16:32:56', '222', '6', '6', 0, NULL, 0, '3118244928', '2', '636772915486480255.jpg', '636772915487868990.jpg', '636772915765325027.jpg', '636772915766273822.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:32:56', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (343, '3113934112', '2018-11-08 16:32:53', '2018-11-08 16:33:33', '', '6', '6', 2000, NULL, 0, '', '3', '636772915731419602.jpg', '636772915732548482.jpg', '636772916142568609.jpg', '636772916143227921.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:33:34', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (344, '3118244928', '2018-11-08 16:33:19', '2018-11-08 16:33:22', '555555', '6', '6', 0, NULL, 0, '3118244928', '4', '636772915992502222.jpg', '636772915993710984.jpg', '636772916030533292.jpg', '636772916031192719.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:33:23', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (345, '3113934112', '2018-11-08 16:39:51', '2018-11-08 16:40:01', '', '6', '6', 2000, NULL, 0, '', '3', '636772919911497196.jpg', '636772919912739050.jpg', '636772920017738899.jpg', '636772920018440178.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:40:01', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (346, '3118244928', '2018-11-08 16:40:07', '2018-11-08 16:40:08', '555555', '6', '6', 0, NULL, 0, '3118244928', '4', '636772920078006651.jpg', '636772920079411523.jpg', '636772920088914190.jpg', '636772920093627160.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:40:09', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (347, '3118244928', '2018-11-08 16:40:12', '2018-11-08 16:40:17', '555555', '6', '6', 0, NULL, 0, '3118244928', '6', '636772920121137193.jpg', '636772920122104004.jpg', '636772920171659575.jpg', '636772920172471234.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-08 16:40:17', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (348, '3118244928', '2018-11-08 16:40:28', '2018-11-09 08:54:19', '555555', '6', '6', 0, NULL, 0, '3118244928', '6', '636772920282603057.jpg', '636772920283592477.jpg', '636773504599630035.jpg', '636773504600589079.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-09 08:54:20', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (349, '3113934112', '2018-11-08 16:57:18', '2018-11-09 09:47:50', '', '6', '6', 5000, NULL, 0, '', '7', '636772930386004927.jpg', '636772930387293611.jpg', '636773536704675309.jpg', '636773536705434388.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-09 09:47:50', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (350, '3118244928', '2018-11-09 08:54:33', '2018-11-15 11:28:32', '555555', '6', '3', 0, NULL, 0, '3118244928', '8', '636773504729389186.jpg', '636773504730617915.jpg', '636778781130549461.jpg', '636778781131158934.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-15 11:28:33', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (351, '3113934112', '2018-11-09 09:48:46', '2018-11-09 09:49:42', '666', '6', '6', 2000, NULL, 0, '', '8', '636773537259182596.jpg', '636773537260699556.jpg', '636773537824249921.jpg', '636773537825116800.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-09 09:49:42', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (352, '3113934112', '2018-11-09 09:50:31', '2018-11-09 09:50:48', '777', '6', '6', 2000, NULL, 0, '', '7', '636773538311473616.jpg', '636773538313243448.jpg', '636773538489316779.jpg', '636773538490659001.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-09 09:50:49', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (353, '3113934112', '2018-11-09 09:51:23', NULL, '888', '6', '6', 2000, NULL, 0, '', '6', '636773538833352865.jpg', '636773538834599438.jpg', '636773539161007090.jpg', '636773539162197580.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-09 09:51:56', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (354, '3118189600', '2018-11-14 14:24:28', '2018-11-14 14:24:34', '123456', '6', '6', 0, NULL, 0, '3118189600', '4', '636778022685251659.jpg', '636778022686220685.jpg', '636778022747538034.jpg', '636778022748027498.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-14 14:24:34', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (355, '3117202048', '2018-11-14 14:24:39', '2018-11-14 14:24:41', '', '6', '6', 2000, NULL, 0, '', '5', '636778022797297270.jpg', '636778022798276141.jpg', '636778022822061826.jpg', '636778022822541343.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-14 14:24:42', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (356, '3118189600', '2018-11-14 14:24:54', '2018-11-14 14:25:15', '123456', '6', '6', 0, NULL, 0, '3118189600', '2', '636778022943307915.jpg', '636778022944327001.jpg', '636778023156829661.jpg', '636778023157508974.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-14 14:25:15', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (357, '3117202048', '2018-11-14 14:24:57', '2018-11-14 14:25:11', '', '6', '6', 2000, NULL, 0, '', '2', '636778022973267546.jpg', '636778022974176517.jpg', '636778023112345149.jpg', '636778023113154303.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-14 14:25:11', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (358, '3117202048', '2018-11-14 14:32:41', '2018-11-14 14:33:32', '', '6', '6', 2000, NULL, 0, '', '3', '636778027610788657.jpg', '636778027611787764.jpg', '636778028130053972.jpg', '636778028130553455.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-14 14:33:33', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (359, '3118189600', '2018-11-14 14:33:25', '2018-11-14 14:59:42', '123456', '6', '6', 0, NULL, 0, '3118189600', '4', '636778028053262823.jpg', '636778028054271587.jpg', '636778043821607854.jpg', '636778043822257716.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-14 14:59:42', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (361, '3117202048', '2018-11-19 15:15:01', '2018-11-19 15:15:11', '', '6', '6', 2000, NULL, 0, '', '5', '636782373013962433.jpg', '636782373015031339.jpg', '636782373117296681.jpg', '636782373117796166.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-19 15:15:11', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (362, '3113934112', '2018-11-15 11:00:28', '2018-11-15 11:00:33', '', '3', '3', 2000, NULL, 0, '', '6', '636778764286873934.jpg', '636778764288272497.jpg', '636778764338915191.jpg', '636778764339414680.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-15 11:00:33', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (363, '3113934112', '2018-11-15 11:00:46', '2018-11-15 11:00:50', '', '3', '3', 2000, NULL, 0, '', '7', '636778764465165337.jpg', '636778764466334265.jpg', '636778764502467159.jpg', '636778764503795802.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-15 11:00:50', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (364, '3113934112', '2018-11-15 11:10:24', '2018-11-15 11:10:33', '', '3', '3', 2000, NULL, 0, '', '8', '636778770240000168.jpg', '636778770241638622.jpg', '636778770333285117.jpg', '636778770333794602.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-15 11:10:33', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (365, '3113934112', '2018-11-15 11:10:40', '2018-11-15 11:10:55', '', '3', '3', 2000, NULL, 0, '', '1', '636778770399196762.jpg', '636778770400365566.jpg', '636778770560361852.jpg', '636778770560861344.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-15 11:10:56', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (366, '3113934112', '2018-11-15 11:11:44', '2018-11-15 11:11:47', '', '3', '3', 2000, NULL, 0, '', '1', '636778771044048819.jpg', '636778771045217613.jpg', '636778771078014059.jpg', '636778771078523669.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-15 11:11:47', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (367, '3118244928', '2018-11-15 11:28:34', '2018-11-15 11:28:42', '555555', '3', '3', 0, NULL, 0, '3118244928', '2', '636778781139869916.jpg', '636778781141338417.jpg', '636778781237380128.jpg', '636778781238029617.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-15 11:28:43', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (368, '3118244928', '2018-11-15 11:28:45', '2018-11-15 11:29:32', '555555', '3', '3', 0, NULL, 0, '3118244928', '4', '636778781250406793.jpg', '636778781251236085.jpg', '636778781920576683.jpg', '636778781921405835.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-15 11:29:52', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (380, '3118189600', '2018-11-28 11:15:11', NULL, '123789', '6', '', 0, NULL, 0, '3118189600', '8', '636790005117980555.jpg', '636790005118819895.jpg', NULL, NULL, 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-28 11:15:11', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (369, '3113934112', '2018-11-15 11:28:59', '2018-11-15 11:29:00', '', '3', '3', 0, NULL, 0, '', '4', '636778781392950725.jpg', '636778781393949683.jpg', '636778781416246858.jpg', '636778781416746254.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-15 11:29:01', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (370, '3118244928', '2018-11-15 11:30:51', '2018-11-16 08:54:15', '555555', '3', '3', 0, NULL, 0, '3118244928', '6', '636778782511981476.jpg', '636778782512790815.jpg', '636779552570555708.jpg', '636779552571055200.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-16 08:54:17', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (371, '3113934112', '2018-11-16 08:54:06', '2018-11-16 08:54:08', '', '3', '3', 0, NULL, 0, '', '4', '636779552463510194.jpg', '636779552465258408.jpg', '636779552489373732.jpg', '636779552489863224.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-16 08:54:08', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (372, '3118244928', '2018-11-16 08:54:21', '2018-11-23 14:55:09', '555555', '3', '2', 0, NULL, 0, '3118244928', '4', '636779552609465894.jpg', '636779552610484851.jpg', '636779552670753374.jpg', '636779552671432682.jpg', 100000, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-23 14:55:09', '2018-11-23 14:55:09');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (373, '3113934112', '2018-11-16 08:56:18', '2018-11-16 08:56:28', '', '3', '3', 2000, NULL, 0, '', '6', '636779553788188586.jpg', '636779553789187182.jpg', '636779553890129807.jpg', '636779553890639420.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-16 08:56:29', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (374, '3113934112', '2018-11-16 08:58:41', '2018-11-16 08:58:44', '', '3', '3', 2000, NULL, 0, '', '7', '636779555212976814.jpg', '636779555213955812.jpg', '636779555247231764.jpg', '636779555247721256.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-16 08:58:44', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (375, '3113934112', '2018-11-16 08:59:24', '2018-11-16 08:59:25', '', '3', '3', 2000, NULL, 0, '', '8', '636779555645775129.jpg', '636779555646933988.jpg', '636779555758055309.jpg', '636779555758724617.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-16 08:59:35', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (376, '3113934112', '2018-11-16 09:00:26', '2018-11-16 09:04:09', '', '3', '3', 5000, NULL, 0, '', '8', '636779556268483012.jpg', '636779556269467085.jpg', '636779558740174220.jpg', '636779558741502857.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-16 09:04:34', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (377, '3113934112', '2018-11-16 09:04:40', '2018-11-16 09:04:50', '', '3', '3', 0, NULL, 0, '', '7', '636779558804908094.jpg', '636779558806656176.jpg', '636779559077759320.jpg', '636779559078428638.jpg', 0, 'WIN10-GIANGNT', NULL, '3', 0, '2018-11-16 09:05:07', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (381, '31181896003', '2018-11-28 11:15:26', NULL, '', '6', '', 0, NULL, 0, '', '1', '636790005266836279.jpg', '636790005267915138.jpg', NULL, NULL, 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-11-28 11:15:26', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (382, '114', '2018-12-04 11:54:52', NULL, '', '6', '', 0, NULL, 0, '', '2', '636795212927484407.jpg', '636795212928423581.jpg', NULL, NULL, 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-12-04 11:54:52', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (383, '3113963712', '2018-12-05 22:15:44', '2018-12-05 22:15:48', '', '6', '6', 2000, NULL, 0, '', '3', '636796449449152887.jpg', '636796449449972372.jpg', '636796449484565736.jpg', '636796449485065188.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-12-05 22:15:48', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (384, '3113963712', '2018-12-05 22:15:54', '2018-12-05 22:16:15', '', '6', '6', 2000, NULL, 0, '', '4', '636796449539170561.jpg', '636796449540059999.jpg', '636796449753637499.jpg', '636796449754157178.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-12-05 22:16:15', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (385, '3113934112', '2018-12-05 22:16:05', '2018-12-05 22:16:07', '111', '6', '6', 0, NULL, 0, '3113934112', '2', '636796449658130356.jpg', '636796449658969825.jpg', '636796449675510288.jpg', '636796449676169851.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-12-05 22:16:07', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (234, '0353401904', '2018-08-19 17:38:19', '2018-08-19 17:39:22', '', '6', '6', 5000, NULL, 0, '', '1', '636702970944640615.jpg', '636702970950874048.jpg', '636702971625195955.jpg', '636702971625365858.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:39:22', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (235, '0353401904', '2018-08-19 17:40:36', '2018-08-19 17:42:40', '', '6', '6', 5000, NULL, 0, '', '1', '636702972356855271.jpg', '636702972357115119.jpg', '636702973603239005.jpg', '636702973603408887.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:42:40', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (236, '0353401904', '2018-08-19 17:42:50', '2018-08-19 17:44:43', '', '6', '6', 5000, NULL, 0, '', '2', '636702973650602740.jpg', '636702973650772639.jpg', '636702974832315549.jpg', '636702974832485440.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:44:43', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (237, '0353401904', '2018-08-19 17:47:37', '2018-08-19 17:47:40', '', '6', '6', 5000, NULL, 0, '', '3', '636702976559098116.jpg', '636702976559357960.jpg', '636702976605205555.jpg', '636702976605375446.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:47:40', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (238, '0353401904', '2018-08-19 17:47:46', '2018-08-19 17:47:48', '', '6', '6', 5000, NULL, 0, '', '4', '636702976626793700.jpg', '636702976626968290.jpg', '636702976681344639.jpg', '636702976681524596.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:47:48', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (239, '0353401904', '2018-08-19 17:47:50', '2018-08-19 17:47:52', '', '6', '6', 5000, NULL, 0, '', '3', '636702976697905366.jpg', '636702976698085730.jpg', '636702976726523952.jpg', '636702976726691175.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:47:52', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (240, '0353401904', '2018-08-19 17:47:53', '2018-08-19 17:47:55', '', '6', '6', 5000, NULL, 0, '', '4', '636702976734385390.jpg', '636702976734558189.jpg', '636702976752628586.jpg', '636702976752798494.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:47:55', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (241, '0353401904', '2018-08-19 17:48:05', '2018-08-19 17:48:06', '', '6', '6', 5000, NULL, 0, '', '5', '636702976845657300.jpg', '636702976845827195.jpg', '636702976866579246.jpg', '636702976866749252.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:48:06', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (242, '0353401904', '2018-08-19 17:48:08', '2018-08-19 17:48:15', '', '6', '6', 5000, NULL, 0, '', '6', '636702976881807211.jpg', '636702976881987087.jpg', '636702976957296774.jpg', '636702976957466634.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:48:15', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (243, '0353401904', '2018-08-19 17:49:31', '2018-08-19 17:49:42', '', '6', '6', 5000, NULL, 0, '', '7', '636702977715895569.jpg', '636702977716125444.jpg', '636702977822717162.jpg', '636702977822887057.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:49:42', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (244, '0353401904', '2018-08-19 17:49:48', '2018-08-19 17:49:49', '', '6', '6', 5000, NULL, 0, '', '8', '636702977885657749.jpg', '636702977885817645.jpg', '636702977899709420.jpg', '636702977899889300.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:49:49', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (245, '0353401904', '2018-08-19 17:49:52', '2018-08-19 17:54:06', '', '6', '6', 5000, NULL, 0, '', '8', '636702977920110601.jpg', '636702977920280504.jpg', '636702980467094999.jpg', '636702980467254930.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:54:06', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (246, '0353401904', '2018-08-19 17:54:09', '2018-08-19 17:54:13', '', '6', '6', 5000, NULL, 0, '', '7', '636702980489849265.jpg', '636702980490013724.jpg', '636702980539880349.jpg', '636702980540040251.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:54:14', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (247, '0353401904', '2018-08-19 17:54:20', '2018-08-19 17:54:21', '', '6', '6', 5000, NULL, 0, '', '6', '636702980601292450.jpg', '636702980601462345.jpg', '636702980612174010.jpg', '636702980612333899.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:54:21', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (248, '0353401904', '2018-08-19 17:54:24', '2018-08-19 17:54:30', '', '6', '6', 5000, NULL, 0, '', '4', '636702980643131728.jpg', '636702980643291612.jpg', '636702980702033156.jpg', '636702980702214174.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:54:30', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (249, '0353401904', '2018-08-19 17:54:31', '2018-08-19 17:54:33', '', '6', '6', 5000, NULL, 0, '', '5', '636702980717926269.jpg', '636702980718086191.jpg', '636702980731157087.jpg', '636702980731327140.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:54:33', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (250, '0353401904', '2018-08-19 17:55:32', '2018-08-19 17:55:40', '', '6', '6', 5000, NULL, 0, '', '1', '636702981319593920.jpg', '636702981319813784.jpg', '636702981402647684.jpg', '636702981402817579.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:55:40', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (251, '0353401904', '2018-08-19 17:55:42', '2018-08-19 17:55:42', '', '6', '6', 5000, NULL, 0, '', '2', '636702981420559399.jpg', '636702981420719689.jpg', '636702981428757013.jpg', '636702981428926917.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 17:55:42', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (252, '3117202048', '2018-08-19 18:21:06', '2018-09-26 20:31:10', '', '6', '6', 386000, NULL, 0, '', '3', '636702996483792625.jpg', '636702996483892558.jpg', '636735906711697395.jpg', '636735906712427516.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-26 20:31:11', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (253, '0353401904', '2018-08-19 18:27:56', '2001-01-01 00:00:00', '', '6', '', 0, NULL, 0, '', '4', '636703000745645236.jpg', '636703000745885105.jpg', '', '', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-08-19 18:27:56', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (254, '3118189600', '2018-09-17 14:28:10', '2018-09-17 14:28:23', '', '6', '6', 3000, NULL, 0, '', '5', '636727912907898120.jpg', '636727912908075330.jpg', '636727913036941274.jpg', '636727913037108618.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-17 14:28:23', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (255, '3118189600', '2018-09-17 14:29:16', '2018-09-17 20:29:25', '', '6', '6', 15, NULL, 0, '', '6', '636727913563952900.jpg', '636727913564826136.jpg', '636728129659544234.jpg', '636728129659704067.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-17 20:29:26', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (257, '3118189600', '2018-09-17 14:33:28', '2018-09-17 20:33:37', '', '6', '6', 7000, NULL, 0, '', '7', '636727916084009794.jpg', '636727916084195556.jpg', '636728132176968192.jpg', '636728132177297582.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-17 20:33:37', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (258, '3118189600', '2018-09-17 20:33:45', '2018-09-19 20:33:55', '', '6', '6', 5000, NULL, 0, '', '8', '636728132250465631.jpg', '636728132250625461.jpg', '636729860353767528.jpg', '636729860353857561.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-19 20:33:55', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (259, '3118189600', '2018-09-19 20:40:29', '2018-09-21 20:40:40', '', '6', '6', 39500, NULL, 0, '', '1', '636729864296770288.jpg', '636729864297080502.jpg', '636731592405074286.jpg', '636731592405413938.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-21 20:40:40', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (260, '3118189600', '2018-09-17 16:18:13', '2018-09-17 16:18:15', '', '6', '6', 3000, NULL, 0, '', '1', '636727978936469552.jpg', '636727978936729286.jpg', '636727978956415662.jpg', '636727978956565502.jpg', 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-09-17 16:18:15', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (261, '3113934112', '2018-09-17 18:29:20', '2018-09-17 18:29:33', '', '6', '6', 3000, NULL, 0, '', '2', '636728057607978719.jpg', '636728057608128639.jpg', '636728057734793551.jpg', '636728057734963450.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-09-17 18:29:33', '2001-01-01 00:00:00');
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (386, '3113934112', '2018-12-05 22:16:19', NULL, '111', '6', '', 0, NULL, 0, '3113934112', '4', '636796449794054999.jpg', '636796449795014377.jpg', NULL, NULL, 0, 'TRUONGGIANG', NULL, '6', 0, '2018-12-05 22:16:19', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (387, '3113963712', '2018-12-05 22:16:30', '2018-12-05 22:16:36', '', '6', '6', 2000, NULL, 0, '', '7', '636796449907209068.jpg', '636796449908138759.jpg', '636796449963474386.jpg', '636796449963994732.jpg', 0, 'TRUONGGIANG', NULL, '6', 0, '2018-12-05 22:16:36', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (388, '111', '2018-12-07 14:32:09', NULL, '63H3-7132', '6', '', 0, NULL, 0, '111', '1', '636797899293559617.jpg', '636797899294648519.jpg', NULL, NULL, 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-12-07 14:32:09', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (389, '113', '2018-12-10 14:51:13', NULL, '????????', '6', '', 0, NULL, 0, '', '2', '636800502726881285.jpg', '636800502730038207.jpg', NULL, NULL, 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-12-10 14:51:13', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (390, '115', '2018-12-10 14:53:23', NULL, '', '6', '', 0, NULL, 0, '', '3', '636800504029457563.jpg', '636800504032944142.jpg', NULL, NULL, 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-12-10 14:53:23', NULL);
INSERT INTO `Car` (`Identify`, `ID`, `TimeStart`, `TimeEnd`, `Digit`, `IDIn`, `IDOut`, `Cost`, `Part`, `Seri`, `IDTicketMonth`, `IDPart`, `Images`, `Images2`, `Images3`, `Images4`, `IsLostCard`, `Computer`, `Note`, `Account`, `CostBefore`, `DateUpdate`, `DateLostCard`) VALUES (393, '500', '2018-12-19 11:45:35', NULL, '', '6', '', 0, NULL, 0, '', '1', '636808167350866642.jpg', '636808167357499920.jpg', NULL, NULL, 0, 'WIN10-GIANGNT', NULL, '6', 0, '2018-12-19 11:45:36', NULL);
# 368 records

#
# Table structure for table 'CardType'
#

DROP TABLE IF EXISTS `CardType`;

CREATE TABLE `CardType` (
  `CardTypeID` VARCHAR(255) NOT NULL, 
  `CardTypeName` VARCHAR(255), 
  PRIMARY KEY (`CardTypeID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'CardType'
#

INSERT INTO `CardType` (`CardTypeID`, `CardTypeName`) VALUES ('1', 'VeI? thAÅãA!I?ng');
INSERT INTO `CardType` (`CardTypeID`, `CardTypeName`) VALUES ('2', 'VeI? thaI?ng');
# 2 records

#
# Table structure for table 'Computer'
#

DROP TABLE IF EXISTS `Computer`;

CREATE TABLE `Computer` (
  `Identify` INTEGER NOT NULL AUTO_INCREMENT, 
  `IDPart` VARCHAR(255), 
  `ParkingTypeID` INTEGER DEFAULT 0, 
  `DayCost` INTEGER DEFAULT 0, 
  `NightCost` INTEGER DEFAULT 0, 
  `DayNightCost` INTEGER DEFAULT 0, 
  `IntervalBetweenDayNight` INTEGER DEFAULT 0, 
  `StartHourNight` INTEGER DEFAULT 0, 
  `EndHourNight` INTEGER DEFAULT 0, 
  `HourMilestone1` INTEGER DEFAULT 0, 
  `HourMilestone2` INTEGER DEFAULT 0, 
  `HourMilestone3` INTEGER DEFAULT 0, 
  `CostMilestone1` INTEGER DEFAULT 0, 
  `CostMilestone2` INTEGER DEFAULT 0, 
  `CostMilestone3` INTEGER DEFAULT 0, 
  `CycleMilestone3` INTEGER DEFAULT 0, 
  `IsAdd` VARCHAR(255), 
  `CycleTicketMonth` INTEGER DEFAULT 0, 
  `CostTicketMonth` INTEGER DEFAULT 0, 
  `MinMinute` INTEGER DEFAULT 0, 
  `MinCost` INTEGER DEFAULT 0, 
  INDEX (`IDPart`), 
  INDEX (`ParkingTypeID`), 
  PRIMARY KEY (`Identify`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'Computer'
#

INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (1, '1', 1, 5000, 6000, 10000, 2, 18, 5, 0, 0, 0, 0, 0, 0, 0, 'NULL', 13, 6000, 1, 2000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (2, '2', 1, 4000, 5000, 9000, 6, 19, 23, 0, 0, 0, 0, 0, 0, 0, 'NULL', 12, 5000, 1, 2000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (3, '3', 1, 4000, 5000, 9000, 6, 20, 22, 0, 0, 0, 0, 0, 0, 0, 'NULL', 12, 5000, 1, 2000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (4, '1', 2, 0, 0, 0, 0, 0, 0, 5, 10, 0, 3000, 4000, 5000, 10, '1', 15, 5000, 1, 2000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (5, '2', 2, 0, 0, 0, 0, 0, 0, 5, 9, 0, 5000, 6000, 8000, 5, '2', 12, 5000, 1, 2000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (6, '3', 2, 0, 0, 0, 0, 0, 0, 5, 9, 0, 6000, 7000, 9000, 5, '1', 12, 5000, 1, 2000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (7, '1', 3, 0, 6000, 0, 0, 19, 1, 7, 11, 0, 6000, 7000, 8000, 15, '2', 10, 6000, 1, 2000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (8, '2', 3, 0, 6000, 0, 0, 19, 23, 5, 9, 0, 5000, 6000, 8000, 5, '1', 12, 5000, 1, 2000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (9, '3', 3, 0, 7000, 0, 0, 20, 22, 5, 9, 0, 6000, 7000, 9000, 5, '1', 12, 5000, 1, 2000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (16, '5', 2, 0, 0, 0, 0, 0, 0, 4, 6, 0, 2000, 8000, 7000, 5, '2', 10, 4000, 0, 0);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (17, '5', 1, 3000, 11000, 15000, 14, 10, 5, 0, 0, 0, 0, 0, 0, 0, '', 7, 14000, 3000, 3000);
INSERT INTO `Computer` (`Identify`, `IDPart`, `ParkingTypeID`, `DayCost`, `NightCost`, `DayNightCost`, `IntervalBetweenDayNight`, `StartHourNight`, `EndHourNight`, `HourMilestone1`, `HourMilestone2`, `HourMilestone3`, `CostMilestone1`, `CostMilestone2`, `CostMilestone3`, `CycleMilestone3`, `IsAdd`, `CycleTicketMonth`, `CostTicketMonth`, `MinMinute`, `MinCost`) VALUES (18, '5', 3, 0, 3000, 0, 0, 11, 4, 4, 7, 0, 5000, 7000, 3000, 5, '1', 15, 6000, 0, 0);
# 12 records

#
# Table structure for table 'Config'
#

DROP TABLE IF EXISTS `Config`;

CREATE TABLE `Config` (
  `Kind` VARCHAR(255), 
  `Title` LONGTEXT, 
  `IsEmSaveLostTicket` TINYINT(1) DEFAULT 0, 
  `IsSeeReport` TINYINT(1) DEFAULT 0, 
  `NumberOfDay` INTEGER DEFAULT 0, 
  `IsGetMoneyTicket` TINYINT(1) DEFAULT 0, 
  `LostCard` INTEGER DEFAULT 0, 
  `BikeSpace` INTEGER DEFAULT 0, 
  `CarSpace` INTEGER DEFAULT 0, 
  `TicketLimitDay` INTEGER DEFAULT 0, 
  `Logo` VARCHAR(255), 
  `NightLimit` INTEGER DEFAULT 0, 
  `TitleReport` LONGTEXT, 
  `ParkingTypeID` INTEGER DEFAULT 0, 
  `Camera1` VARCHAR(255), 
  `Camera2` VARCHAR(255), 
  `Camera3` VARCHAR(255), 
  `Camera4` VARCHAR(255), 
  `RFID1` VARCHAR(255), 
  `RFID2` VARCHAR(255), 
  `InOutType` INTEGER DEFAULT 0, 
  `ExpiredTicketMonthTypeID` INTEGER DEFAULT 0, 
  INDEX (`ExpiredTicketMonthTypeID`), 
  INDEX (`NumberOfDay`), 
  INDEX (`ParkingTypeID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'Config'
#

INSERT INTO `Config` (`Kind`, `Title`, `IsEmSaveLostTicket`, `IsSeeReport`, `NumberOfDay`, `IsGetMoneyTicket`, `LostCard`, `BikeSpace`, `CarSpace`, `TicketLimitDay`, `Logo`, `NightLimit`, `TitleReport`, `ParkingTypeID`, `Camera1`, `Camera2`, `Camera3`, `Camera4`, `RFID1`, `RFID2`, `InOutType`, `ExpiredTicketMonthTypeID`) VALUES (NULL, NULL, 0, 0, 0, 0, 0, 1000, 500, 5005, NULL, 4005, NULL, 1, 'rtsp://admin:bmv333999@192.168.1.190:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif', 'rtsp://admin:bmv333999@192.168.1.190:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif', 'rtsp://admin:bmv333999@192.168.1.190:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif', 'rtsp://admin:bmv333999@192.168.1.190:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif', '\\\\?\\HID#VID_046D&PID_C31C&MI_00#7&3228570&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}', '\\\\?\\HID#VID_046D&PID_C31C&MI_00#7&3228570&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}', 3, 0);
# 1 records

#
# Table structure for table 'ExpiredTicketMonthType'
#

DROP TABLE IF EXISTS `ExpiredTicketMonthType`;

CREATE TABLE `ExpiredTicketMonthType` (
  `ExpiredTicketMonthTypeID` INTEGER NOT NULL DEFAULT 0, 
  `ExpiredTicketMonthTypeName` VARCHAR(255), 
  PRIMARY KEY (`ExpiredTicketMonthTypeID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'ExpiredTicketMonthType'
#

INSERT INTO `ExpiredTicketMonthType` (`ExpiredTicketMonthTypeID`, `ExpiredTicketMonthTypeName`) VALUES (0, 'TiI?nh tiAaI?n nhAÅã vaI?ng lai');
INSERT INTO `ExpiredTicketMonthType` (`ExpiredTicketMonthTypeID`, `ExpiredTicketMonthTypeName`) VALUES (1, 'ChiIÅÒ caIÅÒnh baI?o hAaI?t haIÅín');
# 2 records

#
# Table structure for table 'Functional'
#

DROP TABLE IF EXISTS `Functional`;

CREATE TABLE `Functional` (
  `FunctionID` VARCHAR(255) NOT NULL, 
  `FunctionName` VARCHAR(255), 
  `FunctionSec` VARCHAR(255), 
  PRIMARY KEY (`FunctionID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'Functional'
#

INSERT INTO `Functional` (`FunctionID`, `FunctionName`, `FunctionSec`) VALUES ('Ad', 'Admin', '1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22');
INSERT INTO `Functional` (`FunctionID`, `FunctionName`, `FunctionSec`) VALUES ('Ca', 'Ca trAÅãA!IÅÒng', '3,5,6,7,13,14,15,16,17,18,19,20');
INSERT INTO `Functional` (`FunctionID`, `FunctionName`, `FunctionSec`) VALUES ('Ke', 'KAaI? toaI?n', '4');
INSERT INTO `Functional` (`FunctionID`, `FunctionName`, `FunctionSec`) VALUES ('Nh', 'NhAÅën viAan', '12,21,22');
INSERT INTO `Functional` (`FunctionID`, `FunctionName`, `FunctionSec`) VALUES ('Qu', 'QuaIÅÒn lyI?', '1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22');
# 5 records

#
# Table structure for table 'Log'
#

DROP TABLE IF EXISTS `Log`;

CREATE TABLE `Log` (
  `Identify` INTEGER NOT NULL AUTO_INCREMENT, 
  `LogTypeID` INTEGER DEFAULT 0, 
  `LogNote` LONGTEXT, 
  `Account` VARCHAR(255), 
  `ProcessDate` DATETIME, 
  `Computer` VARCHAR(255), 
  INDEX (`LogTypeID`), 
  PRIMARY KEY (`Identify`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'Log'
#

INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-29 13:35:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-29 13:37:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (3, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-03-29 13:37:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (4, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-03-29 13:37:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (5, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-03-29 13:37:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (6, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-29 13:41:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (7, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-03-29 13:42:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (8, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-29 14:01:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (9, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-29 14:01:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (10, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-03-29 14:02:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (11, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-29 14:05:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (12, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-29 14:14:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (13, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-29 14:15:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (14, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-29 14:47:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (15, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-29 14:49:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (16, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 09:58:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (17, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:36:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (18, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:37:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (19, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:37:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (20, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:37:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (21, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:38:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (22, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:38:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (23, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:39:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (24, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:39:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (25, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:39:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (26, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-03-30 13:39:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (27, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 14:24:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (28, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-03-30 14:24:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (29, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 14:28:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (30, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-03-30 14:28:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (31, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 14:32:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (32, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-03-30 14:32:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (33, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-03-30 14:47:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (34, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-30 14:47:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (35, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-30 14:49:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (36, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-30 16:40:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (37, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-03-30 16:41:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (38, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-30 16:59:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (39, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-03-30 16:59:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (40, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-03-30 17:06:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (41, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-03-30 17:07:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (42, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-03-30 17:15:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (43, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-03-30 17:16:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (44, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-02 17:43:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (45, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-02 17:45:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (46, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-03 10:08:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (47, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 11:05:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (48, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 11:06:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (49, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 11:08:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (50, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 11:11:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (51, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 11:12:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (52, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 14:28:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (53, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 14:28:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (54, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-03 14:28:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (55, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 14:47:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (56, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-03 14:47:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (57, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 14:52:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (58, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 14:53:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (59, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-03 14:56:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (60, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-03 16:55:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (61, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-03 16:56:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (62, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-04 10:14:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (63, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 10:29:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (64, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 10:29:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (65, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 10:32:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (66, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 10:33:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (67, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 10:34:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (68, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-04 10:34:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (69, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 13:45:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (70, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-04 13:45:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (71, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-04 13:46:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (72, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 13:47:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (73, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 15:15:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (74, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 15:20:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (75, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-04 15:21:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (76, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-04 15:23:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (77, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 15:33:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (78, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-04 15:52:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (118, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:53:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (119, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:53:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (120, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:56:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (121, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:56:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (122, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:01:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (123, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:01:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (124, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:17:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (125, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:17:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (126, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:19:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (127, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:19:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (128, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:52:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (129, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:52:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (130, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:54:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (131, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:54:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (132, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:56:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (133, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:56:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (134, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:57:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (135, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 15:57:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (136, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 13:08:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (137, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 13:38:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (138, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 13:38:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (139, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-10 13:39:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (140, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 13:39:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (141, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 13:55:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (142, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 13:57:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (143, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 13:58:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (144, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-10 13:59:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (145, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:00:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (146, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:08:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (147, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:12:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (148, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:12:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (149, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-10 14:14:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (150, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:15:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (151, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:17:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (152, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:42:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (153, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:42:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (154, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:43:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (155, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:44:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (156, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:44:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (157, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:45:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (158, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:45:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (159, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:48:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (160, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:50:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (161, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:55:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (162, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-10 14:55:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (163, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-10 16:59:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (164, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 10:36:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (165, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-11 10:39:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (166, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 11:02:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (167, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-11 11:02:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (168, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 11:04:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (169, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 11:12:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (170, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-11 11:13:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (171, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 11:14:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (172, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-11 11:16:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (173, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 11:16:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (174, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 16:57:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (175, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 16:59:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (176, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 17:01:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (177, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 17:04:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (178, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-11 17:05:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (179, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-11 17:06:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (180, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-11 17:07:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (181, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 08:50:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (182, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-12 08:51:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (183, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 09:14:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (184, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-12 09:15:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (185, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 09:26:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (186, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 09:37:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (187, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-12 10:04:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (188, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-12 10:22:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (189, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-12 10:23:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (190, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-12 10:25:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (191, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 11:22:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (192, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-12 11:24:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (193, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 11:25:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (194, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-12 11:26:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (195, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 11:27:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (196, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-12 11:28:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (197, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 11:44:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (198, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 15:05:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (199, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-12 15:13:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (200, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 15:16:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (201, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-12 15:17:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (202, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 15:34:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (203, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-12 15:35:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (204, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 16:05:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (205, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 16:06:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (206, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-12 16:19:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (207, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-12 16:20:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (208, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 11:24:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (209, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 11:25:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (210, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 11:26:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (211, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 11:27:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (212, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 11:29:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (213, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 11:38:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (214, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 11:39:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (215, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 11:39:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (216, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 11:40:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (217, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 13:08:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (218, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-16 13:23:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (219, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-16 13:23:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (220, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:23:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (221, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:23:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (222, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:23:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (223, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:24:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (224, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:27:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (225, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:28:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (226, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:28:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (227, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:28:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (228, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:30:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (229, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:30:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (230, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:30:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (231, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:31:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (232, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:33:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (233, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:33:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (234, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:40:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (274, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 10:30:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (275, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 10:30:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (276, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 10:33:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (277, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 10:35:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (278, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 10:44:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (279, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 10:48:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (280, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 11:00:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (281, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 11:02:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (282, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 11:04:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (283, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:21:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (284, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:24:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (285, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:25:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (286, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:28:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (287, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:31:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (288, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:34:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (289, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:35:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (290, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:37:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (291, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:37:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (292, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:38:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (293, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:38:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (294, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:39:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (295, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 13:39:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (296, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 13:39:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (297, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-17 13:39:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (298, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 13:41:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (299, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 13:42:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (300, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-17 13:43:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (301, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 13:45:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (302, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-17 13:45:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (303, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 13:46:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (304, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-17 13:46:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (305, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 14:01:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (306, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-17 14:01:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (307, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 14:01:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (308, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 14:23:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (309, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 14:24:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (310, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 14:24:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (311, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 14:25:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (312, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 14:25:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (79, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-04 15:56:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (80, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-04 15:56:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (81, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-04 16:08:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (82, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 16:23:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (83, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-04 16:24:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (84, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-04 16:25:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (85, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-04 16:25:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (86, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-04 16:26:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (87, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-04 16:27:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (88, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-04 16:33:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (89, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-06 09:30:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (90, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-06 09:31:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (91, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-06 09:33:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (92, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-06 09:33:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (93, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-06 09:41:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (94, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-06 10:00:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (95, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 09:01:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (96, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 09:01:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (97, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 09:21:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (98, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 09:25:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (99, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 09:26:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (100, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-09 09:32:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (101, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 09:32:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (102, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 09:33:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (103, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 10:20:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (104, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 10:22:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (105, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 10:24:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (106, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 10:24:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (107, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 13:51:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (108, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:40:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (109, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:40:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (110, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:41:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (111, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:41:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (112, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:42:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (113, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-09 14:44:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (114, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:50:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (115, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:50:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (116, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:51:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (117, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-09 14:51:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (235, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:40:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (236, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:41:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (237, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:42:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (238, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:43:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (239, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:44:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (240, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:44:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (241, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:53:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (242, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:54:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (243, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:55:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (244, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-16 13:56:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (245, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:57:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (246, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 13:59:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (247, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:00:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (248, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:03:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (249, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:09:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (250, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:10:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (251, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:15:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (252, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:25:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (253, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:26:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (254, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:26:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (255, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:26:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (256, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:27:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (257, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:27:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (258, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:28:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (259, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:37:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (260, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:37:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (261, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 14:38:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (262, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:36:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (263, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:36:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (264, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:38:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (265, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:38:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (266, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:40:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (267, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:40:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (268, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:40:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (269, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:48:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (270, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:57:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (271, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 16:57:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (272, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-16 17:05:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (273, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-16 17:05:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (313, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 14:27:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (314, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 14:27:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (315, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 15:10:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (316, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-17 15:10:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (317, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 15:40:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (318, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 15:40:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (319, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 15:42:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (320, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 15:50:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (321, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 15:51:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (322, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 15:52:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (323, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 15:52:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (324, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-17 15:53:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (325, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 15:56:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (326, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-17 15:56:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (327, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-04-17 15:56:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (328, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-04-17 15:57:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (329, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 16:13:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (330, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 16:15:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (331, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 16:18:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (332, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 16:18:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (333, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-04-17 16:21:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (334, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-04-17 16:24:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (335, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-17 16:49:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (336, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-17 16:50:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (337, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-04-17 16:57:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (338, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-04-24 15:28:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (339, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-04-24 15:54:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (340, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 10:45:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (341, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 11:23:41', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (342, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 11:27:24', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (343, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 11:29:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (344, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 11:42:34', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (345, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 11:44:53', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (346, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 11:46:00', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (347, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 11:49:11', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (348, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:28:30', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (349, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:30:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (350, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:31:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (351, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:38:00', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (352, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:42:11', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (353, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:43:37', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (354, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:44:34', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (355, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:51:02', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (356, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:54:55', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (357, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:55:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (358, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:57:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (359, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 13:58:34', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (360, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 14:00:07', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (361, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 14:00:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (362, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 14:02:34', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (363, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 14:04:26', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (364, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 14:10:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (365, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 14:13:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (366, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-07-08 14:31:58', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (367, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 14:54:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (368, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 14:59:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (369, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-08 15:05:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (370, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 15:05:25', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (371, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-08 15:06:41', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (372, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 15:06:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (373, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-08 15:08:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (374, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 15:08:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (375, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-08 15:08:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (376, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-08 15:11:20', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (377, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-08 15:11:34', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (378, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-07-15 12:23:21', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (379, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:24:39', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (380, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:25:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (381, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:25:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (382, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:26:27', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (383, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:26:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (384, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:28:00', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (385, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:28:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (386, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:42:53', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (387, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:43:30', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (388, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:45:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (389, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:46:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (390, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:48:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (391, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:48:29', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (392, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:55:14', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (393, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:55:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (394, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 12:57:46', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (395, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:09:54', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (396, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:10:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (397, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:17:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (398, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:19:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (399, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:20:46', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (400, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:21:54', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (401, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:22:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (402, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:35:30', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (403, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-07-15 13:35:38', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (404, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:36:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (405, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:36:56', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (406, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:39:39', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (407, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:40:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (408, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:40:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (409, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:41:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (410, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:43:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (411, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:45:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (412, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-07-15 13:45:50', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (413, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-07-15 13:49:24', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (414, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:51:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (415, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:52:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (416, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:52:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (417, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:52:21', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (418, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-07-15 13:52:24', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (419, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-07-15 13:53:26', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (420, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-07-15 13:53:34', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (421, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-07-15 13:53:38', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (422, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:53:41', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (423, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:54:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (424, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:54:50', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (425, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:55:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (426, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:55:20', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (427, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 13:55:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (428, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-07-15 13:57:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (429, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-07-15 13:57:37', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (430, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-07-15 14:02:41', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (431, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-07-15 14:03:43', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (432, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 14:03:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (433, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 14:04:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (434, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 14:04:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (435, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 14:05:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (436, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 14:07:37', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (437, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 14:09:38', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (438, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 14:10:40', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (439, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-15 14:11:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (440, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-15 14:12:18', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (441, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-07-15 14:12:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (442, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-07-15 14:12:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (443, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-17 22:32:41', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (444, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-17 22:34:05', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (445, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-17 22:42:33', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (446, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-17 22:42:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (447, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-17 22:48:52', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (448, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-17 22:49:40', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (449, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-17 22:49:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (450, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-17 23:03:01', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (451, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-17 23:11:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (452, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-17 23:19:08', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (453, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-17 23:31:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (454, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-17 23:32:35', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (455, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-24 22:26:21', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (456, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-24 22:27:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (457, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-24 22:31:46', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (458, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-24 22:31:58', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (459, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-07-24 22:32:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (460, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-07-24 22:32:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (461, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-07-24 22:32:40', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (462, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:33:09', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (463, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:33:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (464, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:33:56', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (465, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:35:02', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (466, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:37:40', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (467, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:37:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (468, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:39:18', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (469, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:40:18', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (470, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:40:26', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (471, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:40:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (472, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:41:01', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (473, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:41:42', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (474, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:41:55', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (475, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:44:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (476, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-07-26 21:44:42', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (477, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-02 21:30:40', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (478, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-02 21:30:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (479, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-02 22:05:40', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (480, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-02 22:05:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (481, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-02 22:12:42', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (482, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-02 22:12:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (483, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 21:33:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (484, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 21:33:50', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (485, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 21:53:02', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (486, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 21:53:08', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (487, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:06:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (488, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:06:52', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (489, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:11:14', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (490, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:11:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (491, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:12:07', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (492, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:13:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (493, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:13:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (494, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:13:52', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (495, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:15:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (496, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:16:02', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (497, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-08-06 22:18:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (498, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:19:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (499, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:19:11', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (500, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:32:12', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (501, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:32:22', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (502, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:32:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (503, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:32:53', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (504, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:34:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (505, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:39:24', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (506, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:39:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (507, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:40:09', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (508, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:40:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (509, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:40:36', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (510, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:40:43', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (511, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-08-06 22:41:35', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (512, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:42:33', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (513, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-06 22:42:36', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (514, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-08-06 22:43:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (515, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-17 22:54:36', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (516, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-17 22:55:09', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (517, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-17 23:00:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (518, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-17 23:02:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (519, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-17 23:02:54', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (520, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-17 23:08:41', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (521, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 10:11:20', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (522, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 10:13:53', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (523, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 10:16:58', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (524, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 10:17:29', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (525, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-08-18 11:30:26', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (526, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '5', '2018-08-18 11:38:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (527, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 11:38:36', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (528, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 11:39:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (529, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 15:50:30', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (530, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 15:52:56', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (531, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-18 15:53:27', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (532, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 15:54:02', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (533, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-18 15:54:42', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (534, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 18:56:20', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (535, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 19:54:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (536, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 19:57:29', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (537, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-18 19:57:36', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (538, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 19:58:09', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (539, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 22:07:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (540, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 22:09:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (541, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-18 22:09:11', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (542, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 22:13:27', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (543, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-18 22:13:36', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (544, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 22:13:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (545, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-18 22:31:55', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (546, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:26:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (547, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:29:14', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (548, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:32:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (549, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:35:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (550, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:37:55', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (551, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:38:42', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (552, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:38:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (553, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:38:58', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (554, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:53:16', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (555, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:53:42', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (556, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:54:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (557, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:54:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (558, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:55:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (559, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:56:38', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (560, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:57:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (561, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:57:11', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (562, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:57:28', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (563, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:58:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (564, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:58:16', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (565, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 07:59:52', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (566, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:01:08', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (567, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:06:01', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (568, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:07:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (569, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-08-19 08:07:14', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (570, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-08-19 08:26:43', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (571, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-08-19 08:30:05', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (572, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:30:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (573, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:31:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (574, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:32:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (575, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:34:11', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (576, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:34:43', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (577, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:35:01', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (578, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:35:55', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (579, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:47:14', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (580, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:47:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (581, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:48:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (582, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:48:29', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (583, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:49:02', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (584, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:50:02', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (585, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:50:58', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (586, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:51:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (587, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:51:41', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (588, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:51:53', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (589, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:52:05', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (590, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:52:28', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (591, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:53:18', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (592, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:53:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (593, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:54:08', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (594, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:54:56', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (595, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:58:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (596, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 08:58:35', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (597, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-08-19 09:01:28', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (598, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-08-19 09:03:26', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (599, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-08-19 09:03:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (600, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 09:03:55', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (601, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 09:04:07', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (602, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 09:04:25', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (603, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-08-19 11:12:43', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (604, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-08-19 11:13:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (605, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 11:13:28', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (606, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 11:13:52', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (607, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 12:04:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (608, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 12:04:26', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (609, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-08-19 12:04:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (610, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-08-19 12:05:14', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (611, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-08-19 12:08:05', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (612, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-08-19 12:08:39', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (613, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 15:57:29', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (614, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 15:57:43', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (615, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-08-19 15:57:46', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (616, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-08-19 15:57:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (617, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 15:58:02', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (618, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 15:59:27', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (619, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 15:59:35', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (620, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:09:07', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (621, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:12:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (622, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:13:42', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (623, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:19:30', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (624, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:21:05', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (625, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:21:25', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (626, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:22:00', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (627, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:22:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (628, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:23:43', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (629, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:34:55', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (630, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:35:38', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (631, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:36:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (632, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:36:12', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (633, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:43:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (634, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:45:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (635, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:53:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (636, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 16:54:20', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (637, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:00:12', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (638, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:01:07', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (639, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:26:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (640, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:26:50', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (641, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:26:58', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (642, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:27:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (643, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:29:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (644, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:31:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (645, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:34:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (646, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:35:11', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (647, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:40:27', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (648, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:42:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (649, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:44:09', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (650, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:44:12', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (651, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:44:21', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (652, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:47:21', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (653, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:48:20', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (654, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:48:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (655, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:49:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (656, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:53:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (657, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:54:37', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (658, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:54:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (659, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 17:55:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (660, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-08-19 18:07:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (661, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-08-19 18:13:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (662, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-08-19 18:14:50', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (663, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:18:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (664, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:19:53', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (665, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:20:29', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (666, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:21:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (667, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:27:50', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (668, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:27:58', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (669, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:28:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (670, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:29:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (671, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-08-19 18:36:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (672, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:45:30', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (673, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:46:21', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (674, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-08-19 18:46:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (675, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 10:09:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (676, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 10:10:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (677, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 10:56:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (678, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 10:58:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (679, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 10:58:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (680, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 14:24:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (681, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 14:25:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (682, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-17 14:25:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (683, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-17 14:25:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (684, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 14:25:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (685, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 14:26:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (686, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-17 14:26:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (687, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-17 14:26:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (688, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-17 14:27:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (689, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-17 20:32:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (690, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-09-19 20:36:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (691, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-19 20:40:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (692, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 15:22:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (693, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 15:22:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (694, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 15:39:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (695, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 15:39:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (696, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:10:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (697, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:10:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (698, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:10:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (699, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:10:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (700, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:11:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (701, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:11:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (702, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:12:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (703, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:12:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (704, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:13:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (705, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:13:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (706, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:13:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (707, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:13:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (708, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-09-17 16:14:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (709, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:14:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (710, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:15:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (711, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:15:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (712, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:15:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (713, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-17 16:18:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (714, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-17 16:18:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (715, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:50:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (716, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:51:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (717, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:52:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (718, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:53:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (719, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 16:54:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (720, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:06:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (721, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:07:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (722, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:24:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (723, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:25:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (724, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:36:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (725, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:37:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (726, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:37:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (727, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:39:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (728, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:41:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (729, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:42:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (730, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:42:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (731, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 17:43:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (732, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-17 18:24:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (733, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-17 18:26:24', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (734, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 18:26:30', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (735, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 18:28:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (736, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-17 18:28:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (737, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-17 23:35:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (738, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-17 23:35:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (739, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-17 23:36:27', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (740, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-17 23:36:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (741, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-23 20:28:43', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (742, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-23 20:31:25', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (743, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-25 08:37:53', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (744, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-25 08:40:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (745, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-28 08:46:41', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (746, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-28 20:50:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (747, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 09:07:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (748, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 09:22:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (749, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 09:27:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (750, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 09:29:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (751, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 09:30:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (752, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 09:53:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (753, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 09:55:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (754, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 10:22:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (755, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 10:31:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (756, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 10:32:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (757, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 10:33:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (758, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 10:37:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (759, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 10:38:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (760, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-18 10:38:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (761, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-18 10:38:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (762, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 10:57:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (763, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 10:57:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (764, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:01:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (765, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:02:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (766, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:15:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (767, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:15:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (768, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:16:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (769, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:16:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (770, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:17:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (771, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:19:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (772, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:22:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (773, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:25:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (774, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:27:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (775, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:27:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (776, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:29:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (777, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:33:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (778, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 11:33:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (779, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 13:33:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (780, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 13:41:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (781, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 13:43:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (782, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 13:45:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (783, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 13:57:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (784, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 13:59:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (785, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 14:00:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (786, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 14:05:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (787, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 14:06:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (788, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-18 14:15:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (789, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-18 14:16:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (790, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 10:29:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (791, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:07:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (792, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:07:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (793, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:08:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (794, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:08:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (795, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:08:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (796, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:09:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (797, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:10:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (798, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:17:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (799, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:20:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (800, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:28:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (801, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:29:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (802, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:29:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (803, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:30:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (804, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:37:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (805, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:38:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (806, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:41:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (807, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:44:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (808, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:57:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (809, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-19 11:58:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (810, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 15:45:22', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (811, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-22 15:45:38', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (812, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 15:45:46', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (813, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 15:46:08', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (814, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 15:47:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (815, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 15:54:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (816, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 15:56:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (817, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:04:12', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (818, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:04:25', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (819, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:08:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (820, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:09:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (821, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:13:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (822, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:13:43', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (823, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:21:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (824, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:21:52', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (825, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:21:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (826, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:23:37', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (827, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:23:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (828, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:25:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (829, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:29:58', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (830, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:38:11', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (831, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:38:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (832, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:38:36', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (833, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:39:16', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (834, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:39:41', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (835, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:42:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (836, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:42:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (837, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:42:55', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (838, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:43:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (839, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-09-22 16:44:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (840, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:45:36', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (841, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:46:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (842, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-09-22 16:46:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (843, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:51:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (844, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:53:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (845, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:57:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (846, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:57:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (847, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:57:50', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (848, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 16:57:55', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (849, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 16:57:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (850, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:14:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (851, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:14:28', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (852, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:14:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (853, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:14:36', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (854, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-22 17:16:18', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (855, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-22 17:17:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (856, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:19:22', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (857, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:20:00', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (858, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:21:09', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (859, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:21:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (860, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:23:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (861, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-09-22 17:24:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (862, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:24:46', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (863, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:25:27', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (864, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:25:58', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (865, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:26:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (866, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:26:24', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (867, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:27:05', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (868, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:27:08', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (869, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-22 17:28:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (870, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-23 08:32:34', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (871, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-23 08:32:53', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (872, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-23 08:43:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (873, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-23 08:43:40', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (874, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-23 08:47:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (875, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-23 08:48:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (876, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-23 08:49:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (877, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-23 08:51:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (878, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-24 15:08:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (879, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-24 15:09:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (880, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-24 15:09:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (881, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-24 15:23:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (882, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-24 15:25:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (883, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-24 15:25:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (884, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-24 15:25:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (885, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-24 15:26:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (886, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-24 15:26:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (887, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-24 16:13:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (888, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-25 14:12:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (889, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-25 14:12:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (890, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-25 14:12:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (891, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-25 14:17:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (892, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-25 14:22:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (893, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-25 14:55:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (894, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-25 14:56:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (895, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-25 14:56:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (896, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-25 14:56:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (897, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-25 14:57:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (898, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-25 14:57:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (899, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-25 15:08:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (900, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-25 15:11:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (901, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-25 15:26:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (902, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-25 15:27:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (903, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-25 15:27:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (904, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-25 15:28:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (905, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-25 15:28:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (906, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-25 15:28:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (907, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-25 15:31:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (908, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-25 15:32:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (909, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-26 20:29:15', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (910, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-26 20:30:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (911, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 20:30:37', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (912, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 20:32:44', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (913, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-26 20:47:12', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (914, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-26 20:50:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (915, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-26 20:52:09', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (916, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-26 20:57:26', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (917, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:06:29', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (918, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:06:57', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (919, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:07:45', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (920, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:09:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (921, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:12:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (922, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:12:23', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (923, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:13:34', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (924, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:17:17', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (925, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:19:28', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (926, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:20:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (927, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:36:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (928, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:37:00', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (929, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:38:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (930, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:38:08', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (931, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:38:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (932, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:38:20', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (933, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:38:38', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (934, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:38:38', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (935, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:39:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (936, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-26 21:40:16', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (937, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-26 21:40:16', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (938, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-26 21:40:16', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (939, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:42:33', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (940, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:42:46', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (941, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:42:46', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (942, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-26 21:43:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (943, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-26 21:43:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (944, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-26 21:43:09', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (945, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-09-26 21:43:19', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (946, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-09-26 21:43:22', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (947, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:43:27', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (948, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:43:35', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (949, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:43:40', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (950, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:45:51', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (951, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:46:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (952, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:46:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (953, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:46:29', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (954, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-09-26 21:46:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (955, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-01 13:12:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (956, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 13:24:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (957, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-01 13:25:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (958, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-01 13:25:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (959, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-01 13:27:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (960, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-01 13:28:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (961, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-01 14:00:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (962, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-01 14:02:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (963, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-01 14:05:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (964, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-01 14:23:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (965, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 14:56:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (966, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 14:57:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (967, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-01 14:58:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (968, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:24:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (969, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:26:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (970, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:27:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (971, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:37:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (972, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:39:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (973, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:39:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (974, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:44:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (975, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:44:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (976, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:46:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (977, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:47:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (978, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:50:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (979, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:50:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (980, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:52:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (981, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-01 16:52:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (982, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-01 17:02:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (983, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-01 17:03:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (984, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:06:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (985, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:15:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (986, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:19:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (987, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:20:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (988, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:25:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (989, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:26:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (990, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:32:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (991, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:33:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (992, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:34:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (993, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:46:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (994, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:46:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (995, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:49:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (996, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 11:49:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (997, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 13:30:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (998, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:04:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (999, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:05:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1000, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:28:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1001, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:32:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1002, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:32:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1003, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:38:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1004, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:38:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1005, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:41:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1006, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:42:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1007, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:42:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1008, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:50:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1009, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:51:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1010, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:54:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1011, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 14:58:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1012, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:01:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1013, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:02:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1014, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:05:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1015, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:06:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1016, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:09:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1017, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:09:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1018, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:10:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1019, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:11:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1020, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:20:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1021, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:21:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1022, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:22:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1023, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:23:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1024, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:25:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1025, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:27:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1026, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:29:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1027, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:29:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1028, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:36:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1029, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:39:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1030, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:39:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1031, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:45:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1032, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:45:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1033, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:47:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1034, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 15:55:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1035, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:11:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1036, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:12:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1037, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:12:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1038, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:12:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1039, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:14:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1040, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:15:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1041, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-02 16:18:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1042, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:18:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1043, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:22:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1044, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:22:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1045, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-02 16:36:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1046, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-02 16:39:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1047, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-02 16:40:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1048, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:41:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1049, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-02 16:41:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1050, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-02 16:42:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1051, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 11:32:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1052, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 11:33:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1053, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-10-05 11:41:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1054, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-10-05 11:41:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1055, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 11:42:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1056, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 11:42:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1057, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 11:43:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1058, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 11:46:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1059, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 11:46:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1060, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 11:51:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1061, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 11:51:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1062, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:14:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1063, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:14:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1064, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:42:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1065, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:44:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1066, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:46:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1067, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:47:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1068, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:48:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1069, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:49:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1070, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:51:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1071, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:52:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1072, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:53:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1073, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:57:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1074, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 16:59:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1075, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-05 17:03:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1076, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-05 17:03:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1077, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:24:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1078, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:24:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1079, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:25:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1080, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:25:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1081, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-08 15:43:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1082, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-08 15:44:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1083, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-08 15:44:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1084, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:44:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1085, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:44:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1086, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-08 15:44:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1087, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-08 15:45:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1088, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:45:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1089, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:45:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1090, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-10-08 15:47:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1091, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:50:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1092, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-08 15:50:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1093, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:30:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1094, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-09 14:30:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1095, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-09 14:30:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1096, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:49:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1097, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-09 14:50:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1098, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-09 14:50:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1099, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-09 14:50:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1100, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:50:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1101, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-09 14:50:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1102, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:55:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1103, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-09 14:55:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1104, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:56:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1105, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:57:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1106, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:57:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1107, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:57:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1108, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-09 14:58:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1109, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:58:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1110, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-09 14:58:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1111, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-09 15:00:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1112, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-09 15:00:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1113, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-09 15:03:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1114, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-09 15:13:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1115, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '5', '2018-10-09 15:13:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1116, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-10-09 15:13:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1117, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:12:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1118, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 09:13:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1119, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:24:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1120, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:24:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1121, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:27:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1122, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:27:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1123, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:33:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1124, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 09:33:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1125, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:34:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1126, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:34:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1127, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:34:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1128, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:34:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1129, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:34:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1130, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:34:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1131, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '5', '2018-10-10 09:34:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1132, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-10-10 09:34:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1133, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:37:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1134, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 09:37:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1135, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:37:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1136, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 09:41:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1137, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:13:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1138, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:13:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1139, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:16:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1140, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:16:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1141, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:16:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1142, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:16:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1143, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:16:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1144, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:16:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1145, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:23:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1146, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 10:23:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1147, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:23:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1148, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:23:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1149, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:26:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1150, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:26:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1151, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:26:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1152, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:26:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1153, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:26:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1154, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 10:27:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1155, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:29:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1156, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:29:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1157, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:29:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1158, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:30:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1159, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:30:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1160, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:40:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1161, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:40:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1162, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:40:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1163, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:40:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1164, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 10:40:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1165, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1166, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1167, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1168, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1169, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1170, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1171, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1172, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1173, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1174, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:41:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1175, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:41:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1176, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1177, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:41:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1178, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:42:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1179, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:42:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1180, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:42:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1181, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:42:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1182, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:42:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1183, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:42:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1184, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '5', '2018-10-10 10:44:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1185, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:44:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1186, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:44:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1187, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:44:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1188, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:44:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1189, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:45:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1190, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 10:46:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1191, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:47:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1192, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:47:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1193, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:54:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1194, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 10:54:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1195, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:54:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1196, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:54:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1197, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:54:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1198, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:54:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1199, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:55:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1200, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:55:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1201, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:55:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1202, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:55:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1203, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 10:55:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1204, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:56:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1205, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-10-10 10:56:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1206, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 15:00:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1207, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-10-10 15:00:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1208, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 15:01:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1209, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 15:48:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1210, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 16:34:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1211, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 16:35:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1212, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 0 -MaI? theIÅÒ: 111 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: 1', '1', '2018-10-10 16:35:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1213, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-10-10 16:38:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1214, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 16:46:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1215, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 72 -MaI? theIÅÒ: 111 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-10-10 16:47:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1216, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 16:52:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1217, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 74 -MaI? theIÅÒ: 112 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-10-10 16:52:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1218, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 17:00:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1219, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 75 -MaI? theIÅÒ: 1 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-10-10 17:00:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1220, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 76 -MaI? theIÅÒ: 2 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-10-10 17:00:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1221, 22, 'XoI?a theIÅÒ chip -STT: 2 -MaI? theIÅÒ: 2', '1', '2018-10-10 17:00:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1222, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 17:01:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1223, 22, 'XoI?a theIÅÒ chip -STT: 75 -MaI? theIÅÒ: 1', '1', '2018-10-10 17:01:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1224, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-10 17:16:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1225, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-15 15:52:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1226, 9, 'TaIÅío mA!I?i nhAÅën viAan -MaI? theIÅÒ: 7 -HoIÅí tAan: 7 -TaI?i khoaIÅÒn: 7 -MAÅëIÅít khAÅëIÅÒu: 7 -ChAÅãI?c vuIÅí: 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22 -GiA!I?i tiI?nh: Nam', '1', '2018-10-15 16:10:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1227, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-15 16:13:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1228, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-15 16:14:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1229, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-15 16:15:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1230, 11, 'XoI?a nhAÅën viAan -MaI? theIÅÒ: 7', '1', '2018-10-15 16:15:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1231, 9, 'TaIÅío mA!I?i nhAÅën viAan -MaI? theIÅÒ: 7 -HoIÅí tAan: 8 -TaI?i khoaIÅÒn: 9 -MAÅëIÅít khAÅëIÅÒu: 10 -ChAÅãI?c vuIÅí: Ca trAÅãA!IÅÒng -GiA!I?i tiI?nh: NAÅãI?', '1', '2018-10-15 16:15:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1232, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-15 16:33:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1233, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-15 16:35:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1234, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-10-15 16:55:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1235, 10, 'ChiIÅÒnh sAÅãIÅÒa nhAÅën viAan -MaI? theIÅÒ: 7 -HoIÅí tAan: 88 -> 8 -TaI?i khoaIÅÒn: 99 -> 9 -MAÅëIÅít khAÅëIÅÒu: 1010 -> 10 -ChAÅãI?c vuIÅí: KAaI? toaI?n -> NhAÅën viAan -GiA!I?i tiI?nh: Nam -> NAÅãI?', '1', '2018-10-15 16:55:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1236, 10, 'ChiIÅÒnh sAÅãIÅÒa nhAÅën viAan -MaI? theIÅÒ: 7 -HoIÅí tAan: 8 -> 80 -TaI?i khoaIÅÒn: 9 -> 90', '1', '2018-10-15 16:56:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1237, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-02 13:43:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1238, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-02 14:28:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1239, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-02 16:49:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1240, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-05 11:33:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1241, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-05 11:39:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1242, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-05 13:18:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1243, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-05 13:18:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1244, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 09:00:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1245, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 09:12:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1246, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 09:32:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1247, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-06 09:36:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1248, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 09:37:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1249, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:04:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1250, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:06:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1251, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:07:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1252, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:09:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1253, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:11:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1254, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:12:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1255, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:13:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1256, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:14:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1257, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:14:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1258, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:15:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1259, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:52:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1260, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 11:57:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1261, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 13:11:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1262, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 13:26:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1263, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-06 13:56:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1264, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-06 13:57:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1265, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 13:57:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1266, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-06 13:57:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1267, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 77 -MaI? theIÅÒ: 3118244928 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-06 13:58:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1268, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-06 13:58:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1269, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 13:58:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1270, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 14:04:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1271, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 15:39:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1272, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-06 15:44:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1273, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 11:23:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1274, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 13:40:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1275, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:15:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1276, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:16:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1277, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:16:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1278, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:17:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1279, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:39:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1280, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:40:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1281, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:48:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1282, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:49:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1283, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:52:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1284, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:52:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1285, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:53:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1286, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:53:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1287, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 15:53:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1288, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 16:54:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1289, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-07 17:05:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1290, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 10:16:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1291, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 10:18:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1292, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 11:12:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1293, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 11:40:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1294, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 11:51:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1295, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 11:55:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1296, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 11:58:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1297, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 11:59:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1298, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 13:16:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1299, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 13:17:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1300, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 13:51:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1301, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 13:55:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1302, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 14:15:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1303, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 14:16:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1304, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 14:17:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1305, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 14:25:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1306, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 14:58:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1307, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 14:59:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1308, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 14:59:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1309, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 15:02:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1310, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 15:10:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1311, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 15:45:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1312, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 16:23:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1313, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 16:24:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1314, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 16:27:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1315, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-08 16:27:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1316, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 16:28:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1317, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 16:32:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1318, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 16:39:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1319, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 16:57:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1320, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 16:59:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1321, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 17:01:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1322, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-08 17:07:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1323, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-09 08:49:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1324, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-09 09:46:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1325, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 09:13:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1326, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-12 09:55:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1327, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-12 09:57:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1328, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-12 09:58:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1329, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-12 10:00:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1330, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-12 10:08:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1331, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-12 13:29:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1332, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 13:45:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1333, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-12 14:13:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1334, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 14:14:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1335, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 14:23:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1336, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 14:26:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1337, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 14:50:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1338, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 16:17:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1339, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 78 -MaI? theIÅÒ: 220 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-12 16:17:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1340, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 16:18:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1341, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 80 -MaI? theIÅÒ: 221 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-12 16:19:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1342, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 80 -MaI? theIÅÒ: 222 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-12 16:19:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1343, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 16:23:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1344, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 16:28:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1345, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 16:30:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1346, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 16:31:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1347, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-12 16:47:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1348, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-13 08:47:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1349, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-13 08:48:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1350, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-13 09:08:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1351, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-13 09:09:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1352, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-13 09:11:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1353, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-13 09:14:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1354, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:27:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1355, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:28:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1356, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:33:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1357, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:34:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1358, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:39:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1359, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:39:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1360, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 08:40:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1361, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:46:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1362, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:47:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1363, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:56:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1364, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 08:56:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1365, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 09:02:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1366, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 09:02:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1367, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 09:03:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1368, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 13:48:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1369, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 13:49:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1370, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 83 -MaI? theIÅÒ: 3117202048 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-14 13:50:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1371, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 84 -MaI? theIÅÒ: 3118189600 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-14 13:50:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1372, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-14 13:51:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1373, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:06:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1374, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 14:06:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1375, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-14 14:09:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1376, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 14:09:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1377, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-14 14:09:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1378, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:09:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1379, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 14:10:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1380, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-14 14:11:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1381, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:11:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1382, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:14:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1383, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:16:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1384, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:24:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1385, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:32:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1386, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:33:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1387, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:48:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1388, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:49:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1389, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:52:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1390, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:52:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1391, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:57:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1392, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 14:59:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1393, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 15:03:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1394, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-14 15:05:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1395, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-14 15:05:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1396, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 15:46:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1397, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:19:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1398, 10, 'ChiIÅÒnh sAÅãIÅÒa nhAÅën viAan -MaI? theIÅÒ: 1 -HoIÅí tAan: quan_ly_1 -> Admin -TaI?i khoaIÅÒn: 1 -> admin -MAÅëIÅít khAÅëIÅÒu: 1 -> 123456', '1', '2018-11-14 16:20:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1399, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:20:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1400, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:20:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1401, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:25:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1402, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:26:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1403, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:26:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1404, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:27:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1405, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:29:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1406, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:39:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1407, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 85 -MaI? theIÅÒ: 3117202048 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-14 16:40:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1408, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:41:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1409, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 85 -MaI? theIÅÒ: 3117202048 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-14 16:41:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1410, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 16:44:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1411, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 85 -MaI? theIÅÒ: 3117202048 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-14 16:47:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1412, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 17:00:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1413, 22, 'XoI?a theIÅÒ chip -STT: 85 -MaI? theIÅÒ: 3117202048', '1', '2018-11-14 17:01:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1414, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-14 17:23:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1415, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 85 -MaI? theIÅÒ: 12 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-14 17:23:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1416, 22, 'XoI?a theIÅÒ chip -STT: 85 -MaI? theIÅÒ: 12', '1', '2018-11-14 17:23:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1417, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-15 09:06:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1418, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-15 09:07:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1419, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-15 09:09:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1420, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-15 10:22:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1421, 10, 'ChiIÅÒnh sAÅãIÅÒa nhAÅën viAan -MaI? theIÅÒ: 3 -HoIÅí tAan: admin_3 -> staff_1 -TaI?i khoaIÅÒn: 3 -> staff1 -MAÅëIÅít khAÅëIÅÒu: 3 -> 123456 -ChAÅãI?c vuIÅí: Ca trAÅãA!IÅÒng -> NhAÅën viAan', '1', '2018-11-15 10:25:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1422, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-15 10:25:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1423, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-15 10:26:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1424, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-15 11:00:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1425, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-15 11:28:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1426, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-15 11:30:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1427, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 08:53:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1428, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-16 08:55:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1429, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-16 08:56:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1430, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 08:56:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1431, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-16 08:57:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1432, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-16 08:58:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1433, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 08:58:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1434, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 09:02:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1435, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-16 13:17:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1436, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-16 13:55:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1437, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-16 13:55:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1438, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 13:55:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1439, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-16 13:55:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1440, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-16 13:56:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1441, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 13:56:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1442, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:02:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1443, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:03:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1444, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:07:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1445, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:11:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1446, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:14:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1447, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:15:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1448, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:19:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1449, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:28:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1450, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:48:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1451, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 14:57:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1452, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 15:28:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1453, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 15:34:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1454, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 15:36:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1455, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 15:40:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1456, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-16 15:49:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1457, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 15:52:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1458, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:15:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1459, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:29:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1460, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:30:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1461, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:31:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1462, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:33:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1463, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:34:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1464, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:36:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1465, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:38:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1466, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:41:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1467, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:43:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1468, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:45:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1469, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-16 16:48:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1470, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-19 09:01:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1471, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-19 09:29:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1472, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-19 09:36:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1473, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-19 09:43:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1474, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-19 09:45:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1475, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-19 10:01:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1476, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-19 10:09:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1477, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-19 10:15:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1478, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '3', '2018-11-19 10:18:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1479, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-19 14:56:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1480, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-11-19 14:56:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1481, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-19 14:57:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1482, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-19 15:05:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1483, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-19 15:06:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1484, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 85 -MaI? theIÅÒ: 3117202048 -LoaIÅíi xe: Xe maI?y -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-11-19 15:06:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1485, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-19 15:08:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1486, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-19 15:12:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1487, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-19 15:25:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1488, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-11-19 15:58:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1489, 10, 'ChiIÅÒnh sAÅãIÅÒa nhAÅën viAan -MaI? theIÅÒ: 2 -TaI?i khoaIÅÒn: 2 -> 1 -MAÅëIÅít khAÅëIÅÒu: 2 -> 1', '1', '2018-11-19 15:59:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1490, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-19 16:01:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1491, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-19 16:05:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1492, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-19 16:07:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1493, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-19 16:43:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1494, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-19 16:44:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1495, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-19 16:44:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1496, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-19 16:49:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1497, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-19 16:51:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1498, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-19 16:53:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1499, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-20 14:39:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1500, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-11-20 14:56:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1501, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-20 15:12:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1502, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-23 09:52:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1503, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-23 09:53:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1504, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-23 09:53:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1505, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-23 09:56:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1506, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-23 10:06:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1507, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 10:26:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1508, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 10:29:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1509, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 10:32:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1510, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 10:39:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1511, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 10:46:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1512, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 11:02:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1513, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 11:03:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1514, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 11:05:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1515, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 11:53:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1516, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 14:16:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1517, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 14:24:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1518, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 14:49:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1519, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 14:54:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1520, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 14:57:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1521, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:03:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1522, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:04:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1523, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:07:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1524, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:10:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1525, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:16:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1526, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:22:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1527, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:26:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1528, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:27:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1529, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:31:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1530, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:46:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1531, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:47:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1532, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:50:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1533, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:51:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1534, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 15:54:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1535, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 16:03:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1536, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 16:04:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1537, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 16:05:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1538, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 16:07:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1539, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 16:33:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1540, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-23 16:40:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1541, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-23 17:03:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1542, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 09:39:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1543, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 09:42:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1544, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 09:43:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1545, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 09:46:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1546, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 09:48:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1547, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 09:54:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1548, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 10:05:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1549, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 10:44:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1550, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 10:51:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1551, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 10:55:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1552, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:12:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1553, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:16:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1554, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:17:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1555, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:18:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1556, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:19:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1557, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:20:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1558, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:24:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1559, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:28:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1560, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:29:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1561, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:35:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1562, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 11:37:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1563, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 12:00:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1564, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 13:19:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1565, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 13:34:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1566, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 13:37:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1567, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 13:52:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1568, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 13:56:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1569, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 14:07:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1570, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 14:14:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1571, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 14:34:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1572, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 14:34:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1573, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 14:35:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1574, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 14:49:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1575, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 14:56:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1576, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 14:57:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1577, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:02:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1578, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:02:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1579, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:04:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1580, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:06:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1581, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:08:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1582, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:14:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1583, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:21:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1584, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:22:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1585, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:22:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1586, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:23:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1587, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:25:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1588, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:26:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1589, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:27:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1590, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:29:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1591, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:31:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1592, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:35:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1593, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:38:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1594, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:39:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1595, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:40:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1596, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:41:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1597, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:54:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1598, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:54:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1599, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 15:55:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1600, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:01:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1601, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:04:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1602, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:15:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1603, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:21:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1604, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:30:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1605, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:31:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1606, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:34:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1607, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:35:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1608, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:42:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1609, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:43:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1610, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:45:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1611, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:47:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1612, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:49:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1613, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-26 16:53:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1614, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-26 16:53:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1615, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-27 08:31:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1616, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-11-27 10:37:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1617, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-11-27 13:26:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1618, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-11-27 14:00:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1619, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-27 14:11:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1620, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-11-27 14:12:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1621, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-11-27 14:14:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1622, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-11-27 14:23:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1623, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-11-27 15:57:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1624, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-27 15:59:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1625, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-11-27 15:59:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1626, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-27 15:59:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1627, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-11-27 15:59:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1628, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-27 16:00:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1629, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-11-27 16:00:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1630, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-28 10:22:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1631, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-28 10:52:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1632, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-28 11:09:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1633, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-11-28 11:13:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1634, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-11-29 13:47:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1635, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-29 13:47:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1636, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-29 15:14:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1637, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-29 15:14:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1638, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-29 15:18:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1639, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-11-29 15:31:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1640, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-29 15:31:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1641, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-29 15:57:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1642, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-29 16:06:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1643, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-30 13:41:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1644, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-30 14:55:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1645, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-30 14:56:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1646, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-30 15:08:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1647, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-30 15:24:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1648, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-30 15:25:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1649, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-30 15:27:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1650, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-30 15:28:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1651, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-11-30 15:31:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1652, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 14:11:18', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1653, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 14:39:28', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1654, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 14:52:04', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1655, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 14:53:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1656, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 15:18:32', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1657, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 15:21:01', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1658, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 15:22:33', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1659, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 15:28:52', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1660, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 22:35:12', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1661, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 22:36:10', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1662, 25, 'TaIÅío mA!I?i theIÅÒ chip -MaI? loaIÅíi xe: 3 -TAan loaIÅíi xe: xe con -KyI? hiAaIÅíu: $ -TiAaI?n thu thaI?ng: 100000', '2', '2018-12-02 22:36:48', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1663, 25, 'TaIÅío mA!I?i theIÅÒ chip -MaI? loaIÅíi xe: 3 -TAan loaIÅíi xe: xe con -KyI? hiAaIÅíu: $ -TiAaI?n thu thaI?ng: 100000', '2', '2018-12-02 22:37:03', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1664, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 22:49:21', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1665, 25, 'TaIÅío mA!I?i theIÅÒ chip -MaI? loaIÅíi xe: 4 -TAan loaIÅíi xe: Xe taIÅÒi -KyI? hiAaIÅíu: ^ -TiAaI?n thu thaI?ng: 200000', '2', '2018-12-02 22:50:25', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1666, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-02 22:52:24', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1667, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-02 22:53:30', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1668, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 22:55:08', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1669, 25, 'TaIÅío mA!I?i theIÅÒ chip -MaI? loaIÅíi xe: 3 -TAan loaIÅíi xe: xe con -KyI? hiAaIÅíu: @@ -TiAaI?n thu thaI?ng: 100000', '2', '2018-12-02 22:55:33', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1670, 25, 'TaIÅío mA!I?i theIÅÒ chip -MaI? loaIÅíi xe: 3 -TAan loaIÅíi xe: xe con -KyI? hiAaIÅíu: @@ -TiAaI?n thu thaI?ng: 100000', '2', '2018-12-02 22:55:33', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1671, 25, 'TaIÅío mA!I?i theIÅÒ chip -MaI? loaIÅíi xe: 4 -TAan loaIÅíi xe: xe taIÅÒi -KyI? hiAaIÅíu: @@ -TiAaI?n thu thaI?ng: 100000', '2', '2018-12-02 22:55:54', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1672, 25, 'TaIÅío mA!I?i theIÅÒ chip -MaI? loaIÅíi xe: 4 -TAan loaIÅíi xe: xe taIÅÒi -KyI? hiAaIÅíu: @@ -TiAaI?n thu thaI?ng: 100000', '2', '2018-12-02 22:55:54', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1673, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 23:13:18', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1674, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-02 23:17:53', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1675, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 09:09:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1676, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 09:25:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1677, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 09:35:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1678, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 09:38:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1679, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 09:42:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1680, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 09:51:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1681, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 10:00:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1682, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 10:10:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1683, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 10:14:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1684, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 10:15:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1685, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 10:23:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1686, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 10:51:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1687, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 10:58:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1688, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 11:01:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1689, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 11:03:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1690, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 11:22:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1691, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 11:24:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1692, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 11:28:28', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1693, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 11:30:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1694, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 87 -MaI? theIÅÒ: 112 -LoaIÅíi xe: Xe tay ga -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-03 11:30:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1695, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-03 11:42:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1696, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 11:43:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1697, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 11:45:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1698, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 13:15:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1699, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 87 -MaI? theIÅÒ: 113 -LoaIÅíi xe: Xe sAÅLI? -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-03 13:16:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1700, 22, 'XoI?a theIÅÒ chip -STT: 87 -MaI? theIÅÒ: 113', '2', '2018-12-03 13:16:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1701, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 13:21:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1702, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 13:33:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1703, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 13:35:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1704, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 88 -MaI? theIÅÒ: 114 -LoaIÅíi xe: Xe sAÅLI? -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-03 13:35:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1705, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 13:43:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1706, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 14:07:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1707, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 14:11:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1708, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 14:22:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1709, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 14:50:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1710, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 14:57:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1711, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 15:10:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1712, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 15:14:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1713, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 15:16:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1714, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 15:33:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1715, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 88 -MaI? theIÅÒ: 113 -LoaIÅíi xe: Xe sAÅLI? -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-03 15:34:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1716, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 15:37:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1717, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 15:41:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1718, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 16:27:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1719, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 16:31:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1720, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 16:53:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1721, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 17:00:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1722, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-03 17:01:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1723, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 08:20:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1724, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 08:28:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1725, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 08:35:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1726, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 89 -MaI? theIÅÒ: 114 -LoaIÅíi xe: Xe sAÅLI? -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-04 08:38:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1727, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 08:44:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1728, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 08:48:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1729, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 09:11:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1730, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 90 -MaI? theIÅÒ: 115 -LoaIÅíi xe: Xe sAÅLI? -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-04 09:12:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1731, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 09:22:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1732, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 09:36:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1733, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 09:45:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1734, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 09:55:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1735, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 09:58:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1736, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 10:01:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1737, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 10:03:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1738, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 10:08:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1739, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 10:51:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1740, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 10:56:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1741, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 98 -MaI? theIÅÒ: 116 -LoaIÅíi xe: Xe con -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-04 10:57:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1742, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 99 -MaI? theIÅÒ: 117 -LoaIÅíi xe: Xe taIÅÒi -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-04 10:57:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1743, 22, 'XoI?a theIÅÒ chip -STT: 97 -MaI? theIÅÒ: 113', '2', '2018-12-04 10:57:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1744, 22, 'XoI?a theIÅÒ chip -STT: 98 -MaI? theIÅÒ: 116', '2', '2018-12-04 10:57:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1745, 22, 'XoI?a theIÅÒ chip -STT: 99 -MaI? theIÅÒ: 117', '2', '2018-12-04 10:57:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1746, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 93 -MaI? theIÅÒ: 113 -LoaIÅíi xe: Xe sAÅLI? -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-04 10:58:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1747, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 11:00:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1748, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 11:09:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1749, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 11:14:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1750, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 11:19:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1751, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 11:29:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1752, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-04 11:34:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1753, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-04 11:36:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1754, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-04 11:40:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1755, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 11:53:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1756, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-04 11:54:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1757, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-04 11:54:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1758, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 13:18:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1759, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 13:35:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1760, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 13:44:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1761, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 13:47:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1762, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-04 13:53:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1763, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:02:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1764, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:03:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1765, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:16:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1766, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:18:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1767, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:19:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1768, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:20:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1769, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:22:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1770, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:23:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1771, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:26:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1772, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 14:31:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1773, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 15:29:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1774, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 15:30:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1775, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 15:32:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1776, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 15:59:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1777, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:00:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1778, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:10:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1779, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:14:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1780, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:17:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1781, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:19:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1782, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:33:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1783, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:35:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1784, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-04 16:43:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1785, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:44:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1786, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:52:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1787, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:52:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1788, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-04 16:53:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1789, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-04 16:53:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1790, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 08:28:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1791, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 08:29:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1792, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 08:39:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1793, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 08:42:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1794, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 08:51:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1795, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 08:54:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1796, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 09:08:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1797, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 09:31:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1798, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 09:32:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1799, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 09:35:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1800, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 09:43:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1801, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 09:51:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1802, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 13:51:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1803, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 13:51:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1804, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 14:01:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1805, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 14:03:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1806, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 14:07:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1807, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-05 14:08:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1808, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 14:08:10', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1809, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 15:43:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1810, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-05 15:47:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1811, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 16:19:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1812, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 16:43:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1813, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 16:45:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1814, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 16:56:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1815, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 22:08:39', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1816, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-05 22:09:06', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1817, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 22:09:11', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1818, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 22:09:42', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1819, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 94 -MaI? theIÅÒ: 3113963712 -LoaIÅíi xe: Xe sAÅLI? -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-05 22:10:09', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1820, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-05 22:10:21', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1821, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 22:10:25', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1822, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 22:11:13', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1823, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 22:13:30', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1824, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-05 22:14:59', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1825, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-05 22:15:24', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1826, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 22:31:49', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1827, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-05 22:40:31', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1828, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 08:49:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1829, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 08:59:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1830, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 09:03:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1831, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-06 09:04:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1832, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 09:04:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1833, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 09:10:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1834, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-06 09:22:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1835, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-06 09:32:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1836, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-06 09:32:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1837, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 09:33:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1838, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-06 09:33:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1839, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 09:41:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1840, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-06 09:42:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1841, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-06 09:42:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1842, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-06 10:29:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1843, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 13:35:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1844, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 13:37:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1845, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 13:40:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1846, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-06 16:46:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1847, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-06 16:47:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1848, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-06 16:49:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1849, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-06 16:51:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1850, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 08:45:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1851, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 09:07:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1852, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 09:11:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1853, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 09:39:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1854, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 09:40:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1855, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 09:47:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1856, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 09:49:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1857, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 10:08:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1858, 25, 'TaIÅío mA!I?i theIÅÒ chip -MaI? loaIÅíi xe: 8 -TAan loaIÅíi xe: xe du liIÅích -KyI? hiAaIÅíu: $$ -TiAaI?n thu thaI?ng: 80000', '2', '2018-12-07 10:12:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1859, 25, 'TaIÅío mA!I?i theIÅÒ chip -MaI? loaIÅíi xe: 9 -TAan loaIÅíi xe: Xe du liIÅích -KyI? hiAaIÅíu: $$ -TiAaI?n thu thaI?ng: 80000', '2', '2018-12-07 10:12:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1860, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-07 10:35:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1861, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 10:36:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1862, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 10:38:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1863, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 10:45:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1864, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 10:52:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1865, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 95 -MaI? theIÅÒ: 116 -LoaIÅíi xe: Xe sAÅLI? thaI?ng -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-07 10:53:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1866, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 11:03:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1867, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 11:04:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1868, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 11:22:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1869, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 11:27:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1870, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 11:28:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1871, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 13:24:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1872, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 13:26:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1873, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 13:47:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1874, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 13:52:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1875, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 13:56:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1876, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 13:58:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1877, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 14:10:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1878, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 14:15:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1879, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 14:20:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1880, 27, 'XoI?a loaIÅíi xe -MaI? loaIÅíi xe: 9 -TAan loaIÅíi xe: Xe du liIÅích thAÅãA!I?ng', '2', '2018-12-07 14:21:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1881, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-07 14:21:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1882, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-07 14:21:32', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1883, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-07 14:32:05', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1884, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-07 14:32:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1885, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 15:23:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1886, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 15:26:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1887, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 15:29:35', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1888, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 15:32:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1889, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 15:36:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1890, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 15:37:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1891, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 15:39:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1892, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 15:41:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1893, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-07 15:42:19', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1894, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-07 15:44:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1895, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 15:57:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1896, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 16:24:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1897, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 16:30:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1898, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-07 16:32:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1899, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-07 16:43:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1900, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-07 16:45:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1901, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-07 16:49:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1902, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 10:23:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1903, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 10:36:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1904, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 10:55:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1905, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 10:58:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1906, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:01:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1907, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:09:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1908, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:10:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1909, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:10:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1910, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:14:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1911, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:16:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1912, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:42:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1913, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:46:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1914, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:47:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1915, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:49:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1916, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:51:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1917, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:51:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1918, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 11:52:15', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1919, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 13:17:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1920, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 13:33:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1921, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 14:08:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1922, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 14:50:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1923, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 14:52:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1924, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 15:03:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1925, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-10 15:12:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1926, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-10 16:45:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1927, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-10 16:46:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1928, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-10 16:47:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1929, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-12-10 16:54:14', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1930, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-10 16:54:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1931, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-12-10 16:55:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1932, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-10 16:55:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1933, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-10 16:59:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1934, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-10 17:41:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1935, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-10 17:42:30', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1936, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-10 17:44:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1937, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-10 17:45:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1938, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 08:46:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1939, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 08:57:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1940, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 08:58:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1941, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 09:11:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1942, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 09:11:59', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1943, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 09:19:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1944, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 09:24:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1945, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 10:51:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1946, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '1', '2018-12-11 10:54:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1947, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 10:55:43', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1948, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 10:56:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1949, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 11:46:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1950, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-11 11:56:57', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1951, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 11:25:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1952, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-14 11:25:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1953, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 15:37:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1954, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-14 15:40:51', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1955, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 15:42:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1956, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 15:43:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1957, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 15:46:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1958, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 15:46:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1959, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 15:48:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1960, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 15:51:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1961, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:21:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1962, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:30:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1963, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-14 16:33:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1964, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-14 16:34:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1965, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-14 16:35:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1966, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:36:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1967, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:37:38', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1968, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:37:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1969, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:43:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1970, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:43:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1971, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:43:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1972, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:45:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1973, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:48:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1974, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:50:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1975, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:51:21', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1976, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-14 16:52:18', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1977, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:53:33', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1978, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-14 16:54:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1979, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-14 16:59:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1980, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-14 17:00:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1981, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-18 09:23:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1982, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-18 09:24:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1983, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-18 09:35:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1984, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-18 09:36:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1985, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 96 -MaI? theIÅÒ: 117 -LoaIÅíi xe: Xe sAÅLI? thAÅãA!I?ng -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-18 09:36:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1986, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-18 09:36:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1987, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-18 09:36:54', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1988, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-18 09:37:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1989, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 97 -MaI? theIÅÒ: 500 -LoaIÅíi xe: Xe sAÅLI? thAÅãA!I?ng -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-18 09:37:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1990, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-18 09:37:17', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1991, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-18 09:37:26', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1992, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-18 09:39:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1993, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-18 09:39:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1994, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 98 -MaI? theIÅÒ: 501 -LoaIÅíi xe: Xe sAÅLI? thAÅãA!I?ng -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-18 09:40:01', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1995, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '2', '2018-12-18 09:40:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1996, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-18 09:40:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1997, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '6', '2018-12-18 09:40:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1998, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-18 10:09:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (1999, 7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '', '2018-12-18 10:35:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2000, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-18 10:49:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2001, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-19 11:42:31', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2002, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 99 -MaI? theIÅÒ: 502 -LoaIÅíi xe: Xe sAÅLI? thAÅãA!I?ng -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-19 11:42:45', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2003, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-19 11:44:34', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2004, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 100 -MaI? theIÅÒ: 503 -LoaIÅíi xe: Xe sAÅLI? thAÅãA!I?ng -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-19 11:44:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2005, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '6', '2018-12-19 11:45:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2006, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-19 11:50:12', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2007, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-19 11:52:40', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2008, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-19 11:55:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2009, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-19 11:56:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2010, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-19 11:57:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2011, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-19 11:58:47', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2012, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-19 12:00:24', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2013, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-19 12:02:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2014, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-19 12:03:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2015, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-19 12:05:04', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2016, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 08:38:06', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2017, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 08:46:25', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2018, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 10:44:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2019, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 10:46:13', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2020, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 10:48:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2021, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 10:49:46', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2022, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 11:05:50', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2023, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 11:09:52', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2024, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 11:11:11', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2025, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 11:12:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2026, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 11:14:07', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2027, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 11:16:08', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2028, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 11:58:56', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2029, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 12:00:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2030, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 12:22:55', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2031, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 13:12:42', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2032, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 13:17:29', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2033, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 13:36:36', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2034, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 14:30:37', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2035, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 14:31:16', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2036, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 14:44:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2037, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 14:47:44', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2038, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:00:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2039, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:06:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2040, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:06:39', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2041, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:14:03', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2042, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:23:22', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2043, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:29:23', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2044, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 101 -MaI? theIÅÒ: 504 -LoaIÅíi xe: Xe sAÅLI? thAÅãA!I?ng -SAÅãIÅÒ duIÅíng: coI?', '1', '2018-12-20 15:29:41', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2045, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:31:02', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2046, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:33:53', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2047, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:36:20', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2048, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:39:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2049, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:42:49', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2050, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:44:27', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2051, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:46:09', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2052, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:55:58', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2053, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '1', '2018-12-20 15:56:48', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2054, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-20 17:21:12', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2055, 6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '2', '2018-12-20 17:22:00', 'WIN10-GIANGNT');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2056, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 102 -MaI? theIÅÒ: 505 -LoaIÅíi xe: Xe sAÅLI? thAÅãA!I?ng -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-20 17:22:47', 'TRUONGGIANG');
INSERT INTO `Log` (`Identify`, `LogTypeID`, `LogNote`, `Account`, `ProcessDate`, `Computer`) VALUES (2057, 20, 'TaIÅío mA!I?i theIÅÒ chip -STT: 103 -MaI? theIÅÒ: 506 -LoaIÅíi xe: Xe sAÅLI? thAÅãA!I?ng -SAÅãIÅÒ duIÅíng: coI?', '2', '2018-12-20 17:23:30', 'WIN10-GIANGNT');
# 2057 records

#
# Table structure for table 'LogType'
#

DROP TABLE IF EXISTS `LogType`;

CREATE TABLE `LogType` (
  `LogTypeID` INTEGER NOT NULL AUTO_INCREMENT, 
  `LogTypeName` VARCHAR(255), 
  `IsTicketLog` VARCHAR(255), 
  PRIMARY KEY (`LogTypeID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'LogType'
#

INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (1, 'TaIÅío mA!I?i veI? thaI?ng', '1');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (2, 'ChiIÅÒnh sAÅãIÅÒa veI? thaI?ng', '1');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (3, 'XoI?a veI? thaI?ng', '1');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (4, 'Import danh saI?ch veI? thaI?ng', '1');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (5, 'Export danh saI?ch veI? thaI?ng', '1');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (6, 'A?A?ng nhAÅëIÅíp hAaIÅí thAÅLI?ng', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (7, 'A?A?ng xuAÅëI?t hAaIÅí thAÅLI?ng', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (9, 'TaIÅío mA!I?i nhAÅën viAan', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (10, 'ChiIÅÒnh sAÅãIÅÒa nhAÅën viAan', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (11, 'XoI?a nhAÅën viAan', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (12, 'XuAÅëI?t file Excel doI? baIÅÒng chAÅëI?m cAÅLng', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (13, 'XuAÅëI?t file Excel tAÅLIÅÒng quaI?t thAÅLI?ng kAa doanh thu', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (14, 'XuAÅëI?t file Excel chi tiAaI?t thAÅLI?ng kAa doanh thu', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (15, 'XuAÅëI?t file Excel tiI?nh hiI?nh giao ca thAÅLI?ng kAa doanh thu', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (16, 'XuAÅëI?t file Excel thu tiAaI?n veI? thaI?ng thAÅLI?ng kAa doanh thu', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (17, 'CAÅëIÅíp nhAÅëIÅít cAÅLng thAÅãI?c tiI?nh tiAaI?n theo cAÅLng vA?n', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (18, 'CAÅëIÅíp nhAÅëIÅít cAÅLng thAÅãI?c tiI?nh tiAaI?n luI?y tiAaI?n', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (19, 'CAÅëIÅíp nhAÅëIÅít cAÅLng thAÅãI?c tiI?nh tiAaI?n tAÅLIÅÒng hA!IÅíp', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (20, 'TaIÅío mA!I?i theIÅÒ chip', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (21, 'ChiIÅÒnh sAÅãIÅÒa theIÅÒ chip', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (22, 'XoI?a theIÅÒ chip', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (23, 'XuAÅëI?t file Excel danh saI?ch theIÅÒ xe', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (24, 'NhAÅëIÅíp file Excel danh saI?ch theIÅÒ xe', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (25, 'TaIÅío mA!I?i loaIÅíi xe', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (26, 'ChiIÅÒnh sAÅãIÅÒa loaIÅíi xe', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (27, 'XoI?a loaIÅíi xe', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (28, 'KiI?ch hoaIÅít theIÅÒ xe', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (29, 'Xem nhAÅëIÅít kyI? veI? thaI?ng', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (37, 'Gia haIÅín veI? thaI?ng theo ngaI?y AÅeaI? choIÅín', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (38, 'Gia haIÅín veI? thaI?ng cAÅLIÅíng dAÅLI?n ngaI?y', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (39, 'CAÅëIÅíp nhAÅëIÅít veI? thaI?ng biIÅí mAÅëI?t', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (40, 'CAÅëIÅíp nhAÅëIÅít quyAaI?n truy cAÅëIÅíp', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (41, 'XuAÅëI?t file Excel nhAÅëIÅít kyI? hAaIÅí thAÅLI?ng', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (42, 'CAÅëIÅíp nhAÅëIÅít thiAaI?t lAÅëIÅíp ra vaI?o', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (43, 'TaIÅío mA!I?i biAaIÅÒn sAÅLI? AÅeen', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (44, 'XuAÅëI?t file Excel danh saI?ch xe ra vaI?o', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (45, 'LAÅãu mAÅëI?t theIÅÒ', '0');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (46, 'XuAÅëI?t file Excel danh saI?ch xe ra vaI?o veI? thaI?ng', '1');
INSERT INTO `LogType` (`LogTypeID`, `LogTypeName`, `IsTicketLog`) VALUES (47, 'XuAÅëI?t file Exel thAÅLng tin hAaI?t haIÅín veI? thaI?ng', '1');
# 39 records

#
# Table structure for table 'ParkingType'
#

DROP TABLE IF EXISTS `ParkingType`;

CREATE TABLE `ParkingType` (
  `ParkingTypeID` INTEGER NOT NULL DEFAULT 0, 
  `ParkingTypeName` VARCHAR(255), 
  PRIMARY KEY (`ParkingTypeID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'ParkingType'
#

INSERT INTO `ParkingType` (`ParkingTypeID`, `ParkingTypeName`) VALUES (0, 'GiAÅãI? xe miAaI?n phiI?');
INSERT INTO `ParkingType` (`ParkingTypeID`, `ParkingTypeName`) VALUES (1, 'GiAÅãI? xe theo cAÅLng vA?n');
INSERT INTO `ParkingType` (`ParkingTypeID`, `ParkingTypeName`) VALUES (2, 'GiAÅãI? xe tA?ng luI?y tiAaI?n');
INSERT INTO `ParkingType` (`ParkingTypeID`, `ParkingTypeName`) VALUES (3, 'GiAÅãI? xe tAÅLIÅÒng hA!IÅíp');
# 4 records

#
# Table structure for table 'Part'
#

DROP TABLE IF EXISTS `Part`;

CREATE TABLE `Part` (
  `ID` VARCHAR(255) NOT NULL, 
  `PartName` VARCHAR(255), 
  `Sign` VARCHAR(255), 
  `Amount` INTEGER DEFAULT 0, 
  `TypeID` VARCHAR(255), 
  `CardTypeID` VARCHAR(255), 
  PRIMARY KEY (`ID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'Part'
#

INSERT INTO `Part` (`ID`, `PartName`, `Sign`, `Amount`, `TypeID`, `CardTypeID`) VALUES ('1', 'Xe sAÅLI? thAÅãA!I?ng', '#3', 60000, '1', '1');
INSERT INTO `Part` (`ID`, `PartName`, `Sign`, `Amount`, `TypeID`, `CardTypeID`) VALUES ('2', 'Xe sAÅLI? thaI?ng', '#3', 50000, '1', '2');
INSERT INTO `Part` (`ID`, `PartName`, `Sign`, `Amount`, `TypeID`, `CardTypeID`) VALUES ('3', 'Xe tay ga thAÅãA!I?ng', '*', 60000, '1', '1');
INSERT INTO `Part` (`ID`, `PartName`, `Sign`, `Amount`, `TypeID`, `CardTypeID`) VALUES ('4', 'Xe tay ga thaI?ng', '*', 60000, '1', '2');
INSERT INTO `Part` (`ID`, `PartName`, `Sign`, `Amount`, `TypeID`, `CardTypeID`) VALUES ('5', 'Xe con thAÅãA!I?ng', '++', 100000, '2', '1');
INSERT INTO `Part` (`ID`, `PartName`, `Sign`, `Amount`, `TypeID`, `CardTypeID`) VALUES ('6', 'Xe con thaI?ng', '++', 100000, '2', '2');
INSERT INTO `Part` (`ID`, `PartName`, `Sign`, `Amount`, `TypeID`, `CardTypeID`) VALUES ('7', 'Xe taIÅÒi thAÅãA!I?ng', '@@', 100000, '2', '1');
INSERT INTO `Part` (`ID`, `PartName`, `Sign`, `Amount`, `TypeID`, `CardTypeID`) VALUES ('8', 'Xe taIÅÒi thaI?ng', '@@', 100000, '2', '2');
# 8 records

#
# Table structure for table 'Sex'
#

DROP TABLE IF EXISTS `Sex`;

CREATE TABLE `Sex` (
  `SexID` INTEGER NOT NULL AUTO_INCREMENT, 
  `SexName` VARCHAR(255), 
  PRIMARY KEY (`SexID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'Sex'
#

INSERT INTO `Sex` (`SexID`, `SexName`) VALUES (1, 'Nam');
INSERT INTO `Sex` (`SexID`, `SexName`) VALUES (2, 'NAÅãI?');
# 2 records

#
# Table structure for table 'SmartCard'
#

DROP TABLE IF EXISTS `SmartCard`;

CREATE TABLE `SmartCard` (
  `SystemID` VARCHAR(255) NOT NULL, 
  `Identify` INTEGER DEFAULT 0, 
  `ID` VARCHAR(255) NOT NULL, 
  `IsUsing` VARCHAR(255), 
  `Type` VARCHAR(255), 
  `DayUnlimit` DATETIME, 
  INDEX (`ID`), 
  PRIMARY KEY (`SystemID`), 
  INDEX (`SystemID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'SmartCard'
#

INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('3117202048', 85, '3117202048', '1', '6', '2018-11-19 15:06:29');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('111', 86, '111', '1', '1', '2018-12-03 11:45:43');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('112', 92, '112', '1', '2', '2018-12-07 10:53:22');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('114', 89, '114', '1', '2', '2018-12-04 10:53:24');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('115', 90, '115', '1', '3', '2018-12-04 11:21:10');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('113', 93, '113', '1', '2', '2018-12-04 10:58:38');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('3113963712', 94, '3113963712', '1', '5', '2018-12-05 22:10:09');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('116', 95, '116', '1', '2', '2018-12-07 10:53:04');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('117', 96, '117', '1', '1', '2018-12-18 09:36:25');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('500', 97, '500', '1', '1', '2018-12-18 09:37:10');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('501', 98, '501', '1', '1', '2018-12-18 09:39:59');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('502', 99, '502', '1', '1', '2018-12-19 11:42:44');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('503', 100, '503', '1', '1', '2018-12-19 11:44:48');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('504', 101, '504', '1', '1', '2018-12-20 15:29:41');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('505', 102, '505', '1', '1', '2018-12-20 17:22:46');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('506', 103, '506', '1', '1', '2018-12-20 17:23:29');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('31181896003', 68, '31181896003', '1', '8', '2018-11-19 15:59:41');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('118189600', 69, '118189600', '0', '3', '2018-12-04 08:37:04');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('3113934112', 71, '3113934112', '1', '4', '2018-09-26 20:30:14');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('3118244928', 77, '3118244928', '0', '1', '2018-11-23 14:55:09');
INSERT INTO `SmartCard` (`SystemID`, `Identify`, `ID`, `IsUsing`, `Type`, `DayUnlimit`) VALUES ('3118189600', 84, '3118189600', '1', '7', '2018-11-23 14:55:29');
# 21 records

#
# Table structure for table 'TicketLog'
#

DROP TABLE IF EXISTS `TicketLog`;

CREATE TABLE `TicketLog` (
  `Identify` INTEGER NOT NULL AUTO_INCREMENT, 
  `LogTypeID` INTEGER DEFAULT 0, 
  `ProcessDate` DATETIME, 
  `TicketMonthID` VARCHAR(255), 
  `TicketMonthIdentify` INTEGER DEFAULT 0, 
  `Digit` VARCHAR(255), 
  `CustomerName` VARCHAR(255), 
  `CMND` VARCHAR(255), 
  `Company` VARCHAR(255), 
  `Email` VARCHAR(255), 
  `Address` VARCHAR(255), 
  `CarKind` VARCHAR(255), 
  `IDPart` VARCHAR(255), 
  `RegistrationDate` DATETIME, 
  `ExpirationDate` DATETIME, 
  `Note` VARCHAR(255), 
  `ChargesAmount` VARCHAR(255), 
  `Status` INTEGER DEFAULT 0, 
  `Account` VARCHAR(255), 
  `Images` VARCHAR(255), 
  `DayUnlimit` DATETIME, 
  INDEX (`IDPart`), 
  PRIMARY KEY (`Identify`), 
  INDEX (`TicketMonthID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'TicketLog'
#

INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (26, 1, '2018-03-17 11:24:10', '128', 37, 'A', 'B', 'C', 'E', 'D', 'F', 'G', '2', '2018-03-17 00:00:00', '2018-03-17 00:00:00', NULL, 'H', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (27, 1, '2018-03-17 11:32:30', '129', 41, '64C7-89473', 'KH 1', '312579375', 'CTY 1', 'mail1@gmail.com', 'Q3', 'Yamaha', '2', '2018-03-17 00:00:00', '2018-03-17 00:00:00', NULL, '5000', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (28, 2, '2018-03-17 11:35:16', '', 40, 'A', 'KH 2', 'C', 'CTY 2', 'D', 'F', 'G', '4', '2018-03-17 00:00:00', '2018-03-17 00:00:00', NULL, 'H', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (29, 2, '2018-03-17 11:36:27', '128', 40, 'A', 'KH 2', 'C', 'CTY 2', 'D', 'F', 'G', '6', '2018-03-17 00:00:00', '2018-03-17 00:00:00', NULL, 'H', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (30, 3, '2018-03-17 12:19:33', '126', 35, 'BBB', '', '', '', '', '', '', '8', '2018-03-17 00:00:00', '2018-03-17 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (31, 3, '2018-03-17 12:21:13', '123', 30, '60B6-64587', '', '', '', '', '', '', '8', '2018-03-17 00:00:00', '2018-03-17 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (32, 2, '2018-03-17 12:23:02', '122', 29, '62M9-67213', 'KH 29', 'CMND 29', 'CT 29', 'Email 29', 'Address 29', 'Suzuki', '2', '2018-03-17 00:00:00', '2018-03-17 00:00:00', NULL, '8000', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (33, 3, '2018-03-17 12:23:36', '122', 29, '62M9-67213', 'KH 29', 'CMND 29', 'CT 29', 'Email 29', 'Address 29', 'Suzuki', '6', '2018-03-17 00:00:00', '2018-03-17 00:00:00', NULL, '8000', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (34, 1, '2018-09-18 10:38:06', '3118189600', 42, '123456', 'KH1', '', '', '', '', '', '6', '2018-09-18 00:00:00', '2018-09-18 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (35, 2, '2018-09-18 13:39:52', '120', 10, '123456', 'test', '555555555', 'CTY 2', '', '', 'yamaha', '2', '2018-03-04 00:00:00', '2018-04-19 00:00:00', NULL, '2000', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (36, 2, '2018-09-18 13:40:02', '119', 25, '71D4-72472', '', '', '', '', '', '', '4', '2018-03-11 00:00:00', '2018-03-12 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (37, 2, '2018-09-18 13:40:23', '111', 1, '63H3-7132', 'KH 1', '123456789', 'CTY 1', 'mail1@gmail.com', 'Q3', 'honda', '4', '2018-03-17 00:00:00', '2018-03-29 00:00:00', NULL, '100000', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (38, 2, '2018-09-18 13:40:25', '111', 1, '63H3-7132', 'KH 1', '123456789', 'CTY 1', 'mail1@gmail.com', 'Q3', 'honda', '2', '2018-03-17 00:00:00', '2018-03-29 00:00:00', NULL, '100000', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (39, 2, '2018-09-18 13:40:52', '111', 1, '63H3-7132', 'KH 1', '123456789', 'CTY 1', 'mail1@gmail.com', 'Q3', 'honda', '2', '2018-03-17 00:00:00', '2018-03-29 00:00:00', NULL, '100000', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (40, 2, '2018-09-18 13:40:54', '111', 1, '63H3-7132', 'KH 1', '123456789', 'CTY 1', 'mail1@gmail.com', 'Q3', 'honda', '4', '2018-03-17 00:00:00', '2018-03-29 00:00:00', NULL, '100000', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (41, 2, '2018-09-18 13:40:58', '111', 1, '63H3-7132', 'KH 1', '123456789', 'CTY 1', 'mail1@gmail.com', 'Q3', 'honda', '6', '2018-03-17 00:00:00', '2018-03-29 00:00:00', NULL, '100000', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (42, 1, '2018-09-18 13:58:28', '3113934112', 43, '123456', '', '', '', '', '', '', '8', '2018-09-18 00:00:00', '2018-09-18 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (43, 3, '2018-09-18 13:58:59', '3113934112', 43, '123456', '', '', '', '', '', '', '8', '2018-09-18 00:00:00', '2018-09-18 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (44, 3, '2018-09-18 13:59:43', '3118189600', 42, '123456', 'KH1', '', '', '', '', '', '2', '2018-09-18 00:00:00', '2018-09-18 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (45, 1, '2018-09-18 14:00:05', '3118189600', 42, '123', '', '', '', '', '', '', '6', '2018-09-18 00:00:00', '2018-09-18 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (46, 2, '2018-09-18 14:00:25', '3118189600', 44, '123', 'KH1', '', '', '', '', '', '6', '2018-09-18 00:00:00', '2018-09-18 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (47, 1, '2018-10-02 13:32:16', '222', 45, '2', '', '', '', '', '', '', '2', '2018-10-02 00:00:00', '2018-11-01 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (48, 1, '2018-10-02 13:32:34', '223', 46, '1', '', '', '', '', '', '', '4', '2018-10-02 00:00:00', '2018-11-01 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (49, 1, '2018-10-02 13:33:50', '125', 47, '111', '', '', '', '', '', '', '4', '2018-10-02 00:00:00', '2018-11-01 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (50, 1, '2018-10-02 13:33:56', '126', 48, '122', '', '', '', '', '', '', '6', '2018-10-02 00:00:00', '2018-11-01 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (51, 1, '2018-10-02 13:34:08', '127', 48, '332', '', '', '', '', '', '', '2', '2018-10-02 00:00:00', '2018-11-01 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (52, 2, '2018-10-02 14:43:38', '3118189600', 44, '123456', 'KH1', '', '', '', '', '', '2', '2018-09-18 00:00:00', '2018-09-18 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (53, 1, '2018-10-02 15:55:34', '130', 50, '112233', '', '', '', '', '', '', '4', '2018-10-02 00:00:00', '2018-11-02 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (54, 1, '2018-11-08 16:28:12', '3118244928', 51, '555555', '', '', '', '', '', '', '6', '2018-11-08 00:00:00', '2018-12-08 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (55, 1, '2018-11-14 13:51:12', '3118189600', 52, '63B6-28769', 'KH1', '', '', '', '', '', '8', '2018-11-14 00:00:00', '2018-12-14 00:00:00', NULL, '', 0, '1', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (56, 2, '2018-11-19 16:44:35', '3118244928', 50, '555555', '', '', '', '', '', '', '8', '2018-11-08 00:00:00', '2018-12-08 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (100, 1, '2018-12-07 10:54:07', '116', 95, '547', '', '', '', '', '', '', '2', '2018-12-07 00:00:00', '2019-01-07 00:00:00', NULL, '70000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (93, 1, '2018-12-04 11:14:19', '112', 92, '15', '', '', '', '', '', '', '4', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '60000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (94, 3, '2018-12-04 11:14:24', '112', 92, '15', '', '', '', '', '', '', '6', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '60000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (95, 1, '2018-12-04 11:17:16', '112', 92, '45', '', '', '', '', '', '', '2', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '60000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (96, 3, '2018-12-04 11:17:21', '112', 92, '45', '', '', '', '', '', '', '2', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '60000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (97, 1, '2018-12-04 11:21:21', '115', 90, '5', '', '', '', '', '', '', '4', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '100000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (98, 2, '2018-12-04 11:21:33', '115', 90, '546', '', '', '', '', '', '', '6', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '100000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (99, 3, '2018-12-04 11:29:59', '115', 90, '546', '', '', '', '', '', '', '8', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '100000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (57, 1, '2018-11-19 16:45:39', '3118189600', 51, '123', '', '', '', '', '', '', '2', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (58, 1, '2018-11-19 16:46:01', '3113934112', 52, '111', '', '', '', '', '', '', '6', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (59, 2, '2018-11-19 16:50:06', '3113934112', 52, '111', '', '', '', '', '', '', '6', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (60, 1, '2018-11-19 16:50:41', '3117202048', 52, '123', '', '', '', '', '', '', '2', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (61, 2, '2018-11-19 16:53:53', '3117202048', 54, '123', '', '', '', '', '', '', '4', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (62, 2, '2018-11-19 16:54:07', '3113934112', 53, '111', '', '', '', '', '', '', '4', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (63, 3, '2018-11-19 16:54:20', '3117202048', 54, '123', '', '', '', '', '', '', '2', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (64, 1, '2018-11-19 16:54:29', '3117202048', 56, '2244', '', '', '', '', '', '', '2', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (65, 2, '2018-11-19 16:54:39', '3117202048', 53, '2244', '', '', '', '', '', '', '4', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (66, 2, '2018-11-19 16:54:52', '3117202048', 52, '2244', '', '', '', '', '', '', '6', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (67, 3, '2018-11-26 11:30:02', '3118189600', 84, '123456', 'KH1', '', '', '', '', '', '8', '2018-09-18 00:00:00', '2018-12-17 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (68, 3, '2018-11-26 11:30:02', '3117202048', 85, '2244', '', '', '', '', '', '', '8', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (69, 1, '2018-11-26 11:31:31', '3118189600', 84, '123789', '', '', '', '', '', '', '2', '2018-11-26 00:00:00', '2018-12-26 00:00:00', NULL, '', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (70, 1, '2018-12-03 16:29:09', '31181896003', 68, '222333', '', '', '', '', '', '', '2', '2018-12-03 00:00:00', '2019-01-03 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (71, 1, '2018-12-03 16:53:36', '31181896003', 68, '444', '', '', '', '', '', '', '2', '2018-12-03 00:00:00', '2019-01-03 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (72, 1, '2018-12-03 16:53:55', '31181896003', 68, '234', '', '', '', '', '', '', '4', '2018-12-03 00:00:00', '2019-01-03 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (73, 1, '2018-12-03 17:02:17', '31181896003', 68, '456789', '', '', '', '', '', '', '6', '2018-12-03 00:00:00', '2019-01-03 00:00:00', NULL, '70000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (74, 1, '2018-12-04 08:21:55', '111', 86, '123', '', '', '', '', '', '', '8', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '100000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (75, 1, '2018-12-04 08:22:50', '112', 87, '456', '', '', '', '', '', '', '8', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '60000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (76, 1, '2018-12-04 08:51:18', '114', 89, '145', '', '', '', '', '', '', '2', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (77, 3, '2018-12-04 09:11:58', '114', 89, '145', '', '', '', '', '', '', '6', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (78, 1, '2018-12-04 09:23:14', '113', 91, '7845', '', '', '', '', '', '', '6', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '80000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (79, 1, '2018-12-04 09:25:08', '115', 90, '63B1-21479', 'TEST USER', '312139451', 'BB', 'AA', 'CC', 'DD', '2', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (80, 2, '2018-12-04 09:59:27', '113', 95, '7845', '', '', '', '', '', '', '4', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '80000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (81, 2, '2018-12-04 09:59:57', '113', 95, '112233', '', '', '', '', '', '', '4', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '80000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (82, 2, '2018-12-04 10:01:52', '113', 97, '412', '', '', '', '', '', '', '2', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '80000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (83, 3, '2018-12-04 10:10:18', '115', 90, '63B1-21479', 'TEST USER', '312139451', 'BB', 'AA', 'CC', 'DD', '2', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (84, 2, '2018-12-04 10:10:49', '112', 87, '63H3-7132', 'KH 2', '123456789', 'CTY 12', 'mail2@gmail.com', 'Q1', 'honda', '4', '2018-03-04 00:00:00', '2018-03-31 00:00:00', NULL, '100000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (85, 2, '2018-12-04 10:11:12', '112', 96, '63H3-7132', 'KH 2', '123456789', 'CTY 12', 'mail2@gmail.com', 'Q1', 'honda', '6', '2018-03-04 00:00:00', '2018-03-31 00:00:00', NULL, '100000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (86, 2, '2018-12-04 10:11:27', '112', 92, '63H3-7132', 'KH 2', '123456789', 'CTY 12', 'mail2@gmail.com', 'Q1', 'honda', '8', '2018-03-04 00:00:00', '2018-03-31 00:00:00', NULL, '100000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (87, 1, '2018-12-04 10:59:04', '113', 93, '456', '', '', '', '', '', '', '8', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (88, 3, '2018-12-04 10:59:09', '113', 93, '456', '', '', '', '', '', '', '2', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (89, 1, '2018-12-04 11:01:02', '113', 93, '8', '', '', '', '', '', '', '6', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (90, 3, '2018-12-04 11:01:11', '113', 93, '8', '', '', '', '', '', '', '6', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '50000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (91, 3, '2018-12-04 11:01:52', '112', 92, '63H3-7132', 'KH 2', '123456789', 'CTY 12', 'mail2@gmail.com', 'Q1', 'honda', '2', '2018-03-04 00:00:00', '2018-03-31 00:00:00', NULL, '100000', 0, '2', NULL, NULL);
INSERT INTO `TicketLog` (`Identify`, `LogTypeID`, `ProcessDate`, `TicketMonthID`, `TicketMonthIdentify`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES (92, 1, '2018-12-04 11:09:22', '112', 92, '12', '', '', '', '', '', '', '4', '2018-12-04 00:00:00', '2019-01-04 00:00:00', NULL, '60000', 0, '2', NULL, NULL);
# 75 records

#
# Table structure for table 'TicketMonth'
#

DROP TABLE IF EXISTS `TicketMonth`;

CREATE TABLE `TicketMonth` (
  `ID` VARCHAR(255) NOT NULL, 
  `Identify` INTEGER AUTO_INCREMENT, 
  `ProcessDate` DATETIME, 
  `Digit` VARCHAR(255), 
  `CustomerName` VARCHAR(255), 
  `CMND` VARCHAR(255), 
  `Company` VARCHAR(255), 
  `Email` VARCHAR(255), 
  `Address` VARCHAR(255), 
  `CarKind` VARCHAR(255), 
  `IDPart` VARCHAR(255), 
  `RegistrationDate` DATETIME, 
  `ExpirationDate` DATETIME, 
  `Note` VARCHAR(255), 
  `ChargesAmount` VARCHAR(255), 
  `Status` INTEGER DEFAULT 0, 
  `Account` VARCHAR(255), 
  `Images` VARCHAR(255), 
  `DayUnlimit` DATETIME, 
  INDEX (`ID`), 
  INDEX (`IDPart`), 
  PRIMARY KEY (`ID`), 
  INDEX (`Identify`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'TicketMonth'
#

INSERT INTO `TicketMonth` (`ID`, `Identify`, `ProcessDate`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES ('111', 53, '2018-09-18 13:40:58', '63H3-7132', 'KH 1', '123456789', 'CTY 1', 'mail1@gmail.com', 'Q3', 'honda', '2', '2018-03-17 00:00:00', '2018-11-02 00:00:00', NULL, '100000', 0, '1', NULL, NULL);
INSERT INTO `TicketMonth` (`ID`, `Identify`, `ProcessDate`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES ('3113934112', 55, '2018-11-19 16:54:07', '111', NULL, NULL, NULL, NULL, NULL, NULL, '4', '2018-11-19 00:00:00', '2018-12-19 00:00:00', NULL, NULL, 0, '2', NULL, NULL);
INSERT INTO `TicketMonth` (`ID`, `Identify`, `ProcessDate`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES ('3118189600', 56, '2018-11-26 11:31:31', '123789', NULL, NULL, NULL, NULL, NULL, NULL, '6', '2018-11-26 00:00:00', '2018-12-26 00:00:00', NULL, NULL, 0, '2', NULL, NULL);
INSERT INTO `TicketMonth` (`ID`, `Identify`, `ProcessDate`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES ('3118244928', 57, '2018-11-08 16:28:12', '555555', NULL, NULL, NULL, NULL, NULL, NULL, '2', '2018-11-08 00:00:00', '2018-12-08 00:00:00', NULL, NULL, 0, '1', NULL, NULL);
INSERT INTO `TicketMonth` (`ID`, `Identify`, `ProcessDate`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES ('31181896003', 60, '2018-12-03 17:02:17', '456789', '', '', '', '', '', '', '8', '2018-12-03 00:00:00', '2019-01-03 00:00:00', NULL, '70000', 0, '2', NULL, NULL);
INSERT INTO `TicketMonth` (`ID`, `Identify`, `ProcessDate`, `Digit`, `CustomerName`, `CMND`, `Company`, `Email`, `Address`, `CarKind`, `IDPart`, `RegistrationDate`, `ExpirationDate`, `Note`, `ChargesAmount`, `Status`, `Account`, `Images`, `DayUnlimit`) VALUES ('116', 72, '2018-12-07 10:54:07', '547', '', '', '', '', '', '', '2', '2018-12-07 00:00:00', '2019-01-07 00:00:00', NULL, '70000', 0, '2', NULL, NULL);
# 6 records

#
# Table structure for table 'Type'
#

DROP TABLE IF EXISTS `Type`;

CREATE TABLE `Type` (
  `TypeID` VARCHAR(255) NOT NULL, 
  `TypeName` VARCHAR(255), 
  PRIMARY KEY (`TypeID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'Type'
#

INSERT INTO `Type` (`TypeID`, `TypeName`) VALUES ('1', 'Xe maI?y');
INSERT INTO `Type` (`TypeID`, `TypeName`) VALUES ('2', 'Xe AÅL tAÅL');
# 2 records

#
# Table structure for table 'UserCar'
#

DROP TABLE IF EXISTS `UserCar`;

CREATE TABLE `UserCar` (
  `UserID` VARCHAR(255) NOT NULL, 
  `Account` VARCHAR(255), 
  `Pass` VARCHAR(255), 
  `NameUser` VARCHAR(255), 
  `SexID` INTEGER DEFAULT 0, 
  `Working` INTEGER DEFAULT 0, 
  `IDFunct` VARCHAR(255), 
  `RememberMe` INTEGER DEFAULT 0, 
  INDEX (`IDFunct`), 
  PRIMARY KEY (`UserID`), 
  INDEX (`SexID`), 
  UNIQUE (`UserID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'UserCar'
#

INSERT INTO `UserCar` (`UserID`, `Account`, `Pass`, `NameUser`, `SexID`, `Working`, `IDFunct`, `RememberMe`) VALUES ('1', 'admin', '123456', 'Admin', 1, 0, 'Qu', 1);
INSERT INTO `UserCar` (`UserID`, `Account`, `Pass`, `NameUser`, `SexID`, `Working`, `IDFunct`, `RememberMe`) VALUES ('4', 'admin', 'admin', 'admin', 1, 0, 'Ad', 1);
INSERT INTO `UserCar` (`UserID`, `Account`, `Pass`, `NameUser`, `SexID`, `Working`, `IDFunct`, `RememberMe`) VALUES ('5', 'staff', 'staff', 'staff', 1, 0, 'Nh', 0);
INSERT INTO `UserCar` (`UserID`, `Account`, `Pass`, `NameUser`, `SexID`, `Working`, `IDFunct`, `RememberMe`) VALUES ('2', '1', '1', 'admin_2', 2, 0, 'Ad', 1);
INSERT INTO `UserCar` (`UserID`, `Account`, `Pass`, `NameUser`, `SexID`, `Working`, `IDFunct`, `RememberMe`) VALUES ('3', 'staff1', '123456', 'staff_1', 2, 0, 'Nh', 0);
INSERT INTO `UserCar` (`UserID`, `Account`, `Pass`, `NameUser`, `SexID`, `Working`, `IDFunct`, `RememberMe`) VALUES ('6', '4', '4', 'staff_4', 1, 0, 'Nh', 1);
INSERT INTO `UserCar` (`UserID`, `Account`, `Pass`, `NameUser`, `SexID`, `Working`, `IDFunct`, `RememberMe`) VALUES ('7', '90', '10', '80', 2, 0, 'Nh', 0);
# 7 records

#
# Table structure for table 'WorkAssign'
#

DROP TABLE IF EXISTS `WorkAssign`;

CREATE TABLE `WorkAssign` (
  `Identify` INTEGER NOT NULL AUTO_INCREMENT, 
  `UserID` VARCHAR(255), 
  `TimeStart` DATETIME, 
  `TimeEnd` DATETIME, 
  `Computer` VARCHAR(255), 
  INDEX (`Computer`), 
  PRIMARY KEY (`Identify`), 
  INDEX (`UserID`)
) ENGINE=myisam DEFAULT CHARSET=utf8;

SET autocommit=1;

#
# Dumping data for table 'WorkAssign'
#

INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (275, '1', '2018-03-23 11:25:47', '2018-03-23 11:26:35', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (276, '1', '2018-03-23 11:30:54', '2018-03-23 11:31:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (277, '1', '2018-03-23 11:37:37', '2018-03-23 11:39:33', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (278, '1', '2018-03-23 11:54:22', '2018-03-23 11:54:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (279, '1', '2018-03-23 13:56:58', '2018-03-23 13:58:18', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (280, '2', '2018-03-24 15:10:48', '2018-03-24 15:12:01', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (281, '6', '2018-03-24 15:20:16', '2018-03-24 15:20:52', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (282, '6', '2018-03-24 15:40:38', '2018-03-24 15:41:01', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (283, '6', '2018-03-24 15:41:25', '2018-03-24 15:41:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (284, '6', '2018-03-24 15:44:22', '2018-03-24 15:44:34', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (285, '6', '2018-03-24 15:45:25', '2018-03-24 15:45:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (286, '6', '2018-03-24 15:52:25', '2018-03-24 15:52:28', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (287, '6', '2018-03-24 15:55:43', '2018-03-24 15:55:57', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (288, '6', '2018-03-24 16:07:32', '2018-03-24 16:07:52', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (289, '6', '2018-03-24 16:08:16', '2018-03-24 16:08:23', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (290, '6', '2018-03-24 16:08:35', '2018-03-24 16:08:42', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (291, '6', '2018-03-24 16:09:58', '2018-03-24 16:10:07', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (292, '6', '2018-03-24 16:10:31', '2018-03-24 16:10:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (293, '6', '2018-03-24 16:11:04', '2018-03-24 16:11:15', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (294, '1', '2018-03-24 22:42:08', '2018-03-24 22:46:51', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (295, '1', '2018-03-25 09:21:14', '2018-03-25 09:22:24', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (296, '1', '2018-03-25 09:30:32', '2018-03-25 09:30:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (297, '1', '2018-03-25 09:31:35', '2018-03-25 09:35:46', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (298, '1', '2018-03-25 12:58:17', '2018-03-25 13:05:18', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (299, '1', '2018-03-27 16:49:39', '2018-03-27 16:50:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (300, '4', '2018-03-27 16:50:13', '2018-03-27 16:50:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (301, '1', '2018-03-27 16:52:21', '2018-03-27 16:52:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (302, '1', '2018-03-27 16:55:47', '2018-03-27 16:56:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (303, '3', '2018-03-27 16:59:17', '2018-03-27 16:59:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (304, '3', '2018-03-27 16:59:44', '2018-03-27 17:00:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (305, '6', '2018-03-28 11:55:01', '2018-03-28 11:57:43', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (306, '1', '2018-03-28 13:27:05', '2018-03-28 13:27:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (307, '1', '2018-03-28 13:29:52', '2018-03-28 13:30:33', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (308, '1', '2018-03-28 13:32:07', '2018-03-28 13:32:36', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (309, '1', '2018-03-28 14:24:32', '2018-03-28 14:25:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (310, '1', '2018-03-28 14:25:49', '2018-03-28 14:26:16', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (311, '1', '2018-03-28 14:29:58', '2018-03-28 14:30:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (312, '1', '2018-03-28 14:45:15', '2018-03-28 14:45:34', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (313, '6', '2018-03-29 09:26:04', '2018-03-29 09:26:18', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (314, '6', '2018-03-29 09:36:36', '2018-03-29 09:37:03', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (315, '6', '2018-03-29 09:58:19', '2018-03-29 09:58:38', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (316, '6', '2018-03-29 09:58:54', '2018-03-29 09:59:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (317, '1', '2018-03-29 10:32:58', '2018-03-29 10:33:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (318, '1', '2018-03-29 11:49:44', '2018-03-29 11:49:47', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (319, '1', '2018-03-29 11:51:36', '2018-03-29 11:51:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (320, '1', '2018-03-29 11:54:09', '2018-03-29 11:54:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (321, '1', '2018-03-29 13:35:02', '2018-03-29 13:35:15', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (322, '1', '2018-03-29 13:37:27', '2018-03-29 13:37:31', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (323, '2', '2018-03-29 13:37:35', '2018-03-29 13:37:36', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (324, '1', '2018-03-29 13:41:18', '2018-03-29 13:42:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (325, '1', '2018-03-29 14:01:47', '2018-03-29 14:02:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (326, '6', '2018-03-30 13:36:12', '2018-03-30 13:37:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (327, '6', '2018-03-30 13:37:49', '2018-03-30 13:37:58', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (328, '6', '2018-03-30 13:38:35', '2018-03-30 13:38:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (329, '6', '2018-03-30 13:39:09', '2018-03-30 13:39:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (330, '6', '2018-03-30 13:39:34', '2018-03-30 13:39:39', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (331, '6', '2018-03-30 14:24:14', '2018-03-30 14:24:33', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (332, '6', '2018-03-30 14:28:14', '2018-03-30 14:28:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (333, '6', '2018-03-30 14:32:28', '2018-03-30 14:32:39', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (334, '1', '2018-03-30 16:40:04', '2018-03-30 16:41:21', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (335, '2', '2018-03-30 16:50:48', '2018-03-30 16:50:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (336, '1', '2018-03-30 16:50:59', '2018-03-30 16:51:47', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (337, '1', '2018-03-30 16:58:04', '2018-03-30 16:58:06', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (338, '1', '2018-03-30 16:59:45', '2018-03-30 16:59:50', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (339, '1', '2018-03-30 17:06:40', '2018-03-30 17:07:05', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (340, '2', '2018-03-30 17:15:51', '2018-03-30 17:16:49', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (341, '2', '2018-04-03 14:28:37', '2018-04-03 14:28:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (342, '2', '2018-04-03 14:47:01', '2018-04-03 14:47:27', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (343, '2', '2018-04-03 16:55:22', '2018-04-03 16:56:11', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (344, '2', '2018-04-04 10:34:02', '2018-04-04 10:34:45', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (345, '2', '2018-04-04 13:45:12', '2018-04-04 13:45:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (346, '2', '2018-04-04 16:23:33', '2018-04-04 16:24:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (347, '2', '2018-04-04 16:25:18', '2018-04-04 16:25:30', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (348, '1', '2018-04-04 16:26:58', '2018-04-04 16:27:35', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (349, '2', '2018-04-06 09:30:47', '2018-04-06 09:31:04', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (350, '2', '2018-04-06 09:33:55', '2018-04-06 09:41:43', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (351, '1', '2018-04-09 09:01:27', '2018-04-09 09:01:45', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (352, '1', '2018-04-09 09:25:30', '2018-04-09 09:26:29', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (353, '1', '2018-04-09 09:32:26', '2018-04-09 09:33:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (354, '1', '2018-04-09 10:20:51', '2018-04-09 10:22:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (355, '1', '2018-04-09 10:24:19', '2018-04-09 10:24:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (356, '1', '2018-04-09 14:40:27', '2018-04-09 14:40:41', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (357, '1', '2018-04-09 14:41:03', '2018-04-09 14:41:41', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (358, '1', '2018-04-09 14:50:08', '2018-04-09 14:50:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (359, '1', '2018-04-09 14:51:01', '2018-04-09 14:51:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (360, '1', '2018-04-09 14:53:32', '2018-04-09 14:53:51', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (361, '1', '2018-04-09 14:56:24', '2018-04-09 14:56:59', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (362, '1', '2018-04-09 15:01:19', '2018-04-09 15:01:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (363, '1', '2018-04-09 15:17:09', '2018-04-09 15:17:37', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (364, '1', '2018-04-09 15:19:09', '2018-04-09 15:19:32', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (365, '1', '2018-04-09 15:52:02', '2018-04-09 15:52:23', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (366, '1', '2018-04-09 15:54:25', '2018-04-09 15:54:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (367, '1', '2018-04-09 15:56:05', '2018-04-09 15:56:18', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (368, '1', '2018-04-09 15:57:27', '2018-04-09 15:57:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (369, '1', '2018-04-10 13:38:55', '2018-04-10 13:39:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (370, '1', '2018-04-10 13:58:43', '2018-04-10 13:59:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (371, '1', '2018-04-10 14:12:17', '2018-04-10 14:12:30', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (372, '1', '2018-04-10 14:42:01', '2018-04-10 14:42:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (373, '1', '2018-04-10 14:44:57', '2018-04-10 14:45:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (374, '1', '2018-04-10 14:55:13', '2018-04-10 14:55:30', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (375, '1', '2018-04-11 10:36:40', '2018-04-11 10:39:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (376, '1', '2018-04-11 11:02:12', '2018-04-11 11:02:33', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (377, '1', '2018-04-11 11:12:52', '2018-04-11 11:13:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (378, '1', '2018-04-11 11:14:58', '2018-04-11 11:16:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (379, '1', '2018-04-11 17:04:16', '2018-04-11 17:05:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (380, '1', '2018-04-11 17:06:47', '2018-04-11 17:07:32', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (381, '1', '2018-04-12 08:50:11', '2018-04-12 08:51:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (382, '1', '2018-04-12 09:14:49', '2018-04-12 09:15:34', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (383, '1', '2018-04-12 11:22:30', '2018-04-12 11:24:51', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (384, '1', '2018-04-12 11:25:43', '2018-04-12 11:26:05', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (385, '1', '2018-04-12 11:27:19', '2018-04-12 11:28:07', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (386, '1', '2018-04-12 15:05:23', '2018-04-12 15:13:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (387, '1', '2018-04-12 15:16:37', '2018-04-12 15:17:43', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (388, '1', '2018-04-12 15:34:33', '2018-04-12 15:35:35', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (389, '1', '2018-04-12 16:19:46', '2018-04-12 16:20:29', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (390, '1', '2018-04-16 13:23:04', '2018-04-16 13:23:10', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (391, '6', '2018-04-16 13:23:15', '2018-04-16 13:23:38', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (392, '6', '2018-04-16 13:28:12', '2018-04-16 13:28:34', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (393, '6', '2018-04-16 13:30:17', '2018-04-16 13:30:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (394, '6', '2018-04-16 13:42:42', '2018-04-16 13:43:05', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (395, '6', '2018-04-16 13:44:30', '2018-04-16 13:44:39', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (396, '6', '2018-04-16 14:09:57', '2018-04-16 14:10:20', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (397, '6', '2018-04-16 14:25:54', '2018-04-16 14:26:06', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (398, '6', '2018-04-16 14:26:30', '2018-04-16 14:26:54', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (399, '6', '2018-04-16 14:27:32', '2018-04-16 14:27:43', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (400, '6', '2018-04-16 14:37:46', '2018-04-16 14:37:56', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (401, '6', '2018-04-16 16:36:11', '2018-04-16 16:36:19', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (402, '6', '2018-04-16 16:38:18', '2018-04-16 16:38:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (403, '6', '2018-04-16 16:40:01', '2018-04-16 16:40:19', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (404, '6', '2018-04-16 16:57:21', '2018-04-16 16:57:30', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (405, '6', '2018-04-16 17:05:40', '2018-04-16 17:05:50', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (406, '6', '2018-04-17 10:30:11', '2018-04-17 10:30:48', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (407, '6', '2018-04-17 11:00:36', '2018-04-17 11:02:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (408, '6', '2018-04-17 13:24:23', '2018-04-17 13:25:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (409, '6', '2018-04-17 13:37:49', '2018-04-17 13:37:55', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (410, '6', '2018-04-17 13:38:19', '2018-04-17 13:38:49', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (411, '6', '2018-04-17 13:39:03', '2018-04-17 13:39:07', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (412, '2', '2018-04-17 13:39:09', '2018-04-17 13:39:59', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (413, '2', '2018-04-17 13:42:58', '2018-04-17 13:43:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (414, '2', '2018-04-17 13:45:03', '2018-04-17 13:45:32', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (415, '2', '2018-04-17 13:46:12', '2018-04-17 13:46:27', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (416, '2', '2018-04-17 14:01:06', '2018-04-17 14:01:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (417, '6', '2018-04-17 14:24:19', '2018-04-17 14:24:54', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (418, '6', '2018-04-17 14:25:46', '2018-04-17 14:25:51', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (419, '6', '2018-04-17 14:27:11', '2018-04-17 14:27:32', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (420, '2', '2018-04-17 15:10:28', '2018-04-17 15:10:57', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (421, '6', '2018-04-17 15:40:26', '2018-04-17 15:40:58', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (422, '6', '2018-04-17 15:51:44', '2018-04-17 15:52:32', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (423, '2', '2018-04-17 15:52:35', '2018-04-17 15:53:32', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (424, '2', '2018-04-17 15:56:06', '2018-04-17 15:56:27', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (425, '2', '2018-04-17 15:56:49', '2018-04-17 15:57:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (426, '6', '2018-04-17 16:18:19', '2018-04-17 16:18:51', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (427, '6', '2018-04-17 16:21:27', '2018-04-17 16:24:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (428, '1', '2018-04-17 16:49:19', '2018-04-17 16:50:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (429, '1', '2018-04-24 15:28:30', '2018-04-24 15:54:20', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (430, '6', '2018-07-08 10:45:13', '2018-07-08 10:45:23', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (431, '6', '2018-07-08 11:23:07', '2018-07-08 11:23:41', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (432, '6', '2018-07-08 11:26:33', '2018-07-08 11:27:24', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (433, '6', '2018-07-08 11:28:43', '2018-07-08 11:29:06', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (434, '6', '2018-07-08 11:42:02', '2018-07-08 11:42:34', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (435, '6', '2018-07-08 11:44:45', '2018-07-08 11:44:53', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (436, '6', '2018-07-08 11:45:40', '2018-07-08 11:46:00', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (437, '6', '2018-07-08 11:48:41', '2018-07-08 11:49:11', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (438, '6', '2018-07-08 13:28:16', '2018-07-08 13:28:30', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (439, '6', '2018-07-08 13:30:22', '2018-07-08 13:30:31', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (440, '6', '2018-07-08 13:30:57', '2018-07-08 13:31:03', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (441, '6', '2018-07-08 13:37:53', '2018-07-08 13:38:00', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (442, '6', '2018-07-08 13:42:04', '2018-07-08 13:42:11', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (443, '6', '2018-07-08 13:43:15', '2018-07-08 13:43:37', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (444, '6', '2018-07-08 13:44:25', '2018-07-08 13:44:34', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (445, '6', '2018-07-08 13:50:52', '2018-07-08 13:51:02', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (446, '6', '2018-07-08 13:54:44', '2018-07-08 13:54:55', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (447, '6', '2018-07-08 13:55:11', '2018-07-08 13:55:17', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (448, '6', '2018-07-08 13:57:18', '2018-07-08 13:57:45', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (449, '6', '2018-07-08 13:57:56', '2018-07-08 13:58:33', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (450, '6', '2018-07-08 13:59:55', '2018-07-08 14:00:07', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (451, '6', '2018-07-08 14:00:21', '2018-07-08 14:00:45', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (452, '6', '2018-07-08 14:01:16', '2018-07-08 14:02:34', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (453, '6', '2018-07-08 14:02:49', '2018-07-08 14:04:26', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (454, '6', '2018-07-08 14:10:32', '2018-07-08 14:10:44', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (455, '6', '2018-07-08 14:12:37', '2018-07-08 14:13:06', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (456, '6', '2018-07-08 14:54:02', '2018-07-08 14:54:49', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (457, '6', '2018-07-08 14:59:00', '2018-07-08 14:59:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (458, '6', '2018-07-08 15:05:16', '2018-07-08 15:05:25', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (459, '6', '2018-07-08 15:06:40', '2018-07-08 15:06:48', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (460, '6', '2018-07-08 15:08:12', '2018-07-08 15:08:44', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (461, '6', '2018-07-08 15:11:19', '2018-07-08 15:11:34', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (462, '6', '2018-07-15 12:24:38', '2018-07-15 12:25:13', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (463, '6', '2018-07-15 12:25:48', '2018-07-15 12:26:27', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (464, '6', '2018-07-15 12:27:58', '2018-07-15 12:28:48', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (465, '6', '2018-07-15 12:43:29', '2018-07-15 12:45:15', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (466, '6', '2018-07-15 12:48:05', '2018-07-15 12:48:29', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (467, '6', '2018-07-15 13:09:51', '2018-07-15 13:10:48', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (468, '6', '2018-07-15 13:19:49', '2018-07-15 13:20:46', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (469, '6', '2018-07-15 13:22:47', '2018-07-15 13:35:30', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (470, '6', '2018-07-15 13:36:05', '2018-07-15 13:36:56', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (471, '6', '2018-07-15 13:39:38', '2018-07-15 13:40:23', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (472, '6', '2018-07-15 13:40:31', '2018-07-15 13:41:32', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (473, '6', '2018-07-15 13:43:16', '2018-07-15 13:45:45', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (474, '1', '2018-07-15 13:45:49', '2018-07-15 13:49:24', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (475, '6', '2018-07-15 13:51:18', '2018-07-15 13:52:15', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (476, '6', '2018-07-15 13:52:17', '2018-07-15 13:52:21', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (477, '1', '2018-07-15 13:52:23', '2018-07-15 13:53:26', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (478, '1', '2018-07-15 13:53:33', '2018-07-15 13:53:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (479, '6', '2018-07-15 13:53:40', '2018-07-15 13:54:13', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (480, '6', '2018-07-15 13:54:49', '2018-07-15 13:55:13', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (481, '6', '2018-07-15 13:55:19', '2018-07-15 13:55:51', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (482, '1', '2018-07-15 13:57:05', '2018-07-15 13:57:37', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (483, '1', '2018-07-15 14:02:40', '2018-07-15 14:03:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (484, '6', '2018-07-15 14:03:47', '2018-07-15 14:04:06', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (485, '6', '2018-07-15 14:04:12', '2018-07-15 14:05:04', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (486, '6', '2018-07-15 14:09:36', '2018-07-15 14:10:40', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (487, '6', '2018-07-15 14:11:29', '2018-07-15 14:12:18', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (488, '1', '2018-07-15 14:12:22', '2018-07-15 14:12:48', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (489, '6', '2018-07-17 22:32:40', '2018-07-17 22:34:05', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (490, '6', '2018-07-17 22:40:18', '2018-07-17 22:42:48', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (491, '6', '2018-07-17 22:48:51', '2018-07-17 22:49:40', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (492, '6', '2018-07-17 22:49:47', '2018-07-17 23:03:01', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (493, '6', '2018-07-17 23:11:46', '2018-07-17 23:19:08', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (494, '6', '2018-07-17 23:31:48', '2018-07-17 23:32:35', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (495, '6', '2018-07-24 22:26:18', '2018-07-24 22:27:13', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (496, '6', '2018-07-24 22:31:45', '2018-07-24 22:31:58', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (497, '1', '2018-07-24 22:32:02', '2018-07-24 22:32:13', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (498, '6', '2018-07-26 21:33:07', '2018-07-26 21:33:23', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (499, '6', '2018-07-26 21:33:55', '2018-07-26 21:35:01', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (500, '6', '2018-07-26 21:37:08', '2018-07-26 21:37:45', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (501, '6', '2018-07-26 21:40:17', '2018-07-26 21:40:26', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (502, '6', '2018-07-26 21:40:50', '2018-07-26 21:41:01', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (503, '6', '2018-07-26 21:41:21', '2018-07-26 21:41:55', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (504, '6', '2018-07-26 21:44:30', '2018-07-26 21:44:42', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (505, '6', '2018-08-02 21:30:39', '2018-08-02 21:30:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (506, '6', '2018-08-02 22:05:37', '2018-08-02 22:05:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (507, '6', '2018-08-02 22:12:29', '2018-08-02 22:12:44', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (508, '6', '2018-08-06 21:33:42', '2018-08-06 21:33:50', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (509, '6', '2018-08-06 21:52:59', '2018-08-06 21:53:08', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (510, '6', '2018-08-06 22:06:45', '2018-08-06 22:06:52', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (511, '6', '2018-08-06 22:11:12', '2018-08-06 22:11:19', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (512, '6', '2018-08-06 22:12:03', '2018-08-06 22:13:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (513, '6', '2018-08-06 22:13:43', '2018-08-06 22:13:52', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (514, '6', '2018-08-06 22:15:56', '2018-08-06 22:16:02', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (515, '6', '2018-08-06 22:18:52', '2018-08-06 22:19:11', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (516, '6', '2018-08-06 22:32:10', '2018-08-06 22:32:22', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (517, '6', '2018-08-06 22:32:46', '2018-08-06 22:32:53', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (518, '6', '2018-08-06 22:39:23', '2018-08-06 22:39:47', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (519, '6', '2018-08-06 22:40:08', '2018-08-06 22:40:23', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (520, '6', '2018-08-06 22:40:35', '2018-08-06 22:40:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (521, '6', '2018-08-06 22:42:31', '2018-08-06 22:42:36', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (522, '6', '2018-08-17 22:54:34', '2018-08-17 22:55:09', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (523, '5', '2018-08-18 11:30:23', '2018-08-18 11:38:19', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (524, '6', '2018-08-18 15:52:55', '2018-08-18 15:53:27', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (525, '6', '2018-08-18 15:54:01', '2018-08-18 15:54:42', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (526, '6', '2018-08-18 19:57:28', '2018-08-18 19:57:36', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (527, '6', '2018-08-18 22:09:01', '2018-08-18 22:09:11', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (528, '6', '2018-08-18 22:13:26', '2018-08-18 22:13:35', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (529, '6', '2018-08-19 07:38:41', '2018-08-19 07:38:47', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (530, '6', '2018-08-19 07:53:14', '2018-08-19 07:53:42', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (531, '6', '2018-08-19 07:54:03', '2018-08-19 07:54:47', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (532, '6', '2018-08-19 07:55:56', '2018-08-19 07:56:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (533, '6', '2018-08-19 07:57:05', '2018-08-19 07:57:11', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (534, '6', '2018-08-19 07:58:09', '2018-08-19 07:58:16', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (535, '6', '2018-08-19 08:06:00', '2018-08-19 08:07:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (536, '1', '2018-08-19 08:26:41', '2018-08-19 08:30:05', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (537, '6', '2018-08-19 08:30:30', '2018-08-19 08:31:57', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (538, '6', '2018-08-19 08:34:11', '2018-08-19 08:34:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (539, '6', '2018-08-19 08:35:00', '2018-08-19 08:35:55', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (540, '6', '2018-08-19 08:47:13', '2018-08-19 08:47:32', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (541, '6', '2018-08-19 08:48:09', '2018-08-19 08:48:29', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (542, '6', '2018-08-19 08:49:01', '2018-08-19 08:50:02', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (543, '6', '2018-08-19 08:50:56', '2018-08-19 08:51:15', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (544, '6', '2018-08-19 08:51:39', '2018-08-19 08:51:53', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (545, '6', '2018-08-19 08:52:04', '2018-08-19 08:52:28', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (546, '6', '2018-08-19 08:53:16', '2018-08-19 08:53:23', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (547, '6', '2018-08-19 08:54:07', '2018-08-19 08:54:56', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (548, '6', '2018-08-19 08:58:31', '2018-08-19 08:58:35', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (549, '1', '2018-08-19 09:03:24', '2018-08-19 09:03:51', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (550, '6', '2018-08-19 09:03:55', '2018-08-19 09:04:07', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (551, '1', '2018-08-19 11:12:42', '2018-08-19 11:13:17', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (552, '6', '2018-08-19 11:13:24', '2018-08-19 11:13:52', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (553, '6', '2018-08-19 12:04:13', '2018-08-19 12:04:26', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (554, '1', '2018-08-19 12:04:42', '2018-08-19 12:05:13', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (555, '1', '2018-08-19 12:08:03', '2018-08-19 12:08:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (556, '6', '2018-08-19 15:57:27', '2018-08-19 15:57:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (557, '1', '2018-08-19 15:57:45', '2018-08-19 15:57:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (558, '6', '2018-08-19 15:58:01', '2018-08-19 15:59:27', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (559, '6', '2018-08-19 15:59:34', '2018-08-19 16:09:07', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (560, '6', '2018-08-19 16:12:08', '2018-08-19 16:13:42', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (561, '6', '2018-08-19 16:19:29', '2018-08-19 16:21:05', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (562, '6', '2018-08-19 16:21:23', '2018-08-19 16:22:00', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (563, '6', '2018-08-19 16:22:46', '2018-08-19 16:23:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (564, '6', '2018-08-19 16:34:54', '2018-08-19 16:35:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (565, '6', '2018-08-19 16:36:02', '2018-08-19 16:36:12', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (566, '6', '2018-08-19 16:53:04', '2018-08-19 16:54:20', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (567, '6', '2018-08-19 17:00:11', '2018-08-19 17:01:07', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (568, '6', '2018-08-19 17:26:11', '2018-08-19 17:26:50', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (569, '6', '2018-08-19 17:26:56', '2018-08-19 17:27:49', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (570, '6', '2018-08-19 17:31:57', '2018-08-19 17:34:57', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (571, '6', '2018-08-19 17:42:12', '2018-08-19 17:44:09', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (572, '6', '2018-08-19 17:40:26', '2018-08-19 17:44:12', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (573, '6', '2018-08-19 17:47:19', '2018-08-19 17:48:20', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (574, '6', '2018-08-19 17:48:47', '2018-08-19 17:49:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (575, '6', '2018-08-19 17:53:42', '2018-08-19 17:54:37', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (576, '6', '2018-08-19 17:54:42', '2018-08-19 17:55:47', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (577, '6', '2018-08-19 18:18:17', '2018-08-19 18:19:53', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (578, '6', '2018-08-19 18:20:27', '2018-08-19 18:21:44', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (579, '6', '2018-08-19 18:27:48', '2018-08-19 18:27:58', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (580, '6', '2018-08-19 18:28:49', '2018-08-19 18:29:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (581, '6', '2018-08-19 18:45:28', '2018-08-19 18:46:21', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (582, '1', '2018-09-17 10:09:46', '2018-09-17 10:10:27', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (583, '1', '2018-09-17 10:58:28', '2018-09-17 10:58:55', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (584, '1', '2018-09-17 14:24:45', '2018-09-17 14:25:37', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (585, '6', '2018-09-17 14:25:39', '2018-09-17 14:25:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (586, '1', '2018-09-17 14:25:55', '2018-09-17 14:26:22', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (587, '6', '2018-09-17 14:26:25', '2018-09-17 14:26:35', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (588, '1', '2018-09-17 15:22:11', '2018-09-17 15:22:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (589, '1', '2018-09-17 15:39:25', '2018-09-17 15:39:32', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (590, '1', '2018-09-17 16:10:09', '2018-09-17 16:10:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (591, '1', '2018-09-17 16:10:49', '2018-09-17 16:10:57', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (592, '1', '2018-09-17 16:11:06', '2018-09-17 16:11:15', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (593, '1', '2018-09-17 16:12:44', '2018-09-17 16:13:05', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (594, '1', '2018-09-17 16:13:21', '2018-09-17 16:13:27', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (595, '1', '2018-09-17 16:14:20', '2018-09-17 16:15:04', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (596, '1', '2018-09-17 16:15:06', '2018-09-17 16:15:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (597, '6', '2018-09-17 16:18:05', '2018-09-17 16:18:20', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (598, '1', '2018-09-17 16:50:57', '2018-09-17 16:51:41', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (599, '1', '2018-09-17 16:53:50', '2018-09-17 16:54:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (600, '1', '2018-09-17 17:06:56', '2018-09-17 17:07:33', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (601, '1', '2018-09-17 17:24:31', '2018-09-17 17:25:18', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (602, '1', '2018-09-17 17:37:35', '2018-09-17 17:37:48', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (603, '1', '2018-09-17 17:41:35', '2018-09-17 17:42:22', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (604, '1', '2018-09-17 17:42:53', '2018-09-17 17:43:50', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (605, '6', '2018-09-17 18:24:43', '2018-09-17 18:26:24', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (606, '1', '2018-09-17 18:26:28', '2018-09-17 18:28:51', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (607, '6', '2018-09-17 18:28:56', '2018-09-17 23:35:51', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (608, '1', '2018-09-17 23:35:58', '2018-09-17 23:36:27', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (609, '6', '2018-09-17 23:36:32', '2018-09-23 20:28:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (610, '6', '2018-09-23 20:31:22', '2018-09-25 08:37:52', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (611, '6', '2018-09-28 08:46:39', '2018-09-28 20:50:51', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (612, '1', '2018-09-18 09:53:45', '2018-09-18 09:55:07', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (613, '1', '2018-09-18 10:22:51', '2018-09-18 10:31:57', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (614, '1', '2018-09-18 10:32:53', '2018-09-18 10:33:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (615, '1', '2018-09-18 10:37:34', '2018-09-18 10:38:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (616, '6', '2018-09-18 10:38:17', '2018-09-18 10:38:39', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (617, '1', '2018-09-18 10:57:01', '2018-09-18 10:57:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (618, '1', '2018-09-18 11:01:23', '2018-09-18 11:02:45', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (619, '1', '2018-09-18 11:15:16', '2018-09-18 11:15:31', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (620, '1', '2018-09-18 11:16:05', '2018-09-18 11:16:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (621, '1', '2018-09-18 11:27:09', '2018-09-18 11:27:52', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (622, '1', '2018-09-18 11:33:04', '2018-09-18 11:33:34', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (623, '1', '2018-09-18 13:33:31', '2018-09-18 13:41:05', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (624, '1', '2018-09-18 13:43:15', '2018-09-18 13:45:35', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (625, '1', '2018-09-18 13:59:36', '2018-09-18 14:00:35', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (626, '1', '2018-09-18 14:05:56', '2018-09-18 14:06:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (627, '1', '2018-09-18 14:15:48', '2018-09-18 14:16:55', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (628, '1', '2018-09-19 10:29:12', '2018-09-19 11:07:41', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (629, '1', '2018-09-19 11:07:44', '2018-09-19 11:08:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (630, '1', '2018-09-19 11:08:04', '2018-09-19 11:08:11', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (631, '1', '2018-09-19 11:09:56', '2018-09-19 11:10:31', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (632, '1', '2018-09-19 11:17:46', '2018-09-19 11:20:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (633, '1', '2018-09-19 11:28:35', '2018-09-19 11:29:00', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (634, '1', '2018-09-19 11:29:26', '2018-09-19 11:30:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (635, '1', '2018-09-19 11:37:45', '2018-09-19 11:38:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (636, '1', '2018-09-19 11:57:46', '2018-09-19 11:58:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (637, '6', '2018-09-22 15:45:18', '2018-09-22 15:45:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (638, '1', '2018-09-22 15:45:45', '2018-09-22 15:46:08', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (639, '1', '2018-09-22 15:54:57', '2018-09-22 15:56:19', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (640, '1', '2018-09-22 16:04:09', '2018-09-22 16:04:25', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (641, '1', '2018-09-22 16:08:13', '2018-09-22 16:09:31', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (642, '1', '2018-09-22 16:13:14', '2018-09-22 16:13:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (643, '1', '2018-09-22 16:21:11', '2018-09-22 16:21:52', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (644, '6', '2018-09-22 16:21:55', '2018-09-22 16:23:37', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (645, '1', '2018-09-22 16:23:44', '2018-09-22 16:25:49', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (646, '1', '2018-09-22 16:38:09', '2018-09-22 16:38:23', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (647, '1', '2018-09-22 16:38:34', '2018-09-22 16:39:16', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (648, '1', '2018-09-22 16:42:01', '2018-09-22 16:42:49', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (649, '6', '2018-09-22 16:45:35', '2018-09-22 16:46:03', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (650, '1', '2018-09-22 16:57:02', '2018-09-22 16:57:47', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (651, '1', '2018-09-22 16:57:49', '2018-09-22 16:57:55', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (652, '1', '2018-09-22 17:14:00', '2018-09-22 17:14:28', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (653, '1', '2018-09-22 17:14:30', '2018-09-22 17:14:36', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (654, '6', '2018-09-22 17:16:15', '2018-09-22 17:17:06', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (655, '1', '2018-09-22 17:19:21', '2018-09-22 17:20:00', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (656, '1', '2018-09-22 17:21:07', '2018-09-22 17:21:17', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (657, '1', '2018-09-22 17:25:56', '2018-09-22 17:26:04', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (658, '1', '2018-09-22 17:26:22', '2018-09-22 17:27:05', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (659, '1', '2018-09-22 17:27:07', '2018-09-22 17:28:06', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (660, '6', '2018-09-23 08:32:32', '2018-09-23 08:32:53', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (661, '6', '2018-09-23 08:43:15', '2018-09-23 08:43:40', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (662, '6', '2018-09-23 08:47:49', '2018-09-23 08:48:15', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (663, '6', '2018-09-23 08:49:43', '2018-09-23 08:51:19', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (664, '6', '2018-09-24 15:09:23', '2018-09-24 15:09:33', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (665, '1', '2018-09-24 15:25:01', '2018-09-24 15:25:10', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (666, '6', '2018-09-24 15:26:07', '2018-09-24 15:26:38', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (667, '1', '2018-09-25 14:12:28', '2018-09-25 14:12:47', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (668, '1', '2018-09-25 14:55:34', '2018-09-25 14:56:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (669, '1', '2018-09-25 14:56:05', '2018-09-25 14:56:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (670, '1', '2018-09-25 14:57:06', '2018-09-25 14:57:23', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (671, '1', '2018-09-25 15:08:43', '2018-09-25 15:11:45', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (672, '1', '2018-09-25 15:26:21', '2018-09-25 15:27:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (673, '6', '2018-09-25 15:28:28', '2018-09-25 15:28:43', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (674, '1', '2018-09-25 15:31:45', '2018-09-25 15:32:29', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (675, '1', '2018-09-26 20:29:13', '2018-09-26 20:30:32', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (676, '6', '2018-09-26 20:30:35', '2018-09-26 20:32:44', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (677, '1', '2018-09-26 20:47:10', '2018-09-26 20:50:23', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (678, '1', '2018-09-26 20:52:07', '2018-09-26 20:57:26', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (679, '6', '2018-09-26 21:06:27', '2018-09-26 21:06:57', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (680, '6', '2018-09-26 21:07:43', '2018-09-26 21:09:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (681, '6', '2018-09-26 21:12:08', '2018-09-26 21:12:23', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (682, '6', '2018-09-26 21:13:32', '2018-09-26 21:17:17', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (683, '6', '2018-09-26 21:19:26', '2018-09-26 21:20:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (684, '6', '2018-09-26 21:36:45', '2018-09-26 21:37:00', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (685, '6', '2018-09-26 21:38:01', '2018-09-26 21:38:08', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (686, '6', '2018-09-26 21:38:01', '2018-09-26 21:38:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (687, '6', '2018-09-26 21:38:36', '2018-09-26 21:38:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (688, '1', '2018-09-26 21:40:14', '2018-09-26 21:40:16', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (689, '1', '2018-09-26 21:40:14', '2018-09-26 21:40:16', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (690, '6', '2018-09-26 21:42:45', '2018-09-26 21:42:46', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (691, '1', '2018-09-26 21:43:02', '2018-09-26 21:43:03', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (692, '1', '2018-09-26 21:43:02', '2018-09-26 21:43:09', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (693, '1', '2018-09-26 21:43:17', '2018-09-26 21:43:22', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (694, '6', '2018-09-26 21:43:26', '2018-09-26 21:43:35', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (695, '6', '2018-09-26 21:46:03', '2018-09-26 21:46:03', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (696, '6', '2018-09-26 21:46:03', '2018-09-26 21:46:29', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (697, '6', '2018-09-26 21:46:03', '2018-09-26 21:46:32', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (698, '1', '2018-10-01 13:24:45', '2018-10-01 13:25:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (699, '6', '2018-10-01 13:25:12', '2018-10-01 13:27:31', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (700, '6', '2018-10-01 13:25:12', '2018-10-01 13:28:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (701, '1', '2018-10-01 14:57:50', '2018-10-01 14:58:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (702, '1', '2018-10-01 16:26:35', '2018-10-01 16:27:03', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (703, '1', '2018-10-01 16:39:09', '2018-10-01 16:39:20', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (704, '1', '2018-10-01 16:44:19', '2018-10-01 16:44:39', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (705, '1', '2018-10-01 16:46:46', '2018-10-01 16:47:50', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (706, '1', '2018-10-01 16:50:27', '2018-10-01 16:50:41', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (707, '1', '2018-10-01 16:52:16', '2018-10-01 16:52:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (708, '1', '2018-10-01 17:02:46', '2018-10-01 17:03:00', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (709, '1', '2018-10-02 11:06:14', '2018-10-02 11:15:55', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (710, '1', '2018-10-02 11:19:07', '2018-10-02 11:20:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (711, '1', '2018-10-02 11:25:57', '2018-10-02 11:26:57', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (712, '1', '2018-10-02 11:33:37', '2018-10-02 11:34:05', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (713, '1', '2018-10-02 11:46:07', '2018-10-02 11:46:19', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (714, '1', '2018-10-02 11:49:39', '2018-10-02 11:49:54', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (715, '1', '2018-10-02 13:30:53', '2018-10-02 14:04:52', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (716, '1', '2018-10-02 14:05:21', '2018-10-02 14:28:41', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (717, '1', '2018-10-02 14:32:06', '2018-10-02 14:32:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (718, '1', '2018-10-02 14:38:01', '2018-10-02 14:38:15', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (719, '1', '2018-10-02 14:41:34', '2018-10-02 14:42:04', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (720, '1', '2018-10-02 14:51:04', '2018-10-02 14:54:23', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (721, '1', '2018-10-02 15:01:24', '2018-10-02 15:02:11', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (722, '1', '2018-10-02 15:05:23', '2018-10-02 15:06:31', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (723, '1', '2018-10-02 15:09:06', '2018-10-02 15:09:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (724, '1', '2018-10-02 15:10:12', '2018-10-02 15:11:04', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (725, '1', '2018-10-02 15:20:40', '2018-10-02 15:21:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (726, '1', '2018-10-02 15:22:16', '2018-10-02 15:23:10', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (727, '1', '2018-10-02 15:25:57', '2018-10-02 15:27:06', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (728, '1', '2018-10-02 15:29:11', '2018-10-02 15:29:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (729, '1', '2018-10-02 15:39:18', '2018-10-02 15:39:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (730, '1', '2018-10-02 15:45:44', '2018-10-02 15:45:57', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (731, '1', '2018-10-02 16:11:02', '2018-10-02 16:12:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (732, '1', '2018-10-02 16:12:20', '2018-10-02 16:12:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (733, '1', '2018-10-02 16:14:45', '2018-10-02 16:15:11', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (734, '1', '2018-10-02 16:22:09', '2018-10-02 16:22:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (735, '1', '2018-10-02 16:41:10', '2018-10-02 16:41:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (736, '1', '2018-10-05 11:32:54', '2018-10-05 11:33:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (737, '1', '2018-10-05 11:42:06', '2018-10-05 11:42:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (738, '1', '2018-10-05 11:46:36', '2018-10-05 11:46:52', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (739, '1', '2018-10-05 11:51:40', '2018-10-05 11:51:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (740, '1', '2018-10-05 16:14:03', '2018-10-05 16:14:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (741, '1', '2018-10-05 16:42:45', '2018-10-05 16:44:59', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (742, '1', '2018-10-05 16:46:08', '2018-10-05 16:47:55', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (743, '1', '2018-10-05 16:49:56', '2018-10-05 16:51:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (744, '1', '2018-10-05 16:52:05', '2018-10-05 16:53:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (745, '1', '2018-10-05 16:57:19', '2018-10-05 16:59:05', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (746, '1', '2018-10-05 17:03:29', '2018-10-05 17:03:48', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (747, '1', '2018-10-08 15:24:07', '2018-10-08 15:24:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (748, '1', '2018-10-08 15:25:39', '2018-10-08 15:25:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (749, '6', '2018-10-08 15:43:58', '2018-10-08 15:44:01', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (750, '1', '2018-10-08 15:44:12', '2018-10-08 15:44:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (751, '1', '2018-10-08 15:45:36', '2018-10-08 15:45:36', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (752, '1', '2018-10-08 15:50:27', '2018-10-08 15:50:29', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (753, '1', '2018-10-09 14:30:28', '2018-10-09 14:30:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (754, '1', '2018-10-09 14:50:01', '2018-10-09 14:50:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (755, '6', '2018-10-09 14:55:30', '2018-10-09 14:56:10', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (756, '6', '2018-10-09 14:57:30', '2018-10-09 14:57:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (757, '6', '2018-10-09 14:58:01', '2018-10-09 14:58:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (758, '6', '2018-10-09 15:00:40', '2018-10-09 15:00:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (759, '5', '2018-10-09 15:13:07', '2018-10-09 15:13:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (760, '6', '2018-10-10 09:13:11', '2018-10-10 09:24:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (761, '6', '2018-10-10 09:25:07', '2018-10-10 09:27:01', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (762, '6', '2018-10-10 09:33:38', '2018-10-10 09:33:59', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (763, '6', '2018-10-10 09:34:12', '2018-10-10 09:34:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (764, '6', '2018-10-10 09:34:18', '2018-10-10 09:34:18', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (765, '5', '2018-10-10 09:34:25', '2018-10-10 09:34:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (766, '6', '2018-10-10 09:37:32', '2018-10-10 09:37:49', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (767, '6', '2018-10-10 10:16:09', '2018-10-10 10:16:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (768, '5', '2018-10-10 10:16:24', '2018-10-10 10:16:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (769, '6', '2018-10-10 10:23:40', '2018-10-10 10:23:47', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (770, '6', '2018-10-10 10:26:36', '2018-10-10 10:26:39', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (771, '5', '2018-10-10 10:26:48', '2018-10-10 10:26:55', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (772, '6', '2018-10-10 10:29:54', '2018-10-10 10:29:57', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (773, '5', '2018-10-10 10:30:08', '2018-10-10 10:30:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (774, '6', '2018-10-10 10:40:23', '2018-10-10 10:40:31', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (775, '6', '2018-10-10 10:40:37', '2018-10-10 10:40:43', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (776, '6', '2018-10-10 10:40:58', '2018-10-10 10:41:04', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (777, '6', '2018-10-10 10:41:07', '2018-10-10 10:41:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (778, '6', '2018-10-10 10:41:23', '2018-10-10 10:41:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (779, '6', '2018-10-10 10:41:33', '2018-10-10 10:41:34', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (780, '5', '2018-10-10 10:41:42', '2018-10-10 10:41:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (781, '6', '2018-10-10 10:41:50', '2018-10-10 10:41:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (782, '6', '2018-10-10 10:42:11', '2018-10-10 10:42:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (783, '5', '2018-10-10 10:42:25', '2018-10-10 10:42:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (784, '5', '2018-10-10 10:42:35', '2018-10-10 10:44:10', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (785, '6', '2018-10-10 10:44:19', '2018-10-10 10:44:22', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (786, '6', '2018-10-10 10:44:47', '2018-10-10 10:45:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (787, '6', '2018-10-10 10:54:35', '2018-10-10 10:54:43', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (788, '6', '2018-10-10 10:54:54', '2018-10-10 10:54:57', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (789, '6', '2018-10-10 10:55:03', '2018-10-10 10:55:05', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (790, '6', '2018-10-10 10:55:11', '2018-10-10 10:55:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (791, '6', '2018-10-10 10:56:50', '2018-10-10 10:56:52', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (792, '1', '2018-10-10 15:00:16', '2018-10-10 15:00:59', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (793, '1', '2018-11-06 13:56:00', '2018-11-06 13:57:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (794, '1', '2018-11-06 13:57:58', '2018-11-06 13:58:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (795, '1', '2018-11-13 09:08:27', '2018-11-13 09:09:54', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (796, '1', '2018-11-14 13:49:30', '2018-11-14 13:51:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (797, '1', '2018-11-14 14:06:55', '2018-11-14 14:09:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (798, '1', '2018-11-14 14:09:12', '2018-11-14 14:09:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (799, '1', '2018-11-14 14:10:32', '2018-11-14 14:11:04', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (800, '1', '2018-11-14 15:03:35', '2018-11-14 15:05:21', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (801, '1', '2018-11-14 16:19:26', '2018-11-14 16:20:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (802, '1', '2018-11-15 10:22:56', '2018-11-15 10:25:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (803, '1', '2018-11-16 08:55:38', '2018-11-16 08:56:01', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (804, '1', '2018-11-16 08:57:08', '2018-11-16 08:58:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (805, '1', '2018-11-16 13:55:00', '2018-11-16 13:55:06', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (806, '1', '2018-11-16 13:55:46', '2018-11-16 13:56:15', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (807, '1', '2018-11-19 14:56:06', '2018-11-19 14:56:41', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (808, '', '2001-01-01 00:00:00', '2018-11-20 14:56:21', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (809, '', '2001-01-01 00:00:00', '2018-11-27 10:37:57', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (810, '', '2001-01-01 00:00:00', '2018-11-27 13:26:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (811, '', '2001-01-01 00:00:00', '2018-11-27 14:00:32', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (812, '', '2001-01-01 00:00:00', '2018-11-27 14:12:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (813, '', '2001-01-01 00:00:00', '2018-11-27 14:14:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (814, '', '2001-01-01 00:00:00', '2018-11-27 14:23:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (815, '', '2001-01-01 00:00:00', '2018-11-27 15:57:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (816, '2', '2018-11-27 15:59:20', '2018-11-27 15:59:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (817, '2', '2018-11-27 15:59:56', '2018-11-27 15:59:59', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (818, '2', '2018-11-27 16:00:06', '2018-11-27 16:00:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (819, '', '2001-01-01 00:00:00', '2018-11-29 13:47:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (820, '2', '2018-11-29 15:18:01', '2018-11-29 15:31:45', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (821, '', '2001-01-01 00:00:00', '2018-12-02 22:52:24', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (822, '', '2001-01-01 00:00:00', '2018-12-02 22:53:30', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (823, '', '2001-01-01 00:00:00', '2018-12-03 11:42:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (824, '2', '2018-12-04 11:29:33', '2018-12-04 11:34:11', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (825, '2', '2018-12-04 11:53:56', '2018-12-04 11:54:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (826, '', '2001-01-01 00:00:00', '2018-12-04 13:53:37', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (827, '2', '2018-12-04 16:52:33', '2018-12-04 16:53:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (828, '2', '2018-12-05 14:07:33', '2018-12-05 14:08:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (829, '', '2001-01-01 00:00:00', '2018-12-05 15:47:30', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (830, '2', '2018-12-05 22:08:38', '2018-12-05 22:09:06', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (831, '2', '2018-12-05 22:09:41', '2018-12-05 22:10:20', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (832, '2', '2018-12-05 22:13:29', '2018-12-05 22:14:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (833, '2', '2018-12-06 09:03:29', '2018-12-06 09:04:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (834, '6', '2018-12-06 09:32:27', '2018-12-06 09:32:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (835, '2', '2018-12-06 09:33:20', '2018-12-06 09:33:37', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (836, '2', '2018-12-06 09:41:58', '2018-12-06 09:42:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (837, '', '2001-01-01 00:00:00', '2018-12-06 10:29:49', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (838, '', '2001-01-01 00:00:00', '2018-12-07 10:35:59', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (839, '2', '2018-12-07 14:20:45', '2018-12-07 14:21:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (840, '6', '2018-12-07 14:32:00', '2018-12-07 14:32:18', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (841, '6', '2018-12-10 11:10:39', '2018-12-10 11:10:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (842, '6', '2018-12-10 11:51:15', '2018-12-10 11:51:36', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (843, '1', '2018-12-10 16:47:33', '2018-12-10 16:54:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (844, '1', '2018-12-10 16:54:20', '2018-12-10 16:55:00', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (845, '1', '2018-12-11 10:51:06', '2018-12-11 10:54:43', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (846, '6', '2018-12-14 11:25:02', '2018-12-14 11:25:16', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (847, '6', '2018-12-14 15:37:34', '2018-12-14 15:40:51', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (848, '', '2001-01-01 00:00:00', '2018-12-14 16:33:38', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (849, '', '2001-01-01 00:00:00', '2018-12-14 16:34:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (850, '', '2001-01-01 00:00:00', '2018-12-14 16:35:10', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (851, '6', '2018-12-14 16:37:23', '2018-12-14 16:37:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (852, '6', '2018-12-14 16:43:34', '2018-12-14 16:43:55', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (853, '', '2001-01-01 00:00:00', '2018-12-14 16:52:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (1, '11', '2018-01-03 16:03:19', '2018-03-03 13:04:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (2, '2', '2018-03-04 16:07:32', '2018-03-05 19:27:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (3, '2', '2018-02-28 16:09:28', '2018-02-28 16:49:31', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (4, '11', '2018-02-28 17:00:12', '2018-02-28 17:00:20', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (5, '11', '2018-02-28 22:09:54', '2018-02-28 22:18:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (33, '1', '2018-03-01 20:37:02', '2018-03-01 20:39:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (34, '1', '2018-03-01 20:39:48', '2018-03-01 20:40:00', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (35, '1', '2018-03-01 20:40:28', '2018-03-01 20:40:46', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (36, '1', '2018-03-01 20:40:28', '2018-03-01 20:40:46', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (37, '1', '2018-03-01 20:40:53', '2018-03-01 20:41:19', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (38, '1', '2018-03-01 21:25:53', '2018-03-01 21:26:06', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (39, '1', '2018-03-01 21:26:58', '2018-03-01 21:27:32', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (40, '1', '2018-03-01 21:29:28', '2018-03-01 21:29:40', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (41, '1', '2018-03-01 21:30:17', '2018-03-01 21:31:25', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (42, '1', '2018-03-01 21:33:00', '2018-03-01 21:33:08', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (43, '1', '2018-03-01 22:15:58', '2018-03-01 22:16:32', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (44, '1', '2018-03-01 22:19:47', '2018-03-01 22:20:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (45, '1', '2018-03-02 08:31:53', '2018-03-02 08:32:50', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (46, '1', '2018-03-02 08:37:10', '2018-03-02 08:37:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (47, '2', '2018-03-02 08:37:18', '2018-03-02 08:38:37', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (48, '1', '2018-03-02 08:41:58', '2018-03-02 08:42:10', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (49, '1', '2018-03-02 08:42:39', '2018-03-02 08:43:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (50, '1', '2018-03-02 08:44:36', '2018-03-02 08:52:11', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (51, '1', '2018-03-02 09:17:47', '2018-03-02 09:18:00', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (52, '2', '2018-03-02 09:21:26', '2018-03-02 09:21:54', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (53, '1', '2018-03-02 09:43:34', '2018-03-02 09:44:47', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (54, '1', '2018-03-02 09:46:20', '2018-03-02 09:46:52', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (55, '1', '2018-03-02 09:51:10', '2018-03-02 09:51:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (56, '1', '2018-03-02 09:58:44', '2018-03-02 09:59:04', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (57, '1', '2018-03-02 15:43:17', '2018-03-02 15:43:30', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (58, '1', '2018-03-02 15:48:07', '2018-03-02 15:49:27', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (59, '1', '2018-03-02 16:00:39', '2018-03-02 16:01:56', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (60, '1', '2018-03-02 16:24:25', '2018-03-02 16:24:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (61, '1', '2018-03-02 16:52:13', '2018-03-02 16:52:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (62, '1', '2018-03-02 16:59:42', '2018-03-02 17:00:19', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (63, '1', '2018-03-02 17:05:07', '2018-03-02 17:05:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (64, '1', '2018-03-03 19:17:45', '2018-03-03 19:21:03', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (65, '1', '2018-03-03 19:22:18', '2018-03-03 19:36:16', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (66, '1', '2018-03-04 20:02:13', '2018-03-04 20:02:39', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (67, '1', '2018-03-04 20:02:49', '2018-03-04 20:03:46', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (68, '1', '2018-03-04 20:05:18', '2018-03-04 20:08:14', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (69, '1', '2018-03-04 20:08:49', '2018-03-04 20:09:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (70, '1', '2018-03-04 20:59:20', '2018-03-04 20:59:56', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (71, '1', '2018-03-04 21:14:36', '2018-03-04 21:15:28', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (72, '1', '2018-03-04 21:19:33', '2018-03-04 21:19:48', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (73, '1', '2018-03-04 21:20:48', '2018-03-04 21:21:56', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (74, '1', '2018-03-04 21:22:20', '2018-03-04 21:22:45', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (75, '1', '2018-03-04 21:23:36', '2018-03-04 21:23:54', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (76, '1', '2018-03-04 21:27:56', '2018-03-04 21:28:35', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (77, '1', '2018-03-04 21:31:28', '2018-03-04 21:32:04', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (78, '1', '2018-03-04 21:36:19', '2018-03-04 21:37:27', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (79, '1', '2018-03-04 21:41:05', '2018-03-04 21:45:02', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (80, '1', '2018-03-06 13:13:40', '2018-03-06 13:14:18', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (81, '1', '2018-03-06 13:15:55', '2018-03-06 13:16:15', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (82, '1', '2018-03-06 13:19:53', '2018-03-06 13:20:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (83, '1', '2018-03-06 13:26:31', '2018-03-06 13:27:00', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (84, '1', '2018-03-06 13:30:49', '2018-03-06 13:31:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (85, '1', '2018-03-06 13:31:52', '2018-03-06 13:32:10', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (86, '1', '2018-03-06 13:33:48', '2018-03-06 13:34:06', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (87, '1', '2018-03-06 13:38:25', '2018-03-06 13:38:58', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (88, '1', '2018-03-06 13:40:53', '2018-03-06 13:41:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (89, '1', '2018-03-06 13:41:50', '2018-03-06 13:42:19', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (90, '1', '2018-03-06 14:04:58', '2018-03-06 14:05:37', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (91, '1', '2018-03-06 14:31:36', '2018-03-06 14:32:27', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (92, '1', '2018-03-06 15:35:19', '2018-03-06 15:35:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (93, '1', '2018-03-06 15:48:33', '2018-03-06 15:49:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (94, '1', '2018-03-06 15:54:39', '2018-03-06 15:55:41', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (95, '1', '2018-03-06 15:57:59', '2018-03-06 15:58:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (96, '1', '2018-03-06 16:00:40', '2018-03-06 16:01:01', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (97, '1', '2018-03-06 16:05:27', '2018-03-06 16:06:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (98, '1', '2018-03-06 16:10:04', '2018-03-06 16:11:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (99, '1', '2018-03-06 16:18:15', '2018-03-06 16:19:31', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (100, '1', '2018-03-06 16:20:01', '2018-03-06 16:20:46', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (101, '1', '2018-03-06 16:26:11', '2018-03-06 16:26:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (102, '1', '2018-03-06 16:35:55', '2018-03-06 16:37:37', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (103, '1', '2018-03-06 16:38:54', '2018-03-06 16:39:31', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (104, '1', '2018-03-06 16:49:22', '2018-03-06 16:50:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (105, '1', '2018-03-07 10:53:36', '2018-03-07 10:53:50', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (106, '1', '2018-03-07 10:54:52', '2018-03-07 11:01:45', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (107, '1', '2018-03-07 11:05:02', '2018-03-07 11:05:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (108, '1', '2018-03-07 11:22:03', '2018-03-07 11:22:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (109, '1', '2018-03-07 11:57:06', '2018-03-07 11:57:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (193, '1', '2018-03-16 10:26:24', '2018-03-16 10:28:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (194, '1', '2018-03-16 10:45:37', '2018-03-16 10:46:01', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (195, '1', '2018-03-16 11:36:32', '2018-03-16 11:36:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (196, '1', '2018-03-16 11:46:07', '2018-03-16 11:46:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (197, '1', '2018-03-16 11:46:34', '2018-03-16 11:46:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (198, '1', '2018-03-16 11:46:52', '2018-03-16 11:47:06', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (199, '1', '2018-03-16 13:16:11', '2018-03-16 13:16:21', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (200, '1', '2018-03-16 13:25:06', '2018-03-16 13:25:16', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (201, '1', '2018-03-16 13:55:32', '2018-03-16 13:58:48', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (202, '1', '2018-03-16 14:54:31', '2018-03-16 14:54:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (203, '1', '2018-03-16 14:57:56', '2018-03-16 14:58:21', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (204, '1', '2018-03-16 14:58:49', '2018-03-16 14:59:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (205, '1', '2018-03-16 15:01:49', '2018-03-16 15:01:51', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (206, '1', '2018-03-16 15:05:51', '2018-03-16 15:05:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (207, '1', '2018-03-16 16:27:36', '2018-03-16 16:27:39', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (208, '1', '2018-03-17 07:53:04', '2018-03-17 07:59:37', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (209, '1', '2018-03-17 08:04:58', '2018-03-17 08:06:02', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (210, '1', '2018-03-17 08:24:51', '2018-03-17 08:42:30', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (211, '1', '2018-03-17 08:44:49', '2018-03-17 08:45:57', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (212, '1', '2018-03-17 08:46:18', '2018-03-17 08:47:25', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (213, '1', '2018-03-17 08:49:56', '2018-03-17 08:50:32', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (214, '1', '2018-03-17 08:53:37', '2018-03-17 08:54:30', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (215, '1', '2018-03-17 08:55:23', '2018-03-17 08:56:24', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (216, '1', '2018-03-17 08:56:33', '2018-03-17 08:56:44', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (217, '1', '2018-03-17 08:58:00', '2018-03-17 09:07:04', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (218, '1', '2018-03-17 10:20:55', '2018-03-17 10:21:08', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (219, '1', '2018-03-17 10:21:31', '2018-03-17 10:22:06', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (220, '1', '2018-03-17 10:22:39', '2018-03-17 10:22:51', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (221, '1', '2018-03-17 10:24:29', '2018-03-17 10:27:35', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (222, '1', '2018-03-17 10:28:37', '2018-03-17 10:30:37', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (223, '1', '2018-03-17 10:37:07', '2018-03-17 10:37:19', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (224, '1', '2018-03-17 10:37:33', '2018-03-17 10:37:52', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (225, '1', '2018-03-17 11:15:13', '2018-03-17 11:17:00', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (226, '1', '2018-03-17 11:23:36', '2018-03-17 11:25:29', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (227, '1', '2018-03-17 11:27:19', '2018-03-17 11:28:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (228, '1', '2018-03-17 11:31:09', '2018-03-17 11:33:51', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (229, '1', '2018-03-17 11:34:48', '2018-03-17 11:35:33', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (230, '1', '2018-03-17 11:36:13', '2018-03-17 11:36:41', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (231, '1', '2018-03-17 12:21:03', '2018-03-17 12:24:29', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (232, '1', '2018-03-17 12:32:22', '2018-03-17 12:34:22', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (233, '1', '2018-03-19 09:49:06', '2018-03-19 09:49:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (234, '1', '2018-03-19 15:41:16', '2018-03-19 15:41:35', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (235, '1', '2018-03-19 16:03:03', '2018-03-19 16:03:20', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (236, '1', '2018-03-20 13:24:47', '2018-03-20 13:25:01', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (237, '1', '2018-03-22 14:31:55', '2018-03-22 14:32:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (238, '1', '2018-03-22 14:32:29', '2018-03-22 14:32:54', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (239, '1', '2018-03-22 14:59:34', '2018-03-22 14:59:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (240, '1', '2018-03-22 15:00:51', '2018-03-22 15:01:01', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (241, '1', '2018-03-22 15:01:56', '2018-03-22 15:02:01', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (242, '1', '2018-03-22 16:07:37', '2018-03-22 16:07:48', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (243, '1', '2018-03-22 16:10:01', '2018-03-22 16:10:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (244, '1', '2018-03-22 16:10:24', '2018-03-22 16:10:28', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (245, '1', '2018-03-22 16:12:25', '2018-03-22 16:12:37', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (246, '1', '2018-03-22 16:20:47', '2018-03-22 16:20:51', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (247, '1', '2018-03-22 16:21:54', '2018-03-22 16:21:58', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (248, '1', '2018-03-22 16:22:09', '2018-03-22 16:22:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (249, '1', '2018-03-22 16:26:53', '2018-03-22 16:27:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (250, '1', '2018-03-22 16:44:06', '2018-03-22 16:44:16', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (251, '1', '2018-03-22 16:45:29', '2018-03-22 16:45:36', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (252, '1', '2018-03-22 16:52:56', '2018-03-22 16:53:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (253, '1', '2018-03-22 16:54:10', '2018-03-22 16:54:17', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (254, '1', '2018-03-22 17:58:04', '2018-03-22 17:58:56', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (255, '1', '2018-03-22 18:11:54', '2018-03-22 18:12:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (256, '1', '2018-03-23 08:43:03', '2018-03-23 08:43:14', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (257, '1', '2018-03-23 09:32:33', '2018-03-23 09:32:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (258, '1', '2018-03-23 09:35:13', '2018-03-23 09:35:24', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (259, '1', '2018-03-23 09:36:38', '2018-03-23 09:36:42', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (260, '1', '2018-03-23 09:37:52', '2018-03-23 09:38:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (261, '1', '2018-03-23 09:38:27', '2018-03-23 09:38:36', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (262, '1', '2018-03-23 09:38:53', '2018-03-23 09:39:03', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (263, '1', '2018-03-23 09:40:59', '2018-03-23 09:41:13', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (264, '1', '2018-03-23 09:48:42', '2018-03-23 09:49:07', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (265, '1', '2018-03-23 09:49:35', '2018-03-23 09:49:41', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (266, '1', '2018-03-23 09:54:52', '2018-03-23 09:55:10', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (267, '1', '2018-03-23 10:34:04', '2018-03-23 10:34:11', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (268, '1', '2018-03-23 10:36:08', '2018-03-23 10:36:18', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (269, '1', '2018-03-23 10:38:13', '2018-03-23 10:38:20', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (270, '1', '2018-03-23 10:49:04', '2018-03-23 10:49:23', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (271, '1', '2018-03-23 10:49:57', '2018-03-23 10:50:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (272, '1', '2018-03-23 10:51:22', '2018-03-23 10:51:35', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (273, '1', '2018-03-23 10:55:10', '2018-03-23 10:55:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (274, '1', '2018-03-23 11:21:10', '2018-03-23 11:21:44', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (110, '1', '2018-03-07 12:03:35', '2018-03-07 12:03:39', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (111, '1', '2018-03-07 12:04:19', '2018-03-07 12:04:27', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (112, '1', '2018-03-07 13:17:32', '2018-03-07 13:18:07', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (113, '1', '2018-03-07 13:24:20', '2018-03-07 13:26:33', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (114, '1', '2018-03-07 22:19:19', '2018-03-07 22:19:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (115, '1', '2018-03-07 22:35:00', '2018-03-07 22:36:06', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (116, '1', '2018-03-07 22:39:57', '2018-03-07 22:45:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (117, '1', '2018-03-08 13:37:39', '2018-03-08 13:42:26', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (118, '1', '2018-03-08 13:42:56', '2018-03-08 13:43:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (119, '1', '2018-03-08 13:43:18', '2018-03-08 13:43:52', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (120, '1', '2018-03-08 14:01:05', '2018-03-08 14:01:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (121, '1', '2018-03-08 17:23:55', '2018-03-08 17:24:21', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (122, '1', '2018-03-09 16:50:43', '2018-03-09 16:51:01', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (123, '1', '2018-03-09 16:51:40', '2018-03-09 16:51:51', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (124, '1', '2018-03-09 16:56:46', '2018-03-09 16:56:55', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (125, '1', '2018-03-09 17:07:04', '2018-03-09 17:07:20', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (126, '1', '2018-03-09 18:26:25', '2018-03-09 18:26:40', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (127, '1', '2018-03-10 12:25:14', '2018-03-10 12:25:28', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (128, '1', '2018-03-10 13:01:53', '2018-03-10 13:02:28', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (129, '1', '2018-03-10 13:43:59', '2018-03-10 13:44:36', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (130, '1', '2018-03-10 14:06:19', '2018-03-10 15:05:29', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (131, '1', '2018-03-10 16:09:51', '2018-03-10 16:12:48', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (132, '1', '2018-03-10 16:26:03', '2018-03-10 16:26:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (133, '1', '2018-03-10 16:45:49', '2018-03-10 16:46:11', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (134, '1', '2018-03-10 16:47:21', '2018-03-10 16:47:35', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (135, '1', '2018-03-10 16:48:09', '2018-03-10 16:49:58', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (136, '1', '2018-03-11 12:31:00', '2018-03-11 12:31:18', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (137, '1', '2018-03-11 12:32:08', '2018-03-11 12:32:22', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (138, '1', '2018-03-11 12:41:55', '2018-03-11 12:45:18', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (139, '1', '2018-03-11 12:47:43', '2018-03-11 12:47:56', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (140, '1', '2018-03-11 12:52:54', '2018-03-11 12:53:11', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (141, '1', '2018-03-11 13:32:45', '2018-03-11 13:50:43', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (142, '1', '2018-03-11 14:42:35', '2018-03-11 14:43:03', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (143, '1', '2018-03-11 14:43:42', '2018-03-11 14:44:14', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (144, '1', '2018-03-11 14:45:51', '2018-03-11 14:46:03', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (145, '1', '2018-03-11 14:46:44', '2018-03-11 14:48:12', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (146, '1', '2018-03-11 14:49:02', '2018-03-11 14:51:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (147, '1', '2018-03-11 14:54:35', '2018-03-11 14:54:59', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (148, '1', '2018-03-11 14:56:30', '2018-03-11 14:57:58', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (149, '1', '2018-03-11 15:18:36', '2018-03-11 15:19:33', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (150, '1', '2018-03-11 15:27:03', '2018-03-11 15:29:40', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (151, '1', '2018-03-11 15:37:24', '2018-03-11 15:37:51', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (152, '1', '2018-03-11 15:43:15', '2018-03-11 15:44:35', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (153, '1', '2018-03-11 15:46:18', '2018-03-11 15:47:31', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (154, '1', '2018-03-11 15:49:14', '2018-03-11 15:49:37', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (155, '1', '2018-03-11 15:53:44', '2018-03-11 15:55:30', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (156, '1', '2018-03-11 16:03:55', '2018-03-11 16:04:10', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (157, '1', '2018-03-11 16:08:33', '2018-03-11 16:09:00', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (158, '1', '2018-03-11 16:12:48', '2018-03-11 16:13:33', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (159, '1', '2018-03-11 16:21:15', '2018-03-11 16:24:09', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (160, '1', '2018-03-11 16:26:52', '2018-03-11 16:31:12', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (161, '1', '2018-03-11 19:11:05', '2018-03-11 19:11:17', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (162, '1', '2018-03-11 19:12:10', '2018-03-11 19:12:32', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (163, '1', '2018-03-11 19:13:02', '2018-03-11 19:16:54', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (164, '1', '2018-03-11 19:38:04', '2018-03-11 19:38:15', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (165, '1', '2018-03-12 10:55:49', '2018-03-12 10:56:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (166, '1', '2018-03-12 11:11:54', '2018-03-12 11:12:05', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (167, '1', '2018-03-12 11:12:55', '2018-03-12 11:13:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (168, '1', '2018-03-12 11:18:49', '2018-03-12 11:18:54', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (169, '1', '2018-03-12 11:41:20', '2018-03-12 11:42:22', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (170, '1', '2018-03-12 12:02:53', '2018-03-12 12:03:12', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (171, '1', '2018-03-12 13:20:02', '2018-03-12 13:20:29', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (172, '1', '2018-03-12 13:23:19', '2018-03-12 13:23:25', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (173, '1', '2018-03-12 13:31:24', '2018-03-12 13:32:04', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (174, '1', '2018-03-12 13:32:39', '2018-03-12 13:33:02', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (175, '1', '2018-03-12 13:35:50', '2018-03-12 13:37:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (176, '1', '2018-03-12 13:37:55', '2018-03-12 13:41:08', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (177, '1', '2018-03-12 15:17:19', '2018-03-12 15:17:47', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (178, '1', '2018-03-12 15:19:17', '2018-03-12 15:19:52', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (179, '1', '2018-03-14 08:08:32', '2018-03-14 08:08:34', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (180, '1', '2018-03-14 09:24:04', '2018-03-14 09:24:11', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (181, '1', '2018-03-14 20:24:25', '2018-03-14 20:25:53', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (182, '1', '2018-03-14 20:50:00', '2018-03-14 20:52:14', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (183, '1', '2018-03-14 21:03:39', '2018-03-14 21:04:02', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (184, '1', '2018-03-14 21:10:18', '2018-03-14 21:14:28', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (185, '1', '2018-03-14 21:18:27', '2018-03-14 21:19:47', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (186, '1', '2018-03-14 21:25:25', '2018-03-14 21:36:26', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (187, '1', '2018-03-14 21:56:30', '2018-03-14 21:58:50', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (188, '1', '2018-03-14 21:59:08', '2018-03-14 21:59:19', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (189, '1', '2018-03-14 22:34:24', '2018-03-14 22:34:38', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (190, '1', '2018-03-14 22:36:04', '2018-03-14 22:36:13', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (191, '1', '2018-03-14 22:36:51', '2018-03-14 22:37:04', 'TRUONGGIANG');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (192, '1', '2018-03-15 16:23:03', '2018-03-15 16:23:11', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (854, '6', '2018-12-14 16:52:32', '2018-12-14 16:54:52', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (855, '', '2001-01-01 00:00:00', '2018-12-14 16:59:47', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (856, '', '2001-01-01 00:00:00', '2018-12-14 17:00:04', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (857, '2', '2018-12-18 09:23:21', '2018-12-18 09:24:39', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (858, '6', '2018-12-18 09:36:39', '2018-12-18 09:36:53', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (859, '2', '2018-12-18 09:37:01', '2018-12-18 09:37:16', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (860, '', '2001-01-01 00:00:00', '2018-12-18 09:39:09', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (861, '2', '2018-12-18 09:39:51', '2018-12-18 09:40:07', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (862, '6', '2018-12-18 09:40:17', '2018-12-18 09:40:45', 'WIN10-GIANGNT');
INSERT INTO `WorkAssign` (`Identify`, `UserID`, `TimeStart`, `TimeEnd`, `Computer`) VALUES (863, '', '2001-01-01 00:00:00', '2018-12-18 10:35:02', 'WIN10-GIANGNT');
# 836 records

