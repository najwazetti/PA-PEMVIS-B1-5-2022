-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 17, 2024 at 03:58 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `parfume`
--

-- --------------------------------------------------------

--
-- Table structure for table `databrandpfm`
--

CREATE TABLE `databrandpfm` (
  `ID_Brandpfm` int(10) NOT NULL,
  `Brand_parfume` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `databrandpfm`
--

INSERT INTO `databrandpfm` (`ID_Brandpfm`, `Brand_parfume`) VALUES
(1, 'Chanel'),
(2, 'Dior'),
(3, 'Gucci'),
(4, 'Byredo'),
(5, 'Calvin Klein'),
(6, 'Versace'),
(7, 'Tom Ford'),
(8, 'Yves Saint Laurent');

-- --------------------------------------------------------

--
-- Table structure for table `datajenispfm`
--

CREATE TABLE `datajenispfm` (
  `ID_Jenispfm` int(10) NOT NULL,
  `Jenis_parfume` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `datajenispfm`
--

INSERT INTO `datajenispfm` (`ID_Jenispfm`, `Jenis_parfume`) VALUES
(1, 'Parfum'),
(2, 'Eau de Toilette (EDT)'),
(3, 'Eau de Cologne (EDC)'),
(4, 'Eau de Parfum (EDP)'),
(5, 'Body Mist'),
(6, 'Unisex parfume');

-- --------------------------------------------------------

--
-- Table structure for table `dataparfume`
--

CREATE TABLE `dataparfume` (
  `ID_Parfume` int(4) NOT NULL,
  `Jenis_Parfume` text NOT NULL,
  `Brand_Parfume` text NOT NULL,
  `Nama_Parfume` varchar(100) NOT NULL,
  `Harga_Parfume` int(100) NOT NULL,
  `Stok_Parfume` int(100) NOT NULL,
  `Ukuran_Parfume` varchar(255) NOT NULL,
  `Tanggal_Penambahan` text NOT NULL,
  `Kategori_Parfume` varchar(255) NOT NULL,
  `Alkohol_Parfume` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dataparfume`
--

INSERT INTO `dataparfume` (`ID_Parfume`, `Jenis_Parfume`, `Brand_Parfume`, `Nama_Parfume`, `Harga_Parfume`, `Stok_Parfume`, `Ukuran_Parfume`, `Tanggal_Penambahan`, `Kategori_Parfume`, `Alkohol_Parfume`) VALUES
(1, 'Eau de Toilette (EDT)', 'Gucci', 'Scandalous VS', 2500000, 20, '15 ML', '2024-05-17 00:00:00 ', 'Aquatic or Marine', 'Ada'),
(2, 'Parfum', 'Yves Saint Laurent', 'Blanche', 1249000, 17, '50 ML', '2024-05-17 00:00:00 ', 'Gourmand, Fresh, Woody', 'Ada'),
(3, 'Eau de Cologne (EDC)', 'Tom Ford', 'Lavender Bluez', 280000, 18, '50 ML', '2024-05-17 00:00:00 ', 'Aquatic or Marine, Oriental, Floral', 'Ada'),
(4, 'Parfum', 'Calvin Klein', 'Gypsy Water', 1249000, 3, '75 ML', '2024-05-17 00:00:00 ', 'Aquatic or Marine, Fresh, Oriental, Floral', 'Ada'),
(5, 'Unisex parfume', 'Versace', 'Mojave Ghost', 1650000, 14, '75 ML', '2024-05-17 00:00:00 ', 'Aquatic or Marine, Gourmand, Floral', 'Ada'),
(6, 'Body Mist', 'Gucci', 'Bal D\'Afrique', 1950000, 15, '125 ML', '2024-05-17 00:00:00 ', 'Aquatic or Marine, Oriental, Woody', 'Ada'),
(7, 'Eau de Cologne (EDC)', 'Chanel', 'Chanel Grand Extrait', 1500000, 2, '50 ML', '2024-05-17 00:00:00 ', 'Aromatic or Herbal, Oriental, Woody', 'Ada');

-- --------------------------------------------------------

--
-- Table structure for table `datapesanan`
--

CREATE TABLE `datapesanan` (
  `ID_Pesanan` int(11) NOT NULL,
  `ID_User` int(11) NOT NULL,
  `ID_Parfume` int(11) NOT NULL,
  `Nama_Barang` text NOT NULL,
  `Jumlah_Barang` int(11) NOT NULL,
  `Total_Harga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `datapesanan`
--

INSERT INTO `datapesanan` (`ID_Pesanan`, `ID_User`, `ID_Parfume`, `Nama_Barang`, `Jumlah_Barang`, `Total_Harga`) VALUES
(54, 13, 2, 'Blanche', 2, 2498000);

-- --------------------------------------------------------

--
-- Table structure for table `datauser`
--

CREATE TABLE `datauser` (
  `ID_User` int(11) NOT NULL,
  `Name_User` text NOT NULL,
  `Email_User` text NOT NULL,
  `Username_User` varchar(255) NOT NULL,
  `Password_User` varchar(255) NOT NULL,
  `Address_User` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `datauser`
--

INSERT INTO `datauser` (`ID_User`, `Name_User`, `Email_User`, `Username_User`, `Password_User`, `Address_User`) VALUES
(6, 'desti lucu', 'desti@gmail.com', 'destigemoyy', '222', 'samarinda'),
(7, 'Wildanah Sirad', 'wildacantik@gmail.com', 'wildaaa', '111', 'Bumi Sempaja'),
(12, 'najwa felira zetti', 'najwa@gmail.com', 'najwazetti', '123', 'jalan belatuk 11'),
(13, 'lupi gantenk', '1', '1', '1', 'bumi sempaja');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `databrandpfm`
--
ALTER TABLE `databrandpfm`
  ADD PRIMARY KEY (`ID_Brandpfm`);

--
-- Indexes for table `datajenispfm`
--
ALTER TABLE `datajenispfm`
  ADD PRIMARY KEY (`ID_Jenispfm`);

--
-- Indexes for table `dataparfume`
--
ALTER TABLE `dataparfume`
  ADD PRIMARY KEY (`ID_Parfume`);

--
-- Indexes for table `datapesanan`
--
ALTER TABLE `datapesanan`
  ADD PRIMARY KEY (`ID_Pesanan`),
  ADD KEY `ID_User` (`ID_User`);

--
-- Indexes for table `datauser`
--
ALTER TABLE `datauser`
  ADD PRIMARY KEY (`ID_User`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `databrandpfm`
--
ALTER TABLE `databrandpfm`
  MODIFY `ID_Brandpfm` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `datajenispfm`
--
ALTER TABLE `datajenispfm`
  MODIFY `ID_Jenispfm` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `dataparfume`
--
ALTER TABLE `dataparfume`
  MODIFY `ID_Parfume` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `datapesanan`
--
ALTER TABLE `datapesanan`
  MODIFY `ID_Pesanan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=60;

--
-- AUTO_INCREMENT for table `datauser`
--
ALTER TABLE `datauser`
  MODIFY `ID_User` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
