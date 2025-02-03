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
  PRIMARY KEY (`user_id`),
  unique (username)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into tblUsers