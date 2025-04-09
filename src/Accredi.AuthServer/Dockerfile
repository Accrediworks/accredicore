FROM mcr.microsoft.com/dotnet/aspnet:9.0
COPY . .
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Accredi.AuthServer.dll"]