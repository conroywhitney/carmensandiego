-- phpMyAdmin SQL Dump
-- version 2.9.1.1-Debian-2ubuntu1
-- http://www.phpmyadmin.net
-- 
-- Host: localhost
-- Generation Time: Nov 30, 2007 at 03:19 PM
-- Server version: 5.0.38
-- PHP Version: 5.2.1
-- 
-- Database: `4440`
-- 

-- --------------------------------------------------------

-- 
-- Table structure for table `images`
-- 

DROP TABLE IF EXISTS `images`;
CREATE TABLE `images` (
  `id` int(11) NOT NULL auto_increment,
  `filename` varchar(256) NOT NULL,
  `x` varchar(64) NOT NULL,
  `y` varchar(64) NOT NULL,
  `taken_at` datetime NOT NULL,
  `uploaded_at` datetime NOT NULL,
  `updated_at` timestamp NOT NULL default CURRENT_TIMESTAMP,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=10 ;

-- 
-- Dumping data for table `images`
-- 

INSERT INTO `images` (`id`, `filename`, `x`, `y`, `taken_at`, `uploaded_at`, `updated_at`) VALUES 
(1, 'file', '33.770', '-84.390', '2007-10-24 19:37:00', '2007-11-29 19:37:00', '2007-11-29 19:37:00'),
(2, 'file', '33.772', '-84.394', '2007-10-27 19:37:00', '2007-11-29 19:37:00', '2007-11-29 19:37:00'),
(3, 'file', '33.774', '-84.4', '2007-10-26 19:37:00', '2007-11-29 19:37:00', '2007-11-29 19:37:00'),
(4, 'file', '33.776', '-84.45', '2007-10-26 19:37:00', '2007-11-29 19:37:00', '2007-11-29 19:37:00'),
(5, 'file', '33.778', '-84.42', '2007-10-24 19:37:00', '2007-11-29 19:37:00', '2007-11-29 19:37:00'),
(6, 'file', '33.779', '-84.398000', '2007-10-29 19:37:00', '2007-11-29 19:37:00', '2007-11-29 19:37:00'),
(7, 'file', '33.776000', '-84.390', '2007-10-29 19:37:00', '2007-11-29 19:37:00', '2007-11-29 19:37:00'),
(8, 'file', '33.776000', '-84.394000', '2007-10-25 19:37:00', '2007-11-29 19:37:00', '2007-11-29 19:37:00'),
(9, 'file', '33.776000', '-84.398000', '2007-11-03 19:37:00', '2007-11-29 19:37:00', '2007-11-29 19:37:00');

