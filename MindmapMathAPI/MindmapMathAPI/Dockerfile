# =============================
# BUILD STAGE
# =============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj và restore dependencies
COPY *.sln ./
COPY MindmapMathAPI/*.csproj ./MindmapMathAPI/
RUN dotnet restore MindmapMathAPI/MindmapMathAPI.csproj

# Copy toàn b? source và publish
COPY . .
RUN dotnet publish MindmapMathAPI/MindmapMathAPI.csproj -c Release -o /app/publish /p:UseAppHost=false

# =============================
# RUNTIME STAGE
# =============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Render m?c ??nh expose port 10000 ? ta dùng 8080 cho th?ng nh?t
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MindmapMathAPI.dll"]
