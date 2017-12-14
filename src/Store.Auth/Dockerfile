FROM microsoft/dotnet:latest

RUN mkdir /app
COPY . /app
WORKDIR /app/Store.Auth

RUN dotnet restore
RUN dotnet build

EXPOSE 5005/tcp

WORKDIR /app/Store.Migrations

RUN dotnet restore
RUN dotnet build

WORKDIR /app/Store.Auth

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
