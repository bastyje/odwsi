#!/bin/sh
if [ ! -f initialized ] ; then
    while true; do
        sleep 5s
        /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -d master -Q "SELECT 1" && break
        echo "---------------------------------------- not alive ----------------------------------------"
    done
    echo "---------------------------------------- running script ----------------------------------------"
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -d master -i scripts/init_database.sql && echo "true">initialized
else
    echo "---------------------------------------- initialized ----------------------------------------"
fi    