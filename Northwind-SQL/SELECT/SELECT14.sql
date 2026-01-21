SELECT ProductName, UnitsInStock, UnitsOnOrder, Discontinued FROM dbo.Products 
WHERE UnitsInStock = 0 
AND UnitsOnOrder = 0 
AND Discontinued = 0
ORDER BY ProductName DESC;