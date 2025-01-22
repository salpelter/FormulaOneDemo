# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory
WORKDIR /app

# Restore
COPY FormulaOneDemo.csproj ./
RUN dotnet restore "FormulaOneDemo.csproj"

# Build
COPY ./ ./
RUN dotnet build "FormulaOneDemo.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
WORKDIR /app
RUN dotnet publish "FormulaOneDemo.csproj" -c Release -o /app/publish

# Stage 3: Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /
COPY --from=publish /app/publish ./

ENTRYPOINT ["dotnet", "FormulaOneDemo.dll"]
