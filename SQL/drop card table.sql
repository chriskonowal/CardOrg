USE [CardOrg]
GO

/****** Object:  Table [dbo].[Cards]    Script Date: 10/23/2021 12:56:55 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cards]') AND type in (N'U'))
DROP TABLE [dbo].[Cards]
GO


