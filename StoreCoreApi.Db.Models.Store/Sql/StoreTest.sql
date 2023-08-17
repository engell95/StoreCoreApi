-- Crear la base de datos
CREATE DATABASE StoreTest;
go
-- Usar la base de datos recién creada
USE StoreTest;

-- Create the "Store" table
CREATE TABLE Store (
    StoreID INT IDENTITY(1,1) PRIMARY KEY,
    StoreName VARCHAR(50)
);

-- Create the "Product" table
CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(50)
);

-- Create the "StoreProductMapping" table
CREATE TABLE StoreProductMapping (
    MappingID INT IDENTITY(1,1) PRIMARY KEY,
    StoreID INT,
    ProductID INT,
    Stock INT,
    FOREIGN KEY (StoreID) REFERENCES Store(StoreID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Create the "ApiLog" table
CREATE TABLE dbo.ApiLog (
    ApiLogID INT IDENTITY(1,1) PRIMARY KEY,
    MachineName VARCHAR(50),
    Logged DATETIME,
    Level VARCHAR(10),
    Message NVARCHAR(MAX),
    Logger VARCHAR(255),
    Callsite NVARCHAR(MAX),
    Exception NVARCHAR(MAX)
);

----------------------
-- Insert data into the "Store" table
INSERT INTO Store (StoreName)
VALUES ('Store A'),
       ('Store B'),
       ('Store C');

-- Insert data into the "Product" table
INSERT INTO Product (ProductName)
VALUES ('Product 1'),
       ('Product 2'),
       ('Product 3');

-- Insert data into the "StoreProductMapping" table
INSERT INTO StoreProductMapping (StoreID, ProductID, Stock)
VALUES (1, 1, 50),
       (1, 2, 100),
       (2, 2, 75),
       (3, 3, 30),
       (3, 1, 20);
