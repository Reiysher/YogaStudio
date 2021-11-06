FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Backend/Presentation/YogaStudio.WebApi/YogaStudio.WebApi.csproj", "Backend/Presentation/YogaStudio.WebApi/"]
COPY ["Backend/Infrastructure/YogaStudio.Persistence/YogaStudio.Persistence.csproj", "Backend/Infrastructure/YogaStudio.Persistence/"]
COPY ["Backend/Core/YogaStudio.Application/YogaStudio.Application.csproj", "Backend/Core/YogaStudio.Application/"]
COPY ["Backend/Core/YogaStudio.Domain/YogaStudio.Domain.csproj", "Backend/Core/YogaStudio.Domain/"]
RUN dotnet restore "Backend/Presentation/YogaStudio.WebApi/YogaStudio.WebApi.csproj"
COPY . .
WORKDIR "/src/Backend/Presentation/YogaStudio.WebApi"
RUN dotnet build "YogaStudio.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YogaStudio.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YogaStudio.WebApi.dll"]