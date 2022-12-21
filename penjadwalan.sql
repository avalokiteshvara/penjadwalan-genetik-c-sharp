-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 15, 2013 at 11:48 AM
-- Server version: 5.5.27
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `penjadwalan`
--

-- --------------------------------------------------------

--
-- Table structure for table `dosen`
--

CREATE TABLE IF NOT EXISTS `dosen` (
  `kode` int(2) NOT NULL,
  `nidn` varchar(50) DEFAULT NULL,
  `nama` varchar(50) DEFAULT NULL,
  `alamat` varchar(50) DEFAULT NULL,
  `telp` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`kode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='kode TIDAK autoincrement,karena agar bisa ditentukan sendiri';

--
-- Dumping data for table `dosen`
--

INSERT INTO `dosen` (`kode`, `nidn`, `nama`, `alamat`, `telp`) VALUES
(1, '', 'Eko Listiwikono, Drs. MM', '', ''),
(2, '', 'Mohamad Dedi, Drs. M.Pd', '', ''),
(3, '', 'Moch. Najib, Ir. H. MM', '', ''),
(4, '', 'Iman Santoso, SE., MM', '', ''),
(5, '', 'Chairul Anam, S.Kom., H. MM', '', ''),
(6, '', 'Hadiq, M.Kom', '', ''),
(7, '', 'Slamet Siswanto Utomo, ST', '', ''),
(8, '', 'Dwi Yulian RL, M.Kom', '', ''),
(9, '', 'Tintin Harlina, S.Kom', '', ''),
(10, '', 'Rachman Yulianto, S.Kom', '', ''),
(11, '', 'Rudi Hartono, S.Kom', '', ''),
(12, '', 'Djuniharto, S.Kom', '', ''),
(13, '', 'Mohammad Fairus Abadi, S.Pd', '', ''),
(14, '', 'Lukman Arifi Manshur, M.Pdi', '', ''),
(15, '', 'Ferdi Barlianto, ST', '', ''),
(16, '', 'Nur Ahmadi, ST', '', ''),
(17, '', 'Faruk Alfiyan, S.Kom', '', ''),
(18, '', 'Agus Riyono Drs. ', '', ''),
(19, '', 'Yoyon Ari Budi, ST., M.Kom', '', ''),
(20, '', 'Solehatin, S.Kom', '', ''),
(21, '', 'Eko Heri Susanto, M.Kom', '', ''),
(22, '', 'Sulaibatul Aslamia, S.Kom', '', ''),
(23, '', 'Moh Erdda Habibi, S.St', '', ''),
(24, '', 'Abdul Haris, S.Kom', '', ''),
(25, '', 'Ismurdianto Drs. ', '', ''),
(26, '', 'Lukman Hakim Dr. ', '', ''),
(27, '', 'Rio Coundris Kurniawan, ST', '', ''),
(28, '', 'Haykal, S.Pd., MT', '', ''),
(29, '', 'Bambang Priyono Drs. ', '', ''),
(30, '', 'Melanoke Pramanik, S.Kom', '', ''),
(31, '', 'Kanda Mubaraq, S.St', '', ''),
(32, '', 'Aditya Rizky, S.E', '', ''),
(33, '', 'Yudi Heri Yulianto, S.Kom.', '', ''),
(34, '', 'Dwi Arraziqi, S.Kom', '', ''),
(35, '', 'Retno Ires D, S.St', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `hari`
--

CREATE TABLE IF NOT EXISTS `hari` (
  `kode` int(10) NOT NULL,
  `nama` varchar(50) DEFAULT NULL,
  `aktif` enum('True','False') DEFAULT 'True',
  PRIMARY KEY (`kode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='kode TIDAK autoincrement,karena agar bisa ditentukan sendiri';

--
-- Dumping data for table `hari`
--

INSERT INTO `hari` (`kode`, `nama`, `aktif`) VALUES
(1, 'Senin', 'True'),
(2, 'Selasa', 'True'),
(3, 'Rabu', 'True'),
(4, 'Kamis', 'True'),
(5, 'Jumat', 'True');

-- --------------------------------------------------------

--
-- Table structure for table `jadwal_kuliah`
--

CREATE TABLE IF NOT EXISTS `jadwal_kuliah` (
  `kode` int(10) NOT NULL AUTO_INCREMENT,
  `kode_pengampu` int(10) DEFAULT NULL,
  `kode_jam` int(10) DEFAULT NULL,
  `kode_hari` int(10) DEFAULT NULL,
  `kode_ruang` int(10) DEFAULT NULL,
  PRIMARY KEY (`kode`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COMMENT='hasil proses' AUTO_INCREMENT=51 ;

--
-- Dumping data for table `jadwal_kuliah`
--

INSERT INTO `jadwal_kuliah` (`kode`, `kode_pengampu`, `kode_jam`, `kode_hari`, `kode_ruang`) VALUES
(1, 49, 7, 1, 2),
(2, 50, 2, 1, 3),
(3, 51, 3, 2, 5),
(4, 52, 1, 3, 2),
(5, 53, 5, 4, 1),
(6, 54, 4, 2, 2),
(7, 55, 4, 3, 4),
(8, 56, 8, 3, 1),
(9, 57, 4, 3, 5),
(10, 58, 4, 3, 1),
(11, 59, 1, 4, 2),
(12, 60, 7, 2, 1),
(13, 61, 5, 1, 6),
(14, 62, 2, 2, 1),
(15, 63, 3, 4, 3),
(16, 64, 3, 2, 3),
(17, 65, 1, 5, 1),
(18, 66, 7, 2, 4),
(19, 67, 4, 1, 4),
(20, 68, 2, 3, 6),
(21, 69, 8, 4, 4),
(22, 70, 4, 1, 5),
(23, 71, 2, 1, 1),
(24, 72, 9, 4, 6),
(25, 73, 7, 5, 1),
(26, 74, 8, 5, 8),
(27, 75, 8, 3, 7),
(28, 76, 7, 1, 8),
(29, 77, 5, 4, 9),
(30, 78, 3, 3, 8),
(31, 79, 8, 2, 10),
(32, 80, 5, 2, 8),
(33, 81, 7, 1, 7),
(34, 82, 7, 4, 7),
(35, 83, 7, 1, 9),
(36, 84, 5, 3, 10),
(37, 85, 3, 2, 9),
(38, 86, 1, 4, 7),
(39, 87, 1, 5, 7),
(40, 88, 7, 4, 8),
(41, 89, 4, 1, 7),
(42, 90, 2, 3, 10),
(43, 91, 5, 4, 7),
(44, 92, 8, 5, 9),
(45, 93, 3, 1, 10),
(46, 94, 8, 1, 10),
(47, 95, 7, 3, 8),
(48, 96, 9, 2, 8),
(49, 97, 4, 1, 9),
(50, 98, 2, 3, 7);

-- --------------------------------------------------------

--
-- Table structure for table `jam`
--

CREATE TABLE IF NOT EXISTS `jam` (
  `kode` int(10) NOT NULL,
  `range_jam` varchar(50) DEFAULT NULL,
  `aktif` enum('Y','N') DEFAULT NULL,
  PRIMARY KEY (`kode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='kode TIDAK autoincrement,karena agar bisa ditentukan sendiri\r\nfiled "aktif" belum digunakan dalam kode';

--
-- Dumping data for table `jam`
--

INSERT INTO `jam` (`kode`, `range_jam`, `aktif`) VALUES
(1, '08.00-08.50', NULL),
(2, '08.50-09.40', NULL),
(3, '09.40-10.30', NULL),
(4, '10.30-11.20', NULL),
(5, '11.20-12.10', NULL),
(6, '12.10-13.00', NULL),
(7, '13.00-13.50', NULL),
(8, '13.50-14.40', NULL),
(9, '14.40-15.30', NULL),
(10, '15.30-16.20', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `mata_kuliah`
--

CREATE TABLE IF NOT EXISTS `mata_kuliah` (
  `kode` int(10) NOT NULL AUTO_INCREMENT,
  `kode_mk` varchar(50) DEFAULT NULL,
  `nama` varchar(50) DEFAULT NULL,
  `sks` int(6) DEFAULT NULL,
  `semester` int(6) DEFAULT NULL,
  `aktif` enum('True','False') DEFAULT NULL,
  `jenis` enum('TEORI','PRAKTIKUM') DEFAULT NULL,
  PRIMARY KEY (`kode`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COMMENT='example kode_mk = 0765109 ' AUTO_INCREMENT=34 ;

--
-- Dumping data for table `mata_kuliah`
--

INSERT INTO `mata_kuliah` (`kode`, `kode_mk`, `nama`, `sks`, `semester`, `aktif`, `jenis`) VALUES
(4, '', 'IMK', 3, 3, 'True', 'TEORI'),
(5, '', 'Instalasi & Maintenance + Prakt', 4, 3, 'True', 'TEORI'),
(6, '', 'Basis Data Dasar', 3, 1, 'True', 'TEORI'),
(7, '', 'KDD', 4, 1, 'True', 'TEORI'),
(8, '', 'Desain & Manaj Jaringan', 3, 3, 'True', 'TEORI'),
(9, '', 'ES', 3, 3, 'True', 'TEORI'),
(10, '', 'Software Engineering Fund.', 4, 3, 'True', 'TEORI'),
(11, '', 'Seminar Penelitian', 2, 5, 'True', 'TEORI'),
(12, '', 'DAA', 3, 3, 'True', 'TEORI'),
(13, '', 'Bhs Inggris', 3, 3, 'True', 'TEORI'),
(14, '', 'Agama', 3, 1, 'True', 'TEORI'),
(15, '', 'Matematika 1', 3, 1, 'True', 'TEORI'),
(16, '', 'AI 1', 3, 1, 'True', 'TEORI'),
(17, '', 'Statistik & Probabilitas', 3, 3, 'True', 'TEORI'),
(18, '', 'MPI', 2, 5, 'True', 'TEORI'),
(19, '', 'Alpro 1', 3, 1, 'True', 'PRAKTIKUM'),
(20, '', 'Pemrograman Citra + Prakt', 4, 5, 'True', 'PRAKTIKUM'),
(21, '', 'Citra 2 + Praktikum', 4, 5, 'True', 'PRAKTIKUM'),
(22, '', 'Pemrograman C/S + Prakt', 4, 5, 'True', 'PRAKTIKUM'),
(23, '', 'Struktur Data + Prakt', 4, 5, 'True', 'PRAKTIKUM'),
(24, '', 'PTI + Praktikum', 3, 3, 'True', 'PRAKTIKUM'),
(25, '', 'Advance Network + Prakt', 4, 5, 'True', 'PRAKTIKUM'),
(26, '', 'Pemrog Berbasis Jar 2', 3, 3, 'True', 'PRAKTIKUM'),
(27, '', 'Pemrog Berbasis Mobile', 3, 5, 'True', 'PRAKTIKUM'),
(28, '', 'OOP 1', 3, 1, 'True', 'PRAKTIKUM'),
(29, '', 'Advance Web Prog 2', 3, 5, 'True', 'PRAKTIKUM'),
(30, '', 'Multimedia', 3, 3, 'True', 'PRAKTIKUM'),
(31, '', 'Grafis 1', 2, 1, 'True', 'PRAKTIKUM'),
(32, '', 'Pemrograman 3 Tier', 3, 5, 'True', 'PRAKTIKUM'),
(33, '', 'ADBO', 3, 3, 'True', 'PRAKTIKUM');

-- --------------------------------------------------------

--
-- Table structure for table `pengampu`
--

CREATE TABLE IF NOT EXISTS `pengampu` (
  `kode` int(10) NOT NULL AUTO_INCREMENT,
  `kode_mk` int(10) DEFAULT NULL,
  `kode_dosen` int(10) DEFAULT NULL,
  `kelas` varchar(10) DEFAULT NULL,
  `tahun_akademik` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`kode`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=99 ;

--
-- Dumping data for table `pengampu`
--

INSERT INTO `pengampu` (`kode`, `kode_mk`, `kode_dosen`, `kelas`, `tahun_akademik`) VALUES
(49, 4, 10, 'P1', '2011/2012'),
(50, 5, 5, 'P1', '2011/2012'),
(51, 6, 11, 'P1', '2011/2012'),
(52, 5, 5, 'P2', '2011/2012'),
(53, 7, 34, 'P1', '2011/2012'),
(54, 11, 8, 'AI', '2011/2012'),
(55, 8, 23, 'P1', '2011/2012'),
(56, 6, 12, 'P2', '2011/2012'),
(57, 9, 8, 'P1', '2011/2012'),
(58, 10, 12, 'P1', '2011/2012'),
(59, 11, 12, 'RPL', '2011/2012'),
(60, 12, 19, 'P1', '2011/2012'),
(61, 10, 9, 'P2', '2011/2012'),
(62, 11, 21, 'JAR', '2011/2012'),
(63, 13, 13, 'P1', '2011/2012'),
(64, 14, 14, 'P1', '2011/2012'),
(65, 14, 14, 'P2', '2011/2012'),
(66, 15, 3, 'P1', '2011/2012'),
(67, 16, 22, 'P1', '2011/2012'),
(68, 17, 2, 'P1', '2011/2012'),
(69, 16, 22, 'P2', '2011/2012'),
(70, 15, 3, 'P2', '2011/2012'),
(71, 17, 2, 'P2', '2011/2012'),
(72, 18, 26, 'P1', '2011/2012'),
(73, 12, 27, 'P2', '2011/2012'),
(74, 19, 24, 'P1', '2011/2012'),
(75, 19, 24, 'P3', '2011/2012'),
(76, 21, 17, 'P1', '2011/2012'),
(77, 22, 11, 'P1', '2011/2012'),
(78, 23, 20, 'P1', '2011/2012'),
(79, 24, 33, 'P1', '2011/2012'),
(80, 19, 20, 'P2', '2011/2012'),
(81, 20, 6, 'P1', '2011/2012'),
(82, 21, 6, 'P2', '2011/2012'),
(83, 24, 33, 'P2', '2011/2012'),
(84, 22, 28, 'P2', '2011/2012'),
(85, 25, 7, 'P1', '2011/2012'),
(86, 26, 7, 'P1', '2011/2012'),
(87, 27, 31, 'P1', '2011/2012'),
(88, 28, 7, 'P2', '2011/2012'),
(89, 29, 34, 'P1', '2011/2012'),
(90, 30, 16, 'P1', '2011/2012'),
(91, 31, 10, 'P1', '2011/2012'),
(92, 31, 10, 'P3', '2011/2012'),
(93, 32, 21, 'P1', '2011/2012'),
(94, 33, 21, 'P1', '2011/2012'),
(95, 23, 19, 'P2', '2011/2012'),
(96, 31, 14, 'P2', '2011/2012'),
(97, 30, 16, 'P2', '2011/2012'),
(98, 28, 24, 'P1', '2011/2012');

-- --------------------------------------------------------

--
-- Table structure for table `ruang`
--

CREATE TABLE IF NOT EXISTS `ruang` (
  `kode` int(10) NOT NULL AUTO_INCREMENT,
  `nama` varchar(50) DEFAULT NULL,
  `kapasitas` int(10) DEFAULT NULL,
  `jenis` enum('TEORI','LABORATORIUM') DEFAULT NULL,
  PRIMARY KEY (`kode`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `ruang`
--

INSERT INTO `ruang` (`kode`, `nama`, `kapasitas`, `jenis`) VALUES
(1, 'Ruang 2.1', 40, 'TEORI'),
(2, 'Ruang 3.1', 40, 'TEORI'),
(3, 'Ruang 3.2', 40, 'TEORI'),
(4, 'Ruang 3.3', 40, 'TEORI'),
(5, 'Ruang 3.4', 40, 'TEORI'),
(6, 'Ruang 3.6', 40, 'TEORI'),
(7, 'Lab. Pemrograman', 40, 'LABORATORIUM'),
(8, 'Lab. AI & Citra', 40, 'LABORATORIUM'),
(9, 'Lab. Multimedia', 40, 'LABORATORIUM'),
(10, 'Lab. RPL', 40, 'LABORATORIUM');

-- --------------------------------------------------------

--
-- Table structure for table `waktu_tidak_bersedia`
--

CREATE TABLE IF NOT EXISTS `waktu_tidak_bersedia` (
  `kode` int(10) NOT NULL AUTO_INCREMENT,
  `kode_dosen` int(10) DEFAULT NULL,
  `kode_jam` int(10) DEFAULT NULL,
  `kode_hari` int(10) DEFAULT NULL,
  PRIMARY KEY (`kode`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=101 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
