#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["src/DustySolutions.Accounts/DustySolutions.Accounts.csproj", "src/DustySolutions.Accounts/"]
COPY ["src/DustySolutions.Accounts.BlazorApp/DustySolutions.Accounts.BlazorApp.csproj", "src/DustySolutions.Accounts.BlazorApp/"]
RUN dotnet restore "src/DustySolutions.Accounts/DustySolutions.Accounts.csproj"
COPY . .
WORKDIR "/src/src/DustySolutions.Accounts"
RUN dotnet build "DustySolutions.Accounts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DustySolutions.Accounts.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DustySolutions.Accounts.dll"]