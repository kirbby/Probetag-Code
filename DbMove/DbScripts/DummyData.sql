USE [Move]
GO

INSERT INTO [dbo].[Sports]
           ([Name])
     VALUES
           ('Fußball'),
		   ('Tennis'),
		   ('Laufen')
GO

INSERT INTO [dbo].[Movers]
           ([Username]
           ,[Password]
           ,[Firstname]
           ,[Lastname])
     VALUES
           ('test'
           ,'1234'
           ,'Test'
           ,'Mover'
           )
GO