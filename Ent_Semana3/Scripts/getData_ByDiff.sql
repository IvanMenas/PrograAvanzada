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
ALTER PROCEDURE getData_ByDiff
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT MAX(X.DIFERENCIA) MAXIMO, MIN(X.DIFERENCIA) MINIMO, AVG(X.DIFERENCIA) PROMEDIO 
		FROM
		(SELECT ABS(C.NUM_VALOR - V.NUM_VALOR) DIFERENCIA
		FROM T_TIPOCAMBIO C
		INNER JOIN
		(SELECT NUM_VALOR, COD_INDICADORINTERNO, DES_FECHA
		FROM T_TIPOCAMBIO V
		WHERE V.COD_INDICADORINTERNO = 318)
		V ON C.DES_FECHA = V.DES_FECHA
		WHERE C.COD_INDICADORINTERNO = 317)X


END
GO
