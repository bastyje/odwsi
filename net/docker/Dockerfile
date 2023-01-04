FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out .

COPY ./docker/cert/self.pass /etc/keys/self.pass
COPY ./docker/cert/self.key /etc/ssl/private/self.key
COPY ./docker/cert/self.crt /etc/ssl/certs/self.crt
COPY ./docker/cert/self.pfx /etc/ssl/certs/self.pfx


ENTRYPOINT ["dotnet", "Notepad.API.dll"]
