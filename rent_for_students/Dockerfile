# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY rent_for_students.csproj .
RUN dotnet restore rent_for_students.csproj

COPY . .
RUN dotnet publish rent_for_students.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

RUN mkdir -p /app/data

COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENV ConnectionStrings__DefaultConnection="Data Source=/app/data/rentservice.db"

EXPOSE 8080

ENTRYPOINT ["dotnet", "rent_for_students.dll"]
