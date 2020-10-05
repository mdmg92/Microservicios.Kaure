FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY . .
RUN dotnet publish src/gateway/Microservicios.Kaure.Gateway -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as runtime
WORKDIR /app

COPY --from=build /app/out .

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Docker

ENTRYPOINT ["dotnet", "Microservicios.Kaure.Gateway.dll"]