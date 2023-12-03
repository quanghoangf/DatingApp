# DOTNET_SOA

Add need package
```bash
dotnet tool install --global dotnet-ef
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
```


```cs
// in program.cs
var serverVersion = new MySqlServerVersion(new Version("8.0.34"));
```


### migration
```
dotnet ef migrations add InitialDB -o Database/Migration
dotnet ef database update
dotnet-ef migrations update <ID>
dotnet-ef migrations remove
```

authenticate

```sh
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
```
