CREATE DATABASE [Banking]
GO

USE [Banking]
GO

CREATE TABLE [dbo].[Account](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Initial_balance] [decimal](18, 2) NOT NULL,
	[Date_creation] [datetime]  Not Null CONSTRAINT Account_Date DEFAULT getdate(),
 )
go

CREATE TABLE [dbo].[Operation](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Date_insertion] [datetime] Not Null CONSTRAINT Operation_Date DEFAULT getdate(),
	[Account_id] [int] NOT NULL,
 CONSTRAINT [FK_Operation_Account] FOREIGN KEY([account_id]) REFERENCES [dbo].[Account] ([Id])
 )
 go

 INSERT INTO [dbo].[Account] ([Name],[Initial_balance]) VALUES ('Banque 1',50)
GO
INSERT INTO [dbo].[Account] ([Name],[Initial_balance]) VALUES ('Banque 2',250)
GO
INSERT INTO [dbo].[Account] ([Name],[Initial_balance]) VALUES ('Banque 5',300.50)
GO
INSERT INTO [dbo].[Account] ([Name],[Initial_balance]) VALUES ('Banque 4',450)
GO



INSERT INTO [dbo].[Operation] ([amount],[account_id]) VALUES (234.56,1)
GO

INSERT INTO [dbo].[Operation] ([amount],[account_id]) VALUES (-123.45,1)
GO

INSERT INTO [dbo].[Operation] ([amount],[account_id]) VALUES (23.45,3)
GO

INSERT INTO [dbo].[Operation] ([amount],[account_id]) VALUES (12.4012,3)
GO







