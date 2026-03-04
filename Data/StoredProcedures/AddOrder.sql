CREATE PROCEDURE [dbo].[AddOrder]
	 @OrderId NVARCHAR(50),
    @ContactNumber NVARCHAR(20),
    @CustomerName NVARCHAR(100),
    @ServiceType NVARCHAR(50),
    @WeightInKg DECIMAL(10,2),
    @TotalPrice DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO LaundryOrders
    (
        OrderId,
        ContactNumber,
        CustomerName,
        ServiceType,
        WeightInKg,
        TotalPrice
    )
    VALUES
    (
        @OrderId,
        @ContactNumber,
        @CustomerName,
        @ServiceType,
        @WeightInKg,
        @TotalPrice
    );
END;
GO