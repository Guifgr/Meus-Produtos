CREATE TABLE `product` (
  `product_id` bigint NOT NULL AUTO_INCREMENT,
  `product_name` varchar(80) DEFAULT NULL,
  `product_price` decimal(10,2) DEFAULT NULL,
  `product_is_active` bit(1) DEFAULT NULL,
  PRIMARY KEY (`product_id`)
);