user emg;
drop TABLE if exists tblqstnrs;

CREATE TABLE tblQstnrs (
  qnr_id int NOT NULL primary key,
  qnr_name text,
  qnr_desc text
);

insert into tblQstnrs (qnr_id, qnr_name, qnr_desc) values (10, 'ARAT', 'The Action Research Arm Test (ARAT) is a 19 item observational measure used by physical therapists and other health care professionals to assess upper extremity performance (coordination, dexterity and functioning) in stroke recovery, brain injury and multiple sclerosis populations.'),(11,'Protocol', 'הפרוטוקול יעשה פעמיים – פעם אחת עבור מיישרי שורש כף היד ופעם אחת עבור מיישרי המרפק.');
select * from tblQstnrs;