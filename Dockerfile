FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
COPY ./dumb-storage.k8s.j5/bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "dumb-storage.k8s.j5.dll"]