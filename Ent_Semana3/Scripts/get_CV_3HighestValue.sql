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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE get_CV_3HighestValue
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		DECLARE @Datos TABLE(NUM_VALOR_TEMPORAL DECIMAL(18,4), POSICION INT)
		DECLARE @indicador INT = 318
		DECLARE @fechaMenos6Mes DATETIME = DATEADD(MONTH, -1, GETDATE())
		INSERT INTO @Datos
		SELECT NUM_VALOR,
		ROW_NUMBER() OVER(ORDER BY NUM_VALOR DESC) AS Row#
		FROM T_TIPOCAMBIO
		WHERE COD_INDICADORINTERNO = @indicador
		AND DES_FECHA BETWEEN @fechaMenos6Mes AND GETDATE()
		SELECT NUM_VALOR_TEMPORAL FROM @Datos
		WHERE POSICION = 3


END
GO
