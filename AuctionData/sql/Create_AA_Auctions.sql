USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_Auctions]    Script Date: 1/13/2018 3:40:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_Auctions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[AuctionDateTime] [datetime] NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[LocationId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ValidToDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_Auctions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_Auctions] ADD  CONSTRAINT [DF_AA_Auctions_IsPublic]  DEFAULT ((0)) FOR [IsPublic]
GO

ALTER TABLE [dbo].[AA_Auctions] ADD  CONSTRAINT [DF_AA_Auctions_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_Auctions] ADD  CONSTRAINT [DF_AA_Auctions_ValidToDate]  DEFAULT ('9999-12-31') FOR [ValidToDate]
GO

ALTER TABLE [dbo].[AA_Auctions]  WITH CHECK ADD  CONSTRAINT [FK_AA_Auctions_AA_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[AA_Locations] ([Id])
GO

ALTER TABLE [dbo].[AA_Auctions] CHECK CONSTRAINT [FK_AA_Auctions_AA_Locations]
GO

