USE [CrudWithStoredProcedure]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[UpdateProduct]
@Id int,
@Name [nvarchar](max),
@Company [nvarchar](max),
@Job [nvarchar](max)
AS
BEGIN
	UPDATE dbo.Customers
	SET
		Name=@Name,
		Company=@Company,
		Job=@Job
	WHERE Id=@Id
END
GO