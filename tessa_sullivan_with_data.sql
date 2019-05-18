-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 18, 2019 at 05:59 PM
-- Server version: 5.7.25
-- PHP Version: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tessa_sullivan`
--
DROP DATABASE IF EXISTS tessa_sullivan;
CREATE DATABASE IF NOT EXISTS `tessa_sullivan` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `tessa_sullivan`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `phone_number` varchar(255) NOT NULL,
  `notes` varchar(500) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `first_name`, `last_name`, `phone_number`, `notes`, `stylist_id`) VALUES
(9, 'Judith', 'Monroe', '206-867-5309', 'Double-process, use brand X for color, mix 75% Sapphire and 25% Amethyst', 5),
(10, 'Hannah', 'Chance', '206-555-4930', '', 5),
(11, 'Fiona', 'Hardingham', '425-355-9009', 'Notes', 5),
(12, 'Katherine', 'Kellgren', '832-899-3421', 'Notes', 5),
(14, 'Susan', 'Duerden', '206-619-9391', 'Prefers Brand Happy Color Canary Yellow', 10),
(15, 'Kate', 'Reading', '253-435-9040', '', 10),
(16, 'John', 'Lennon', '425-366-4039', '', 11),
(17, 'Paul', 'McCartney', '425-660-5043', '', 11),
(18, 'George', 'Harrison', '425-660-5044', '', 11),
(19, 'Ringo', 'Starr', '425-679-2424', '', 11),
(20, 'Ned', 'Henry', '425-870-4367', '', 12),
(21, 'Verity', 'Kindle', '832-395-3940', '', 12),
(22, 'Sandra', 'Foster', '919-619-9391', '', 12),
(23, 'Bennett', 'O\'Reilly', '206-786-4429', '', 12);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `specialty`) VALUES
(1, 'Highlights / Lowlights'),
(2, 'Hair cuts'),
(3, 'Straightening'),
(4, 'Corrective Color');

-- --------------------------------------------------------

--
-- Table structure for table `specialties_stylists`
--

CREATE TABLE `specialties_stylists` (
  `id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties_stylists`
--

INSERT INTO `specialties_stylists` (`id`, `specialty_id`, `stylist_id`) VALUES
(1, 1, 5),
(2, 1, 10),
(3, 3, 11),
(4, 3, 12),
(5, 4, 11),
(6, 4, 12);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `phone_number` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `first_name`, `last_name`, `phone_number`) VALUES
(5, 'Gregory', 'Johnston', '206-867-5310'),
(10, 'Katie', 'Dior', '832-455-9803'),
(11, 'Lucy', 'Diamond', '206-242-3356'),
(12, 'Connie', 'Willis', '206-544-3042');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
