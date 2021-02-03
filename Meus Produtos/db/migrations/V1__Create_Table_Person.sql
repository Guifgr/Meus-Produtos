CREATE TABLE `person` (
  `user_id` bigint NOT NULL AUTO_INCREMENT,
  `user_name` varchar(30) DEFAULT NULL,
  `user_password` varchar(20) DEFAULT NULL,
  `user_email` varchar(80) DEFAULT NULL,
  UNIQUE KEY unique_email (user_email),
  PRIMARY KEY (`user_id`)
);