SELECT Firstname, Lastname, Email, PhoneNumber, StreetName, StreetNumber, Zip, City
FROM Persons, ContactInformations, Addresses
WHERE persons.ContactInformationID = ContactInformations.ContactInformationID AND Persons.AddressID = Addresses.AddressID;