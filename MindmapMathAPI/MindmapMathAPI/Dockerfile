# =============================
# BUILD STAGE
# =============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file và restore dependencies
COPY MindmapMathAPI/MindmapMathAPI.csproj MindmapMathAPI/
COPY MindmapBO/*.csproj MindmapBO/
COPY MindmapDAO/*.csproj MindmapDAO/
COPY MindmapRepository/*.csproj MindmapRepository/
COPY MindmapService/*.csproj MindmapService/

# Restore dependencies cho toàn b? solution
RUN dotnet restore "MindmapMathAPI/MindmapMathAPI.csproj"

# Copy toàn b? source code
COPY . .

# Build & publish Web API
WORKDIR "/src/MindmapMathAPI"
RUN dotnet publish "MindmapMathAPI.csproj" -c Release -o /app/publish

# =============================
# RUNTIME STAGE
# =============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Railway c?p bi?n PORT khi ch?y container
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE 8080

ENTRYPOINT ["dotnet", "MindmapMathAPI.dll"]
