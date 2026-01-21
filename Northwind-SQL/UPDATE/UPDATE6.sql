UPDATE dbo.Employees
SET 
    Address = (SELECT Address FROM dbo.Employees WHERE FirstName = 'Andrew'),
    City = (SELECT City FROM dbo.Employees WHERE FirstName = 'Andrew'),
    Region = (SELECT Region FROM dbo.Employees WHERE FirstName = 'Andrew'),
    PostalCode = (SELECT PostalCode FROM dbo.Employees WHERE FirstName = 'Andrew'),
    Country = (SELECT Country FROM dbo.Employees WHERE FirstName = 'Andrew')
WHERE FirstName = 'Janet';