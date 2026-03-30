IF NOT EXISTS (SELECT name FROM master.sys.sql_logins WHERE name = 'thewatchers.webapi')
	BEGIN
		CREATE LOGIN [thewatchers.webapi] WITH PASSWORD = 'TheWatchers26$'
	END