user emg;
drop TABLE if exists tblProtocols;

CREATE TABLE tblProtocols (
  protocol_id int NOT NULL primary key,
  protocol_name text,
  protocol_desc text
);

drop TABLE if exists tblSections;

CREATE TABLE tblSections (
  section_id integer NOT NULL PRIMARY KEY,
  protocol_id integer,
  sect_order	integer,
  section_title text,
  section_desc	text,
  foreign key (protocol_id) REFERENCES  tblProtocols(protocol_id) on update cascade on delete cascade
/*  ,
  desc text,
  foreign key (protocol_id) REFERENCES  tblProtocols(protocol_id)
*/
);

drop table if exists tblProtocolTasks ;

create table tblProtocolTasks (
	task_id		integer not null primary key,
	task_order	integer,
	section_id	integer,
	task_desc	text,
	unique (section_id,task_order),
	foreign key (section_id) references tblSections (section_id) on update cascade on delete cascade
);

/*
	dtStart	datetime,
	dtEnd	datetime,
	result	text,
	emg		blob,
*/

insert into tblProtocols (protocol_id, protocol_name, protocol_desc) values (10, 'ARAT', 'The Action Research Arm Test (ARAT) is a 19 item observational measure used by physical therapists and other health care professionals to assess upper extremity performance (coordination, dexterity and functioning) in stroke recovery, brain injury and multiple sclerosis populations.'),(11,'Protocol', 'הפרוטוקול יעשה פעמיים – פעם אחת עבור מיישרי שורש כף היד ופעם אחת עבור מיישרי המרפק.');
select * from tblProtocols;
insert into tblSections (section_id,protocol_id,sect_order,section_title) values (1,10,0,'Grasp'),(2,10,1,'Grip');

select * from tblProtocolTasks;
insert into tblProtocolTasks (section_id,task_id,task_order,task_desc) values (1,1,0,'Block, Wood, 10cm Wood (if score=3, total=18 and to Grip'),(1,2,1,'Block,wood,2.5cm cube (if score=0, total=0 and go to Grip');

select 
  tblProtocols.protocol_id,
  protocol_name,
  protocol_desc,
  section_id,
  sect_order,
  section_title,
  section_desc
 from tblProtocols,tblSections where tblProtocols.protocol_id=tblSections.protocol_id;
 
 select 
  protocol_id,
  protocol_name,
  protocol_desc,
  null as 'section_id',
  null as 'sect_order',
  null as 'section_title',
  null as 'section_desc'
 from tblProtocols where protocol_id not in (select distinct protocol_id from tblSections);;

create view vProtocolSections 
as
select 
  tblProtocols.protocol_id,
  protocol_name,
  protocol_desc,
  section_id,
  sect_order,
  section_title,
  section_desc
 from tblProtocols,tblSections where tblProtocols.protocol_id=tblSections.protocol_id
 
 union
 
 select 
  protocol_id,
  protocol_name,
  protocol_desc,
  null as 'section_id',
  null as 'sect_order',
  null as 'section_title',
  null as 'section_desc'
 from tblProtocols where protocol_id not in (select distinct protocol_id from tblSections)
;

select * from tblProtocols
select * from tblSections,tblProtocolTasks where tblSections.section_id=tblProtocolTasks.section_id;

select * from vProtocolSections;
select * from vProtocolSections, tblProtocolTasks where vProtocolSections.section_id=tblProtocolTasks.section_id;

drop view if exists vProtocolSectionsTasks;
create view vProtocolSectionsTasks
as
select
	protocol_id,
	protocol_name,
	protocol_desc,
	vProtocolSections.section_id,
	sect_order,
	section_title,
	section_desc,
	task_id,
	task_order,
	task_desc
	from vProtocolSections, tblProtocolTasks where vProtocolSections.section_id=tblProtocolTasks.section_id

union

select
	protocol_id,
	protocol_name,
	protocol_desc,
	vProtocolSections.section_id,
	sect_order,
	section_title,
	section_desc,
	null as 'task_id',
	null as 'task_order',
	null as 'task_desc'
	from vProtocolSections where section_id not in (select distinct section_id from tblProtocolTasks);

select * from vProtocolSectionsTasks;
