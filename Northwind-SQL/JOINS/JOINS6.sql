SELECT A.FirstName, A.LastName, B.FirstName AS BossFirstName, B.LastName AS BossLastName, B.EmployeeID
FROM Employees A
INNER JOIN Employees B 
ON A.ReportsTo = B.EmployeeID
ORDER BY BossLastName;