./build-image.ps1 -ProjectPath "../../src/Acreddi.DbMigrator/Acreddi.DbMigrator.csproj" -ImageName acreddi/dbmigrator
./build-image.ps1 -ProjectPath "../../src/Acreddi.Web.Public/Acreddi.Web.Public.csproj" -ImageName acreddi/webpublic
./build-image.ps1 -ProjectPath "../../src/Acreddi.Web/Acreddi.Web.csproj" -ImageName acreddi/web
./build-image.ps1 -ProjectPath "../../src/Acreddi.HttpApi.Host/Acreddi.HttpApi.Host.csproj" -ImageName acreddi/httpapihost
./build-image.ps1 -ProjectPath "../../src/Acreddi.AuthServer/Acreddi.AuthServer.csproj" -ImageName acreddi/authserver
