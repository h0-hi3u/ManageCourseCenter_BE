USE [master]
GO

CREATE DATABASE [ManageCourseCenter]
GO

USE [ManageCourseCenter]
GO

CREATE TABLE [dbo].[Parent](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](128) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[Children](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[parent_id] [int] FOREIGN KEY REFERENCES [dbo].[Parent]([id]) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
 )
GO

CREATE TABLE [dbo].[Teacher](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](128) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[Course](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
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
)
GO

CREATE TABLE [dbo].[AcademicTranscript](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[teacher_id] [int] FOREIGN KEY REFERENCES [dbo].[Teacher]([id]) NOT NULL,
	[course_id] [int] FOREIGN KEY REFERENCES [dbo].[Course]([id]) NOT NULL,
	[children_id] [int] FOREIGN KEY REFERENCES [dbo].[Children]([id]) NOT NULL,
	[quiz_1] [decimal](3,1) CHECK([quiz_1] >= 0.0 AND [quiz_1] <= 10.0) NOT NULL,
	[quiz_2] [decimal](3,1) CHECK([quiz_2] >= 0.0 AND [quiz_2] <= 10.0) NOT NULL,
	[midterm] [decimal](3,1) CHECK([midterm] >= 0.0 AND [midterm] <= 10.0) NOT NULL,
	[final] [decimal](3,1) CHECK([final] >= 0.0 AND [final] <= 10.0) NOT NULL,
	[average] [decimal](3,1) NOT NULL,
	[status] [int] NOT NULL,
 )
GO

CREATE TABLE [dbo].[Class](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[course_id] [int] FOREIGN KEY REFERENCES [dbo].[Course]([id]) NOT NULL,
	[teacher_id] [int] FOREIGN KEY REFERENCES [dbo].[Teacher]([id]) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[total_amount] [int] NOT NULL,
	[status] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[Cart](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[parent_id] [int] FOREIGN KEY REFERENCES [dbo].[Parent]([id]) NOT NULL,
	[status] [int] NOT NULL,
 )
GO

CREATE TABLE [dbo].[CartItem](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[cart_id] [int] FOREIGN KEY REFERENCES [dbo].[Cart]([id]) NOT NULL,
	[course_id] [int] FOREIGN KEY REFERENCES [dbo].[Course]([id]) NOT NULL,
	[class_id] [int] FOREIGN KEY REFERENCES [dbo].[Class]([id]) NOT NULL,
	[children_id] [int] FOREIGN KEY REFERENCES [dbo].[Children]([id]) NOT NULL,
)
GO

CREATE TABLE [dbo].[ClassTime](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[class_id] [int] FOREIGN KEY REFERENCES [dbo].[Class]([id]) NOT NULL,
	[day_in_week] [varchar](9) NOT NULL,
	[star_time] [time] NOT NULL,
	[end_time] [time] NOT NULL,
 )
GO

CREATE TABLE [dbo].[Equipment](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](max) NULL,
	[type] [int] NOT NULL,
	[status] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[Manager](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](128) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[birth_day] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[Room](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[floor] [int] NOT NULL,
	[room_no] [int] NOT NULL,
	[status] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[EquipmenntActivity](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[manager_id] [int] FOREIGN KEY REFERENCES [dbo].[Manager]([id]) NOT NULL,
	[equipment_id] [int] FOREIGN KEY REFERENCES [dbo].[Equipment]([id]) NOT NULL,
	[room_id] [int] FOREIGN KEY REFERENCES [dbo].[Room]([id]) NOT NULL,
	[operate_time] [datetime] NOT NULL,
	[description] [nvarchar](max) NULL,
	[action] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[EquipmentReport](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[room_id] [int] FOREIGN KEY REFERENCES [dbo].[Room]([id]) NOT NULL,
	[equipment_id] [int] FOREIGN KEY REFERENCES [dbo].[Equipment]([id]) NOT NULL,
	[description] [nvarchar](max) NULL,
	[status] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[ChildrenClass](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[class_id] [int] FOREIGN KEY REFERENCES [dbo].[Class]([id]) NOT NULL,
	[children_id] [int] FOREIGN KEY REFERENCES [dbo].[Children]([id]) NOT NULL,
)
GO

CREATE TABLE [dbo].[Feedback](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[children_class_id] [int] FOREIGN KEY REFERENCES [dbo].[ChildrenClass]([id]) NOT NULL,
	[course_rating] [int] CHECK([course_rating] >= 0 AND [course_rating] <= 5) NOT NULL,
	[teacher_rating] [int] CHECK([teacher_rating] >= 0 AND [teacher_rating] <= 5) NOT NULL,
	[equipment_rating] [int] CHECK([equipment_rating] >= 0 AND [equipment_rating] <= 5) NOT NULL,
	[description] [nvarchar](max) NULL,
)
GO

CREATE TABLE [dbo].[Payment](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[cart_id] [int] FOREIGN KEY REFERENCES [dbo].[Cart]([id]) NOT NULL,
	[method] [int] NOT NULL,
	[status] [int] NOT NULL,
)
GO

CREATE TABLE [dbo].[Schedule](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[teacher_id] [int] FOREIGN KEY REFERENCES [dbo].[Teacher]([id]) NOT NULL,
	[children_class_id] [int] FOREIGN KEY REFERENCES [dbo].[ChildrenClass]([id]) NOT NULL,
	[room_id] [int] FOREIGN KEY REFERENCES [dbo].[Room]([id]) NOT NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NOT NULL,
	[attendance] [int] NOT NULL,
)
GO

-- Dump data for [Parent] table
INSERT INTO [dbo].[Parent] ([full_name], [email], [password], [phone], [birth_day], [gender], [role], [status])
VALUES 
	('Test Parent', 'testparent@gmail.com', '12345', '1234567890', '1990-05-15', 1, 1, 1),
	('Jane Smith', 'jane.smith@example.com', 'password456', '0987654321', '1985-08-20', 2, 1, 1),
	('Michael Johnson', 'michael.johnson@example.com', 'password789', '5554443333', '1978-12-10', 1, 1, 1),
	('Emily Davis', 'emily.davis@example.com', 'password123', '1112223333', '1982-03-25', 2, 1, 1),
	('David Brown', 'david.brown@example.com', 'password456', '9998887777', '1975-09-18', 1, 1, 1);

-- Dump data for [Children] table
INSERT INTO [dbo].[Children] ([parent_id], [full_name], [birth_day], [gender], [role], [status])
VALUES 
	(1, 'Test Children 1', '2010-05-15', 1, 1, 1),
	(1, 'Test Children 2', '2012-08-20', 2, 1, 1),
	(2, 'Michael Williams', '2015-03-10', 1, 1, 1),
	(2, 'Sophia Brown', '2011-11-25', 2, 1, 1),
	(3, 'Matthew Jones', '2013-07-12', 1, 1, 1),
	(3, 'Olivia Davis', '2016-01-30', 2, 1, 1),
	(4, 'Daniel Wilson', '2014-09-05', 1, 1, 1),
	(4, 'Emma Martinez', '2018-04-18', 2, 1, 1),
	(5, 'Alexander Anderson', '2017-06-22', 1, 1, 1),
	(5, 'Ava Taylor', '2019-10-08', 2, 1, 1);

-- Dump data for [Teacher] table
INSERT INTO [dbo].[Teacher] ([full_name], [email], [password], [phone], [birth_day], [gender], [role], [status])
VALUES 
	('Test Teacher', 'testteacher@gmail.com', '12345', '1234567890', '1985-07-15', 2, 1, 1),
	('Bob Smith', 'bob@example.com', 'password456', '9876543210', '1978-12-20', 1, 1, 1),
	('Charlie Brown', 'charlie@example.com', 'password789', '5551234567', '1990-03-25', 1, 1, 1),
	('Diana Martinez', 'diana@example.com', 'passwordabc', '7778889999', '1982-09-12', 2, 1, 1),
	('Eva Taylor', 'eva@example.com', 'passwordefg', '4445556666', '1988-05-30', 2, 1, 1);

-- Dump data for [Course] table
INSERT INTO [dbo].[Course] ([name], [description], [start_date], [end_date], [open_form_time], [close_form_time], [price], [level], [total_slot], [status])
VALUES 
	('Introduction to Robotics', 'This course covers basic concepts in robotics including robot design, sensors, actuators, and programming.', '2024-03-01', '2024-04-15', '2024-02-01 09:00:00', '2024-02-28 17:00:00', 99.99, 1, 20, 1),
	('Intermediate Robotics', 'This course builds upon the basics and covers topics such as advanced programming, machine learning in robotics, and project development.', '2024-03-15', '2024-05-01', '2024-02-01 09:00:00', '2024-03-14 17:00:00', 149.99, 2, 15, 1),
	('Advanced Robotics', 'This course dives deep into advanced robotics concepts including computer vision, motion planning, and autonomous systems.', '2024-04-01', '2024-06-01', '2024-02-01 09:00:00', '2024-03-31 17:00:00', 199.99, 3, 10, 1),
	('Robotics Project Workshop', 'A hands-on workshop where students work on real-world robotics projects under the guidance of experienced mentors.', '2024-04-15', '2024-07-01', '2024-02-01 09:00:00', '2024-04-14 17:00:00', 249.99, 3, 15, 1),
	('Robotics for Kids', 'An introductory course designed for children to learn basic robotics concepts through fun and interactive activities.', '2024-03-01', '2024-04-15', '2024-02-01 09:00:00', '2024-02-28 17:00:00', 79.99, 1, 25, 1);

-- Dump data for [AcademicTranscript] table
INSERT INTO [dbo].[AcademicTranscript] ([teacher_id], [course_id], [children_id], [quiz_1], [quiz_2], [midterm], [final], [average], [status])
VALUES 
    (1, 1, 1, 8.5, 7.8, 9.2, 8.7, 8.3, 1),
    (1, 1, 2, 7.9, 8.2, 9.0, 8.5, 8.4, 1),
    (1, 1, 3, 9.0, 8.5, 8.8, 9.2, 8.9, 1),
    (1, 1, 4, 8.7, 9.1, 8.4, 9.0, 8.8, 1),
    (1, 1, 5, 8.2, 7.9, 8.9, 8.4, 8.3, 1);

-- Dump data for [Class] table
INSERT INTO [dbo].[Class] ([course_id], [teacher_id], [name], [total_amount], [status])
VALUES 
    (1, 1, 'Introduction to Robotics - Class A', 30, 1),
    (1, 2, 'Introduction to Robotics - Class B', 30, 1),
    (1, 3, 'Introduction to Robotics - Class C', 30, 1),
    (1, 4, 'Introduction to Robotics - Class D', 30, 1),
    (1, 5, 'Introduction to Robotics - Class E', 30, 1);

-- Dump data for [Cart] table
INSERT INTO [dbo].[Cart] ([parent_id], [status])
VALUES 
    (1, 1),
    (2, 1),
    (3, 1),
    (4, 1),
    (5, 1);

-- Dump data for [ClassTime] table
INSERT INTO [dbo].[ClassTime] ([class_id], [day_in_week], [star_time], [end_time])
VALUES 
    (1, 'Monday', '08:00:00', '10:00:00'),
    (2, 'Tuesday', '10:30:00', '12:30:00'),
    (3, 'Wednesday', '13:00:00', '15:00:00'),
    (4, 'Thursday', '15:30:00', '17:30:00'),
    (5, 'Friday', '18:00:00', '20:00:00');

-- Dump data for [Equipment] table
INSERT INTO [dbo].[Equipment] ([name], [description], [type], [status])
VALUES 
    ('Laptop', 'Dell Inspiron 15 with 8GB RAM and 256GB SSD', 1, 1),
    ('Projector', 'Epson Home Cinema 1080p projector with HDMI input', 1, 1),
    ('Microscope', 'Nikon Eclipse Ni-U with 20x magnification', 1, 1),
    ('Robot Kit', 'LEGO Mindstorms EV3 Robotics Kit', 1, 1),
    ('3D Printer', 'Creality Ender 3 Pro with PLA filament', 1, 1),
    ('Virtual Reality Headset', 'Oculus Quest 2 standalone VR headset', 1, 1),
    ('Arduino Starter Kit', 'Official Arduino Starter Kit with UNO board', 1, 1),
    ('Drone', 'DJI Mavic Air 2 quadcopter with 4K camera', 1, 1),
    ('Smartboard', 'Promethean ActivPanel interactive whiteboard', 1, 1),
    ('Soldering Iron', 'Weller WLC100 40-Watt Soldering Station', 1, 1);

-- Dump data for [Manager] table
INSERT INTO [dbo].[Manager] ([full_name], [email], [password], [phone], [birth_day], [gender], [role], [status])
VALUES 
    ('Test Owner', 'testowner@gmail.com', '12345', '0234567890', '1990-01-15', 1, 1, 1),
    ('Test Admin', 'testadmin@gmail.com', '12345', '0876543210', '1985-05-20', 2, 2, 1),
    ('Test Staff', 'teststaff@gmail.com', '12345', '8554443333', '1980-12-10', 1, 3, 1);

-- Dump data for [Room] table
INSERT INTO [dbo].[Room] ([floor], [room_no], [status])
VALUES 
    (1, 101, 1),
    (1, 102, 1),
    (2, 201, 1),
    (2, 202, 1),
    (3, 301, 1);

-- Dump data for [EquipmenntActivity] table
INSERT INTO [dbo].[EquipmenntActivity] ([manager_id], [equipment_id], [room_id], [operate_time], [description], [action])
VALUES 
    (3, 1, 1, '2024-02-25 09:00:00', 'Setting up equipment for robotics class.', 1),
    (3, 2, 2, '2024-02-25 10:00:00', 'Testing projector in the conference room.', 1),
    (3, 3, 3, '2024-02-25 11:00:00', 'Calibrating microscope for biology lab.', 1),
    (3, 4, 4, '2024-02-25 12:00:00', 'Assembling robot kit for STEM workshop.', 1),
    (3, 5, 5, '2024-02-25 13:00:00', 'Printing 3D model using the 3D printer.', 1);

-- Dump data for [EquipmentReport] table
INSERT INTO [dbo].[EquipmentReport] ([room_id], [equipment_id], [description], [status])
VALUES 
    (1, 1, 'Laptop not turning on.', 1),
    (2, 2, 'Projector lamp needs replacement.', 1),
    (3, 3, 'Microscope lens cracked.', 1),
    (4, 4, 'Robot kit missing components.', 1),
    (5, 5, '3D printer filament jammed.', 1);

-- Dump data for [ChildrenClass] table
INSERT INTO [dbo].[ChildrenClass] ([class_id], [children_id])
VALUES
	(1, 1),
	(1, 2),
	(1, 3),
	(1, 4),
	(1, 5),
	(1, 6),
	(1, 7),
	(1, 8),
	(1, 9),
	(1, 10);


-- Dump data for [Feedback] table
INSERT INTO [dbo].[Feedback] ([children_class_id], [course_rating], [teacher_rating], [equipment_rating], [description])
VALUES 
    (1, 4, 5, 3, 'I enjoyed the course overall, but I think the equipment could be improved.'),
    (2, 5, 4, 5, 'The course was great and the teacher was excellent. I had a fantastic learning experience.'),
    (3, 3, 3, 2, 'The course content was okay, but I found the equipment to be outdated.'),
    (4, 4, 5, 4, 'Both the course and the teacher were fantastic. I learned a lot and had fun.'),
    (5, 5, 5, 5, 'I absolutely loved the course! I had a blast and learned a ton.');

-- Dump data for [Schedule] table
INSERT INTO [dbo].[Schedule] ([teacher_id], [children_class_id], [room_id], [start_time], [end_time], [attendance])
VALUES 
    (1, 1, 1, '2024-03-01 09:00:00', '2024-03-01 11:00:00', 1),
    (1, 2, 1, '2024-03-02 09:00:00', '2024-03-02 11:00:00', 1),
    (1, 3, 1, '2024-03-03 09:00:00', '2024-03-03 11:00:00', 1),
    (1, 4, 1, '2024-03-04 09:00:00', '2024-03-04 11:00:00', 1),
    (1, 5, 1, '2024-03-05 09:00:00', '2024-03-05 11:00:00', 1),
    (1, 1, 1, '2024-03-06 09:00:00', '2024-03-06 11:00:00', 1),
    (1, 2, 1, '2024-03-07 09:00:00', '2024-03-07 11:00:00', 1),
    (1, 3, 1, '2024-03-08 09:00:00', '2024-03-08 11:00:00', 1),
    (1, 4, 1, '2024-03-09 09:00:00', '2024-03-09 11:00:00', 1),
    (1, 5, 1, '2024-03-10 09:00:00', '2024-03-10 11:00:00', 1);
