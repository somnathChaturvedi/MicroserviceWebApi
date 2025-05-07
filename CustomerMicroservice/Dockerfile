FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CustomerMicroservice.csproj", "."]
RUN dotnet restore "CustomerMicroservice.csproj"
COPY . .
RUN dotnet build "CustomerMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerMicroservice.dll"]