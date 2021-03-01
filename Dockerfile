FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal-arm64v8 AS runtime
COPY ./dumb-storage.k8s.j5/bin/Release/net5.0/publish/ App/
WORKDIR /App
VOLUME /dumb-storage-data
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "dumb-storage.k8s.j5.dll"]