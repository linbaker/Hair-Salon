-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 20, 2019 at 03:54 AM
-- Server version: 5.7.26
-- PHP Version: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `lindsey_baker_test`
--
CREATE DATABASE IF NOT EXISTS `lindsey_baker_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `lindsey_baker_test`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `client_since` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `stylist_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=272 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

DROP TABLE IF EXISTS `specialties`;
CREATE TABLE IF NOT EXISTS `specialties` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=138 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `type`) VALUES
(135, 'Stuff'),
(136, 'Cutting'),
(137, 'Shaving');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

DROP TABLE IF EXISTS `stylists`;
CREATE TABLE IF NOT EXISTS `stylists` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=216 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `stylists_specialties`
--

DROP TABLE IF EXISTS `stylists_specialties`;
CREATE TABLE IF NOT EXISTS `stylists_specialties` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=49 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists_specialties`
--

INSERT INTO `stylists_specialties` (`id`, `specialty_id`, `stylist_id`) VALUES
(1, 50, 5),
(2, 10, 58),
(3, 15, 65),
(4, 16, 67),
(5, 27, 83),
(6, 28, 85),
(7, 33, 92),
(8, 34, 94),
(9, 39, 101),
(10, 40, 103),
(11, 45, 110),
(12, 46, 112),
(13, 52, 119),
(14, 53, 121),
(16, 60, 129),
(17, 61, 131),
(19, 71, 141),
(20, 72, 143),
(22, 75, 151),
(23, 76, 152),
(24, 82, 153),
(25, 83, 155),
(27, 87, 163),
(28, 88, 164),
(29, 94, 165),
(30, 95, 167),
(32, 99, 175),
(33, 100, 176),
(34, 106, 177),
(35, 107, 179),
(37, 111, 187),
(38, 112, 188),
(39, 118, 190),
(40, 119, 192),
(42, 123, 200),
(43, 124, 201),
(44, 130, 203),
(45, 131, 205),
(47, 135, 213),
(48, 136, 214);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
