USE [TestDapper]
GO
/****** Object:  Table [dbo].[Dapper]    Script Date: 2018/1/5 下午 06:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dapper](
	[Dapper_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Dapper_Code] [nvarchar](30) NOT NULL CONSTRAINT [DF_Dapper_Dapper_Code]  DEFAULT (''),
	[Dapper_IsTrue] [bit] NOT NULL CONSTRAINT [DF_Dapper_Dapper_IsTrue]  DEFAULT ((0)),
	[Dapper_Integer] [int] NOT NULL CONSTRAINT [DF_Dapper_Dapper_Integer]  DEFAULT ((0)),
	[Dapper_CreateDateTime] [datetime] NOT NULL CONSTRAINT [DF_Dapper_Dapper_CreateDateTime]  DEFAULT (getdate()),
	[Dapper_CreateDateTimeTwo] [datetime2](7) NOT NULL CONSTRAINT [DF_Dapper_Dapper_CreateDateTimeTwo]  DEFAULT (getdate()),
	[Dapper_CreateUser] [nvarchar](30) NOT NULL CONSTRAINT [DF_Dapper_Dapper_CreateUser]  DEFAULT (''),
	[Dapper_NullableInteger] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reppad]    Script Date: 2018/1/5 下午 06:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reppad](
	[Reppad_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Reppad_Code] [nvarchar](30) NOT NULL CONSTRAINT [DF_Reppad_Reppad_Code]  DEFAULT (''),
	[Reppad_IsTrue] [bit] NOT NULL CONSTRAINT [DF_Reppad_Reppad_IsTrue]  DEFAULT ((0)),
	[Reppad_Integer] [int] NOT NULL CONSTRAINT [DF_Reppad_Reppad_Integer]  DEFAULT ((0)),
	[Reppad_CreateDateTime] [datetime] NOT NULL CONSTRAINT [DF_Reppad_Reppad_CreateDateTime]  DEFAULT (getdate()),
	[Reppad_CreateDateTimeTwo] [datetime2](7) NOT NULL CONSTRAINT [DF_Reppad_Reppad_CreateDateTimeTwo]  DEFAULT (getdate()),
	[Reppad_CreateUser] [nvarchar](30) NOT NULL CONSTRAINT [DF_Reppad_Reppad_CreateUser]  DEFAULT (''),
	[Reppad_NullableInteger] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[csp_GetAllDapperRecord]    Script Date: 2018/1/5 下午 06:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:JoelHsu
-- Create date: 2018.01.04
-- Description:	TestDapper
-- =============================================
CREATE PROCEDURE [dbo].[csp_GetAllDapperRecord]
( 
@code nvarchar(30),
@user nvarchar(30)
)
AS
BEGIN
SELECT [Dapper_Id]
      ,[Dapper_Code]
      ,[Dapper_IsTrue]
      ,[Dapper_Integer]
      ,[Dapper_CreateDateTime]
      ,[Dapper_CreateDateTimeTwo]
      ,[Dapper_CreateUser]
      ,[Dapper_NullableInteger]
  FROM [TestDapper].[dbo].[Dapper]
  WHERE Dapper_Code=@code
  AND Dapper_CreateUser = @user
END

GO
