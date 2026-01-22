SELECT DISTINCT ProductName, UnitPrice, UnitsInStock
FROM dbo.Categories
INNER JOIN dbo.Products
ON  Categories.CategoryID = Products.CategoryID
WHERE Discontinued = 0 AND Products.CategoryID = 1
ORDER BY UnitsInStock, ProductName;