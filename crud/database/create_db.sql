CREATE DATABASE IF NOT EXISTS crud;

use crud;

CREATE TABLE IF NOT EXISTS `clients` (
    `id` int(11) AUTO_INCREMENT,
    `first_name` varchar(60) NOT NULL,
    `last_name` varchar(60) NOT NULL,
    `type_person` varchar(40) DEFAULT NULL,
    `cpf_cnpj` varchar(20) NOT NULL,
    `phone_number` varchar(20) NOT NULL,
    `type_number` varchar(40) DEFAULT NULL,
    `address` varchar(100) NOT NULL,
    `zip_code` varchar(30) NOT NULL,
    `number` varchar(10) NOT NULL,
    `complement` varchar(10) DEFAULT NULL,
    `neighborhood` varchar(200) NOT NULL,
    `city` varchar(150) NOT NULL,
    `uf` char(2) NOT NULL,
    `type_address` varchar(40) DEFAULT NULL,
    `created_at` timestamp NOT NULL DEFAULT current_timestamp,
    `updated_at` datetime DEFAULT current_timestamp ON UPDATE current_timestamp,
    PRIMARY KEY(`id`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;