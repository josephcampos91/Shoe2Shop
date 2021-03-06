USE Shoe2Shop
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


print 'Creating user stored procedure USP_ReadStores';
GO
-- ============================================================================================
-- PROCEDURE USP_ReadStores
-- ============================================================================================

IF OBJECT_ID (N'[GAP].[USP_ReadStores]') IS NOT NULL
  BEGIN   
	DROP PROCEDURE GAP.USP_ReadStores;
  END
GO

-- =============================================
-- Author:       Joseph Campos C
-- Create date:  05/02/2017
-- Description:  Reads the entire list of stores
-- =============================================

CREATE PROCEDURE GAP.USP_ReadStores
	@nError		AS VARCHAR (2)		= '' OUTPUT,
    @strMessage AS VARCHAR (100)	= '' OUTPUT
AS
BEGIN TRY
	
	--BEGIN TRANSACTION TRAN_USP_ReadStores
	--BEGIN	
		
		SELECT 
			STR_nId, 
			STR_strName, 
			STR_strAddress
		FROM GAP.STR_Stores;

	--END		
	--COMMIT TRANSACTION TRAN_USP_ReadStores
	
	SET @nError = '00'
	SET @strMessage = 'TRANSACTION PROCESSED'
END TRY 
BEGIN CATCH
	IF @@TRANCOUNT > 0
		-- ROLLBACK TRANSACTION TRAN_USP_ReadStores

	SET @nError		= '99';
	SET @strMessage = 'TRANSACTION FAILED: ' + STR(@@error) + ' - ' + ERROR_MESSAGE();
END CATCH
GO


print 'Creating user stored procedure USP_ReadArticles';
GO
-- ============================================================================================
-- PROCEDURE USP_ReadArticles
-- ============================================================================================

IF OBJECT_ID (N'[GAP].[USP_ReadArticles]') IS NOT NULL
  BEGIN   
	DROP PROCEDURE GAP.USP_ReadArticles;
  END
GO

-- =============================================
-- Author:       Joseph Campos C
-- Create date:  05/02/2017
-- Description:  Reads the entire list of articles
-- =============================================

CREATE PROCEDURE GAP.USP_ReadArticles
	@nError		AS VARCHAR (2)		= '' OUTPUT,
    @strMessage AS VARCHAR (100)	= '' OUTPUT
AS
BEGIN TRY
	
	--BEGIN TRANSACTION TRAN_USP_ReadArticles 
	--BEGIN	
		
		SELECT 
			ART_nId				AS 'ART_nId', 
			ART_strDescription	AS 'ART_strDescription', 
			ART_strName			AS 'ART_strName',
			ART_dPrice			AS 'ART_dPrice',
			ART_nTotalShelf		AS 'ART_nTotalShelf',
			ART_nTotalVault		AS 'ART_nTotalVault',
			STR_strName			AS 'STR_strName'
		FROM GAP.ART_Articles
			INNER JOIN GAP.STR_Stores ON (STR_nId = ART_nStoreId);

	--END		
	--COMMIT TRANSACTION TRAN_USP_ReadArticles
	
	SET @nError = '00'
	SET @strMessage = 'TRANSACTION PROCESSED'
END TRY 
BEGIN CATCH
	IF @@TRANCOUNT > 0
		-- ROLLBACK TRANSACTION TRAN_USP_ReadArticles

	SET @nError		= '99';
	SET @strMessage = 'TRANSACTION FAILED: ' + STR(@@error) + ' - ' + ERROR_MESSAGE();
END CATCH
GO


print 'Creating user stored procedure USP_ReadArticles_X_Store';
GO
-- ============================================================================================
-- PROCEDURE USP_ReadArticles_X_Store
-- ============================================================================================

IF OBJECT_ID (N'[GAP].[USP_ReadArticles_X_Store]') IS NOT NULL
  BEGIN   
	DROP PROCEDURE GAP.USP_ReadArticles_X_Store;
  END
GO

-- =============================================
-- Author:       Joseph Campos C
-- Create date:  05/02/2017
-- Description:  Reads the entire list of articles that are in a specific store
-- =============================================

CREATE PROCEDURE GAP.USP_ReadArticles_X_Store
	@nSTR_Id	AS INTEGER, -- Store Id
	@nError		AS VARCHAR (2)		= '' OUTPUT,
    @strMessage AS VARCHAR (100)	= '' OUTPUT
AS
BEGIN TRY
	
	--BEGIN TRANSACTION TRAN_USP_ReadArticles_X_Store
	--BEGIN	
		
		SELECT 
			ART_nId				AS 'ART_nId', 
			ART_strDescription	AS 'ART_strDescription', 
			ART_strName			AS 'ART_strName',
			ART_dPrice			AS 'ART_dPrice',
			ART_nTotalShelf		AS 'ART_nTotalShelf',
			ART_nTotalVault		AS 'ART_nTotalVault',
			STR_strName			AS 'STR_strName'
		FROM GAP.ART_Articles
			INNER JOIN GAP.STR_Stores ON (STR_nId = ART_nStoreId)
		WHERE STR_nId = @nSTR_Id;

	--END		
	--COMMIT TRANSACTION TRAN_ReadArticles_X_Store
	
	SET @nError = '00'
	SET @strMessage = 'TRANSACTION PROCESSED'
END TRY 
BEGIN CATCH
	IF @@TRANCOUNT > 0
		-- ROLLBACK TRANSACTION TRAN_USP_ReadArticles_X_Store

	SET @nError		= '99';
	SET @strMessage = 'TRANSACTION FAILED: ' + STR(@@error) + ' - ' + ERROR_MESSAGE();
END CATCH
GO

print 'Creating user stored procedure USP_CreateStore';
GO
-- ============================================================================================
-- PROCEDURE USP_CreateStore
-- ============================================================================================

IF OBJECT_ID (N'[GAP].[USP_CreateStore]') IS NOT NULL
  BEGIN   
	DROP PROCEDURE GAP.USP_CreateStore;
  END
GO

-- =============================================
-- Author:       Joseph Campos C
-- Create date:  06/02/2017
-- Description:  It creates a new Store
-- =============================================

CREATE PROCEDURE GAP.USP_CreateStore
	@STR_strName		AS INTEGER, -- Store Name
	@STR_strAddress	AS INTEGER, -- Store Address
	@STR_nId			AS INTEGER	= 0 OUTPUT,
	@nError			AS VARCHAR (2)		= '' OUTPUT,
    @strMessage		AS VARCHAR (100)	= '' OUTPUT
AS
BEGIN TRY
	
	BEGIN TRANSACTION TRAN_USP_CreateStore
	BEGIN	
		
		INSERT INTO GAP.STR_Stores (STR_strName, STR_strAddress)
			VALUES (@STR_strName, @STR_strAddress)

			set @STR_nId = @@IDENTITY;

	END		
	COMMIT TRANSACTION TRAN_CreateStore
	
	SET @nError = '00'
	SET @strMessage = 'TRANSACTION PROCESSED'
END TRY 
BEGIN CATCH
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION TRAN_CreateStore

	SET @nError		= '99';
	SET @strMessage = 'TRANSACTION FAILED: ' + STR(@@error) + ' - ' + ERROR_MESSAGE();
END CATCH
GO