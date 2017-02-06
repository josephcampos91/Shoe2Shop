USE [Shoe2Shop]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

-- ============================================================================================
-- SCHEMA GAP
-- ============================================================================================

print 'Checking SCHEMA [GAP]';
GO
IF NOT EXISTS (SELECT schema_name FROM information_schema.schemata WHERE schema_name = 'GAP' )
BEGIN
	print 'Creating SCHEMA [GAP]';
    EXECUTE('CREATE SCHEMA GAP Authorization dbo');
END

-- DROP SCHEMA GAP
-- GO


DECLARE @DROP_CONSTRAINTS NVARCHAR(MAX) = N'';

SELECT @DROP_CONSTRAINTS += N'ALTER TABLE [GAP].' + OBJECT_NAME(PARENT_OBJECT_ID) + ' DROP CONSTRAINT ' + OBJECT_NAME(OBJECT_ID) + '; ' 
	FROM SYS.OBJECTS
	WHERE OBJECT_NAME(OBJECT_ID) like '%FK%' and TYPE_DESC LIKE '%CONSTRAINT' AND 
		(	
			OBJECT_NAME(PARENT_OBJECT_ID) = 'STR_Stores' OR	
			OBJECT_NAME(PARENT_OBJECT_ID) = 'ART_Articles'
		);

print 'Eliminating relationships between tables'; 
EXECUTE (@DROP_CONSTRAINTS);    


-- ============================================================================================
-- TABLE Stores
-- ============================================================================================
print 'Creating TABLE [STR_Stores]'; 

IF OBJECT_ID (N'[GAP].[STR_Stores]', N'U') IS NOT NULL
  BEGIN   
	DROP TABLE GAP.STR_Stores;
  END
GO

CREATE TABLE GAP.STR_Stores (
	STR_nId			INTEGER NOT NULL IDENTITY (1,1),
	STR_strName		VARCHAR (20) NOT NULL,
	STR_strAddress	VARCHAR (50) NOT NULL,

	CONSTRAINT [PK_STR_Stores] PRIMARY KEY CLUSTERED (STR_nId ASC)
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- ============================================================================================
-- TABLE ART_Articles
-- ============================================================================================
print 'Creating TABLE [ART_Articles]'; 

IF OBJECT_ID (N'[GAP].[ART_Articles]', N'U') IS NOT NULL
  BEGIN   
	DROP TABLE GAP.ART_Articles;
  END
GO

CREATE TABLE GAP.ART_Articles (
	ART_nId				INTEGER NOT NULL IDENTITY (1, 1),
	ART_strName			VARCHAR (20) NOT NULL,
	ART_strDescription	VARCHAR (50) NOT NULL,
	ART_dPrice			DECIMAL (10,2) NOT NULL,
	ART_nTotalShelf		INTEGER NOT NULL,
	ART_nTotalVault		INTEGER NOT NULL,
	ART_nStoreId		INTEGER NOT NULL,

	CONSTRAINT FK_ART_nStoreId_X_STR_nId FOREIGN KEY (ART_nStoreId)
		REFERENCES GAP.STR_Stores (STR_nId),

	CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED (ART_nId ASC)
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- ============================================================================================
-- INDEX STR_Stores
-- ============================================================================================
print 'Creating INDEXES in [STR_Stores]'; 
CREATE INDEX I_STR_strName ON GAP.STR_Stores(STR_strName)
GO

-- ============================================================================================
-- INDEX ART_Articles
-- ============================================================================================
print 'Creating INDEXES in [ART_Articles]'; 
CREATE INDEX I_ART_strName ON GAP.ART_Articles(ART_strName)
CREATE INDEX I_ART_nStoreId ON GAP.ART_Articles(ART_nStoreId)
GO

print 'FINISHED.'; 
GO


