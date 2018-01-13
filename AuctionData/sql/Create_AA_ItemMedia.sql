USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_ItemMedia]    Script Date: 1/13/2018 3:40:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_ItemMedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[MediaId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_AA_ItemMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_ItemMedia] ADD  CONSTRAINT [DF_AA_ItemMedia_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_ItemMedia]  WITH CHECK ADD  CONSTRAINT [FK_AA_ItemMedia_AA_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[AA_Items] ([Id])
GO

ALTER TABLE [dbo].[AA_ItemMedia] CHECK CONSTRAINT [FK_AA_ItemMedia_AA_Item]
GO

