FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . ./

RUN mkdir -p /out && chmod -R 777 /out

RUN dotnet publish /app/Tarea2_ArquiSistemas/Tarea2_ArquiSistemas.csproj -c Release -o /temp_out

RUN cp -r /temp_out/* /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /out /app
COPY --from=build /app/user_db.db /app/user_db.db

RUN chmod -R 777 /app

EXPOSE 80

ENTRYPOINT ["dotnet", "Tarea2_ArquiSistemas.dll"]
