PRINT '-------------------------- Stored Procedures : SELECT --------------------------------'
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
	@OnSiteDt datetime=NULL,
	@OrderID int=NULL,
	@OrderLineID int=NULL,
	@OrderLineStatusID tinyint=NULL,
	@ProductID int=NULL,
	@SupplierRefNo varchar(50)=NULL,
	@TariffCode varchar(15)=NULL,
	@TotalVolume decimal(18,2)=NULL,
	@TotalWeight decimal(18,2)=NULL,
	@UnitCurrencyID smallint=NULL,
	@UnitPrice money=NULL,
	@UnitQuantity int=NULL,
	@UnitTypeID tinyint=NULL,
	@UpdatedDt datetime=NULL,
	@UpdatedUserID smallint=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder tinyint=NULL
AS
BEGIN
	
	SET NOCOUNT ON;

SELECT
	CreatedDt,
	CreatedUserID,
	Description,
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
	ORDER BY 
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN 'CreatedUserID' THEN CreatedUserID
			 WHEN 'OrderID' THEN OrderID
			 WHEN 'OrderLineID' THEN OrderLineID
			 WHEN 'OrderLineStatusID' THEN OrderLineStatusID
			 WHEN 'ProductID' THEN ProductID
			 WHEN 'TotalVolume' THEN TotalVolume
			 WHEN 'TotalWeight' THEN TotalWeight
			 WHEN 'UnitCurrencyID' THEN UnitCurrencyID
			 WHEN 'UnitPrice' THEN UnitPrice
			 WHEN 'UnitQuantity' THEN UnitQuantity
			 WHEN 'UnitTypeID' THEN UnitTypeID
			 WHEN 'UpdatedUserID' THEN UpdatedUserID
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN 'Description' THEN Description
			 WHEN 'SupplierRefNo' THEN SupplierRefNo
			 WHEN 'TariffCode' THEN TariffCode
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN 'CreatedDt' THEN CreatedDt
			 WHEN 'OnSiteDt' THEN OnSiteDt
			 WHEN 'UpdatedDt' THEN UpdatedDt
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN 'CreatedUserID' THEN CreatedUserID
			 WHEN 'OrderID' THEN OrderID
			 WHEN 'OrderLineID' THEN OrderLineID
			 WHEN 'OrderLineStatusID' THEN OrderLineStatusID
			 WHEN 'ProductID' THEN ProductID
			 WHEN 'TotalVolume' THEN TotalVolume
			 WHEN 'TotalWeight' THEN TotalWeight
			 WHEN 'UnitCurrencyID' THEN UnitCurrencyID
			 WHEN 'UnitPrice' THEN UnitPrice
			 WHEN 'UnitQuantity' THEN UnitQuantity
			 WHEN 'UnitTypeID' THEN UnitTypeID
			 WHEN 'UpdatedUserID' THEN UpdatedUserID
		 END
	 END
	 DESC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN 'Description' THEN Description
			 WHEN 'SupplierRefNo' THEN SupplierRefNo
			 WHEN 'TariffCode' THEN TariffCode
		 END
	 END
	 DESC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN 'CreatedDt' THEN CreatedDt
			 WHEN 'OnSiteDt' THEN OnSiteDt
			 WHEN 'UpdatedDt' THEN UpdatedDt
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
	@CountryOriginID smallint=NULL,
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@FinalDestinationCode char(5)=NULL,
	@ImporterID int=NULL,
	@ImporterRef varchar(50)=NULL,
	@INCOTermCode char(3)=NULL,
	@OrderDt datetime=NULL,
	@OrderID int=NULL,
	@OrderNo varchar(50)=NULL,
	@OrderStatusID tinyint=NULL,
	@PaymentDate datetime=NULL,
	@PaymentTermID tinyint=NULL,
	@PaymentTriggerID tinyint=NULL,
	@PaymentTypeID tinyint=NULL,
	@PlaceReceiptCode char(5)=NULL,
	@PlannedDt datetime=NULL,
	@PortDischargeCode char(5)=NULL,
	@PortLoadingCode char(5)=NULL,
	@SpotROE decimal(18,4)=NULL,
	@SupplierID int=NULL,
	@SupplierRef varchar(50)=NULL,
	@TransportModeID tinyint=NULL,
	@UpdatedDt datetime=NULL,
	@UpdatedUserID smallint=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder tinyint=NULL
AS
BEGIN
	
	SET NOCOUNT ON;

SELECT
	CountryOriginID,
	CreatedDt,
	CreatedUserID,
	FinalDestinationCode,
	ImporterID,
	ImporterRef,
	INCOTermCode,
	OrderDt,
	OrderID,
	OrderNo,
	OrderStatusID,
	PaymentDate,
	PaymentTermID,
	PaymentTriggerID,
	PaymentTypeID,
	PlaceReceiptCode,
	PlannedDt,
	PortDischargeCode,
	PortLoadingCode,
	SpotROE,
	SupplierID,
	SupplierRef,
	TransportModeID,
	UpdatedDt,
	UpdatedUserID
	FROM PurchaseOrder
	WHERE
	(@CountryOriginID IS NULL OR CountryOriginID=@CountryOriginID)
	AND (@CreatedDt IS NULL OR CreatedDt=@CreatedDt)
	AND (@CreatedUserID IS NULL OR CreatedUserID=@CreatedUserID)
	AND (@FinalDestinationCode IS NULL OR FinalDestinationCode=@FinalDestinationCode)
	AND (@ImporterID IS NULL OR ImporterID=@ImporterID)
	AND (@ImporterRef IS NULL OR ImporterRef=@ImporterRef)
	AND (@INCOTermCode IS NULL OR INCOTermCode=@INCOTermCode)
	AND (@OrderDt IS NULL OR OrderDt=@OrderDt)
	AND (@OrderID IS NULL OR OrderID=@OrderID)
	AND (@OrderNo IS NULL OR OrderNo=@OrderNo)
	AND (@OrderStatusID IS NULL OR OrderStatusID=@OrderStatusID)
	AND (@PaymentDate IS NULL OR PaymentDate=@PaymentDate)
	AND (@PaymentTermID IS NULL OR PaymentTermID=@PaymentTermID)
	AND (@PaymentTriggerID IS NULL OR PaymentTriggerID=@PaymentTriggerID)
	AND (@PaymentTypeID IS NULL OR PaymentTypeID=@PaymentTypeID)
	AND (@PlaceReceiptCode IS NULL OR PlaceReceiptCode=@PlaceReceiptCode)
	AND (@PlannedDt IS NULL OR PlannedDt=@PlannedDt)
	AND (@PortDischargeCode IS NULL OR PortDischargeCode=@PortDischargeCode)
	AND (@PortLoadingCode IS NULL OR PortLoadingCode=@PortLoadingCode)
	AND (@SpotROE IS NULL OR SpotROE=@SpotROE)
	AND (@SupplierID IS NULL OR SupplierID=@SupplierID)
	AND (@SupplierRef IS NULL OR SupplierRef=@SupplierRef)
	AND (@TransportModeID IS NULL OR TransportModeID=@TransportModeID)
	AND (@UpdatedDt IS NULL OR UpdatedDt=@UpdatedDt)
	AND (@UpdatedUserID IS NULL OR UpdatedUserID=@UpdatedUserID)
	ORDER BY 
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN 'CountryOriginID' THEN CountryOriginID
			 WHEN 'CreatedUserID' THEN CreatedUserID
			 WHEN 'ImporterID' THEN ImporterID
			 WHEN 'OrderID' THEN OrderID
			 WHEN 'OrderStatusID' THEN OrderStatusID
			 WHEN 'PaymentTermID' THEN PaymentTermID
			 WHEN 'PaymentTriggerID' THEN PaymentTriggerID
			 WHEN 'PaymentTypeID' THEN PaymentTypeID
			 WHEN 'SpotROE' THEN SpotROE
			 WHEN 'SupplierID' THEN SupplierID
			 WHEN 'TransportModeID' THEN TransportModeID
			 WHEN 'UpdatedUserID' THEN UpdatedUserID
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN 'FinalDestinationCode' THEN FinalDestinationCode
			 WHEN 'ImporterRef' THEN ImporterRef
			 WHEN 'INCOTermCode' THEN INCOTermCode
			 WHEN 'OrderNo' THEN OrderNo
			 WHEN 'PlaceReceiptCode' THEN PlaceReceiptCode
			 WHEN 'PortDischargeCode' THEN PortDischargeCode
			 WHEN 'PortLoadingCode' THEN PortLoadingCode
			 WHEN 'SupplierRef' THEN SupplierRef
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN 'CreatedDt' THEN CreatedDt
			 WHEN 'OrderDt' THEN OrderDt
			 WHEN 'PaymentDate' THEN PaymentDate
			 WHEN 'PlannedDt' THEN PlannedDt
			 WHEN 'UpdatedDt' THEN UpdatedDt
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN 'CountryOriginID' THEN CountryOriginID
			 WHEN 'CreatedUserID' THEN CreatedUserID
			 WHEN 'ImporterID' THEN ImporterID
			 WHEN 'OrderID' THEN OrderID
			 WHEN 'OrderStatusID' THEN OrderStatusID
			 WHEN 'PaymentTermID' THEN PaymentTermID
			 WHEN 'PaymentTriggerID' THEN PaymentTriggerID
			 WHEN 'PaymentTypeID' THEN PaymentTypeID
			 WHEN 'SpotROE' THEN SpotROE
			 WHEN 'SupplierID' THEN SupplierID
			 WHEN 'TransportModeID' THEN TransportModeID
			 WHEN 'UpdatedUserID' THEN UpdatedUserID
		 END
	 END
	 DESC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN 'FinalDestinationCode' THEN FinalDestinationCode
			 WHEN 'ImporterRef' THEN ImporterRef
			 WHEN 'INCOTermCode' THEN INCOTermCode
			 WHEN 'OrderNo' THEN OrderNo
			 WHEN 'PlaceReceiptCode' THEN PlaceReceiptCode
			 WHEN 'PortDischargeCode' THEN PortDischargeCode
			 WHEN 'PortLoadingCode' THEN PortLoadingCode
			 WHEN 'SupplierRef' THEN SupplierRef
		 END
	 END
	 DESC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN 'CreatedDt' THEN CreatedDt
			 WHEN 'OrderDt' THEN OrderDt
			 WHEN 'PaymentDate' THEN PaymentDate
			 WHEN 'PlannedDt' THEN PlannedDt
			 WHEN 'UpdatedDt' THEN UpdatedDt
		 END
	 END
	 DESC
END
GO

PRINT '-------------------------- Stored Procedures : INSERT --------------------------------'
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
	@OnSiteDt datetime,
	@OrderID int,
	@OrderLineStatusID tinyint,
	@ProductID int,
	@SupplierRefNo varchar(50),
	@TariffCode varchar(15),
	@TotalVolume decimal(18,2),
	@TotalWeight decimal(18,2),
	@UnitCurrencyID smallint,
	@UnitPrice money,
	@UnitQuantity int,
	@UnitTypeID tinyint,
	@UpdatedDt datetime,
	@UpdatedUserID smallint
AS
BEGIN
	INSERT OrderLine (
	CreatedDt,
	CreatedUserID,
	Description,
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

PRINT 'CREATE PROCEDURE : PurchaseOrderInsert'
GO

IF OBJECT_ID(N'[dbo].[PurchaseOrderInsert]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[PurchaseOrderInsert]
GO

CREATE PROCEDURE [dbo].[PurchaseOrderInsert]
	@CountryOriginID smallint,
	@CreatedDt datetime,
	@CreatedUserID smallint,
	@FinalDestinationCode char(5),
	@ImporterID int,
	@ImporterRef varchar(50),
	@INCOTermCode char(3),
	@OrderDt datetime,
	@OrderNo varchar(50),
	@OrderStatusID tinyint,
	@PaymentDate datetime,
	@PaymentTermID tinyint,
	@PaymentTriggerID tinyint,
	@PaymentTypeID tinyint,
	@PlaceReceiptCode char(5),
	@PlannedDt datetime,
	@PortDischargeCode char(5),
	@PortLoadingCode char(5),
	@SpotROE decimal(18,4),
	@SupplierID int,
	@SupplierRef varchar(50),
	@TransportModeID tinyint,
	@UpdatedDt datetime,
	@UpdatedUserID smallint
AS
BEGIN
	INSERT PurchaseOrder (
	CountryOriginID,
	CreatedDt,
	CreatedUserID,
	FinalDestinationCode,
	ImporterID,
	ImporterRef,
	INCOTermCode,
	OrderDt,
	OrderNo,
	OrderStatusID,
	PaymentDate,
	PaymentTermID,
	PaymentTriggerID,
	PaymentTypeID,
	PlaceReceiptCode,
	PlannedDt,
	PortDischargeCode,
	PortLoadingCode,
	SpotROE,
	SupplierID,
	SupplierRef,
	TransportModeID,
	UpdatedDt,
	UpdatedUserID
	) VALUES (
	@CountryOriginID,
	@CreatedDt,
	@CreatedUserID,
	@FinalDestinationCode,
	@ImporterID,
	@ImporterRef,
	@INCOTermCode,
	@OrderDt,
	@OrderNo,
	@OrderStatusID,
	@PaymentDate,
	@PaymentTermID,
	@PaymentTriggerID,
	@PaymentTypeID,
	@PlaceReceiptCode,
	@PlannedDt,
	@PortDischargeCode,
	@PortLoadingCode,
	@SpotROE,
	@SupplierID,
	@SupplierRef,
	@TransportModeID,
	@UpdatedDt,
	@UpdatedUserID)
	
	
	
	SELECT SCOPE_IDENTITY()
END
GO

PRINT '-------------------------- Stored Procedures : UPDATE --------------------------------'
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
	@OnSiteDt datetime=NULL,
	@OrderID int=NULL,
	@OrderLineID int,
	@OrderLineStatusID tinyint=NULL,
	@ProductID int=NULL,
	@SupplierRefNo varchar(50)=NULL,
	@TariffCode varchar(15)=NULL,
	@TotalVolume decimal(18,2)=NULL,
	@TotalWeight decimal(18,2)=NULL,
	@UnitCurrencyID smallint=NULL,
	@UnitPrice money=NULL,
	@UnitQuantity int=NULL,
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

PRINT 'CREATE PROCEDURE : PurchaseOrderUpdate'
GO

IF OBJECT_ID(N'[dbo].[PurchaseOrderUpdate]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[PurchaseOrderUpdate]
GO

CREATE PROCEDURE [dbo].[PurchaseOrderUpdate]
	@CountryOriginID smallint=NULL,
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@FinalDestinationCode char(5)=NULL,
	@ImporterID int=NULL,
	@ImporterRef varchar(50)=NULL,
	@INCOTermCode char(3)=NULL,
	@OrderDt datetime=NULL,
	@OrderID int,
	@OrderNo varchar(50)=NULL,
	@OrderStatusID tinyint=NULL,
	@PaymentDate datetime=NULL,
	@PaymentTermID tinyint=NULL,
	@PaymentTriggerID tinyint=NULL,
	@PaymentTypeID tinyint=NULL,
	@PlaceReceiptCode char(5)=NULL,
	@PlannedDt datetime=NULL,
	@PortDischargeCode char(5)=NULL,
	@PortLoadingCode char(5)=NULL,
	@SpotROE decimal(18,4)=NULL,
	@SupplierID int=NULL,
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
			CountryOriginID=ISNULL(@CountryOriginID, CountryOriginID),
			CreatedDt=ISNULL(@CreatedDt, CreatedDt),
			CreatedUserID=ISNULL(@CreatedUserID, CreatedUserID),
			FinalDestinationCode=ISNULL(@FinalDestinationCode, FinalDestinationCode),
			ImporterID=ISNULL(@ImporterID, ImporterID),
			ImporterRef=ISNULL(@ImporterRef, ImporterRef),
			INCOTermCode=ISNULL(@INCOTermCode, INCOTermCode),
			OrderDt=ISNULL(@OrderDt, OrderDt),
			OrderNo=ISNULL(@OrderNo, OrderNo),
			OrderStatusID=ISNULL(@OrderStatusID, OrderStatusID),
			PaymentDate=ISNULL(@PaymentDate, PaymentDate),
			PaymentTermID=ISNULL(@PaymentTermID, PaymentTermID),
			PaymentTriggerID=ISNULL(@PaymentTriggerID, PaymentTriggerID),
			PaymentTypeID=ISNULL(@PaymentTypeID, PaymentTypeID),
			PlaceReceiptCode=ISNULL(@PlaceReceiptCode, PlaceReceiptCode),
			PlannedDt=ISNULL(@PlannedDt, PlannedDt),
			PortDischargeCode=ISNULL(@PortDischargeCode, PortDischargeCode),
			PortLoadingCode=ISNULL(@PortLoadingCode, PortLoadingCode),
			SpotROE=ISNULL(@SpotROE, SpotROE),
			SupplierID=ISNULL(@SupplierID, SupplierID),
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
			CountryOriginID=@CountryOriginID,
			CreatedDt=@CreatedDt,
			CreatedUserID=@CreatedUserID,
			FinalDestinationCode=@FinalDestinationCode,
			ImporterID=@ImporterID,
			ImporterRef=@ImporterRef,
			INCOTermCode=@INCOTermCode,
			OrderDt=@OrderDt,
			OrderNo=@OrderNo,
			OrderStatusID=@OrderStatusID,
			PaymentDate=@PaymentDate,
			PaymentTermID=@PaymentTermID,
			PaymentTriggerID=@PaymentTriggerID,
			PaymentTypeID=@PaymentTypeID,
			PlaceReceiptCode=@PlaceReceiptCode,
			PlannedDt=@PlannedDt,
			PortDischargeCode=@PortDischargeCode,
			PortLoadingCode=@PortLoadingCode,
			SpotROE=@SpotROE,
			SupplierID=@SupplierID,
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

PRINT 'CREATE PROCEDURE : OrderLineDelete'
GO

IF OBJECT_ID(N'[dbo].[OrderLineDelete]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[OrderLineDelete]
GO

CREATE PROCEDURE [dbo].[OrderLineDelete]
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@Description varchar(100)=NULL,
	@OnSiteDt datetime=NULL,
	@OrderID int=NULL,
	@OrderLineID int=NULL,
	@OrderLineStatusID tinyint=NULL,
	@ProductID int=NULL,
	@SupplierRefNo varchar(50)=NULL,
	@TariffCode varchar(15)=NULL,
	@TotalVolume decimal(18,2)=NULL,
	@TotalWeight decimal(18,2)=NULL,
	@UnitCurrencyID smallint=NULL,
	@UnitPrice money=NULL,
	@UnitQuantity int=NULL,
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

PRINT 'CREATE PROCEDURE : PurchaseOrderDelete'
GO

IF OBJECT_ID(N'[dbo].[PurchaseOrderDelete]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[PurchaseOrderDelete]
GO

CREATE PROCEDURE [dbo].[PurchaseOrderDelete]
	@CountryOriginID smallint=NULL,
	@CreatedDt datetime=NULL,
	@CreatedUserID smallint=NULL,
	@FinalDestinationCode char(5)=NULL,
	@ImporterID int=NULL,
	@ImporterRef varchar(50)=NULL,
	@INCOTermCode char(3)=NULL,
	@OrderDt datetime=NULL,
	@OrderID int=NULL,
	@OrderNo varchar(50)=NULL,
	@OrderStatusID tinyint=NULL,
	@PaymentDate datetime=NULL,
	@PaymentTermID tinyint=NULL,
	@PaymentTriggerID tinyint=NULL,
	@PaymentTypeID tinyint=NULL,
	@PlaceReceiptCode char(5)=NULL,
	@PlannedDt datetime=NULL,
	@PortDischargeCode char(5)=NULL,
	@PortLoadingCode char(5)=NULL,
	@SpotROE decimal(18,4)=NULL,
	@SupplierID int=NULL,
	@SupplierRef varchar(50)=NULL,
	@TransportModeID tinyint=NULL,
	@UpdatedDt datetime=NULL,
	@UpdatedUserID smallint=NULL
AS
BEGIN
	DELETE PurchaseOrder
	WHERE
	(@CountryOriginID IS NULL OR CountryOriginID=@CountryOriginID)
	AND (@CreatedDt IS NULL OR CreatedDt=@CreatedDt)
	AND (@CreatedUserID IS NULL OR CreatedUserID=@CreatedUserID)
	AND (@FinalDestinationCode IS NULL OR FinalDestinationCode=@FinalDestinationCode)
	AND (@ImporterID IS NULL OR ImporterID=@ImporterID)
	AND (@ImporterRef IS NULL OR ImporterRef=@ImporterRef)
	AND (@INCOTermCode IS NULL OR INCOTermCode=@INCOTermCode)
	AND (@OrderDt IS NULL OR OrderDt=@OrderDt)
	AND (@OrderID IS NULL OR OrderID=@OrderID)
	AND (@OrderNo IS NULL OR OrderNo=@OrderNo)
	AND (@OrderStatusID IS NULL OR OrderStatusID=@OrderStatusID)
	AND (@PaymentDate IS NULL OR PaymentDate=@PaymentDate)
	AND (@PaymentTermID IS NULL OR PaymentTermID=@PaymentTermID)
	AND (@PaymentTriggerID IS NULL OR PaymentTriggerID=@PaymentTriggerID)
	AND (@PaymentTypeID IS NULL OR PaymentTypeID=@PaymentTypeID)
	AND (@PlaceReceiptCode IS NULL OR PlaceReceiptCode=@PlaceReceiptCode)
	AND (@PlannedDt IS NULL OR PlannedDt=@PlannedDt)
	AND (@PortDischargeCode IS NULL OR PortDischargeCode=@PortDischargeCode)
	AND (@PortLoadingCode IS NULL OR PortLoadingCode=@PortLoadingCode)
	AND (@SpotROE IS NULL OR SpotROE=@SpotROE)
	AND (@SupplierID IS NULL OR SupplierID=@SupplierID)
	AND (@SupplierRef IS NULL OR SupplierRef=@SupplierRef)
	AND (@TransportModeID IS NULL OR TransportModeID=@TransportModeID)
	AND (@UpdatedDt IS NULL OR UpdatedDt=@UpdatedDt)
	AND (@UpdatedUserID IS NULL OR UpdatedUserID=@UpdatedUserID)
END
GO

