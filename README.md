
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

---

# Vue JS


> Typescript

```zsh
npm install
npm run dev
npm i @aws-sdk/client-s3 @aws-sdk/s3-request-presigner @google-cloud/text-to-speech @prisma/client amqplib
 npm i axios babel-loader bcryptjs body-parser chalk cloudinary
npm i compression cookie-parser cors cron debug dotenv express fs-extra
npm i helmet http-errors jake joi jsonwebtoken lodash moment
npm i morgan multer node-schedule nodemon npm npm-run-all
npm i faker jest mocha prettier --dev
npm i
```



