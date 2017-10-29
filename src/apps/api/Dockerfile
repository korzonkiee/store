FROM microsoft/dotnet:latest

RUN mkdir /app
COPY . /app
WORKDIR /app/api

RUN dotnet restore
RUN dotnet build

EXPOSE 5000/tcp

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

