USE [master]
GO
/****** Object:  Database [CarShopDB]    Script Date: 25.04.2023 16:19:30 ******/
CREATE DATABASE [CarShopDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarShopDB', FILENAME = N'D:\SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarShopDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarShopDB_log', FILENAME = N'D:\SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarShopDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarShopDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarShopDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarShopDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarShopDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarShopDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [CarShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarShopDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarShopDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarShopDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CarShopDB] SET QUERY_STORE = OFF
GO
USE [CarShopDB]
GO
/****** Object:  Table [dbo].[buying]    Script Date: 25.04.2023 16:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[buying](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerFname] [nvarchar](50) NOT NULL,
	[customerLname] [nvarchar](50) NOT NULL,
	[carID] [int] NOT NULL,
	[purchaseAmount] [nvarchar](50) NOT NULL,
	[purchaseDate] [date] NOT NULL,
 CONSTRAINT [PK_buying] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[car]    Script Date: 25.04.2023 16:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[car](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[model] [nvarchar](50) NOT NULL,
	[color] [nvarchar](50) NOT NULL,
	[complectationID] [int] NOT NULL,
	[price] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_car] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[complectation]    Script Date: 25.04.2023 16:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[complectation](
	[id] [int] NOT NULL,
	[title] [nchar](10) NOT NULL,
 CONSTRAINT [PK_complectation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 25.04.2023 16:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 25.04.2023 16:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[roleID] [int] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[buying] ON 

INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (1, N'Customer1', N'Customer1', 1, N'9 970 000', CAST(N'2023-01-01' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (8, N'Арсений', N'Пастухов ', 14, N'999.000', CAST(N'2023-01-21' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (9, N'Даниил', N'Баранов', 20, N'4 000 000', CAST(N'2023-01-27' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (10, N'Александр', N'Виноградов ', 27, N'19 967 000', CAST(N'2023-01-29' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (11, N'Алиса', N'Литвинова', 15, N'7 900 000', CAST(N'2023-02-02' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (12, N'Сафия', N'Степанова ', 33, N'11 730 000', CAST(N'2023-02-04' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (13, N'Андрей', N'Афанасьев', 25, N'4 000 000', CAST(N'2023-02-06' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (14, N'Тимур', N'Устинов', 18, N'19 759 0000', CAST(N'2023-02-10' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (15, N'Тимофей', N'Иванов', 8, N'3 999 000', CAST(N'2023-02-10' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (16, N'Артём', N'Никитин ', 29, N'16 100 000', CAST(N'2023-02-13' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (17, N'Матвей', N'Тарасов ', 1, N'9 970 000', CAST(N'2023-02-17' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (18, N'Даниил', N'Соколов ', 16, N'13 000 000', CAST(N'2023-02-19' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (19, N'Майя', N'Максимова ', 14, N'999 000', CAST(N'2023-03-01' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (20, N'Дмитрий', N'Поляков ', 24, N'18 510 000', CAST(N'2023-03-04' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (21, N'Григорий', N'Головин ', 9, N'6 960 000', CAST(N'2023-03-09' AS Date))
INSERT [dbo].[buying] ([id], [customerFname], [customerLname], [carID], [purchaseAmount], [purchaseDate]) VALUES (22, N'Кирилл', N'Туркин', 13, N'38 900 000', CAST(N'2023-03-13' AS Date))
SET IDENTITY_INSERT [dbo].[buying] OFF
GO
SET IDENTITY_INSERT [dbo].[car] ON 

INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (1, N'Jeep', N'Grand Cherokee', N'White', 3, N'9 970 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (8, N'Acura', N'NSX', N'Red', 2, N'3 990 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (9, N'BMW', N'M5 F90', N'Black', 3, N'6 960 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (10, N'Nissan', N'GT-R35', N'Orange', 3, N'7 900 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (12, N'McLaren', N'765LT', N'Orange', 3, N'22 999 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (13, N'RollsRoyce', N'CULLINAN', N'Black', 3, N'38.900.000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (14, N'Volkswagen', N'Golf', N'White', 2, N'999 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (15, N'Nissan', N'Silvia', N'Purple', 1, N'1 250 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (16, N'Mercedes', N'AMG GT63', N'Black', 3, N'13 000 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (18, N'Aston Martin', N'DB11', N'Green', 2, N'19 759 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (19, N'Subaru', N'BRZ', N'Blue', 1, N'2 360 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (20, N'Audi', N'R8', N'Grey', 3, N'4 000 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (21, N'Toyota', N'Supra', N'Red', 2, N'1 349 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (23, N'Range Rover', N'Evoque', N'White', 1, N'4 998 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (24, N'Bentley', N'Bentayga', N'Green', 3, N'18 510 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (25, N'Lotus', N'Elise', N'Yellow', 2, N'4 000 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (26, N'Jaguar', N'F-type', N'Orange', 3, N'6 280 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (27, N'Cadillac', N'Escalade ESV', N'Balck', 3, N'19 987 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (28, N'Chevrolet', N'Camaro', N'Yellow', 2, N'6 100 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (29, N'Lamborghini', N'Urus', N'Black', 1, N'16 100 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (30, N'Ford', N'Mustang', N'White', 3, N'6 921 000')
INSERT [dbo].[car] ([id], [name], [model], [color], [complectationID], [price]) VALUES (33, N'Porsche', N'Taycan Kyne', N'White', 2, N'11 730 000')
SET IDENTITY_INSERT [dbo].[car] OFF
GO
INSERT [dbo].[complectation] ([id], [title]) VALUES (1, N'Minimum   ')
INSERT [dbo].[complectation] ([id], [title]) VALUES (2, N'Average   ')
INSERT [dbo].[complectation] ([id], [title]) VALUES (3, N'Maximum   ')
GO
INSERT [dbo].[role] ([id], [title]) VALUES (1, N'Admin')
INSERT [dbo].[role] ([id], [title]) VALUES (2, N'User')
GO
INSERT [dbo].[user] ([id], [login], [password], [roleID]) VALUES (1, N'0', N'0', 1)
INSERT [dbo].[user] ([id], [login], [password], [roleID]) VALUES (2, N'1', N'1', 2)
GO
ALTER TABLE [dbo].[buying]  WITH CHECK ADD  CONSTRAINT [FK_buying_car] FOREIGN KEY([carID])
REFERENCES [dbo].[car] ([id])
GO
ALTER TABLE [dbo].[buying] CHECK CONSTRAINT [FK_buying_car]
GO
ALTER TABLE [dbo].[car]  WITH CHECK ADD  CONSTRAINT [FK_car_complectation] FOREIGN KEY([complectationID])
REFERENCES [dbo].[complectation] ([id])
GO
ALTER TABLE [dbo].[car] CHECK CONSTRAINT [FK_car_complectation]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_role] FOREIGN KEY([roleID])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO
USE [master]
GO
ALTER DATABASE [CarShopDB] SET  READ_WRITE 
GO
