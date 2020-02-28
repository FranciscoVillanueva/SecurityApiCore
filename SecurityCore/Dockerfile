FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["SecurityCore.csproj", ""]
RUN dotnet restore "SecurityCore.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "SecurityCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SecurityCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SecurityCore.dll"]