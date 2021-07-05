FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mastermind.API/Mastermind.API.csproj", "Mastermind.API/"]
RUN dotnet restore "Mastermind.API/Mastermind.API.csproj"
COPY . .
WORKDIR "/src/Mastermind.API"
RUN dotnet build "Mastermind.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mastermind.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mastermind.API.dll"]
