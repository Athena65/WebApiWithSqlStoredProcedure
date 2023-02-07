USE [CrudWithStoredProcedure]
Go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[AddNewCustomer]
@Name [nvarchar](max),
@Company [nvarchar](max),
@Job [nvarchar](max)
AS
BEGIN
 INSERT INTO dbo.Customers
 (
 Name,
 Company,
 Job
 )
 VALUES
 (
 @Name,
 @Company,
 @Job
 )
 END
 GO