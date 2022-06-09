FROM mcr.microsoft.com/dotnet/aspnet:6.0

COPY /bin/Release/net6.0/publish/ RequestPrototype/

ENV ASPNETCORE_ENVIRONMENT Production
ENV Logging__Console__FormatterName=Simple

EXPOSE 5000
WORKDIR /RequestPrototype
ENTRYPOINT ["dotnet", "RequestPrototype.dll",  "--urls=http://0.0.0.0:5000"]
