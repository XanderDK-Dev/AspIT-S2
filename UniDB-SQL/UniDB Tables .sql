CREATE TABLE ContactInformations 
(
    ContactInformationID int NOT NULL PRIMARY KEY IDENTITY(1,1),
    PhoneNumber nvarchar(20) NOT NULL,
    Email nvarchar(100) NOT NULL,
);

CREATE TABLE Addresses
(
    AddressID int NOT NULL PRIMARY KEY IDENTITY(1,1),
    StreetName nvarchar(50) NOT NULL,
    StreetNumber nvarchar(10) NOT NULL,
    Zip nvarchar(10) NOT NULL,
    City nvarchar(50) NOT NULL,
    Country nvarchar(50) NOT NULL,
);

CREATE TABLE Persons
(
    PersonID int NOT NULL PRIMARY KEY IDENTITY(1,1),
    AddressID int,
    CONSTRAINT FK_AddressPerson 
    FOREIGN KEY (AddressID) 
    REFERENCES Addresses(AddressID),
    ContactInformationID int,
    CONSTRAINT FK_ContactInformationPerson 
    FOREIGN KEY (ContactInformationID) 
    REFERENCES ContactInformations(ContactInformationID),
    Firstname nvarchar(50) NOT NULL,
    Lastname nvarchar(50) NOT NULL,
);

