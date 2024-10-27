DECLARE @NewSPRNo int
EXEC [dbo].[GenerateSPRNo] 1, 10, 2024, @NewSPRNo OUTPUT
Select @NewSPRNo as hasil