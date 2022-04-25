FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Portal/Portal.csproj", "Portal"]
RUN dotnet restore "Portal/Portal.csproj"
COPY . .
WORKDIR "/src/Portal"
RUN dotnet build "Portal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Portal.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY ["Portal/nginx.conf", "/etc/nginx/nginx.conf"]