/*CustomerMaster Table*/

USE [Customer]
GO

/****** Object:  Table [dbo].[CustomerMaster]    Script Date: 1/31/2026 8:51:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerMaster](
[ID] [int] NOT NULL,
[CustomerName] [varchar](https://www.notion.so/50) NOT NULL,
[CustomerPhoneNo] [varchar](https://www.notion.so/50) NOT NULL,
[CustomerCity] [varchar](https://www.notion.so/50) NOT NULL,
CONSTRAINT [PK_CustomerMaster] PRIMARY KEY CLUSTERED
(
[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*OrderDetails Table*/

USE [Customer]
GO

/****** Object:  Table [dbo].[OrderDetails]    Script Date: 1/31/2026 8:52:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderDetails](
[Id] [int] NOT NULL,
[CustomerId] [int] NOT NULL,
[PurchaseDate] [date] NOT NULL,
[SalesId] [int] NOT NULL,
CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_CustomerMaster] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerMaster] ([ID])
GO

ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_CustomerMaster]
GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_SalesPersonDetails] FOREIGN KEY([SalesId])
REFERENCES [dbo].[SalesPersonDetails] ([SalesId])
GO

ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_SalesPersonDetails]
GO

/*ProductMaster Table*/

USE [Customer]
GO

/****** Object:  Table [dbo].[ProductMaster]    Script Date: 1/31/2026 8:52:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductMaster](
[Id] [int] NOT NULL,
[Item] [varchar](https://www.notion.so/50) NOT NULL,
[Price] [varchar](https://www.notion.so/50) NOT NULL,
CONSTRAINT [PK_ProductMaster] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*PurchaseDetails Table*/

USE [Customer]
GO

/****** Object:  Table [dbo].[PurchaseDetails]    Script Date: 1/31/2026 8:53:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PurchaseDetails](
[Id] [int] NOT NULL,
[OrderId] [int] NOT NULL,
[ProductId] [int] NOT NULL,
[Quantity] [int] NOT NULL,
CONSTRAINT [PK_PurchaseDetails] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PurchaseDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetails_OrderDetails] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderDetails] ([Id])
GO

ALTER TABLE [dbo].[PurchaseDetails] CHECK CONSTRAINT [FK_PurchaseDetails_OrderDetails]
GO

ALTER TABLE [dbo].[PurchaseDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetails_ProductMaster] FOREIGN KEY([ProductId])
REFERENCES [dbo].[ProductMaster] ([Id])
GO

ALTER TABLE [dbo].[PurchaseDetails] CHECK CONSTRAINT [FK_PurchaseDetails_ProductMaster]
GO

/*SalesPersonDetails Table*/

USE [Customer]
GO

/****** Object:  Table [dbo].[SalesPersonDetails]    Script Date: 1/31/2026 8:54:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesPersonDetails](
[SalesId] [int] NOT NULL,
[Name] [varchar](https://www.notion.so/50) NOT NULL,
CONSTRAINT [PK_SalesPersonDetails] PRIMARY KEY CLUSTERED
(
[SalesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO