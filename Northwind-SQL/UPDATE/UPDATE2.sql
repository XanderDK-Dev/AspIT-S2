UPDATE dbo.Products
SET ReorderLevel = 10
WHERE Discontinued = 0 AND ReorderLevel = 0 AND UnitsInStock < 20;