USE [WebCasinoHex]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_PLAYERS_BY_SORTING]    Script Date: 17/11/2021 08:46:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_GET_PLAYERS_BY_SORTING]
@VColumn varchar (30),
@VOrder varchar(30)
as 
begin
   DECLARE @OColumn varchar(30);
if (@VOrder = 'ASC') 
BEGIN

if @VColumn = 'IdPlayer' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      IdPlayer 
end
if @VColumn = 'Name' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      Name 
end
if @VColumn = 'Last Name' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      LastName 
end
if @VColumn = 'UserName' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      UserName 
end
if @VColumn = 'Money account' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      MoneyAccount 
end
if @VColumn = 'Date creation' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      DateCreation 
end
if @VColumn = 'Last date modification' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      LastDateModificacion 
end
end

ELSE if (@VOrder = 'DESC') 

begin
  
  
if @VColumn = 'IdPlayer' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      IdPlayer DESC
end
if @VColumn = 'Name' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      Name DESC
end
if @VColumn = 'Last Name' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      LastName DESC 
end
if @VColumn = 'UserName' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      UserName DESC 
end
if @VColumn = 'Money account' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      MoneyAccount DESC 
end
if @VColumn = 'Date creation' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      DateCreation DESC 
end
if @VColumn = 'Last date modification' 
begin
   Select
      IdPlayer,
      Name,
      LastName as "Last name",
      UserName,
      MoneyAccount as "Money account",
      CONVERT(varchar(12), DateCreation, 103) AS "Date creation",
      CONVERT(varchar(12), LastDateModificacion, 103) AS "Last date modification" 
   from
      Players 
   Order by
      LastDateModificacion DESC 
     end
   end
END