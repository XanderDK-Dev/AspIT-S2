UPDATE dbo.Customers
SET Region = 'Madrid'
WHERE Country = 'Spain' AND City = 'Madrid';

UPDATE dbo.Customers
SET Region = 'Catalonia'
WHERE Country = 'Spain' AND City = 'Barcelona';

UPDATE dbo.Customers
SET Region = 'Andalusia'
WHERE Country = 'Spain' AND City = 'Sevilla';