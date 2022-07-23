USE [master]
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'SaleManagementDB')
BEGIN
	ALTER DATABASE [SaleManagementDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [SaleManagementDB];  
END;
GO

CREATE DATABASE [SaleManagementDB]
GO

USE [SaleManagementDB]
GO

CREATE TABLE [dbo].[Member](
	[MemberId] INT IDENTITY(1,1) NOT NULL,
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId]  INT IDENTITY(1,1) NOT NULL,
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId]  INT IDENTITY(1,1) NOT NULL,
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
INSERT [dbo].[Member] ([Email], [CompanyName], [City], [Country], [Password]) VALUES (N'hungpd@fpt.edu.vn', N'FPT', N'HCM', N'VN', N'hung')
GO
INSERT [dbo].[Member] ([Email], [CompanyName], [City], [Country], [Password]) VALUES (N'anhtt@fpt.edu.vn', N'FPT', N'HCM', N'VN', N'anh')
GO

GO
INSERT [dbo].[Order] ([MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (1, CAST(N'2022-04-03T00:00:00.000' AS DateTime), CAST(N'2022-05-06T00:00:00.000' AS DateTime), CAST(N'2022-04-04T00:00:00.000' AS DateTime), 2020.0000)
GO
INSERT [dbo].[Order] ([MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (1, CAST(N'2022-07-11T20:08:12.830' AS DateTime), CAST(N'2022-07-11T20:08:12.830' AS DateTime), CAST(N'2022-07-11T20:08:12.830' AS DateTime), 5000.0000)
GO
INSERT [dbo].[Order] ([MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (1, CAST(N'2022-07-11T21:06:49.000' AS DateTime), CAST(N'2022-07-11T21:06:49.000' AS DateTime), CAST(N'2022-07-11T21:06:49.000' AS DateTime), 12.0000)
GO
INSERT [dbo].[Order] ([MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (2, CAST(N'2022-07-11T22:56:03.960' AS DateTime), CAST(N'2022-07-11T22:56:03.957' AS DateTime), CAST(N'2022-07-11T22:56:03.957' AS DateTime), 222.0000)
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 1, 23000000.0000, 1, 200000)
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 2, 33000000.0000, 2, 40000)
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 3, 4000000.0000, 3, 5000)
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (2, 2, 3232322.0000, 1, 0)
GO
INSERT [dbo].[Product] ([CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (1, N'Laptop', N'2.9', 2300000.0000, 25)
GO
INSERT [dbo].[Product] ([CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (1, N'Phone', N'0.5', 1000000.0000, 177)
GO
INSERT [dbo].[Product] ([CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (1, N'Watch', N'0.3', 100000.0000, 32)
GO
INSERT [dbo].[Product] ([CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (2, N'Ball', N'1', 32442.0000, 213)
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
