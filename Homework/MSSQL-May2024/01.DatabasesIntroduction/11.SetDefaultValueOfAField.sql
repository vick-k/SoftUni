USE [Minions]

--

ALTER TABLE [Users]
ADD CONSTRAINT DF_LastLogin_Default
DEFAULT GETDATE() FOR [LastLoginTime]