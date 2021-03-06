USE [BaddyMatchMaker]
GO
/****** Object:  Table [dbo].[SessionPlayer]    Script Date: 23-Jul-21 10:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionPlayer](
	[sessionPlayerId] [int] IDENTITY(1,1) NOT NULL,
	[sessionId] [int] NOT NULL,
	[playerId] [int] NOT NULL,
	[signUpTime] [datetime] NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_SessionPlayer] PRIMARY KEY CLUSTERED 
(
	[sessionPlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SessionPlayer] ON 

INSERT [dbo].[SessionPlayer] ([sessionPlayerId], [sessionId], [playerId], [signUpTime], [active]) VALUES (22, 2, 1, CAST(N'2021-07-22T12:17:26.597' AS DateTime), 1)
INSERT [dbo].[SessionPlayer] ([sessionPlayerId], [sessionId], [playerId], [signUpTime], [active]) VALUES (23, 2, 2, CAST(N'2021-07-22T12:17:31.603' AS DateTime), 1)
INSERT [dbo].[SessionPlayer] ([sessionPlayerId], [sessionId], [playerId], [signUpTime], [active]) VALUES (24, 2, 3, CAST(N'2021-07-22T12:17:36.603' AS DateTime), 1)
INSERT [dbo].[SessionPlayer] ([sessionPlayerId], [sessionId], [playerId], [signUpTime], [active]) VALUES (25, 2, 4, CAST(N'2021-07-22T12:17:41.603' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[SessionPlayer] OFF
GO
ALTER TABLE [dbo].[SessionPlayer]  WITH CHECK ADD  CONSTRAINT [FK_SessionPlayer_Player] FOREIGN KEY([playerId])
REFERENCES [dbo].[Player] ([playerId])
GO
ALTER TABLE [dbo].[SessionPlayer] CHECK CONSTRAINT [FK_SessionPlayer_Player]
GO
ALTER TABLE [dbo].[SessionPlayer]  WITH CHECK ADD  CONSTRAINT [FK_SessionPlayer_Session] FOREIGN KEY([sessionId])
REFERENCES [dbo].[Session] ([sessionId])
GO
ALTER TABLE [dbo].[SessionPlayer] CHECK CONSTRAINT [FK_SessionPlayer_Session]
GO
