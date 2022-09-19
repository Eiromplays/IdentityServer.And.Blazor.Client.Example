#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["src/DustySolutions.Accounts.BlazorApp/DustySolutions.Accounts.BlazorApp.csproj", "src/DustySolutions.Accounts.BlazorApp/"]
RUN dotnet restore "src/DustySolutions.Accounts.BlazorApp/DustySolutions.Accounts.BlazorApp.csproj"
COPY . .
WORKDIR "/src/src/DustySolutions.Accounts.BlazorApp"
RUN dotnet build "DustySolutions.Accounts.BlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DustySolutions.Accounts.BlazorApp.csproj" -c Release -o /app/publish

FROM nginx:1.22 AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY --from=build /src/src/DustySolutions.Accounts.BlazorApp/nginx.conf /etc/nginx/nginx.conf