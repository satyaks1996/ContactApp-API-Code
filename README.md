Beofre runs this API we have to do changes below

1. Please excute this schema on sql server before running this API.

USE [ContactApp]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 11/24/2024 5:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Email]) VALUES (1, N'Alex', N'BlaBla', N'alex.blabla@aol.at')
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Email]) VALUES (2, N'Otto', N'Blubb', N'otto.blubb@dsl.de')
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Email]) VALUES (3, N'Peter', N'Pan', N'peter.pan@neverland.com')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO

2. Change Connectionstring accoring to this, in appsettings.json file

3. Code will work fine

