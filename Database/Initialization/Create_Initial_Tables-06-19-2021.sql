/*
* Introduces Tables for Bespoked Bikes
*/

BEGIN TRANSACTION
GO

/****** Object:  Table [dbo].[Product]    Script Date: 6/19/2021 9:59:40 AM ******/
CREATE TABLE [dbo].[Product](
	[ProductId] [uniqueidentifier] NOT NULL DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](50) NOT NULL,
	[Manufacturer] [nvarchar](50) NOT NULL,
	[Style] [nvarchar](50) NOT NULL,
	[PurchasePrice] [money] NOT NULL,
	[SalePrice] [money] NOT NULL,
	[QtyOnHand] [int] NOT NULL,
	[CommissionPercentage] [decimal](5, 2) NULL

	CONSTRAINT [PK_Product] PRIMARY KEY([ProductId])
)
GO

/****** Object:  Table [dbo].[Salesperson]    Script Date: 6/19/2021 9:59:40 AM ******/
CREATE TABLE [dbo].[Salesperson](
	[SalespersonId] [uniqueidentifier] NOT NULL DEFAULT NEWSEQUENTIALID(),
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[StartDate] [date] NOT NULL,
	[TerminationDate] [date] NULL,
	[Manager] [nvarchar](50) NOT NULL

	CONSTRAINT [PK_Salesperson] PRIMARY KEY([SalespersonId])
)
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 6/19/2021 9:59:40 AM ******/
CREATE TABLE [dbo].[Customer](
	[CustomerId] [uniqueidentifier] NOT NULL DEFAULT NEWSEQUENTIALID(),
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[StartDate] [date] NOT NULL

	CONSTRAINT [PK_Customer] PRIMARY KEY([CustomerId])
)
GO

/****** Object:  Table [dbo].[Sales]    Script Date: 6/19/2021 9:59:40 AM ******/
CREATE TABLE [dbo].[Sales](
	[SalesId] [uniqueidentifier] NOT NULL DEFAULT NEWSEQUENTIALID(),
	[ProductId] [uniqueidentifier] NOT NULL,
	[SalespersonId] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[SalesDate] [date] NOT NULL

	CONSTRAINT [PK_Sales] PRIMARY KEY([SalesId])
	CONSTRAINT [FK_Sales_Product] FOREIGN KEY ([ProductId])
		REFERENCES [Product]([ProductId])
	CONSTRAINT [FK_Sales_Salesperson] FOREIGN KEY ([SalespersonId])
		REFERENCES [Salesperson]([SalespersonId])
	CONSTRAINT [FK_Sales_Customer] FOREIGN KEY ([CustomerId])
		REFERENCES [Customer]([CustomerId])
)
GO

/****** Object:  Table [dbo].[Discount]    Script Date: 6/19/2021 9:59:40 AM ******/
CREATE TABLE [dbo].[Discount](
	[ProductId] [uniqueidentifier] NOT NULL,
	[BeginDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[DiscountPercentage] [int] NOT NULL

	CONSTRAINT [FK_Discount_Product] FOREIGN KEY ([ProductId])
		REFERENCES [Product]([ProductId])
)
GO
COMMIT TRANSACTION