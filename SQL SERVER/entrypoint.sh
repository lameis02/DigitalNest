#!/bin/bash

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Function to check if SQL Server is ready
function is_sql_server_ready() {
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -Q "SELECT 1" &> /dev/null
    return $?
}

# Wait for SQL Server to start
echo "Waiting for SQL Server to start..."
i=0
while ! is_sql_server_ready && [ $i -le 30 ]
do
    sleep 1
    i=$((i+1))
    echo "Still waiting for SQL Server to start..."
done

if [ $i -eq 31 ]; then
    echo "SQL Server failed to start in time."
    exit 1
fi

echo "SQL Server is ready."

# Run the setup script to create the DB and the schema in the DB
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -d master -i /var/opt/mssql/scripts/create-database.sql

# Optional: any other initialization scripts can be run here

# Keep the container running
wait
