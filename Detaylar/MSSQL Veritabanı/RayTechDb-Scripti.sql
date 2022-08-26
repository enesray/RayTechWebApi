USE [RayTechDb]
GO
/****** Object:  Table [dbo].[users]    Script Date: 26.08.2022 16:42:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[UserID] [int] NOT NULL,
	[UserKey] [uniqueidentifier] NULL,
	[Name] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK__users__1788CCAC7FE46383] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkOrder]    Script Date: 26.08.2022 16:42:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkOrder](
	[WorkOrderCode] [int] NOT NULL,
	[WorkOrderDescription] [nvarchar](300) NOT NULL,
	[Adress] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__WorkOrde__E7DB5FEB2B32C389] PRIMARY KEY CLUSTERED 
(
	[WorkOrderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkOrderActivities]    Script Date: 26.08.2022 16:42:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkOrderActivities](
	[WorkOrderCode] [int] NOT NULL,
	[ActivityCode] [int] NOT NULL,
	[ActivityDescription] [nvarchar](300) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderStatus] [bit] NOT NULL,
 CONSTRAINT [PK_WorkOrderActivities] PRIMARY KEY CLUSTERED 
(
	[WorkOrderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[users] ([UserID], [UserKey], [Name], [Role]) VALUES (1, N'0cd6e78d-628a-4cea-bf84-d28f38b711c5', N'Mustafa', N'A')
GO
INSERT [dbo].[users] ([UserID], [UserKey], [Name], [Role]) VALUES (2, N'018fff17-fb49-4caf-9aa2-49b30c2f0d9d', N'Enes', N'U')
GO
INSERT [dbo].[WorkOrder] ([WorkOrderCode], [WorkOrderDescription], [Adress], [Phone]) VALUES (1, N'Elektirik Faliyetleri', N'5459 / sokak no 5', N'02324856865')
GO
INSERT [dbo].[WorkOrder] ([WorkOrderCode], [WorkOrderDescription], [Adress], [Phone]) VALUES (2, N'Bakım Faliyeti', N'Sevenler 9694 sokak no 5 ', N'0232989583')
GO
INSERT [dbo].[WorkOrder] ([WorkOrderCode], [WorkOrderDescription], [Adress], [Phone]) VALUES (3, N'Bakım Faliyeti', N'Karşıyaka sokak no 5 ', N'05498634534')
GO
INSERT [dbo].[WorkOrderActivities] ([WorkOrderCode], [ActivityCode], [ActivityDescription], [StartDate], [EndDate], [WorkOrderStatus]) VALUES (1, 545434, N'Aktivitelerim örnek', CAST(N'2022-03-15T00:00:00.000' AS DateTime), CAST(N'2022-10-20T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[WorkOrderActivities] ([WorkOrderCode], [ActivityCode], [ActivityDescription], [StartDate], [EndDate], [WorkOrderStatus]) VALUES (2, 545434, N'Aktivitelerim örnek', CAST(N'2022-02-15T00:00:00.000' AS DateTime), CAST(N'2022-04-20T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[WorkOrderActivities] ([WorkOrderCode], [ActivityCode], [ActivityDescription], [StartDate], [EndDate], [WorkOrderStatus]) VALUES (3, 64234, N'Aktivitelerim örnek 3', CAST(N'2022-04-15T00:00:00.000' AS DateTime), CAST(N'2022-12-20T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[WorkOrderActivities] ([WorkOrderCode], [ActivityCode], [ActivityDescription], [StartDate], [EndDate], [WorkOrderStatus]) VALUES (4, 6454543, N'Aktivitelerim örnek', CAST(N'2022-05-15T00:00:00.000' AS DateTime), CAST(N'2022-07-20T00:00:00.000' AS DateTime), 1)
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_UserKey]  DEFAULT (newid()) FOR [UserKey]
GO
