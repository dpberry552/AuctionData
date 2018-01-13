USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_AuctionMedia]    Script Date: 1/13/2018 3:39:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_AuctionMedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuctionId] [int] NOT NULL,
	[MediaId] [int] NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_AA_AuctionMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_AuctionMedia] ADD  CONSTRAINT [DF_AA_AuctionMedia_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_AuctionMedia]  WITH CHECK ADD  CONSTRAINT [FK_AA_AuctionMedia_AA_Auction] FOREIGN KEY([AuctionId])
REFERENCES [dbo].[AA_Auctions] ([Id])
GO

ALTER TABLE [dbo].[AA_AuctionMedia] CHECK CONSTRAINT [FK_AA_AuctionMedia_AA_Auction]
GO

