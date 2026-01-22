SELECT DISTINCT CompanyName
FROM dbo.Suppliers
INNER JOIN dbo.Products
ON Suppliers.SupplierID = Products.SupplierID
WHERE CategoryID = 1
ORDER BY CompanyName