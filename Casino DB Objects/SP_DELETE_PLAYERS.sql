USE [WebCasinoHex]
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_PLAYERS]    Script Date: 17/11/2021 08:48:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_DELETE_PLAYERS]
 @VIdPlayer int
as BEGIN  
BEGIN TRY
     BEGIN TRANSACTION
          DELETE FROM Players where IdPlayer = @VIdPlayer;
     COMMIT TRANSACTION
END TRY
BEGIN CATCH
     ROLLBACK TRANSACTION
END CATCH
END;