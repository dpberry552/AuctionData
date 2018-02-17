USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_Locations]    Script Date: 2/17/2018 9:08:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[StreetAddress] [varchar](255) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[State] [varchar](2) NOT NULL,
	[Zip] [varchar](20) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
	[LastModified] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_Locations] ADD  CONSTRAINT [DF_AA_Locations_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_Locations] ADD  CONSTRAINT [DF_AA_Locations_WhenCreated]  DEFAULT (getdate()) FOR [WhenCreated]
GO

ALTER TABLE [dbo].[AA_Locations] ADD  CONSTRAINT [DF_AA_Locations_LastModified]  DEFAULT (getdate()) FOR [LastModified]
GO

