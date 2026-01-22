SELECT ShippedDate, CompanyName
From dbo.Orders
INNER JOIN dbo.Customers
ON Orders.CustomerID = Customers.CustomerID
WHERE MONTH(ShippedDate) BETWEEN 4 AND 6 AND YEAR(ShippedDate) = 1997
ORDER BY OrderDate, CompanyName;