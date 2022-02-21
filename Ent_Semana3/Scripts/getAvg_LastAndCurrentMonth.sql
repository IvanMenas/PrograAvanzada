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
CREATE PROCEDURE getAvg_LastAndCurrentMonth
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @indicador INT = 318
	DECLARE @fechaMenos1Mes DATETIME = DATEADD(MONTH, -1, GETDATE())

	SELECT AVG(NUM_VALOR) NUM_VALOR, COD_INDICADORINTERNO
	FROM T_TIPOCAMBIO
	WHERE COD_INDICADORINTERNO = @indicador
	AND MONTH(DES_FECHA) = MONTH(GETDATE()) AND YEAR(DES_FECHA) = YEAR(GETDATE())
	GROUP BY COD_INDICADORINTERNO
	UNION ALL
	SELECT AVG(NUM_VALOR) NUM_VALOR, COD_INDICADORINTERNO
	FROM T_TIPOCAMBIO
	WHERE COD_INDICADORINTERNO = @indicador
	AND MONTH(DES_FECHA) = MONTH(@fechaMenos1Mes) AND YEAR(DES_FECHA) = YEAR(@fechaMenos1Mes)
	GROUP BY COD_INDICADORINTERNO

END
GO

