SELECT CompanyName, ContactName, Country, Fax FROM dbo.Customers
WHERE Country IN ('Argentina', 'Brazil', 'Canada', 'Mexico', 'USA', 'Venezuela')
AND Fax IS NULL
ORDER BY CompanyName;