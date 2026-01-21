SELECT CompanyName, ContactName, ContactTitle, Country FROM dbo.Customers
WHERE (Country = 'France' AND ContactTitle LIKE '%Owner%')
OR (Country = 'UK' AND ContactTitle LIKE '%Sales%')
ORDER BY Country, ContactName;