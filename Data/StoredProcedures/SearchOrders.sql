CREATE PROCEDURE [dbo].[SearchOrders]
	 @Keyword NVARCHAR(100)
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
    WHERE 
        OrderId LIKE '%' + @Keyword + '%'
        OR CustomerName LIKE '%' + @Keyword + '%'
        OR ContactNumber LIKE '%' + @Keyword + '%'
    ORDER BY OrderId;
END;
GO
