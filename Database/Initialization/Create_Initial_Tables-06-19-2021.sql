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
		REFERENCES [Product]([ProductId]),
	CONSTRAINT [FK_Sales_Salesperson] FOREIGN KEY ([SalespersonId])
		REFERENCES [Salesperson]([SalespersonId]),
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

INSERT INTO [dbo].[Product] (Name, Manufacturer, Style, PurchasePrice, SalePrice, QtyOnHand, CommissionPercentage)
VALUES ('SupahFastBike', 'TheBestBikeMaker', 'Very good bike', 199.99, 199.99, 32, 12.5),
       ('LowRiderBike', 'TheCoolestBikeMaker', 'Very cool bike', 200, 150, 16, 10),
       ('HotRodBike', 'TheCoolestBikeMaker', 'Very hot bike', 350, 350, 93, 15),
       ('MegaUltraMountainBike', 'HardCoreBikeMaker', 'Very rugged bike', 150, 150, 6, 5),
       ('LittleKiddyBabyBike', 'GrandmaTheBikeMaker', 'Very comfortable and safe bike', 49.99, 99.99, 2, 4)
GO

INSERT INTO [dbo].[Salesperson] (FirstName, LastName, Address, Phone, StartDate, TerminationDate, Manager)
VALUES ('Jessica', 'SellsALot', '1002 VeryGood Salesperson Dr.', '1234567890', '2015-12-17', NULL, 'Martha VeryGoodManager'),
	   ('Marisha', 'NotSoGreat', '3153 NotSoGoodOfA Salesperson Ln.', '2345678901', '2019-04-06', '2019-06-17', 'Jeff NotTheBestManager'),
	   ('Robert', 'WatchesYoutubeAllDay', '1653 NotSoGoodOfA Salesperson Ln.', '3456789012', '2020-07-16', NULL, 'Jeff NotTheBestManager'),
	   ('Amir', 'BestSalesman', '643 VeryGood Salesperson Dr.', '4567890123', '2004-02-01', NULL, 'Martha VeryGoodManager'),
	   ('Susan', 'NeedsAPromotion', '782 VeryGood Salesperson Dr.', '5678901234', '2012-08-21', NULL, 'Martha VeryGoodManager')
GO

INSERT INTO [dbo].[Customer] (FirstName, LastName, Address, Phone, StartDate)
VALUES ('Billy', 'BuysSomeBikes', '3698 Biking Trail Way', '6789012345', '2012-05-13'),
	   ('Laura', 'BicycleGang', '468 Hardcore Trl.', '7890123456', '2020-04-23'),
	   ('Lexie', 'TrainingWheels', '418 Teapot St.', '8901234567', '2019-11-16'),
	   ('Merle', 'Highchurch', '265 Bureau of Balance Cir.', '9012345678', '2017-10-24'),
	   ('Taako', 'FromTV', '653 Fantasy Costco Blvd.', '0123456789', '2016-08-13')
GO

INSERT INTO [dbo].[Discount] (ProductId, BeginDate, EndDate, DiscountPercentage)
VALUES ((SELECT ProductId FROM Product WHERE Name = 'LowRiderBike'), '2021-06-13', '2021-06-20', 25),
	   ((SELECT ProductId FROM Product WHERE Name = 'MegaUltraMountainBike'), '2021-01-15', '2021-01-22', 16.66),
	   ((SELECT ProductId FROM Product WHERE Name = 'LittleKiddyBabyBike'), '2021-06-21', '2021-06-28', 50),
	   ((SELECT ProductId FROM Product WHERE Name = 'SupahFastBike'), '2021-06-28', '2021-07-05', 10),
	   ((SELECT ProductId FROM Product WHERE Name = 'HotRodBike'), '2021-07-05', '2021-07-12', 5)
GO

INSERT INTO [dbo].[Sales] (ProductId, SalespersonId, CustomerId, SalesDate)
VALUES ((SELECT ProductId FROM Product WHERE Name = 'SupahFastBike'),
			(SELECT SalesPersonId FROM Salesperson WHERE FirstName = 'Amir'),
			(SELECT CustomerId FROM Customer WHERE FirstName = 'Taako'), '2021-06-05'),
	   ((SELECT ProductId FROM Product WHERE Name = 'LowRiderBike'),
			(SELECT SalesPersonId FROM Salesperson WHERE FirstName = 'Jessica'),
			(SELECT CustomerId FROM Customer WHERE FirstName = 'Billy'), '2021-05-23'),
	   ((SELECT ProductId FROM Product WHERE Name = 'HotRodBike'),
			(SELECT SalesPersonId FROM Salesperson WHERE FirstName = 'Susan'),
			(SELECT CustomerId FROM Customer WHERE FirstName = 'Laura'), '2021-06-15'),
	   ((SELECT ProductId FROM Product WHERE Name = 'MegaUltraMountainBike'),
			(SELECT SalesPersonId FROM Salesperson WHERE FirstName = 'Amir'),
			(SELECT CustomerId FROM Customer WHERE FirstName = 'Merle'), '2021-03-12'),
	   ((SELECT ProductId FROM Product WHERE Name = 'LittleKiddyBabyBike'),
			(SELECT SalesPersonId FROM Salesperson WHERE FirstName = 'Marisha'),
			(SELECT CustomerId FROM Customer WHERE FirstName = 'Lexie'), '2021-04-26')
GO
COMMIT TRANSACTION