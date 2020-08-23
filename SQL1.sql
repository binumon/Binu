USE [Test]
GO
/****** Object:  Table [dbo].[TblContract]    Script Date: 23-08-2020 17:38:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblContract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[Gender] [char](5) NULL,
	[Country] [char](5) NULL,
	[DOB] [datetime] NULL,
	[SaleDate] [datetime] NULL,
	[CoveragePlan] [varchar](50) NULL,
	[NetPrice] [decimal](18, 2) NULL,
	[IsActive] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblContract] ADD  CONSTRAINT [DF_TblContract_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  StoredProcedure [dbo].[AddContract]    Script Date: 23-08-2020 17:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddContract]
@Id INT=0,
@Name VARCHAR(50),
@Address VARCHAR(100),
@Country CHAR(5),
@Gender CHAR(5),
@DOB DATETIME,
@SaleDate DATETIME

AS
BEGIN
DECLARE @NetPrice Decimal
DECLARE @Age INT
DECLARE @Plan VARCHAR(50)


SELECT @Age= DATEDIFF(YY, @DOB, Getdate())


IF(@SaleDate BETWEEN  '2009-01-01' AND  '2021-01-01' AND @Country='USA')
	BEGIN
		SET @Plan ='Gold'
	END 
	ELSE IF(@SaleDate BETWEEN  '2005-01-01' AND  '2023-01-01' AND @Country='CAN')
	BEGIN
		SET @Plan ='Platinum'
	END
	ELSE IF(@SaleDate BETWEEN  '2001-01-01' AND  '2026-01-01' )
	BEGIN
		SET @Plan ='Silver'
	END
	
  IF(@Plan='Gold' AND @Gender='M' AND @Age <=40)
	BEGIN
		SET @NetPrice =1000
	END
	ELSE IF(@Plan='Gold' AND @Gender='M' AND @Age >40)
	BEGIN
		SET @NetPrice =2000
	END
	ELSE IF(@Plan='Gold' AND @Gender='F' AND @Age <=40)
	BEGIN
		SET @NetPrice =1200
	END
	ELSE IF(@Plan='Gold' AND @Gender='F' AND @Age >40)
	BEGIN
		SET @NetPrice =2500
	END


	ELSE IF(@Plan='Platinum' AND @Gender='M' AND @Age <=40)
	BEGIN
		SET @NetPrice =1900
	END
	ELSE IF(@Plan='Platinum' AND @Gender='M' AND @Age >40)
	BEGIN
		SET @NetPrice =2900
	END
	ELSE IF(@Plan='Platinum' AND @Gender='F' AND @Age <=40)
	BEGIN
		SET @NetPrice =2100
	END
	ELSE IF(@Plan='Platinum' AND @Gender='F' AND @Age >40)
	BEGIN
		SET @NetPrice =3200
	END


	ELSE IF(@Plan='Silver' AND @Gender='M' AND @Age <=40)
	BEGIN
		SET @NetPrice =1500
	END
	ELSE IF(@Plan='Silver' AND @Gender='M' AND @Age >40)
	BEGIN
		SET @NetPrice =2600
	END
	ELSE IF(@Plan='Silver' AND @Gender='F' AND @Age <=40)
	BEGIN
		SET @NetPrice =1900
	END
	ELSE IF(@Plan='Silver' AND @Gender='F' AND @Age >40)
	BEGIN
		SET @NetPrice =2800
	END

	IF(@Id=0)
		BEGIN
			INSERT INTO TblContract(Name, Address, Gender, Country, DOB, SaleDate, CoveragePlan, NetPrice)
			VALUES(@Name,@Address,@Gender,@Country,@DOB,@SaleDate,@Plan,@NetPrice)
		END
		ELSE
		BEGIN
			UPDATE TblContract SET Name=@Name,Address=@Address, Gender=@Gender,Country=@Country,DOB=@DOB,
			SaleDate=@SaleDate,CoveragePlan=@Plan,NetPrice=@NetPrice WHERE ID=@Id
		END
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePlan]    Script Date: 23-08-2020 17:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePlan]
@Id INT
AS
BEGIN
	UPDATE tblContract SET IsActive=0 WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetPlan]    Script Date: 23-08-2020 17:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPlan]
AS
BEGIN
	SELECT Id,Name,Address, Gender,Country,DOB,
			SaleDate,CoveragePlan,NetPrice FROM tblContract WHERE IsActive=1 FOR JSON PATH
END

GO
