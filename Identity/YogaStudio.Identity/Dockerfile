FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Identity/YogaStudio.Identity/YogaStudio.Identity.csproj", "Identity/YogaStudio.Identity/"]
RUN dotnet restore "Identity/YogaStudio.Identity/YogaStudio.Identity.csproj"
COPY . .
WORKDIR "/src/Identity/YogaStudio.Identity"
RUN dotnet build "YogaStudio.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YogaStudio.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YogaStudio.Identity.dll"]