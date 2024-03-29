USE [master]
GO
CREATE DATABASE [PRN231SU22]
GO
USE [PRN231SU22]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 6/23/2022 1:03:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 6/23/2022 1:03:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Year] [int] NULL,
	[GenreID] [int] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 6/23/2022 1:03:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](200) NULL,
	[Gender] [nvarchar](10) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](100) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rates]    Script Date: 6/23/2022 1:03:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rates](
	[MovieID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[Comment] [ntext] NULL,
	[NumericRating] [float] NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_Rates] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC,
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (1, N'Hành động')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (2, N'Tâm lý tình cảm')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (3, N'Kinh dị')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (4, N'Hoạt hình')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (5, N'Khoa học - Nghệ thuật')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID]) VALUES (1, N'Bão ngầm', 2022, 1)
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID]) VALUES (2, N'Mặt nạ gương', 2021, 1)
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID]) VALUES (4, N'Về nhà đi con', 2021, 2)
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID]) VALUES (5, N'Ngõ nhỏ vào đời', 2022, 2)
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID]) VALUES (6, N'Tom và Jerry', 1990, 4)
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID]) VALUES (7, N'Quá nhanh - Quá nguy hiểm', 2018, 1)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password]) VALUES (1, N'Phạm Minh Hùng', N'Nam', N'user1@gmail.com', N'123')
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password]) VALUES (2, N'Phạm Ngọc Minh Châu', N'Nữ', N'user2@gmail.com', N'1234')
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password]) VALUES (3, N'Hoàng Đức Hải', N'Nam', N'user3@gmail.com', N'12345')
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password]) VALUES (4, N'Quách Như Thế', N'Nam', N'user4@gmail.com', N'123456')
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password]) VALUES (5, N'Nguyễn Thùy Dương', N'Nữ', N'user5@gmail.com', N'1234567')
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password]) VALUES (6, N'Trịnh Thị Trang', N'Nữ', N'user6@gmail.com', N'12345678')
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password]) VALUES (7, N'Hoàng Tùng', N'Nam', N'user7@gmail.com', N'123456789')
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password]) VALUES (8, N'string', N'string', N'string', N'string')
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password]) VALUES (9, N'string', N'string', N'string', N'string')
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
INSERT [dbo].[Rates] ([MovieID], [PersonID], [Comment], [NumericRating], [Time]) VALUES (1, 1, N'Phim rất hay', 8.6, CAST(N'2022-10-06T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreID])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres]
GO
ALTER TABLE [dbo].[Rates]  WITH CHECK ADD  CONSTRAINT [FK_Rates_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Rates] CHECK CONSTRAINT [FK_Rates_Movies]
GO
ALTER TABLE [dbo].[Rates]  WITH CHECK ADD  CONSTRAINT [FK_Rates_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Rates] CHECK CONSTRAINT [FK_Rates_Persons]
GO
USE [master]
GO
ALTER DATABASE [PRN231SU22] SET  READ_WRITE 
GO
