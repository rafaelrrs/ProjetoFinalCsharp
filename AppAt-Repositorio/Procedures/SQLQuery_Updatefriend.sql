-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
CREATE PROCEDURE dbo.Updatefriend 
	-- Add the parameters for the stored procedure here
	@Nome varchar(50),
	@Sobrenome varchar(50),
	@Aniversario date,
	@IdFriend int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Amigo
		SET Nome = @Nome,
			Sobrenome = @Sobrenome,
			Aniversario = @Aniversario
		where @IdFriend = @IdFriend;
END
GO