SELECT OrderDate, CompanyName
From dbo.Orders
INNER JOIN dbo.Customers
ON Orders.CustomerID = Customers.CustomerID
WHERE MONTH(OrderDate) = 2 AND YEAR(OrderDate) = 1997
ORDER BY OrderDate, CompanyName;