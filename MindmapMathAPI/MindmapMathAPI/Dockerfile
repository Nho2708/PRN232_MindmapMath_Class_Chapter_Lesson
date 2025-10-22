FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MindmapMathAPI.csproj", "./"]
RUN dotnet restore "MindmapMathAPI.csproj"
COPY . .
RUN dotnet publish "MindmapMathAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE 8080
ENTRYPOINT ["dotnet", "MindmapMathAPI.dll"]
