CREATE DATABASE jackie_Project0DB;
CREATE table Customer(CustomerId int,CustomerFirstName VARCHAR(50),CustomerLastName VARCHAR(50));

ALTER TABLE Customer
ALTER COLUMN CustomerId INT NOT NULL;

ALTER TABLE Customer
ADD CONSTRAINT PK_Customer PRIMARY KEY(CustomerId);

ALTER TABLE Customer
Alter Column C_Address1 varchar(50) NOT NULL;

ALTER TABLE Customer
ALTER COLUMN C_Address1 varchar(50) NOT NULL;


UPDATE Customer
SET C_Address1 = 'Glastonbury'
WHERE CustomerID = 11012;
UPDATE Customer
SET C_Address2 = 'CT'
WHERE CustomerID = 11012;
UPDATE Customer
SET C_Address1 = 'Hartford'
WHERE CustomerID = 11013;
UPDATE Customer
SET C_Address2 = 'CT'
WHERE CustomerID = 11013;
UPDATE Customer
SET C_Address1 = 'Ashburn'
WHERE CustomerID = 11014;

    
SELECT * from Customer;

CREATE TABLE Store (
    StoreId int NOT NULL,
    StoreName varchar(50) NOT NULL,
    S_Address varchar(50),
	ZipCode int,
    PRIMARY KEY (StoreId));
   
CREATE table Product(
ProductID int NOT null,
ProductName varchar(50) not null,
StoreId int, 
ProductPrice int not null
PRIMARY KEY (ProductID),
FOREIGN KEY (StoreId) REFERENCES Store(StoreId)
);


CREATE TABLE Orders (
    OrderID int NOT NULL,
	CustomerId int NOT NULL,
    ProductID int NOT NULL,
	Quantity int Not Null,
    PRIMARY KEY (OrderID),
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
	FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);






