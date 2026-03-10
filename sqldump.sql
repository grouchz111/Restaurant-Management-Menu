-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: Restaurant
-- ------------------------------------------------------
-- Server version	9.4.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `Restaurant`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `Restaurant` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `Restaurant`;

--
-- Table structure for table `Categories`
--

DROP TABLE IF EXISTS `Categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Categories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Categories`
--

LOCK TABLES `Categories` WRITE;
/*!40000 ALTER TABLE `Categories` DISABLE KEYS */;
INSERT INTO `Categories` VALUES (1,'Appetizers'),(2,'Main dishes'),(3,'Desserts'),(4,'Drinks'),(5,'Salads');
/*!40000 ALTER TABLE `Categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Role` enum('Admin','Waiter') NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES (1,'admin','admin123','Admin'),(2,'waiter1','waiter','Waiter'),(3,'waiter2','waiter2','Waiter');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Dishes`
--

DROP TABLE IF EXISTS `Dishes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Dishes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Description` text,
  `Price` decimal(10,2) NOT NULL,
  `CategoryId` int NOT NULL,
  `ImagePath` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `CategoryId` (`CategoryId`),
  CONSTRAINT `Dishes_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`),
  CONSTRAINT `Dishes_chk_1` CHECK ((`Price` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Dishes`
--

LOCK TABLES `Dishes` WRITE;
/*!40000 ALTER TABLE `Dishes` DISABLE KEYS */;
INSERT INTO `Dishes` VALUES 
-- Appetizers (15 dishes)
(1,'Bruschetta','Toasted bread with tomatoes, garlic, basil and olive oil',8.50,1,'images/bruschetta.jpg'),
(2,'Garlic Bread','Toasted bread with garlic butter and herbs',6.00,1,'images/garlic_bread.jpg'),
(3,'Mozzarella Sticks','Breaded mozzarella with marinara sauce',9.00,1,'images/mozzarella_sticks.jpg'),
(4,'Onion Rings','Crispy battered onion rings with dipping sauce',7.50,1,'images/onion_rings.jpg'),
(5,'Chicken Wings','Spicy buffalo wings with blue cheese dip',10.00,1,'images/chicken_wings.jpg'),
(6,'Spinach Artichoke Dip','Creamy dip with spinach, artichokes and tortilla chips',11.00,1,'images/spinach_dip.jpg'),
(7,'Nachos','Tortilla chips with cheese, jalapeños, sour cream and guacamole',12.00,1,'images/nachos.jpg'),
(8,'Shrimp Cocktail','Chilled shrimp with cocktail sauce',14.00,1,'images/shrimp_cocktail.jpg'),
(9,'Caprese Skewers','Cherry tomatoes, mozzarella, basil with balsamic glaze',9.50,1,'images/caprese_skewers.jpg'),
(10,'Stuffed Mushrooms','Mushrooms stuffed with herbs, cheese and breadcrumbs',8.00,1,'images/stuffed_mushrooms.jpg'),
(11,'Deviled Eggs','Classic deviled eggs with paprika',6.50,1,'images/deviled_eggs.jpg'),
(12,'French Fries','Crispy golden fries with ketchup',5.00,1,'images/french_fries.jpg'),
(13,'Quesadilla','Grilled tortilla with cheese and peppers',9.00,1,'images/quesadilla.jpg'),
(14,'Calamari','Fried squid rings with marinara sauce',13.00,1,'images/calamari.jpg'),
(15,'Spring Rolls','Vegetable spring rolls with sweet chili sauce',7.00,1,'images/spring_rolls.jpg'),

-- Main dishes (15 dishes)
(16,'Grilled Ribeye Steak','12oz ribeye with mashed potatoes and vegetables',28.00,2,'images/ribeye_steak.jpg'),
(17,'Chicken Parmesan','Breaded chicken with marinara, mozzarella and pasta',22.00,2,'images/chicken_parma.jpg'),
(18,'Spaghetti Carbonara','Pasta with bacon, eggs, parmesan and black pepper',18.00,2,'images/carbonara.jpg'),
(19,'Fish and Chips','Battered cod with fries and tartar sauce',16.00,2,'images/fish_chips.jpg'),
(20,'Beef Burger','Angus beef patty with cheese, lettuce, tomato, fries',15.00,2,'images/beef_burger.jpg'),
(21,'Chicken Alfredo','Grilled chicken with fettuccine in creamy alfredo sauce',20.00,2,'images/chicken_alfredo.jpg'),
(22,'Pork Chops','Grilled pork chops with apple sauce and roasted potatoes',24.00,2,'images/pork_chops.jpg'),
(23,'Salmon Teriyaki','Grilled salmon with teriyaki glaze and rice',26.00,2,'images/salmon_teriyaki.jpg'),
(24,'Lasagna','Layered pasta with meat sauce, cheese and béchamel',19.00,2,'images/lasagna.jpg'),
(25,'Shepherd''s Pie','Ground lamb with mashed potatoes and vegetables',17.00,2,'images/shepherds_pie.jpg'),
(26,'Chicken Tikka Masala','Creamy tomato curry with rice and naan bread',21.00,2,'images/tikka_masala.jpg'),
(27,'Beef Stroganoff','Beef strips in mushroom sauce over egg noodles',23.00,2,'images/beef_stroganoff.jpg'),
(28,'Grilled Chicken','Herb-marinated chicken with roasted vegetables',18.00,2,'images/grilled_chicken.jpg'),
(29,'Shrimp Scampi','Shrimp in garlic butter sauce over linguine',25.00,2,'images/shrimp_scampi.jpg'),
(30,'Vegetarian Pizza','Margherita pizza with fresh basil and mozzarella',14.00,2,'images/veggie_pizza.jpg'),

-- Desserts (15 dishes)
(31,'Chocolate Lava Cake','Warm chocolate cake with molten center',8.00,3,'images/lava_cake.jpg'),
(32,'Tiramisu','Italian coffee-flavored dessert with mascarpone',7.50,3,'images/tiramisu.jpg'),
(33,'New York Cheesecake','Classic cheesecake with berry compote',7.00,3,'images/cheesecake.jpg'),
(34,'Apple Pie','Traditional apple pie with vanilla ice cream',6.50,3,'images/apple_pie.jpg'),
(35,'Crème Brûlée','Vanilla custard with caramelized sugar top',8.50,3,'images/creme_brulee.jpg'),
(36,'Brownie Sundae','Warm brownie with ice cream, chocolate sauce and whipped cream',7.00,3,'images/brownie_sundae.jpg'),
(37,'Chocolate Mousse','Light and airy chocolate mousse',6.00,3,'images/chocolate_mousse.jpg'),
(38,'Key Lime Pie','Tangy lime pie with graham cracker crust',6.50,3,'images/key_lime_pie.jpg'),
(39,'Panna Cotta','Vanilla panna cotta with berry sauce',7.00,3,'images/panna_cotta.jpg'),
(40,'Ice Cream Scoops','Three scoops of premium ice cream',5.00,3,'images/ice_cream.jpg'),
(41,'Chocolate Chip Cookies','Fresh baked cookies with milk',4.50,3,'images/cookies.jpg'),
(42,'Fruit Tart','Fresh fruit tart with pastry cream',8.00,3,'images/fruit_tart.jpg'),
(43,'Bread Pudding','Warm bread pudding with vanilla sauce',6.00,3,'images/bread_pudding.jpg'),
(44,'Chocolate Fondant','Rich chocolate fondant with raspberry coulis',9.00,3,'images/chocolate_fondant.jpg'),
(45,'Strawberry Shortcake','Layered sponge cake with strawberries and cream',7.50,3,'images/strawberry_shortcake.jpg'),

-- Drinks (15 dishes)
(46,'Coca-Cola','Classic cola soft drink',3.00,4,'images/coca_cola.jpg'),
(47,'Orange Juice','Fresh squeezed orange juice',4.00,4,'images/orange_juice.jpg'),
(48,'Lemonade','Fresh lemonade with mint',3.50,4,'images/lemonade.jpg'),
(49,'Iced Coffee','Cold brew coffee with ice',4.50,4,'images/iced_coffee.jpg'),
(50,'Hot Coffee','Freshly brewed coffee',3.00,4,'images/hot_coffee.jpg'),
(51,'Green Tea','Japanese green tea',3.50,4,'images/green_tea.jpg'),
(52,'Apple Juice','100% pure apple juice',3.50,4,'images/apple_juice.jpg'),
(53,'Milkshake','Vanilla milkshake with whipped cream',6.00,4,'images/milkshake.jpg'),
(54,'Smoothie','Mixed berry smoothie',5.50,4,'images/smoothie.jpg'),
(55,'Mineral Water','Sparkling mineral water',2.50,4,'images/mineral_water.jpg'),
(56,'Hot Chocolate','Rich hot chocolate with marshmallows',4.00,4,'images/hot_chocolate.jpg'),
(57,'Ginger Ale','Refreshing ginger ale',3.00,4,'images/ginger_ale.jpg'),
(58,'Cranberry Juice','Pure cranberry juice',4.00,4,'images/cranberry_juice.jpg'),
(59,'Iced Tea','Sweet iced tea with lemon',3.00,4,'images/iced_tea.jpg'),
(60,'Root Beer','Classic root beer float',4.50,4,'images/root_beer.jpg'),

-- Salads (15 dishes)
(61,'Caesar Salad','Romaine lettuce, parmesan, croutons, caesar dressing',10.00,5,'images/caesar_salad.jpg'),
(62,'Greek Salad','Tomatoes, cucumbers, olives, feta, oregano dressing',11.00,5,'images/greek_salad.jpg'),
(63,'Garden Salad','Mixed greens, tomatoes, carrots, cucumber, vinaigrette',8.50,5,'images/garden_salad.jpg'),
(64,'Cobb Salad','Mixed greens, chicken, bacon, eggs, avocado, blue cheese',14.00,5,'images/cobb_salad.jpg'),
(65,'Chef Salad','Mixed greens, ham, turkey, cheese, hard-boiled eggs',12.00,5,'images/chef_salad.jpg'),
(66,'Waldorf Salad','Apples, celery, walnuts, grapes in mayonnaise dressing',9.00,5,'images/waldorf_salad.jpg'),
(67,'Caprese Salad','Fresh mozzarella, tomatoes, basil, balsamic glaze',10.50,5,'images/caprese_salad.jpg'),
(68,'Spinach Salad','Fresh spinach with strawberries, almonds, poppyseed dressing',11.50,5,'images/spinach_salad.jpg'),
(69,'Pasta Salad','Rotini pasta with vegetables, Italian dressing',9.50,5,'images/pasta_salad.jpg'),
(70,'Quinoa Salad','Quinoa with roasted vegetables, lemon dressing',12.00,5,'images/quinoa_salad.jpg'),
(71,'Asian Slaw','Cabbage, carrots, sesame dressing, peanuts',8.00,5,'images/asian_slaw.jpg'),
(72,'Beet Salad','Roasted beets, goat cheese, walnuts, balsamic',11.00,5,'images/beet_salad.jpg'),
(73,'Chicken Salad','Grilled chicken over mixed greens with ranch dressing',13.00,5,'images/chicken_salad.jpg'),
(74,'Tuna Salad','Mixed greens with tuna salad, eggs, olives',10.50,5,'images/tuna_salad.jpg'),
(75,'Fruit Salad','Seasonal fresh fruits with honey-lime dressing',7.00,5,'images/fruit_salad.jpg');
/*!40000 ALTER TABLE `Dishes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Stock`
--

DROP TABLE IF EXISTS `Stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Stock` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DishId` int NOT NULL,
  `Quantity` int NOT NULL DEFAULT 0,
  `LastUpdated` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `UpdatedBy` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `DishId` (`DishId`),
  CONSTRAINT `Stock_ibfk_1` FOREIGN KEY (`DishId`) REFERENCES `Dishes` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `Stock_ibfk_2` FOREIGN KEY (`UpdatedBy`) REFERENCES `Users` (`Id`),
  CONSTRAINT `Stock_chk_1` CHECK ((`Quantity` >= 0))
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Stock`
--

LOCK TABLES `Stock` WRITE;
/*!40000 ALTER TABLE `Stock` DISABLE KEYS */;
INSERT INTO `Stock` (DishId, Quantity, UpdatedBy) VALUES
(1,50,1),(2,50,1),(3,50,1),(4,50,1),(5,50,1),(6,50,1),(7,50,1),(8,50,1),(9,50,1),(10,50,1),
(11,50,1),(12,50,1),(13,50,1),(14,50,1),(15,50,1),(16,50,1),(17,50,1),(18,50,1),(19,50,1),(20,50,1),
(21,50,1),(22,50,1),(23,50,1),(24,50,1),(25,50,1),(26,50,1),(27,50,1),(28,50,1),(29,50,1),(30,50,1),
(31,50,1),(32,50,1),(33,50,1),(34,50,1),(35,50,1),(36,50,1),(37,50,1),(38,50,1),(39,50,1),(40,50,1),
(41,50,1),(42,50,1),(43,50,1),(44,50,1),(45,50,1),(46,50,1),(47,50,1),(48,50,1),(49,50,1),(50,50,1),
(51,50,1),(52,50,1),(53,50,1),(54,50,1),(55,50,1),(56,50,1),(57,50,1),(58,50,1),(59,50,1),(60,50,1),
(61,50,1),(62,50,1),(63,50,1),(64,50,1),(65,50,1),(66,50,1),(67,50,1),(68,50,1),(69,50,1),(70,50,1),
(71,50,1),(72,50,1),(73,50,1),(74,50,1),(75,50,1);
/*!40000 ALTER TABLE `Stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Discounts`
--

DROP TABLE IF EXISTS `Discounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Discounts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Description` text,
  `DiscountType` enum('Percentage','FixedAmount') NOT NULL,
  `DiscountValue` decimal(10,2) NOT NULL,
  `MinOrderAmount` decimal(10,2) DEFAULT 0,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `IsActive` boolean DEFAULT true,
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  CONSTRAINT `Discounts_ibfk_1` FOREIGN KEY (`CreatedBy`) REFERENCES `Users` (`Id`),
  CONSTRAINT `Discounts_chk_1` CHECK ((`DiscountValue` > 0)),
  CONSTRAINT `Discounts_chk_2` CHECK ((`MinOrderAmount` >= 0)),
  CONSTRAINT `Discounts_chk_3` CHECK ((`StartDate` <= `EndDate`))
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Discounts`
--

LOCK TABLES `Discounts` WRITE;
/*!40000 ALTER TABLE `Discounts` DISABLE KEYS */;
INSERT INTO `Discounts` (Name, Description, DiscountType, DiscountValue, MinOrderAmount, StartDate, EndDate, CreatedBy) VALUES
('Weekend Special', '10% off on orders above $50 during weekends', 'Percentage', 10.00, 50.00, '2026-01-01 00:00:00', '2026-12-31 23:59:59', 1),
('Lunch Deal', '$5 off on orders above $25', 'FixedAmount', 5.00, 25.00, '2026-01-01 11:00:00', '2026-12-31 15:00:00', 1),
('Happy Hour', '15% off drinks between 5PM-7PM', 'Percentage', 15.00, 10.00, '2026-01-01 17:00:00', '2026-12-31 19:00:00', 1);
/*!40000 ALTER TABLE `Discounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DishDiscounts`
--

DROP TABLE IF EXISTS `DishDiscounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DishDiscounts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DiscountId` int NOT NULL,
  `DishId` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `DiscountDish` (`DiscountId`,`DishId`),
  CONSTRAINT `DishDiscounts_ibfk_1` FOREIGN KEY (`DiscountId`) REFERENCES `Discounts` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `DishDiscounts_ibfk_2` FOREIGN KEY (`DishId`) REFERENCES `Dishes` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DishDiscounts`
--

LOCK TABLES `DishDiscounts` WRITE;
/*!40000 ALTER TABLE `DishDiscounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `DishDiscounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Orders`
--

DROP TABLE IF EXISTS `Orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Orders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `WaiterId` int NOT NULL,
  `OrderDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `TotalPrice` decimal(10,2) NOT NULL,
  `DiscountId` int DEFAULT NULL,
  `DiscountAmount` decimal(10,2) DEFAULT 0,
  `FinalTotal` decimal(10,2) GENERATED ALWAYS AS (`TotalPrice` - `DiscountAmount`) STORED,
  PRIMARY KEY (`Id`),
  KEY `WaiterId` (`WaiterId`),
  KEY `DiscountId` (`DiscountId`),
  CONSTRAINT `Orders_ibfk_1` FOREIGN KEY (`WaiterId`) REFERENCES `Users` (`Id`),
  CONSTRAINT `Orders_ibfk_2` FOREIGN KEY (`DiscountId`) REFERENCES `Discounts` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Orders`
--

LOCK TABLES `Orders` WRITE;
/*!40000 ALTER TABLE `Orders` DISABLE KEYS */;
/*!40000 ALTER TABLE `Orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OrderItems`
--

DROP TABLE IF EXISTS `OrderItems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OrderItems` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OrderId` int NOT NULL,
  `DishId` int NOT NULL,
  `Quantity` int NOT NULL DEFAULT '1',
  `PriceAtOrder` decimal(10,2) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `OrderId` (`OrderId`),
  KEY `DishId` (`DishId`),
  CONSTRAINT `OrderItems_ibfk_1` FOREIGN KEY (`OrderId`) REFERENCES `Orders` (`Id`),
  CONSTRAINT `OrderItems_ibfk_2` FOREIGN KEY (`DishId`) REFERENCES `Dishes` (`Id`),
  CONSTRAINT `OrderItems_chk_1` CHECK ((`Quantity` > 0))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OrderItems`
--

LOCK TABLES `OrderItems` WRITE;
/*!40000 ALTER TABLE `OrderItems` DISABLE KEYS */;
/*!40000 ALTER TABLE `OrderItems` ENABLE KEYS */;
UNLOCK TABLES;

--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-03-10 16:22:00
