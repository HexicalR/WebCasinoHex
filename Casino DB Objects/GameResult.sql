USE [WebCasinoHex]
GO

/****** Object:  Table [dbo].[GameResult]    Script Date: 17/11/2021 08:50:25 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GameResult](
	[IdTicketResult] [int] IDENTITY(1,1) NOT NULL,
	[IdGame] [int] NOT NULL,
	[IdPlayer] [int] NOT NULL,
	[MoneyBet] [decimal](18, 0) NOT NULL,
	[Situation] [int] NOT NULL,
	[DateResult] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTicketResult] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


