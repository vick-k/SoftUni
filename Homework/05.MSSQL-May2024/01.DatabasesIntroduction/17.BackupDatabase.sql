USE [master]

BACKUP DATABASE [SoftUni]
TO DISK = 'D:\BackupDB\SoftUniDB.bak'

-- If the database cannot be dropped because it is currently in use, execute this code:
ALTER DATABASE [SoftUni]
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE
--

GO

DROP DATABASE [SoftUni]

GO

RESTORE DATABASE [SoftUni] 
FROM DISK = 'D:\BackupDB\SoftUniDB.bak'