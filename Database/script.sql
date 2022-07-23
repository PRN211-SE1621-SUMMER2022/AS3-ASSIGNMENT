USE [master]
CREATE DATABASE [SaleManagementDB]
GO
CREATE DATABASE [SaleManagementDB]
ALTER DATABASE [SaleManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SaleManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SaleManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SaleManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SaleManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SaleManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SaleManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SaleManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SaleManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SaleManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SaleManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SaleManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SaleManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SaleManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SaleManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SaleManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SaleManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SaleManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SaleManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SaleManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SaleManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SaleManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SaleManagementDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SaleManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [SaleManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SaleManagementDB] SET DB_CHAINING OFF 
GO

USE [SaleManagementDB]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 07/11/2022 11:32:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberId] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CompanyName] [varchar](40) NOT NULL,
	[City] [varchar](15) NOT NULL,
	[Country] [varchar](15) NOT NULL,
	[Password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 07/11/2022 11:32:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[RequiredDate] [datetime] NULL,
	[ShippedDate] [datetime] NULL,
	[Freight] [money] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 07/11/2022 11:32:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 07/11/2022 11:32:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductName] [varchar](40) NOT NULL,
	[Weight] [varchar](20) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitsInStock] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

GO 
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (3, N'hungpd@fpt.edu.vn', N'FPT', N'HCM', N'VN', N'hung')
GO
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (4, N'anhtt@fpt.edu.vn', N'FPT', N'HCM', N'VN', N'anh')
GO

GO
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (1, 1, CAST(N'2022-04-03T00:00:00.000' AS DateTime), CAST(N'2022-05-06T00:00:00.000' AS DateTime), CAST(N'2022-04-04T00:00:00.000' AS DateTime), 2020.0000)
GO
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (2, 1, CAST(N'2022-07-11T20:08:12.830' AS DateTime), CAST(N'2022-07-11T20:08:12.830' AS DateTime), CAST(N'2022-07-11T20:08:12.830' AS DateTime), 5000.0000)
GO
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (213, 1, CAST(N'2022-07-11T21:06:49.000' AS DateTime), CAST(N'2022-07-11T21:06:49.000' AS DateTime), CAST(N'2022-07-11T21:06:49.000' AS DateTime), 12.0000)
GO
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (666, 21, CAST(N'2022-07-11T22:56:03.960' AS DateTime), CAST(N'2022-07-11T22:56:03.957' AS DateTime), CAST(N'2022-07-11T22:56:03.957' AS DateTime), 222.0000)
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 1, 23000000.0000, 1, 200000)
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 2, 33000000.0000, 2, 40000)
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 3, 4000000.0000, 3, 5000)
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (2, 2, 3232322.0000, 1, 0)
GO
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (1, 1, N'Laptop', N'2.9', 2300000.0000, 25)
GO
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (2, 1, N'Phone', N'0.5', 1000000.0000, 177)
GO
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (3, 1, N'Watch', N'0.3', 100000.0000, 32)
GO
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (4, 2, N'Ball', N'1', 32442.0000, 213)
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([MemberId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Member]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
USE [master]
GO
ALTER DATABASE [SaleManagementDB] SET  READ_WRITE 
GO
