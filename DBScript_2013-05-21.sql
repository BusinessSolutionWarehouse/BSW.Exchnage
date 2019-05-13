PRINT '-------------------------- Stored Procedures : SELECT --------------------------------'
GO

PRINT 'CREATE PROCEDURE : BusinessEntityGet'
GO

IF OBJECT_ID(N'[dbo].[BusinessEntityGet]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BusinessEntityGet]
GO

CREATE PROCEDURE [dbo].[BusinessEntityGet]
	@BusinessEntityCode varchar(10)=NULL,
	@BusinessEntityID int=NULL,
	@BusinessEntityName varchar(100)=NULL,
	@BusinessEntityStatusID tinyint=NULL,
	@BusinessEntityTypeID tinyint=NULL,
	@VatNumber varchar(20)=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	BusinessEntityCode,
	BusinessEntityID,
	BusinessEntityName,
	BusinessEntityStatusID,
	BusinessEntityTypeID,
	VatNumber
	FROM BusinessEntity
	WHERE
	(@BusinessEntityCode IS NULL OR BusinessEntityCode=@BusinessEntityCode)
	AND (@BusinessEntityID IS NULL OR BusinessEntityID=@BusinessEntityID)
	AND (@BusinessEntityName IS NULL OR BusinessEntityName=@BusinessEntityName)
	AND (@BusinessEntityStatusID IS NULL OR BusinessEntityStatusID=@BusinessEntityStatusID)
	AND (@BusinessEntityTypeID IS NULL OR BusinessEntityTypeID=@BusinessEntityTypeID)
	AND (@VatNumber IS NULL OR VatNumber=@VatNumber)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN 'BusinessEntityCode' THEN BusinessEntityCode
		WHEN NULL THEN BusinessEntityID
		WHEN 'BusinessEntityID' THEN BusinessEntityID
		WHEN 'BusinessEntityName' THEN BusinessEntityName
		WHEN 'BusinessEntityStatusID' THEN BusinessEntityStatusID
		WHEN 'BusinessEntityTypeID' THEN BusinessEntityTypeID
		WHEN 'VatNumber' THEN VatNumber
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN 'BusinessEntityCode' THEN BusinessEntityCode
		WHEN NULL THEN BusinessEntityID
		WHEN 'BusinessEntityID' THEN BusinessEntityID
		WHEN 'BusinessEntityName' THEN BusinessEntityName
		WHEN 'BusinessEntityStatusID' THEN BusinessEntityStatusID
		WHEN 'BusinessEntityTypeID' THEN BusinessEntityTypeID
		WHEN 'VatNumber' THEN VatNumber
	END
	END
	DESC
END
GO

PRINT 'CREATE PROCEDURE : OrderLineGet'
GO

IF OBJECT_ID(N'[dbo].[OrderLineGet]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[OrderLineGet]
GO

CREATE PROCEDURE [dbo].[OrderLineGet]
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@Description varchar(100)=NULL,
	@DutyPercentage decimal(5,2)=NULL,
	@DutyTypeID int=NULL,
	@OnSiteDt datetime=NULL,
	@OrderID int=NULL,
	@OrderLineID int=NULL,
	@OrderLineStatusID tinyint=NULL,
	@ProductID int=NULL,
	@SupplierRefNo varchar(50)=NULL,
	@TariffCode varchar(50)=NULL,
	@TotalVolume decimal(18,2)=NULL,
	@TotalWeight decimal(18,2)=NULL,
	@UnitCurrencyID smallint=NULL,
	@UnitPrice money=NULL,
	@UnitQuantity smallint=NULL,
	@UnitTypeID tinyint=NULL,
	@UpdatedDt datetime=NULL,
	@UpdatedUserID smallint=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	CreatedDt,
	CreatedUserID,
	Description,
	DutyPercentage,
	DutyTypeID,
	OnSiteDt,
	OrderID,
	OrderLineID,
	OrderLineStatusID,
	ProductID,
	SupplierRefNo,
	TariffCode,
	TotalVolume,
	TotalWeight,
	UnitCurrencyID,
	UnitPrice,
	UnitQuantity,
	UnitTypeID,
	UpdatedDt,
	UpdatedUserID
	FROM OrderLine
	WHERE
	(@CreatedDt IS NULL OR CreatedDt=@CreatedDt)
	AND (@CreatedUserID IS NULL OR CreatedUserID=@CreatedUserID)
	AND (@Description IS NULL OR Description=@Description)
	AND (@DutyPercentage IS NULL OR DutyPercentage=@DutyPercentage)
	AND (@DutyTypeID IS NULL OR DutyTypeID=@DutyTypeID)
	AND (@OnSiteDt IS NULL OR OnSiteDt=@OnSiteDt)
	AND (@OrderID IS NULL OR OrderID=@OrderID)
	AND (@OrderLineID IS NULL OR OrderLineID=@OrderLineID)
	AND (@OrderLineStatusID IS NULL OR OrderLineStatusID=@OrderLineStatusID)
	AND (@ProductID IS NULL OR ProductID=@ProductID)
	AND (@SupplierRefNo IS NULL OR SupplierRefNo=@SupplierRefNo)
	AND (@TariffCode IS NULL OR TariffCode=@TariffCode)
	AND (@TotalVolume IS NULL OR TotalVolume=@TotalVolume)
	AND (@TotalWeight IS NULL OR TotalWeight=@TotalWeight)
	AND (@UnitCurrencyID IS NULL OR UnitCurrencyID=@UnitCurrencyID)
	AND (@UnitPrice IS NULL OR UnitPrice=@UnitPrice)
	AND (@UnitQuantity IS NULL OR UnitQuantity=@UnitQuantity)
	AND (@UnitTypeID IS NULL OR UnitTypeID=@UnitTypeID)
	AND (@UpdatedDt IS NULL OR UpdatedDt=@UpdatedDt)
	AND (@UpdatedUserID IS NULL OR UpdatedUserID=@UpdatedUserID)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN 'CreatedDt' THEN CreatedDt
		WHEN 'CreatedUserID' THEN CreatedUserID
		WHEN 'Description' THEN Description
		WHEN 'DutyPercentage' THEN DutyPercentage
		WHEN 'DutyTypeID' THEN DutyTypeID
		WHEN 'OnSiteDt' THEN OnSiteDt
		WHEN 'OrderID' THEN OrderID
		WHEN NULL THEN OrderLineID
		WHEN 'OrderLineID' THEN OrderLineID
		WHEN 'OrderLineStatusID' THEN OrderLineStatusID
		WHEN 'ProductID' THEN ProductID
		WHEN 'SupplierRefNo' THEN SupplierRefNo
		WHEN 'TariffCode' THEN TariffCode
		WHEN 'TotalVolume' THEN TotalVolume
		WHEN 'TotalWeight' THEN TotalWeight
		WHEN 'UnitCurrencyID' THEN UnitCurrencyID
		WHEN 'UnitPrice' THEN UnitPrice
		WHEN 'UnitQuantity' THEN UnitQuantity
		WHEN 'UnitTypeID' THEN UnitTypeID
		WHEN 'UpdatedDt' THEN UpdatedDt
		WHEN 'UpdatedUserID' THEN UpdatedUserID
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN 'CreatedDt' THEN CreatedDt
		WHEN 'CreatedUserID' THEN CreatedUserID
		WHEN 'Description' THEN Description
		WHEN 'DutyPercentage' THEN DutyPercentage
		WHEN 'DutyTypeID' THEN DutyTypeID
		WHEN 'OnSiteDt' THEN OnSiteDt
		WHEN 'OrderID' THEN OrderID
		WHEN NULL THEN OrderLineID
		WHEN 'OrderLineID' THEN OrderLineID
		WHEN 'OrderLineStatusID' THEN OrderLineStatusID
		WHEN 'ProductID' THEN ProductID
		WHEN 'SupplierRefNo' THEN SupplierRefNo
		WHEN 'TariffCode' THEN TariffCode
		WHEN 'TotalVolume' THEN TotalVolume
		WHEN 'TotalWeight' THEN TotalWeight
		WHEN 'UnitCurrencyID' THEN UnitCurrencyID
		WHEN 'UnitPrice' THEN UnitPrice
		WHEN 'UnitQuantity' THEN UnitQuantity
		WHEN 'UnitTypeID' THEN UnitTypeID
		WHEN 'UpdatedDt' THEN UpdatedDt
		WHEN 'UpdatedUserID' THEN UpdatedUserID
	END
	END
	DESC
END
GO

PRINT 'CREATE PROCEDURE : ProductGet'
GO

IF OBJECT_ID(N'[dbo].[ProductGet]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[ProductGet]
GO

CREATE PROCEDURE [dbo].[ProductGet]
	@DurtyPercentage decimal(5,2)=NULL,
	@ImporterID int=NULL,
	@LatestUpdateDT datetime=NULL,
	@ProductCode varchar(50)=NULL,
	@ProductDescription varchar(100)=NULL,
	@ProductID int=NULL,
	@ProductStatusID tinyint=NULL,
	@SupplierID int=NULL,
	@SupplierProductCode varchar(50)=NULL,
	@TariffCode varchar(30)=NULL,
	@UnitDim1_CM decimal(16,2)=NULL,
	@UnitDim2_CM decimal(16,2)=NULL,
	@UnitDim3_CM decimal(16,2)=NULL,
	@UnitPackQty smallint=NULL,
	@UnitPriceForeign money=NULL,
	@UnitWeight_KG decimal(16,2)=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	DurtyPercentage,
	ImporterID,
	LatestUpdateDT,
	ProductCode,
	ProductDescription,
	ProductID,
	ProductStatusID,
	SupplierID,
	SupplierProductCode,
	TariffCode,
	UnitDim1_CM,
	UnitDim2_CM,
	UnitDim3_CM,
	UnitPackQty,
	UnitPriceForeign,
	UnitWeight_KG
	FROM Product
	WHERE
	(@DurtyPercentage IS NULL OR DurtyPercentage=@DurtyPercentage)
	AND (@ImporterID IS NULL OR ImporterID=@ImporterID)
	AND (@LatestUpdateDT IS NULL OR LatestUpdateDT=@LatestUpdateDT)
	AND (@ProductCode IS NULL OR ProductCode=@ProductCode)
	AND (@ProductDescription IS NULL OR ProductDescription=@ProductDescription)
	AND (@ProductID IS NULL OR ProductID=@ProductID)
	AND (@ProductStatusID IS NULL OR ProductStatusID=@ProductStatusID)
	AND (@SupplierID IS NULL OR SupplierID=@SupplierID)
	AND (@SupplierProductCode IS NULL OR SupplierProductCode=@SupplierProductCode)
	AND (@TariffCode IS NULL OR TariffCode=@TariffCode)
	AND (@UnitDim1_CM IS NULL OR UnitDim1_CM=@UnitDim1_CM)
	AND (@UnitDim2_CM IS NULL OR UnitDim2_CM=@UnitDim2_CM)
	AND (@UnitDim3_CM IS NULL OR UnitDim3_CM=@UnitDim3_CM)
	AND (@UnitPackQty IS NULL OR UnitPackQty=@UnitPackQty)
	AND (@UnitPriceForeign IS NULL OR UnitPriceForeign=@UnitPriceForeign)
	AND (@UnitWeight_KG IS NULL OR UnitWeight_KG=@UnitWeight_KG)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN 'DurtyPercentage' THEN DurtyPercentage
		WHEN 'ImporterID' THEN ImporterID
		WHEN 'LatestUpdateDT' THEN LatestUpdateDT
		WHEN 'ProductCode' THEN ProductCode
		WHEN 'ProductDescription' THEN ProductDescription
		WHEN NULL THEN ProductID
		WHEN 'ProductID' THEN ProductID
		WHEN 'ProductStatusID' THEN ProductStatusID
		WHEN 'SupplierID' THEN SupplierID
		WHEN 'SupplierProductCode' THEN SupplierProductCode
		WHEN 'TariffCode' THEN TariffCode
		WHEN 'UnitDim1_CM' THEN UnitDim1_CM
		WHEN 'UnitDim2_CM' THEN UnitDim2_CM
		WHEN 'UnitDim3_CM' THEN UnitDim3_CM
		WHEN 'UnitPackQty' THEN UnitPackQty
		WHEN 'UnitPriceForeign' THEN UnitPriceForeign
		WHEN 'UnitWeight_KG' THEN UnitWeight_KG
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN 'DurtyPercentage' THEN DurtyPercentage
		WHEN 'ImporterID' THEN ImporterID
		WHEN 'LatestUpdateDT' THEN LatestUpdateDT
		WHEN 'ProductCode' THEN ProductCode
		WHEN 'ProductDescription' THEN ProductDescription
		WHEN NULL THEN ProductID
		WHEN 'ProductID' THEN ProductID
		WHEN 'ProductStatusID' THEN ProductStatusID
		WHEN 'SupplierID' THEN SupplierID
		WHEN 'SupplierProductCode' THEN SupplierProductCode
		WHEN 'TariffCode' THEN TariffCode
		WHEN 'UnitDim1_CM' THEN UnitDim1_CM
		WHEN 'UnitDim2_CM' THEN UnitDim2_CM
		WHEN 'UnitDim3_CM' THEN UnitDim3_CM
		WHEN 'UnitPackQty' THEN UnitPackQty
		WHEN 'UnitPriceForeign' THEN UnitPriceForeign
		WHEN 'UnitWeight_KG' THEN UnitWeight_KG
	END
	END
	DESC
END
GO

PRINT 'CREATE PROCEDURE : ProductDetailAZGet'
GO

IF OBJECT_ID(N'[dbo].[ProductDetailAZGet]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[ProductDetailAZGet]
GO

CREATE PROCEDURE [dbo].[ProductDetailAZGet]
	@BuyerID smallint=NULL,
	@ClaimsPercentage decimal(5,2)=NULL,
	@ContingencyPercentage decimal(5,2)=NULL,
	@FIFOPercentage decimal(5,2)=NULL,
	@IsHouse bit=NULL,
	@MarketingPercentage decimal(5,2)=NULL,
	@ProductID int=NULL,
	@UnitCDCPrice_ZAR money=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	BuyerID,
	ClaimsPercentage,
	ContingencyPercentage,
	FIFOPercentage,
	IsHouse,
	MarketingPercentage,
	ProductID,
	UnitCDCPrice_ZAR
	FROM ProductDetailAZ
	WHERE
	(@BuyerID IS NULL OR BuyerID=@BuyerID)
	AND (@ClaimsPercentage IS NULL OR ClaimsPercentage=@ClaimsPercentage)
	AND (@ContingencyPercentage IS NULL OR ContingencyPercentage=@ContingencyPercentage)
	AND (@FIFOPercentage IS NULL OR FIFOPercentage=@FIFOPercentage)
	AND (@IsHouse IS NULL OR IsHouse=@IsHouse)
	AND (@MarketingPercentage IS NULL OR MarketingPercentage=@MarketingPercentage)
	AND (@ProductID IS NULL OR ProductID=@ProductID)
	AND (@UnitCDCPrice_ZAR IS NULL OR UnitCDCPrice_ZAR=@UnitCDCPrice_ZAR)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN 'BuyerID' THEN BuyerID
		WHEN 'ClaimsPercentage' THEN ClaimsPercentage
		WHEN 'ContingencyPercentage' THEN ContingencyPercentage
		WHEN 'FIFOPercentage' THEN FIFOPercentage
		WHEN 'IsHouse' THEN IsHouse
		WHEN 'MarketingPercentage' THEN MarketingPercentage
		WHEN NULL THEN ProductID
		WHEN 'ProductID' THEN ProductID
		WHEN 'UnitCDCPrice_ZAR' THEN UnitCDCPrice_ZAR
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN 'BuyerID' THEN BuyerID
		WHEN 'ClaimsPercentage' THEN ClaimsPercentage
		WHEN 'ContingencyPercentage' THEN ContingencyPercentage
		WHEN 'FIFOPercentage' THEN FIFOPercentage
		WHEN 'IsHouse' THEN IsHouse
		WHEN 'MarketingPercentage' THEN MarketingPercentage
		WHEN NULL THEN ProductID
		WHEN 'ProductID' THEN ProductID
		WHEN 'UnitCDCPrice_ZAR' THEN UnitCDCPrice_ZAR
	END
	END
	DESC
END
GO

PRINT 'CREATE PROCEDURE : PurchaseOrderGet'
GO

IF OBJECT_ID(N'[dbo].[PurchaseOrderGet]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[PurchaseOrderGet]
GO

CREATE PROCEDURE [dbo].[PurchaseOrderGet]
	@BankID smallint=NULL,
	@BuyerID int=NULL,
	@BuyerRef varchar(50)=NULL,
	@CountryOriginID smallint=NULL,
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@FinalDestinationCode char(5)=NULL,
	@ImporterID int=NULL,
	@ImporterRef varchar(50)=NULL,
	@INCOTermCode char(3)=NULL,
	@LCNumber varchar(50)=NULL,
	@OrderDt datetime=NULL,
	@OrderID int=NULL,
	@OrderNo varchar(50)=NULL,
	@OrderStatusID tinyint=NULL,
	@PaymentDate datetime=NULL,
	@PaymentTermID tinyint=NULL,
	@PaymentTriggerID tinyint=NULL,
	@PaymentTypeID tinyint=NULL,
	@PlaceReceiptCode char(5)=NULL,
	@PortDischargeCode char(5)=NULL,
	@PortLoadingCode char(5)=NULL,
	@SupplierID int=NULL,
	@SupplierInvoiceCurrencyID smallint=NULL,
	@SupplierInvoiceRef varchar(50)=NULL,
	@SupplierInvoiceROE decimal(18,0)=NULL,
	@SupplierInvoiceValue decimal(18,0)=NULL,
	@SupplierRef varchar(50)=NULL,
	@TransportModeID tinyint=NULL,
	@UpdatedDt datetime=NULL,
	@UpdatedUserID smallint=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	BankID,
	BuyerID,
	BuyerRef,
	CountryOriginID,
	CreatedDt,
	CreatedUserID,
	FinalDestinationCode,
	ImporterID,
	ImporterRef,
	INCOTermCode,
	LCNumber,
	OrderDt,
	OrderID,
	OrderNo,
	OrderStatusID,
	PaymentDate,
	PaymentTermID,
	PaymentTriggerID,
	PaymentTypeID,
	PlaceReceiptCode,
	PortDischargeCode,
	PortLoadingCode,
	SupplierID,
	SupplierInvoiceCurrencyID,
	SupplierInvoiceRef,
	SupplierInvoiceROE,
	SupplierInvoiceValue,
	SupplierRef,
	TransportModeID,
	UpdatedDt,
	UpdatedUserID
	FROM PurchaseOrder
	WHERE
	(@BankID IS NULL OR BankID=@BankID)
	AND (@BuyerID IS NULL OR BuyerID=@BuyerID)
	AND (@BuyerRef IS NULL OR BuyerRef=@BuyerRef)
	AND (@CountryOriginID IS NULL OR CountryOriginID=@CountryOriginID)
	AND (@CreatedDt IS NULL OR CreatedDt=@CreatedDt)
	AND (@CreatedUserID IS NULL OR CreatedUserID=@CreatedUserID)
	AND (@FinalDestinationCode IS NULL OR FinalDestinationCode=@FinalDestinationCode)
	AND (@ImporterID IS NULL OR ImporterID=@ImporterID)
	AND (@ImporterRef IS NULL OR ImporterRef=@ImporterRef)
	AND (@INCOTermCode IS NULL OR INCOTermCode=@INCOTermCode)
	AND (@LCNumber IS NULL OR LCNumber=@LCNumber)
	AND (@OrderDt IS NULL OR OrderDt=@OrderDt)
	AND (@OrderID IS NULL OR OrderID=@OrderID)
	AND (@OrderNo IS NULL OR OrderNo=@OrderNo)
	AND (@OrderStatusID IS NULL OR OrderStatusID=@OrderStatusID)
	AND (@PaymentDate IS NULL OR PaymentDate=@PaymentDate)
	AND (@PaymentTermID IS NULL OR PaymentTermID=@PaymentTermID)
	AND (@PaymentTriggerID IS NULL OR PaymentTriggerID=@PaymentTriggerID)
	AND (@PaymentTypeID IS NULL OR PaymentTypeID=@PaymentTypeID)
	AND (@PlaceReceiptCode IS NULL OR PlaceReceiptCode=@PlaceReceiptCode)
	AND (@PortDischargeCode IS NULL OR PortDischargeCode=@PortDischargeCode)
	AND (@PortLoadingCode IS NULL OR PortLoadingCode=@PortLoadingCode)
	AND (@SupplierID IS NULL OR SupplierID=@SupplierID)
	AND (@SupplierInvoiceCurrencyID IS NULL OR SupplierInvoiceCurrencyID=@SupplierInvoiceCurrencyID)
	AND (@SupplierInvoiceRef IS NULL OR SupplierInvoiceRef=@SupplierInvoiceRef)
	AND (@SupplierInvoiceROE IS NULL OR SupplierInvoiceROE=@SupplierInvoiceROE)
	AND (@SupplierInvoiceValue IS NULL OR SupplierInvoiceValue=@SupplierInvoiceValue)
	AND (@SupplierRef IS NULL OR SupplierRef=@SupplierRef)
	AND (@TransportModeID IS NULL OR TransportModeID=@TransportModeID)
	AND (@UpdatedDt IS NULL OR UpdatedDt=@UpdatedDt)
	AND (@UpdatedUserID IS NULL OR UpdatedUserID=@UpdatedUserID)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN 'BankID' THEN BankID
		WHEN 'BuyerID' THEN BuyerID
		WHEN 'BuyerRef' THEN BuyerRef
		WHEN 'CountryOriginID' THEN CountryOriginID
		WHEN 'CreatedDt' THEN CreatedDt
		WHEN 'CreatedUserID' THEN CreatedUserID
		WHEN 'FinalDestinationCode' THEN FinalDestinationCode
		WHEN 'ImporterID' THEN ImporterID
		WHEN 'ImporterRef' THEN ImporterRef
		WHEN 'INCOTermCode' THEN INCOTermCode
		WHEN 'LCNumber' THEN LCNumber
		WHEN 'OrderDt' THEN OrderDt
		WHEN NULL THEN OrderID
		WHEN 'OrderID' THEN OrderID
		WHEN 'OrderNo' THEN OrderNo
		WHEN 'OrderStatusID' THEN OrderStatusID
		WHEN 'PaymentDate' THEN PaymentDate
		WHEN 'PaymentTermID' THEN PaymentTermID
		WHEN 'PaymentTriggerID' THEN PaymentTriggerID
		WHEN 'PaymentTypeID' THEN PaymentTypeID
		WHEN 'PlaceReceiptCode' THEN PlaceReceiptCode
		WHEN 'PortDischargeCode' THEN PortDischargeCode
		WHEN 'PortLoadingCode' THEN PortLoadingCode
		WHEN 'SupplierID' THEN SupplierID
		WHEN 'SupplierInvoiceCurrencyID' THEN SupplierInvoiceCurrencyID
		WHEN 'SupplierInvoiceRef' THEN SupplierInvoiceRef
		WHEN 'SupplierInvoiceROE' THEN SupplierInvoiceROE
		WHEN 'SupplierInvoiceValue' THEN SupplierInvoiceValue
		WHEN 'SupplierRef' THEN SupplierRef
		WHEN 'TransportModeID' THEN TransportModeID
		WHEN 'UpdatedDt' THEN UpdatedDt
		WHEN 'UpdatedUserID' THEN UpdatedUserID
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN 'BankID' THEN BankID
		WHEN 'BuyerID' THEN BuyerID
		WHEN 'BuyerRef' THEN BuyerRef
		WHEN 'CountryOriginID' THEN CountryOriginID
		WHEN 'CreatedDt' THEN CreatedDt
		WHEN 'CreatedUserID' THEN CreatedUserID
		WHEN 'FinalDestinationCode' THEN FinalDestinationCode
		WHEN 'ImporterID' THEN ImporterID
		WHEN 'ImporterRef' THEN ImporterRef
		WHEN 'INCOTermCode' THEN INCOTermCode
		WHEN 'LCNumber' THEN LCNumber
		WHEN 'OrderDt' THEN OrderDt
		WHEN NULL THEN OrderID
		WHEN 'OrderID' THEN OrderID
		WHEN 'OrderNo' THEN OrderNo
		WHEN 'OrderStatusID' THEN OrderStatusID
		WHEN 'PaymentDate' THEN PaymentDate
		WHEN 'PaymentTermID' THEN PaymentTermID
		WHEN 'PaymentTriggerID' THEN PaymentTriggerID
		WHEN 'PaymentTypeID' THEN PaymentTypeID
		WHEN 'PlaceReceiptCode' THEN PlaceReceiptCode
		WHEN 'PortDischargeCode' THEN PortDischargeCode
		WHEN 'PortLoadingCode' THEN PortLoadingCode
		WHEN 'SupplierID' THEN SupplierID
		WHEN 'SupplierInvoiceCurrencyID' THEN SupplierInvoiceCurrencyID
		WHEN 'SupplierInvoiceRef' THEN SupplierInvoiceRef
		WHEN 'SupplierInvoiceROE' THEN SupplierInvoiceROE
		WHEN 'SupplierInvoiceValue' THEN SupplierInvoiceValue
		WHEN 'SupplierRef' THEN SupplierRef
		WHEN 'TransportModeID' THEN TransportModeID
		WHEN 'UpdatedDt' THEN UpdatedDt
		WHEN 'UpdatedUserID' THEN UpdatedUserID
	END
	END
	DESC
END
GO

PRINT '-------------------------- Stored Procedures : INSERT --------------------------------'
GO

PRINT 'CREATE PROCEDURE : BusinessEntityInsert'
GO

IF OBJECT_ID(N'[dbo].[BusinessEntityInsert]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BusinessEntityInsert]
GO

CREATE PROCEDURE [dbo].[BusinessEntityInsert]
	@BusinessEntityCode varchar(10),
	@BusinessEntityName varchar(100),
	@BusinessEntityStatusID tinyint,
	@BusinessEntityTypeID tinyint,
	@VatNumber varchar(20)
AS
BEGIN
	INSERT BusinessEntity (
	BusinessEntityCode,
	BusinessEntityName,
	BusinessEntityStatusID,
	BusinessEntityTypeID,
	VatNumber
	) VALUES (
	@BusinessEntityCode,
	@BusinessEntityName,
	@BusinessEntityStatusID,
	@BusinessEntityTypeID,
	@VatNumber)
	
	
	
	SELECT SCOPE_IDENTITY()
END
GO

PRINT 'CREATE PROCEDURE : OrderLineInsert'
GO

IF OBJECT_ID(N'[dbo].[OrderLineInsert]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[OrderLineInsert]
GO

CREATE PROCEDURE [dbo].[OrderLineInsert]
	@CreatedDt datetime,
	@CreatedUserID smallint,
	@Description varchar(100),
	@DutyPercentage decimal(5,2),
	@DutyTypeID int,
	@OnSiteDt datetime,
	@OrderID int,
	@OrderLineStatusID tinyint,
	@ProductID int,
	@SupplierRefNo varchar(50),
	@TariffCode varchar(50),
	@TotalVolume decimal(18,2),
	@TotalWeight decimal(18,2),
	@UnitCurrencyID smallint,
	@UnitPrice money,
	@UnitQuantity smallint,
	@UnitTypeID tinyint,
	@UpdatedDt datetime,
	@UpdatedUserID smallint
AS
BEGIN
	INSERT OrderLine (
	CreatedDt,
	CreatedUserID,
	Description,
	DutyPercentage,
	DutyTypeID,
	OnSiteDt,
	OrderID,
	OrderLineStatusID,
	ProductID,
	SupplierRefNo,
	TariffCode,
	TotalVolume,
	TotalWeight,
	UnitCurrencyID,
	UnitPrice,
	UnitQuantity,
	UnitTypeID,
	UpdatedDt,
	UpdatedUserID
	) VALUES (
	@CreatedDt,
	@CreatedUserID,
	@Description,
	@DutyPercentage,
	@DutyTypeID,
	@OnSiteDt,
	@OrderID,
	@OrderLineStatusID,
	@ProductID,
	@SupplierRefNo,
	@TariffCode,
	@TotalVolume,
	@TotalWeight,
	@UnitCurrencyID,
	@UnitPrice,
	@UnitQuantity,
	@UnitTypeID,
	@UpdatedDt,
	@UpdatedUserID)
	
	
	
	SELECT SCOPE_IDENTITY()
END
GO

PRINT 'CREATE PROCEDURE : ProductInsert'
GO

IF OBJECT_ID(N'[dbo].[ProductInsert]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[ProductInsert]
GO

CREATE PROCEDURE [dbo].[ProductInsert]
	@DurtyPercentage decimal(5,2),
	@ImporterID int,
	@LatestUpdateDT datetime,
	@ProductCode varchar(50),
	@ProductDescription varchar(100),
	@ProductStatusID tinyint,
	@SupplierID int,
	@SupplierProductCode varchar(50),
	@TariffCode varchar(30),
	@UnitDim1_CM decimal(16,2),
	@UnitDim2_CM decimal(16,2),
	@UnitDim3_CM decimal(16,2),
	@UnitPackQty smallint,
	@UnitPriceForeign money,
	@UnitWeight_KG decimal(16,2)
AS
BEGIN
	INSERT Product (
	DurtyPercentage,
	ImporterID,
	LatestUpdateDT,
	ProductCode,
	ProductDescription,
	ProductStatusID,
	SupplierID,
	SupplierProductCode,
	TariffCode,
	UnitDim1_CM,
	UnitDim2_CM,
	UnitDim3_CM,
	UnitPackQty,
	UnitPriceForeign,
	UnitWeight_KG
	) VALUES (
	@DurtyPercentage,
	@ImporterID,
	@LatestUpdateDT,
	@ProductCode,
	@ProductDescription,
	@ProductStatusID,
	@SupplierID,
	@SupplierProductCode,
	@TariffCode,
	@UnitDim1_CM,
	@UnitDim2_CM,
	@UnitDim3_CM,
	@UnitPackQty,
	@UnitPriceForeign,
	@UnitWeight_KG)
	
	
	
	SELECT SCOPE_IDENTITY()
END
GO

PRINT 'CREATE PROCEDURE : ProductDetailAZInsert'
GO

IF OBJECT_ID(N'[dbo].[ProductDetailAZInsert]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[ProductDetailAZInsert]
GO

CREATE PROCEDURE [dbo].[ProductDetailAZInsert]
	@BuyerID smallint,
	@ClaimsPercentage decimal(5,2),
	@ContingencyPercentage decimal(5,2),
	@FIFOPercentage decimal(5,2),
	@IsHouse bit,
	@MarketingPercentage decimal(5,2),
	@UnitCDCPrice_ZAR money
AS
BEGIN
	INSERT ProductDetailAZ (
	BuyerID,
	ClaimsPercentage,
	ContingencyPercentage,
	FIFOPercentage,
	IsHouse,
	MarketingPercentage,
	UnitCDCPrice_ZAR
	) VALUES (
	@BuyerID,
	@ClaimsPercentage,
	@ContingencyPercentage,
	@FIFOPercentage,
	@IsHouse,
	@MarketingPercentage,
	@UnitCDCPrice_ZAR)
	
	
	
	SELECT SCOPE_IDENTITY()
END
GO

PRINT 'CREATE PROCEDURE : PurchaseOrderInsert'
GO

IF OBJECT_ID(N'[dbo].[PurchaseOrderInsert]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[PurchaseOrderInsert]
GO

CREATE PROCEDURE [dbo].[PurchaseOrderInsert]
	@BankID smallint,
	@BuyerID int,
	@BuyerRef varchar(50),
	@CountryOriginID smallint,
	@CreatedDt datetime,
	@CreatedUserID smallint,
	@FinalDestinationCode char(5),
	@ImporterID int,
	@ImporterRef varchar(50),
	@INCOTermCode char(3),
	@LCNumber varchar(50),
	@OrderDt datetime,
	@OrderNo varchar(50),
	@OrderStatusID tinyint,
	@PaymentDate datetime,
	@PaymentTermID tinyint,
	@PaymentTriggerID tinyint,
	@PaymentTypeID tinyint,
	@PlaceReceiptCode char(5),
	@PortDischargeCode char(5),
	@PortLoadingCode char(5),
	@SupplierID int,
	@SupplierInvoiceCurrencyID smallint,
	@SupplierInvoiceRef varchar(50),
	@SupplierInvoiceROE decimal(18,0),
	@SupplierInvoiceValue decimal(18,0),
	@SupplierRef varchar(50),
	@TransportModeID tinyint,
	@UpdatedDt datetime,
	@UpdatedUserID smallint
AS
BEGIN
	INSERT PurchaseOrder (
	BankID,
	BuyerID,
	BuyerRef,
	CountryOriginID,
	CreatedDt,
	CreatedUserID,
	FinalDestinationCode,
	ImporterID,
	ImporterRef,
	INCOTermCode,
	LCNumber,
	OrderDt,
	OrderNo,
	OrderStatusID,
	PaymentDate,
	PaymentTermID,
	PaymentTriggerID,
	PaymentTypeID,
	PlaceReceiptCode,
	PortDischargeCode,
	PortLoadingCode,
	SupplierID,
	SupplierInvoiceCurrencyID,
	SupplierInvoiceRef,
	SupplierInvoiceROE,
	SupplierInvoiceValue,
	SupplierRef,
	TransportModeID,
	UpdatedDt,
	UpdatedUserID
	) VALUES (
	@BankID,
	@BuyerID,
	@BuyerRef,
	@CountryOriginID,
	@CreatedDt,
	@CreatedUserID,
	@FinalDestinationCode,
	@ImporterID,
	@ImporterRef,
	@INCOTermCode,
	@LCNumber,
	@OrderDt,
	@OrderNo,
	@OrderStatusID,
	@PaymentDate,
	@PaymentTermID,
	@PaymentTriggerID,
	@PaymentTypeID,
	@PlaceReceiptCode,
	@PortDischargeCode,
	@PortLoadingCode,
	@SupplierID,
	@SupplierInvoiceCurrencyID,
	@SupplierInvoiceRef,
	@SupplierInvoiceROE,
	@SupplierInvoiceValue,
	@SupplierRef,
	@TransportModeID,
	@UpdatedDt,
	@UpdatedUserID)
	
	
	
	SELECT SCOPE_IDENTITY()
END
GO

PRINT '-------------------------- Stored Procedures : UPDATE --------------------------------'
GO

PRINT 'CREATE PROCEDURE : BusinessEntityUpdate'
GO

IF OBJECT_ID(N'[dbo].[BusinessEntityUpdate]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BusinessEntityUpdate]
GO

CREATE PROCEDURE [dbo].[BusinessEntityUpdate]
	@BusinessEntityCode varchar(10)=NULL,
	@BusinessEntityID int,
	@BusinessEntityName varchar(100)=NULL,
	@BusinessEntityStatusID tinyint=NULL,
	@BusinessEntityTypeID tinyint=NULL,
	@VatNumber varchar(20)=NULL,
	@CheckNull bit=NULL
AS
BEGIN
	IF @CheckNull IS NULL SET @CheckNull=0

	IF @CheckNull=1
	BEGIN
		UPDATE BusinessEntity SET
			BusinessEntityCode=ISNULL(@BusinessEntityCode, BusinessEntityCode),
			BusinessEntityName=ISNULL(@BusinessEntityName, BusinessEntityName),
			BusinessEntityStatusID=ISNULL(@BusinessEntityStatusID, BusinessEntityStatusID),
			BusinessEntityTypeID=ISNULL(@BusinessEntityTypeID, BusinessEntityTypeID),
			VatNumber=ISNULL(@VatNumber, VatNumber)
		WHERE
			BusinessEntityID=@BusinessEntityID
	END
	ELSE
	BEGIN
		UPDATE BusinessEntity SET
			BusinessEntityCode=@BusinessEntityCode,
			BusinessEntityName=@BusinessEntityName,
			BusinessEntityStatusID=@BusinessEntityStatusID,
			BusinessEntityTypeID=@BusinessEntityTypeID,
			VatNumber=@VatNumber
		WHERE
			BusinessEntityID=@BusinessEntityID
	END
END
GO

PRINT 'CREATE PROCEDURE : OrderLineUpdate'
GO

IF OBJECT_ID(N'[dbo].[OrderLineUpdate]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[OrderLineUpdate]
GO

CREATE PROCEDURE [dbo].[OrderLineUpdate]
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@Description varchar(100)=NULL,
	@DutyPercentage decimal(5,2)=NULL,
	@DutyTypeID int=NULL,
	@OnSiteDt datetime=NULL,
	@OrderID int=NULL,
	@OrderLineID int,
	@OrderLineStatusID tinyint=NULL,
	@ProductID int=NULL,
	@SupplierRefNo varchar(50)=NULL,
	@TariffCode varchar(50)=NULL,
	@TotalVolume decimal(18,2)=NULL,
	@TotalWeight decimal(18,2)=NULL,
	@UnitCurrencyID smallint=NULL,
	@UnitPrice money=NULL,
	@UnitQuantity smallint=NULL,
	@UnitTypeID tinyint=NULL,
	@UpdatedDt datetime=NULL,
	@UpdatedUserID smallint=NULL,
	@CheckNull bit=NULL
AS
BEGIN
	IF @CheckNull IS NULL SET @CheckNull=0

	IF @CheckNull=1
	BEGIN
		UPDATE OrderLine SET
			CreatedDt=ISNULL(@CreatedDt, CreatedDt),
			CreatedUserID=ISNULL(@CreatedUserID, CreatedUserID),
			Description=ISNULL(@Description, Description),
			DutyPercentage=ISNULL(@DutyPercentage, DutyPercentage),
			DutyTypeID=ISNULL(@DutyTypeID, DutyTypeID),
			OnSiteDt=ISNULL(@OnSiteDt, OnSiteDt),
			OrderID=ISNULL(@OrderID, OrderID),
			OrderLineStatusID=ISNULL(@OrderLineStatusID, OrderLineStatusID),
			ProductID=ISNULL(@ProductID, ProductID),
			SupplierRefNo=ISNULL(@SupplierRefNo, SupplierRefNo),
			TariffCode=ISNULL(@TariffCode, TariffCode),
			TotalVolume=ISNULL(@TotalVolume, TotalVolume),
			TotalWeight=ISNULL(@TotalWeight, TotalWeight),
			UnitCurrencyID=ISNULL(@UnitCurrencyID, UnitCurrencyID),
			UnitPrice=ISNULL(@UnitPrice, UnitPrice),
			UnitQuantity=ISNULL(@UnitQuantity, UnitQuantity),
			UnitTypeID=ISNULL(@UnitTypeID, UnitTypeID),
			UpdatedDt=ISNULL(@UpdatedDt, UpdatedDt),
			UpdatedUserID=ISNULL(@UpdatedUserID, UpdatedUserID)
		WHERE
			OrderLineID=@OrderLineID
	END
	ELSE
	BEGIN
		UPDATE OrderLine SET
			CreatedDt=@CreatedDt,
			CreatedUserID=@CreatedUserID,
			Description=@Description,
			DutyPercentage=@DutyPercentage,
			DutyTypeID=@DutyTypeID,
			OnSiteDt=@OnSiteDt,
			OrderID=@OrderID,
			OrderLineStatusID=@OrderLineStatusID,
			ProductID=@ProductID,
			SupplierRefNo=@SupplierRefNo,
			TariffCode=@TariffCode,
			TotalVolume=@TotalVolume,
			TotalWeight=@TotalWeight,
			UnitCurrencyID=@UnitCurrencyID,
			UnitPrice=@UnitPrice,
			UnitQuantity=@UnitQuantity,
			UnitTypeID=@UnitTypeID,
			UpdatedDt=@UpdatedDt,
			UpdatedUserID=@UpdatedUserID
		WHERE
			OrderLineID=@OrderLineID
	END
END
GO

PRINT 'CREATE PROCEDURE : ProductUpdate'
GO

IF OBJECT_ID(N'[dbo].[ProductUpdate]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[ProductUpdate]
GO

CREATE PROCEDURE [dbo].[ProductUpdate]
	@DurtyPercentage decimal(5,2)=NULL,
	@ImporterID int=NULL,
	@LatestUpdateDT datetime=NULL,
	@ProductCode varchar(50)=NULL,
	@ProductDescription varchar(100)=NULL,
	@ProductID int,
	@ProductStatusID tinyint=NULL,
	@SupplierID int=NULL,
	@SupplierProductCode varchar(50)=NULL,
	@TariffCode varchar(30)=NULL,
	@UnitDim1_CM decimal(16,2)=NULL,
	@UnitDim2_CM decimal(16,2)=NULL,
	@UnitDim3_CM decimal(16,2)=NULL,
	@UnitPackQty smallint=NULL,
	@UnitPriceForeign money=NULL,
	@UnitWeight_KG decimal(16,2)=NULL,
	@CheckNull bit=NULL
AS
BEGIN
	IF @CheckNull IS NULL SET @CheckNull=0

	IF @CheckNull=1
	BEGIN
		UPDATE Product SET
			DurtyPercentage=ISNULL(@DurtyPercentage, DurtyPercentage),
			ImporterID=ISNULL(@ImporterID, ImporterID),
			LatestUpdateDT=ISNULL(@LatestUpdateDT, LatestUpdateDT),
			ProductCode=ISNULL(@ProductCode, ProductCode),
			ProductDescription=ISNULL(@ProductDescription, ProductDescription),
			ProductStatusID=ISNULL(@ProductStatusID, ProductStatusID),
			SupplierID=ISNULL(@SupplierID, SupplierID),
			SupplierProductCode=ISNULL(@SupplierProductCode, SupplierProductCode),
			TariffCode=ISNULL(@TariffCode, TariffCode),
			UnitDim1_CM=ISNULL(@UnitDim1_CM, UnitDim1_CM),
			UnitDim2_CM=ISNULL(@UnitDim2_CM, UnitDim2_CM),
			UnitDim3_CM=ISNULL(@UnitDim3_CM, UnitDim3_CM),
			UnitPackQty=ISNULL(@UnitPackQty, UnitPackQty),
			UnitPriceForeign=ISNULL(@UnitPriceForeign, UnitPriceForeign),
			UnitWeight_KG=ISNULL(@UnitWeight_KG, UnitWeight_KG)
		WHERE
			ProductID=@ProductID
	END
	ELSE
	BEGIN
		UPDATE Product SET
			DurtyPercentage=@DurtyPercentage,
			ImporterID=@ImporterID,
			LatestUpdateDT=@LatestUpdateDT,
			ProductCode=@ProductCode,
			ProductDescription=@ProductDescription,
			ProductStatusID=@ProductStatusID,
			SupplierID=@SupplierID,
			SupplierProductCode=@SupplierProductCode,
			TariffCode=@TariffCode,
			UnitDim1_CM=@UnitDim1_CM,
			UnitDim2_CM=@UnitDim2_CM,
			UnitDim3_CM=@UnitDim3_CM,
			UnitPackQty=@UnitPackQty,
			UnitPriceForeign=@UnitPriceForeign,
			UnitWeight_KG=@UnitWeight_KG
		WHERE
			ProductID=@ProductID
	END
END
GO

PRINT 'CREATE PROCEDURE : ProductDetailAZUpdate'
GO

IF OBJECT_ID(N'[dbo].[ProductDetailAZUpdate]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[ProductDetailAZUpdate]
GO

CREATE PROCEDURE [dbo].[ProductDetailAZUpdate]
	@BuyerID smallint=NULL,
	@ClaimsPercentage decimal(5,2)=NULL,
	@ContingencyPercentage decimal(5,2)=NULL,
	@FIFOPercentage decimal(5,2)=NULL,
	@IsHouse bit=NULL,
	@MarketingPercentage decimal(5,2)=NULL,
	@ProductID int,
	@UnitCDCPrice_ZAR money=NULL,
	@CheckNull bit=NULL
AS
BEGIN
	IF @CheckNull IS NULL SET @CheckNull=0

	IF @CheckNull=1
	BEGIN
		UPDATE ProductDetailAZ SET
			BuyerID=ISNULL(@BuyerID, BuyerID),
			ClaimsPercentage=ISNULL(@ClaimsPercentage, ClaimsPercentage),
			ContingencyPercentage=ISNULL(@ContingencyPercentage, ContingencyPercentage),
			FIFOPercentage=ISNULL(@FIFOPercentage, FIFOPercentage),
			IsHouse=ISNULL(@IsHouse, IsHouse),
			MarketingPercentage=ISNULL(@MarketingPercentage, MarketingPercentage),
			UnitCDCPrice_ZAR=ISNULL(@UnitCDCPrice_ZAR, UnitCDCPrice_ZAR)
		WHERE
			ProductID=@ProductID
	END
	ELSE
	BEGIN
		UPDATE ProductDetailAZ SET
			BuyerID=@BuyerID,
			ClaimsPercentage=@ClaimsPercentage,
			ContingencyPercentage=@ContingencyPercentage,
			FIFOPercentage=@FIFOPercentage,
			IsHouse=@IsHouse,
			MarketingPercentage=@MarketingPercentage,
			UnitCDCPrice_ZAR=@UnitCDCPrice_ZAR
		WHERE
			ProductID=@ProductID
	END
END
GO

PRINT 'CREATE PROCEDURE : PurchaseOrderUpdate'
GO

IF OBJECT_ID(N'[dbo].[PurchaseOrderUpdate]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[PurchaseOrderUpdate]
GO

CREATE PROCEDURE [dbo].[PurchaseOrderUpdate]
	@BankID smallint=NULL,
	@BuyerID int=NULL,
	@BuyerRef varchar(50)=NULL,
	@CountryOriginID smallint=NULL,
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@FinalDestinationCode char(5)=NULL,
	@ImporterID int=NULL,
	@ImporterRef varchar(50)=NULL,
	@INCOTermCode char(3)=NULL,
	@LCNumber varchar(50)=NULL,
	@OrderDt datetime=NULL,
	@OrderID int,
	@OrderNo varchar(50)=NULL,
	@OrderStatusID tinyint=NULL,
	@PaymentDate datetime=NULL,
	@PaymentTermID tinyint=NULL,
	@PaymentTriggerID tinyint=NULL,
	@PaymentTypeID tinyint=NULL,
	@PlaceReceiptCode char(5)=NULL,
	@PortDischargeCode char(5)=NULL,
	@PortLoadingCode char(5)=NULL,
	@SupplierID int=NULL,
	@SupplierInvoiceCurrencyID smallint=NULL,
	@SupplierInvoiceRef varchar(50)=NULL,
	@SupplierInvoiceROE decimal(18,0)=NULL,
	@SupplierInvoiceValue decimal(18,0)=NULL,
	@SupplierRef varchar(50)=NULL,
	@TransportModeID tinyint=NULL,
	@UpdatedDt datetime=NULL,
	@UpdatedUserID smallint=NULL,
	@CheckNull bit=NULL
AS
BEGIN
	IF @CheckNull IS NULL SET @CheckNull=0

	IF @CheckNull=1
	BEGIN
		UPDATE PurchaseOrder SET
			BankID=ISNULL(@BankID, BankID),
			BuyerID=ISNULL(@BuyerID, BuyerID),
			BuyerRef=ISNULL(@BuyerRef, BuyerRef),
			CountryOriginID=ISNULL(@CountryOriginID, CountryOriginID),
			CreatedDt=ISNULL(@CreatedDt, CreatedDt),
			CreatedUserID=ISNULL(@CreatedUserID, CreatedUserID),
			FinalDestinationCode=ISNULL(@FinalDestinationCode, FinalDestinationCode),
			ImporterID=ISNULL(@ImporterID, ImporterID),
			ImporterRef=ISNULL(@ImporterRef, ImporterRef),
			INCOTermCode=ISNULL(@INCOTermCode, INCOTermCode),
			LCNumber=ISNULL(@LCNumber, LCNumber),
			OrderDt=ISNULL(@OrderDt, OrderDt),
			OrderNo=ISNULL(@OrderNo, OrderNo),
			OrderStatusID=ISNULL(@OrderStatusID, OrderStatusID),
			PaymentDate=ISNULL(@PaymentDate, PaymentDate),
			PaymentTermID=ISNULL(@PaymentTermID, PaymentTermID),
			PaymentTriggerID=ISNULL(@PaymentTriggerID, PaymentTriggerID),
			PaymentTypeID=ISNULL(@PaymentTypeID, PaymentTypeID),
			PlaceReceiptCode=ISNULL(@PlaceReceiptCode, PlaceReceiptCode),
			PortDischargeCode=ISNULL(@PortDischargeCode, PortDischargeCode),
			PortLoadingCode=ISNULL(@PortLoadingCode, PortLoadingCode),
			SupplierID=ISNULL(@SupplierID, SupplierID),
			SupplierInvoiceCurrencyID=ISNULL(@SupplierInvoiceCurrencyID, SupplierInvoiceCurrencyID),
			SupplierInvoiceRef=ISNULL(@SupplierInvoiceRef, SupplierInvoiceRef),
			SupplierInvoiceROE=ISNULL(@SupplierInvoiceROE, SupplierInvoiceROE),
			SupplierInvoiceValue=ISNULL(@SupplierInvoiceValue, SupplierInvoiceValue),
			SupplierRef=ISNULL(@SupplierRef, SupplierRef),
			TransportModeID=ISNULL(@TransportModeID, TransportModeID),
			UpdatedDt=ISNULL(@UpdatedDt, UpdatedDt),
			UpdatedUserID=ISNULL(@UpdatedUserID, UpdatedUserID)
		WHERE
			OrderID=@OrderID
	END
	ELSE
	BEGIN
		UPDATE PurchaseOrder SET
			BankID=@BankID,
			BuyerID=@BuyerID,
			BuyerRef=@BuyerRef,
			CountryOriginID=@CountryOriginID,
			CreatedDt=@CreatedDt,
			CreatedUserID=@CreatedUserID,
			FinalDestinationCode=@FinalDestinationCode,
			ImporterID=@ImporterID,
			ImporterRef=@ImporterRef,
			INCOTermCode=@INCOTermCode,
			LCNumber=@LCNumber,
			OrderDt=@OrderDt,
			OrderNo=@OrderNo,
			OrderStatusID=@OrderStatusID,
			PaymentDate=@PaymentDate,
			PaymentTermID=@PaymentTermID,
			PaymentTriggerID=@PaymentTriggerID,
			PaymentTypeID=@PaymentTypeID,
			PlaceReceiptCode=@PlaceReceiptCode,
			PortDischargeCode=@PortDischargeCode,
			PortLoadingCode=@PortLoadingCode,
			SupplierID=@SupplierID,
			SupplierInvoiceCurrencyID=@SupplierInvoiceCurrencyID,
			SupplierInvoiceRef=@SupplierInvoiceRef,
			SupplierInvoiceROE=@SupplierInvoiceROE,
			SupplierInvoiceValue=@SupplierInvoiceValue,
			SupplierRef=@SupplierRef,
			TransportModeID=@TransportModeID,
			UpdatedDt=@UpdatedDt,
			UpdatedUserID=@UpdatedUserID
		WHERE
			OrderID=@OrderID
	END
END
GO

PRINT '-------------------------- Stored Procedures : DELETE --------------------------------'
GO

PRINT 'CREATE PROCEDURE : BusinessEntityDelete'
GO

IF OBJECT_ID(N'[dbo].[BusinessEntityDelete]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BusinessEntityDelete]
GO

CREATE PROCEDURE [dbo].[BusinessEntityDelete]
	@BusinessEntityCode varchar(10)=NULL,
	@BusinessEntityID int=NULL,
	@BusinessEntityName varchar(100)=NULL,
	@BusinessEntityStatusID tinyint=NULL,
	@BusinessEntityTypeID tinyint=NULL,
	@VatNumber varchar(20)=NULL
AS
BEGIN
	DELETE BusinessEntity
	WHERE
	(@BusinessEntityCode IS NULL OR BusinessEntityCode=@BusinessEntityCode)
	AND (@BusinessEntityID IS NULL OR BusinessEntityID=@BusinessEntityID)
	AND (@BusinessEntityName IS NULL OR BusinessEntityName=@BusinessEntityName)
	AND (@BusinessEntityStatusID IS NULL OR BusinessEntityStatusID=@BusinessEntityStatusID)
	AND (@BusinessEntityTypeID IS NULL OR BusinessEntityTypeID=@BusinessEntityTypeID)
	AND (@VatNumber IS NULL OR VatNumber=@VatNumber)
END
GO

PRINT 'CREATE PROCEDURE : OrderLineDelete'
GO

IF OBJECT_ID(N'[dbo].[OrderLineDelete]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[OrderLineDelete]
GO

CREATE PROCEDURE [dbo].[OrderLineDelete]
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@Description varchar(100)=NULL,
	@DutyPercentage decimal(5,2)=NULL,
	@DutyTypeID int=NULL,
	@OnSiteDt datetime=NULL,
	@OrderID int=NULL,
	@OrderLineID int=NULL,
	@OrderLineStatusID tinyint=NULL,
	@ProductID int=NULL,
	@SupplierRefNo varchar(50)=NULL,
	@TariffCode varchar(50)=NULL,
	@TotalVolume decimal(18,2)=NULL,
	@TotalWeight decimal(18,2)=NULL,
	@UnitCurrencyID smallint=NULL,
	@UnitPrice money=NULL,
	@UnitQuantity smallint=NULL,
	@UnitTypeID tinyint=NULL,
	@UpdatedDt datetime=NULL,
	@UpdatedUserID smallint=NULL
AS
BEGIN
	DELETE OrderLine
	WHERE
	(@CreatedDt IS NULL OR CreatedDt=@CreatedDt)
	AND (@CreatedUserID IS NULL OR CreatedUserID=@CreatedUserID)
	AND (@Description IS NULL OR Description=@Description)
	AND (@DutyPercentage IS NULL OR DutyPercentage=@DutyPercentage)
	AND (@DutyTypeID IS NULL OR DutyTypeID=@DutyTypeID)
	AND (@OnSiteDt IS NULL OR OnSiteDt=@OnSiteDt)
	AND (@OrderID IS NULL OR OrderID=@OrderID)
	AND (@OrderLineID IS NULL OR OrderLineID=@OrderLineID)
	AND (@OrderLineStatusID IS NULL OR OrderLineStatusID=@OrderLineStatusID)
	AND (@ProductID IS NULL OR ProductID=@ProductID)
	AND (@SupplierRefNo IS NULL OR SupplierRefNo=@SupplierRefNo)
	AND (@TariffCode IS NULL OR TariffCode=@TariffCode)
	AND (@TotalVolume IS NULL OR TotalVolume=@TotalVolume)
	AND (@TotalWeight IS NULL OR TotalWeight=@TotalWeight)
	AND (@UnitCurrencyID IS NULL OR UnitCurrencyID=@UnitCurrencyID)
	AND (@UnitPrice IS NULL OR UnitPrice=@UnitPrice)
	AND (@UnitQuantity IS NULL OR UnitQuantity=@UnitQuantity)
	AND (@UnitTypeID IS NULL OR UnitTypeID=@UnitTypeID)
	AND (@UpdatedDt IS NULL OR UpdatedDt=@UpdatedDt)
	AND (@UpdatedUserID IS NULL OR UpdatedUserID=@UpdatedUserID)
END
GO

PRINT 'CREATE PROCEDURE : ProductDelete'
GO

IF OBJECT_ID(N'[dbo].[ProductDelete]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[ProductDelete]
GO

CREATE PROCEDURE [dbo].[ProductDelete]
	@DurtyPercentage decimal(5,2)=NULL,
	@ImporterID int=NULL,
	@LatestUpdateDT datetime=NULL,
	@ProductCode varchar(50)=NULL,
	@ProductDescription varchar(100)=NULL,
	@ProductID int=NULL,
	@ProductStatusID tinyint=NULL,
	@SupplierID int=NULL,
	@SupplierProductCode varchar(50)=NULL,
	@TariffCode varchar(30)=NULL,
	@UnitDim1_CM decimal(16,2)=NULL,
	@UnitDim2_CM decimal(16,2)=NULL,
	@UnitDim3_CM decimal(16,2)=NULL,
	@UnitPackQty smallint=NULL,
	@UnitPriceForeign money=NULL,
	@UnitWeight_KG decimal(16,2)=NULL
AS
BEGIN
	DELETE Product
	WHERE
	(@DurtyPercentage IS NULL OR DurtyPercentage=@DurtyPercentage)
	AND (@ImporterID IS NULL OR ImporterID=@ImporterID)
	AND (@LatestUpdateDT IS NULL OR LatestUpdateDT=@LatestUpdateDT)
	AND (@ProductCode IS NULL OR ProductCode=@ProductCode)
	AND (@ProductDescription IS NULL OR ProductDescription=@ProductDescription)
	AND (@ProductID IS NULL OR ProductID=@ProductID)
	AND (@ProductStatusID IS NULL OR ProductStatusID=@ProductStatusID)
	AND (@SupplierID IS NULL OR SupplierID=@SupplierID)
	AND (@SupplierProductCode IS NULL OR SupplierProductCode=@SupplierProductCode)
	AND (@TariffCode IS NULL OR TariffCode=@TariffCode)
	AND (@UnitDim1_CM IS NULL OR UnitDim1_CM=@UnitDim1_CM)
	AND (@UnitDim2_CM IS NULL OR UnitDim2_CM=@UnitDim2_CM)
	AND (@UnitDim3_CM IS NULL OR UnitDim3_CM=@UnitDim3_CM)
	AND (@UnitPackQty IS NULL OR UnitPackQty=@UnitPackQty)
	AND (@UnitPriceForeign IS NULL OR UnitPriceForeign=@UnitPriceForeign)
	AND (@UnitWeight_KG IS NULL OR UnitWeight_KG=@UnitWeight_KG)
END
GO

PRINT 'CREATE PROCEDURE : ProductDetailAZDelete'
GO

IF OBJECT_ID(N'[dbo].[ProductDetailAZDelete]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[ProductDetailAZDelete]
GO

CREATE PROCEDURE [dbo].[ProductDetailAZDelete]
	@BuyerID smallint=NULL,
	@ClaimsPercentage decimal(5,2)=NULL,
	@ContingencyPercentage decimal(5,2)=NULL,
	@FIFOPercentage decimal(5,2)=NULL,
	@IsHouse bit=NULL,
	@MarketingPercentage decimal(5,2)=NULL,
	@ProductID int=NULL,
	@UnitCDCPrice_ZAR money=NULL
AS
BEGIN
	DELETE ProductDetailAZ
	WHERE
	(@BuyerID IS NULL OR BuyerID=@BuyerID)
	AND (@ClaimsPercentage IS NULL OR ClaimsPercentage=@ClaimsPercentage)
	AND (@ContingencyPercentage IS NULL OR ContingencyPercentage=@ContingencyPercentage)
	AND (@FIFOPercentage IS NULL OR FIFOPercentage=@FIFOPercentage)
	AND (@IsHouse IS NULL OR IsHouse=@IsHouse)
	AND (@MarketingPercentage IS NULL OR MarketingPercentage=@MarketingPercentage)
	AND (@ProductID IS NULL OR ProductID=@ProductID)
	AND (@UnitCDCPrice_ZAR IS NULL OR UnitCDCPrice_ZAR=@UnitCDCPrice_ZAR)
END
GO

PRINT 'CREATE PROCEDURE : PurchaseOrderDelete'
GO

IF OBJECT_ID(N'[dbo].[PurchaseOrderDelete]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[PurchaseOrderDelete]
GO

CREATE PROCEDURE [dbo].[PurchaseOrderDelete]
	@BankID smallint=NULL,
	@BuyerID int=NULL,
	@BuyerRef varchar(50)=NULL,
	@CountryOriginID smallint=NULL,
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@FinalDestinationCode char(5)=NULL,
	@ImporterID int=NULL,
	@ImporterRef varchar(50)=NULL,
	@INCOTermCode char(3)=NULL,
	@LCNumber varchar(50)=NULL,
	@OrderDt datetime=NULL,
	@OrderID int=NULL,
	@OrderNo varchar(50)=NULL,
	@OrderStatusID tinyint=NULL,
	@PaymentDate datetime=NULL,
	@PaymentTermID tinyint=NULL,
	@PaymentTriggerID tinyint=NULL,
	@PaymentTypeID tinyint=NULL,
	@PlaceReceiptCode char(5)=NULL,
	@PortDischargeCode char(5)=NULL,
	@PortLoadingCode char(5)=NULL,
	@SupplierID int=NULL,
	@SupplierInvoiceCurrencyID smallint=NULL,
	@SupplierInvoiceRef varchar(50)=NULL,
	@SupplierInvoiceROE decimal(18,0)=NULL,
	@SupplierInvoiceValue decimal(18,0)=NULL,
	@SupplierRef varchar(50)=NULL,
	@TransportModeID tinyint=NULL,
	@UpdatedDt datetime=NULL,
	@UpdatedUserID smallint=NULL
AS
BEGIN
	DELETE PurchaseOrder
	WHERE
	(@BankID IS NULL OR BankID=@BankID)
	AND (@BuyerID IS NULL OR BuyerID=@BuyerID)
	AND (@BuyerRef IS NULL OR BuyerRef=@BuyerRef)
	AND (@CountryOriginID IS NULL OR CountryOriginID=@CountryOriginID)
	AND (@CreatedDt IS NULL OR CreatedDt=@CreatedDt)
	AND (@CreatedUserID IS NULL OR CreatedUserID=@CreatedUserID)
	AND (@FinalDestinationCode IS NULL OR FinalDestinationCode=@FinalDestinationCode)
	AND (@ImporterID IS NULL OR ImporterID=@ImporterID)
	AND (@ImporterRef IS NULL OR ImporterRef=@ImporterRef)
	AND (@INCOTermCode IS NULL OR INCOTermCode=@INCOTermCode)
	AND (@LCNumber IS NULL OR LCNumber=@LCNumber)
	AND (@OrderDt IS NULL OR OrderDt=@OrderDt)
	AND (@OrderID IS NULL OR OrderID=@OrderID)
	AND (@OrderNo IS NULL OR OrderNo=@OrderNo)
	AND (@OrderStatusID IS NULL OR OrderStatusID=@OrderStatusID)
	AND (@PaymentDate IS NULL OR PaymentDate=@PaymentDate)
	AND (@PaymentTermID IS NULL OR PaymentTermID=@PaymentTermID)
	AND (@PaymentTriggerID IS NULL OR PaymentTriggerID=@PaymentTriggerID)
	AND (@PaymentTypeID IS NULL OR PaymentTypeID=@PaymentTypeID)
	AND (@PlaceReceiptCode IS NULL OR PlaceReceiptCode=@PlaceReceiptCode)
	AND (@PortDischargeCode IS NULL OR PortDischargeCode=@PortDischargeCode)
	AND (@PortLoadingCode IS NULL OR PortLoadingCode=@PortLoadingCode)
	AND (@SupplierID IS NULL OR SupplierID=@SupplierID)
	AND (@SupplierInvoiceCurrencyID IS NULL OR SupplierInvoiceCurrencyID=@SupplierInvoiceCurrencyID)
	AND (@SupplierInvoiceRef IS NULL OR SupplierInvoiceRef=@SupplierInvoiceRef)
	AND (@SupplierInvoiceROE IS NULL OR SupplierInvoiceROE=@SupplierInvoiceROE)
	AND (@SupplierInvoiceValue IS NULL OR SupplierInvoiceValue=@SupplierInvoiceValue)
	AND (@SupplierRef IS NULL OR SupplierRef=@SupplierRef)
	AND (@TransportModeID IS NULL OR TransportModeID=@TransportModeID)
	AND (@UpdatedDt IS NULL OR UpdatedDt=@UpdatedDt)
	AND (@UpdatedUserID IS NULL OR UpdatedUserID=@UpdatedUserID)
END
GO

