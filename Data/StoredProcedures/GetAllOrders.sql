CREATE PROCEDURE [dbo].[GetAllOrders]
	AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        OrderId,
        ContactNumber,
        CustomerName,
        ServiceType,
        WeightInKg,
        TotalPrice
    FROM LaundryOrders
    ORDER BY OrderId;
END;
GO