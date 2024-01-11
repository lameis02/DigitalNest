FROM mcr.microsoft.com/mssql/server:2019-latest

# Use a directory in a location where the SQL Server user has permissions
WORKDIR /var/opt/mssql/scripts

# Copy initialization scripts
COPY . /var/opt/mssql/scripts

# No need to change permissions if using /bin/bash to run the script
# RUN chmod +x /var/opt/mssql/scripts/run-initialization.sh

# Set environment variables
ENV SA_PASSWORD YourStrong!Passw0rd
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

# Expose port 1433
EXPOSE 1433

# Run Microsoft SQL Server and initialization script
CMD /bin/bash ./entrypoint.sh