FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8083
ENV ASPNETCORE_URLS=http://*:8083

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ProductMicroservice.csproj", "."]
RUN dotnet restore "ProductMicroservice.csproj"
COPY . .
RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]