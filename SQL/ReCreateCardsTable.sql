USE [CardOrg]
GO

ALTER TABLE [dbo].[Cards] DROP CONSTRAINT [FK__Cards__SportId__1AD3FDA4]
GO

/****** Object:  Table [dbo].[Cards]    Script Date: 10/31/2021 2:02:29 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cards]') AND type in (N'U'))
DROP TABLE [dbo].[Cards]
GO

/****** Object:  Table [dbo].[Cards]    Script Date: 10/31/2021 2:02:29 PM ******/
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
	[LowestBeckettPrice] [decimal](18, 2) NOT NULL,
	[HighestBeckettPrice] [decimal](18, 2) NOT NULL,
	[FrontCardMainImagePath] [nvarchar](254) NOT NULL,
	[FrontCardThumbnailImagePath] [nvarchar](254) NOT NULL,
	[BackCardMainImagePath] [nvarchar](254) NOT NULL,
	[BackCardThumbnailImagePath] [nvarchar](254) NOT NULL,
	[LowestCOMCPrice] [decimal](18, 2) NOT NULL,
	[EbayPrice] [decimal](18, 2) NOT NULL,
	[PricePaid] [decimal](18, 2) NOT NULL,
	[IsGraded] [bit] NOT NULL,
	[Location] [nvarchar](254) NOT NULL,
	[Copies] [int] NOT NULL,
	[SerialNumber] [int] NOT NULL,
	[GradeCompany] [nvarchar](254) NOT NULL,
	[Grade] [decimal](18, 1) NOT NULL,
	[IsRookie] [bit] NOT NULL,
	[IsAuto] [bit] NOT NULL,
	[IsPatch] [bit] NOT NULL,
	[IsOnCardAuto] [bit] NOT NULL,
	[IsGameWornJersey] [bit] NOT NULL,
	[SportId] [int] FOREIGN KEY REFERENCES Sports([SportId])
,
PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cards]  WITH CHECK ADD FOREIGN KEY([SportId])
REFERENCES [dbo].[Sports] ([SportId])
GO


