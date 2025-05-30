USE [CarsDatabase]
GO
/****** Object:  Table [dbo].[Automobiles]    Script Date: 5/24/2025 7:20:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Automobiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarName] [nvarchar](max) NULL,
	[Manufacturer] [int] NULL,
 CONSTRAINT [PK_Automobiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Automobiles] ON 

INSERT [dbo].[Automobiles] ([Id], [CarName], [Manufacturer]) VALUES (1, N'Miata', 2)
INSERT [dbo].[Automobiles] ([Id], [CarName], [Manufacturer]) VALUES (2, N'Bronko Sport', 1)
INSERT [dbo].[Automobiles] ([Id], [CarName], [Manufacturer]) VALUES (3, N'Ranger', 1)
INSERT [dbo].[Automobiles] ([Id], [CarName], [Manufacturer]) VALUES (4, N'CX-50', 2)
INSERT [dbo].[Automobiles] ([Id], [CarName], [Manufacturer]) VALUES (5, N'Mustang', 1)
SET IDENTITY_INSERT [dbo].[Automobiles] OFF
GO
USE [master]
GO
ALTER DATABASE [CarsDatabase] SET  READ_WRITE 
GO
