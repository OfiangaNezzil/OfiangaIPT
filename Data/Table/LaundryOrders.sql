CREATE TABLE [dbo].[LaundryOrders]
(
    OrderId NVARCHAR(50) PRIMARY KEY,
    ContactNumber NVARCHAR(20) NOT NULL,
    CustomerName NVARCHAR(100) NOT NULL,
    ServiceType NVARCHAR(50) NOT NULL,
    WeightInKg DECIMAL(10,2) NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL
);
