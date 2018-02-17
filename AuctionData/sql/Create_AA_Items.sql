USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_Items]    Script Date: 2/17/2018 11:57:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[OnlineBidding] [bit] NOT NULL,
	[MinimumBid] [money] NOT NULL,
	[LotNumber] [varchar](50) NOT NULL,
	[AuctionId] [int] NULL,
	[Rank] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
	[LastModfied] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_Items]  WITH CHECK ADD  CONSTRAINT [FK_AA_Items_AA_Auctions] FOREIGN KEY([AuctionId])
REFERENCES [dbo].[AA_Auctions] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AA_Items] CHECK CONSTRAINT [FK_AA_Items_AA_Auctions]
GO

