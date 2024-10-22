USE [db_spr]
GO

DECLARE @NewSPRNo int

EXEC [dbo].[GenerateSPRNo]
		@ProyekId = 12,
		@Bulan = 09,
		@Tahun = 2024,
		@NewSPRNo = @NewSPRNo OUTPUT

SELECT	@NewSPRNo as N'@NewSPRNo'



GO
