USE [BaddyMatchMaker]
GO
/****** Object:  Table [dbo].[PlayerMatch]    Script Date: 23-Jul-21 10:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerMatch](
	[playerMatchId] [int] IDENTITY(1,1) NOT NULL,
	[matchId] [int] NOT NULL,
	[playerId] [int] NOT NULL,
 CONSTRAINT [PK_PlayerMatch] PRIMARY KEY CLUSTERED 
(
	[playerMatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PlayerMatch]  WITH CHECK ADD  CONSTRAINT [FK_PlayerMatch_Match] FOREIGN KEY([matchId])
REFERENCES [dbo].[Match] ([matchId])
GO
ALTER TABLE [dbo].[PlayerMatch] CHECK CONSTRAINT [FK_PlayerMatch_Match]
GO
ALTER TABLE [dbo].[PlayerMatch]  WITH CHECK ADD  CONSTRAINT [FK_PlayerMatch_Player] FOREIGN KEY([playerId])
REFERENCES [dbo].[Player] ([playerId])
GO
ALTER TABLE [dbo].[PlayerMatch] CHECK CONSTRAINT [FK_PlayerMatch_Player]
GO
