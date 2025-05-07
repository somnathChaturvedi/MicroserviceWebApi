FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CartMicroservice.csproj", "."]
RUN dotnet restore "CartMicroservice.csproj"
COPY . .
RUN dotnet build "CartMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CartMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CartMicroservice.dll"]