FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY . ./

RUN dotnet restore

RUN dotnet publish Contacts.API/Contacts.API.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

COPY --from=build-env /App/out ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "Contacts.API.dll"]
