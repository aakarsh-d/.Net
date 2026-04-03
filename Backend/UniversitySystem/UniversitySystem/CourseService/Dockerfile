FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["CourseService/CourseService.csproj", "CourseService/"]
COPY ["Shared.Contracts/Shared.Contracts.csproj", "Shared.Contracts/"]
RUN dotnet restore "CourseService/CourseService.csproj"

COPY . .
WORKDIR "/src/CourseService"
RUN dotnet build "CourseService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseService.dll"]
