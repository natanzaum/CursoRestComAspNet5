create database restwithaspnet;

use restwithaspnet;

create table person(
    id bigint(20) NOT NULL AUTO_INCREMENT,
    address VARCHAR(100) NOT NULL,
    frist_name varchar(80) NOT NULL,
    last_name VARCHAR(80) NOT NULL,
    gender VARCHAR(12) NOT NULL,
    PRIMARY KEY (id))