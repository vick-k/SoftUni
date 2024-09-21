USE [Minions]

--

ALTER TABLE [Users]
ADD CONSTRAINT Check_Password_Length
CHECK(LEN([Password]) >= 5)