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
		[img_url] [nvarchar](max) NULL,
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
		[username] [nvarchar](100) NOT NULL,
		[password] [nvarchar](128) NOT NULL,
		[img_url] [nvarchar](max) NOT NULL,
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
		[img_url] [nvarchar](max) NOT NULL,
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
		[img_url] [nvarchar](max) NOT NULL,
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
		[start_date] [date] NOT NULL,
		[end_date] [date] NOT NULL,
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
		[star_time] [nvarchar](10) NOT NULL,
		[end_time] [nvarchar](10) NOT NULL,
	 )
	GO

	CREATE TABLE [dbo].[Equipment](
		[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
		[name] [nvarchar](100) NOT NULL,
		[supplier] [nvarchar](100) NOT NULL,
		[quantity] [int] CHECK([quantity] >= 0.0) NOT NULL,
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
		[img_url] [nvarchar](max) NOT NULL,
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

	CREATE TABLE [dbo].[EquipmentActivity](
		[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
		[manager_id] [int] FOREIGN KEY REFERENCES [dbo].[Manager]([id]) NOT NULL,
		[equipment_id] [int] FOREIGN KEY REFERENCES [dbo].[Equipment]([id]) NOT NULL,
		[room_id] [int] FOREIGN KEY REFERENCES [dbo].[Room]([id]) NOT NULL,
		[operate_time] [datetime] NOT NULL,
		[finished_time] [datetime] NULL,
		[description] [nvarchar](max) NULL,
		[action] [int] NOT NULL,
		[status] [int] NOT NULL,
	)
	GO

	CREATE TABLE [dbo].[EquipmentReport](
		[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
		[sender_id] [int] FOREIGN KEY REFERENCES [dbo].[Teacher]([id]) NOT NULL,
		[room_id] [int] FOREIGN KEY REFERENCES [dbo].[Room]([id]) NOT NULL,
		[equipment_id] [int] FOREIGN KEY REFERENCES [dbo].[Equipment]([id]) NOT NULL,
		[description] [nvarchar](max) NULL,
		[send_time] [datetime] NOT NULL,
		[close_time] [datetime] NULL,
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
		[create_time] [datetime] NOT NULL,
		[paid_time] [datetime] NULL,
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
	INSERT INTO [dbo].[Children] ([parent_id], [full_name], [username], [password], [img_url], [birth_day], [gender], [role], [status])
	VALUES 
		(1, 'Test Children 1', 'children1@gmail.com', '12345', 'img-link', '2010-05-15', 1, 1, 1),
		(1, 'Test Children 2', 'children2@gmail.com', '12345', 'img-link', '2012-08-20', 2, 1, 1),
		(2, 'Michael Williams', 'williams@gmail.com', '12345', 'img-link', '2015-03-10', 1, 1, 1),
		(2, 'Sophia Brown', 'browns@gmail.com', '12345', 'img-link', '2011-11-25', 2, 1, 1),
		(3, 'Matthew Jones', 'jones@gmail.com', '12345', 'img-link', '2013-07-12', 1, 1, 1),
		(3, 'Olivia Davis', 'davis@gmail.com', '12345', 'img-link', '2016-01-30', 2, 1, 1),
		(4, 'Daniel Wilson', 'wilson@gmail.com', '12345', 'img-link', '2014-09-05', 1, 1, 1),
		(4, 'Emma Martinez', 'martinez@gmail.com', '12345', 'img-link', '2018-04-18', 2, 1, 1),
		(5, 'Alexander Anderson', 'anderson@gmail.com', '12345', 'img-link', '2017-06-22', 1, 1, 1),
		(5, 'Ava Taylor', 'taylor@gmail.com', '12345', 'img-link', '2019-10-08', 2, 1, 1);

	-- Dump data for [Teacher] table
	INSERT INTO [dbo].[Teacher] ([full_name], [email], [password], [img_url], [phone], [birth_day], [gender], [role], [status])
	VALUES 
		('Test Teacher', 'testteacher@gmail.com', '12345', 'img-link', '1234567890', '1985-07-15', 2, 1, 1),
		('Bob Smith', 'bob@example.com', 'password456', 'img-link', '9876543210', '1978-12-20', 1, 1, 1),
		('Charlie Brown', 'charlie@example.com', 'password789', 'img-link', '5551234567', '1990-03-25', 1, 1, 1),
		('Diana Martinez', 'diana@example.com', 'passwordabc', 'img-link', '7778889999', '1982-09-12', 2, 1, 1),
		('Eva Taylor', 'eva@example.com', 'passwordefg', 'img-link', '4445556666', '1988-05-30', 2, 1, 1);

	-- Dump data for [Course] table
	INSERT INTO [dbo].[Course] ([name], [img_url], [description], [open_form_time], [close_form_time], [price], [level], [total_slot], [status])
	VALUES 
		('Introduction to Robotics', 'img-link', 'This course covers basic concepts in robotics including robot design, sensors, actuators, and programming.', '2024-03-15 00:00:00', '2024-04-15 00:00:00', 99.99, 1, 20, 1),
		('Intermediate Robotics', 'img-link', 'This course builds upon the basics and covers topics such as advanced programming, machine learning in robotics, and project development.', '2024-02-01 09:00:00', '2024-03-14 17:00:00', 149.99, 2, 15, 1),
		('Advanced Robotics', 'img-link', 'This course dives deep into advanced robotics concepts including computer vision, motion planning, and autonomous systems.', '2024-02-01 09:00:00', '2024-03-31 17:00:00', 199.99, 3, 10, 1),
		('Robotics Project Workshop', 'img-link', 'A hands-on workshop where students work on real-world robotics projects under the guidance of experienced mentors.', '2024-02-01 09:00:00', '2024-04-14 17:00:00', 249.99, 3, 15, 1),
		('Robotics for Kids', 'img-link', 'An introductory course designed for children to learn basic robotics concepts through fun and interactive activities.', '2024-01-01 00:00:00', '2024-01-14 00:00:00', 79.99, 1, 10, 1);

	-- Dump data for [AcademicTranscript] table
	INSERT INTO [dbo].[AcademicTranscript] ([teacher_id], [course_id], [children_id], [quiz_1], [quiz_2], [midterm], [final], [average], [status])
	VALUES 
		(1, 5, 1, 8.5, 7.8, 9.2, 8.7, 8.7, 1),
		(1, 5, 2, 7.9, 8.2, 9.0, 8.5, 8.5, 1),
		(1, 5, 3, 9.0, 8.5, 8.8, 9.2, 8.9, 1),
		(1, 5, 4, 8.7, 9.1, 8.4, 9.0, 8.8, 1),
		(1, 5, 5, 8.2, 7.9, 8.9, 8.4, 8.4, 1),
		(1, 1, 4, 0.0, 0.0, 0.0, 0.0, 0.0, 1),
		(1, 1, 5, 0.0, 0.0, 0.0, 0.0, 0.0, 1),
		(1, 1, 2, 0.0, 0.0, 0.0, 0.0, 0.0, 1),
		(1, 1, 3, 0.0, 0.0, 0.0, 0.0, 0.0, 1);

	-- Dump data for [Class] table
	INSERT INTO [dbo].[Class] ([course_id], [teacher_id], [name], [start_date], [end_date], [total_amount], [status])
	VALUES 
		(5, 1, 'Robotics for Kids - Class A', '2024-02-01', '2024-03-07', 24, 3),
		(5, 2, 'Robotics for Kids - Class B', '2024-02-01', '2024-03-07', 24, 3),
		(1, 1, 'Introduction to Robotics - Class A', '2024-03-01', '2024-04-05', 24, 2),
		(1, 1, 'Introduction to Robotics - Class B', '2024-05-01', '2024-06-05', 24, 1),
		(1, 1, 'Introduction to Robotics - Class C', '2024-05-01', '2024-06-05', 24, 1);


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
	INSERT INTO [dbo].[Equipment] ([name], [supplier], [quantity], [description], [type], [status])
	VALUES 
		('Laptop Dell', 'Supplier', 1, 'Dell Inspiron 15 with 8GB RAM and 256GB SSD', 1, 2),
		('Laptop Acer', 'Supplier', 1, 'Acer Laptop with 8GB RAM and 256GB SSD', 1, 2),
		('Laptop ASUS', 'Supplier', 1, 'ASUS Laptop with 8GB RAM and 256GB SSD', 1, 1),
		('Laptop MSI', 'Supplier', 1, 'MSI Laptop with 8GB RAM and 256GB SSD', 1, 1),
		('Robot Kit 001', 'Supplier', 1,  'Mindstorms EV3 Robotics Kit', 2, 2),
		('Robot Kit 002', 'Supplier', 1,  'Mindstorms EV3 Robotics Kit', 2, 2),
		('Robot Kit 003', 'Supplier', 1,  'Mindstorms EV3 Robotics Kit', 2, 1),
		('Robot Kit 004', 'Supplier', 1,  'Mindstorms EV3 Robotics Kit', 2, 1),
		('Projector 001', 'Supplier', 1,  'Epson Home Cinema 1080p projector with HDMI input', 3, 2),
		('Projector 002', 'Supplier', 1,  'Xiaomi Home Cinema 1080p projector with HDMI input', 3, 2),
		('Projector 003', 'Supplier', 1,  'Vison Home Cinema 1080p projector with HDMI input', 3, 1),
		('Projector 004', 'Supplier', 1,  'Hawei Home Cinema 1080p projector with HDMI input', 3, 1),
		('Smartboard 001', 'Supplier', 1,  'Promethean ActivPanel interactive whiteboard', 4, 2),
		('Smartboard 002', 'Supplier', 1,  'Promethean ActivPanel interactive whiteboard', 4, 2),
		('Smartboard 003', 'Supplier', 1,  'Promethean ActivPanel interactive whiteboard', 4, 1),
		('Smartboard 004', 'Supplier', 1,  'Promethean ActivPanel interactive whiteboard', 4, 1);

	-- Dump data for [Manager] table
	INSERT INTO [dbo].[Manager] ([full_name], [email], [password], [img_url], [phone], [birth_day], [gender], [role], [status])
	VALUES 
		('Test Owner', 'testowner@gmail.com', '12345', 'img-link', '0234567890', '1990-01-15', 1, 1, 1),
		('Test Admin', 'testadmin@gmail.com', '12345', 'img-link', '0876543210', '1985-05-20', 2, 2, 1),
		('Test Staff', 'teststaff@gmail.com', '12345', 'img-link', '8554443333', '1980-12-10', 1, 3, 1);

	-- Dump data for [Room] table
	INSERT INTO [dbo].[Room] ([floor], [room_no], [status])
	VALUES 
		(1, 101, 1),
		(1, 102, 1),
		(2, 201, 1),
		(2, 202, 1),
		(3, 301, 1);

	-- Dump data for [EquipmentActivity] table
	INSERT INTO [dbo].[EquipmentActivity] ([manager_id], [equipment_id], [room_id], [operate_time], [finished_time], [description], [action], [status])
	VALUES 
		(3, 1, 2, '2024-02-25 09:00:00', NULL, 'Moving Equipment To This Room', 2, 1),
		(3, 2, 3, '2024-02-25 10:00:00', NULL, 'Moving Equipment To This Room', 2, 1),
		(3, 5, 2, '2024-02-25 11:00:00', NULL, 'Moving Equipment To This Room', 2, 1),
		(3, 6, 3, '2024-02-25 12:00:00', NULL, 'Moving Equipment To This Room', 2, 1),
		(3, 9, 2, '2024-02-25 13:00:00', NULL, 'Moving Equipment To This Room', 2, 1),
		(3, 10, 3, '2024-02-25 09:00:00', NULL, 'Moving Equipment To This Room', 2, 1),
		(3, 13, 2, '2024-02-25 10:00:00', NULL, 'Moving Equipment To This Room', 2, 1),
		(3, 14, 3, '2024-02-25 11:00:00', NULL, 'Moving Equipment To This Room', 2, 1),
		(3, 3, 1, '2024-02-25 09:00:00', NULL, 'Storage At This Room', 1, 1),
		(3, 4, 1, '2024-02-25 10:00:00', NULL, 'Storage At This Room', 1, 1),
		(3, 7, 1, '2024-02-25 11:00:00', NULL, 'Storage At This Room', 1, 1),
		(3, 8, 1, '2024-02-25 12:00:00', NULL, 'Storage At This Room', 1, 1),
		(3, 11, 1, '2024-02-25 13:00:00', NULL, 'Storage At This Room', 1, 1),
		(3, 12, 1, '2024-02-25 09:00:00', NULL, 'Storage At This Room', 1, 1),
		(3, 15, 1, '2024-02-25 10:00:00', NULL, 'Storage At This Room', 1, 1),
		(3, 16, 1, '2024-02-25 11:00:00', NULL, 'Storage At This Room', 1, 1);

	-- Dump data for [EquipmentReport] table
	INSERT INTO [dbo].[EquipmentReport] ([sender_id], [room_id], [equipment_id],[send_time], [close_time], [description], [status])
	VALUES 
		(1, 2, 1, '2024-02-25 13:00:00', '2024-02-26 13:00:00','Laptop not turning on.', 2),
		(1, 3, 6, '2024-02-26 13:00:00', '2024-02-27 13:00:00','Kit not running.', 2);

	-- Dump data for [ChildrenClass] table
	INSERT INTO [dbo].[ChildrenClass] ([class_id], [children_id])
	VALUES
		(1, 1),
		(1, 2),
		(2, 3),
		(2, 4),
		(2, 5),
		(3, 4),
		(3, 5),
		(4, 2),
		(4, 3);


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
