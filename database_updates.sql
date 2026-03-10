-- Database updates for stock management and discounts

-- Create Stock table for better inventory management
DROP TABLE IF EXISTS `Stock`;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Create Discounts table
DROP TABLE IF EXISTS `Discounts`;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Create DishDiscounts table for dish-specific discounts
DROP TABLE IF EXISTS `DishDiscounts`;
CREATE TABLE `DishDiscounts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DiscountId` int NOT NULL,
  `DishId` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `DiscountDish` (`DiscountId`,`DishId`),
  CONSTRAINT `DishDiscounts_ibfk_1` FOREIGN KEY (`DiscountId`) REFERENCES `Discounts` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `DishDiscounts_ibfk_2` FOREIGN KEY (`DishId`) REFERENCES `Dishes` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Update Orders table to support discounts
ALTER TABLE `Orders` 
ADD COLUMN `DiscountId` int DEFAULT NULL AFTER `TotalPrice`,
ADD COLUMN `DiscountAmount` decimal(10,2) DEFAULT 0 AFTER `DiscountId`,
ADD COLUMN `FinalTotal` decimal(10,2) GENERATED ALWAYS AS (`TotalPrice` - `DiscountAmount`) STORED AFTER `DiscountAmount`,
ADD CONSTRAINT `Orders_ibfk_2` FOREIGN KEY (`DiscountId`) REFERENCES `Discounts` (`Id`);

-- Insert initial stock data for existing dishes
INSERT INTO `Stock` (DishId, Quantity, UpdatedBy)
SELECT d.Id, 50, 1 FROM Dishes d
WHERE NOT EXISTS (SELECT 1 FROM Stock s WHERE s.DishId = d.Id);

-- Insert sample discounts
INSERT INTO `Discounts` (Name, Description, DiscountType, DiscountValue, MinOrderAmount, StartDate, EndDate, CreatedBy) VALUES
('Weekend Special', '10% off on orders above $50 during weekends', 'Percentage', 10.00, 50.00, '2026-01-01 00:00:00', '2026-12-31 23:59:59', 1),
('Lunch Deal', '$5 off on orders above $25', 'FixedAmount', 5.00, 25.00, '2026-01-01 11:00:00', '2026-12-31 15:00:00', 1),
('Happy Hour', '15% off drinks between 5PM-7PM', 'Percentage', 15.00, 10.00, '2026-01-01 17:00:00', '2026-12-31 19:00:00', 1);
