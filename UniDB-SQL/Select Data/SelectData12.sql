SELECT Firstname, Lastname, Email, PhoneNumber
FROM Persons, ContactInformations
WHERE persons.ContactInformationID = ContactInformations.ContactInformationID