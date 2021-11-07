USE [CardOrg]
GO

/****** Object:  Table [dbo].[Cards]    Script Date: 10/23/2021 12:54:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cards](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](254) NOT NULL,
	[LastName] [nvarchar](254) NOT NULL,
	[BeginningYear] [int] NOT NULL,
	[EndingYear] [int] NOT NULL,
	[CardBrand] [nvarchar](254) NOT NULL,
	[CardNumber] [nvarchar](254) NOT NULL,
	[LowestBeckettPrice] [decimal] (18, 2) NOT NULL,
	[HighestBeckettPrice] [decimal] (18, 2) NOT NULL,
	[FrontCardMainImagePath] [nvarchar](254) NOT NULL,
	[FrontCardThumbnailImagePath] [nvarchar](254) NOT NULL,
) ON [PRIMARY]
GO


