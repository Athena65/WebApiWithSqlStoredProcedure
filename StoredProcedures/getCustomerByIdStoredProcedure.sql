USE [CrudWithStoredProcedure]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[GetCustomerById]
@CustomerId int
AS
BEGIN
	SELECT
		Id,
		Name,
		Company,
		Job
	FROM dbo.Customers where Id=@CustomerId
END
GO
		
		
		
