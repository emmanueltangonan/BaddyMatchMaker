USE [BaddyMatchMaker]
GO
/****** Object:  Table [dbo].[Round]    Script Date: 23-Jul-21 10:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Round](
	[roundId] [int] IDENTITY(1,1) NOT NULL,
	[sessionId] [int] NOT NULL,
	[startTime] [datetime] NOT NULL,
	[endTime] [datetime] NOT NULL,
	[courtsAvailable] [tinyint] NOT NULL,
 CONSTRAINT [PK_Round] PRIMARY KEY CLUSTERED 
(
	[roundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Round]  WITH CHECK ADD  CONSTRAINT [FK_Round_Session] FOREIGN KEY([sessionId])
REFERENCES [dbo].[Session] ([sessionId])
GO
ALTER TABLE [dbo].[Round] CHECK CONSTRAINT [FK_Round_Session]
GO
