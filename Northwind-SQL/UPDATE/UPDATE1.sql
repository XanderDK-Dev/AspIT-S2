UPDATE dbo.Suppliers
SET Fax = 'no fax number'
WHERE Fax IS NULL;

UPDATE dbo.Customers
SET Fax = 'no fax number'
WHERE Fax IS NULL;