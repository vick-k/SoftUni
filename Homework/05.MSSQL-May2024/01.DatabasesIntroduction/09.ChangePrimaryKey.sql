USE [Minions]

--
GO
SELECT name
FROM sys.key_constraints
WHERE parent_object_id = OBJECT_ID('Users') AND type = 'PK';
GO
-- The above query returns the system-generated name of the primary key

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC073DC7760A

ALTER TABLE [Users]
ADD CONSTRAINT PK_Users
PRIMARY KEY(Id, Username)
