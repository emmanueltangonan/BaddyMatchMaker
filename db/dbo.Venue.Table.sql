USE [BaddyMatchMaker]
GO
/****** Object:  Table [dbo].[Venue]    Script Date: 23-Jul-21 10:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venue](
	[venueId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[address] [varchar](max) NULL,
	[numberOfCourts] [tinyint] NOT NULL,
 CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED 
(
	[venueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Venue] ON 

INSERT [dbo].[Venue] ([venueId], [name], [address], [numberOfCourts]) VALUES (1, N'Auckland Badminton Centre', N'99 Gillies Avenue, Epsom, Auckland', 12)
SET IDENTITY_INSERT [dbo].[Venue] OFF
GO
