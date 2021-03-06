USE [BaddyMatchMaker]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 23-Jul-21 10:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[sessionId] [int] IDENTITY(1,1) NOT NULL,
	[clubId] [int] NOT NULL,
	[venueId] [int] NOT NULL,
	[startTime] [datetime] NULL,
	[endTime] [datetime] NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[sessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([sessionId], [clubId], [venueId], [startTime], [endTime]) VALUES (2, 1, 1, CAST(N'2021-07-25T10:00:00.000' AS DateTime), CAST(N'2021-07-25T13:00:00.000' AS DateTime))
INSERT [dbo].[Session] ([sessionId], [clubId], [venueId], [startTime], [endTime]) VALUES (3, 1, 1, CAST(N'2021-07-25T10:00:00.000' AS DateTime), CAST(N'2021-07-25T13:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Session] OFF
GO
