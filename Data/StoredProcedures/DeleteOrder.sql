CREATE PROCEDURE [dbo].[DeleteOrder]
	@OrderId NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM LaundryOrders
    WHERE OrderId = @OrderId;
END;
GO
