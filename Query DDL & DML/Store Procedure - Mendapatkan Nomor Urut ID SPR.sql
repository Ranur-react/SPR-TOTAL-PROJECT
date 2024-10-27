USE [db_spr]
GO

CREATE PROCEDURE [dbo].[GenerateSPRNo]
    @ProyekId INT,
    @Bulan INT,
    @Tahun INT,
    @NewSPRNo INT OUTPUT
AS
BEGIN
    SELECT @NewSPRNo = ISNULL(COUNT(id), 0) + 1
    FROM [dbo].[Headers_SP]
    WHERE ProyekId = @ProyekId 
      AND MONTH(TanggalMinta) = @Bulan 
      AND YEAR(TanggalMinta) = @Tahun;
END;