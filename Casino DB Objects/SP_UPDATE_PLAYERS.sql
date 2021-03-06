USE [WebCasinoHex]
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_PLAYERS]    Script Date: 17/11/2021 08:46:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_UPDATE_PLAYERS]
 @VIdPlayer int,
 @VName varchar(50),
 @VLastName varchar(50), 
 @VMoneyAccount decimal
as BEGIN  
BEGIN TRY
     BEGIN TRANSACTION
          
      UPDATE Players SET Name = @VName, LastName = @VLastName, MoneyAccount = @VMoneyAccount, LastDateModificacion = GETDATE() WHERE IdPlayer = @VIdPlayer;
     COMMIT TRANSACTION
END TRY
BEGIN CATCH
     ROLLBACK TRANSACTION
END CATCH
END;