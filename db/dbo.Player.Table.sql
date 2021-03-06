USE [BaddyMatchMaker]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 23-Jul-21 10:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[playerId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[sex] [char](1) NOT NULL,
	[grade] [tinyint] NOT NULL,
	[phone] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[playerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([playerId], [name], [sex], [grade], [phone], [email]) VALUES (1, N'Emmanuel Tangonan', N'M', 3, N'0224635010', N'emmanueltangonan@gmail.com')
INSERT [dbo].[Player] ([playerId], [name], [sex], [grade], [phone], [email]) VALUES (2, N'Laken Mok', N'M', 3, NULL, NULL)
INSERT [dbo].[Player] ([playerId], [name], [sex], [grade], [phone], [email]) VALUES (3, N'Edward Tan', N'M', 4, NULL, NULL)
INSERT [dbo].[Player] ([playerId], [name], [sex], [grade], [phone], [email]) VALUES (4, N'Edwin Chow', N'M', 4, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
