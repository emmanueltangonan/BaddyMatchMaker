USE [BaddyMatchMaker]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 23-Jul-21 10:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[matchDuration] [smallint] NULL,
	[ignoreSex] [bit] NULL
) ON [PRIMARY]
GO
