CREATE PROCEDURE [dbo].[UpdateOrder]
	@OrderId NVARCHAR(50),
    @ContactNumber NVARCHAR(20),
    @CustomerName NVARCHAR(100),
    @ServiceType NVARCHAR(50),
    @WeightInKg DECIMAL(10,2),
    @TotalPrice DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE LaundryOrders
    SET
        ContactNumber = @ContactNumber,
        CustomerName = @CustomerName,
        ServiceType = @ServiceType,
        WeightInKg = @WeightInKg,
        TotalPrice = @TotalPrice
    WHERE OrderId = @OrderId;
END;
GO
