USE [WebCasinoHex]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_PLAYERS]    Script Date: 17/11/2021 08:47:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_GET_PLAYERS]
as
begin
Select IdPlayer, Name, LastName as "Last name", UserName, MoneyAccount as "Money account", CONVERT(varchar(12),DateCreation, 103) AS "Date creation",  
CONVERT(varchar(12),LastDateModificacion, 103) AS "Last date modification"
from Players Order by Name
end;