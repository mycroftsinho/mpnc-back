FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/webapi/webapi.csproj", "src/webapi/"]
RUN dotnet restore "src/webapi/webapi.csproj"
COPY . .
WORKDIR "/src/src/webapi"
RUN dotnet build "webapi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "webapi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "webapi.dll"]
