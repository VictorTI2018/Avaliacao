CREATE DATABASE IF NOT EXISTS crud;

use crud;

CREATE TABLE IF NOT EXISTS `clients` (
    `id` int(11) AUTO_INCREMENT,
    `first_name` varchar(60) NOT NULL,
    `last_name` varchar(60) NOT NULL,
    `type_person` enum('fisica', 'juridica') DEFAULT NULL,
    `cpf_cnpj` varchar(20) NOT NULL,
    `created_at` timestamp NOT NULL DEFAULT current_timestamp,
    `updated_at` datetime DEFAULT current_timestamp ON UPDATE current_timestamp,
    PRIMARY KEY(`id`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE `phones` (
    `id` int(11) AUTO_INCREMENT,
    `client_id` int(11) NOT NULL,
    `number` varchar(20) NOT NULL,
    `type` enum('celular', 'residencial', 'comercial') DEFAULT NULL,
    `created_at` timestamp NOT NULL DEFAULT current_timestamp,
    `updated_at` datetime DEFAULT current_timestamp ON UPDATE current_timestamp,
    PRIMARY KEY(`id`),
    FOREIGN KEY(`client_id`) REFERENCES `clients`(`id`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE `adresses` (
    `id` int(11) AUTO_INCREMENT,
    `client_id` int(11) NOT NULL,
    `address` varchar(100) NOT NULL,
    `zip_code` varchar(30) NOT NULL,
    `number` varchar(10) NOT NULL,
    `complement` varchar(10) DEFAULT NULL,
    `neighborhood` varchar(200) NOT NULL,
    `city` varchar(150) NOT NULL,
    `uf` char(2) NOT NULL,
    `type` enum(
        'cobranca',
        'comercial',
        'correspondencia',
        'entrega',
        'residencial'
    ) DEFAULT NULL,
    `created_at` timestamp NOT NULL DEFAULT current_timestamp,
    `updated_at` datetime DEFAULT current_timestamp ON UPDATE current_timestamp,
    PRIMARY KEY(`id`),
    FOREIGN KEY(`client_id`) REFERENCES `clients`(`id`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;