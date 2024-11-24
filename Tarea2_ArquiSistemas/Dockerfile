FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . ./

RUN mkdir -p /out && chmod -R 777 /out

RUN dotnet publish -c Release -o /temp_out

RUN cp -r /temp_out/* /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

COPY --from=build /out /app

WORKDIR /app

EXPOSE 80

ENTRYPOINT ["dotnet", "Tarea2_ArquiSistemas.dll"]