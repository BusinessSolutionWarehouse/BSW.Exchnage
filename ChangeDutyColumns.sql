EXEC sp_rename
    @objname = 'OrderLine.DutyPercentage',
    @newname = 'OrderLine.Duty',
    @objtype = 'COLUMN'


/****** Object:  StoredProcedure [dbo].[ProductGetByCode]    Script Date: 2013-05-23 11:17:28 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductGetByCode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ProductGetByCode]
GO
/****** Object:  StoredProcedure [dbo].[OrderLineInsert]    Script Date: 2013-05-23 11:17:28 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderLineInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrderLineInsert]
GO
/****** Object:  StoredProcedure [dbo].[OrderLineInsert]    Script Date: 2013-05-23 11:17:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderLineInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[OrderLineInsert]
	@CreatedDt datetime,
	@CreatedUserID smallint,
	@Description varchar(100),
	@Duty decimal(5,2),
	@DutyTypeID int,
	@OnSiteDt datetime,
	@OrderID int,
	@OrderLineStatusID tinyint,
	@ProductID int,
	@SupplierRefNo varchar(50),
	@TariffCode varchar(50),
	@UnitCurrencyID smallint,
	@UnitPrice money,
	@UnitQuantity int,
	@UnitTypeID tinyint,
	@TotalVolume decimal(18,2),
	@TotalWeight decimal(18,2)
AS
BEGIN
	INSERT OrderLine (
	CreatedDt,
	CreatedUserID,
	Description,
	Duty,
	DutyTypeID,
	OnSiteDt,
	OrderID,
	OrderLineStatusID,
	ProductID,
	SupplierRefNo,
	TariffCode,
	UnitCurrencyID,
	UnitPrice,
	UnitQuantity,
	UnitTypeID,
	TotalVolume,
	TotalWeight
	) VALUES (
	@CreatedDt,
	@CreatedUserID,
	@Description,
	@Duty,
	@DutyTypeID,
	@OnSiteDt,
	@OrderID,
	@OrderLineStatusID,
	@ProductID,
	@SupplierRefNo,
	@TariffCode,
	@UnitCurrencyID,
	@UnitPrice,
	@UnitQuantity,
	@UnitTypeID,
	@TotalVolume,
	@TotalWeight)
	
		
	SELECT SCOPE_IDENTITY()
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[ProductGetByCode]    Script Date: 2013-05-23 11:17:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductGetByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ProductGetByCode]
	@ProductCode varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT [ProductID]
      ,[ImporterID]
      ,[SupplierID]
      ,[ProductCode]
      ,[ProductDescription]
      ,[SupplierProductCode]
      ,[UnitPackQty]
      ,[UnitWeight_KG]
      ,[UnitDim1_CM]
      ,[UnitDim2_CM]
      ,[UnitDim3_CM]
      ,[UnitPriceForeign]
      ,[Durty]
	  ,[DutyTypeID]
      ,[TariffCode]
      ,[LatestUpdateDT]
      ,[ProductStatusID]
  FROM [dbo].[Product]
  Where ProductCode = @ProductCode

END
' 
END
GO
