CREATE TABLE Products (
    ProductID INT IDENTITY PRIMARY KEY,
    Name VARCHAR(100),
    Price DECIMAL(10,2),
    Quantity INT
);

CREATE TABLE Invoices (
    InvoiceID INT IDENTITY PRIMARY KEY,
    DateCreated DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2)
);

CREATE TABLE InvoiceItems (
    InvoiceItemID INT IDENTITY PRIMARY KEY,
    InvoiceID INT FOREIGN KEY REFERENCES Invoices(InvoiceID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT,
    Subtotal DECIMAL(10,2)
);
