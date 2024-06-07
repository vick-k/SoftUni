CREATE FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @Index SMALLINT = 1
	WHILE (@Index <= LEN(@word))
	BEGIN
		IF (CHARINDEX(SUBSTRING(@word, @Index, 1), @setOfLetters) = 0)
		RETURN 0
		SET @Index += 1
	END
	RETURN 1
END