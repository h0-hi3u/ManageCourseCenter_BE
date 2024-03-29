USE [master]
GO
/****** Object:  Database [ManageCourseCenter]    Script Date: 2/20/2024 7:25:56 PM ******/
CREATE DATABASE [ManageCourseCenter]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ManageCourseCenter', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.HOTRONGHIEU\MSSQL\DATA\ManageCourseCenter.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ManageCourseCenter_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.HOTRONGHIEU\MSSQL\DATA\ManageCourseCenter_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [ManageCourseCenter] SET  DISABLE_BROKER 
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
/****** Object:  Table [dbo].[AcademicTranscript]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicTranscript](
	[id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[children_id] [int] NOT NULL,
	[quiz_1] [float] NOT NULL,
	[quiz_2] [float] NOT NULL,
	[midtern] [float] NOT NULL,
	[average] [float] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_AcademicTranscript] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[id] [int] NOT NULL,
	[parent_id] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItem]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItem](
	[id] [int] NOT NULL,
	[cart_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[children_id] [int] NOT NULL,
 CONSTRAINT [PK_CartItem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[time_id] [int] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassTime]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassTime](
	[id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[day_in_week] [varchar](9) NOT NULL,
	[star_time] [time](7) NOT NULL,
	[end_time] [time](7) NOT NULL,
 CONSTRAINT [PK_ClassTime] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[description] [varchar](255) NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[open_form_time] [datetime] NOT NULL,
	[close_form_time] [datetime] NOT NULL,
	[price] [float] NULL,
	[level] [int] NOT NULL,
	[total_slot] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Children]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Children](
	[id] [int] NOT NULL,
	[parent_id] [int] NOT NULL,
	[full_name] [varchar](20) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Children] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmenntActivity]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmenntActivity](
	[id] [int] NOT NULL,
	[manager_id] [int] NOT NULL,
	[equipment_id] [int] NOT NULL,
	[room_id] [int] NOT NULL,
	[operate_time] [datetime] NOT NULL,
	[action] [int] NOT NULL,
 CONSTRAINT [PK_EquipmenntActivity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[id] [int] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[description] [varchar](255) NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentReport]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentReport](
	[id] [int] NOT NULL,
	[room_id] [int] NOT NULL,
	[equipment_id] [int] NOT NULL,
	[description] [varchar](255) NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentReport] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [int] NOT NULL,
	[children_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[course_rating] [int] NOT NULL,
	[teacher_rating] [int] NOT NULL,
	[equipment_rating] [int] NOT NULL,
	[description] [varchar](255) NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[id] [int] NOT NULL,
	[full_name] [varchar](20) NOT NULL,
	[email] [varchar](256) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[id] [int] NOT NULL,
	[full_name] [varchar](20) NOT NULL,
	[email] [varchar](256) NOT NULL,
	[password] [varchar](16) NOT NULL,
	[phone] [int] NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] NOT NULL,
	[cart_id] [int] NOT NULL,
	[method] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[id] [int] NOT NULL,
	[floor] [int] NOT NULL,
	[room_no] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[children_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[room_id] [int] NOT NULL,
	[date] [date] NOT NULL,
	[start_time] [time](7) NOT NULL,
	[end_time] [time](7) NOT NULL,
	[attendance] [int] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2/20/2024 7:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] NOT NULL,
	[full_name] [varchar](20) NOT NULL,
	[email] [varchar](256) NOT NULL,
	[password] [varchar](16) NOT NULL,
	[phone] [int] NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNIQUE_EMAIL_MANAGER]    Script Date: 2/20/2024 7:25:56 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UNIQUE_EMAIL_MANAGER] ON [dbo].[Manager]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD  CONSTRAINT [FK_AcademicTranscript_Course] FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[AcademicTranscript] CHECK CONSTRAINT [FK_AcademicTranscript_Course]
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD  CONSTRAINT [FK_AcademicTranscript_Children] FOREIGN KEY([children_id])
REFERENCES [dbo].[Children] ([id])
GO
ALTER TABLE [dbo].[AcademicTranscript] CHECK CONSTRAINT [FK_AcademicTranscript_Children]
GO
ALTER TABLE [dbo].[AcademicTranscript]  WITH CHECK ADD  CONSTRAINT [FK_AcademicTranscript_Teacher] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[AcademicTranscript] CHECK CONSTRAINT [FK_AcademicTranscript_Teacher]
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_Cart] FOREIGN KEY([cart_id])
REFERENCES [dbo].[Cart] ([id])
GO
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_Cart]
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_Class]
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_Course] FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_Course]
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_Children] FOREIGN KEY([children_id])
REFERENCES [dbo].[Children] ([id])
GO
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_Children]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Course] FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Course]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Teacher] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Teacher]
GO
ALTER TABLE [dbo].[ClassTime]  WITH CHECK ADD  CONSTRAINT [FK_ClassTime_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[ClassTime] CHECK CONSTRAINT [FK_ClassTime_Class]
GO
ALTER TABLE [dbo].[Children]  WITH CHECK ADD  CONSTRAINT [FK_Children_Parent] FOREIGN KEY([parent_id])
REFERENCES [dbo].[Parent] ([id])
GO
ALTER TABLE [dbo].[Children] CHECK CONSTRAINT [FK_Children_Parent]
GO
ALTER TABLE [dbo].[EquipmenntActivity]  WITH CHECK ADD  CONSTRAINT [FK_EquipmenntActivity_Equipment] FOREIGN KEY([equipment_id])
REFERENCES [dbo].[Equipment] ([id])
GO
ALTER TABLE [dbo].[EquipmenntActivity] CHECK CONSTRAINT [FK_EquipmenntActivity_Equipment]
GO
ALTER TABLE [dbo].[EquipmenntActivity]  WITH CHECK ADD  CONSTRAINT [FK_EquipmenntActivity_Manager] FOREIGN KEY([manager_id])
REFERENCES [dbo].[Manager] ([id])
GO
ALTER TABLE [dbo].[EquipmenntActivity] CHECK CONSTRAINT [FK_EquipmenntActivity_Manager]
GO
ALTER TABLE [dbo].[EquipmenntActivity]  WITH CHECK ADD  CONSTRAINT [FK_EquipmenntActivity_Room] FOREIGN KEY([room_id])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[EquipmenntActivity] CHECK CONSTRAINT [FK_EquipmenntActivity_Room]
GO
ALTER TABLE [dbo].[EquipmentReport]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentReport_Equipment] FOREIGN KEY([equipment_id])
REFERENCES [dbo].[Equipment] ([id])
GO
ALTER TABLE [dbo].[EquipmentReport] CHECK CONSTRAINT [FK_EquipmentReport_Equipment]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Course1] FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Course1]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Children] FOREIGN KEY([children_id])
REFERENCES [dbo].[Children] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Children]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Cart] FOREIGN KEY([cart_id])
REFERENCES [dbo].[Cart] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Cart]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Parent] FOREIGN KEY([cart_id])
REFERENCES [dbo].[Parent] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Parent]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Class]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Children] FOREIGN KEY([children_id])
REFERENCES [dbo].[Children] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Children]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Room] FOREIGN KEY([room_id])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Room]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Teacher] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Teacher]
GO
USE [master]
GO
ALTER DATABASE [ManageCourseCenter] SET  READ_WRITE 
GO
