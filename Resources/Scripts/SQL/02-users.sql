IF NOT EXISTS(SELECT name FROM sys.sysusers WHERE name = 'thewatchers.webapi')
    BEGIN
        CREATE USER [thewatchers.webapi] FOR LOGIN [thewatchers.webapi]
        EXEC [sp_addrolemember] N'db_owner', N'thewatchers.webapi'
    END