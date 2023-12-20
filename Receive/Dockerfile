# Dockerfile for .net core 7 console app
FROM --platform=arm64 mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build

WORKDIR /app

COPY . .

RUN dotnet publish -c Release -o out

FROM --platform=arm64 mcr.microsoft.com/dotnet/runtime:7.0-alpine AS runtime

WORKDIR /app

COPY --from=build /app/out ./
