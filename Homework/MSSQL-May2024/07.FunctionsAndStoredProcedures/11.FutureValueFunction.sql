CREATE FUNCTION ufn_CalculateFutureValue (@initialSum DECIMAL(18, 4), @interestRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	RETURN @initialSum * POWER((1 + @interestRate), @years)
END