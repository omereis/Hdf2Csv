/*
SQLyog Community v13.2.1 (64 bit)
MySQL - 9.0.1 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

use emg;
drop table if exists tblPatients;

create table `tblPatients` (
	`patient_id` integer not null primary key,
	`code` varchar(10) not null,
	`yob` integer,
	`height` double ,
	`weight` double ,
	`gender` tinyint (4),
	unique (code)
);

insert into tblPatients (patient_id, code, yob, height, weight, gender) values (100,"wo90",1970,172,85,1);
insert into tblPatients (patient_id, code) values (101,"br_17");

select * from tblPatients;

delete from tblPatients where patient_id>101;
select count(*) from tblPatients;
select count(*) from tblPatients where code='br_17';
update tblPatients set height=null where patient_id=101;
