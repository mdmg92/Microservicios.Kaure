FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY . .
RUN dotnet publish src/microservices/Microservicios.Kaure.History -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as runtime
WORKDIR /app

COPY --from=build /app/out .

EXPOSE 5005/tcp
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Docker

ENTRYPOINT ["dotnet", "Microservicios.Kaure.History.dll"]