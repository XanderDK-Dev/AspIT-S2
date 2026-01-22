SELECT DISTINCT RegionDescription, TerritoryDescription
FROM dbo.Region
INNER JOIN dbo.Territories
ON  Region.RegionID = Territories.RegionID; 