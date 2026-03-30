IF NOT EXISTS(SELECT name FROM master.sys.databases WHERE name = 'TheWatchers')
    BEGIN
        CREATE DATABASE [TheWatchers]
    END