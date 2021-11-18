USE [WebCasinoHex]
GO

/****** Object:  Table [dbo].[Players]    Script Date: 17/11/2021 08:50:58 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Players](
	[IdPlayer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[MoneyAccount] [decimal](18, 0) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[LastDateModificacion] [date] NULL,
	[DateCreation] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPlayer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


