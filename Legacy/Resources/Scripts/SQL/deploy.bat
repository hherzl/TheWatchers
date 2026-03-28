cls
set db_server=(local)
set db_name=TheWatcher
sqlcmd -S %db_server% -d %db_name% -E -i "01-tables.sql"
sqlcmd -S %db_server% -d %db_name% -E -i "02-constraints.sql"
pause
