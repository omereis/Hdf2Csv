use emg;
drop table if exists tblUsers;

CREATE TABLE `tblusers` (
  `user_id` int NOT NULL,
  `last_name` text,
  `first_name` text,
  `email` text,
  `phone` text,
  `username` varchar(255) not null,
  `password` text,
  `is_active` tinyint,
  PRIMARY KEY (`user_id`),
  unique (username)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

delete from tblUsers;
insert into tblUsers (user_id,username,first_name,last_name,is_active) values (100, 'admin','EMG','Admin',1);
select * from tblUsers;
insert into tblUsers (user_id,username) values (101, 'user101');
delete from tblUsers where user_id=101;
