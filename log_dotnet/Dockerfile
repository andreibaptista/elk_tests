FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY *.csproj .
RUN dotnet restore

COPY . .

RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=build /app .

ENTRYPOINT ["dotnet", "./log_dotnet.dll"]

EXPOSE 80