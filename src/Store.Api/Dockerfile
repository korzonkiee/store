FROM microsoft/dotnet:latest

RUN mkdir /app
COPY . /app
WORKDIR /app/Store.Api

RUN dotnet restore
RUN dotnet build

EXPOSE 5000/tcp

WORKDIR /app/Store.Migrations

RUN dotnet restore
RUN dotnet build

WORKDIR /app/Store.Api

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh