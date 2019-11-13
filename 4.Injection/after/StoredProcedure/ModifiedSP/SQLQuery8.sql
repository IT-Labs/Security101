USE [1-Injection]
GO

/****** Object:  StoredProcedure [dbo].[SearchProducts]    Script Date: 11/13/2019 8:04:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SearchProducts] 
  @SearchTerm VARCHAR(50)
AS
BEGIN
  DECLARE @query NVARCHAR(100)
  SET @query = 'SELECT * FROM dbo.Product WHERE Name LIKE ''%'' + @SearchTerm + ''%'''

  EXEC sp_executesql(@query), N'@SearchTerm varchar(50)', @SearchTerm=@SearchTerm
END
GO



