# =============================
# BUILD STAGE
# =============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY MindmapMathAPI/MindmapMathAPI.sln ./MindmapMathAPI.sln


COPY MindmapMathAPI/MindmapBO/*.csproj MindmapBO/
COPY MindmapMathAPI/MindmapDAO/*.csproj MindmapDAO/
COPY MindmapMathAPI/MindmapRepository/*.csproj MindmapRepository/
COPY MindmapMathAPI/MindmapService/*.csproj MindmapService/
COPY MindmapMathAPI/MindmapMathAPI/*.csproj MindmapMathAPI/

# Restore dependencies
RUN dotnet restore ./MindmapMathAPI.sln


COPY MindmapMathAPI/ .

# Publish Web API
RUN dotnet publish MindmapMathAPI/MindmapMathAPI.csproj -c Release -o /app/publish /p:UseAppHost=false

# =============================
# RUNTIME STAGE
# =============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MindmapMathAPI.dll"]
