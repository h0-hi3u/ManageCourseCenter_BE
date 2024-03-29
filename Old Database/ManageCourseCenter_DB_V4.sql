USE [master]
GO
/****** Object:  Database [ManageCourseCenter]    Script Date: 2/26/2024 7:25:57 PM ******/
CREATE DATABASE [ManageCourseCenter]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OCEMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.HOTRONGHIEU\MSSQL\DATA\OCEMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OCEMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.HOTRONGHIEU\MSSQL\DATA\OCEMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ManageCourseCenter] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ManageCourseCenter].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ManageCourseCenter] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET ARITHABORT OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ManageCourseCenter] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ManageCourseCenter] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ManageCourseCenter] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ManageCourseCenter] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET RECOVERY FULL 
GO
ALTER DATABASE [ManageCourseCenter] SET  MULTI_USER 
GO
ALTER DATABASE [ManageCourseCenter] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ManageCourseCenter] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ManageCourseCenter] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ManageCourseCenter] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ManageCourseCenter] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ManageCourseCenter] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ManageCourseCenter', N'ON'
GO
ALTER DATABASE [ManageCourseCenter] SET QUERY_STORE = OFF
GO
USE [ManageCourseCenter]
GO
/****** Object:  Table [dbo].[AcademicTranscript]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicTranscript](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[children_id] [int] NOT NULL,
	[quiz_1] [decimal](3, 1) NOT NULL,
	[quiz_2] [decimal](3, 1) NOT NULL,
	[midtern] [decimal](3, 1) NOT NULL,
	[final] [decimal](3, 1) NOT NULL,
	[average] [decimal](3, 1) NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItem]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cart_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[children_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[course_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassTime]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassTime](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[class_id] [int] NOT NULL,
	[day_in_week] [varchar](9) NOT NULL,
	[star_time] [time](7) NOT NULL,
	[end_time] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](max) NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[open_form_time] [datetime] NOT NULL,
	[close_form_time] [datetime] NOT NULL,
	[price] [float] NULL,
	[level] [int] NOT NULL,
	[total_slot] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Children]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Children](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmenntActivity]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmenntActivity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[manager_id] [int] NOT NULL,
	[equipment_id] [int] NOT NULL,
	[room_id] [int] NOT NULL,
	[operate_time] [datetime] NOT NULL,
	[description] [nvarchar](max) NULL,
	[action] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](max) NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentReport]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentReport](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[room_id] [int] NOT NULL,
	[equipment_id] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[children_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[course_rating] [int] NOT NULL,
	[teacher_rating] [int] NOT NULL,
	[equipment_rating] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](128) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](128) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cart_id] [int] NOT NULL,
	[method] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[floor] [int] NOT NULL,
	[room_no] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_id] [int] NOT NULL,
	[children_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[room_id] [int] NOT NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NOT NULL,
	[attendance] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2/26/2024 7:25:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](128) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AcademicTranscript] ON 

INSERT [dbo].[AcademicTranscript] ([id], [teacher_id], [course_id], [children_id], [quiz_1], [quiz_2], [midtern], [final], [average], [status]) VALUES (1, 1, 1, 1, CAST(8.5 AS Decimal(3, 1)), CAST(7.8 AS Decimal(3, 1)), CAST(9.2 AS Decimal(3, 1)), CAST(8.7 AS Decimal(3, 1)), CAST(8.3 AS Decimal(3, 1)), 1)
INSERT [dbo].[AcademicTranscript] ([id], [teacher_id], [course_id], [children_id], [quiz_1], [quiz_2], [midtern], [final], [average], [status]) VALUES (2, 1, 1, 2, CAST(7.9 AS Decimal(3, 1)), CAST(8.2 AS Decimal(3, 1)), CAST(9.0 AS Decimal(3, 1)), CAST(8.5 AS Decimal(3, 1)), CAST(8.4 AS Decimal(3, 1)), 1)
INSERT [dbo].[AcademicTranscript] ([id], [teacher_id], [course_id], [children_id], [quiz_1], [quiz_2], [midtern], [final], [average], [status]) VALUES (3, 1, 1, 3, CAST(9.0 AS Decimal(3, 1)), CAST(8.5 AS Decimal(3, 1)), CAST(8.8 AS Decimal(3, 1)), CAST(9.2 AS Decimal(3, 1)), CAST(8.9 AS Decimal(3, 1)), 1)
INSERT [dbo].[AcademicTranscript] ([id], [teacher_id], [course_id], [children_id], [quiz_1], [quiz_2], [midtern], [final], [average], [status]) VALUES (4, 1, 1, 4, CAST(8.7 AS Decimal(3, 1)), CAST(9.1 AS Decimal(3, 1)), CAST(8.4 AS Decimal(3, 1)), CAST(9.0 AS Decimal(3, 1)), CAST(8.8 AS Decimal(3, 1)), 1)
INSERT [dbo].[AcademicTranscript] ([id], [teacher_id], [course_id], [children_id], [quiz_1], [quiz_2], [midtern], [final], [average], [status]) VALUES (5, 1, 1, 5, CAST(8.2 AS Decimal(3, 1)), CAST(7.9 AS Decimal(3, 1)), CAST(8.9 AS Decimal(3, 1)), CAST(8.4 AS Decimal(3, 1)), CAST(8.3 AS Decimal(3, 1)), 1)
SET IDENTITY_INSERT [dbo].[AcademicTranscript] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([id], [parent_id], [status]) VALUES (1, 1, 1)
INSERT [dbo].[Cart] ([id], [parent_id], [status]) VALUES (2, 2, 1)
INSERT [dbo].[Cart] ([id], [parent_id], [status]) VALUES (3, 3, 1)
INSERT [dbo].[Cart] ([id], [parent_id], [status]) VALUES (4, 4, 1)
INSERT [dbo].[Cart] ([id], [parent_id], [status]) VALUES (5, 5, 1)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([id], [course_id], [teacher_id], [name], [status]) VALUES (1, 1, 1, N'Introduction to Robotics - Class A', 1)
INSERT [dbo].[Class] ([id], [course_id], [teacher_id], [name], [status]) VALUES (2, 1, 2, N'Introduction to Robotics - Class B', 1)
INSERT [dbo].[Class] ([id], [course_id], [teacher_id], [name], [status]) VALUES (3, 1, 3, N'Introduction to Robotics - Class C', 1)
INSERT [dbo].[Class] ([id], [course_id], [teacher_id], [name], [status]) VALUES (4, 1, 4, N'Introduction to Robotics - Class D', 1)
INSERT [dbo].[Class] ([id], [course_id], [teacher_id], [name], [status]) VALUES (5, 1, 5, N'Introduction to Robotics - Class E', 1)
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[ClassTime] ON 

INSERT [dbo].[ClassTime] ([id], [class_id], [day_in_week], [star_time], [end_time]) VALUES (1, 1, N'Monday', CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time))
INSERT [dbo].[ClassTime] ([id], [class_id], [day_in_week], [star_time], [end_time]) VALUES (2, 2, N'Tuesday', CAST(N'10:30:00' AS Time), CAST(N'12:30:00' AS Time))
INSERT [dbo].[ClassTime] ([id], [class_id], [day_in_week], [star_time], [end_time]) VALUES (3, 3, N'Wednesday', CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[ClassTime] ([id], [class_id], [day_in_week], [star_time], [end_time]) VALUES (4, 4, N'Thursday', CAST(N'15:30:00' AS Time), CAST(N'17:30:00' AS Time))
INSERT [dbo].[ClassTime] ([id], [class_id], [day_in_week], [star_time], [end_time]) VALUES (5, 5, N'Friday', CAST(N'18:00:00' AS Time), CAST(N'20:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[ClassTime] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([id], [name], [description], [start_date], [end_date], [open_form_time], [close_form_time], [price], [level], [total_slot], [status]) VALUES (1, N'Introduction to Robotics', N'This course covers basic concepts in robotics including robot design, sensors, actuators, and programming.', CAST(N'2024-03-01' AS Date), CAST(N'2024-04-15' AS Date), CAST(N'2024-02-01T09:00:00.000' AS DateTime), CAST(N'2024-02-28T17:00:00.000' AS DateTime), 99.99, 1, 20, 1)
INSERT [dbo].[Course] ([id], [name], [description], [start_date], [end_date], [open_form_time], [close_form_time], [price], [level], [total_slot], [status]) VALUES (2, N'Intermediate Robotics', N'This course builds upon the basics and covers topics such as advanced programming, machine learning in robotics, and project development.', CAST(N'2024-03-15' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-02-01T09:00:00.000' AS DateTime), CAST(N'2024-03-14T17:00:00.000' AS DateTime), 149.99, 2, 15, 1)
INSERT [dbo].[Course] ([id], [name], [description], [start_date], [end_date], [open_form_time], [close_form_time], [price], [level], [total_slot], [status]) VALUES (3, N'Advanced Robotics', N'This course dives deep into advanced robotics concepts including computer vision, motion planning, and autonomous systems.', CAST(N'2024-04-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-02-01T09:00:00.000' AS DateTime), CAST(N'2024-03-31T17:00:00.000' AS DateTime), 199.99, 3, 10, 1)
INSERT [dbo].[Course] ([id], [name], [description], [start_date], [end_date], [open_form_time], [close_form_time], [price], [level], [total_slot], [status]) VALUES (4, N'Robotics Project Workshop', N'A hands-on workshop where students work on real-world robotics projects under the guidance of experienced mentors.', CAST(N'2024-04-15' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2024-02-01T09:00:00.000' AS DateTime), CAST(N'2024-04-14T17:00:00.000' AS DateTime), 249.99, 3, 15, 1)
INSERT [dbo].[Course] ([id], [name], [description], [start_date], [end_date], [open_form_time], [close_form_time], [price], [level], [total_slot], [status]) VALUES (5, N'Robotics for Kids', N'An introductory course designed for children to learn basic robotics concepts through fun and interactive activities.', CAST(N'2024-03-01' AS Date), CAST(N'2024-04-15' AS Date), CAST(N'2024-02-01T09:00:00.000' AS DateTime), CAST(N'2024-02-28T17:00:00.000' AS DateTime), 79.99, 1, 25, 1)
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Children] ON 

INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (1, 1, N'Test Children 1', CAST(N'2010-05-15' AS Date), 1, 1, 1)
INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (2, 1, N'Test Children 2', CAST(N'2012-08-20' AS Date), 2, 1, 1)
INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (3, 2, N'Michael Williams', CAST(N'2015-03-10' AS Date), 1, 1, 1)
INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (4, 2, N'Sophia Brown', CAST(N'2011-11-25' AS Date), 2, 1, 1)
INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (5, 3, N'Matthew Jones', CAST(N'2013-07-12' AS Date), 1, 1, 1)
INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (6, 3, N'Olivia Davis', CAST(N'2016-01-30' AS Date), 2, 1, 1)
INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (7, 4, N'Daniel Wilson', CAST(N'2014-09-05' AS Date), 1, 1, 1)
INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (8, 4, N'Emma Martinez', CAST(N'2018-04-18' AS Date), 2, 1, 1)
INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (9, 5, N'Alexander Anderson', CAST(N'2017-06-22' AS Date), 1, 1, 1)
INSERT [dbo].[Children] ([id], [parent_id], [full_name], [birth_day], [gender], [role], [status]) VALUES (10, 5, N'Ava Taylor', CAST(N'2019-10-08' AS Date), 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Children] OFF
GO
SET IDENTITY_INSERT [dbo].[EquipmenntActivity] ON 

INSERT [dbo].[EquipmenntActivity] ([id], [manager_id], [equipment_id], [room_id], [operate_time], [description], [action]) VALUES (1, 3, 1, 1, CAST(N'2024-02-25T09:00:00.000' AS DateTime), N'Setting up equipment for robotics class.', 1)
INSERT [dbo].[EquipmenntActivity] ([id], [manager_id], [equipment_id], [room_id], [operate_time], [description], [action]) VALUES (2, 3, 2, 2, CAST(N'2024-02-25T10:00:00.000' AS DateTime), N'Testing projector in the conference room.', 1)
INSERT [dbo].[EquipmenntActivity] ([id], [manager_id], [equipment_id], [room_id], [operate_time], [description], [action]) VALUES (3, 3, 3, 3, CAST(N'2024-02-25T11:00:00.000' AS DateTime), N'Calibrating microscope for biology lab.', 1)
INSERT [dbo].[EquipmenntActivity] ([id], [manager_id], [equipment_id], [room_id], [operate_time], [description], [action]) VALUES (4, 3, 4, 4, CAST(N'2024-02-25T12:00:00.000' AS DateTime), N'Assembling robot kit for STEM workshop.', 1)
INSERT [dbo].[EquipmenntActivity] ([id], [manager_id], [equipment_id], [room_id], [operate_time], [description], [action]) VALUES (5, 3, 5, 5, CAST(N'2024-02-25T13:00:00.000' AS DateTime), N'Printing 3D model using the 3D printer.', 1)
SET IDENTITY_INSERT [dbo].[EquipmenntActivity] OFF
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (1, N'Laptop', N'Dell Inspiron 15 with 8GB RAM and 256GB SSD', 1)
INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (2, N'Projector', N'Epson Home Cinema 1080p projector with HDMI input', 1)
INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (3, N'Microscope', N'Nikon Eclipse Ni-U with 20x magnification', 1)
INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (4, N'Robot Kit', N'LEGO Mindstorms EV3 Robotics Kit', 1)
INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (5, N'3D Printer', N'Creality Ender 3 Pro with PLA filament', 1)
INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (6, N'Virtual Reality Headset', N'Oculus Quest 2 standalone VR headset', 1)
INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (7, N'Arduino Starter Kit', N'Official Arduino Starter Kit with UNO board', 1)
INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (8, N'Drone', N'DJI Mavic Air 2 quadcopter with 4K camera', 1)
INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (9, N'Smartboard', N'Promethean ActivPanel interactive whiteboard', 1)
INSERT [dbo].[Equipment] ([id], [name], [description], [status]) VALUES (10, N'Soldering Iron', N'Weller WLC100 40-Watt Soldering Station', 1)
SET IDENTITY_INSERT [dbo].[Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[EquipmentReport] ON 

INSERT [dbo].[EquipmentReport] ([id], [room_id], [equipment_id], [description], [status]) VALUES (1, 1, 1, N'Laptop not turning on.', 1)
INSERT [dbo].[EquipmentReport] ([id], [room_id], [equipment_id], [description], [status]) VALUES (2, 2, 2, N'Projector lamp needs replacement.', 1)
INSERT [dbo].[EquipmentReport] ([id], [room_id], [equipment_id], [description], [status]) VALUES (3, 3, 3, N'Microscope lens cracked.', 1)
INSERT [dbo].[EquipmentReport] ([id], [room_id], [equipment_id], [description], [status]) VALUES (4, 4, 4, N'Robot kit missing components.', 1)
INSERT [dbo].[EquipmentReport] ([id], [room_id], [equipment_id], [description], [status]) VALUES (5, 5, 5, N'3D printer filament jammed.', 1)
SET IDENTITY_INSERT [dbo].[EquipmentReport] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([id], [children_id], [course_id], [course_rating], [teacher_rating], [equipment_rating], [description]) VALUES (1, 1, 1, 4, 5, 3, N'I enjoyed the course overall, but I think the equipment could be improved.')
INSERT [dbo].[Feedback] ([id], [children_id], [course_id], [course_rating], [teacher_rating], [equipment_rating], [description]) VALUES (2, 2, 1, 5, 4, 5, N'The course was great and the teacher was excellent. I had a fantastic learning experience.')
INSERT [dbo].[Feedback] ([id], [children_id], [course_id], [course_rating], [teacher_rating], [equipment_rating], [description]) VALUES (3, 3, 1, 3, 3, 2, N'The course content was okay, but I found the equipment to be outdated.')
INSERT [dbo].[Feedback] ([id], [children_id], [course_id], [course_rating], [teacher_rating], [equipment_rating], [description]) VALUES (4, 4, 1, 4, 5, 4, N'Both the course and the teacher were fantastic. I learned a lot and had fun.')
INSERT [dbo].[Feedback] ([id], [children_id], [course_id], [course_rating], [teacher_rating], [equipment_rating], [description]) VALUES (5, 5, 1, 5, 5, 5, N'I absolutely loved the course! I had a blast and learned a ton.')
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Manager] ON 

INSERT [dbo].[Manager] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (1, N'Test Owner', N'testowner@gmail.com', N'12345', N'0234567890', CAST(N'1990-01-15' AS Date), 1, 1, 1)
INSERT [dbo].[Manager] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (2, N'Test Admin', N'testadmin@gmail.com', N'12345', N'0876543210', CAST(N'1985-05-20' AS Date), 2, 2, 1)
INSERT [dbo].[Manager] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (3, N'Test Staff', N'teststaff@gmail.com', N'12345', N'8554443333', CAST(N'1980-12-10' AS Date), 1, 3, 1)
SET IDENTITY_INSERT [dbo].[Manager] OFF
GO
SET IDENTITY_INSERT [dbo].[Parent] ON 

INSERT [dbo].[Parent] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (1, N'Test Parent', N'testparent@gmail.com', N'12345', N'1234567890', CAST(N'1990-05-15' AS Date), 1, 1, 1)
INSERT [dbo].[Parent] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (2, N'Jane Smith', N'jane.smith@example.com', N'password456', N'0987654321', CAST(N'1985-08-20' AS Date), 2, 1, 1)
INSERT [dbo].[Parent] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (3, N'Michael Johnson', N'michael.johnson@example.com', N'password789', N'5554443333', CAST(N'1978-12-10' AS Date), 1, 1, 1)
INSERT [dbo].[Parent] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (4, N'Emily Davis', N'emily.davis@example.com', N'password123', N'1112223333', CAST(N'1982-03-25' AS Date), 2, 1, 1)
INSERT [dbo].[Parent] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (5, N'David Brown', N'david.brown@example.com', N'password456', N'9998887777', CAST(N'1975-09-18' AS Date), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Parent] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([id], [floor], [room_no], [status]) VALUES (1, 1, 101, 1)
INSERT [dbo].[Room] ([id], [floor], [room_no], [status]) VALUES (2, 1, 102, 1)
INSERT [dbo].[Room] ([id], [floor], [room_no], [status]) VALUES (3, 2, 201, 1)
INSERT [dbo].[Room] ([id], [floor], [room_no], [status]) VALUES (4, 2, 202, 1)
INSERT [dbo].[Room] ([id], [floor], [room_no], [status]) VALUES (5, 3, 301, 1)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (1, 1, 1, 1, 1, CAST(N'2024-03-01T09:00:00.000' AS DateTime), CAST(N'2024-03-01T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (2, 1, 2, 1, 1, CAST(N'2024-03-02T09:00:00.000' AS DateTime), CAST(N'2024-03-02T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (3, 1, 3, 1, 1, CAST(N'2024-03-03T09:00:00.000' AS DateTime), CAST(N'2024-03-03T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (4, 1, 4, 1, 1, CAST(N'2024-03-04T09:00:00.000' AS DateTime), CAST(N'2024-03-04T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (5, 1, 5, 1, 1, CAST(N'2024-03-05T09:00:00.000' AS DateTime), CAST(N'2024-03-05T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (6, 1, 1, 1, 1, CAST(N'2024-03-06T09:00:00.000' AS DateTime), CAST(N'2024-03-06T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (7, 1, 2, 1, 1, CAST(N'2024-03-07T09:00:00.000' AS DateTime), CAST(N'2024-03-07T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (8, 1, 3, 1, 1, CAST(N'2024-03-08T09:00:00.000' AS DateTime), CAST(N'2024-03-08T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (9, 1, 4, 1, 1, CAST(N'2024-03-09T09:00:00.000' AS DateTime), CAST(N'2024-03-09T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([id], [teacher_id], [children_id], [course_id], [room_id], [start_time], [end_time], [attendance]) VALUES (10, 1, 5, 1, 1, CAST(N'2024-03-10T09:00:00.000' AS DateTime), CAST(N'2024-03-10T11:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (1, N'Test Teacher', N'testteacher@gmail.com', N'12345', N'1234567890', CAST(N'1985-07-15' AS Date), 2, 1, 1)
INSERT [dbo].[Teacher] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (2, N'Bob Smith', N'bob@example.com', N'password456', N'9876543210', CAST(N'1978-12-20' AS Date), 1, 1, 1)
INSERT [dbo].[Teacher] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (3, N'Charlie Brown', N'charlie@example.com', N'password789', N'5551234567', CAST(N'1990-03-25' AS Date), 1, 1, 1)
INSERT [dbo].[Teacher] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (4, N'Diana Martinez', N'diana@example.com', N'passwordabc', N'7778889999', CAST(N'1982-09-12' AS Date), 2, 1, 1)
INSERT [dbo].[Teacher] ([id], [full_name], [email], [password], [phone], [birth_day], [gender], [role], [status]) VALUES (5, N'Eva Taylor', N'eva@example.com', N'passwordefg', N'4445556666', CAST(N'1988-05-30' AS Date), 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD FOREIGN KEY([children_id])
REFERENCES [dbo].[Children] ([id])
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([parent_id])
REFERENCES [dbo].[Parent] ([id])
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD FOREIGN KEY([cart_id])
REFERENCES [dbo].[Cart] ([id])
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD FOREIGN KEY([children_id])
REFERENCES [dbo].[Children] ([id])
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[ClassTime]  WITH CHECK ADD FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Children]  WITH CHECK ADD  CONSTRAINT [FK_Children_Parent] FOREIGN KEY([parent_id])
REFERENCES [dbo].[Parent] ([id])
GO
ALTER TABLE [dbo].[Children] CHECK CONSTRAINT [FK_Children_Parent]
GO
ALTER TABLE [dbo].[EquipmenntActivity]  WITH CHECK ADD FOREIGN KEY([equipment_id])
REFERENCES [dbo].[Equipment] ([id])
GO
ALTER TABLE [dbo].[EquipmenntActivity]  WITH CHECK ADD FOREIGN KEY([manager_id])
REFERENCES [dbo].[Manager] ([id])
GO
ALTER TABLE [dbo].[EquipmenntActivity]  WITH CHECK ADD FOREIGN KEY([room_id])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[EquipmentReport]  WITH CHECK ADD FOREIGN KEY([equipment_id])
REFERENCES [dbo].[Equipment] ([id])
GO
ALTER TABLE [dbo].[EquipmentReport]  WITH CHECK ADD FOREIGN KEY([room_id])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([children_id])
REFERENCES [dbo].[Children] ([id])
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([cart_id])
REFERENCES [dbo].[Cart] ([id])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([children_id])
REFERENCES [dbo].[Children] ([id])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([room_id])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD CHECK  (([final]>=(0.0) AND [final]<=(10.0)))
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD CHECK  (([midtern]>=(0.0) AND [midtern]<=(10.0)))
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD CHECK  (([quiz_1]>=(0.0) AND [quiz_1]<=(10.0)))
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD CHECK  (([quiz_2]>=(0.0) AND [quiz_2]<=(10.0)))
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD CHECK  (([course_rating]>=(0) AND [course_rating]<=(5)))
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD CHECK  (([equipment_rating]>=(0) AND [equipment_rating]<=(5)))
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD CHECK  (([teacher_rating]>=(0) AND [teacher_rating]<=(5)))
GO
USE [master]
GO
ALTER DATABASE [ManageCourseCenter] SET  READ_WRITE 
GO
