# =============================
# BUILD STAGE
# =============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution
COPY *.sln ./

# Copy từng project con (đúng thư mục)
COPY MindmapBO/*.csproj MindmapBO/
COPY MindmapDAO/*.csproj MindmapDAO/
COPY MindmapRepository/*.csproj MindmapRepository/
COPY MindmapService/*.csproj MindmapService/
COPY MindmapMathAPI/*.csproj MindmapMathAPI/

# Restore tất cả dependencies theo solution
RUN dotnet restore

# Copy toàn bộ source code
COPY . .

# Publish project chính (Web API)
RUN dotnet publish MindmapMathAPI/MindmapMathAPI.csproj -c Release -o /app/publish /p:UseAppHost=false

# =============================
# RUN STAGE
# =============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "MindmapMathAPI.dll"]
