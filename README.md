# Game Store

## Starting SQL Server docker container

```powershell
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name mssql --hostname sql2022 -d mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the connection string in Secret Manager

```powershell
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server:localhost; Database=GameStore; User Id=sa; Password=<YourStrong@Passw0rd>; TrustServerCertificate=True"
```
