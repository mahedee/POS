USE [master]
GO
/****** Object:  Database [IMS]    Script Date: 1/3/2016 10:04:37 PM ******/
CREATE DATABASE [IMS] 
go
ALTER DATABASE [IMS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [IMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [IMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IMS] SET RECOVERY FULL 
GO
ALTER DATABASE [IMS] SET  MULTI_USER 
GO
ALTER DATABASE [IMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IMS] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'IMS', N'ON'
GO
USE [IMS]
GO
/****** Object:  StoredProcedure [dbo].[spSales]    Script Date: 1/3/2016 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSales]
(
@modelID int
)
as
begin
	SELECT S.sale_id, S.model_id, S.discount, S.quantity, S.netprice,M.model_name
	FROM salesinfo S
	INNER JOIN model_name1 M ON M.model_id=S.model_id
	WHERE S.model_id = @modelID OR @modelID = 0
END
GO
/****** Object:  Table [dbo].[brand_name]    Script Date: 1/3/2016 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[brand_name](
	[brand_name_id] [bigint] IDENTITY(1,1) NOT NULL,
	[brand_name] [varchar](50) NULL,
	[product_name_id] [bigint] NULL,
 CONSTRAINT [PK_brand_name] PRIMARY KEY CLUSTERED 
(
	[brand_name_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[category]    Script Date: 1/3/2016 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[category](
	[category_code] [bigint] NULL,
	[category_name] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[menu]    Script Date: 1/3/2016 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[menu](
	[menu_id] [int] NULL,
	[parent_menu_id] [int] NULL,
	[menu_name] [varchar](50) NULL,
	[form_name] [varchar](50) NULL,
	[menu_level] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[model_name1]    Script Date: 1/3/2016 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[model_name1](
	[model_id] [bigint] IDENTITY(1,1) NOT NULL,
	[product_name_id] [bigint] NULL,
	[brand_name_id] [bigint] NULL,
	[model_name] [varchar](50) NULL,
 CONSTRAINT [PK_model_name1] PRIMARY KEY CLUSTERED 
(
	[model_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product_name]    Script Date: 1/3/2016 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product_name](
	[product_name_id] [bigint] IDENTITY(1,1) NOT NULL,
	[product_name] [varchar](30) NULL,
 CONSTRAINT [PK_product_name] PRIMARY KEY CLUSTERED 
(
	[product_name_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[purchage_product]    Script Date: 1/3/2016 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchage_product](
	[model_id] [bigint] NULL,
	[purchage_price] [decimal](18, 2) NULL,
	[sales_price] [decimal](18, 2) NULL,
	[Total_Quantity] [bigint] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[salesinfo]    Script Date: 1/3/2016 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salesinfo](
	[sale_id] [bigint] NULL,
	[model_id] [bigint] NULL,
	[discount] [decimal](18, 2) NULL,
	[quantity] [int] NULL,
	[netprice] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[brand_name] ON 

INSERT [dbo].[brand_name] ([brand_name_id], [brand_name], [product_name_id]) VALUES (1, N'hp', 3)
INSERT [dbo].[brand_name] ([brand_name_id], [brand_name], [product_name_id]) VALUES (2, N'hp', 3)
SET IDENTITY_INSERT [dbo].[brand_name] OFF
INSERT [dbo].[category] ([category_code], [category_name]) VALUES (101, N'TEST CATEGORY')
INSERT [dbo].[menu] ([menu_id], [parent_menu_id], [menu_name], [form_name], [menu_level]) VALUES (1, 1, N'File', NULL, 1)
INSERT [dbo].[menu] ([menu_id], [parent_menu_id], [menu_name], [form_name], [menu_level]) VALUES (2, 1, N'Add Product Name', N'addproduct', 2)
INSERT [dbo].[menu] ([menu_id], [parent_menu_id], [menu_name], [form_name], [menu_level]) VALUES (3, 1, N'Add Brand Name', N'addbrand', 2)
INSERT [dbo].[menu] ([menu_id], [parent_menu_id], [menu_name], [form_name], [menu_level]) VALUES (4, 1, N'Add Model', N'addmodel', 2)
INSERT [dbo].[menu] ([menu_id], [parent_menu_id], [menu_name], [form_name], [menu_level]) VALUES (5, 1, N'Purchage Product Entry', N'PurchageProduct', 2)
INSERT [dbo].[menu] ([menu_id], [parent_menu_id], [menu_name], [form_name], [menu_level]) VALUES (6, 1, N'Sales', N'Sales', 2)
SET IDENTITY_INSERT [dbo].[model_name1] ON 

INSERT [dbo].[model_name1] ([model_id], [product_name_id], [brand_name_id], [model_name]) VALUES (1, 3, 2, N'mn0012')
INSERT [dbo].[model_name1] ([model_id], [product_name_id], [brand_name_id], [model_name]) VALUES (2, 3, 1, N'5245jhhh')
INSERT [dbo].[model_name1] ([model_id], [product_name_id], [brand_name_id], [model_name]) VALUES (3, 3, 1, N'm12')
SET IDENTITY_INSERT [dbo].[model_name1] OFF
SET IDENTITY_INSERT [dbo].[product_name] ON 

INSERT [dbo].[product_name] ([product_name_id], [product_name]) VALUES (1, N'test name')
INSERT [dbo].[product_name] ([product_name_id], [product_name]) VALUES (2, N'ss')
INSERT [dbo].[product_name] ([product_name_id], [product_name]) VALUES (3, N'test data')
SET IDENTITY_INSERT [dbo].[product_name] OFF
INSERT [dbo].[purchage_product] ([model_id], [purchage_price], [sales_price], [Total_Quantity]) VALUES (3, CAST(14.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), 250)
INSERT [dbo].[purchage_product] ([model_id], [purchage_price], [sales_price], [Total_Quantity]) VALUES (2, CAST(50.00 AS Decimal(18, 2)), CAST(55.00 AS Decimal(18, 2)), 150)
INSERT [dbo].[purchage_product] ([model_id], [purchage_price], [sales_price], [Total_Quantity]) VALUES (1, CAST(15.00 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)), 12)
INSERT [dbo].[salesinfo] ([sale_id], [model_id], [discount], [quantity], [netprice]) VALUES (4, 1, CAST(0.00 AS Decimal(18, 2)), 20, CAST(360.00 AS Decimal(18, 2)))
INSERT [dbo].[salesinfo] ([sale_id], [model_id], [discount], [quantity], [netprice]) VALUES (1, 3, CAST(2.00 AS Decimal(18, 2)), 350, CAST(6860.00 AS Decimal(18, 2)))
INSERT [dbo].[salesinfo] ([sale_id], [model_id], [discount], [quantity], [netprice]) VALUES (2, 2, CAST(2.00 AS Decimal(18, 2)), 100, CAST(5500.00 AS Decimal(18, 2)))
INSERT [dbo].[salesinfo] ([sale_id], [model_id], [discount], [quantity], [netprice]) VALUES (3, 2, CAST(2.00 AS Decimal(18, 2)), 100, CAST(5500.00 AS Decimal(18, 2)))
USE [master]
GO
ALTER DATABASE [IMS] SET  READ_WRITE 
GO
