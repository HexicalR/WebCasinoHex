USE [WebCasinoHex]
GO
/****** Object:  StoredProcedure [dbo].[SP_SAVE_RESULTS]    Script Date: 17/11/2021 08:40:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_SAVE_RESULTS]
@VIdGame int,
@VIdPlayer int, 
@VMoneyBet decimal,
@VSituation int
as
BEGIN  
BEGIN TRY
BEGIN TRANSACTION
          
INSERT INTO GameResult(IdGame,IdPlayer,MoneyBet,Situation,DateResult)VALUES(@VIdGame,@VIdPlayer, @VMoneyBet,@VSituation, GETDATE());

IF (@VSituation = 1)


UPDATE Players SET  MoneyAccount = MoneyAccount + @VMoneyBet WHERE IdPlayer = @VIdPlayer;

IF (@VSituation = 0)

UPDATE Players SET  MoneyAccount = MoneyAccount - @VMoneyBet WHERE IdPlayer = @VIdPlayer;

COMMIT TRANSACTION
END TRY
BEGIN CATCH
     ROLLBACK TRANSACTION
END CATCH
END;