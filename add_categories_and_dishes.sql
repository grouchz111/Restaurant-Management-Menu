-- Add missing categories and insert 75 dishes (15 per category)
-- Categories: Appetizers, Main dishes, Desserts, Drinks, Salads

-- First, ensure we have all required categories
INSERT IGNORE INTO Categories (Name) VALUES 
('Appetizers'),
('Main dishes'), 
('Desserts'),
('Drinks'),
('Salads');

-- Get category IDs for reference (assuming standard order)
-- Appetizers = 1, Main dishes = 2, Desserts = 3, Drinks = 4, Salads = 5

-- Clear existing dishes to avoid duplicates
DELETE FROM DishDiscounts;
DELETE FROM OrderItems;
DELETE FROM Stock;
DELETE FROM Dishes;

-- Insert Appetizers (15 dishes)
INSERT INTO Dishes (Name, Description, Price, CategoryId, ImagePath) VALUES
('Bruschetta', 'Toasted bread with tomatoes, garlic, basil and olive oil', 8.50, 1, 'images/bruschetta.jpg'),
('Garlic Bread', 'Toasted bread with garlic butter and herbs', 6.00, 1, 'images/garlic_bread.jpg'),
('Mozzarella Sticks', 'Breaded mozzarella with marinara sauce', 9.00, 1, 'images/mozzarella_sticks.jpg'),
('Onion Rings', 'Crispy battered onion rings with dipping sauce', 7.50, 1, 'images/onion_rings.jpg'),
('Chicken Wings', 'Spicy buffalo wings with blue cheese dip', 10.00, 1, 'images/chicken_wings.jpg'),
('Spinach Artichoke Dip', 'Creamy dip with spinach, artichokes and tortilla chips', 11.00, 1, 'images/spinach_dip.jpg'),
('Nachos', 'Tortilla chips with cheese, jalapeños, sour cream and guacamole', 12.00, 1, 'images/nachos.jpg'),
('Shrimp Cocktail', 'Chilled shrimp with cocktail sauce', 14.00, 1, 'images/shrimp_cocktail.jpg'),
('Caprese Skewers', 'Cherry tomatoes, mozzarella, basil with balsamic glaze', 9.50, 1, 'images/caprese_skewers.jpg'),
('Stuffed Mushrooms', 'Mushrooms stuffed with herbs, cheese and breadcrumbs', 8.00, 1, 'images/stuffed_mushrooms.jpg'),
('Deviled Eggs', 'Classic deviled eggs with paprika', 6.50, 1, 'images/deviled_eggs.jpg'),
('French Fries', 'Crispy golden fries with ketchup', 5.00, 1, 'images/french_fries.jpg'),
('Quesadilla', 'Grilled tortilla with cheese and peppers', 9.00, 1, 'images/quesadilla.jpg'),
('Calamari', 'Fried squid rings with marinara sauce', 13.00, 1, 'images/calamari.jpg'),
('Spring Rolls', 'Vegetable spring rolls with sweet chili sauce', 7.00, 1, 'images/spring_rolls.jpg');

-- Insert Main dishes (15 dishes)
INSERT INTO Dishes (Name, Description, Price, CategoryId, ImagePath) VALUES
('Grilled Ribeye Steak', '12oz ribeye with mashed potatoes and vegetables', 28.00, 2, 'images/ribeye_steak.jpg'),
('Chicken Parmesan', 'Breaded chicken with marinara, mozzarella and pasta', 22.00, 2, 'images/chicken_parma.jpg'),
('Spaghetti Carbonara', 'Pasta with bacon, eggs, parmesan and black pepper', 18.00, 2, 'images/carbonara.jpg'),
('Fish and Chips', 'Battered cod with fries and tartar sauce', 16.00, 2, 'images/fish_chips.jpg'),
('Beef Burger', 'Angus beef patty with cheese, lettuce, tomato, fries', 15.00, 2, 'images/beef_burger.jpg'),
('Chicken Alfredo', 'Grilled chicken with fettuccine in creamy alfredo sauce', 20.00, 2, 'images/chicken_alfredo.jpg'),
('Pork Chops', 'Grilled pork chops with apple sauce and roasted potatoes', 24.00, 2, 'images/pork_chops.jpg'),
('Salmon Teriyaki', 'Grilled salmon with teriyaki glaze and rice', 26.00, 2, 'images/salmon_teriyaki.jpg'),
('Lasagna', 'Layered pasta with meat sauce, cheese and béchamel', 19.00, 2, 'images/lasagna.jpg'),
('Shepherd''s Pie', 'Ground lamb with mashed potatoes and vegetables', 17.00, 2, 'images/shepherds_pie.jpg'),
('Chicken Tikka Masala', 'Creamy tomato curry with rice and naan bread', 21.00, 2, 'images/tikka_masala.jpg'),
('Beef Stroganoff', 'Beef strips in mushroom sauce over egg noodles', 23.00, 2, 'images/beef_stroganoff.jpg'),
('Grilled Chicken', 'Herb-marinated chicken with roasted vegetables', 18.00, 2, 'images/grilled_chicken.jpg'),
('Shrimp Scampi', 'Shrimp in garlic butter sauce over linguine', 25.00, 2, 'images/shrimp_scampi.jpg'),
('Vegetarian Pizza', 'Margherita pizza with fresh basil and mozzarella', 14.00, 2, 'images/veggie_pizza.jpg');

-- Insert Desserts (15 dishes)
INSERT INTO Dishes (Name, Description, Price, CategoryId, ImagePath) VALUES
('Chocolate Lava Cake', 'Warm chocolate cake with molten center', 8.00, 3, 'images/lava_cake.jpg'),
('Tiramisu', 'Italian coffee-flavored dessert with mascarpone', 7.50, 3, 'images/tiramisu.jpg'),
('New York Cheesecake', 'Classic cheesecake with berry compote', 7.00, 3, 'images/cheesecake.jpg'),
('Apple Pie', 'Traditional apple pie with vanilla ice cream', 6.50, 3, 'images/apple_pie.jpg'),
('Crème Brûlée', 'Vanilla custard with caramelized sugar top', 8.50, 3, 'images/creme_brulee.jpg'),
('Brownie Sundae', 'Warm brownie with ice cream, chocolate sauce and whipped cream', 7.00, 3, 'images/brownie_sundae.jpg'),
('Chocolate Mousse', 'Light and airy chocolate mousse', 6.00, 3, 'images/chocolate_mousse.jpg'),
('Key Lime Pie', 'Tangy lime pie with graham cracker crust', 6.50, 3, 'images/key_lime_pie.jpg'),
('Panna Cotta', 'Vanilla panna cotta with berry sauce', 7.00, 3, 'images/panna_cotta.jpg'),
('Ice Cream Scoops', 'Three scoops of premium ice cream', 5.00, 3, 'images/ice_cream.jpg'),
('Chocolate Chip Cookies', 'Fresh baked cookies with milk', 4.50, 3, 'images/cookies.jpg'),
('Fruit Tart', 'Fresh fruit tart with pastry cream', 8.00, 3, 'images/fruit_tart.jpg'),
('Bread Pudding', 'Warm bread pudding with vanilla sauce', 6.00, 3, 'images/bread_pudding.jpg'),
('Chocolate Fondant', 'Rich chocolate fondant with raspberry coulis', 9.00, 3, 'images/chocolate_fondant.jpg'),
('Strawberry Shortcake', 'Layered sponge cake with strawberries and cream', 7.50, 3, 'images/strawberry_shortcake.jpg');

-- Insert Drinks (15 dishes)
INSERT INTO Dishes (Name, Description, Price, CategoryId, ImagePath) VALUES
('Coca-Cola', 'Classic cola soft drink', 3.00, 4, 'images/coca_cola.jpg'),
('Orange Juice', 'Fresh squeezed orange juice', 4.00, 4, 'images/orange_juice.jpg'),
('Lemonade', 'Fresh lemonade with mint', 3.50, 4, 'images/lemonade.jpg'),
('Iced Coffee', 'Cold brew coffee with ice', 4.50, 4, 'images/iced_coffee.jpg'),
('Hot Coffee', 'Freshly brewed coffee', 3.00, 4, 'images/hot_coffee.jpg'),
('Green Tea', 'Japanese green tea', 3.50, 4, 'images/green_tea.jpg'),
('Apple Juice', '100% pure apple juice', 3.50, 4, 'images/apple_juice.jpg'),
('Milkshake', 'Vanilla milkshake with whipped cream', 6.00, 4, 'images/milkshake.jpg'),
('Smoothie', 'Mixed berry smoothie', 5.50, 4, 'images/smoothie.jpg'),
('Mineral Water', 'Sparkling mineral water', 2.50, 4, 'images/mineral_water.jpg'),
('Hot Chocolate', 'Rich hot chocolate with marshmallows', 4.00, 4, 'images/hot_chocolate.jpg'),
('Ginger Ale', 'Refreshing ginger ale', 3.00, 4, 'images/ginger_ale.jpg'),
('Cranberry Juice', 'Pure cranberry juice', 4.00, 4, 'images/cranberry_juice.jpg'),
('Iced Tea', 'Sweet iced tea with lemon', 3.00, 4, 'images/iced_tea.jpg'),
('Root Beer', 'Classic root beer float', 4.50, 4, 'images/root_beer.jpg');

-- Insert Salads (15 dishes)
INSERT INTO Dishes (Name, Description, Price, CategoryId, ImagePath) VALUES
('Caesar Salad', 'Romaine lettuce, parmesan, croutons, caesar dressing', 10.00, 5, 'images/caesar_salad.jpg'),
('Greek Salad', 'Tomatoes, cucumbers, olives, feta, oregano dressing', 11.00, 5, 'images/greek_salad.jpg'),
('Garden Salad', 'Mixed greens, tomatoes, carrots, cucumber, vinaigrette', 8.50, 5, 'images/garden_salad.jpg'),
('Cobb Salad', 'Mixed greens, chicken, bacon, eggs, avocado, blue cheese', 14.00, 5, 'images/cobb_salad.jpg'),
('Chef Salad', 'Mixed greens, ham, turkey, cheese, hard-boiled eggs', 12.00, 5, 'images/chef_salad.jpg'),
('Waldorf Salad', 'Apples, celery, walnuts, grapes in mayonnaise dressing', 9.00, 5, 'images/waldorf_salad.jpg'),
('Caprese Salad', 'Fresh mozzarella, tomatoes, basil, balsamic glaze', 10.50, 5, 'images/caprese_salad.jpg'),
('Spinach Salad', 'Fresh spinach with strawberries, almonds, poppyseed dressing', 11.50, 5, 'images/spinach_salad.jpg'),
('Pasta Salad', 'Rotini pasta with vegetables, Italian dressing', 9.50, 5, 'images/pasta_salad.jpg'),
('Quinoa Salad', 'Quinoa with roasted vegetables, lemon dressing', 12.00, 5, 'images/quinoa_salad.jpg'),
('Asian Slaw', 'Cabbage, carrots, sesame dressing, peanuts', 8.00, 5, 'images/asian_slaw.jpg'),
('Beet Salad', 'Roasted beets, goat cheese, walnuts, balsamic', 11.00, 5, 'images/beet_salad.jpg'),
('Chicken Salad', 'Grilled chicken over mixed greens with ranch dressing', 13.00, 5, 'images/chicken_salad.jpg'),
('Tuna Salad', 'Mixed greens with tuna salad, eggs, olives', 10.50, 5, 'images/tuna_salad.jpg'),
('Fruit Salad', 'Seasonal fresh fruits with honey-lime dressing', 7.00, 5, 'images/fruit_salad.jpg');

-- Initialize stock for all dishes (50 units each)
INSERT INTO Stock (DishId, Quantity, UpdatedBy)
SELECT d.Id, 50, 1 FROM Dishes d
WHERE NOT EXISTS (SELECT 1 FROM Stock s WHERE s.DishId = d.Id);
