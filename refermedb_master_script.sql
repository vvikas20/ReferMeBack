USE [ReferMeDB]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 4/23/2020 8:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 4/23/2020 8:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LocationID] [int] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 4/23/2020 8:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PostID] [int] NOT NULL,
	[Company] [varchar](200) NOT NULL,
	[Position] [nvarchar](100) NOT NULL,
	[MinExp] [int] NOT NULL,
	[MaxExp] [int] NOT NULL,
	[Location] [nvarchar](200) NULL,
	[Description] [text] NULL,
	[Keywords] [nvarchar](200) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[Active] [bit] NOT NULL,
	[PostedBy] [int] NOT NULL,
	[PostedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_JobPost] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Referral]    Script Date: 4/23/2020 8:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Referral](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ReferralID] [int] NOT NULL,
	[PostID] [int] NOT NULL,
	[Subject] [text] NULL,
	[Message] [text] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Referral] PRIMARY KEY CLUSTERED 
(
	[ReferralID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/23/2020 8:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleDisplayName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/23/2020 8:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](20) NULL,
	[PasswordHash] [nvarchar](50) NOT NULL,
	[PasswordSalt] [nvarchar](50) NOT NULL,
	[ProfileImagePath] [nvarchar](250) NULL,
	[ResumePath] [nvarchar](250) NULL,
	[CreatedOnDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[Verified] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleMapping]    Script Date: 4/23/2020 8:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleMapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserRoleMappingID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserRoleMapping] PRIMARY KEY CLUSTERED 
(
	[UserRoleMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (1, 1, N'Tata Consultancy Services', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (2, 2, N'Wipro Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (3, 3, N'Infosys Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (4, 4, N'HCL Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (5, 5, N'Mahindra IT Services', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (6, 6, N'MindTree Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (7, 7, N'Infotech Enterprise Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (8, 8, N'Hexaware Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (9, 9, N'NIIT Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (10, 10, N'3i Infotech', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (11, 11, N'MyBox Technologies Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (12, 12, N'Accel Frontline Limited', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (13, 13, N'I Matrix Tech', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (14, 14, N'Accenture India', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (15, 15, N'Adrenalin Systems', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (16, 16, N'Aftek', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (17, 17, N'American Megatrends', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (18, 18, N'Capgemini', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (19, 19, N'Accenture India', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (20, 20, N'CGI', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (21, 21, N'Cognizant Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (22, 22, N'Dhruv Software', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (23, 23, N'Seasia Infotech Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (24, 24, N'Tech Mahindra Satyam', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (25, 25, N'Amazon', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (26, 26, N'ADP', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (27, 27, N'Citrix Systems', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (28, 28, N'Microsoft Corporation', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (29, 29, N'CMC Limited', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (30, 30, N'Intergraph Corporation', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (31, 31, N'NTT Data', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (32, 32, N'iGate', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (33, 33, N'Fortune Industries Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (34, 34, N'Adit Microsys Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (35, 35, N'GNFC', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (36, 36, N'Virmati Software & Telecommunications', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (37, 37, N'Accel Frontline Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (38, 38, N'Birla Soft', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (39, 39, N'Computer Sciences Corporations', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (40, 40, N'Netescape Technologies Pvt Ltd Acer India', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (41, 41, N'IBM', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (42, 42, N'APTECH', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (43, 43, N'AECOM India Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (44, 44, N'Honey Well Software', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (45, 45, N'Oracle', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (46, 46, N'Adobe Systems', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (47, 47, N'Mphasis', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (48, 48, N'Khyati Infotech', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (49, 49, N'Dynamic Dreamz Web Solutions', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (50, 50, N'Western Deal', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (51, 51, N'Amdocs', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (52, 52, N'Avaya Inc', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (53, 53, N'Atos', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (54, 54, N'BMC Software', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (55, 55, N'Cybage', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (56, 56, N'Sonata Software', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (57, 57, N'4C Plus Solutions Limited', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (58, 58, N'7G Infosystems', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (59, 59, N'Smriti Techno Logics', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (60, 60, N'Yoctel Solutions Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (61, 61, N'Green Web Software Development Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (62, 62, N'Silvery Infotech', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (63, 63, N'Verma Infocomm Private Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (64, 64, N'RKV IT Solutions', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (65, 65, N'Horizon Soft Tech', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (66, 66, N'Sanviya Tech', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (67, 67, N'Amadeus', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (68, 68, N'Bebo Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (69, 69, N'FCS Software Solutions Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (70, 70, N'Floresco Technologies Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (71, 71, N'3E IT Solutions', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (72, 72, N'Phitany Business Solutions', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (73, 73, N'Robert Bosch', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (74, 74, N'Nile Software Solutions', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (75, 75, N'iCore Software Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (76, 76, N'AabSys Information Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (77, 77, N'Allay Software Solutions', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (78, 78, N'AgreeYa Solutions Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (79, 79, N'All e-Technologies Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (80, 80, N'Artech Infosystems Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (81, 81, N'Daffodil', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (82, 82, N'OTS Solutions', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (83, 83, N'InterGlobe Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (84, 84, N'Web by Logic Solutions', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (85, 85, N'GPRO Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (86, 86, N'Prapthi Technology Services', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (87, 87, N'Radix Soft Solutions Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (88, 88, N'Medma Infomatix Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (89, 89, N'Accel Frontline Limited', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (90, 90, N'SRS Info Connect', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (91, 91, N'Maurya Software Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (92, 92, N'Smart Way Solutions Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (93, 93, N'01 Synergy', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (94, 94, N'Unikaihatsu Software', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (95, 95, N'ExcelSoft Technologies Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (96, 96, N'ADD Technologies Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (97, 97, N'Numeric Infosystems Pvt Ltd', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (98, 98, N'Nikunj Technologies', 1)
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (99, 99, N'Cogzidel Consultancy Services Pvt Ltd', 1)
GO
INSERT [dbo].[Company] ([id], [CompanyID], [CompanyName], [Active]) VALUES (100, 100, N'DOT COM Infoway Ltd', 1)
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (1, 1, N'Mumbai', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (2, 2, N'Delhi', N'Delhi', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (3, 3, N'Bangalore', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (4, 4, N'Hyderabad', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (5, 5, N'Ahmedabad', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (6, 6, N'Chennai', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (7, 7, N'Kolkata', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (8, 8, N'Surat', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (9, 9, N'Pune', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (10, 10, N'Jaipur', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (11, 11, N'Lucknow', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (12, 12, N'Kanpur', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (13, 13, N'Nagpur', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (14, 14, N'Indore', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (15, 15, N'Thane', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (16, 16, N'Bhopal', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (17, 17, N'Visakhapatnam', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (18, 18, N'Pimpri-Chinchwad', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (19, 19, N'Patna', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (20, 20, N'Vadodara', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (21, 21, N'Ghaziabad', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (22, 22, N'Ludhiana', N'Punjab', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (23, 23, N'Agra', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (24, 24, N'Nashik', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (25, 25, N'Faridabad', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (26, 26, N'Meerut', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (27, 27, N'Rajkot', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (28, 28, N'Kalyan-Dombivli', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (29, 29, N'Vasai-Virar', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (30, 30, N'Varanasi', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (31, 31, N'Srinagar', N'Jammu and Kashmir', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (32, 32, N'Aurangabad', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (33, 33, N'Dhanbad', N'Jharkhand', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (34, 34, N'Amritsar', N'Punjab', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (35, 35, N'Navi Mumbai', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (36, 36, N'Allahabad', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (37, 37, N'Howrah', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (38, 38, N'Ranchi', N'Jharkhand', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (39, 39, N'Gwalior', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (40, 40, N'Jabalpur', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (41, 41, N'Coimbatore', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (42, 42, N'Vijayawada', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (43, 43, N'Jodhpur', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (44, 44, N'Madurai', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (45, 45, N'Raipur', N'Chhattisgarh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (46, 46, N'Kota[6]', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (47, 47, N'Chandigarh', N'Chandigarh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (48, 48, N'Guwahati', N'Assam', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (49, 49, N'Solapur', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (50, 50, N'Hubli–Dharwad', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (51, 51, N'Tiruchirappalli', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (52, 52, N'Bareilly', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (53, 53, N'Mysore', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (54, 54, N'Tiruppur', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (55, 55, N'Gurgaon', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (56, 56, N'Aligarh', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (57, 57, N'Jalandhar', N'Punjab', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (58, 58, N'Bhubaneswar', N'Odisha', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (59, 59, N'Salem', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (60, 60, N'Mira-Bhayandar', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (61, 61, N'Warangal', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (62, 62, N'Jalgaon', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (63, 63, N'Guntur', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (64, 64, N'Bhiwandi', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (65, 65, N'Saharanpur', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (66, 66, N'Gorakhpur', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (67, 67, N'Bikaner', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (68, 68, N'Amravati', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (69, 69, N'Noida', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (70, 70, N'Jamshedpur', N'Jharkhand', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (71, 71, N'Bhilai', N'Chhattisgarh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (72, 72, N'Cuttack', N'Odisha', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (73, 73, N'Firozabad', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (74, 74, N'Kochi', N'Kerala', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (75, 75, N'Nellore', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (76, 76, N'Bhavnagar', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (77, 77, N'Dehradun', N'Uttarakhand', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (78, 78, N'Durgapur', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (79, 79, N'Asansol', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (80, 80, N'Rourkela', N'Odisha', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (81, 81, N'Nanded', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (82, 82, N'Kolhapur', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (83, 83, N'Ajmer', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (84, 84, N'Akola', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (85, 85, N'Gulbarga', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (86, 86, N'Jamnagar', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (87, 87, N'Ujjain', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (88, 88, N'Loni', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (89, 89, N'Jhansi', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (90, 90, N'Ulhasnagar', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (91, 91, N'Jammu', N'Jammu and Kashmir', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (92, 92, N'Sangli-Miraj & Kupwad', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (93, 93, N'Mangalore', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (94, 94, N'Erode', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (95, 95, N'Belgaum', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (96, 96, N'Ambattur', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (97, 97, N'Tirunelveli', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (98, 98, N'Malegaon', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (99, 99, N'Gaya', N'Bihar', 1)
GO
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (100, 100, N'Thiruvananthapuram', N'Kerala', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (101, 101, N'Udaipur', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (102, 102, N'Maheshtala', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (103, 103, N'Davanagere', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (104, 104, N'Kozhikode', N'Kerala', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (105, 105, N'Kurnool', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (106, 106, N'Rajpur Sonarpur', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (107, 107, N'Rajahmundry', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (108, 108, N'Bokaro', N'Jharkhand', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (109, 109, N'South Dumdum', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (110, 110, N'Bellary', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (111, 111, N'Patiala', N'Punjab', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (112, 112, N'Gopalpur', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (113, 113, N'Agartala', N'Tripura', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (114, 114, N'Bhagalpur', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (115, 115, N'Muzaffarnagar', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (116, 116, N'Bhatpara', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (117, 117, N'Panihati', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (118, 118, N'Latur', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (119, 119, N'Dhule', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (120, 120, N'Tirupati', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (121, 121, N'Rohtak', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (122, 122, N'Korba', N'Chhattisgarh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (123, 123, N'Bhilwara', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (124, 124, N'Berhampur', N'Odisha', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (125, 125, N'Muzaffarpur', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (126, 126, N'Ahmednagar', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (127, 127, N'Mathura', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (128, 128, N'Kollam', N'Kerala', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (129, 129, N'Avadi', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (130, 130, N'Kadapa', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (131, 131, N'Kamarhati', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (132, 132, N'Sambalpur', N'Odisha', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (133, 133, N'Bilaspur', N'Chhattisgarh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (134, 134, N'Shahjahanpur', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (135, 135, N'Satara', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (136, 136, N'Bijapur', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (137, 137, N'Kakinada', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (138, 138, N'Rampur', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (139, 139, N'Shimoga', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (140, 140, N'Chandrapur', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (141, 141, N'Junagadh', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (142, 142, N'Thrissur', N'Kerala', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (143, 143, N'Alwar', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (144, 144, N'Bardhaman', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (145, 145, N'Kulti', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (146, 146, N'Nizamabad', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (147, 147, N'Parbhani', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (148, 148, N'Tumkur', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (149, 149, N'Khammam', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (150, 150, N'Ozhukarai', N'Puducherry', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (151, 151, N'Bihar Sharif', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (152, 152, N'Panipat', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (153, 153, N'Darbhanga', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (154, 154, N'Bally', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (155, 155, N'Aizawl', N'Mizoram', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (156, 156, N'Dewas', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (157, 157, N'Ichalkaranji', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (158, 158, N'Karnal', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (159, 159, N'Bathinda', N'Punjab', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (160, 160, N'Jalna', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (161, 161, N'Eluru', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (162, 162, N'Barasat', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (163, 163, N'Kirari Suleman Nagar', N'Delhi', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (164, 164, N'Purnia', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (165, 165, N'Satna', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (166, 166, N'Mau', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (167, 167, N'Sonipat', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (168, 168, N'Farrukhabad', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (169, 169, N'Sagar', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (170, 170, N'Durg', N'Chhattisgarh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (171, 171, N'Imphal', N'Manipur', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (172, 172, N'Ratlam', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (173, 173, N'Hapur', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (174, 174, N'Arrah', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (175, 175, N'Anantapur', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (176, 176, N'Karimnagar', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (177, 177, N'Etawah', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (178, 178, N'Ambarnath', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (179, 179, N'North Dumdum', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (180, 180, N'Bharatpur', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (181, 181, N'Begusarai', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (182, 182, N'New Delhi', N'Delhi', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (183, 183, N'Gandhidham', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (184, 184, N'Baranagar', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (185, 185, N'Tiruvottiyur', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (186, 186, N'Pondicherry', N'Puducherry', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (187, 187, N'Sikar', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (188, 188, N'Thoothukudi', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (189, 189, N'Rewa', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (190, 190, N'Mirzapur', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (191, 191, N'Raichur', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (192, 192, N'Pali', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (193, 193, N'Ramagundam', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (194, 194, N'Haridwar', N'Uttarakhand', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (195, 195, N'Vijayanagaram', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (196, 196, N'Katihar', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (197, 197, N'Nagercoil', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (198, 198, N'Sri Ganganagar', N'Rajasthan', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (199, 199, N'Karawal Nagar', N'Delhi', 1)
GO
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (200, 200, N'Mango', N'Jharkhand', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (201, 201, N'Thanjavur', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (202, 202, N'Bulandshahr', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (203, 203, N'Uluberia', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (204, 204, N'Katni', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (205, 205, N'Sambhal', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (206, 206, N'Singrauli', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (207, 207, N'Nadiad', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (208, 208, N'Secunderabad', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (209, 209, N'Naihati', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (210, 210, N'Yamunanagar', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (211, 211, N'Bidhannagar', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (212, 212, N'Pallavaram', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (213, 213, N'Bidar', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (214, 214, N'Munger', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (215, 215, N'Panchkula', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (216, 216, N'Burhanpur', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (217, 217, N'Raurkela Industrial Township', N'Odisha', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (218, 218, N'Kharagpur', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (219, 219, N'Dindigul', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (220, 220, N'Gandhinagar', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (221, 221, N'Hospet', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (222, 222, N'Nangloi Jat', N'Delhi', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (223, 223, N'Malda', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (224, 224, N'Ongole', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (225, 225, N'Deoghar', N'Jharkhand', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (226, 226, N'Chapra', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (227, 227, N'Haldia', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (228, 228, N'Khandwa', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (229, 229, N'Nandyal', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (230, 230, N'Morena', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (231, 231, N'Amroha', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (232, 232, N'Anand', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (233, 233, N'Bhind', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (234, 234, N'Bhalswa Jahangir Pur', N'Delhi', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (235, 235, N'Madhyamgram', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (236, 236, N'Bhiwani', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (237, 237, N'Berhampore', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (238, 238, N'Ambala', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (239, 239, N'Morbi', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (240, 240, N'Fatehpur', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (241, 241, N'Raebareli', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (242, 242, N'Mahaboobnagar', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (243, 243, N'Chittoor', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (244, 244, N'Bhusawal', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (245, 245, N'Orai', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (246, 246, N'Bahraich', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (247, 247, N'Vellore', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (248, 248, N'Mehsana', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (249, 249, N'Raiganj', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (250, 250, N'Sirsa', N'Haryana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (251, 251, N'Danapur', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (252, 252, N'Serampore', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (253, 253, N'Sultan Pur Majra', N'Delhi', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (254, 254, N'Guna', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (255, 255, N'Jaunpur', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (256, 256, N'Panvel', N'Maharashtra', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (257, 257, N'Shivpuri', N'Madhya Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (258, 258, N'Surendranagar Dudhrej', N'Gujarat', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (259, 259, N'Unnao', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (260, 260, N'Chinsurah', N'West Bengal', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (261, 261, N'Alappuzha', N'Kerala', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (262, 262, N'Kottayam', N'Kerala', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (263, 263, N'Machilipatnam', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (264, 264, N'Shimla', N'Himachal Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (265, 265, N'Adoni', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (266, 266, N'Udupi', N'Karnataka', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (267, 267, N'Tenali', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (268, 268, N'Proddatur', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (269, 269, N'Saharsa', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (270, 270, N'Hindupur', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (271, 271, N'Sasaram', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (272, 272, N'Hajipur', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (273, 273, N'Bhimavaram', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (274, 274, N'Kumbakonam', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (275, 275, N'Dehri', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (276, 276, N'Madanapalle', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (277, 277, N'Siwan', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (278, 278, N'Bettiah', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (279, 279, N'Guntakal', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (280, 280, N'Srikakulam', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (281, 281, N'Motihari', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (282, 282, N'Dharmavaram', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (283, 283, N'Gudivada', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (284, 284, N'Phagwara', N'Punjab', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (285, 285, N'Narasaraopet', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (286, 286, N'Suryapet', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (287, 287, N'Miryalaguda', N'Telangana', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (288, 288, N'Tadipatri', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (289, 289, N'Karaikudi', N'Tamil Nadu', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (290, 290, N'Kishanganj', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (291, 291, N'Jamalpur', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (292, 292, N'Ballia', N'Uttar Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (293, 293, N'Kavali', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (294, 294, N'Tadepalligudem', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (295, 295, N'Amaravati', N'Andhra Pradesh', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (296, 296, N'Buxar', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (297, 297, N'Jehanabad', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (298, 298, N'Aurangabad', N'Bihar', 1)
INSERT [dbo].[Location] ([id], [LocationID], [City], [State], [Active]) VALUES (299, 299, N'Gangtok', N'Sikkim', 1)
GO
SET IDENTITY_INSERT [dbo].[Location] OFF
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([id], [PostID], [Company], [Position], [MinExp], [MaxExp], [Location], [Description], [Keywords], [ContactNumber], [Active], [PostedBy], [PostedOn]) VALUES (12, 2, N'Capgemini', N'module lead', 1, 2, N'Pune', N'<p> fdasgfdgasfdhgasfdgh</p>', NULL, N'', 0, 1, CAST(N'2019-11-06T02:00:17.193' AS DateTime))
INSERT [dbo].[Post] ([id], [PostID], [Company], [Position], [MinExp], [MaxExp], [Location], [Description], [Keywords], [ContactNumber], [Active], [PostedBy], [PostedOn]) VALUES (13, 3, N'MindTree Ltd', N'Senior Software Engineer', 4, 8, N'Noida', N'<p>TEST HERE</p>', N'java', N'', 0, 1, CAST(N'2020-01-21T23:23:39.430' AS DateTime))
SET IDENTITY_INSERT [dbo].[Post] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [RoleID], [RoleName], [RoleDisplayName]) VALUES (1, 1, N'USER', N'User')
INSERT [dbo].[Role] ([id], [RoleID], [RoleName], [RoleDisplayName]) VALUES (2, 2, N'MODERATOR', N'Moderator')
INSERT [dbo].[Role] ([id], [RoleID], [RoleName], [RoleDisplayName]) VALUES (3, 9, N'ADMIN', N'System Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [UserID], [FirstName], [MiddleName], [LastName], [EmailAddress], [Mobile], [PasswordHash], [PasswordSalt], [ProfileImagePath], [ResumePath], [CreatedOnDate], [ModifiedDate], [Verified], [Active]) VALUES (8, 1, N'Vikas', N'', N'Singh', N'vsvikassingh49@gmail.com', N'', N'B8E0716BAABDBCA138164204B1D6C6BA00160FD52ajF5O8=', N'2ajF5O8=', NULL, NULL, CAST(N'2019-11-03T18:56:51.220' AS DateTime), CAST(N'2019-11-03T18:56:51.220' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserRoleMapping] ON 

INSERT [dbo].[UserRoleMapping] ([id], [UserRoleMappingID], [UserID], [RoleID]) VALUES (1, 1, 1, 9)
SET IDENTITY_INSERT [dbo].[UserRoleMapping] OFF
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF_Company_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Verified]  DEFAULT ((1)) FOR [Verified]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([PostedBy])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[Referral]  WITH CHECK ADD  CONSTRAINT [FK_Referral_Post] FOREIGN KEY([PostID])
REFERENCES [dbo].[Post] ([PostID])
GO
ALTER TABLE [dbo].[Referral] CHECK CONSTRAINT [FK_Referral_Post]
GO
ALTER TABLE [dbo].[Referral]  WITH CHECK ADD  CONSTRAINT [FK_Referral_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Referral] CHECK CONSTRAINT [FK_Referral_User]
GO
ALTER TABLE [dbo].[UserRoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleMapping_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[UserRoleMapping] CHECK CONSTRAINT [FK_UserRoleMapping_Role]
GO
ALTER TABLE [dbo].[UserRoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleMapping_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserRoleMapping] CHECK CONSTRAINT [FK_UserRoleMapping_User]
GO
